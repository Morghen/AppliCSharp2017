using FilmsDTO;
using FilmsGUI.ServiceReference;
using System;
using System.Collections.Generic;

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
            _filmList = new List<FilmDTO>(_cli.getFilmList(_offset, _nbfilm));
            _countfilm = _cli.CountFilm();
            grid.DataSource = _filmList;
            grid.DataBind();
            buttonPrec.Enabled = false;          
        }

        protected void buttonPrec_Click(object sender, EventArgs e)
        {
            _offset = _offset - 20;
            _filmList = new List<FilmDTO>(_cli.getFilmList(_offset, _nbfilm));
            grid.DataSource = _filmList;
            grid.DataBind();

        }

        protected void buttonNext_Click(object sender, EventArgs e)
        {
            _offset = _offset + 20;
            _filmList = new List<FilmDTO>(_cli.getFilmList(_offset, _nbfilm));
            grid.DataSource = _filmList;
            grid.DataBind();
        }
    }
}