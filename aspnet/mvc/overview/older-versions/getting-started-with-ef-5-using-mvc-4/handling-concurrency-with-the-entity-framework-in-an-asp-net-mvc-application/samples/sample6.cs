[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(
   [Bind(Include = "DepartmentID, Name, Budget, StartDate, RowVersion, InstructorID")]
    Department department)
{
   try
   {
      if (ModelState.IsValid)
      {
         db.Entry(department).State = EntityState.Modified;
         db.SaveChanges();
         return RedirectToAction("Index");
      }
   }
   catch (DbUpdateConcurrencyException ex)
   {
      var entry = ex.Entries.Single();
      var clientValues = (Department)entry.Entity;
      var databaseValues = (Department)entry.GetDatabaseValues().ToObject();

      if (databaseValues.Name != clientValues.Name)
         ModelState.AddModelError("Name", "Current value: "
             + databaseValues.Name);
      if (databaseValues.Budget != clientValues.Budget)
         ModelState.AddModelError("Budget", "Current value: "
             + String.Format("{0:c}", databaseValues.Budget));
      if (databaseValues.StartDate != clientValues.StartDate)
         ModelState.AddModelError("StartDate", "Current value: "
             + String.Format("{0:d}", databaseValues.StartDate));
      if (databaseValues.InstructorID != clientValues.InstructorID)
         ModelState.AddModelError("InstructorID", "Current value: "
             + db.Instructors.Find(databaseValues.InstructorID).FullName);
      ModelState.AddModelError(string.Empty, "The record you attempted to edit "
          + "was modified by another user after you got the original value. The "
          + "edit operation was canceled and the current values in the database "
          + "have been displayed. If you still want to edit this record, click "
          + "the Save button again. Otherwise click the Back to List hyperlink.");
      department.RowVersion = databaseValues.RowVersion;
   }
   catch (DataException /* dex */)
   {
      //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
      ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
   }

   ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FullName", department.InstructorID);
   return View(department);
}