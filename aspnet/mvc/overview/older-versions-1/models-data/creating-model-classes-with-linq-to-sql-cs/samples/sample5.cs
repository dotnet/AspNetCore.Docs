using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
     public class MoviesController : Controller
     {
          private IMovieRepository _repository;

          public MoviesController() : this(new MovieRepository())
          {
          }

          public MoviesController(IMovieRepository repository)
          {
               _repository = repository;
          }

          public ActionResult Index()
          {
               return View(_repository.ListAll());
          }
     }
}