using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
       // private string path;
        //private StreamWriter sw;
        public SmartWcf()
        {
            fm = new FilmsBLLManager();
            //path = @"D:\Cours\csharp\dump\log.txt";
            //sw = new StreamWriter(path);
        }

        public List<FilmDTO> getFilmList(int offset, int nbr)
        {
            write("list film"+offset+" "+nbr);
            return fm.getFilmList(offset, nbr);
        }

        public FilmDTO GetFilmDetails(int idfilm)
        {
            try
            {
                FilmDTO film = new FilmDTO(fm.getFilmDetails(idfilm));
                return film;
            }
            catch (Exception ex)
            {
                throw new System.ServiceModel.FaultException(ex.Message);
            }
        }

        public List<FilmDTO> searchFilm(string reference,string type)
        {
            List<FilmDTO> tmp = fm.searchFilm(reference, type);
            return tmp;
        }

        public List<ActorDTO> searchActor(string name)
        {
            List<ActorDTO> tmp = fm.searchActor(name);
            return tmp;
        }

        public int CountFilm()
        {
            write("count film");
            return fm.CountFilm();
        }

        public bool UpdateFilm(int idFilm, string url)
        {
            write("update film"+idFilm+" "+url);
            return fm.UpdateFilm(idFilm, url);
        }

        public FilmDTO RefreshFilm(int idFilm)
        {
            write("refresh film"+idFilm);
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

        public void write(string s)
        {
            Console.WriteLine(""+DateTime.Now +" "+ s);
            //sw.WriteLine(""+DateTime.Now +" "+ s);
        }
    }
}
