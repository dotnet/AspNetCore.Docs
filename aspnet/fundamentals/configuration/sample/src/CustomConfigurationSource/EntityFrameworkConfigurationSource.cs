using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Framework.Configuration;

namespace CustomConfigurationSource
{
    public class EntityFrameworkConfigurationSource : ConfigurationSource
    {
        public EntityFrameworkConfigurationSource(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        Action<DbContextOptionsBuilder> OptionsAction { get; }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ConfigurationContext>();
            OptionsAction(builder);

            using (var dbContext = new ConfigurationContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();
                Data = !dbContext.Values.Any()
                    ? CreateAndSaveDefaultValues(dbContext)
                    : dbContext.Values.ToDictionary(c => c.Id, c => c.Value);
            }
        }

        private IDictionary<string, string> CreateAndSaveDefaultValues(ConfigurationContext dbContext)
        {
            var configValues = new Dictionary<string, string>
            {
                { "key1", "value_from_ef_1" },
                { "key2", "value_from_ef_2" }
            };
            dbContext.Values.AddRange(configValues
                .Select(kvp => new ConfigurationValue() { Id = kvp.Key, Value = kvp.Value })
                .ToArray());
            dbContext.SaveChanges();
            return configValues;
        }
    }

    public static class EntityFrameworkExtensions
    {
        public static IConfigurationBuilder AddEntityFramework(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
        {
            return builder.Add(new EntityFrameworkConfigurationSource(setup));
        }
    }
}
