using Microsoft.Data.Entity;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<BrainstormSession> BrainstormSessions { get; set; }
    }
}