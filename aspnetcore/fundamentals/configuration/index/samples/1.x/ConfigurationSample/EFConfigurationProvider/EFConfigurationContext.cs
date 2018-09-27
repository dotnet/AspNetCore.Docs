using Microsoft.EntityFrameworkCore;
using ConfigurationSample.Models;

namespace ConfigurationSample.EFConfigurationProvider
{
    #region snippet1
    public class EFConfigurationContext : DbContext
    {
        public EFConfigurationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EFConfigurationValue> Values { get; set; }
    }
    #endregion
}
