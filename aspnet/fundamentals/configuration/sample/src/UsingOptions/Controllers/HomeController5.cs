//#define Simple
#if Simple
// Use this class with Startup5.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsingOptions.Models;

namespace UsingOptions.Controllers
{
#region snippet1
    public class HomeController : Controller
    {
        private readonly MyOptions _optionsAccessor;

        public HomeController(MyOptions optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public IActionResult Index()
        {
            var option1 = _optionsAccessor.Option1;
            var option2 = _optionsAccessor.Option2;
            return Content($"option1 = {option1}, option2 = {option2}");
        }
    }
#endregion
}
#endif
