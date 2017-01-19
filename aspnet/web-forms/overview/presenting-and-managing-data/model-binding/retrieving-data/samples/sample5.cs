namespace ContosoUniversityModelBinding.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ContosoUniversityModelBinding.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {

            context.Students.AddOrUpdate(
                 new Student { 
                     FirstName = "Carson", 
                     LastName = "Alexander", 
                     Year = AcademicYear.Freshman },
                 new Student { 
                     FirstName = "Meredith", 
                     LastName = "Alonso", 
                     Year = AcademicYear.Freshman },
                 new Student { 
                     FirstName = "Arturo", 
                     LastName = "Anand", 
                     Year = AcademicYear.Sophomore },
                 new Student { 
                     FirstName = "Gytis", 
                     LastName = "Barzdukas", 
                     Year = AcademicYear.Sophomore },
                 new Student { 
                     FirstName = "Yan", 
                     LastName = "Li", 
                     Year = AcademicYear.Junior },
                 new Student { 
                     FirstName = "Peggy", 
                     LastName = "Justice", 
                     Year = AcademicYear.Junior },
                 new Student { 
                     FirstName = "Laura", 
                     LastName = "Norman", 
                     Year = AcademicYear.Senior },
                 new Student { 
                     FirstName = "Nino", 
                     LastName = "Olivetto", 
                     Year = AcademicYear.Senior }
                 );

            context.SaveChanges();

            context.Courses.AddOrUpdate(
                new Course { Title = "Chemistry", Credits = 3 },
                new Course { Title = "Microeconomics", Credits = 3 },
                new Course { Title = "Macroeconomics", Credits = 3 },
                new Course { Title = "Calculus", Credits = 4 },
                new Course { Title = "Trigonometry", Credits = 4 },
                new Course { Title = "Composition", Credits = 3 },
                new Course { Title = "Literature", Credits = 4 }
                );

            context.SaveChanges();

            context.Enrollments.AddOrUpdate(
                new Enrollment { StudentID = 1, CourseID = 1, Grade = 1 },
                new Enrollment { StudentID = 1, CourseID = 2, Grade = 3 },
                new Enrollment { StudentID = 1, CourseID = 3, Grade = 1 },
                new Enrollment { StudentID = 2, CourseID = 4, Grade = 2 },
                new Enrollment { StudentID = 2, CourseID = 5, Grade = 4 },
                new Enrollment { StudentID = 2, CourseID = 6, Grade = 4 },
                new Enrollment { StudentID = 3, CourseID = 1 },
                new Enrollment { StudentID = 4, CourseID = 1 },
                new Enrollment { StudentID = 4, CourseID = 2, Grade = 4 },
                new Enrollment { StudentID = 5, CourseID = 3, Grade = 3 },
                new Enrollment { StudentID = 6, CourseID = 4 },
                new Enrollment { StudentID = 7, CourseID = 5, Grade = 2 }
                );

            context.SaveChanges();
        }
    }
}