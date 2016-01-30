using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace CustomConfigurationProvider
{
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ConfigurationValue> Values { get; set; }

    }
}
