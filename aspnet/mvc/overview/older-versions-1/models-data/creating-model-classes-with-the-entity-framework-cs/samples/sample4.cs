public ActionResult Add()
{
    return View();
}

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Add(FormCollection form)
{
    var movieToAdd = new Movie();

    // Deserialize (Include white list!)
    TryUpdateModel(movieToAdd, new string[] { "Title", "Director" }, form.ToValueProvider());

    // Validate
    if (String.IsNullOrEmpty(movieToAdd.Title))
        ModelState.AddModelError("Title", "Title is required!");
    if (String.IsNullOrEmpty(movieToAdd.Director))
        ModelState.AddModelError("Director", "Director is required!");

    // If valid, save movie to database
    if (ModelState.IsValid)
    {
        _db.AddToMovieSet(movieToAdd);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    // Otherwise, reshow form
    return View(movieToAdd);
}