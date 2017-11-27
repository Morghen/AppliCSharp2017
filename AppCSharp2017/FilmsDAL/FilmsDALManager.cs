using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FilmsDTO;

#pragma warning disable IDE1006
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

        public List<FilmDTO> getFilm(int idFilm)
        {
            List<FilmDTO> lf = new List<FilmDTO>();
            foreach (Film tmp in getList<Film>(xg => xg.id == idFilm))
            {
                FilmDTO fd = new FilmDTO(tmp.id, tmp.title,tmp.original_title, tmp.runtime??0, tmp.posterpath);
                lf.Add(fd);
            }
            return lf;
        }

        public List<GenreDTO> getGenre(int idGenre)
        {
            List<GenreDTO> lf = new List<GenreDTO>();
            foreach (Genre tmp in getList<Genre>(xg => xg.id == idGenre))
            {
                GenreDTO fd = new GenreDTO(tmp.id, tmp.name);
                lf.Add(fd);
            }
            return lf;
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
        }

        public List<T> getList<T>(Func<T, bool> expr) where T : class
        {
            if (dc == null)
                throw new Exception("DAL not connected");
            List<T> list = new List<T>();
            try
            {
                // Query qui permet d'accéder à l'ensemble des objets d'une table dont le type es passé en paramètre
                IQueryable<T> query = ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc));
                foreach (T tmp in query.Where(expr)) // Vérifie sur base de l'expression que aucun objet ne correspond au critère de recherche
                {
                    list.Add(tmp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
            return list;
        }

        public List<T> getList<T>(Func<T, bool> expr, int debut, int nbr) where T : class
        {
            if (dc == null)
                throw new Exception("DAL not connected");
            List<T> list = new List<T>();
            try
            {
                // Query qui permet d'accéder à l'ensemble des objets d'une table dont le type es passé en paramètre
                IQueryable<T> query = ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc));
                foreach (T tmp in query.Where(expr).Skip(debut).Take(nbr)) // Vérifie sur base de l'expression que aucun objet ne correspond au critère de recherche
                {
                    list.Add(tmp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
            return list;
        }

        public bool Update<T>(T rec, Func<T, bool> expr) where T : class
        {
            if (dc == null)
                throw new Exception("DAL not connected");
            //try
            {
                T tmp;
                PropertyInfo[] mi;
                // Query qui permet d'accéder à l'ensemble des objets d'une table dont le type es passé en paramètre
                IQueryable<T> query = ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc));
                if (((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc)).Contains<T>(rec)) // Vérifie sur base de l'expression que aucun objet ne correspond au critère de recherche
                {
                    tmp = ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc)).First<T>(expr);
                    mi = tmp.GetType().GetProperties();
                    foreach (PropertyInfo item in mi)
                    {
                        ColumnAttribute ca = (ColumnAttribute)((item.GetCustomAttribute(typeof(ColumnAttribute))));
                        if (!(ca.IsPrimaryKey))
                            tmp.GetType().GetProperty(item.Name).SetValue(tmp, (rec.GetType().GetProperty(item.Name)).GetValue(rec));
                    }
                    dc.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
#pragma warning restore IDE1006 // Naming Styles