protected void DepartmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
{
	if (e.Row.RowType == DataControlRowType.DataRow)
	{
		var department = e.Row.DataItem as Department;
		var coursesGridView = (GridView)e.Row.FindControl("CoursesGridView");
		coursesGridView.DataSource = department.Courses.ToList();
		coursesGridView.DataBind();
	}
}