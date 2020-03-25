using Microsoft.AspNetCore.Mvc;
using ResourceBasedAuthApp2.Models;
using System.Diagnostics;

namespace ResourceBasedAuthApp2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
