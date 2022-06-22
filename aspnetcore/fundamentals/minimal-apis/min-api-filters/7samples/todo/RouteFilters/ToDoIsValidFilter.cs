namespace TodoApi.RouteFilters;
#region snippet
public class ToDoIsValidFilter : IRouteHandlerFilter
{
    public async ValueTask<object?> InvokeAsync(RouteHandlerInvocationContext rhiContextontext,
                                                RouteHandlerFilterDelegate next)
    {
        Todo? todo = null;
        var tdparam0 = rhiContextontext.Arguments[0]!;

        if (tdparam0.GetType() == typeof(Todo))
        {
            todo = (Todo)tdparam0;
        }

        var tdparam = rhiContextontext.Arguments[1]!;

        if (tdparam.GetType() == typeof(Todo))
        {
             todo = (Todo)tdparam;
        }

        var validationError = Utilities.IsValid(todo!);

        if (!String.IsNullOrEmpty(validationError))
        {
            return Results.Problem(validationError);
        }
        return await next(rhiContextontext);
    }
}
#endregion
