using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;

namespace MyApp.Middleware
{
    public class HttpContextDemoMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpContextDemoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // OnStarting handlers have to be set early during request processing,
            // even though they are used to create the response.

            // ----------------------
            // ASP.NET 4 - HttpContext.Response.Headers  
            // ASP.NET 4 - HttpContext.Response.Cookies  
            // 
            // Issue with all response headers is that they will not be sent 
            // after anything has been written to the response body.
            // To solve this, use OnStarting to set a callback that will be called 
            // right before headers are sent. Set the headers in that callback.
            //
            // Setting a cookie results in a Set-Cookie response header.
            // So use an OnStarting handler here as well.

            //>40
            httpContext.Response.OnStarting(SetHeaders, state: httpContext);
            httpContext.Response.OnStarting(SetCookies, state: httpContext);
            //<40

            // ==================================================================
            // Context

            // Unique request ID (no ASP.NET 4 counterpart)
            #region snippet_Trace
            string requestId = httpContext.TraceIdentifier;
            #endregion

            // ASP.NET 4 - HttpContext.Items
            #region snippet_Items
            IDictionary<object, object> items = httpContext.Items;
            #endregion

            // ==================================================================
            // Request

            // ASP.NET 4 - HttpContext.Request.HttpMethod
            #region snippet_Method
            string httpMethod = httpContext.Request.Method;
            #endregion

            // ----------

            // ASP.NET 4 - HttpContext.Request.QueryString
            #region snippet_Query
            IQueryCollection queryParameters = httpContext.Request.Query;

            // If no query parameter "key" used, values will have 0 items
            // If single value used for a key (...?key=v1), values will have 1 item ("v1")
            // If key has multiple values (...?key=v1&key=v2), values will have 2 items ("v1" and "v2")
            IList<string> values = queryParameters["key"];

            // If no query parameter "key" used, value will be ""
            // If single value used for a key (...?key=v1), value will be "v1"
            // If key has multiple values (...?key=v1&key=v2), value will be "v1,v2"
            string value = queryParameters["key"].ToString();
            #endregion

            // ASP.NET 4 - HttpContext.Request.Url and HttpContext.Request.RawUrl
            #region snippet_Url
            // using Microsoft.AspNetCore.Http.Extensions;
            var url = httpContext.Request.GetDisplayUrl();
            #endregion

            // ASP.NET 4 - HttpContext.Request.IsSecureConnection
            #region snippet_Secure
            var isSecureConnection = httpContext.Request.IsHttps;
            #endregion

            // ASP.NET 4 - HttpContext.Request.UserHostAddress
            #region snippet_Host
            var userHostAddress = httpContext.Connection.RemoteIpAddress?.ToString();
            #endregion

            // ASP.NET 4 - HttpContext.Request.Cookies 
            #region snippet_Cookies
            IRequestCookieCollection cookies = httpContext.Request.Cookies;
            string unknownCookieValue = cookies["unknownCookie"]; // will be null (no exception)
            string knownCookieValue = cookies["cookie1name"];     // will be actual value
            #endregion

            // ASP.NET 4 - HttpContext.Request.RequestContext.RouteData
            // using Microsoft.AspNetCore.Routing;
            #region snippet_Route
            var routeValue = httpContext.GetRouteValue("key");
            #endregion

            // ASP.NET 4 - HttpContext.Request.Headers
            #region snippet_Headers
            // using Microsoft.AspNetCore.Http.Headers;
            // using Microsoft.Net.Http.Headers;

            IHeaderDictionary headersDictionary = httpContext.Request.Headers;

            // GetTypedHeaders extension method provides strongly typed access to many headers
            var requestHeaders = httpContext.Request.GetTypedHeaders();
            CacheControlHeaderValue cacheControlHeaderValue = requestHeaders.CacheControl;

            // For unknown header, unknownheaderValues has zero items and unknownheaderValue is ""
            IList<string> unknownheaderValues = headersDictionary["unknownheader"];
            string unknownheaderValue = headersDictionary["unknownheader"].ToString();

            // For known header, knownheaderValues has 1 item and knownheaderValue is the value
            IList<string> knownheaderValues = headersDictionary[HeaderNames.AcceptLanguage];
            string knownheaderValue = headersDictionary[HeaderNames.AcceptLanguage].ToString();
            #endregion

            // ASP.NET 4 - HttpContext.Request.UserAgent
            #region snippet_Agent
            string userAgent = headersDictionary[HeaderNames.UserAgent].ToString();
            #endregion

            // ASP.NET 4 - HttpContext.Request.UrlReferrer
            #region snippet_Referrer
            string urlReferrer = headersDictionary[HeaderNames.Referer].ToString();
            #endregion

            // ASP.NET 4 - HttpContext.Request.ContentType 
            #region snippet_Type
            // using Microsoft.Net.Http.Headers;

            MediaTypeHeaderValue mediaHeaderValue = requestHeaders.ContentType;
            string contentType = mediaHeaderValue?.MediaType.ToString();   // ex. application/x-www-form-urlencoded
            string contentMainType = mediaHeaderValue?.Type.ToString();    // ex. application
            string contentSubType = mediaHeaderValue?.SubType.ToString();  // ex. x-www-form-urlencoded

            System.Text.Encoding requestEncoding = mediaHeaderValue?.Encoding;
            #endregion

            // ASP.NET 4 - HttpContext.Request.Form 
            #region snippet_Form
            if (httpContext.Request.HasFormContentType)
            {
                IFormCollection form;

                form = httpContext.Request.Form; // sync
                // Or
                form = await httpContext.Request.ReadFormAsync(); // async

                string firstName = form["firstname"];
                string lastName = form["lastname"];
            }
            #endregion

            // ----------
            // See 
            // http://stackoverflow.com/questions/31389781/read-body-twice-in-asp-net-5/

            // ASP.NET 4 - HttpContext.Request.InputStream
            // Unlike reading the form, reading the raw body is not from a buffer.
            // So you can only do this once per request.
            // 
            // If you need to read the body multiple times per request, see
            // http://stackoverflow.com/questions/31389781/read-body-twice-in-asp-net-5/

            #region snippet_Input
            string inputBody;
            using (var reader = new System.IO.StreamReader(
                httpContext.Request.Body, System.Text.Encoding.UTF8))
            {
                inputBody = reader.ReadToEnd();
            }
            #endregion

            // Use this middleware as a handler, so no call to 
            // await _next.Invoke(aspnetCoreHttpContext);

            // ==================================================================
            // Response

            // ASP.NET 4 - HttpContext.Response.Status  
            // ASP.NET 4 - HttpContext.Response.StatusDescription (obsolete, removed from HTTP/2) 
            #region snippet_Status
            // using Microsoft.AspNetCore.Http;
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            #endregion

            // ASP.NET 4 - HttpContext.Response.ContentEncoding and HttpContext.Response.ContentType  
            #region snippet_RespType
            // using Microsoft.Net.Http.Headers;
            var mediaType = new MediaTypeHeaderValue("application/json");
            mediaType.Encoding = System.Text.Encoding.UTF8;
            httpContext.Response.ContentType = mediaType.ToString();
            #endregion

            // ASP.NET 4 - HttpContext.Response.ContentType only 
            #region snippet_RespTypeOnly
            httpContext.Response.ContentType = "text/html";
            #endregion

            // ASP.NET 4 - HttpContext.Response.Output  
            #region  snippet_Output
            string responseContent = GetResponseContent();
            await httpContext.Response.WriteAsync(responseContent);
            #endregion
        }

        #region snippet_SetHeaders
        // using Microsoft.AspNet.Http.Headers;
        // using Microsoft.Net.Http.Headers;

        private Task SetHeaders(object context)
        {
            var httpContext = (HttpContext)context;

            // Set header with single value
            httpContext.Response.Headers["ResponseHeaderName"] = "headerValue";

            // Set header with multiple values
            string[] responseHeaderValues = new string[] { "headerValue1", "headerValue1" };
            httpContext.Response.Headers["ResponseHeaderName"] = responseHeaderValues;

            // Translating ASP.NET 4's HttpContext.Response.RedirectLocation  
            httpContext.Response.Headers[HeaderNames.Location] = "http://www.example.com";
            // Or
            httpContext.Response.Redirect("http://www.example.com");

            // GetTypedHeaders extension method provides strongly typed access to many headers
            var responseHeaders = httpContext.Response.GetTypedHeaders();

            // Translating ASP.NET 4's HttpContext.Response.CacheControl 
            responseHeaders.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = new System.TimeSpan(365, 0, 0, 0)
                // Many more properties available 
            };

            // If you use .NET Framework 4.6+, Task.CompletedTask will be a bit faster
            return Task.FromResult(0);
        }
        #endregion

        #region snippet_SetCookies
        private Task SetCookies(object context)
        {
            var httpContext = (HttpContext)context;

            IResponseCookies responseCookies = httpContext.Response.Cookies;

            responseCookies.Append("cookie1name", "cookie1value");
            responseCookies.Append("cookie2name", "cookie2value",
                new CookieOptions { Expires = System.DateTime.Now.AddDays(5), HttpOnly = true });

            // If you use .NET Framework 4.6+, Task.CompletedTask will be a bit faster
            return Task.FromResult(0); 
        }
        #endregion

        // You would normally use MVC to generate HTML like this.
        private string GetResponseContent()
        {
            return @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <title>index</title>
</head>
<body>
<form action=""form.context"" method=""post"">
    <input type=""text"" name=""firstname"">
    <input type=""text"" name=""lastname"">
    <input type=""submit"" value=""Submit"">
</form> 
</body>
</html>
";
        }
    }

    public static class HttpContextDemoMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpContextDemoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpContextDemoMiddleware>();
        }
    }
}
