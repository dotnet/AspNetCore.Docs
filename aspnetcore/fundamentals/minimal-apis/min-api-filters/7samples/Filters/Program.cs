#define XYZ // FIRST SECOND ABC XYZ
#if NEVER
#elif FIRST
#region snippet1
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

string ColorName(string color) => $"Color specified: {color}!";

app.MapGet("/colorSelector/{color}", ColorName)
    .AddFilter(async (rhiContext, next) =>
    {
        var color = rhiContext.GetArgument<string>(0);

        if (color == "Red")
        {
            return Results.Problem("Red not allowed!");
        }
        return await next(rhiContext);
    });

app.Run();
#endregion
#elif SECOND
#region snippet2
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

static string? PrintLogger(HttpContext context) => $"Logger Error IsEnabled:" +
                                            $"{context.Items["loggerErrorIsEnabled"]}";

app.MapGet("/print-logger", PrintLogger).AddFilter<ServiceAccessingRouteHandlerFilter>();

app.Run();

class ServiceAccessingRouteHandlerFilter : IRouteHandlerFilter
{
    private ILogger _logger;

    public ServiceAccessingRouteHandlerFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ServiceAccessingRouteHandlerFilter>();
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext rhiContext, RouteHandlerFilterDelegate next)
    {
        rhiContext.HttpContext.Items["loggerErrorIsEnabled"] = _logger.IsEnabled(LogLevel.Error);
        return await next(rhiContext);
    }
}
#endregion
#elif ABC
#region snippet_abc
using Filters.RouteFilters;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Test of multiple filters")
    .AddFilter<ArouteFilter>()
    .AddFilter<BrouteFilter>()
    .AddFilter<CrouteFilter>();

app.Run();
#endregion
#elif XYZ
#region snippet_xyz
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Test of multiple filters")
    .AddFilter(async (rhiContext, next) =>
    {
        app.Logger.LogInformation("First filter");
        return await next(rhiContext);
    })
    .AddFilter(async (rhiContext, next) =>
    {
        app.Logger.LogInformation("2nd filter");
        return await next(rhiContext);
    })
    .AddFilter(async (rhiContext, next) =>
    {
        app.Logger.LogInformation("3rd filter");
        return await next(rhiContext);
    });
app.Run();
#endregion
#endif

