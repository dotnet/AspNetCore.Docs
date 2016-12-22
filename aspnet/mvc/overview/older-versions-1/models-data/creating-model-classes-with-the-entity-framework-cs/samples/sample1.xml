using System.Linq;
using System.Web.Mvc;
using MovieEntityApp.Models;

namespace MovieEntityApp.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        MoviesDBEntities _db;

        public HomeController()
        {
            _db = new MoviesDBEntities();
        }

        public ActionResult Index()
        {
            ViewData.Model = _db.MovieSet.ToList();
            return View();
        }

    }
}