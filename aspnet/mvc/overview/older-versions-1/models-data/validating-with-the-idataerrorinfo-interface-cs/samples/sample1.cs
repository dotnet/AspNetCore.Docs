using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{

    public class HomeController : Controller
    {
        private MoviesDBEntities _db = new MoviesDBEntities();

        public ActionResult Index()
        {
            return View(_db.MovieSet.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Movie movieToCreate)
        {
            // Validate
            if (!ModelState.IsValid)
                return View();

            // Add to database
            try
            {
                _db.AddToMovieSet(movieToCreate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}