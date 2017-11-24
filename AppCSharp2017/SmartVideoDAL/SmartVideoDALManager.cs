using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using SmartVideoDTOLibrary;

namespace SmartVideoDAL
{
    public class SmartVideoDALManager
    {
        public SmartVideoDBManagementDataContext dc = null;
        private static SmartVideoDALManager _instance;
        
        public bool addHit(HitDTO h)
        {
            string typestr = h.Type.ToString();
            Hit newh = new Hit{ id = h.Id,  type = typestr, date = h.Date, hit1 = h.Hit };
            return Add<Hit>(newh, xg => xg.id == h.Id);
        }

        public List<HitDTO> getHit()
        {
            List<HitDTO> lh = new List<HitDTO>();
            var result = dc.ExecuteQuery<Hit>(@"SELECT * FROM dbo.Hit");
            if(result == null)
                return null;
            else
            {
                foreach(Hit h in result)
                {
                    lh.Add(new HitDTO(h.id, h.type, h.date, h.hit1));
                }
                return lh;
            }
        }

        public bool addUser(UserDTO h)
        {
            User newh = new User { login = h.Login, password = h.Password, prenom = h.Prenom };
            return Add<User>(newh, xg => xg.login == h.Login);
        }

        public List<UserDTO> getUser()
        {
            List<UserDTO> lh = new List<UserDTO>();
            var result = dc.ExecuteQuery<User>(@"SELECT * FROM dbo.User");
            if (result == null)
                return null;
            else
            {
                foreach (User h in result)
                {
                    lh.Add(new UserDTO(h.login, h.password, h.prenom));
                }
                return lh;
            }
        }

        public bool addLocation(LocationDTO h)
        {
            Location newh = new Location { id = h.Id, film_id = h.FilmId, film_name = h.FilmName, datedebut = h.DateDebut, datefin = h.DateFin, user_id = h.UserId};
            return Add<Location>(newh, xg => xg.id == h.Id);
        }

        public List<LocationDTO> getLocation()
        {
            List<LocationDTO> lh = new List<LocationDTO>();
            var result = dc.ExecuteQuery<Location>(@"SELECT * FROM dbo.Location");
            if (result == null)
                return null;
            else
            {
                foreach (Location h in result)
                {
                    lh.Add(new LocationDTO(h.id, h.film_id, h.film_name, h.datedebut, h.datefin, h.user_id));
                }
                return lh;
            }
        }

        #region truc need pas toucher
        public static SmartVideoDALManager Singleton(String servername, String dbname)
        {
            return _instance ?? (_instance = new SmartVideoDALManager(servername, dbname));
        }

        public static SmartVideoDALManager Singleton(String servername)
        {
            return _instance ?? (_instance = new SmartVideoDALManager(servername));
        }

        public SmartVideoDALManager(String servername, String dbname)
        {
            if (dbname == null || dbname == null)
                dc = new SmartVideoDBManagementDataContext();
            else
            {
                String constr = "Data Source = " + servername + " ; Initial Catalog =" + dbname + "; Integrated Security = True";
                dc = new SmartVideoDBManagementDataContext(constr);
            }
        }

        public SmartVideoDALManager(String servername)
        {
            if (servername == null)
                dc = new SmartVideoDBManagementDataContext();
            else
            {
                String constr = "Data Source = " + servername + " ; Initial Catalog = SmartVideoBD; Integrated Security = True";
                dc = new SmartVideoDBManagementDataContext(constr);
            }
        }

        public bool Add<T>(T rec, Func<T, bool> expr) where T : class
        {
            if (dc == null)
                throw new Exception("DAL not connected");
            try
            {
                // Query qui permet d'accéder à l'ensemble des objets d'une table dont le type es passé en paramètre
                IQueryable<T> query = ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc));
                if (!query.Where(expr).Any()) // Vérifie sur base de l'expression que aucun objet ne correspond au critère de recherche
                {
                    ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc)).InsertOnSubmit(rec);
                    dc.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Add<T, String, Q>(T rec, string sid) where T : class
        {
            if (dc == null)
                throw new Exception("DAL not connected");
            try
            {
                var valeur = rec.GetType().GetProperty(sid).GetValue(rec);
                IQueryable<T> query = ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc));
                query = Simplified<T, Q>(query, sid, (Q)valeur);
                if (query.Count() == 0)
                {
                    ((Table<T>)dc.GetType().GetProperty(typeof(T).Name + "s").GetValue(dc)).InsertOnSubmit(rec);
                    dc.SubmitChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        static IQueryable<T> Simplified<T, Q>(IQueryable<T> query, string propertyName, Q propertyValue)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(propertyName);
            return Simplified<T, Q>(query, propertyInfo, propertyValue);
        }

        static IQueryable<T> Simplified<T, Q>(IQueryable<T> query, PropertyInfo propertyInfo, Q propertyValue)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            MemberExpression m = Expression.MakeMemberAccess(e, propertyInfo);
            ConstantExpression c = Expression.Constant(propertyValue, propertyValue.GetType());
            BinaryExpression b = Expression.Equal(m, c);

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return query.Where(lambda);
        }
        #endregion
    }
}
