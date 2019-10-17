using System.Threading.Tasks;
using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Controllers
{
    #region snippet
    public class TestController : Controller
    {
        [SampleActionFilter]
        public IActionResult FilterTest2()
        {
            return Content($"From FilterTest2");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            base.OnActionExecuted(context);
        }
    }
    #endregion
}