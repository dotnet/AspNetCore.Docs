using AppPartSample.Model;
using Microsoft.AspNetCore.Mvc;

namespace AppPartSample.Controllers
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
