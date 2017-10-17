#define SortOnly // first 

using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public IList<Student> Student { get; set; }

#if first
        #region snippet_ScaffoldedIndex
        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
        #endregion
#endif

#if SortOnly
        #region snippet_SortOnly
        public async Task OnGetAsync(string sortOrder)
        {
            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSort"] = sortOrder == "Date" ? "date_desc" : "Date";

            // Initialize IQueryable<Student> Student
            IQueryable<Student> studentIQ = from s in _context.Students
                                            select s;

            switch (sortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentIQ = studentIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.LastName);
                    break;
            }
            Student = await studentIQ.AsNoTracking().ToListAsync();
        }
        #endregion
#endif

    }
}
