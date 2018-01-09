using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FilmsDTO;
using SmartVideoBLL;
using SmartVideoDTOLibrary;
using WebAtSmartVideo.ServiceReference;

namespace WebAtSmartVideo
{
    public partial class Stat : System.Web.UI.Page
    {
        private SmartWcfClient _cli = new SmartWcfClient();
        private SmartVideoBLLManager sv = new SmartVideoBLLManager();
        private List<FilmDTO> _filmList;

        private List<StatistiqueDTO> lStat;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (lStat != null)
            {
                lStat.Sort((a, b) => a.Position.CompareTo(b.Position));
                lStat.Sort((a, b) => a.Type.CompareTo(b.Type));

                grid.DataSource = lStat;
                grid.DataBind();
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (dropMenu.Text.Equals("Today"))
            {
                lStat = sv.getStatistique(DateTime.Today);
            }
            if (dropMenu.Text.Equals("Hier"))
            {
                lStat = sv.getStatistique(DateTime.Today.AddDays(-1));
            }
            if (dropMenu.Text.Equals("Tous"))
            {
                lStat = sv.getStatistique();
            }
            if (lStat != null)
            {
                lStat.Sort((a, b) => a.Position.CompareTo(b.Position));
                lStat.Sort((a, b) => a.Type.CompareTo(b.Type));
                
                grid.DataSource = lStat;
                grid.DataBind();
            }
            else
            {
                lStat = new List<StatistiqueDTO>();
                grid.DataSource = lStat;
                grid.DataBind();
            }
        }
        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            searchButton_Click(this, new EventArgs());
            if (e.CommandName.CompareTo("viewDetails") == 0)
            {
                if (lStat[Convert.ToInt32(e.CommandArgument)].Type == TypeEnum.Film)
                {
                    int idFilm = (lStat[Convert.ToInt32(e.CommandArgument)]).Id;

                    Response.Redirect("Details.aspx?idfilm=" + idFilm);
                }
            }
        }
    }
}