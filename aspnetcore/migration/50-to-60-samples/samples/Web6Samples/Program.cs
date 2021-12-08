#define TEST // MID RT ROOT CONF LOGG SVC HB WHB WR AF TEST 
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
    EnvironmentName = Environments.Staging,
    WebRootPath = "customwwwroot"
});

Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");

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
#elif SVC
#region snippet_svc
var builder = WebApplication.CreateBuilder(args);

// Add the memory cache services.
builder.Services.AddMemoryCache();

// Add a custom scoped service.
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
var app = builder.Build();
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
#elif HB
#region snippet_hb
var builder = WebApplication.CreateBuilder(args);

// Wait 30 seconds for graceful shutdown.
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));

var app = builder.Build();
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
#elif WHB
#region snippet_whb
var builder = WebApplication.CreateBuilder(args);

// Change the HTTP server implementation to be HTTP.sys based.
// Windows only.
builder.WebHost.UseHttpSys();

var app = builder.Build();
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
#elif WR
#region snippet_wr
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Look for static files in webroot
    WebRootPath = "webroot"
});

var app = builder.Build();
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
#elif AF
#region snippet_af
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IService, Service>();

var app = builder.Build();

IService service = app.Services.GetRequiredService<IService>();
ILogger logger = app.Logger;
IHostApplicationLifetime lifetime = app.Lifetime;
IWebHostEnvironment env = app.Environment;

lifetime.ApplicationStarted.Register(() =>
    logger.LogInformation(
        $"The application {env.ApplicationName} started" +
        $" with injected {service}"));
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
#elif TEST
#region snippet_test

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IHelloService, HelloService>();

var app = builder.Build();

var helloService = app.Services.GetRequiredService<IHelloService>();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(helloService.HelloMessage);
});

app.Run();
#endregion
#endif
