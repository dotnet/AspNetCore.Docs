using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDotNetCore1App.Models
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetCoreDotNetCore1App.Models.Movie> Movie { get; set; }
    }
}
