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
        private static int _version = 2;
        private FilmsDALManager _db;
        #endregion
        
        public FilmsBLLManager()
        {
            if (Version == 1)
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




        public string getFilmTitle(FilmDTO obj)
        {
            return obj.Title;
        }
        public string getFilmId(FilmDTO obj)
        {
            return obj.Id.ToString();
        }
        public string getFilmOriginalTitle(FilmDTO obj)
        {
            return obj.OriginalTitle;
        }
        public string getFilmRuntime(FilmDTO obj)
        {
            return obj.Runtime.ToString();
        }
        public string getFilmPosterpath(FilmDTO obj)
        {
            return obj.PosterPath;
        }
        public string getFilmURL(FilmDTO obj)
        {
            return obj.Url;
        }
        public List<string> getFilmInfos(FilmDTO obj)
        {
            List<string> objlist = new List<string>();
            objlist.Add(getFilmId(obj));
            objlist.Add(getFilmTitle(obj));
            objlist.Add(getFilmOriginalTitle(obj));
            objlist.Add(getFilmRuntime(obj));
            objlist.Add(getFilmPosterpath(obj));
            objlist.Add(getFilmURL(obj));
            return objlist;
        }
        public List<FilmDTO> getFilmList(int offset,int nbr)
        {
            return Db.getFilm(offset, nbr);
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
