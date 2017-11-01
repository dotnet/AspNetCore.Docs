using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace ContosoUniversity.Pages.Students
{
    public class EditVmModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public EditVmModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student Student = await _context.Students.FirstOrDefaultAsync (m => m.ID == id);
            CopyStudentToStudentVM(Student);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        private void CopyStudentToStudentVM(Student student)
        {
            StudentVM = new StudentVM();
            StudentVM.EnrollmentDate = student.EnrollmentDate;
            StudentVM.FirstMidName = student.FirstMidName;
            StudentVM.LastName = student.LastName;
        }

        #region snippet_OnPostAsync
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentToUpdate = await _context.FindAsync<Student>(id);
            if (await TryUpdateModelAsync(
                studentToUpdate,
                nameof(StudentVM),
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        #endregion
    }
}
