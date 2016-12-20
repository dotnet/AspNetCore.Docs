[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(int id)
{
   Instructor instructor = db.Instructors
     .Include(i => i.OfficeAssignment)
     .Where(i => i.ID == id)
     .Single();

   db.Instructors.Remove(instructor);

    var department = db.Departments
        .Where(d => d.InstructorID == id)
        .SingleOrDefault();
    if (department != null)
    {
        department.InstructorID = null;
    }

   db.SaveChanges();
   return RedirectToAction("Index");
}