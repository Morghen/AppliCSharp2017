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
    public partial class Locations : System.Web.UI.Page
    {
        private SmartWcfClient _cli = new SmartWcfClient();
        private SmartVideoBLLManager sv = new SmartVideoBLLManager();
        private List<LocationDTO> llocation;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!(bool)Session["islogged"])
                    Response.Redirect("/Default.aspx");
                llocation = new List<LocationDTO>(sv.getLocation((String)Session["username"]));

                grid.DataSource = llocation;
                grid.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("/Default.aspx");
            }
        }

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    
    
}