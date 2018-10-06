using System;
using System.Configuration;
using System.Web.UI;

namespace MyConfigBuilders
{
    public partial class About : Page
    {
        public string ServiceID { get; set; }
        public string ServiceKey { get; set; }
        public string ConString { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceID = ConfigurationManager.AppSettings["ServiceID"];
            ServiceKey = ConfigurationManager.AppSettings["ServiceKey"];
            ConString = ConfigurationManager.ConnectionStrings["default"]
                                            ?.ConnectionString;
        }
    }
}