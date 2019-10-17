using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace StartupFilterSample
{
    #region snippet1
    public class RequestSetOptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestSetOptionsMiddleware( RequestDelegate next )
        {
            _next = next;
        }

        // Test with https://localhost:5001/Privacy/?option=Hello
        public async Task Invoke(HttpContext httpContext)
        {
            var option = httpContext.Request.Query["option"];

            if (!string.IsNullOrWhiteSpace(option))
            {
                httpContext.Items["option"] = WebUtility.HtmlEncode(option);
            }

            await _next(httpContext);
        }
    }
    #endregion
}