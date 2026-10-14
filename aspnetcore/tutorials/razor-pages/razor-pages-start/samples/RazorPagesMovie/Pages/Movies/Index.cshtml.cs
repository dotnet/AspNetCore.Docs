//#define first
#define snippet_SearchGenre

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovie.Pages.Movies
{
    #region snippet_newProps
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public IndexModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        #endregion

#if first
        #region snippet_1stSearch
        public async Task OnGetAsync(string searchString)
        {
            var movies = from m in _context.Movie
                         select m;

            #region snippet_SearchNull
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            #endregion

            Movie = await movies.ToListAsync();
            SearchString = searchString;
        }
        #endregion
#endif

#if snippet_SearchGenre
        #region snippet_SearchGenre
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            #region snippet_LINQ
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            #endregion

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            #region snippet_SelectList
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            #endregion
            Movie = await movies.ToListAsync();
            SearchString = searchString;
        }
        #endregion
#endif
    }
}
