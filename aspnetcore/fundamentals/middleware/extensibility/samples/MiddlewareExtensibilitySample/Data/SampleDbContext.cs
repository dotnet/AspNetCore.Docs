using Microsoft.EntityFrameworkCore;

namespace MiddlewareExtensibilitySample.Data;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> dbContextOptions)
        : base(dbContextOptions) { }

    public DbSet<Request> Requests { get; set; } = null!;
}
