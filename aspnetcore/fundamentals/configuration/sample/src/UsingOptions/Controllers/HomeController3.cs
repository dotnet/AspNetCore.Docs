//#define First
#if First
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsingOptions.Models;

namespace UsingOptions.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyOptions _options;

        public HomeController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public IActionResult Index()
        {
            return View(_options);
        }
    }
}
#endif
