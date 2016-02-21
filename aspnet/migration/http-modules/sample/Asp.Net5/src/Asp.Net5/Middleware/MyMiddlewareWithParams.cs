using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.OptionsModel;
using System.Threading.Tasks;

namespace MyApp.Middleware
{
    public class MyMiddlewareOptions
    {
        public string Param1 { get; set; }
        public string Param2 { get; set; }
    }

    // Remove this when Microsoft.Extensions.Options becomes available from NuGet
    public class OptionsWrapper<TOptions> : IOptions<TOptions> where TOptions : class, new()
    {
        public OptionsWrapper(TOptions options)
        {
            Value = options;
        }

        public TOptions Value { get; }
    }

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
}
