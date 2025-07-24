using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters;

public class GlobalSampleActionFilter : IActionFilter
{

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine(
            $"- {nameof(GlobalSampleActionFilter)}.{nameof(OnActionExecuting)}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine(
            $"- {nameof(GlobalSampleActionFilter)}.{nameof(OnActionExecuted)}");
    }
}
