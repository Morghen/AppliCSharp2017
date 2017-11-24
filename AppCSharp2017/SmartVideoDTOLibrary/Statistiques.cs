using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVideoDTOLibrary
{
    public class StatistiquesDTOs
    {
        private int id;
        private DateTime date;
        private TypeEnum type;
        private int position;

        public StatistiquesDTOs(int position, TypeEnum type, DateTime date, int id)
        {
            Position = position;
            Type = type;
            Date = date;
            Id = id;
        }

        public StatistiquesDTOs(int position, string type, DateTime date, int id)
        {
            Position = position;
            Type = (TypeEnum)Enum.Parse(typeof(TypeEnum), type);
            Date = date;
            Id = id;
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }


        public TypeEnum Type
        {
            get { return type; }
            set { type = value; }
        }


        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return ""+Id+" "+Type+" "+Date+" "+Position;
        }
    }
}
