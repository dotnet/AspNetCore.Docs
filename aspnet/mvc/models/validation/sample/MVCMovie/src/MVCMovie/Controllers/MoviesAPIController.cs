using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    [Produces("application/json")]
    [Route("api/MoviesAPI")]
    public class MoviesAPIController : Controller
    {
        private MVCMovieContext _context;

        public MoviesAPIController(MVCMovieContext context)
        {
            _context = context;
        }

        // GET: api/MoviesAPI
        [HttpGet]
        public IEnumerable<Movie> GetMovie()
        {
            return _context.Movie;
        }

        // GET: api/MoviesAPI/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Movie movie = _context.Movie.Single(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return Ok(movie);
        }

        // PUT: api/MoviesAPI/5
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/MoviesAPI
        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Movie.Add(movie);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MovieExists(movie.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/MoviesAPI/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Movie movie = _context.Movie.Single(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            _context.Movie.Remove(movie);
            _context.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Count(e => e.Id == id) > 0;
        }
    }
}