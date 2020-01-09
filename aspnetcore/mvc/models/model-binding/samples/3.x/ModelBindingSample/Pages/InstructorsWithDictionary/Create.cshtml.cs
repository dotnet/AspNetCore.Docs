using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelBindingSample.Pages.InstructorsWithDictionary
{
    public class CreateModel : InstructorsPageModel
    {
        public IActionResult OnGet()
        {

            Instructor = new InstructorWithDictionary();
            Instructor.Courses = new Dictionary<string, string>();
            Instructor.Courses["1000"] = "New course A";
            Instructor.Courses["2000"] = "New course B";
            Instructor.Courses["3000"] = "New course C";

            return Page();
        }

        [BindProperty]
        public InstructorWithDictionary Instructor { get; set; }

        public async Task<IActionResult> OnPostAsync(Dictionary<string, string> selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newInstructor = new InstructorWithDictionary();
            newInstructor.Courses = new Dictionary<string, string>();

            if (await TryUpdateModelAsync<InstructorWithDictionary>(
                newInstructor,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.Courses))
            {
                _instructorsInMemoryStore.Add(newInstructor);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
