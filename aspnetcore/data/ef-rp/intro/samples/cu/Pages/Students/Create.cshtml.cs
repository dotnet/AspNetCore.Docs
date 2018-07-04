using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
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
                LastName = "1 Smith"
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
                "student",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                #endregion
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
        #endregion
    }
}