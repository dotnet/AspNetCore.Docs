public ActionResult Browse(string genre)
{
	// Retrieve Genre and its Associated Albums from database
	var genreModel = storeDB.Genres.Include("Albums")
		.Single(g => g.Name == genre);

	return View(genreModel);
}