using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace StartupDemo
{
    public static class RequestLoggerExtensions
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
        {
            var env = builder.ApplicationServices.GetService<IHostingEnvironment>();
            var loggerFactory = builder.ApplicationServices.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(env.EnvironmentName);

            return builder.Use(next => new RequestLoggerMiddleware(next, logger).Invoke);
        }
    }
}
