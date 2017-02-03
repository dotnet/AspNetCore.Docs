protected void Page_Load(object sender, EventArgs e)
{
	if (!Page.IsPostBack)
	BindUserAccounts();
}

private void BindUserAccounts()
{
	UserAccounts.DataSource = Membership.GetAllUsers();
	UserAccounts.DataBind();
}