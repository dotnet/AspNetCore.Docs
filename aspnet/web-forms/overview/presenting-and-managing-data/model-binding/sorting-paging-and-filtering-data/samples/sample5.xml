public IQueryable<Student> studentsGrid_GetData([Control] AcademicYear? displayYear)
{
    SchoolContext db = new SchoolContext();
    var query = db.Students.Include(s => s.Enrollments.Select(e => e.Course));

    if (displayYear != null)
    {
        query = query.Where(s => s.Year == displayYear);   
    }

    return query;    
}