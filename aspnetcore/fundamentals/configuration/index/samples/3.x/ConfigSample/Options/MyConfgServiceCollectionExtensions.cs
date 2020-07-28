using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigSample.Options
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
