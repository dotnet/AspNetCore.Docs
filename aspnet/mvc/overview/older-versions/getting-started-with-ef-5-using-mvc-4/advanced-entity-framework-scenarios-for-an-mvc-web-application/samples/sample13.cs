public ViewResult Index()
{
    var courses = unitOfWork.CourseRepository.Get();
    return View(courses.ToList());
}