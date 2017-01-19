[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(int? id, string[] selectedCourses)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    var instructorToUpdate = db.Instructors
       .Include(i => i.OfficeAssignment)
       .Include(i => i.Courses)
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

            UpdateInstructorCourses(selectedCourses, instructorToUpdate);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (RetryLimitExceededException /* dex */)
        {
            //Log the error (uncomment dex variable name and add a line here to write a log.
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        }
    }
    PopulateAssignedCourseData(instructorToUpdate);
    return View(instructorToUpdate);
}
private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate)
{
   if (selectedCourses == null)
   {
      instructorToUpdate.Courses = new List<Course>();
      return;
   }
 
   var selectedCoursesHS = new HashSet<string>(selectedCourses);
   var instructorCourses = new HashSet<int>
       (instructorToUpdate.Courses.Select(c => c.CourseID));
   foreach (var course in db.Courses)
   {
      if (selectedCoursesHS.Contains(course.CourseID.ToString()))
      {
         if (!instructorCourses.Contains(course.CourseID))
         {
            instructorToUpdate.Courses.Add(course);
         }
      }
      else
      {
         if (instructorCourses.Contains(course.CourseID))
         {
            instructorToUpdate.Courses.Remove(course);
         }
      }
   }
}