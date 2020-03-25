using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ValidationSample.Data;
using ValidationSample.Models;

namespace ValidationSample.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieContext _context;

        public CreateModel(MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        #region snippet_OnPostAsync
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        #endregion

        public async Task<IActionResult> OnPostTryValidateAsync()
        {
            var modifiedReleaseDate = DateTime.Now.Date;

            #region snippet_TryValidate
            Movie.ReleaseDate = modifiedReleaseDate;

            if (!TryValidateModel(Movie, nameof(Movie)))
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            #endregion
        }
    }
}
