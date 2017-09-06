//#define First
#if First
// use with Startup3.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsingOptions.Models;

namespace UsingOptions.Controllers
{
    #region snippet1
    public class HomeController : Controller
    {
        private readonly MySubOptions _subOptions;

        public HomeController(IOptions<MySubOptions> subOptionsAccessor)
        {
            _subOptions = subOptionsAccessor.Value;
        }

        public IActionResult Index()
        {
            var subOption1 = _subOptions.SubOption1;
            var subOption2 = _subOptions.SubOption2;
            return Content($"subOption1 = {subOption1}, subOption2 = {subOption2}");
        }
    }
    #endregion
}
#endif
