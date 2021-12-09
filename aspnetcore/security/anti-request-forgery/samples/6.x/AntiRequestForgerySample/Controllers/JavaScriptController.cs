using Microsoft.AspNetCore.Mvc;

namespace AntiRequestForgerySample.Controllers;

public class JavaScriptController : Controller
{
    public IActionResult Index()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult FetchEndpoint()
        => Content("Success");
}
