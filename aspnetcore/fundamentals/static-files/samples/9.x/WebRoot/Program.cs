#define FIRST // FIRST
#if NEVER
#elif FIRST
// <snippet1>
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Look for static files in "wwwroot-custom"
    WebRootPath = "wwwroot-custom"
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
// </snippet1>
#elif SECOND
// <snippet2>
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Examine Hosting environment: logging value
    EnvironmentName = Environments.Staging,
    WebRootPath = "wwwroot-custom"
});

var app = builder.Build();

app.Logger.LogInformation("ASPNETCORE_ENVIRONMENT: {env}",
      Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

app.Logger.LogInformation("app.Environment.IsDevelopment(): {env}",
      app.Environment.IsDevelopment().ToString());

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
// </snippet2>
#endif
