public ActionResult Index(string sortOrder)
{
   ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
   ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
   var students = from s in db.Students
                  select s;
   switch (sortOrder)
   {
      case "Name_desc":
         students = students.OrderByDescending(s => s.LastName);
         break;
      case "Date":
         students = students.OrderBy(s => s.EnrollmentDate);
         break;
      case "Date_desc":
         students = students.OrderByDescending(s => s.EnrollmentDate);
         break;
      default:
         students = students.OrderBy(s => s.LastName);
         break;
   }
   return View(students.ToList());
}