using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Web;

namespace SmartWCFService
{
    public class SmartWcfService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public SmartWcfService()
        {
            ServiceName = "SmartWcfService";
        }

        public static void Main()
        {
            ServiceBase.Run(new SmartWcfService());
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