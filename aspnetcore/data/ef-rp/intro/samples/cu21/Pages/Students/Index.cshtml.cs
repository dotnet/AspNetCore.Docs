#define SortFilterPage // SortFilterPage // SortFilter //SortOnly // first 

using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Students
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        #endregion

#if SortFilterPage
        #region snippet_SortFilterPageType
        public PaginatedList<Student> Student { get; set; }
        #endregion
#else
        public IList<Student> Student { get; set; }
#endif

#if first
        #region snippet_ScaffoldedIndex
        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
        #endregion
#endif

#if SortOnly
        #region snippet_SortOnly
        public async Task OnGetAsync(string sortOrder)
        {
        #region snippet_Ternary
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
        #endregion

            IQueryable<Student> studentIQ = from s in _context.Student
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

        #region snippet_SortOnlyRtn
            Student = await studentIQ.AsNoTracking().ToListAsync();
        #endregion
        }
        #endregion
#endif
#if SortFilter
        #region snippet_SortFilter
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentFilter = searchString;

            IQueryable<Student> studentIQ = from s in _context.Student
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }

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
#if SortFilterPage
        #region snippet_SortFilterPage
        #region snippet_SortFilterPage2
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        #endregion
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            #region snippet_SortFilterPage3
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            #endregion

            CurrentFilter = searchString;

            IQueryable<Student> studentIQ = from s in _context.Student
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }
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

            int pageSize = 3;
            #region snippet_SortFilterPage4
            Student = await PaginatedList<Student>.CreateAsync(
                studentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            #endregion
        }
        #endregion
#endif
    }
}
