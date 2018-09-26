using System;
using System.Configuration;
using System.Web.UI;

namespace MyConfigBuilders
{
    public partial class Contact : Page
    {
        public string ServiceID { get; set; }
        public string ServiceKey { get; set; }
        public string ConString { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceID = ConfigurationManager.AppSettings["AppSetting_ServiceID"];
            ServiceKey = ConfigurationManager.AppSettings["AppSetting_ServiceKey"];
            var cs = ConfigurationManager.ConnectionStrings["ConnStr_default"];
            if (cs != null)
            {
                ConString = ConfigurationManager.ConnectionStrings["ConnStr_default"].ConnectionString;
            }

        }
    }
}