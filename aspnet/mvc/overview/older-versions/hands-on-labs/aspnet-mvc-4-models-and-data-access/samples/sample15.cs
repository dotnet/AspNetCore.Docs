public ActionResult Index()
{
	var genres = this.storeDB.Genres;

	return this.View(genres);
}