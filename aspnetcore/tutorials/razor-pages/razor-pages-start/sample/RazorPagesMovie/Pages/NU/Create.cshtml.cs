// Unused usings removed.
#define NS

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using RazorPagesMovie.Models;  // Not used

namespace RazorPagesMovie.Pages.Movie
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public CreateModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Movie = new Models.Movie
            {
                Title = "Conan",
                Genre = "Action",
                Price = 1.99M
            };
            return Page();
        }

        [BindProperty]
#if NS
        public Models.Movie Movie { get; set; }
#else
        public Movie Movie { get; set; }
#endif

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Movie/Index");
        }
    }
}