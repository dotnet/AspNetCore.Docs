[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Edit(int? id, byte[] rowVersion)
{
    string[] fieldsToBind = new string[] { "Name", "Budget", "StartDate", "InstructorID", "RowVersion" };

    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }

    var departmentToUpdate = await db.Departments.FindAsync(id);
    if (departmentToUpdate == null)
    {
        Department deletedDepartment = new Department();
        TryUpdateModel(deletedDepartment, fieldsToBind);
        ModelState.AddModelError(string.Empty,
            "Unable to save changes. The department was deleted by another user.");
        ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FullName", deletedDepartment.InstructorID);
        return View(deletedDepartment);
    }

    if (TryUpdateModel(departmentToUpdate, fieldsToBind))
    {
        try
        {
            db.Entry(departmentToUpdate).OriginalValues["RowVersion"] = rowVersion;
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            var entry = ex.Entries.Single();
            var clientValues = (Department)entry.Entity;
            var databaseEntry = entry.GetDatabaseValues();
            if (databaseEntry == null)
            {
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The department was deleted by another user.");
            }
            else
            {
                var databaseValues = (Department)databaseEntry.ToObject();

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
                departmentToUpdate.RowVersion = databaseValues.RowVersion;
            }
        }
        catch (RetryLimitExceededException /* dex */)
        {
            //Log the error (uncomment dex variable name and add a line here to write a log.
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        }
    }
    ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);
    return View(departmentToUpdate);
}