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
        private readonly IOptions<MyOptions> _optionsAccessor;

        public HomeController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public IActionResult Index()
        {
            var option1 = _optionsAccessor.Value.Option1;
            var option2 = _optionsAccessor.Value.Option2;
            return Content($"option1 = {option1}, option2 = {option2}");
        }
    }
    #endregion
}
#endif
