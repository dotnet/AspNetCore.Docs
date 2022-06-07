using Microsoft.AspNetCore.Mvc.Filters;

namespace SampleApp.Filters
{
    public class EmptyFilter : IActionFilter
    {
        public EmptyFilter()
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
