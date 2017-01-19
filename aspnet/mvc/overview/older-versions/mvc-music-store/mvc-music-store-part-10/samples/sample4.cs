//
// GET: /Store/GenreMenu
[ChildActionOnly]
 public ActionResult GenreMenu()
{
    var genres = storeDB.Genres.ToList();
    return PartialView(genres);
 }