#define First
#if First
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsingOptions.Models;

namespace UsingOptions.Controllers
{
    #region snippet1
    public class HomeController : Controller
    {
        private readonly MyOptions _options;

        public HomeController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public IActionResult Index()
        {
            var option1 = _options.Option1;
            var option2 = _options.Option2;
            return Content($"option1 = {option1}, option2 = {option2}");
        }
    }
    #endregion
}
#endif
