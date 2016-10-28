using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsingOptions.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UsingOptions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyOptions> _optionsAccessor;

        public HomeController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        // GET: /<controller>/
        public IActionResult Index() => View(_optionsAccessor.Value);
    }
}
