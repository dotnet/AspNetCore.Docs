using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ModelBindingSample.Pages.InstructorsWithCollectionWithDictionary
{
    public class CreateModel : InstructorsPageModel
    {
        public CreateModel() : base()
        {
        }

        public IActionResult OnGet()
        {
            Instructor = new InstructorWithDictionary();
            Instructor.Courses = new Dictionary<int, string>();
            Instructor.Courses[0] = "New course";
            Instructor.Courses[1] = "New course";
            Instructor.Courses[2] = "New course";

            return Page();
        }

        [BindProperty]
        public InstructorWithDictionary Instructor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newInstructor = new InstructorWithDictionary();
            newInstructor.Courses = new Dictionary<int, string>();

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