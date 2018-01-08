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
            throw new NotImplementedException();
        }

        protected override void OnStop()
        {
            _dailyTimer.Stop();
            _db = null;
        }
    }
}
