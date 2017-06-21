protected void Page_Load(object sender, EventArgs e)
{
	if (!Page.IsPostBack)
	{
		if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
		// This is an unauthorized, authenticated request...
		Response.Redirect("~/UnauthorizedAccess.aspx");
	}
}