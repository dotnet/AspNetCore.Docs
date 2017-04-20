using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [OutputCache(Duration=10, VaryByParam="none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}