using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
     [HandleError]
     public class HomeController : Controller
     {
          private MovieDataContext _dataContext = new MovieDataContext();

          /// <summary>

          /// Show list of all movies
          /// </summary>
          public ActionResult Index()
          {
               ViewData["categories"] = from c in _dataContext.MovieCategories 
                         select c;
               ViewData["movies"] = from m in _dataContext.Movies 
                         select m;
               return View();
          }

          /// <summary>
          /// Show list of movies in a category
          /// </summary>

          public ActionResult Details(int id)
          {
               ViewData["categories"] = from c in _dataContext.MovieCategories 
                         select c;
               ViewData["movies"] = from m in _dataContext.Movies 
                         where m.CategoryId == id
                         select m;
               return View();
          }
     }
}