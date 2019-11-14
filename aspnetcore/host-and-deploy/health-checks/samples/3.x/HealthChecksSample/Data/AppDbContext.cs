using Microsoft.EntityFrameworkCore;

namespace SampleApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
