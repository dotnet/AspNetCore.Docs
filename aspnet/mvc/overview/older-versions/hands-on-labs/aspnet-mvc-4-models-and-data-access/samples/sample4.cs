// GET: /Store/GenreMenu
[ChildActionOnly]
public ActionResult GenreMenu()
{
	var genres = this.storeDB.Genres.Take(9).ToList();

	return this.PartialView(genres);
}