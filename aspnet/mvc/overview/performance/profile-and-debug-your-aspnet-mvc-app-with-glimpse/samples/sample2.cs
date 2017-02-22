public ActionResult Index(int? id, int? courseID, int ? eager)
{
    var viewModel = new InstructorIndexData();

    viewModel.Instructors = db.Instructors
        .Include(i => i.OfficeAssignment)
        .Include(i => i.Courses.Select(c => c.Department))
        .OrderBy(i => i.LastName);

    if (id != null)
    {
        ViewBag.InstructorID = id.Value;
        viewModel.Courses = viewModel.Instructors.Where(
            i => i.ID == id.Value).Single().Courses;
    }

    if (courseID != null)
    {
       ViewBag.CourseID = courseID.Value;
       // Eager loading
       if (eager != null && eager > 0)
       {
          ViewBag.eagerMsg = "Eager Loading";

          viewModel.Enrollments = viewModel.Courses.Where(
              x => x.CourseID == courseID).Single().Enrollments;

       }
       else { 
        // Explicit loading
          ViewBag.eagerMsg = "Explicit Loading";

        var selectedCourse = viewModel.Courses.Where(x => x.CourseID == courseID).Single();
        db.Entry(selectedCourse).Collection(x => x.Enrollments).Load();
        foreach (Enrollment enrollment in selectedCourse.Enrollments)
        {
            db.Entry(enrollment).Reference(x => x.Student).Load();
        }

        viewModel.Enrollments = selectedCourse.Enrollments;
       }
    }

    return View(viewModel);
}