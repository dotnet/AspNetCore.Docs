using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;

namespace StartupFilterSample
{
    #region snippet1
    public class RequestSetOptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private IOptions<AppOptions> _injectedOptions;

        public RequestSetOptionsMiddleware(
            RequestDelegate next, IOptions<AppOptions> injectedOptions)
        {
            _next = next;
            _injectedOptions = injectedOptions;
        }

        // Test with https://localhost:5001/?option=hello
        public async Task Invoke(HttpContext httpContext)
        {
            var option = httpContext.Request.Query["option"];

            if (!string.IsNullOrWhiteSpace(option))
            {
                _injectedOptions.Value.Option = WebUtility.HtmlEncode(option);
            }

            await _next(httpContext);
        }
    }
    #endregion

    public class AppOptions
    {
        public string Option { get;  set; }
    }
}
