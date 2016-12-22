using System.Linq;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
     public class MoviesController : ApplicationController
     {
          /// <summary>

          /// Show list of all movies
          /// </summary>
          public ActionResult Index()
          {
               ViewData["movies"] = from m in DataContext.Movies 
                         select m;
               return View();
          }

          /// <summary>
          /// Show list of movies in a category
          /// </summary>

          public ActionResult Details(int id)
          {
               ViewData["movies"] = from m in DataContext.Movies
                         where m.CategoryId == id
                         select m;
               return View();
          }

     }
}