using Microsoft.Data.Entity;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<BrainStormSession> BrainStormSessions { get; set; }
    }
}