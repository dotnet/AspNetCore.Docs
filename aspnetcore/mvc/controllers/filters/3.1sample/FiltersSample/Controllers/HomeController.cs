using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace FiltersSample.Controllers
{
    public class HomeController : Controller
    {
        #region snippet_ServiceFilter
        [ServiceFilter(typeof(AddHeaderResultServiceFilter))]
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        [AddHeader("Author", "Rick Anderson @RickAndMSFT")]
        public IActionResult Hello(string name)
        {
            return Content($"Hello {name}");
        }

        #region snippet_TypeFilter
        [TypeFilter(typeof(LogConstantFilter),
            Arguments = new object[] { "Method 'Hi' called" })]
        public IActionResult Hi(string name)
        {
            return Content($"Hi {name}");
        }
        #endregion

        #region snippet_MiddlewareFilter
        [Route("{culture}/[controller]/[action]")]
        [MiddlewareFilter(typeof(LocalizationPipeline))]
        public IActionResult CultureFromRouteData()
        {
            return Content(
                  $"CurrentCulture:{CultureInfo.CurrentCulture.Name},"
                + $"CurrentUICulture:{CultureInfo.CurrentUICulture.Name}");
        }
        #endregion

        #region snippet
        #region snippet2
        [SampleActionFilter]
        public IActionResult FilterTest()
        {
            return Content("From FilterTest");
        }
        #endregion

        [TypeFilter(typeof(SampleActionFilterAttribute))]
        public IActionResult TypeFilterTest()
        {
            return Content("From TypeFilterTest");
        }

        // ServiceFilter must be registered in ConfigureServices or
        // System.InvalidOperationException: No service for type '<filter>'
        // has been registered. Is thrown.
        [ServiceFilter(typeof(SampleActionFilterAttribute))]
        public IActionResult ServiceFilterTest()
        {
            return Content("From ServiceFilterTest");
        }
        #endregion

        public IActionResult CultureFromRouteData2()
        {
            return Redirect("/en.en/Home/CultureFromRouteData");
        }

    }
}
