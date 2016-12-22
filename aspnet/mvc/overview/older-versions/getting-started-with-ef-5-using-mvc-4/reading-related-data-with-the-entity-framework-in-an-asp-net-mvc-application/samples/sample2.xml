public ViewResult Index()
{
    var courses = db.Courses.Include(c => c.Department);
    return View(courses.ToList());
}