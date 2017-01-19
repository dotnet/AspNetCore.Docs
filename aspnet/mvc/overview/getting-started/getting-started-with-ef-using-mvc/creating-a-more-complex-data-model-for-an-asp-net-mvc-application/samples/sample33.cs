var courses = new List<Course>
{
    new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
      DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
      Instructors = new List<Instructor>() 
    },
    ...
};
courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
context.SaveChanges();