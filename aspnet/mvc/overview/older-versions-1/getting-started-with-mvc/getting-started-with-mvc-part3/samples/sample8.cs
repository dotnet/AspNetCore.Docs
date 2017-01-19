using System.Web.Mvc;

namespace Movies.Controllers
{
    public class HelloWorldController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            var viewModel = new WelcomeViewModel
            {
                Message = "Hello " + name,
                NumTimes = numTimes
            };

            return View(viewModel);
        }

        public class WelcomeViewModel
        {
            public string Message { get; set; }
            public int NumTimes { get; set; }
        }
    }
}