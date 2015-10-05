using Microsoft.AspNet.Builder;

namespace LoggingSample
{
    public static class SimpleLoggerExtensions
    {
        public static IApplicationBuilder UseSimpleLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleLoggerMiddleware>();
        }
    }
}