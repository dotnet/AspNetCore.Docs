using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FiltersSample.Controllers
{
    public class HomeController : Controller
    {
        #region snippet_ServiceFilter
        [ServiceFilter(typeof(AddHeaderFilterWithDi))]
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        [AddHeader("Author", "Steve Smith @ardalis")]
        public IActionResult Hello(string name)
        {
            return Content($"Hello {name}");
        }

        #region snippet_TypeFilter
        [TypeFilter(typeof(AddHeaderAttribute),
            Arguments = new object[] { "Author", "Steve Smith (@ardalis)" })]
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
            return Content($"CurrentCulture:{CultureInfo.CurrentCulture.Name},"
                + "CurrentUICulture:{CultureInfo.CurrentUICulture.Name}");
        }
        #endregion
    }
}
