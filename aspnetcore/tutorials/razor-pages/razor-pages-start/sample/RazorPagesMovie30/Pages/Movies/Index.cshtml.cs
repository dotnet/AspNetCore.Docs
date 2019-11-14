#define  SearchGenreAndString   //SearchString
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{
    #region snippet_newProps
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        #endregion

#if SearchString
        #region snippet_1stSearch
        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie
                         select m;
        #region snippet_SearchNull
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
        #endregion

            Movie = await movies.ToListAsync();
        }
        #endregion
#endif

#if Original
        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
#endif
#if SearchGenreAndString
        #region snippet_SearchGenre
        public async Task OnGetAsync()
        {
            #region snippet_LINQ
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            #endregion

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            #region snippet_SelectList
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            #endregion
            Movie = await movies.ToListAsync();
        }
        #endregion
#endif
    }
}
