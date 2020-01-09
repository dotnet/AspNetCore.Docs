using Microsoft.EntityFrameworkCore;

namespace CustomModelBindingSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
    }
}
