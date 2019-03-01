using System.Collections.Generic;
using ValidationSample.Models;

namespace ValidationSample.Data
{
    public class ValidationSampleContext
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