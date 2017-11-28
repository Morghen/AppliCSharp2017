using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDTO
{
    public class FilmRealisateurDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int id_film;

        public int IdFilm
        {
            get { return id_film; }
            set { id_film = value; }
        }
        private int id_realisateur;

        public FilmRealisateurDTO()
        {
        }

        public FilmRealisateurDTO(int id, int idFilm, int idRealisateur)
        {
            Id = id;
            IdFilm = idFilm;
            IdRealisateur = idRealisateur;
        }

        public int IdRealisateur
        {
            get { return id_realisateur; }
            set { id_realisateur = value; }
        }

        public override bool Equals(object obj)
        {
            var dTO = obj as FilmRealisateurDTO;
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
