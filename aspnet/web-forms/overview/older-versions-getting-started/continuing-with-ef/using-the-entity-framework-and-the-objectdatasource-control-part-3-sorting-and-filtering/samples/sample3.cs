protected void Page_Load(object sender, EventArgs e)
{
	if (!IsPostBack)
	{
		DepartmentsGridView.Sort("Name", SortDirection.Ascending);
	}
}