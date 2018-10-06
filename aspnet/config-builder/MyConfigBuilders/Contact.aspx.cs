using System;
using System.Configuration;
using System.Web.UI;

namespace MyConfigBuilders
{
    #region snippet
    public partial class Contact : Page
    {
        public string ServiceID { get; set; }
        public string AppSetting_default { get; set; }
        public string ConString { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceID = ConfigurationManager.AppSettings["AppSetting_ServiceID"];
            AppSetting_default = ConfigurationManager.AppSettings["AppSetting_default"];
            ConString = ConfigurationManager.ConnectionStrings["ConnStr_default"]
                                         ?.ConnectionString;
        }
    }
    #endregion
}