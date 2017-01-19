public ActionResult Edit(int id)
{
    Instructor instructor = db.Instructors
        .Include(i => i.OfficeAssignment)
        .Where(i => i.InstructorID == id)
        .Single();
    return View(instructor);
}