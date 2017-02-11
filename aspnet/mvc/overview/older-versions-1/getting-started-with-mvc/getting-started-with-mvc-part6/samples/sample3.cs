[HttpPost]
public ActionResult Create(Movie newMovie)
{
    if (ModelState.IsValid)
    {
        db.AddToMovies(newMovie);
        db.SaveChanges();

        return RedirectToAction("Index");
    }
    else
    {
        return View(newMovie);
    }
}