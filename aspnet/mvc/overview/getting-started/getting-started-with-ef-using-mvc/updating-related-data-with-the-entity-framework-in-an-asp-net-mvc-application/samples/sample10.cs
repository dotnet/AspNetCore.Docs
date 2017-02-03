public ActionResult Edit(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Instructor instructor = db.Instructors
        .Include(i => i.OfficeAssignment)
        .Where(i => i.ID == id)
        .Single();
    if (instructor == null)
    {
        return HttpNotFound();
    }
    return View(instructor);
}