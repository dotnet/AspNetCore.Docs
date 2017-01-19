new Enrollment { 
    StudentID = students.Single(s => s.LastName == "Alexander").ID, 
    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, 
    Grade = Grade.A 
},