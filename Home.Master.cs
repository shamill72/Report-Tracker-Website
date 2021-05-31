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
    public partial class Home : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
                string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection sqconn = new SqlConnection(dbconn);
                string query = "SELECT COUNT(case when Blocation = 'Nashville' then 1 end) as Nashville, Count(case when Blocation = 'Gallatin' then 1 end) as Gallatin, COUNT(case when Blocation = 'Cookeville' then 1 end) as Cookeville, COUNT(case when Blocation = 'Knoxville' then 1 end) as Knoxville, COUNT(case when Blocation = 'Memphis' then 1 end) as Memphis from [dbo].[blog]";
                sqconn.Open();
                SqlCommand cmd = new SqlCommand(query, sqconn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    LblNash.Text = sdr.GetValue(0).ToString();
                    LabGall.Text = sdr.GetValue(1).ToString();
                    LabCooke.Text = sdr.GetValue(2).ToString();
                    LabKnox.Text = sdr.GetValue(3).ToString();
                    LabMem.Text = sdr.GetValue(4).ToString();
                }
                sqconn.Close();
            

        }

        protected void NewPostButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Blogs/BlogEntry.aspx");
        }
        protected void Nashville_Click(object sender, EventArgs e)
        {
            Session["Location"] = "Nashville";
            Response.Redirect("~/Blogs/ReportLocations.aspx");
        }

        protected void Gallatin_Click(object sender, EventArgs e)
        {
            Session["Location"] = "Gallatin";
            Response.Redirect("~/Blogs/ReportLocations.aspx");
        }

        protected void Cookeville_Click(object sender, EventArgs e)
        {
            Session["Location"] = "Cookeville";
            Response.Redirect("~/Blogs/ReportLocations.aspx");
        }

        protected void Knoxville_Click(object sender, EventArgs e)
        {
            Session["Location"] = "Knoxville";
            Response.Redirect("~/Blogs/ReportLocations.aspx");
        }

        protected void Memphis_Click(object sender, EventArgs e)
        {
            Session["Location"] = "Memphis";
            Response.Redirect("~/Blogs/ReportLocations.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["user"] = "";
            Session["pword"] = "";
            Response.Redirect("~/Default.aspx");
        }
    }
}