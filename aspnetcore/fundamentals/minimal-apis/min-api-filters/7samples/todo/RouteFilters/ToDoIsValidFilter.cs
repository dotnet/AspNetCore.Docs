namespace TodoApi.RouteFilters;
#region snippet
public class TodoIsValidFilter : IRouteHandlerFilter
{
    private ILogger _logger;

    public TodoIsValidFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<TodoIsValidFilter>();
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext rhiContext,
                                                RouteHandlerFilterDelegate next)
    {
        var todo = rhiContext.GetArgument<Todo>(0);

        var validationError = Utilities.IsValid(todo!);

        if (!string.IsNullOrEmpty(validationError))
        {
            _logger.LogWarning(validationError);
            return Results.Problem(validationError);
        }
        return await next(rhiContext);
    }
}
#endregion
#region snippet2
public class TodoIsValidUcFilter : IRouteHandlerFilter
{
    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext rhiContext,
                                                RouteHandlerFilterDelegate next)
    {
        var todo = rhiContext.GetArgument<Todo>(0);
        todo.Name = todo.Name!.ToUpper();

        var validationError = Utilities.IsValid(todo!);

        if (!string.IsNullOrEmpty(validationError))
        {
            return Results.Problem(validationError);
        }
        return await next(rhiContext);
    }
}
#endregion
