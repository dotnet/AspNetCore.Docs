using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Students
{
    public class CreateVmModel : PageModel
    {
        private readonly ContosoUniversity.Models.SchoolContext _context;

        public CreateVmModel(ContosoUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // TODO remove. For quick testing.
            StudentVM = new StudentVM
            {
                EnrollmentDate = DateTime.Now.AddYears(-10),
                FirstMidName = "Rick",
                LastName = "Anderson"
            };
            return Page();
        }

        #region snippet_OnPostAsync
        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        #endregion
    }
}