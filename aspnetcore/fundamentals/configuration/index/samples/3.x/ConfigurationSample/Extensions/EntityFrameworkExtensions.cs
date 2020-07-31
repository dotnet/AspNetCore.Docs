using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ConfigurationSample.EFConfigurationProvider;

namespace ConfigurationSample.Extensions
{
    #region snippet1
    // using Microsoft.EntityFrameworkCore;
    // using Microsoft.Extensions.Configuration;

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
