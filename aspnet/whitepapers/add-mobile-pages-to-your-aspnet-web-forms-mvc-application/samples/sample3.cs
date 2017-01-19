public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Ensure that if Forms Authentication forces a mobile user 
        // to log in, we display the mobile login page
        string returnUrl = Request.QueryString["ReturnUrl"];
        if (!String.IsNullOrEmpty(returnUrl) && returnUrl.StartsWith("/Mobile/",
                                                StringComparison.OrdinalIgnoreCase)) 
        {
            Response.Redirect("~/Mobile/Account/Login.aspx?ReturnUrl=" 
                              + HttpUtility.UrlEncode(returnUrl));
        }

        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" 
                                        + HttpUtility.UrlEncode(returnUrl);
    }
}