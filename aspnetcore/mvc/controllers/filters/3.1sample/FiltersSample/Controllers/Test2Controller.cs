using FiltersSample.Filters;
using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace FiltersSample.Controllers
{
    #region snippet
    [TestActionFilter]
public class Test2Controller : Controller
{
    [SampleActionFilter(Order = int.MinValue)]
    public IActionResult FilterTest3()
    {
            var m = MethodBase.GetCurrentMethod();
            MyDebug.Write(m, HttpContext.Request.Path);
            return Content(m.ReflectedType.Name + "." + m.Name);
        }
}
    #endregion
}