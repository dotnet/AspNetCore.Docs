public ViewResult Index()
{
    return View(db.Students.ToList());
}