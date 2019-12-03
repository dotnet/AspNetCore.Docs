using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelBindingSample.Data;
using ModelBindingSample.Models;

namespace ModelBindingSample.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly InstructorContext _context;

        public IndexModel(InstructorContext context)
        {
            _context = context;
        }

        public List<Instructor> Instructors { get; set; }

        public async Task OnGetAsync()
        {
            Instructors = await _context.Instructors.ToListAsync();
        }
    }
}
