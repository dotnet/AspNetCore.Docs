using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCareas.Models;

namespace MVCareas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // URL to /Products/Manage/About
            ViewData["url"] =
            #region snippet
                Url.Action("About", "Manage", new { area = "Products" });
            #endregion

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            ViewData["url"] =
            #region snippet_test
                Url.Action("About", "Manage");
            #endregion
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
