using FilmsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartVideoBLL;
using WebAtSmartVideo.ServiceReference;


namespace WebAtSmartVideo
{
    public partial class Details : System.Web.UI.Page
    {
        private SmartWcfClient _cli;
        private SmartVideoBLLManager sv;
        private FilmDTO film;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _cli = new SmartWcfClient();
                sv = new SmartVideoBLLManager();
            }
            try
            {
                film = _cli.GetFilmDetails(Convert.ToInt32(Request.QueryString["idfilm"]));
                FilmDetails.Text = " ";
                filmName.Text = "Title : " + film.Title;
                posterPath.Text = "PosterPath : " + film.FullPosterPath;
                trailerPath.Text = "Trailer url : " + film.Url;
                id.Text = "id : "+film.Id.ToString();
                runtime.Text = "Durée : " + film.Runtime.ToString()+"minutes";
                image.ImageUrl = film.FullPosterPath;
            }
            catch (Exception ex)
            {
                FilmDetails.Text = "ERREUR FILMS " + ex.Message;
            }
        }

        protected void rentButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                if ((bool)Session["islogged"])
                {
                    sv.LouerFilm(film.Id, DateTime.Now.AddMonths(3));
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