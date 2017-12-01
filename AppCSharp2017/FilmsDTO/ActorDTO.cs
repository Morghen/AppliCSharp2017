using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable 0659
namespace FilmsDTO
{
    public class ActorDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string character;

        public ActorDTO()
        {
        }

        public ActorDTO(int id, string name, string character)
        {
            Id = id;
            Name = name;
            Character = character;
        }

        public string Character
        {
            get { return character; }
            set { character = value; }
        }
        public override bool Equals(object obj)
        {
            var dTO = obj as ActorDTO;
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
