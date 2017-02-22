public ActionResult Index()
{
    var courses = db.Courses;
    var sql = courses.ToString();
    return View(courses.ToList());
}