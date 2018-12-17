using System;
using System.Configuration;
using System.Web.UI;

namespace MyConfigBuilders
{
    #region snippet
    public partial class About2 : Page
    {
        public string ServiceID { get; set; }
        public string AppSetting_default { get; set; }
        public string ConString { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceID = ConfigurationManager.AppSettings["ServiceID"];
            AppSetting_default = ConfigurationManager.AppSettings["default"];
            ConString = ConfigurationManager.ConnectionStrings["default"]
                                            ?.ConnectionString;
        }
    }
    #endregion
}