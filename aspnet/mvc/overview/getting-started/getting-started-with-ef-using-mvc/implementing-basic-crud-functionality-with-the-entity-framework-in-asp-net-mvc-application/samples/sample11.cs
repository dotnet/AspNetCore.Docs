[HttpPost, ActionName("Edit")]
[ValidateAntiForgeryToken]
public ActionResult EditPost(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    var studentToUpdate = db.Students.Find(id);
    if (TryUpdateModel(studentToUpdate, "",
       new string[] { "LastName", "FirstMidName", "EnrollmentDate" }))
    {
        try
        {
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name and add a line here to write a log.
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        }
    }
    return View(studentToUpdate);
}