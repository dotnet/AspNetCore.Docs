using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Controllers;

// <snippet_Class>
[SampleActionFilter]
public class ControllerFiltersController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine(
            $"- {nameof(ControllerFiltersController)}.{nameof(OnActionExecuting)}");

        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine(
            $"- {nameof(ControllerFiltersController)}.{nameof(OnActionExecuted)}");

        base.OnActionExecuted(context);
    }

    public IActionResult Index()
    {
        Console.WriteLine(
            $"- {nameof(ControllerFiltersController)}.{nameof(Index)}");

        return Content("Check the Console.");
    }
}
// </snippet_Class>