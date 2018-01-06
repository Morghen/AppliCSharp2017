using FilmsBLL;
using FilmsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAtSmartVideo
{
    public partial class Movies : System.Web.UI.Page
    {
        private FilmsBLLManager _dbFilm;
        private List<FilmDTO> _filmList;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dbFilm = new FilmsBLLManager();
            _filmList = _dbFilm.getFilmList(0, 20);
            grid.DataSource = _filmList;
            grid.DataBind();
        }
    }
}