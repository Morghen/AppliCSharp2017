using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartVideoDTOLibrary;

namespace SmartVideoDAL
{
    public class SmartVideoDALManager
    {
        SmartVideoDBManagementDataContext dc = null;
        private static SmartVideoDALManager _instance;

        public static SmartVideoDALManager Singleton(String servername, String dbname)
        {
            return _instance ?? (_instance = new SmartVideoDALManager(servername, dbname));
        }

        public SmartVideoDALManager(String servername, String dbname)
        {
            if (dbname == null || dbname == null)
                dc = new SmartVideoDBManagementDataContext();
            else
            {
                String constr = "DataSource = " + servername + " ; Initial Catalog =" + dbname + "; Integrated Security = True";
                dc = new SmartVideoDBManagementDataContext(constr);
            }
        }

        public SmartVideoDALManager(String servername)
        {
            if (servername == null )
                dc = new SmartVideoDBManagementDataContext();
            else
            {
                String constr = "DataSource = " + servername + " ; Initial Catalog = SmartVideoBD; Integrated Security = True";
                dc = new SmartVideoDBManagementDataContext(constr);
            }
        }

        public bool addHit(int id, TypeEnum type, DateTime dt)
        {
            return false;
        }

        public bool updateHit(int id, TypeEnum type, DateTime dt)
        {
            return false;
        }
    }
}
