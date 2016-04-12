using System.Net.Http;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCMovie.Models;
using System.Net;
using System.Web.Http;
using System;

namespace MVCMovie.Controllers
{
    public class MoviesController : Controller
    {
        private MVCMovieContext _context;
        public MoviesController(MVCMovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            string title, DateTime releaseDate, 
            string description, bool preorder)
        {
            DateTime modifiedReleaseDate = releaseDate;
            if (releaseDate == null) {
                modifiedReleaseDate = DateTime.Today;
            }

            var movie = new Movie
            {
                Title = title,
                ReleaseDate = modifiedReleaseDate,
                Description = description,
                Preorder = preorder
            };
                               
            TryValidateModel(movie);

            if (ModelState.IsValid)
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();           
                return RedirectToAction("Index","Home");    
            }
            else
            {
                return HttpBadRequest(ModelState);
            }            
        }
    }
}
