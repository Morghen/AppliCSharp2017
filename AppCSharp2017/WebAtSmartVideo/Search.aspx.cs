using FilmsDTO;
using SmartVideoBLL;
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
        private SmartVideoBLLManager _db = new SmartVideoBLLManager();
        private List<FilmDTO> _filmList;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if(dropMenu.Text.Equals("Acteur"))
            {
                _filmList = new List<FilmDTO>(_cli.searchFilm(searchBox.Text, "Acteur"));
                if(_filmList.Count != 0)
                {
                    gridSearch.DataSource = _filmList;
                    gridSearch.DataBind();
                }            
            }
            else
            {
                _filmList = new List<FilmDTO>(_cli.searchFilm(searchBox.Text, "Film"));
                if(_filmList.Count != 0)
                {
                    foreach (FilmDTO tmp in _filmList)
                    {
                        _db.incHitFilm(tmp.Id);
                    }
                    gridSearch.DataSource = _filmList;
                    gridSearch.DataBind();
                }
                
            }
        }
    }
}