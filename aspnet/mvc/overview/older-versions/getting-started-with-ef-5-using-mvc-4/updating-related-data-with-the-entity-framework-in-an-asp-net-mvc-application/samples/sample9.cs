[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(int id, FormCollection formCollection)
{
   var instructorToUpdate = db.Instructors
       .Include(i => i.OfficeAssignment)
       .Where(i => i.InstructorID == id)
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

         db.Entry(instructorToUpdate).State = EntityState.Modified;
         db.SaveChanges();

         return RedirectToAction("Index");
      }
      catch (DataException /* dex */)
      {
         //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
         ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
      }
   }
   ViewBag.InstructorID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", id);
   return View(instructorToUpdate);
}