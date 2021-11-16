using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Docs.Samples;

namespace RoutingSample.Controllers
{
    // webBuilder.UseStartup<StartupMVC>();
    // <snippet>
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
        // </snippet>

        public IActionResult Subscribe(int id) =>
            ControllerContext.MyDisplayRouteInfo(id);

        // <snippet2>
        public IActionResult Index2()
        {
            var url = _linkGenerator.GetPathByAction("Subscribe", "Home",
                                                     new { id = 17, });
            return Content(url);
        }
        // </snippet2>

        public IActionResult Index3()
        {
            // <snippet3>
            var url = _linkGenerator.GetPathByAction("Subscribe", null,
                                                     new { id = 17, });
            // </snippet3>
            return Content(url);
        }
    }
}