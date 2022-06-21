#define SECOND // FIRST SECOND
#if NEVER
#elif FIRST
#region snippet1
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

string ColorName(string color) => $"Hello, {color}!";

app.MapGet("/colorSelector/{color}", ColorName)
    .AddFilter(async (routeHandlerInvocationContext, next) =>
    {
        var color = (string)routeHandlerInvocationContext.Arguments[0]!;
        if (color == "Red")
        {
            return Results.Problem("Red not allowed!");
        }
        return await next(routeHandlerInvocationContext);
    });

app.Run();
#endregion
#elif SECOND
#region snippet1
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

string? PrintLogger(HttpContext context) => $"Logger Error IsEnabled:" +
    $"                                 {context.Items["loggerErrorIsEnabled"]}";
app.MapGet("/print-logger", PrintLogger).AddFilter<ServiceAccessingRouteHandlerFilter>();

app.Run();

class ServiceAccessingRouteHandlerFilter : IRouteHandlerFilter
{
    private ILogger _logger;

    public ServiceAccessingRouteHandlerFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ServiceAccessingRouteHandlerFilter>();
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        context.HttpContext.Items["loggerErrorIsEnabled"] = _logger.IsEnabled(LogLevel.Error);
        return await next(context);
    }
}
#endregion
#endif

