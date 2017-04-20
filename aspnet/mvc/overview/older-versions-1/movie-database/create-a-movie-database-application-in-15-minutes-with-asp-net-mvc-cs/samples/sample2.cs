using System.Linq;

using System.Web.Mvc;

using MovieApp.Models; 

namespace MovieApp.Controllers

{

	public class HomeController : Controller

	{

		private MoviesDBEntities _db = new MoviesDBEntities(); 

		public ActionResult Index()

		{

			return View(_db.MovieSet.ToList());

		}

	}

}