using Microsoft.AspNetCore.Mvc.Filters;

// <snippet_Class>
namespace FiltersSample.Snippets.Filters
{
    public class SampleAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Do something before the action executes.
            await next();
            // Do something after the action executes.
        }
    }
}
// </snippet_Class>
