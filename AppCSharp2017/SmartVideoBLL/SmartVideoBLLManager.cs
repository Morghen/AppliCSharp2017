using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using SmartVideoDAL;
using SmartVideoDTOLibrary;

namespace SmartVideoBLL
{
    public class SmartVideoBLLManager
    {
        private static int _version = 2;// 2 remy   1 antoine
        public  SmartVideoDALManager svDal;

        public SmartVideoBLLManager()
        {
            if (Environment.MachineName == "TOINE")
            {
                _version = 1;
            }
            else
            {
                _version = 2;
            }
            svDal = new SmartVideoDALManager(@"(localdb)\"+(_version == 1 ? "ProjectsV13" : "MSSQLLocalDB"));
        }

        public bool LouerFilm(String iduser, int idFilm, String filmname,DateTime duree)
        {
            LocationDTO l = new LocationDTO(svDal.getLocation().Last().Id+1,idFilm,filmname, DateTime.Now, duree,iduser);
            return svDal.addLocation(l);
        }

        public bool Login(String username, String password)
        {
            List<UserDTO> luser = svDal.getUser();
            UserDTO user = new UserDTO(username, password, username);
            return luser.Exists(dto => dto.Login == user.Login && dto.Password == user.Password);
        }

        public bool register(UserDTO user)
        {
            return svDal.addUser(user);
        }

        public UserDTO getUser(String username)
        {
            return svDal.getUser().FindLast(dto => dto.Login == username);
        }

        public List<LocationDTO> getLocation(int iduser)
        {
            return new List<LocationDTO>(svDal.getLocation().Where(xg=>xg.Id == iduser));
        }

        public List<StatistiqueDTO> getStatistique()
        {
            return new List<StatistiqueDTO>(svDal.getStatistique());
        }

        public List<StatistiqueDTO> getStatistique(DateTime date)
        {
            return new List<StatistiqueDTO>(svDal.getStatistique().Where(xg => xg.Date.Year == date.Year && xg.Date.Month == date.Month && xg.Date.Day == date.Day));
        }

        public bool incHitFilm(int idFilm,string type)
        {
            HitDTO h = null;
            if (type.Equals("Film"))
            {
                h = svDal.getHit(idFilm, TypeEnum.Film, DateTime.Today);
            } 
            else
            {
                h = svDal.getHit(idFilm, TypeEnum.Actor, DateTime.Today);
            }            
            if (h == null)
            {
                if(type.Equals("Film"))
                {
                    //hit non existant faut ajouter
                    h = new HitDTO(idFilm, TypeEnum.Film, DateTime.Today, 1);
                    return svDal.addHit(h);
                }
                else
                {
                    h = new HitDTO(idFilm, TypeEnum.Actor, DateTime.Today, 1);
                    return svDal.addHit(h);
                }           
            }
            h.Hit++;
            return svDal.updateHit(h); ;
        }
        
    }
}
