#define IndexTest
//#define SearchPost
using System.Linq;
using Microsoft.AspNet.Mvc;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IActionResult Index() {
        //    return View(_context.Movie.ToList());
        //}

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
        public IActionResult Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
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

        public IActionResult Index(string searchString)
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

        public IActionResult Index(string id)
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

        public IActionResult Index(string searchString)
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


#if SearchPost


        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


#endif

#if SearchGenre

        public IActionResult Index(string movieGenre, string searchString)
        {
            var GenreQry = from m in _context.Movie
                           orderby m.Genre
                           select m.Genre;

            var GenreList = new List<string>();
            GenreList.AddRange(GenreQry.Distinct());
            ViewData["GenreList"]= new SelectList(GenreList);

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return View(movies);  
        }



#endif


#if  IndexTest
        
        // This is never in .rst

        public IActionResult Index(string movieGenre, string searchString)
        {
            var GenreQry = from m in _context.Movie
                           orderby m.Genre
                           select m.Genre;

            var GenreList = new List<string>();
            GenreList.AddRange(GenreQry.Distinct());
            ViewData["GenreList"] = new SelectList(GenreList);

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return View("IndexGenreRating",movies);
        }



#endif

        private void testAdd()
        {
            Movie movie = new Movie();
            movie.Title = "Gone with the Wind";
            _context.Movie.Add(movie);
            _context.SaveChanges();        // <= Will throw server side validation exception 
        }

    }
}

