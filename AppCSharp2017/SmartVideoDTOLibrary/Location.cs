using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVideoDTOLibrary
{
    public class LocationDTO
    {
        private int id;
        private int filmId;
        private string filmName;
        private DateTime dateDebut;
        private DateTime dateFin;
        private string userId;

        public LocationDTO(string userId, DateTime dateFin, DateTime dateDebut, string filmName, int filmId, int id)
        {
            UserId = userId;
            DateFin = dateFin;
            DateDebut = dateDebut;
            FilmName = filmName;
            FilmId = filmId;
            Id = id;
        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }


        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }
            

        public string FilmName
        {
            get { return filmName; }
            set { filmName = value; }
        }


        public int FilmId
        {
            get { return filmId; }
            set { filmId = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
