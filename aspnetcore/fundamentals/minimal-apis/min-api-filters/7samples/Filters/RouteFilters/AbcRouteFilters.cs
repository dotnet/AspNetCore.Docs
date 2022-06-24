
namespace Filters.RouteFilters;

public abstract class ABCrouteFilters : IRouteHandlerFilter
{
    protected readonly ILogger Logger;
    private readonly string? _methodName;

    protected ABCrouteFilters(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger<ABCrouteFilters>();
        _methodName = GetType().FullName;
    }

    public virtual async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context,
        RouteHandlerFilterDelegate next)
    {
        Logger.LogInformation("{MethodName} Before next", _methodName);
        var result = await next(context);
        Logger.LogInformation("{MethodName} After next", _methodName);
        return result;
    }
}

class ArouteFilter : ABCrouteFilters
{
    public ArouteFilter(ILoggerFactory loggerFactory) : base(loggerFactory) { }
}

class BrouteFilter : ABCrouteFilters
{
    public BrouteFilter(ILoggerFactory loggerFactory) : base(loggerFactory) { }
}

class CrouteFilter : ABCrouteFilters
{
    public CrouteFilter(ILoggerFactory loggerFactory) : base(loggerFactory) { }
}
