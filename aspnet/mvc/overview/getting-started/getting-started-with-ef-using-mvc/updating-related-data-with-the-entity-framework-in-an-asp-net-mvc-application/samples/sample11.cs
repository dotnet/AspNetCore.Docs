[HttpPost, ActionName("Edit")]
[ValidateAntiForgeryToken]
public ActionResult EditPost(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    var instructorToUpdate = db.Instructors
       .Include(i => i.OfficeAssignment)
       .Where(i => i.ID == id)
       .Single();

    if (TryUpdateModel(instructorToUpdate, "",
       new string[] { "LastName", "FirstMidName", "HireDate", "OfficeAssignment" }))
    {
       try
       {
          if (String.IsNullOrWhiteSpace(instructorToUpdate.OfficeAssignment.Location))
          {
             instructorToUpdate.OfficeAssignment = null;
          }

          db.SaveChanges();

          return RedirectToAction("Index");
       }
       catch (RetryLimitExceededException /* dex */)
      {
         //Log the error (uncomment dex variable name and add a line here to write a log.
         ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
      }
   }
   return View(instructorToUpdate);
}