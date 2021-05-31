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

namespace Report_Tracker_Website.Blogs
{
    public partial class ReportLocations : System.Web.UI.Page
    {
        string loc;
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetLocation();
            LocationTitle.Text = loc;
            if (!this.IsPostBack)
            {
                GetUser();
                if (username != "Shabel")
                {
                    Response.Redirect("~/Default.aspx");
                }
                string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection sqconn = new SqlConnection(dbconn);
                string query = "SELECT * from [dbo].[blog] where Blocation='" + loc + "' order by Bpostdate DESC";
                sqconn.Open();
                SqlCommand cmd = new SqlCommand(query, sqconn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ReportDetails.DataSource = dt;
                ReportDetails.DataBind();
                sqconn.Close();
            }
        }
        protected string GetLocation()
        {
            loc = Session["Location"].ToString();
            return loc;
        }
        protected void NewPostButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Blogs/BlogEntry.aspx");
        }

        protected void RepBlog_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "click")
            {
                Session["RecordId"] = e.CommandArgument.ToString();
                Response.Redirect("PostDetails.aspx");
            }
        }
        private string GetUser()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                username = Session["User"].ToString();
            }
            return username;
        }
    }
}