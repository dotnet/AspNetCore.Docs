if (courseID != null)
{
	ViewBag.CourseID = courseID.Value;
	viewModel.Enrollments = viewModel.Courses.Where(
		x => x.CourseID == courseID).Single().Enrollments;
}