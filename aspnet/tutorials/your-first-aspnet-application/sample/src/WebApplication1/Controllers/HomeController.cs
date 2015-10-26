using System;
using Microsoft.AspNet.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            string appName = "Your First ASP.NET 5 App";
            ViewBag.Message = "Your Application Name: " + appName;

            var serverInfo = new ServerInfoViewModel()
            {
                Name = Environment.MachineName,
                Software = Environment.OSVersion.ToString()
            };
            return View(serverInfo);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
