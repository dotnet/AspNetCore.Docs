protected void Page_Load(object sender, EventArgs e)
{
	CourseAssignedLabel.Visible = false;
	CourseRemovedLabel.Visible = false;
}

protected void InstructorsDropDownList_DataBound(object sender, EventArgs e)
{
	PopulateDropDownLists();
}

protected void InstructorsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
{
	PopulateDropDownLists();
}