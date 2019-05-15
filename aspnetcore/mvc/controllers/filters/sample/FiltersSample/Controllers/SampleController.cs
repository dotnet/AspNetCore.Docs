using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers
{
    #region snippet_AddHeader
    [AddHeader("Author", "Joe Smith")]
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return Content("Examine the headers using the F12 developer tools.");
        }

        [ShortCircuitingResourceFilter]
        public IActionResult SomeResource()
        {
            return Content("Successful access to resource - header is set.");
        }
        #endregion

        [AddHeaderWithFactory]
        public IActionResult HeaderWithFactory()
        {
            return Content("Examine the headers using the F12 developer tools.");
        }
    }
}
