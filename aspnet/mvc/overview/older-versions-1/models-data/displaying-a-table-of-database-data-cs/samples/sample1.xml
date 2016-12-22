using System.Linq;

using System.Web.Mvc;

using MvcApplication1.Models; 

namespace MvcApplication1.Controllers

{

    public class MovieController : Controller

    {

        //

        // GET: /Movie/ 

        public ActionResult Index()

        {

            var entities = new MoviesDBEntities();

            return View(entities.MovieSet.ToList());

        } 

    }

}