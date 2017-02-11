public ActionResult Create()
{
    PopulateDepartmentsDropDownList();
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
{
    try
    {
        if (ModelState.IsValid)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    catch (RetryLimitExceededException /* dex */)
    {
        //Log the error (uncomment dex variable name and add a line here to write a log.)
        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
    }
    PopulateDepartmentsDropDownList(course.DepartmentID);
    return View(course);
}

public ActionResult Edit(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Course course = db.Courses.Find(id);
    if (course == null)
    {
        return HttpNotFound();
    }
    PopulateDepartmentsDropDownList(course.DepartmentID);
    return View(course);
}

[HttpPost, ActionName("Edit")]
[ValidateAntiForgeryToken]
public ActionResult EditPost(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    var courseToUpdate = db.Courses.Find(id);
    if (TryUpdateModel(courseToUpdate, "",
       new string[] { "Title", "Credits", "DepartmentID" }))
    {
        try
        {
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (RetryLimitExceededException /* dex */)
        {
            //Log the error (uncomment dex variable name and add a line here to write a log.
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        }
    }
    PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
    return View(courseToUpdate);
}

private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
{
    var departmentsQuery = from d in db.Departments
                           orderby d.Name
                           select d;
    ViewBag.DepartmentID = new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
} 