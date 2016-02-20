using System;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Localization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Localization;


namespace Localization.StarterWeb.Controllers
{
    public class ZebraController : Controller
    {
        private readonly IStringLocalizer<ZebraController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ZebraController(IStringLocalizer<ZebraController> localizer,
                       IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }


        public string TestLoc()
        {
            string msg = "Shared resx: " + _sharedLocalizer["Hello!"] + 
                         " Zebra resx " + _localizer["Hello!"];
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

        //title="@Localizer["Log in using your {0} account", @provider.DisplayName]"> 
        // @provider.AuthenticationScheme</button>



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

#if NOns

#else
namespace Localization.StarterWeb.LocSample
{
    public class SharedResource
    {
    }
}
#endif