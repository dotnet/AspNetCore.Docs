using System.Web;
using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSystemWebAdapters()
    .AddHttpApplication<MyApp>(options =>
    {
        // Size of pool for HttpApplication instances. Should be what the expected concurrent requests will be
        options.PoolSize = 10;

        // Register a module (optionally) by name
        options.RegisterModule<MyModule>("MyModule");
    });

// Only available in .NET 7+
builder.Services.AddOutputCache(options =>
{
    options.AddHttpApplicationBasePolicy(_ => new[] { "browser" });
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthenticationEvents();

app.UseAuthorization();
app.UseAuthorizationEvents();

app.UseSystemWebAdapters();
app.UseOutputCache();

app.MapGet("/", () => "Hello World!")
    .CacheOutput();

app.Run();

class MyApp : HttpApplication
{
    protected void Application_Start()
    {
    }

    public override string? GetVaryByCustomString(System.Web.HttpContext context, string custom)
    {
        // Any custom vary-by string needed

        return base.GetVaryByCustomString(context, custom);
    }
}

class MyModule : IHttpModule
{
    public void Init(HttpApplication application)
    {
        application.BeginRequest += (s, e) =>
        {
            // Handle events at the beginning of a request
        };

        application.AuthorizeRequest += (s, e) =>
        {
            // Handle events that need to be authorized
        };
    }

    public void Dispose()
    {
    }
}
