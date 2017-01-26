protected void Page_Load(object sender, EventArgs e)
{
	if (!IsPostBack)
	{
		var userId = signinManager.GetVerifiedUserId<ApplicationUser, string>();
		if (userId == null)
		{
			Response.Redirect("/Account/Error", true);
		}
		var userFactors = manager.GetValidTwoFactorProviders(userId);
		Providers.DataSource = userFactors.Select(x => x).ToList();
		Providers.DataBind();
	}
}