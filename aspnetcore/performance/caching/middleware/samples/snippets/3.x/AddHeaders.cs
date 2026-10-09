// using Microsoft.AspNetCore.Http;

app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl = 
        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
        {
            Public = true,
            MaxAge = TimeSpan.FromSeconds(10)
        };
    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = 
        new string[] { "Accept-Encoding" };

    await next();
});
