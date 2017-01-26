using System.Web.Mvc;
using MvcApplication1.ActionFilters;

namespace MvcApplication1.Controllers
{
     [LogActionFilter]
     public class HomeController : Controller
     {
          public ActionResult Index()
          {
               return View();
          }

          public ActionResult About()
          {
               return View();
          }
     }
}