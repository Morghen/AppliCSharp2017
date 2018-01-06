using FilmsBLL;
using FilmsDTO;
using SmartWCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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