using Microsoft.AspNetCore.Mvc;
using AppPartDemo.Model;

namespace AppPartDemo.Controllers
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
