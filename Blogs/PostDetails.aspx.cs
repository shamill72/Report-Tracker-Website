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
    public partial class PostDetails : System.Web.UI.Page
    {
        int id;
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetId();
            if (!this.IsPostBack)
            {
                GetUser();
                if (username != "Shabel")
                {
                    Response.Redirect("~/Default.aspx");
                }
                string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection sqconn = new SqlConnection(dbconn);
                string query = "SELECT * from [dbo].[blog] where Bid=" + id;
                sqconn.Open();
                SqlCommand cmd = new SqlCommand(query, sqconn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    LblTitle.Text = rdr["Btitle"].ToString();
                    LblLocation.Text = rdr["Blocation"].ToString();
                    LblReport.Text = rdr["Btext"].ToString();
                    LblPostDate.Text = String.Format("{0: MM/dd/yyyy hh:mm tt}", rdr["Bpostdate"]);
                    LblUpdate.Text = String.Format("{0: MM/dd/yyyy hh:mm tt}", rdr["Bupdate"]);
                }
                sqconn.Close();
                PopulateUploadedFiles();
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
        protected void EditPostButton_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Session["RecordId"]);
            Response.Redirect("~/Blogs/EditPost.aspx");
        }

        private int GetId()
        {
            id = Convert.ToInt32(Session["RecordId"]);
            return id;
        }

        protected void DeletePostButton_Click(object sender, EventArgs e)
        {
            string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqconn = new SqlConnection(dbconn);
            string query = "DELETE from [dbo].[blog] where Bid=" + id;
            sqconn.Open();
            SqlCommand cmd = new SqlCommand(query, sqconn);
            cmd.ExecuteNonQuery();
            sqconn.Close();
            Response.Redirect("/Blogs/BlogHome.aspx");
        }

        private void PopulateUploadedFiles()
        {
            using (ShabelGroupEntities dc = new ShabelGroupEntities())
            {
                GridView1.DataSource = dc.UploadFiles.ToList().Where(a => a.BlogId.Equals(id));
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int fileId = Convert.ToInt32(e.CommandArgument.ToString());
                using (ShabelGroupEntities dc = new ShabelGroupEntities())
                {
                    var v = dc.UploadFiles.Where(a => a.FileId.Equals(fileId)).FirstOrDefault();
                    if (v != null)
                    {
                        Response.ContentType = v.ContentType;
                        Response.AddHeader("content-disposition", "attachment; filename=" + v.FileName);
                        Response.BinaryWrite(v.Content);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }
    }
}