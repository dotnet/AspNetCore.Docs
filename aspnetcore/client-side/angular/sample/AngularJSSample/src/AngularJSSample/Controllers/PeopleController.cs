using Microsoft.AspNetCore.Mvc;

namespace AngularSample.Controllers
{
    public class PeopleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Spa()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }
    }
}
