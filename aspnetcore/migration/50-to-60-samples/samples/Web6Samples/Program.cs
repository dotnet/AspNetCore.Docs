#define LOGG // MID RT ROOT CONF LOGG
#if MID
#region snippet_mid
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.Run();
#endregion
#elif RT
#region snippet_rt
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif ROOT
#region snippet_root
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    EnvironmentName = Environments.Staging
});

Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");

var app = builder.Build();
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
#elif CONF
#region snippet_conf
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddIniFile("appsettings.ini");

var app = builder.Build();
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
#elif LOGG
#region snippet_log
var builder = WebApplication.CreateBuilder(args);

// Configure JSON logging to the console.
builder.Logging.AddJsonConsole();

var app = builder.Build();
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
#endif
