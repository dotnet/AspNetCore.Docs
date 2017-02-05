using Microsoft.AspNetCore.Builder;

namespace MiddlewareSample
{
    #region snippet1
    public static class RequestLoggerExtensions
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
    #endregion
}
