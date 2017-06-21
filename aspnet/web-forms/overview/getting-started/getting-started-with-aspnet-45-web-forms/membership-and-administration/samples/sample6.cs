protected void Page_Load(object sender, EventArgs e)
{
	if (HttpContext.Current.User.IsInRole("canEdit"))
	{
		adminLink.Visible = true;
	}
}