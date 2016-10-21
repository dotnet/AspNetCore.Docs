#define First
#if First
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UsingOptions.Controllers
{
    #region snippet1
    public class HomeController : Controller
    {
        private readonly MyOptions _optionsAccessor;

        public HomeController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
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
