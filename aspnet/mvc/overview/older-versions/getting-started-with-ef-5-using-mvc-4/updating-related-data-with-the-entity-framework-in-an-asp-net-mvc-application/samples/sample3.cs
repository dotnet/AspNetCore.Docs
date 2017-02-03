public ActionResult Edit(int id)
{
    Course course = db.Courses.Find(id);
    PopulateDepartmentsDropDownList(course.DepartmentID);
    return View(course);
}