#define FIRST // FIRST SECOND
#if NEVER
#elif FIRST
#region snippet1
var builder = WebApplication.CreateBuilder(args);

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Program");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Test", async context =>
{
    logger.LogInformation("Testing logging in Program.cs");
    await context.Response.WriteAsync("Testing");
});

app.Run();
#endregion
#elif SECOND
#region snippet2
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Disabled);
});

var logger = loggerFactory.CreateLogger<Program>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Test", async context =>
{
    logger.LogInformation("Testing logging in Program.cs");
    await context.Response.WriteAsync("Testing");
});

app.Run();
#endregion
#endif
