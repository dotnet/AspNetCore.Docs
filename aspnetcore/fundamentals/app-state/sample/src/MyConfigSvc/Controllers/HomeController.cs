using Microsoft.AspNetCore.Mvc;
using MyConfigSvc.Services;

public class HomeController : Controller
{
    private readonly MyConfigService _myService;

    public HomeController(MyConfigService myService)
    {
        _myService = myService;
        // Read service values.
        MyService.InitializeService(_myService);
    }

    public IActionResult Index()
    {
        return Content($"Discount: \"{_myService.Discount}\","
                     + $"Theme: \"{_myService.Theme}\"");
    }
}

