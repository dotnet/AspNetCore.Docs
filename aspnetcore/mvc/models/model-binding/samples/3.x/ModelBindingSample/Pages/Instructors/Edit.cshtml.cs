using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ModelBindingSample.Pages.Instructors
{
    // <snippet_BindProperty>
    public class EditModel : InstructorsPageModel
    {
        [BindProperty]
        public Instructor Instructor { get; set; }
        // </snippet_BindProperty>

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

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var instructorToUpdate = _instructorsInMemoryStore.First(s => s.ID == id);

            instructorToUpdate.FirstMidName = Instructor.FirstMidName;
            instructorToUpdate.LastName = Instructor.LastName;
            instructorToUpdate.HireDate = Instructor.HireDate;
            instructorToUpdate.OfficeAssignment = Instructor.OfficeAssignment;
            return RedirectToPage("./Index");
        }
    }
}
