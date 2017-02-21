protected void RemoveCourseButton_Click(object sender, EventArgs e)
{
	using (var context = new SchoolEntities())
	{
		var instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue);
		var instructor = (from p in context.People
						  where p.PersonID == instructorID
						  select p).First();
		var courseID = Convert.ToInt32(AssignedCoursesDropDownList.SelectedValue);
		var courses = instructor.Courses;
		var courseToRemove = new Course();
		foreach (Course c in courses)
		{
			if (c.CourseID == courseID)
			{
				courseToRemove = c;
				break;
			}
		}
		try
		{
			courses.Remove(courseToRemove);
			context.SaveChanges();
			PopulateDropDownLists();
			CourseRemovedLabel.Text = "Removal successful.";
		}
		catch (Exception)
		{
			CourseRemovedLabel.Text = "Removal unsuccessful.";
			//Add code to log the error.
		}
		CourseRemovedLabel.Visible = true;
	}
}