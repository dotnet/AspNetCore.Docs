using Microsoft.EntityFrameworkCore;
using ValidationSample.Models;

namespace ValidationSample.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
