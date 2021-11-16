using Microsoft.AspNetCore.Mvc.Filters;

// <snippet_Class>
namespace FiltersSample.Snippets.Filters
{
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
}
// </snippet_Class>