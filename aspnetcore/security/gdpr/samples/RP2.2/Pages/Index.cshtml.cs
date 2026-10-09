using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPCC.Pages
{
    public class IndexModel : PageModel
    {
        public ITrackingConsentFeature TrackingConsentFeature;
        public IRequestCookieCollection RequestCookieCollection;

        [TempData]
        public string ResponseCookies { get; set; }

        public void OnGet()
        {
            RequestCookieCollection = Request.Cookies;
            TrackingConsentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
        }
    }
}
