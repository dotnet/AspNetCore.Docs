using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HostingStartupSample
{
    #region snippet1
    public class RequestSetOptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private IOptions<InjectedOptions> _injectedOptions;

        public RequestSetOptionsMiddleware(
            RequestDelegate next, IOptions<InjectedOptions> injectedOptions)
        {
            _next = next;
            _injectedOptions = injectedOptions;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("RequestSetOptionsMiddleware.Invoke");

            var option1 = httpContext.Request.Query["option1"];

            if (!string.IsNullOrWhiteSpace(option1))
            {
                _injectedOptions.Value.Option1 = WebUtility.HtmlEncode(option1);
            }

            await _next(httpContext);
        }
    }
    #endregion
}
