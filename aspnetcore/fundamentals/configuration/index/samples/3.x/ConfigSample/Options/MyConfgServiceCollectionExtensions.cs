using ConfigSample.Options;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection.ConfigSample.Options
{
    public static class MyConfgServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig( this IServiceCollection services,
                                                    IConfiguration config)
        {
            services.Configure<PositionOptions>(config.GetSection(
                                    PositionOptions.Position));
            services.Configure<ColorOptions>(config.GetSection(
                                             ColorOptions.Color));
            return services;
        }
    }
}
