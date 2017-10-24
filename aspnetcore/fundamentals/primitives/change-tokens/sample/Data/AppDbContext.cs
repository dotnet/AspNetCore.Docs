using Microsoft.EntityFrameworkCore;

namespace ChangeTokenSample.Data
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
