using System.Reflection;
#pragma warning disable CS0659
namespace FilmsDTO
{
    public class FilmGenreDTO : IInterfaceFilmDTO
    {
        private int id;
        private int id_film;
        private int if_genre;

        public FilmGenreDTO()
        {
        }

        public FilmGenreDTO(int idGenre, int idFilm, int id)
        {
            IdGenre = idGenre;
            IdFilm = idFilm;
            Id = id;
        }

        public int IdGenre
        {
            get { return if_genre; }
            set { if_genre = value; }
        }


        public int IdFilm
        {
            get { return id_film; }
            set { id_film = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override bool Equals(object obj)
        {
            var dTO = obj as FilmGenreDTO;
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
