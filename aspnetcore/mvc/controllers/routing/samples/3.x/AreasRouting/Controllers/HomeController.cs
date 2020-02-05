using Microsoft.AspNetCore.Mvc;

namespace AreasRouting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region snippet
        public IActionResult About()
        {
            var url = Url.Action( "Users", "AddUser", new { Area = "Zebra" });
            return Content($"URL: {url}");
        }
        #endregion

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
