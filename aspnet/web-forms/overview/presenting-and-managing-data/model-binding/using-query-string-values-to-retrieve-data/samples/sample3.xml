public IQueryable<Enrollment> coursesGrid_GetData([QueryString] int? studentID)
{
    SchoolContext db = new SchoolContext();
    var query = db.Enrollments.Include(e => e.Course)
        .Where(e => e.StudentID == studentID);
    return query;
}