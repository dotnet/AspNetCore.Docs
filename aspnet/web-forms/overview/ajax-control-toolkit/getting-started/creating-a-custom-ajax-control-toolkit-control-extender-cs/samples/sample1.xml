using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

[assembly: System.Web.UI.WebResource("CustomExtenders.MyControlBehavior.js", "text/javascript")]

namespace CustomExtenders
{
    [ClientScriptResource("CustomExtenders.MyControlBehavior", "CustomExtenders.MyControlBehavior.js")]
    [TargetControlType(typeof(TextBox))]
    public class MyControlExtender : ExtenderControlBase
    {

        [ExtenderControlProperty]
        [DefaultValue("")]
        public string MyProperty
        {
            get
            {
                return GetPropertyValue("MyProperty", "");
            }
            set
            {
                SetPropertyValue("MyProperty", value);
            }
        }
    }
}