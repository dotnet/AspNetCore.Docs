
using EFConfigSample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFConfigSample;
#region snippet1
public class EFConfigurationContext : DbContext
{
    public EFConfigurationContext(DbContextOptions<EFConfigurationContext> options) : base(options)
    {
    }

    public DbSet<EFConfigurationValue> Values => Set<EFConfigurationValue>();
}
#endregion
