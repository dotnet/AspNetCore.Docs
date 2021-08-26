using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace RP.Pages;

public class LanguageModel : PageModel
{
    private readonly IOptions<RequestLocalizationOptions> _requestLocalizationOptions;
    public LanguageModel(IOptions<RequestLocalizationOptions> requestLocalizationOptions)
    {
        _requestLocalizationOptions = requestLocalizationOptions;
    }

    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public void OnGet()
    {
    }
    public IActionResult OnPost(string lang, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            if (_requestLocalizationOptions.Value.RequestCultureProviders.FirstOrDefault()
                is CookieRequestCultureProvider cookieRequestCultureProvider)
            {
                Response.Cookies.Append(cookieRequestCultureProvider.CookieName,
                          //CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
                          //new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
                          CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)));
            }
            return LocalRedirect(returnUrl);
        }
        return LocalRedirect("/");
    }
}
