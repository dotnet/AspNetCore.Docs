using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;
using System;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //Movie = new Movie
            //{
            //    Genre = "Action",
            //    Price = 1.99m,
            //    ReleaseDate = DateTime.Now,
            //    Title = "Conan"
            //    , Rating = "R"
            //};
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        #region snippet
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        #endregion
    }
}
