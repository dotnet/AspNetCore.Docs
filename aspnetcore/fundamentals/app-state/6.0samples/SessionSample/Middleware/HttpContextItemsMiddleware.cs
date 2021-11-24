namespace SessionSample.Middleware
{
    #region snippet1
    public class HttpContextItemsMiddleware
    {
        private readonly RequestDelegate _next;
        public static readonly object HttpContextItemsMiddlewareKey = new();

        public HttpContextItemsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items[HttpContextItemsMiddlewareKey] = "K-9";

            await _next(httpContext);
        }
    }

    public static class HttpContextItemsMiddlewareExtensions
    {
        public static IApplicationBuilder 
            UseHttpContextItemsMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HttpContextItemsMiddleware>();
        }
    }
    #endregion
}
