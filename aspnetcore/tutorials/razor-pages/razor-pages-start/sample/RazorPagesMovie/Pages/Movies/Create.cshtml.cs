using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
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
            Movie = new Movie
            {
                Title = "The Good, the bad, and the ugly",
                Genre = "Western",
                Price = 1.19M,
                ReleaseDate = DateTime.Now,
                Rating = "NA"
            };
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

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
    }
}
