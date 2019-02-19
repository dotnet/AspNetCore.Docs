using Microsoft.AspNetCore.Mvc;
using MVCareas.Models;
using System.Diagnostics;

namespace MVCareas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //// URL to /Products/Manage/About
            //ViewData["url"] =
            //#region snippet
            //    Url.Action("About", "Manage", new { area = "Products" });
            //#endregion

            //ViewData["urlNo"] =
            //#region snippet_test
            //    Url.Action("About", "Manage");
            //#endregion

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
