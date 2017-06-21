using Microsoft.EntityFrameworkCore;

namespace CustomConfigurationProvider
{
    #region snippet1
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ConfigurationValue> Values { get; set; }
    }
    #endregion
}
