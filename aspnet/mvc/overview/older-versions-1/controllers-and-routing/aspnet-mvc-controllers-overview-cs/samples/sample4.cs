using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class StatusController : Controller
    {
        public ActionResult Index()
        {
            return Content("Hello World!");
        }
    }
}