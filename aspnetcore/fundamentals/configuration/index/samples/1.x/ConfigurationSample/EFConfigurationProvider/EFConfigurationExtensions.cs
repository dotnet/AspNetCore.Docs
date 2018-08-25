using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample.EFConfigurationProvider
{
    #region snippet1
    public static class EntityFrameworkExtensions
    {
        public static IConfigurationBuilder AddEFConfiguration(
            this IConfigurationBuilder builder, 
            Action<DbContextOptionsBuilder> optionsAction)
        {
            return builder.Add(new EFConfigurationSource(optionsAction));
        }
    }
    #endregion
}
