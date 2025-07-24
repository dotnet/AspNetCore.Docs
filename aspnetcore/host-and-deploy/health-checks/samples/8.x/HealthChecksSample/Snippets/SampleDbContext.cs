using Microsoft.EntityFrameworkCore;

namespace HealthChecksSample.Snippets;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> dbContextOptions)
        : base(dbContextOptions) { }
}
