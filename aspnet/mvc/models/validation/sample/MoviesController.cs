using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    public class MoviesControllerx : Controller
    {
        private MVCMovieContext _context;

        public MoviesControllerx(MVCMovieContext context)
        {
            _context = context;    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (movie.Genre == Genre.Family)                    
            {
                if (movie.Audience != Audience.Everyone)
                {
                    ModelState.AddModelError("GenreAudienceMismatch", 
                        "'Family' movies must be rated for an audience of 'Everyone'. " + 
                        "Are you sure you have the correct genre or audience?");
                }
            }                          

            if (ModelState.IsValid)
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}
