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

namespace Report_Tracker_Website.Models
{
    public class ReportHold
    {
        public DateTime PostedDate { get; set; }
        public DateTime UpdateDte { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public string Report { get; set; }

    }
}