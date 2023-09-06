#define APP4 // FIRST SECOND APP3
#if NEVER
#elif FIRST
// <snippet1>
var builder = WebApplication.CreateBuilder(args);

// Configure logging with AddConsole()
builder.Logging.AddConsole();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Test", async context =>
{
    var logger = app.Logger; // Access the configured logger directly
    logger.LogInformation("Testing logging in Program.cs");
    await context.Response.WriteAsync("Testing");
});

app.Run();
// </snippet1>
#elif SECOND
// <snippet2>
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

// Configure logging with AddSimpleConsole
builder.Logging.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Disabled);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Test", async context =>
{
    var logger = app.Logger; // Access the configured logger directly
    logger.LogInformation("Testing logging in Program.cs");
    await context.Response.WriteAsync("Testing");
});

app.Run();

// </snippet2>
#elif APP3
// <snippet3>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Logger.LogInformation("Adding Routes");
app.MapGet("/", () => "Hello World!");
app.Logger.LogInformation("Starting the app");
app.Run();
// </snippet3>
#elif APP4
// <snippet4>
var builder = WebApplication.CreateBuilder(args);

var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.Configure(options =>
    {
        options.ActivityTrackingOptions = ActivityTrackingOptions.SpanId
                                            | ActivityTrackingOptions.TraceId
                                            | ActivityTrackingOptions.ParentId
                                            | ActivityTrackingOptions.Baggage
                                            | ActivityTrackingOptions.Tags;
    }).AddSimpleConsole(options =>
    {
        options.IncludeScopes = true;
    });
});
// </snippet4>
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endif
