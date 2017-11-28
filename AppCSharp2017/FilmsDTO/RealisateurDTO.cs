using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDTO
{
    public class RealisateurDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public RealisateurDTO()
        {
        }

        public RealisateurDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override bool Equals(object obj)
        {
            var dTO = obj as RealisateurDTO;
            return dTO != null &&
                   Id == dTO.Id;
        }
        public override string ToString()
        {
            string str = "";
            PropertyInfo[] pi = this.GetType().GetProperties();
            foreach (PropertyInfo t in pi)
            {
                str += "" + this.GetType().GetProperty(t.Name).GetValue(this) + " ";
            }
            return str;
        }
    }
}
