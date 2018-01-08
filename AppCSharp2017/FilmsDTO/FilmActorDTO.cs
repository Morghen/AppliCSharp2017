using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable 0659
namespace FilmsDTO
{
    public class FilmActorDTO : IInterfaceFilmDTO
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
        private int id_actor;

        public FilmActorDTO()
        {
        }

        public FilmActorDTO(int id, int idFilm, int idActor)
        {
            Id = id;
            IdFilm = idFilm;
            IdActor = idActor;
        }

        public int IdActor
        {
            get { return id_actor; }
            set { id_actor = value; }
        }
        public override bool Equals(object obj)
        {
            var dTO = obj as FilmActorDTO;
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
