using AppPartsSample.Model;
using Microsoft.AspNetCore.Mvc;

namespace AppPartsSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var entities = EntityTypes.Types;
            return View(entities);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
