using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataProtectionConfigurationSample.Snippets;

public class SampleDbContext : DbContext, IDataProtectionKeyContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> dbContextOptions)
        : base(dbContextOptions) { }

    // <snippet_DataProtectionKeys>
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;
    // </snippet_DataProtectionKeys>
}
