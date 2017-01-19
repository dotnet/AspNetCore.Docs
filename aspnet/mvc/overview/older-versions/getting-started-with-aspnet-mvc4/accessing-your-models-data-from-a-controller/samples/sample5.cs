public ActionResult Index()
{
    return View(db.Movies.ToList());
}