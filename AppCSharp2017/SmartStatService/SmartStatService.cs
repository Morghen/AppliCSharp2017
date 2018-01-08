using SmartVideoBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
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

        public SmartStatService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _toMidnightTimer = new Timer();
            _toMidnightTimer.AutoReset = false;
            _toMidnightTimer.Elapsed += _toMidnightTimer_Elapsed;
            TimeSpan delay = DateTime.Today.AddDays(1) - DateTime.Now;
            _toMidnightTimer.Interval = delay.TotalMilliseconds;
            _toMidnightTimer.Start();
        }

        private void _toMidnightTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _toMidnightTimer.Stop();
            _db = new SmartVideoBLLManager();
            _dailyTimer = new Timer(86400000); // Correspond a 24h
            _dailyTimer.AutoReset = true;
            _dailyTimer.Elapsed += DailyTimer_Elapsed;
            _dailyTimer.Start();
        }

        private void DailyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_db.doStat(DateTime.Today.AddDays(-1)))
            {

            }
        }

        protected override void OnStop()
        {
            _dailyTimer.Stop();
            _db = null;
        }
    }
}
