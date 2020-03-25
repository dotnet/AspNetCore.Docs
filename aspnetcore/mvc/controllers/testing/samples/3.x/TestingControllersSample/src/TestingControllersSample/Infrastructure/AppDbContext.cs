using Microsoft.EntityFrameworkCore;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<BrainstormSession> BrainstormSessions { get; set; }
    }
}
