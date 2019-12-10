using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ModelBindingSample.Pages.InstructorsWithCollection
{
    public class EditModel : InstructorsPageModel
    {
        [BindProperty]
        public InstructorWithCollection Instructor { get; set; }

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
            PopulateAssignedCourseData(Instructor);
            return Page();
        }

        public IActionResult OnPost(int? id, string[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                UpdateInstructorCourses(selectedCourses, Instructor);
                PopulateAssignedCourseData(Instructor);
                return Page();
            }

            var instructorToUpdate = _instructorsInMemoryStore.FirstOrDefault(s => s.ID == id);

            instructorToUpdate.FirstMidName = Instructor.FirstMidName;
            instructorToUpdate.LastName = Instructor.LastName;
            instructorToUpdate.HireDate = Instructor.HireDate;
            UpdateInstructorCourses(selectedCourses, instructorToUpdate);
            return RedirectToPage("./Index");
        }
    }
}
