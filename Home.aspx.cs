using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Report_Tracker_Website
{
    public partial class Default : System.Web.UI.Page
    {
        string username;
        string pw;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUser();
            if (username != "Shabel")
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        private string GetUser()
        {
            if(Session["User"] == null || Session["pword"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                username = Session["User"].ToString();
                pw = Session["pword"].ToString();
            }
            return username;
        }
    }
}