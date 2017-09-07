using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebConfigBind
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyWindow> _optionsAccessor;

        public HomeController(IOptions<MyWindow> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public IActionResult Index()
        {
            var height = _optionsAccessor.Value.Height;
            var width = _optionsAccessor.Value.Width;
            var left = _optionsAccessor.Value.Left;
            var top = _optionsAccessor.Value.Top;

            return Content($"height = {height}, width = {width}, " + 
                $"left = {left}, top = {top}");
        }
    }
}
