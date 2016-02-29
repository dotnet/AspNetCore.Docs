using Microsoft.AspNet.Mvc;

namespace ViewInjectSample.Controllers
{
    public class HelperController : Controller
    {
        [Route("Helper")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
