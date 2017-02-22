private DropDownList administratorsDropDownList;

protected void Page_Init(object sender, EventArgs e)
{
	DepartmentsDetailsView.EnableDynamicData(typeof(Department));
}

protected void DepartmentsDropDownList_Init(object sender, EventArgs e)
{
	administratorsDropDownList = sender as DropDownList;
}

protected void DepartmentsDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
{
	e.Values["Administrator"] = administratorsDropDownList.SelectedValue;
}