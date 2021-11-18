using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters;

// <snippet_Class>
public class SampleAsyncActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Do something before the action executes.
        await next();
        // Do something after the action executes.
    }
}
// </snippet_Class>
