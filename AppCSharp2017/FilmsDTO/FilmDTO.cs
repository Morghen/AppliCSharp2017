using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable 0659
namespace FilmsDTO
{
    public class FilmDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id")); }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title")); }
        }
        private string original_title;

        public string OriginalTitle
        {
            get { return original_title; }
            set { original_title = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OriginalTitle")); }
        }

        private int runtime;

        public int Runtime
        {
            get { return runtime; }
            set { runtime = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Runtime")); }
        }
        private string poster_path;

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public FilmDTO()
        {
        }

        public FilmDTO(int id, string title, string originalTitle, int runtime, string posterPath, string url)
        {
            Id = id;
            Title = title;
            OriginalTitle = originalTitle;
            Runtime = runtime;
            PosterPath = posterPath;
            Url = url;
        }

        public string PosterPath
        {
            get { return poster_path; }
            set { poster_path = value; }
        }

        public string FullPosterPath // http://image.tmdb.org/t/p/w300
        {
            get
            {
                return PosterPath != "" ? "http://image.tmdb.org/t/p/w300"+PosterPath: "";
            }
        }

        public Uri UriUrl
        {
            get { return new Uri( "https://www.youtube.com/watch?v=OAQ7l33UF3E", UriKind.Absolute); }
        }
        public override bool Equals(object obj)
        {
            var dTO = obj as FilmDTO;
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
