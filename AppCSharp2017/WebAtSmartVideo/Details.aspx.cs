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
    public partial class Details : System.Web.UI.Page
    {
        private SmartWcfClient _cli;
        private FilmDTO film;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _cli = new SmartWcfClient();
            }
            film = _cli.GetFilmDetails(Convert.ToInt32(Request.QueryString["idfilm"]));
            FilmDetails.Text = film.ToString();

        }

        protected void rentButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                if ((bool)Session["islogged"])
                {

                }
                else
                {
                    erreurRent.Text = "vous n'etes pas connectez";
                }
            }
            catch (Exception ex)
            {
                erreurRent.Text = "vous n'etes pas connectez" + ex.Message;
            }
        }
    }
}