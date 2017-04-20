public ActionResult Details(int id)
{
    var query = "SELECT * FROM Course WHERE CourseID = @p0";
    return View(unitOfWork.CourseRepository.GetWithRawSql(query, id).Single());
}