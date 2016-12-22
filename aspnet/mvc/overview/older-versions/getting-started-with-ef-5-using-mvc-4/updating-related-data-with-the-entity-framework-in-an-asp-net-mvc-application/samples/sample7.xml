public ActionResult Edit(int id = 0)
{
    Instructor instructor = db.Instructors.Find(id);
    if (instructor == null)
    {
        return HttpNotFound();
    }
    ViewBag.InstructorID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.InstructorID);
    return View(instructor);
}