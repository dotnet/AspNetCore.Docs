public IQueryable<Student> studentsGrid_GetData()
{
    SchoolContext db = new SchoolContext();
    var query = db.Students.Include(s => s.Enrollments.Select(e => e.Course));
    return query;
}