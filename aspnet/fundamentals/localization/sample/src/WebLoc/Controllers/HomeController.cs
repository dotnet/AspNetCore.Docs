using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Localization;
using Microsoft.AspNet.Localization;

using System.Globalization;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using Microsoft.Extensions.DependencyInjection;

namespace WebLoc.Controllers
{
    public class HomeController : Controller
    {
        private IHtmlLocalizer<HomeController> _localizer;

        //public HomeController(IHtmlLocalizer<HomeController> localizer)
        //{
        //    _localizer = localizer;
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            var context = HttpContext.Request.HttpContext;

            var requestCultureFeature = context.Features.Get<IRequestCultureFeature>();
           var requestCulture = requestCultureFeature.RequestCulture;

            ViewData["Message"] = requestCultureFeature.Provider.GetType().Name;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
