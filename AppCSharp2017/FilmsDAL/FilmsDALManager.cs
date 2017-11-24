using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDAL
{
    public class FilmsDALManager
    {
        public FilmsDBManagementDataContext dc = null;
        public List<String> lf = null;

        public FilmsDALManager()
        {
            if(dc == null)
            {
                dc = new FilmsDBManagementDataContext();
            }

            else
            {
                String constr = "DataSource = " + servername + " ; Initial Catalog = FilmDB; Integrated Security = True";
            }
        }

        public List<String> getFilm()
        {
            

            return lf;
        }

        public String getGenre()
        {


            return "genre";
        }

        public String getActor()
        {



            return "actor";
        }

        public String getProducer()
        {



            return "producer";
        }
    }
}
