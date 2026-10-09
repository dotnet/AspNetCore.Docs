
namespace Filters.EndpointFilters;

public abstract class ABCEndpointFilters : IEndpointFilter
{
    protected readonly ILogger Logger;
    private readonly string _methodName;

    protected ABCEndpointFilters(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger<ABCEndpointFilters>();
        _methodName = GetType().Name;
    }

    public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        Logger.LogInformation("{MethodName} Before next", _methodName);
        var result = await next(context);
        Logger.LogInformation("{MethodName} After next", _methodName);
        return result;
    }
}

class AEndpointFilter : ABCEndpointFilters
{
    public AEndpointFilter(ILoggerFactory loggerFactory) : base(loggerFactory) { }
}

class BEndpointFilter : ABCEndpointFilters
{
    public BEndpointFilter(ILoggerFactory loggerFactory) : base(loggerFactory) { }
}

class CEndpointFilter : ABCEndpointFilters
{
    public CEndpointFilter(ILoggerFactory loggerFactory) : base(loggerFactory) { }
}
