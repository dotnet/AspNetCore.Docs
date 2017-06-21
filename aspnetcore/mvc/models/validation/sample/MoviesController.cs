using System;
using Microsoft.AspNetCore.Mvc;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MVCMovieContext _context;

        public MoviesController(MVCMovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            string title,
            Genre genre,
            DateTime releaseDate,
            string description,
            decimal price,
            bool preorder)
        {
            var modifiedReleaseDate = releaseDate;
            if (releaseDate == null)
            {
                modifiedReleaseDate = DateTime.Today;
            }

            var movie = new Movie
            {
                Title = title,
                Genre = genre,
                ReleaseDate = modifiedReleaseDate,
                Description = description,
                Price = price,
                Preorder = preorder,
            };

            TryValidateModel(movie);
            if (ModelState.IsValid)
            {
                _context.AddMovie(movie);
                _context.SaveChanges();

                return RedirectToAction(actionName: nameof(Index));
            }

            return View(movie);
        }
    }
}
