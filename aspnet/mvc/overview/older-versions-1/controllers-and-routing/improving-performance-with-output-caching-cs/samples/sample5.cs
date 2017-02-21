using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDataContext _dataContext;

        public MoviesController()
        {
            _dataContext = new MovieDataContext();
        }

        [OutputCache(Duration=int.MaxValue, VaryByParam="none")]
        public ActionResult Master()
        {
            ViewData.Model = (from m in _dataContext.Movies 
                              select m).ToList();
            return View();
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            ViewData.Model = _dataContext.Movies.SingleOrDefault(m => m.Id == id);
            return View();
        }


    }
}