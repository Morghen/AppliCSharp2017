using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SmartWCFService;

namespace SmartWCFWindowService
{
    public partial class SmartWcfService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public SmartWcfService()
        {
            InitializeComponent();
            ServiceName = "SmartWcfService";
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(SmartWcf));
            serviceHost.Open();
            EventLog.WriteEntry("Démarrage de mon service", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
            EventLog.WriteEntry("Arrêt de mon service", EventLogEntryType.Information);
        }
    }
}
