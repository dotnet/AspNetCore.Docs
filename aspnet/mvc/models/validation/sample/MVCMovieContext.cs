using System.Collections.Generic;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    public class MVCMovieContext
    {
        public IList<Movie> Movies { get; } = new List<Movie>();

        public void AddMovie(Movie movie)
        {
            movie.Id = Movies.Count;
            Movies.Add(movie);
        }

        public void SaveChanges()
        {
            // No-op. In real world, this would save to a backing store e.g. SQL Server.
        }
    }
}