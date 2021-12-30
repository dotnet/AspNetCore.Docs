#define FIRST // FIRST SECOND
#if NEVER
#elif FIRST
#region snippet1
#region snippet2
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCaching();

var app = builder.Build();

app.UseHttpsRedirection();

// UseCors must be called before UseResponseCaching
//app.UseCors();

app.UseResponseCaching();
#endregion

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

app.MapGet("/", () => DateTime.Now.Millisecond);

app.Run();
#endregion
#endif