using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVideoDTOLibrary
{
    public class StatistiqueDTO
    {
        private int id;
        private DateTime date;
        private TypeEnum type;
        private int position;

        public StatistiqueDTO(int id, TypeEnum type, DateTime date, int position)
        {
            Position = position;
            Type = type;
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
            if (!(obj is StatistiqueDTO))
                return false;
            return id == ((StatistiqueDTO) obj).id;
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
