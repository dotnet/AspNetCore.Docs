using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ModelBindingSample.Pages.InstructorsWithCollection
{
    public class CreateModel : InstructorsPageModel
    {
        public IActionResult OnGet()
        {
            var instructor = new InstructorWithCollection();
            instructor.Courses = new List<Course>();

            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedCourseData(instructor);
            Instructor = instructor;
            return Page();
        }

        [BindProperty]
        public InstructorWithCollection Instructor { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newInstructor = new InstructorWithCollection();
            if (selectedCourses != null)
            {
                newInstructor.Courses = new List<Course>();
                foreach (var course in selectedCourses)
                {
                    newInstructor.Courses.Add(_courses.Single(c => c.CourseID == int.Parse(course)));
                }
            }

            // <snippet_TryUpdate>
            if (await TryUpdateModelAsync<InstructorWithCollection>(
                newInstructor,
                "Instructor",
                i => i.FirstMidName, i => i.LastName, i => i.HireDate))
            {
                _instructorsInMemoryStore.Add(newInstructor);
                return RedirectToPage("./Index");
            }
            PopulateAssignedCourseData(newInstructor);
            return Page();
            // </snippet_TryUpdate>
        }
    }
}
