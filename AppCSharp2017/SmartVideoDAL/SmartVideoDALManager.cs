using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using SmartVideoDTOLibrary;
using System.Data.Linq.Mapping;

#pragma warning disable IDE1006

namespace SmartVideoDAL
{
    public class SmartVideoDALManager
    {
        public SmartVideoDBManagementDataContext dc = null;
        private static SmartVideoDALManager _instance;
        
        public bool addHit(HitDTO h)
        {
            Hit newh = new Hit{ id = h.Id,  type = (int)h.Type, date = h.Date, hit = h.Hit };
            return Add<Hit>(newh, xg => xg.Equals(newh));
        }

        public bool updateHit(HitDTO h)
        {
            Hit newh = new Hit { id = h.Id, type = (int)h.Type, date = h.Date, hit = h.Hit };
            return Update<Hit>(newh, xg => xg.Equals(newh));
        }

        public List<HitDTO> getHit()
        {
            List<HitDTO> lh = new List<HitDTO>();
            var result = dc.ExecuteQuery<Hit>(@"SELECT * FROM [dbo].[Hit]");
            if(result == null)
                return lh;
            else
            {
                foreach(Hit h in result)
                {
                    lh.Add(new HitDTO(h.id, (TypeEnum)h.type, h.date, h.hit));
                }
                return lh;
            }
        }

        public HitDTO getHit(int tid, TypeEnum tte, DateTime tdt)
        {
            List<Hit> lt = getList<Hit>(xg => xg.Equals(new Hit() {id = tid, type = (int) tte, date = tdt, hit = 0}));
            if (lt.Count < 1)
            {
                return null;
            }
            Hit newh = lt.First();
            if (newh == null)
            {
                return null;
            }
            return new HitDTO(newh.id, (TypeEnum)newh.type, newh.date, newh.hit);
        }
        
        public bool addUser(UserDTO h)
        {
            User newh = new User { login = h.Login, password = h.Password, prenom = h.Prenom };
            return Add<User>(newh, xg => xg.Equals(newh));
        }

        public bool updateUser(UserDTO h)
        {
            User newh = new User { login = h.Login, password = h.Password, prenom = h.Prenom };
            return Update<User>(newh, xg => xg.Equals(newh));
        }

        public List<UserDTO> getUser()
        {
            List<UserDTO> lh = new List<UserDTO>();
            var result = dc.ExecuteQuery<User>(@"SELECT * FROM [dbo].[User]");
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
            return Add<Location>(newh, xg => xg.Equals(newh));
        }

        public bool updateLocation(LocationDTO h)
        {
            Location newh = new Location { id = h.Id, film_id = h.FilmId, film_name = h.FilmName, datedebut = h.DateDebut, datefin = h.DateFin, user_id = h.UserId };
            return Update<Location>(newh, xg => xg.Equals(newh));
        }

        public List<LocationDTO> getLocation()
        {
            List<LocationDTO> lh = new List<LocationDTO>();
            var result = dc.ExecuteQuery<Location>(@"SELECT * FROM [dbo].[Location]");
            if (result == null)
                return null;
            else
            {
                foreach (Location h in result)
                {
                    lh.Add(new LocationDTO(h.id, h.film_id??0, h.film_name, h.datedebut.GetValueOrDefault(), h.datefin.GetValueOrDefault(), h.user_id));
                }
                return lh;
            }
        }

        public bool addStatistique(StatistiqueDTO h)
        {
            Statistique newh = new Statistique { id = h.Id, date = h.Date, type = (int)h.Type, position = h.Position };
            return Add<Statistique>(newh, xg => xg.Equals(newh));
        }

        public bool updateStatistique(StatistiqueDTO h)
        {
            Statistique newh = new Statistique { id = h.Id, date = h.Date, type = (int)h.Type, position = h.Position };
            return Update<Statistique>(newh, xg => xg.Equals(newh));
        }

        public List<StatistiqueDTO> getStatistique()
        {
            List<StatistiqueDTO> lh = new List<StatistiqueDTO>();
            var result = dc.ExecuteQuery<Statistique>(@"SELECT * FROM [dbo].[Statistiques]");
            if (result == null)
                return null;
            else
            {
                foreach (Statistique h in result)
                {
                    lh.Add(new StatistiqueDTO(h.id, (TypeEnum)h.type, h.date, h.position));
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
                    foreach(PropertyInfo item in mi)
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
#pragma warning restore IDE1006 // Naming Styles


