namespace TodoApi.RouteFilters;
#region snippet
public class ToDoIsValidFilter : IRouteHandlerFilter
{
    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext rhiContext,
                                                RouteHandlerFilterDelegate next)
    {
        Todo? todo = null;
        var tdparam0 = rhiContext.Arguments[0]!;

        if (tdparam0.GetType() == typeof(Todo))
        {
            todo = (Todo)tdparam0;
        }

        var tdparam = rhiContext.Arguments[1]!;

        if (tdparam.GetType() == typeof(Todo))
        {
             todo = (Todo)tdparam;
        }

        var validationError = Utilities.IsValid(todo!);

        if (!String.IsNullOrEmpty(validationError))
        {
            return Results.Problem(validationError);
        }
        return await next(rhiContext);
    }
}
#endregion
