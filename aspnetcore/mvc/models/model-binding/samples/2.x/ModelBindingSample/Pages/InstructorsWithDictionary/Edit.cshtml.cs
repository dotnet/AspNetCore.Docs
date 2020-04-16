#define TryUpdate

using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ModelBindingSample.Pages.InstructorsWithDictionary
{
    public class EditModel : InstructorsPageModel
    {
        [BindProperty]
        public InstructorWithDictionary Instructor { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instructor = _instructorsInMemoryStore.FirstOrDefault(m => m.ID == id);

            if (Instructor == null)
            {
                return NotFound();
            }
            //PopulateAssignedCourseData(Instructor);
            return Page();
        }

#if TryUpdate
        public async Task<IActionResult> OnPostAsync(int? id, Dictionary<string, string> courses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var instructorToUpdate = _instructorsInMemoryStore.FirstOrDefault(s => s.ID == id);

            if (await TryUpdateModelAsync<InstructorWithDictionary>(
                instructorToUpdate,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.Courses))
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
#else
        public IActionResult OnPost(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var instructorToUpdate = _instructorsInMemoryStore.FirstOrDefault(s => s.ID == id);
            instructorToUpdate.FirstMidName = Instructor.FirstMidName;
            instructorToUpdate.LastName = Instructor.LastName;
            instructorToUpdate.HireDate = Instructor.HireDate;
            instructorToUpdate.Courses = Instructor.Courses;
            return RedirectToPage("./Index");
        }
#endif
    }

    public class LastNameTest
    {
        public string LastName { get; set; }
    }
}
