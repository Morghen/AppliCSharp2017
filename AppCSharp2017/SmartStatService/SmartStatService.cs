using SmartVideoBLL;
using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Timers;


namespace SmartStatService
{
    [RunInstaller(true)]
    public class SmartStatServiceInstaller : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public SmartStatServiceInstaller() : base()
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.StartType = ServiceStartMode.Manual;

            serviceInstaller.ServiceName = "SmartStatService";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            EventLog.WriteEntry("SmartStatService","Installation de mon service", EventLogEntryType.Information);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            EventLog.WriteEntry("SmartStatService","Désinstallation de mon service", EventLogEntryType.Information);
        }
    }

    public partial class SmartStatService : ServiceBase
    {
        private Timer _toMidnightTimer;
        private Timer _dailyTimer;
        private SmartVideoBLLManager _db;
        public string pathfile = @"d:\Cours\csharp\StatService\log.txt";
        public StreamWriter outputfile=null;

        public SmartStatService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _toMidnightTimer = new Timer();
                _toMidnightTimer.AutoReset = false;
                _toMidnightTimer.Elapsed += new ElapsedEventHandler(_toMidnightTimer_Elapsed);

                TimeSpan delay = DateTime.Today.AddDays(1) - DateTime.Now;
                _toMidnightTimer.Interval = delay.TotalMilliseconds;
                write("delay = " + _toMidnightTimer.Interval + "  --  " + delay);
                _toMidnightTimer.Start();
                //_toMidnightTimer.Enabled = true;
                write("midnight timer start");
            }
            catch (Exception ex)
            {
                write(ex.GetType()+" - "+ex.Message);
            }
        }

        private void _toMidnightTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                write("midnight timer stop");
                try
                {
                    _db = new SmartVideoBLLManager();
                }
                catch (Exception ex)
                {
                    write(ex.GetType() + " - " + ex.Message);
                }
                _dailyTimer = new Timer(86400000); // Correspond a 24h
                //_dailyTimer = new Timer(60000);
                _dailyTimer.AutoReset = true;
                _dailyTimer.Elapsed += DailyTimer_Elapsed;
                write("daily timer start");
                _db.doStat(DateTime.Today.AddDays(-1));
                write("do stat OK");
                /*if (_db.doStat(DateTime.Today.AddDays(-1)))
                {
                    write("do stat OK");
                }
                else
                {
                    write("do stat ERREUR");
                }*/
                _dailyTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                write(ex.GetType() + " - " + ex.Message);
            }
        }

        private void DailyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                write("time elapsed !");
                if (_db.doStat(DateTime.Today.AddDays(-1)))
                {
                    write("do stat OK");
                }
                else
                {
                    write("do stat ERREUR");
                }
            }
            catch (Exception ex)
            {
                write(ex.GetType()+" - "+ex.Message);
            }
        }

        protected override void OnStop()
        {
            try
            {
                write("service stoped");
                _dailyTimer.Enabled = false;
                _db = null;
                outputfile.Close();
            }
            catch (Exception ex)
            {
                write(ex.GetType()+" - "+ex.Message);
            }
        }

        public void write(string t)
        {
            outputfile = File.AppendText(pathfile);
            if (outputfile != null)
            {
                outputfile.WriteLine(DateTime.Now + " : " + t);
                outputfile.Flush();
                outputfile.Close();
            }

            EventLog.WriteEntry(DateTime.Now + " : "+t, EventLogEntryType.Information);
        }
    }
}
