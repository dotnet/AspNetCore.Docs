using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers
{
    #region snippet_AddHeader
    [AddHeader("Author", "Steve Smith @ardalis")]
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return Content("Examine the headers using developer tools.");
        }

        [ShortCircuitingResourceFilter]
        public IActionResult SomeResource()
        {
            return Content("Successful access to resource - header should be set.");
        }
        #endregion

        [AddHeaderWithFactory]
        public IActionResult HeaderWithFactory()
        {
            return Content("Examine the headers using developer tools.");
        }
    }
}
