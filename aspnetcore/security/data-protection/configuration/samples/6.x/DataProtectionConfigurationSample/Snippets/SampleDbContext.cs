using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataProtectionConfigurationSample.Snippets;

public class SampleDbContext : DbContext, IDataProtectionKeyContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> dbContextOptions)
        : base(dbContextOptions) { }

    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;
}
