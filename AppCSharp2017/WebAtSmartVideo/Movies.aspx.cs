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
            if (_offset == 0)
                buttonPrec.Enabled = false;
            else
                buttonPrec.Enabled = true;
            if (_offset >= _countfilm)
                buttonNext.Enabled = false;
            else
                buttonNext.Enabled = true;
            
        }

        protected void buttonPrec_Click(object sender, EventArgs e)
        {
            _offset -= 20;
        }

        protected void buttonNext_Click(object sender, EventArgs e)
        {
            _offset += 20;
        }
    }
}