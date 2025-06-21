using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace MyApp.Middleware
{
    #region snippet_Options
    public class MyMiddlewareOptions
    {
        public string Param1 { get; set; }
        public string Param2 { get; set; }
    }
    #endregion

    #region snippet_MiddlewareWithParams
    public class MyMiddlewareWithParams
    {
        private readonly RequestDelegate _next;
        private readonly MyMiddlewareOptions _myMiddlewareOptions;

        public MyMiddlewareWithParams(RequestDelegate next,
            IOptions<MyMiddlewareOptions> optionsAccessor)
        {
            _next = next;
            _myMiddlewareOptions = optionsAccessor.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something with context near the beginning of request processing
            // using configuration in _myMiddlewareOptions

            await _next.Invoke(context);

            // Do something with context near the end of request processing
            // using configuration in _myMiddlewareOptions
        }
    }
    #endregion

    #region snippet_Extensions
    public static class MyMiddlewareWithParamsExtensions
    {
        public static IApplicationBuilder UseMyMiddlewareWithParams(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddlewareWithParams>();
        }

        public static IApplicationBuilder UseMyMiddlewareWithParams(
            this IApplicationBuilder builder, MyMiddlewareOptions myMiddlewareOptions)
        {
            return builder.UseMiddleware<MyMiddlewareWithParams>(
                new OptionsWrapper<MyMiddlewareOptions>(myMiddlewareOptions));
        }
    }
    #endregion
}
