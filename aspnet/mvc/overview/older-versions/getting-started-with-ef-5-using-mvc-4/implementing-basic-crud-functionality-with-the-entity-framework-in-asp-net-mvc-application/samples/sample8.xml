[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(
   [Bind(Include = "StudentID, LastName, FirstMidName, EnrollmentDate")]
   Student student)
{
   try
   {
      if (ModelState.IsValid)
      {
         db.Entry(student).State = EntityState.Modified;
         db.SaveChanges();
         return RedirectToAction("Index");
      }
   }
   catch (DataException /* dex */)
   {
      //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
      ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
   }
   return View(student);
}