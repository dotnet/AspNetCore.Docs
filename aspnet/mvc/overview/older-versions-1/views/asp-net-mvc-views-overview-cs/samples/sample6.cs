using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ViewData["message"] = "Hello World!";
            return View();
        }

    }
}