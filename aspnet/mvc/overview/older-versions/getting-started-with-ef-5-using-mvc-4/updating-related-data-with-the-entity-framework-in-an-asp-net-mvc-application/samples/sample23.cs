[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(int id)
{
   Instructor instructor = db.Instructors
     .Include(i => i.OfficeAssignment)
     .Where(i => i.InstructorID == id)
     .Single();

   instructor.OfficeAssignment = null;
   db.Instructors.Remove(instructor);
   db.SaveChanges();
   return RedirectToAction("Index");
}