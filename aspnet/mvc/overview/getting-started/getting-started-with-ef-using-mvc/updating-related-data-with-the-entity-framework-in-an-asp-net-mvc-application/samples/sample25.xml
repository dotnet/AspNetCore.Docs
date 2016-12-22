public ActionResult Create()
{
    var instructor = new Instructor();
    instructor.Courses = new List<Course>();
    PopulateAssignedCourseData(instructor);
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "LastName,FirstMidName,HireDate,OfficeAssignment" )]Instructor instructor, string[] selectedCourses)
{
    if (selectedCourses != null)
    {
        instructor.Courses = new List<Course>();
        foreach (var course in selectedCourses)
        {
            var courseToAdd = db.Courses.Find(int.Parse(course));
            instructor.Courses.Add(courseToAdd);
        }
    }
    if (ModelState.IsValid)
    {
        db.Instructors.Add(instructor);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    PopulateAssignedCourseData(instructor);
    return View(instructor);
}