#define SearchGenre
//#define SearchPost
using System.Linq;
using Microsoft.AspNet.Mvc;
using MvcMovie.Models;
using System;
using System.Collections.Generic;



#if Never
namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index() {
            return View(_context.Movie.ToList());
        }

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        /*
        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        
        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        */


        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/6
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            [Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        // GET: Movies/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Movie movie = _context.Movie.Single(m => m.ID == id);
            _context.Movie.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

#if Search1

        public ActionResult Index(string searchString)
        {
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return View(movies);
        }


#endif


#if SearchID

        public ActionResult Index(string id)
        {
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(id))
            {
                movies = movies.Where(s => s.Title.Contains(id));
            }

            return View(movies);
        }


#endif


#if SearchView

        public ActionResult Index(string searchString)
        {
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return View("Index", movies);
        }



#endif


#if SearchPost


        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


#endif

#if SearchGenre

        public ActionResult Index(string movieGenre, string searchString)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return View("Index", movies);
        }



#endif

    }
}
#endif