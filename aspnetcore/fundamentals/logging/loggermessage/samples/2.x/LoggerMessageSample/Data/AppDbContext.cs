using Microsoft.EntityFrameworkCore;

namespace LoggerMessageSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
