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
        //         [SampleActionFilter(Order = int.MinValue)]
        // 
        [SampleActionFilter]
        public IActionResult FilterTest3()
        {
            var method = MethodBase.GetCurrentMethod();
            MyDebug.Write(method, HttpContext.Request.Path);

            return Content("From " + method);
        }

    }
    #endregion
}