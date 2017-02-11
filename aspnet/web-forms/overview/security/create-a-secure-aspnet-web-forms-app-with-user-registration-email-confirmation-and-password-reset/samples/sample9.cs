protected void Page_Load(object sender, EventArgs e)
{
	RegisterHyperLink.NavigateUrl = "Register";
	// Enable this once you have account confirmation enabled for password reset functionality
	ForgotPasswordHyperLink.NavigateUrl = "Forgot";
	OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
	var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
	if (!String.IsNullOrEmpty(returnUrl))
	{
		RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
	}
}