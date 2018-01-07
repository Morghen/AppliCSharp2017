﻿using FilmsDTO;
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
        private SmartWcfClient _cli = new SmartWcfClient();
        private SmartVideoBLLManager sv = new SmartVideoBLLManager();
        private FilmDTO film;
        private int idFilm;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                film = _cli.GetFilmDetails(Convert.ToInt32(Request.QueryString["idfilm"]));
                idFilm = film.Id;
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
                    film = _cli.GetFilmDetails(Convert.ToInt32(Request.QueryString["idfilm"]));
                    DateTime dt = DateTime.Today.AddMonths(3);
                    sv.LouerFilm((String)Session["username"],film.Id, film.Title, DateTime.Now.AddMonths(3), film.Url);
                }
                else
                {
                    erreurRent.Text = "vous n'etes pas connectez";
                }
            }
            catch (Exception ex)
            {
                erreurRent.Text = Request.QueryString["idfilm"] + " error "+Session["username"]+" "+ex.Message+ex.GetType();
                if(film != null)
                    erreurRent.Text += " " + film.ToString();
            }
        }
    }
}