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
        private int _countFilm = 0;
        private int _nbfilm = 20;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            _nbfilm = Convert.ToInt32(numberList.Text);
            _countFilm = _cli.CountFilm();
            if(!IsPostBack)
            {
                Session["offset"] = _offset;
                Session["nextState"] = true;
                Session["precState"] = false;
                buttonPrec.Enabled = false;
                buttonNext.Enabled = true;
            }
            else
            {
                _offset = (int)Session["offset"];
                buttonNext.Enabled = (bool)Session["nextState"];
                buttonPrec.Enabled = (bool)Session["precState"];
            }
            _filmList = new List<FilmDTO>(_cli.getFilmList(_offset, _nbfilm));
            grid.DataSource = _filmList;
            grid.DataBind();
        }

        protected void buttonPrec_Click(object sender, EventArgs e)
        {
            _nbfilm = Convert.ToInt32(numberList.Text);
            _offset = (int)Session["offset"];
            if (_offset <= 0)
                Session["precState"] = false;
            else
            {
                _offset -= _nbfilm;
                Session["offset"] = _offset;
                Session["precState"] = true;
                Session["nextState"] = true;
            }
            _filmList = new List<FilmDTO>(_cli.getFilmList(_offset, _nbfilm));
            grid.DataSource = _filmList;
            grid.DataBind();
        }

        protected void buttonNext_Click(object sender, EventArgs e)
        {
            _nbfilm = Convert.ToInt32(numberList.Text);
            _offset = (int)Session["offset"];
            if ((_offset + _nbfilm) >= _countFilm)
                Session["nextState"] = false;
            else
            {
                _offset += _nbfilm;
                Session["offset"] = _offset;
                Session["nextState"] = true;
                Session["precState"] = true;
            }
            _filmList = new List<FilmDTO>(_cli.getFilmList(_offset, _nbfilm));
            grid.DataSource = _filmList;
            grid.DataBind();
        }
    }
}