using System.Reflection;
using System.Threading.Tasks;
using FiltersSample.Filters;
using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Controllers
{
public class Test3Controller : Controller
{
    [SampleActionFilter(Order = int.MinValue)]
    public IActionResult FilterTest2()
    {
        var m = MethodBase.GetCurrentMethod();
        MyDebug.Write(m, HttpContext.Request.Path);
        return Content(m.ReflectedType.Name + "." + m.Name);
    }

    public override Task OnActionExecutionAsync(ActionExecutingContext context, 
                                                ActionExecutionDelegate next)
    {
        MyDebug.Write(MethodBase.GetCurrentMethod(), HttpContext.Request.Path);
        return base.OnActionExecutionAsync(context, next);
    }

}
}