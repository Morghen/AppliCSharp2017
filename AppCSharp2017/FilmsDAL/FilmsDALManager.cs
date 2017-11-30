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

        public FilmDTO getFilm(int idFilm)
        {
            Film tmp = getList<Film>(xg => xg.id == idFilm).First();
            
            if (tmp == null)
                return null;
            return new FilmDTO(tmp.id, tmp.title,tmp.original_title, tmp.runtime??0, tmp.posterpath, tmp.url);
        }

        public GenreDTO getGenre(int idGenre)
        {
            Genre tmp = getList<Genre>(xg => xg.id == idGenre).First();
            if (tmp == null)
                return null;
            return new GenreDTO(tmp.id, tmp.name);
        }

        public ActorDTO getActor(int idActor)
        {
            Actor tmp = getList<Actor>(xg => xg.id == idActor).First();
            if (tmp == null)
                return null;
            return new ActorDTO(tmp.id, tmp.name, tmp.character);
        }

        public RealisateurDTO getProducer(int idProducer)
        {
            Realisateur tmp = getList<Realisateur>(xg => xg.id == idProducer).First();
            if (tmp == null)
                return null;
            return new RealisateurDTO(tmp.id, tmp.name);
        }

        public List<FilmDTO> getFilm(int debut, int nbr)
        {
            List<FilmDTO> lh = new List<FilmDTO>();
            List<Film> t = getList<Film>(debut, nbr);
            if (t == null)
                return null;
            foreach (Film tmp in t)
            {
                lh.Add(new FilmDTO(tmp.id, tmp.title, tmp.original_title, tmp.runtime ?? 0, tmp.posterpath, tmp.url));
            }
            return lh;
        }

        public List<GenreDTO> getGenre(int debut, int nbr)
        {
            List<GenreDTO> lh = new List<GenreDTO>();
            List<Genre> t = getList<Genre>(debut, nbr);
            if (t == null)
                return null;
            else
            {
                foreach (Genre tmp in t)
                {
                    lh.Add(new GenreDTO(tmp.id, tmp.name));
                }
                return lh;
            }
        }

        public List<ActorDTO> getActor( int debut, int nbr)
        {
            List<ActorDTO> lh = new List<ActorDTO>();
            List<Actor> t = getList<Actor>(debut, nbr);
            if (t == null)
                return null;
            else
            {
                foreach (Actor tmp in t)
                {
                    lh.Add(new ActorDTO(tmp.id, tmp.name, tmp.character));
                }
                return lh;
            }
        }

        public List<RealisateurDTO> getProducer(int debut, int nbr)
        {
            List<RealisateurDTO> lh = new List<RealisateurDTO>();
            List<Realisateur> t = getList<Realisateur>(debut, nbr);
            if (t == null)
                return null;
            else
            {
                foreach (Realisateur tmp in t)
                {
                    lh.Add(new RealisateurDTO(tmp.id, tmp.name));
                }
                return lh;
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

        public List<T> getList<T>( int debut, int nbr) where T : class
        {
            if (dc == null)
                throw new Exception("DAL not connected");
            List<T> list = new List<T>();
            try
            {
                // Query qui permet d'accéder à l'ensemble des objets d'une table dont le type es passé en paramètre
                IQueryable<T> query = ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc));
                IQueryable<T> t = query.Skip(debut).Take(nbr);
                foreach (T tmp in t) // Vérifie sur base de l'expression que aucun objet ne correspond au critère de recherche
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