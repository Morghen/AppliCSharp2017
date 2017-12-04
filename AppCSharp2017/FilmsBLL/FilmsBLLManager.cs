using FilmsDAL;
using FilmsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#pragma warning disable IDE1006
namespace FilmsBLL
{
    public class FilmsBLLManager
    {
        #region VARIABLES MEMBRES
        private static int _version = 2;// 2 remy   1 antoine
        private FilmsDALManager _db;
        #endregion
        
        public FilmsBLLManager()
        {
            if (Environment.MachineName == "TOINE")
            {
                Console.WriteLine("TOINE");
                _version = 1;
            }
            else
            {
                _version = 2;
            }
            if (Version == 2)
                Db = new FilmsDALManager(@"(localdb)\MSSQLLocalDB", "FilmDB");
            else
                Db = new FilmsDALManager(@"(localdb)\ProjectsV13", "FilmDB");
        }

        /*
        int cursorposition= 0;
        int pagesize = 10;
        getFirstFilms()
        {
            cursorposition = 0;
            Db.getNfilm(0, pagesize);
        }
        getNextFilms()
        {
            cursorpositin += pagesize;
            GetNfilm(cursorposition, pagesize);
        }

        */
        public List<FilmDTO> getFilmList(int offset,int nbr)
        {
            return Db.getFilm(offset, nbr);
        }

        public int CountFilm()
        {
            return Db.getCountFilm();
        }

        public bool UpdateFilm(int idFilm, string url)
        {
            FilmDTO f = new FilmDTO();
            f.Id = idFilm;
            f.Url = url;
            return Db.updateFilm(f);
        }

        public FilmDTO RefreshFilm(int idFilm)
        {
            Db.Refresh <Film>(xg => xg.id == idFilm);
            return Db.getFilm(idFilm);
        }

        public int Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public FilmsDALManager Db
        {
            get { return _db; }
            set { _db = value; }
        }
    }
}


#pragma warning restore IDE1006
