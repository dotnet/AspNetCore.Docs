protected void AssignCourseButton_Click(object sender, EventArgs e)
{
	using (var context = new SchoolEntities())
	{
		var instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue);
		var instructor = (from p in context.People
						  where p.PersonID == instructorID
						  select p).First();
		var courseID = Convert.ToInt32(UnassignedCoursesDropDownList.SelectedValue);
		var course = (from c in context.Courses
					  where c.CourseID == courseID
					  select c).First();
		instructor.Courses.Add(course);
		try
		{
			context.SaveChanges();
			PopulateDropDownLists();
			CourseAssignedLabel.Text = "Assignment successful.";
		}
		catch (Exception)
		{
			CourseAssignedLabel.Text = "Assignment unsuccessful.";
			//Add code to log the error.
		}
		CourseAssignedLabel.Visible = true;
	}
}