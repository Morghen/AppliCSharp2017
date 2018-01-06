using FilmsDTO;
using FilmsGUI.ServiceReference;
using System;
using System.Collections.Generic;

namespace WebAtSmartVideo
{
    public partial class Movies : System.Web.UI.Page
    {
        private SmartWcfClient _cli = new SmartWcfClient();
        private List<FilmDTO> _filmList;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Connexion a la BDD et pull des 20 premiers films
            _filmList = new List<FilmDTO>(_cli.getFilmList(0, 20));
            //Binding a la GridView nommée grid définie dans le fichier .cs
            grid.DataSource = _filmList;
            grid.DataBind();
        }
    }
}