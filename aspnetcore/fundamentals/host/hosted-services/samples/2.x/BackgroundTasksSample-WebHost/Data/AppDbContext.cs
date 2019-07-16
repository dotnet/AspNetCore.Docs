using Microsoft.EntityFrameworkCore;

namespace BackgroundTasksSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
