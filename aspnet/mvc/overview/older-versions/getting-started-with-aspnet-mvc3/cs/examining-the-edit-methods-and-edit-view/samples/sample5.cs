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