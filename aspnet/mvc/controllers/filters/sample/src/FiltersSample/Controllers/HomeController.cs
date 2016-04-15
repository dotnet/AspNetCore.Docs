using FiltersSample.Filters;
using Microsoft.AspNet.Mvc;

namespace FiltersSample.Controllers
{
    public class HomeController : Controller
    {
        [ServiceFilter(typeof(AddHeaderFilterWithDi))]
        public IActionResult Index()
        {
            return View();
        }

        [AddHeader("Author","Steve Smith @ardalis")]
        public IActionResult Hello(string name)
        {
            return Content($"Hello {name}");
        }

        [TypeFilter(typeof(AddHeaderAttribute), 
            Arguments =new object[] { "Author", "Steve Smith (@ardalis)"})]
        public IActionResult Hi(string name)
        {
            return Content($"Hi {name}");
        }
    }
}
