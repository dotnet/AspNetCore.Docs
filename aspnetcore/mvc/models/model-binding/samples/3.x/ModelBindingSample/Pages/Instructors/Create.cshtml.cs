using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelBindingSample.Data;
using ModelBindingSample.Models;

namespace ModelBindingSample.Pages.Instructors
{
    #region snippet_BindProperty
    public class CreateModel : PageModel
    {
        private readonly InstructorContext _context;

        public CreateModel(InstructorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Instructor Instructor { get; set; }
        #endregion

        #region snippet_ModelState
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Instructors.Add(Instructor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        #endregion
    }
}
