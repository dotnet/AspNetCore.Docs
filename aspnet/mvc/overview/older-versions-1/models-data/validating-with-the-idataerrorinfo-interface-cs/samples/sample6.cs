[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create([Bind(Exclude = "Id")] Movie movieToCreate)
{
	// Validate
	if (!ModelState.IsValid)
		return View();

	// Add to database
	try
	{
		_db.AddToMovieSet(movieToCreate);
		_db.SaveChanges();

		return RedirectToAction("Index");
	}
	catch
	{
		return View();
	}
}