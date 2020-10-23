using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Localization.Controllers
{
    public class InfoController : Controller
    {
        private readonly IStringLocalizer<InfoController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public InfoController(IStringLocalizer<InfoController> localizer,
                       IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }

        public string TestLoc()
        {
            string msg = "Shared resx: " + _sharedLocalizer["Hello!"] +
                         " Info resx " + _localizer["Hello!"];
            return msg;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _sharedLocalizer["Your application description page."];

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = _sharedLocalizer["Your contact page."];
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

namespace Localization.LocSample
{
    public class SharedResource
    {
    }
}
