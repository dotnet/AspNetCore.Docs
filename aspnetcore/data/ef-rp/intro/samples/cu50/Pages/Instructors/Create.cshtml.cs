using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContosoUniversity.Pages.Instructors
{
    public class CreateModel : InstructorCoursesPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var instructor = new Instructor();
            instructor.Courses = new List<Course>();

            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedCourseData(_context, instructor);
            return Page();
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newInstructor = new Instructor();

            if (await TryUpdateModelAsync<Instructor>(
                newInstructor,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.OfficeAssignment))
            {
                _context.Instructors.Add(newInstructor);
                await _context.SaveChangesAsync();
                if (selectedCourses != null)
                {
                    await AddInstructorToCoursesAsync(selectedCourses, newInstructor.ID);
                }
                return RedirectToPage("./Index");
            }
            PopulateAssignedCourseData(_context, newInstructor);
            return Page();
        }

        public async Task AddInstructorToCoursesAsync(string[] selectedCourses, int id)
        {
            Instructor newInstructor = await _context.Instructors
                                        .FirstOrDefaultAsync(m => m.ID == id);

            foreach (var course in selectedCourses)
            {
                Course Course = await _context.Courses
                      .Include(c => c.Instructors)
                      .FirstOrDefaultAsync(m => m.CourseID == int.Parse(course));

                Course.Instructors.Add(newInstructor);
                await _context.SaveChangesAsync();
            }

        }
    }
}
