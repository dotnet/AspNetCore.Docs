public ActionResult Index()
{
    var genres = storeDB.Genres.ToList();
    return View(genres);
 }