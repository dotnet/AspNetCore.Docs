using System;
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

            instructorContext.Instructors.AddRange(
                new Instructor
                {
                    FirstName = "Kim",
                    LastName = "Abercrombie",
                    DateHired = DateTime.Parse("1995-03-11")
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
                    DateHired = DateTime.Parse("1998-07-01")
                });

            instructorContext.SaveChanges();

            return host;
        }
    }
}
