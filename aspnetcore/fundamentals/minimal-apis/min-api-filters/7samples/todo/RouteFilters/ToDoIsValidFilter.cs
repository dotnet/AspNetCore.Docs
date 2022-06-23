namespace TodoApi.RouteFilters;
#region snippet
public class ToDoIsValidFilter : IRouteHandlerFilter
{
    private ILogger _logger;

    public ToDoIsValidFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ToDoIsValidFilter>();
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext rhiContext,
                                                RouteHandlerFilterDelegate next)
    {
        var todo = rhiContext.GetArgument<Todo>(0);

        var validationError = Utilities.IsValid(todo!);

        if (!String.IsNullOrEmpty(validationError))
        {
            _logger.LogWarning(validationError);
            return Results.Problem(validationError);
        }
        return await next(rhiContext);
    }
}
#endregion
#region snippet
public class ToDoIsValidUcFilter : IRouteHandlerFilter
{
    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext rhiContext,
                                                RouteHandlerFilterDelegate next)
    {
        var todo = rhiContext.GetArgument<Todo>(0);
        todo.Name = todo.Name!.ToUpper();

        var validationError = Utilities.IsValid(todo!);

        if (!String.IsNullOrEmpty(validationError))
        {
            return Results.Problem(validationError);
        }
        return await next(rhiContext);
    }
}
#endregion
