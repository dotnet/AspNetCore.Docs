using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
     public abstract class ApplicationController : Controller
     {
          private MovieDataContext _dataContext = new MovieDataContext();

          public MovieDataContext DataContext
          {
               get { return _dataContext; }
          }

          public ApplicationController()
          {
               ViewData["categories"] = from c in DataContext.MovieCategories 
                         select c;
          }

     }
}