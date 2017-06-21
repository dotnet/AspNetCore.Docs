public ActionResult About()
{
    // Commenting out LINQ to show how to do the same thing in SQL.
    //IQueryable<EnrollmentDateGroup> = from student in db.Students
    //           group student by student.EnrollmentDate into dateGroup
    //           select new EnrollmentDateGroup()
    //           {
    //               EnrollmentDate = dateGroup.Key,
    //               StudentCount = dateGroup.Count()
    //           };

    // SQL version of the above LINQ code.
    string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
        + "FROM Person "
        + "WHERE Discriminator = 'Student' "
        + "GROUP BY EnrollmentDate";
    IEnumerable<EnrollmentDateGroup> data = db.Database.SqlQuery<EnrollmentDateGroup>(query);

    return View(data.ToList());
}