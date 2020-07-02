using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaticFilesSample.Models;

namespace StaticFilesSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #region snippet_BannerImage
        [Authorize]
        public IActionResult BannerImage()
        {
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(), "MyStaticFiles", "images", "banner1.svg");

            return PhysicalFile(filePath, "image/svg+xml");
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
