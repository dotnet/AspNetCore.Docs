using System;
using System.Web.Security;

namespace SignalRWithConsoleChat
{
    public partial class RemoteLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request["UserName"];
            string password = Request["Password"];
            bool result = Membership.ValidateUser(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
        }
    }
}