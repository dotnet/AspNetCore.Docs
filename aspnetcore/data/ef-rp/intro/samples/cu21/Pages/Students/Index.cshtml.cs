#define first // SortFilterPage // SortFilter //SortOnly // first 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Models.SchoolContext _context;

        public IndexModel(ContosoUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

#if first
        #region snippet_ScaffoldedIndex
        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
        #endregion
#endif
    }
