#define FIRST // FIRST SECOND ABC XYZ
#if NEVER
#elif FIRST
#region snippet1
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

string ColorName(string color) => $"Color specified: {color}!";

app.MapGet("/colorSelector/{color}", ColorName)
    .AddFilter(async (invocationContext, next) =>
    {
        var color = invocationContext.GetArgument<string>(0);

        if (color == "Red")
        {
            return Results.Problem("Red not allowed!");
        }
        return await next(invocationContext);
    });

app.Run();
#endregion
#elif SECOND
#region snippet2
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

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

app.MapGet("/", () =>
    {
        app.Logger.LogInformation("Endpoint");
        return "Test of multiple filters";
    })
    .AddFilter<ArouteFilter>()
    .AddFilter<BrouteFilter>()
    .AddFilter<CrouteFilter>();

app.Run();
#endregion
#elif XYZ
#region snippet_xyz
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () =>
    {
        app.Logger.LogInformation("             Endpoint");
        return "Test of multiple filters";
    })
    .AddFilter(async (rhiContext, next) =>
    {
        app.Logger.LogInformation("Before first filter");
        var result = await next(rhiContext);
        app.Logger.LogInformation("After first filter");
        return result;
    })
    .AddFilter(async (rhiContext, next) =>
    {
        app.Logger.LogInformation(" Before 2nd filter");
        var result = await next(rhiContext);
        app.Logger.LogInformation(" After 2nd filter");
        return result;
    })
    .AddFilter(async (rhiContext, next) =>
    {
        app.Logger.LogInformation("     Before 3rd filter");
        var result = await next(rhiContext);
        app.Logger.LogInformation("     After 3rd filter");
        return result;
    });

app.Run();
#endregion
#endif

