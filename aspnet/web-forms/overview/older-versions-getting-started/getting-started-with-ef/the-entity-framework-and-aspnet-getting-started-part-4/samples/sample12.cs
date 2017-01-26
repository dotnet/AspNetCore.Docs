protected void CourseDetailsEntityDataSource_Selected(object sender, EntityDataSourceSelectedEventArgs e)
{
	var course = e.Results.Cast<Course>().FirstOrDefault();
	if (course != null)
	{
		var studentGrades = course.StudentGrades.ToList();
		GradesListView.DataSource = studentGrades;
		GradesListView.DataBind();
	}
}