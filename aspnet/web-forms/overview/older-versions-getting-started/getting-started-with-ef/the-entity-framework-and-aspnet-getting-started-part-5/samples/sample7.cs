private void PopulateDropDownLists()
{
	using (var context = new SchoolEntities())
	{
		var allCourses = (from c in context.Courses
						  select c).ToList();

		var instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue);
		var instructor = (from p in context.People.Include("Courses")
						  where p.PersonID == instructorID
						  select p).First();

		var assignedCourses = instructor.Courses.ToList();
		var unassignedCourses = allCourses.Except(assignedCourses.AsEnumerable()).ToList();

		UnassignedCoursesDropDownList.DataSource = unassignedCourses;
		UnassignedCoursesDropDownList.DataBind();
		UnassignedCoursesDropDownList.Visible = true;

		AssignedCoursesDropDownList.DataSource = assignedCourses;
		AssignedCoursesDropDownList.DataBind();
		AssignedCoursesDropDownList.Visible = true;
	}
}