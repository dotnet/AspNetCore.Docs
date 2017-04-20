if (id != null)
{
    ViewBag.InstructorID = id.Value;
    viewModel.Courses = viewModel.Instructors.Where(i => i.InstructorID == id.Value).Single().Courses;
}