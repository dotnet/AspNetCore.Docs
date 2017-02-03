using System.Web.Mvc;
namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Details(int productId)
        {
            return View();
        }
    }
}