using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RazorPagesMovie.Models;


namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public IndexModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movies { get;set; }

        public async Task OnGetAsync()
        {
            Movies = await _context.Movies.ToListAsync();
        }
    }
}
