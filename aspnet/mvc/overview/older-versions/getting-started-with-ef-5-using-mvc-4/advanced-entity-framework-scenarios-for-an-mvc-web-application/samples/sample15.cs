public ActionResult Index(int? SelectedDepartment)
{
    var departments = unitOfWork.DepartmentRepository.Get(
        orderBy: q => q.OrderBy(d => d.Name));
    ViewBag.SelectedDepartment = new SelectList(departments, "DepartmentID", "Name", SelectedDepartment);

    int departmentID = SelectedDepartment.GetValueOrDefault(); 
    return View(unitOfWork.CourseRepository.Get(
        filter: d => !SelectedDepartment.HasValue || d.DepartmentID == departmentID,
        orderBy: q => q.OrderBy(d => d.CourseID),
        includeProperties: "Department"));
}