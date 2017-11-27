using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDTO
{
    public class FilmDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string original_title;

        public string OriginalTitle
        {
            get { return original_title; }
            set { original_title = value; }
        }

        private int runtime;

        public int Runtime
        {
            get { return runtime; }
            set { runtime = value; }
        }
        private string poster_path;

        public FilmDTO()
        {
        }

        public FilmDTO(int id, string title, string originalTitle, int runtime, string posterPath)
        {
            Id = id;
            Title = title;
            OriginalTitle = originalTitle;
            Runtime = runtime;
            PosterPath = posterPath;
        }

        public string PosterPath
        {
            get { return poster_path; }
            set { poster_path = value; }
        }
        public override bool Equals(object obj)
        {
            var dTO = obj as FilmDTO;
            return dTO != null &&
                   Id == dTO.Id;
        }
    }
}
