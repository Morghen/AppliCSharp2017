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
            //Lancer la recherche film et acteur avec cle mot-clé





            //S'il y a au moins un résultat, insérer dans la table de hit






        }
    }
}