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

        public SmartVideoDALManager()
        {
            if(dc == null)
            {
                dc = new SmartVideoDBManagementDataContext();
            }
        }

        public bool addHit(int id, TypeEnum type, DateTime dt)
        {
            return false;
        }
    }
}
