var courses = new List<Course>
{
     new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
       Department = departments.Single( s => s.Name == "Engineering"),
       Instructors = new List<Instructor>() 
     },
     ...
};
courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
context.SaveChanges();