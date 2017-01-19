public ActionResult Create()
{
   PopulateDepartmentsDropDownList();
   return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create(
   [Bind(Include = "CourseID,Title,Credits,DepartmentID")]
   Course course)
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
   catch (DataException /* dex */)
   {
      //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
      ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
   }
   PopulateDepartmentsDropDownList(course.DepartmentID);
   return View(course);
}

public ActionResult Edit(int id)
{
   Course course = db.Courses.Find(id);
   PopulateDepartmentsDropDownList(course.DepartmentID);
   return View(course);
}

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(
    [Bind(Include = "CourseID,Title,Credits,DepartmentID")]
    Course course)
{
   try
   {
      if (ModelState.IsValid)
      {
         db.Entry(course).State = EntityState.Modified;
         db.SaveChanges();
         return RedirectToAction("Index");
      }
   }
   catch (DataException /* dex */)
   {
      //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
      ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
   }
   PopulateDepartmentsDropDownList(course.DepartmentID);
   return View(course);
}

private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
{
   var departmentsQuery = from d in db.Departments
                          orderby d.Name
                          select d;
   ViewBag.DepartmentID = new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
} 