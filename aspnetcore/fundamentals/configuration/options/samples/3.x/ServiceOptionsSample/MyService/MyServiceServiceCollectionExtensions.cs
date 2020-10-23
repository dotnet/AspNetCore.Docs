using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ServiceOptionsSample;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyServiceServiceCollectionExtensions
    {
        public static void AddMyService(this IServiceCollection services)
        {
            services.TryAddSingleton<IMyService, MyService>();
        }

        public static void AddMyService(this IServiceCollection services, Action<MyServiceOptions> setupAction)
        {
            services.AddMyService();
            services.Configure(setupAction);
        }
    }
}
