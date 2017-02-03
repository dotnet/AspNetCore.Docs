using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
     [HandleError]
     public class HomeController : Controller
     {
          public ActionResult Index()
          {
               var dataContext = new MovieDataContext();
               var movies = from m in dataContext.Movies
                    select m;
               return View(movies);
          }
     }
}