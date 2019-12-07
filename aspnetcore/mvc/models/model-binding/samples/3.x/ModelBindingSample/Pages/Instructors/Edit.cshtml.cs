using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelBindingSample.Data;
using ModelBindingSample.Models;

namespace ModelBindingSample.Pages.Instructors
{
    #region snippet_BindProperties
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly InstructorContext _context;

        public EditModel(InstructorContext context)
        {
            _context = context;
        }

        public Instructor Instructor { get; set; }
        #endregion

        #region snippet_SupportsGet
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        #endregion

        [BindProperty]
        public List<int> SelectedCourses { get; set; }

        public List<Course> Courses { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
            {
                return NotFound();
            }

            Instructor = await _context.Instructors
                .Include(i => i.InstructorCourses)
                .ThenInclude(ic => ic.Course)
                .SingleOrDefaultAsync(c => c.Id == Id);

            if (Instructor == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.ToListAsync();
            SelectedCourses = Instructor.InstructorCourses.Select(c => c.CourseId).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Id == null)
            {
                return NotFound();
            }

            var instructorToUpdate = await _context.Instructors
                .Include(i => i.InstructorCourses)
                .ThenInclude(ic => ic.Course)
                .SingleOrDefaultAsync(c => c.Id == Id);

            if (instructorToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                Courses = await _context.Courses.ToListAsync();
                return Page();
            }

            instructorToUpdate.FirstName = Instructor.FirstName;
            instructorToUpdate.LastName = Instructor.LastName;
            instructorToUpdate.DateHired = Instructor.DateHired;
            instructorToUpdate.InstructorCourses = (from sc in SelectedCourses.Distinct() join c in _context.Courses on sc equals c.Id select new InstructorCourse { CourseId = c.Id }).ToList();

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
