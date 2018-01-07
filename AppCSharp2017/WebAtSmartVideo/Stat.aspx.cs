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
            if (!IsPostBack)
            {
                lStat = sv.getStatistique(DateTime.Today);
            }
            else
            {
                lStat = sv.getStatistique(DateTime.Today);
            }
            grid.DataSource = lStat;
            grid.DataBind();
        }
    }
}