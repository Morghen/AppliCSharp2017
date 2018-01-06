using FilmsDTO;
using FilmsGUI.ServiceReference;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebAtSmartVideo
{
    public partial class Movies : System.Web.UI.Page
    {
        
        private SmartWcfClient _cli = new SmartWcfClient();
        private List<FilmDTO> _filmList;
        private int _offset = 0;
        private int _nbfilm = 20;
        private int _countfilm = 0;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                _filmList = new List<FilmDTO>(_cli.getFilmList(_offset, _nbfilm));
                _countfilm = _cli.CountFilm();
                Session["offset"] = _offset.ToString();
                grid.DataSource = _filmList;
                grid.DataBind();
                buttonPrec.Enabled = false;
            }
            else
            {
                _offset = (int)Session["offset"];
                _filmList = new List<FilmDTO>(_cli.getFilmList(_offset, _nbfilm));
                grid.DataSource = _filmList;
                grid.DataBind();
                buttonNext.Enabled = (bool)Session["nextState"];
                buttonPrec.Enabled = (bool)Session["precState"];
            }

        }

        protected void buttonPrec_Click(object sender, EventArgs e)
        {
            _offset = (int)Session["offset"];
            if (_offset <= 0)
                Session["precState"] = false.ToString();
            else
            {
                _offset -= 20;
                Session["offset"] = _offset.ToString();
                Session["precState"] = true.ToString();
            }
        }

        protected void buttonNext_Click(object sender, EventArgs e)
        {
            _offset = (int)Session["offset"];
            if ((_offset + 20) >= _nbfilm)
                Session["nextState"] = false.ToString();
            else
            {
                _offset += 20;
                Session["offset"] = _offset.ToString();
                Session["nextState"] = true.ToString();
            }
        }
    }
}