using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // TODO remove. For quick testing.
            Student = new Student
            {
                EnrollmentDate = DateTime.Now,
                FirstMidName = "Joe",
                LastName = "Smith"
            };
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        #region snippet_OnPostAsync
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            #region snippet_TryUpdateModelAsync

            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                #endregion
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");

                }
                // requires using Microsoft.EntityFrameworkCore;
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to Create. ");
                }
            }

            return Page();
        }
        #endregion
    }
}