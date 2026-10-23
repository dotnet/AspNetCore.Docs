using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Localization.Controllers;

// <snippet_1>
public class TestController : Controller
{
    private readonly IStringLocalizer _localizer;
    private readonly IStringLocalizer _localizer2;

    public TestController(IStringLocalizerFactory factory)
    {
        var type = typeof(SharedResource);
        var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
        _localizer = factory.Create(type);
        _localizer2 = factory.Create("SharedResource", assemblyName.Name);
    }       

    public IActionResult About()
    {
        ViewData["Message"] = _localizer["Your application description page."] 
            + " loc 2: " + _localizer2["Your application description page."];

        return View();
    }
    // </snippet_1>
    public IActionResult Contact()
    {
        ViewData["Message"] = _localizer["Your contact page."]
            + " shared 2: " + _localizer2["Your contact page."];
        return View();
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

    public IActionResult Error()
    {
        return View();
    }
}
