
namespace Filters.RouteFilters;

public abstract class ABCrouteFilters : IRouteHandlerFilter
{
    public abstract ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next);
}

class ArouteFilter : IRouteHandlerFilter
{
    public ILogger _logger;
    public string? _methodName;

    public ArouteFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ABCrouteFilters>();
        _methodName = this.GetType().FullName;

    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        _logger.LogInformation(_methodName);
        return await next(context);
    }

}

class BrouteFilter : IRouteHandlerFilter
{
    public ILogger _logger;
    public string? _methodName;

    public BrouteFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ABCrouteFilters>();
        _methodName = this.GetType().FullName;
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        _logger.LogInformation(_methodName);
        return await next(context);
    }
}

class CrouteFilter : IRouteHandlerFilter
{
    public ILogger _logger;
    public string? _methodName;

    public CrouteFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ABCrouteFilters>();
        _methodName = this.GetType().FullName;
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext context, RouteHandlerFilterDelegate next)
    {
        _logger.LogInformation(_methodName);
        return await next(context);
    }
}
