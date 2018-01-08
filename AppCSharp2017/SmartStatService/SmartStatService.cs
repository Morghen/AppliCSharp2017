using SmartVideoBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SmartVideoDTOLibrary;


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
            _toMidnightTimer = new Timer();
            _toMidnightTimer.AutoReset = false;
            _toMidnightTimer.Elapsed += new ElapsedEventHandler(_toMidnightTimer_Elapsed);

            TimeSpan delay = DateTime.Today.AddDays(1) - DateTime.Now;
            _toMidnightTimer.Interval = delay.TotalMilliseconds;
            write("delay = "+_toMidnightTimer.Interval + "  --  " + delay);
            //_toMidnightTimer.Start();
            _toMidnightTimer.Enabled = true;
            write("midnight timer start");
        }

        private void _toMidnightTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
<<<<<<< HEAD
            _toMidnightTimer.Enabled = false;
=======
>>>>>>> 88e66aa29f27795a4d0665af9be3f95205ec7129
            write("midnight timer stop");
            _db = new SmartVideoBLLManager();
            _dailyTimer = new Timer(86400000); // Correspond a 24h
            _dailyTimer.AutoReset = true;
            _dailyTimer.Elapsed += DailyTimer_Elapsed;
            _dailyTimer.Start();
            write("daily timer start");
            //_toMidnightTimer.Stop();
        }

        private void DailyTimer_Elapsed(object sender, ElapsedEventArgs e)
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

        protected override void OnStop()
        {
            write("service stoped");
            _dailyTimer.Stop();
            _db = null;
            outputfile.Close();
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
