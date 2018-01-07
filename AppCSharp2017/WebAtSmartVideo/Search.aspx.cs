using FilmsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAtSmartVideo.ServiceReference;

namespace WebAtSmartVideo
{
    public partial class Search : System.Web.UI.Page
    {
        private SmartWcfClient _cli = new SmartWcfClient();
        private List<FilmDTO> _filmList;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if(dropMenu.Text.Equals("Acteur"))
            {
                _filmList = _cli.searchFilm(searchBox.Text, "Acteur");
                gridSearch.DataSource = _filmList;
                gridSearch.DataBind();
            }
            else
            {
                _filmList = _cli.searchFilm(searchBox.Text, "Film");
                gridSearch.DataSource = _filmList;
                gridSearch.DataBind();
            }
            //S'il y a au moins un résultat, insérer dans la table de hit






        }
    }
}