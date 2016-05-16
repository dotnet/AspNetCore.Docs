using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsCore.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
