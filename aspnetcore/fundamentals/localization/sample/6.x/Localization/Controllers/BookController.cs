using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace Localization.Controllers;

public class BookController : Controller
{
    private readonly IHtmlLocalizer<BookController> _localizer;

    public BookController(IHtmlLocalizer<BookController> localizer)
    {
        _localizer = localizer;
    }

    public IActionResult Hello(string name)
    {
        ViewData["Message"] = _localizer["<b>Hello</b><i> {0}</i>", name];

        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    // Pass the requestCultureFeature and requestCulture objects to the view
    // so we can get Culture/UICulture information.
     
    public IActionResult About()
    {
        IRequestCultureFeature requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
        RequestCulture requestCulture = requestCultureFeature.RequestCulture;
        ViewData["requestCultureFeature"] = requestCultureFeature;
        ViewData["requestCulture"] = requestCulture;
        ViewData["Message"] = _localizer["Your application description page."];

        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = _localizer["Your contact page."];
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
