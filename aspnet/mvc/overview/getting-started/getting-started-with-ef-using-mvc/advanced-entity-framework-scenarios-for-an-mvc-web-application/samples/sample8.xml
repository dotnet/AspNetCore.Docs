public ActionResult Index(int? SelectedDepartment)
{
    var departments = db.Departments.OrderBy(q => q.Name).ToList();
    ViewBag.SelectedDepartment = new SelectList(departments, "DepartmentID", "Name", SelectedDepartment);
    int departmentID = SelectedDepartment.GetValueOrDefault();

    IQueryable<Course> courses = db.Courses
        .Where(c => !SelectedDepartment.HasValue || c.DepartmentID == departmentID)
        .OrderBy(d => d.CourseID)
        .Include(d => d.Department);
    var sql = courses.ToString();
    return View(courses.ToList());
}