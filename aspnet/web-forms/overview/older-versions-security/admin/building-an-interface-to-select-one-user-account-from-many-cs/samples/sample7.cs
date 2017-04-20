protected void Page_Load(object sender, EventArgs e)
{
	if (!Page.IsPostBack)
	{
		BindUserAccounts();
		BindFilteringUI();
	}
}

private void BindFilteringUI()
{
	string[] filterOptions = { "All", "A", "B", "C","D", "E", "F", "G", "H", "I","J", "K", "L", "M", "N", "O","P", "Q", "R", "S", "T", "U","V", "W", "X", "Y", "Z" };
	FilteringUI.DataSource = filterOptions;
	FilteringUI.DataBind();
}