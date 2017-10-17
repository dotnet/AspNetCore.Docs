#define SortOnly // first 

using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

#if first
        public IList<Student> Student { get; set; }

        #region snippet_ScaffoldedIndex
        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
        #endregion
#endif

#if SortOnly
        #region snippet_SortOnly
        public IQueryable<Student> Student { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSort"] = sortOrder == "Date" ? "date_desc" : "Date";

            // Initialize IQueryable<Student> Student
            Student = from s in _context.Students
                      select s;

            switch (sortOrder)
            {
                case "name_desc":
                    Student = Student.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    Student = Student.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    Student = Student.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    Student = Student.OrderBy(s => s.LastName);
                    break;
            }
            await Student.AsNoTracking().ToListAsync();
        }
        #endregion
#endif

    }
}
