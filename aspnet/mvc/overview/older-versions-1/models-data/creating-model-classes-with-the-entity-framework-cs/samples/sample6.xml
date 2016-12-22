public ActionResult Edit(int id)
{
    // Get movie to update
    var movieToUpdate = _db.MovieSet.First(m => m.Id == id);

    ViewData.Model = movieToUpdate;
    return View();
}

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Edit(FormCollection form)
{
    // Get movie to update
    var id = Int32.Parse(form["id"]);
    var movieToUpdate = _db.MovieSet.First(m => m.Id == id);

    // Deserialize (Include white list!)
    TryUpdateModel(movieToUpdate, new string[] { "Title", "Director" }, form.ToValueProvider());

    // Validate
    if (String.IsNullOrEmpty(movieToUpdate.Title))
        ModelState.AddModelError("Title", "Title is required!");
    if (String.IsNullOrEmpty(movieToUpdate.Director))
        ModelState.AddModelError("Director", "Director is required!");

    // If valid, save movie to database
    if (ModelState.IsValid)
    {
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    // Otherwise, reshow form
    return View(movieToUpdate);
}