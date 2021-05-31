using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Report_Tracker_Website.Blogs
{
    public partial class EditPost : System.Web.UI.Page
    {
        int pid;
        int attach;
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.Enctype = "multipart/form-data";
            LblPostDate.Text = DateTime.Now.ToString();
            GetId();
            if (!this.IsPostBack)
            {
                GetUser();
                if (username != "Shabel")
                {
                    Response.Redirect("~/Default.aspx");
                }
                LoadReport(pid);
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

        private void LoadReport(int id)
        {
            string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqconn = new SqlConnection(dbconn);
            string query = "SELECT * from [dbo].[blog] where Bid=" + id;
            sqconn.Open();
            SqlCommand cmd = new SqlCommand(query, sqconn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TxtTitle.Text = rdr["Btitle"].ToString();
                DDLLocation.Text = rdr["Blocation"].ToString();
                TxtReport.Text = rdr["Btext"].ToString();
            }
            sqconn.Close();
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            Check_Attachment();
            string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqconn = new SqlConnection(dbconn);
            string sqlquery = "UPDATE [dbo].[blog] SET Btitle=@Btitle, Blocation=@Blocation, Btext=@Btext, Bupdate=@Bupdate, Battach=@Battach WHERE Bid=" + pid;
            sqconn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, sqconn);
            cmd.Parameters.AddWithValue("@Btitle", TxtTitle.Text);
            cmd.Parameters.AddWithValue("@Blocation", DDLLocation.SelectedItem.Text.ToString());
            cmd.Parameters.AddWithValue("@Btext", TxtReport.Text);
            cmd.Parameters.AddWithValue("@Bupdate", LblPostDate.Text);
            cmd.Parameters.AddWithValue("@Battach", attach);
            cmd.ExecuteNonQuery();
            sqconn.Close();
            Response.Redirect("/Blogs/PostDetails.aspx?RecordId=" + pid);
        }

        private int Check_Attachment()
        {
            int counter = 0;
            string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqconn = new SqlConnection(dbconn);
            string query = "SELECT COUNT(*) from [dbo].[UploadFiles] where BlogId=" + pid;
            sqconn.Open();
            SqlCommand com = new SqlCommand(query);
            com.Connection = sqconn;
            counter = Convert.ToInt32(com.ExecuteScalar());
            sqconn.Close();

            if (counter > 0)
            {
                attach = 1;
            }
            else
            {
                attach = 0;
            }
            return attach;
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            pid = Convert.ToInt32(Session["RecordId"]);
            Response.Redirect("~/Blogs/PostDetails.aspx");
        }

        private int GetId()
        {
            pid = Convert.ToInt32(Session["RecordId"]);
            return pid;
        }

        private void PopulateUploadedFiles()
        {

            using (ShabelGroupEntities dc = new ShabelGroupEntities())
            {
                GridView1.DataSource = dc.UploadFiles.ToList().Where(a => a.BlogId.Equals(pid));
                GridView1.DataBind();
            }
        }


        protected void Upload(object sender, EventArgs e)
        {
            HttpFileCollection filesColl = Request.Files;
            using (ShabelGroupEntities dc = new ShabelGroupEntities())
            {
                foreach (string uploader in filesColl)
                {
                    HttpPostedFile file = filesColl[uploader];
                    if (file.ContentLength > 0)
                    {
                        BinaryReader br = new BinaryReader(file.InputStream);
                        byte[] data = br.ReadBytes(file.ContentLength);
                        dc.UploadFiles.Add(new UploadFile
                        {
                            FileId = 0,
                            BlogId = pid,
                            FileName = file.FileName,
                            ContentType = file.ContentType,
                            FileSize = file.ContentLength,
                            Extension = Path.GetExtension(file.FileName),
                            Content = data
                        });
                    }
                }
                dc.SaveChanges();
                PopulateUploadedFiles();
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
            else if (e.CommandName == "Delete")
            {
                int fileId = Convert.ToInt32(e.CommandArgument.ToString());
                string dbconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection sqconn = new SqlConnection(dbconn);
                string query = "DELETE from [dbo].[UploadFiles] where FileId=" + fileId;
                sqconn.Open();
                SqlCommand cmd = new SqlCommand(query, sqconn);
                cmd.ExecuteNonQuery();
                sqconn.Close();
                Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                Check_Attachment();
            }
        }
    }
}