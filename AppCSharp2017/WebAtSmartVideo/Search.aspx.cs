using FilmsDTO;
using SmartVideoBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAtSmartVideo.ServiceReference;

namespace WebAtSmartVideo
{
    public partial class Search : System.Web.UI.Page
    {
        private SmartWcfClient _cli = new SmartWcfClient();
        private SmartVideoBLLManager _db = new SmartVideoBLLManager();
        private List<FilmDTO> _filmList;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dropMenu.Text.Equals("Acteur"))
                {
                    _filmList = new List<FilmDTO>(_cli.searchFilm(searchBox.Text, "Acteur"));
                    if (_filmList.Count != 0)
                    {
                        List<ActorDTO> tmp = new List<ActorDTO>(_cli.searchActor(searchBox.Text));
                        foreach (ActorDTO act in tmp)
                        {
                            _db.incHitFilm(act.Id, "Acteur");
                        }
                        gridSearch.DataSource = _filmList;
                        gridSearch.DataBind();
                    }
                }
                else
                {
                    _filmList = new List<FilmDTO>(_cli.searchFilm(searchBox.Text, "Film"));
                    if (_filmList.Count != 0)
                    {
                        foreach (FilmDTO tmp in _filmList)
                        {
                            _db.incHitFilm(tmp.Id, "Film");
                        }
                        gridSearch.DataSource = _filmList;
                        gridSearch.DataBind();
                    }

                }
                errorSearch.Text = "";
            }
            catch (FaultException ex)
            {
                errorSearch.Text = "Error from the wcf service please retry with a more specific keyword";
            }
            catch (Exception ex)
            {
                errorSearch.Text = ex.Message;
            }
        }

        protected void grid_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (dropMenu.Text.Equals("Acteur"))
            {
                _filmList = new List<FilmDTO>(_cli.searchFilm(searchBox.Text, "Acteur"));
            }
            else
            {
                _filmList = new List<FilmDTO>(_cli.searchFilm(searchBox.Text, "Film"));
            }
            if (e.CommandName.CompareTo("viewDetails") == 0)
            {
                int idFilm = (_filmList[Convert.ToInt32(e.CommandArgument)]).Id;

                Response.Redirect("Details.aspx?idfilm=" + idFilm);
            }
        }
    }
}