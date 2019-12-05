using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelBindingSample.Data;
using ModelBindingSample.Models;

namespace ModelBindingSample.Pages.Instructors
{
    public class EditModel : PageModel
    {
        private readonly InstructorContext _context;

        public EditModel(InstructorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
            {
                return NotFound();
            }

            Instructor = await _context.Instructors.FindAsync(Id);

            if (Instructor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Id == null)
            {
                return NotFound();
            }

            var instructorToUpdate = await _context.Instructors.FindAsync(Id);

            if (instructorToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            instructorToUpdate.FirstName = Instructor.FirstName;
            instructorToUpdate.LastName = Instructor.LastName;
            instructorToUpdate.DateHired = Instructor.DateHired;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
