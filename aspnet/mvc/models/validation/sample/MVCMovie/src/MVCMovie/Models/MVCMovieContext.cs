using Microsoft.Data.Entity;
using MVCMovie.Models;

namespace MVCMovie.Models
{
    public class MVCMovieContext : DbContext
    {
        private static bool _created = false;

        public MVCMovieContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<User> User { get; set; }
    }
}
