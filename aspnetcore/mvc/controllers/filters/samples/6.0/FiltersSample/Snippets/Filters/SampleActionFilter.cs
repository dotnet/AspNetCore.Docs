using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Snippets.Filters;

// <snippet_Class>
public class SampleActionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Do something before the action executes.
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Do something after the action executes.
    }
}
// </snippet_Class>
