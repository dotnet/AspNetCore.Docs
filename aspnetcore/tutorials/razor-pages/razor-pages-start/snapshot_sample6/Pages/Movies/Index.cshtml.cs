#region snippetFull 
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

#region snippet
namespace RazorPagesMovie.Pages.Movies
{
#pragma warning disable CS8618
#pragma warning disable CS8604
    #region snippet2
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }
        #endregion

        public IList<Movie> Movie { get; set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
#pragma warning restore CS8618
#pragma warning restore CS8604
}
#endregion
#endregion
