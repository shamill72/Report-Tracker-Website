using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Report_Tracker_Website.Blogs
{
    public partial class BlogEntry : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetUser();
                if (username != "Shabel")
                {
                    Response.Redirect("~/Default.aspx");
                }
                LblPostDate.Text = DateTime.Now.ToString();
                DDLLocation.Items.Insert(0, "--Select Location --");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqconn = new SqlConnection(dbconn);
            string sqlquery = "insert into [dbo].[blog] (Btitle, Blocation, Btext, Bpostdate, Bupdate) values(@Btitle, @Blocation, @Btext, @Bpostdate, @Bupdate)";
            sqconn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, sqconn);
            cmd.Parameters.AddWithValue("@Btitle", TxtTitle.Text);
            cmd.Parameters.AddWithValue("@Blocation", DDLLocation.SelectedItem.Text.ToString());
            cmd.Parameters.AddWithValue("@Btext", TxtReport.Text);
            cmd.Parameters.AddWithValue("@Bpostdate", LblPostDate.Text);
            cmd.Parameters.AddWithValue("@Bupdate", LblPostDate.Text);
            cmd.ExecuteNonQuery();
            sqconn.Close();
            Response.Redirect("/Blogs/BlogHome.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Blogs/BlogHome.aspx");
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