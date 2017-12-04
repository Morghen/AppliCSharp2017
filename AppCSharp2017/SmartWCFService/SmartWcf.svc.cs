using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FilmsBLL;
using FilmsDTO;
using System.ServiceProcess;

namespace SmartWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SmartWcf : ISmartWcf
    {
        private FilmsBLLManager fm;
        public SmartWcf()
        {
            fm = new FilmsBLLManager();
        }

        public List<FilmDTO> getFilmList(int offset, int nbr)
        {
            return fm.getFilmList(offset, nbr);
        }

        public int CountFilm()
        {
            return fm.CountFilm();
        }

        public bool UpdateFilm(int idFilm, string url)
        {
            return fm.UpdateFilm(idFilm, url);
        }

        public FilmDTO RefreshFilm(int idFilm)
        {
            return fm.RefreshFilm(idFilm);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
