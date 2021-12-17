using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    #region snippet
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(RazorPagesMovieContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            _logger.LogInformation("IndexModel OnGetAsync.");
            Movie = await _context.Movie.ToListAsync();
        }
    }
    #endregion
}
