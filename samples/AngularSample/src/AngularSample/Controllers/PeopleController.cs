using Microsoft.AspNet.Mvc;

namespace AngularSample.Controllers
{
    public class PeopleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
