//
// GET: /Movies/Edit/5

public ActionResult Edit(int id) 
{
    Movie movie = db.Movies.Find(id);
    return View(movie);
}

//
// POST: /Movies/Edit/5

[HttpPost]
public ActionResult Edit(Movie movie) 
{
    if (ModelState.IsValid) 
    {
        db.Entry(movie).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(movie);
}