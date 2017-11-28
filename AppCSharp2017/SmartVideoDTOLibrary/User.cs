using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVideoDTOLibrary
{
    public class UserDTO
    {
        #region variables
        private string login;
        private string password;
        private string prenom;

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }



        #endregion
        #region constructeur
        public UserDTO(string login, string password, string prenom)
        {
            Login = login;
            Password = password;
            Prenom = prenom;
        }

        public override string ToString()
        {
            return ""+Login+" "+Password+" "+Prenom;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UserDTO))
                return false;
            return Login == ((UserDTO) obj).Login;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
