using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report_Tracker_Website
{
    public partial class Defualt : System.Web.UI.Page
    {
        
        string name = "Shabel";
        string pw = "Group";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = user.Text;
            string password = psswrd.Text;
            if (username != name || password != pw)
            {
                string script = "alert(\"Please enter a valid username and password.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                user.Text = "";
                psswrd.Text = "";
            }
            else if (username == name && password == pw)
            {
                Session["User"] = username;
                Session["pword"] = password;
                Response.Redirect("~/Home.aspx");
            }
        }

    }
}