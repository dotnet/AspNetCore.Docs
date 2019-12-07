using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelBindingSample.Data;
using ModelBindingSample.Models;

namespace ModelBindingSample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .SeedDatabase()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IHost SeedDatabase(this IHost host)
        {
            using var serviceScope = host.Services.CreateScope();
            var instructorContext = serviceScope.ServiceProvider.GetRequiredService<InstructorContext>();

            var coursesToSeed = new[]
            {
                new Course { Id = 1050, Title = "Chemistry" },
                new Course { Id = 2021, Title = "Composition" },
                new Course { Id = 2042, Title = "Literature" },
                new Course { Id = 3141, Title = "Trigonometry" },
                new Course { Id = 4022, Title = "Microeconomics" },
                new Course { Id = 4041, Title = "Macroeconomics" }
            };

            var instructorsToSeed = new[]
            {
                new Instructor
                {
                    FirstName = "Kim",
                    LastName = "Abercrombie",
                    DateHired = DateTime.Parse("1995-03-11"),
                    InstructorCourses = coursesToSeed.Take(3).Select(c => new InstructorCourse { CourseId = c.Id }).ToList()
                },
                new Instructor
                {
                    FirstName = "Fadi",
                    LastName = "Fakhouri",
                    DateHired = DateTime.Parse("2002-07-06")
                },
                new Instructor
                {
                    FirstName = "Roger",
                    LastName = "Harui",
                    DateHired = DateTime.Parse("1998-07-01"),
                    InstructorCourses = coursesToSeed.Skip(3).Take(3).Select(c => new InstructorCourse { CourseId = c.Id }).ToList()
                }
            };

            instructorContext.Courses.AddRange(coursesToSeed);
            instructorContext.Instructors.AddRange(instructorsToSeed);

            instructorContext.SaveChanges();

            return host;
        }
    }
}
