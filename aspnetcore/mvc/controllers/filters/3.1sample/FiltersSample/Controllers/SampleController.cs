using FiltersSample.Filters;
using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FiltersSample.Controllers
{
    #region snippet2
    #region snippet_AddHeader
    [AddHeader("Author", "Rick Anderson")]
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return Content("Examine the headers using the F12 developer tools.");
        }
        #endregion

        [ServiceFilter(typeof(MyActionFilterAttribute))]
        public IActionResult Index2()
        {
            return Content("Examine the headers using the F12 developer tools.");
        }
#endregion


        [ShortCircuitingResourceFilter]
        public IActionResult SomeResource()
        {
            return Content("Successful access to resource - header is set.");
        }

        [AddHeaderWithFactory]
        public IActionResult HeaderWithFactory()
        {
            return Content("Examine the headers using the F12 developer tools.");
        }
    }
}
