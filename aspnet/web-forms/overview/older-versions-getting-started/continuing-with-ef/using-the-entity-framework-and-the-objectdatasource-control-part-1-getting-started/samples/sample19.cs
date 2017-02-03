protected void DepartmentsDropDownList_Init(object sender, EventArgs e)
{
	administratorsDropDownList = sender as DropDownList;
}

protected void DepartmentsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
	e.NewValues["Administrator"] = administratorsDropDownList.SelectedValue;
}