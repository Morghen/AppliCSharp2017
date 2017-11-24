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

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        #endregion
        #region constructeur
        public UserDTO(string login, string password, string prenom)
        {
            Login = login;
            Password = password;
            Prenom = prenom;
        }
        #endregion
    }
}
