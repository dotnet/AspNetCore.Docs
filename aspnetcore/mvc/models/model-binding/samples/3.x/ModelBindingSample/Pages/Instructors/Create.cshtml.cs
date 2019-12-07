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

        [BindProperty]
        public List<int> SelectedCourses { get; set; }

        public List<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses.ToListAsync();
            SelectedCourses = new List<int>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Courses = await _context.Courses.ToListAsync();

            #region snippet_ModelState
            if (!ModelState.IsValid)
            {
                return Page();
            }
            #endregion

            Instructor.InstructorCourses = (from sc in SelectedCourses.Distinct() join c in _context.Courses on sc equals c.Id select new InstructorCourse { CourseId = c.Id }).ToList();

            _context.Instructors.Add(Instructor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
