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
            // This method works with all the startup files 
            // .UseStartup<StartupViews>(); 
            // in Program.cs
            return View("Index");
        }
    }
}