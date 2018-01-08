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

namespace SmartStatService
{
    public partial class Service1 : ServiceBase
    {
        private Timer _dailyTimer;
        private SmartVideoBLLManager _db;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _db = new SmartVideoBLLManager();
            _dailyTimer = new Timer(86400000); // Correspond a 24h
            _dailyTimer.AutoReset = true;
            _dailyTimer.Elapsed += DailyTimer_Elapsed;
            _dailyTimer.Start();
        }

        private void DailyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnStop()
        {
            _dailyTimer.Stop();
            _db = null;
        }
    }
}
