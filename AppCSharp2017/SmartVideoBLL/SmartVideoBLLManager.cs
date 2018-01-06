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

        public bool LouerFilm(int idFilm, int durée)
        {

            return false;
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

        public bool incHitFilm(int idFilm)
        {
            HitDTO h = svDal.getHit(idFilm, TypeEnum.Film, DateTime.Today);
            if (h == null)
            {
                //hit non existant faut ajouter
                h = new HitDTO(idFilm, TypeEnum.Film, DateTime.Today, 1);
                return svDal.addHit(h);
            }
            h.Hit++;
            return svDal.updateHit(h); ;
        }
        
        
    }
}
