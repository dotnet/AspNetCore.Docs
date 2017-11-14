using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Instructors
{
    public class TestCreateModel : InstructorCoursesPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public TestCreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var instructor = new Instructor();
            instructor.CourseAssignments = new List<CourseAssignment>();
            PopulateAssignedCourseData(_context, instructor);

            Instructor = new Instructor
            {
                FirstMidName = "Rick",
                LastName = "Anderson",
                HireDate = DateTime.Now
            };
            return Page();
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newInstructor = new Instructor();
            if (selectedCourses != null)
            {
                newInstructor.CourseAssignments = new List<CourseAssignment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new CourseAssignment
                    {
                        CourseID = int.Parse(course)
                    };
                    newInstructor.CourseAssignments.Add(courseToAdd);
                }
            }

            if (await TryUpdateModelAsync<Instructor>(
                newInstructor,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.OfficeAssignment))
            {
                _context.Instructors.Add(newInstructor);               
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // If TryUpdateModelAsync fails, repopulate course selections
            PopulateAssignedCourseData(_context, newInstructor);
            return Page();
        }
    }
}