protected void CoursesDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
{
	var departmentID = Convert.ToInt32(departmentDropDownList.SelectedValue);
	e.Values["DepartmentID"] = departmentID;
}