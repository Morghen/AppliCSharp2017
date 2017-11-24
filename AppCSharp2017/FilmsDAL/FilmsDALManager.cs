using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDAL
{
    public class FilmsDALManager
    {
        private static FilmsDALManager _instance;
        public FilmsDBManagementDataContext dc = null;
        public List<String> lf = null;

        public static FilmsDALManager Singleton(String servername, String dbname)
        {
            return _instance ?? (_instance = new FilmsDALManager(servername, dbname));
        }

        public static FilmsDALManager Singleton(String servername)
        {
            return _instance ?? (_instance = new FilmsDALManager(servername));
        }

        public FilmsDALManager(String servername, String dbname)
        {
            if (dbname == null || dbname == null)
                dc = new FilmsDBManagementDataContext();
            else
            {
                String constr = "Data Source=" + servername + ";Initial Catalog=" + dbname + ";Integrated Security=True";
                dc = new FilmsDBManagementDataContext(constr);
            }
        }

        public FilmsDALManager(String servername)
        {
            if (servername == null)
                dc = new FilmsDBManagementDataContext();
            else
            {
                String constr = "Data Source=" + servername + ";Initial Catalog=FilmDB;Integrated Security=True";
                dc = new FilmsDBManagementDataContext(constr);
            }
        }

        public List<String> getFilm(int idFilm)
        {
            

            return lf;
        }

        public List<Genre> getGenre(int idFilm)
        {
            List<Genre> strlist = new List<Genre>();
            var result = dc.ExecuteQuery<Genre>(@"SELECT DISTINCT name,dbo.Genre.id FROM dbo.Genre JOIN dbo.FilmGenre ON dbo.Genre.id = dbo.FilmGenre.id_genre WHERE dbo.FilmGenre.id_film = {0}", idFilm);
            if (result == null)
                return null;
            else
            {
                foreach (Genre str in result)
                {
                    strlist.Add(str);
                }
                return strlist;
            }
        }

        public List<Actor> getActor(int idFilm)
        {
            List<Actor> strlist = new List<Actor>();
            var result = dc.ExecuteQuery<Actor>(@"SELECT DISTINCT name,dbo.Actor.id,character FROM dbo.Actor JOIN dbo.FilmActor ON dbo.Actor.id = dbo.FilmActor.id_actor WHERE dbo.FilmActor.id_film = {0}", idFilm);
            if (result == null)
                return null;
            else
            {
                foreach (Actor str in result)
                {
                    strlist.Add(str);
                }
                return strlist;
            }
        }

        public List<Realisateur> getProducer(int idFilm)
        {
            List<Realisateur> strlist = new List<Realisateur>();
            var result = dc.ExecuteQuery<Realisateur>(@"SELECT DISTINCT name,dbo.Realisateur.id FROM dbo.Realisateur JOIN dbo.FilmRealisateur ON dbo.Realisateur.id = dbo.FilmRealisateur.id_realisateur WHERE dbo.FilmRealisateur.id_film = {0}", idFilm);
            if (result == null)
                return null;
            else
            {
                foreach (Realisateur str in result)
                {
                    strlist.Add(str);
                }
                return strlist;
            }

            return strlist;
        }
    }
}
