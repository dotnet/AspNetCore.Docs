namespace TodoApi.RouteFilters;
#region snippet
public class ToDoIsValidFilter : IRouteHandlerFilter
{
    private ILogger _logger;

    public ToDoIsValidFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ToDoIsValidFilter>();
    }

    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext rhiContextontext,
                                                RouteHandlerFilterDelegate next)
    {
        var tdparam0 = rhiContextontext.Arguments[0]!;
        Todo todo = (Todo)tdparam0;


        var validationError = Utilities.IsValid(todo!);

        if (!String.IsNullOrEmpty(validationError))
        {
            _logger.LogWarning(validationError);
            return Results.Problem(validationError);
        }
        return await next(rhiContextontext);
    }
}
#endregion
