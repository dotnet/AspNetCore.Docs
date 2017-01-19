[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(
   [Bind(Include = "DepartmentID, Name, Budget, StartDate, RowVersion, PersonID")]
    Department department)
{
   try
   {
      if (ModelState.IsValid)
      {
         ValidateOneAdministratorAssignmentPerInstructor(department);
      }

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