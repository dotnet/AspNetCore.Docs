using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Docs.Samples;

namespace RoutingSample.Controllers
{
    // webBuilder.UseStartup<StartupMVC>();
    #region snippet
    public class WidgetController : Controller
    {
        private readonly LinkGenerator _linkGenerator;

        public WidgetController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public IActionResult Index()
        {
            var url = _linkGenerator.GetPathByAction(HttpContext,
                                                     null, null,
                                                     new { id = 17, });
            return Content(url);
        }
        #endregion

        public IActionResult Subscribe(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);

        #region snippet2
        public IActionResult Index2()
        {
            var url = _linkGenerator.GetPathByAction("Subscribe", "Home",
                                                     new { id = 17, });
            return Content(url);
        }
        #endregion

        public IActionResult Index3()
        {
            #region snippet3
            var url = _linkGenerator.GetPathByAction("Subscribe", null,
                                                     new { id = 17, });
            #endregion
            return Content(url);
        }
    }
}