using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    public class SampleGlobalActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.DisplayName == "FiltersSample.Controllers.HomeController.Hello")
            {
                // Manipulating action arguments...
                if (!context.ActionArguments.ContainsKey("name"))
                {
                    context.ActionArguments["name"] = "Steve";
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ActionDescriptor.DisplayName == "FiltersSample.Controllers.HomeController.Hello")
            {
                // Manipulating action result...
                context.Result = Helpers.GetContentResult(context.Result, "FIRST: ");
            }
        }
    }
}