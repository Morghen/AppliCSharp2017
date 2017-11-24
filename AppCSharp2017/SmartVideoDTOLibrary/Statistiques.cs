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
        private int type;
        private int position;

        public StatistiquesDTOs(int position, int type, DateTime date, int id)
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


        public int Type
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

    }
}
