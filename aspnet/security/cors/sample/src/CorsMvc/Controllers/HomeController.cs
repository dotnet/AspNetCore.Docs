using Microsoft.AspNetCore.Cors.Core;
using Microsoft.AspNetCore.Mvc;

namespace CorsMvc.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class HomeController : Controller
    {
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Index()
        {
            return View();
        }

        [DisableCors]
        public IActionResult About()
        {
            return View();
        }
    }
}
