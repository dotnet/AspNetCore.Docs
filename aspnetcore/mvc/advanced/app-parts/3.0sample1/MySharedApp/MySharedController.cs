using Microsoft.AspNetCore.Mvc;

namespace MySharedApp.Controllers
{
    public class MySharedController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Message from shared assembly!");
        }

        public IActionResult IndexView()
        {
            // This method requires 
            // .UseStartup<StartupViews>(); or StartUp
            // in Program.cs
            return View("Index");
        }
    }
}