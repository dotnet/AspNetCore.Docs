public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Ensure that after logging in, mobile users stay on mobile pages
        string returnUrl = Request.QueryString["ReturnUrl"];
        if (String.IsNullOrEmpty(returnUrl))
        {
            returnUrl = "~/Mobile/";
        }
        LoginUser.DestinationPageUrl = returnUrl;

        // (the following line is already present by default)
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" 
                                        + HttpUtility.UrlEncode(returnUrl);
    }
}