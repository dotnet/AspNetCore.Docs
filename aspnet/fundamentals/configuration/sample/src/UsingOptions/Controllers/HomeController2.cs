//#define First
#if First
// use with Startup3.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UsingOptions.Controllers
{
    #region snippet1
    public class HomeController : Controller
    {
        private readonly IOptions<MySubOptions> _subOptionsAccessor;

        public HomeController(IOptions<MyOptions> optionsAccessor, 
                              IOptions<MySubOptions> subOptionsAccessor)
        {
            _subOptionsAccessor = subOptionsAccessor;
        }

        public IActionResult Index()
        {
            var subOption1 = _subOptionsAccessor.Value.SubOption1;
            var subOption2 = _subOptionsAccessor.Value.SubOption2;
            return Content($"subOption1 = {subOption1}, subOption2 = {subOption2}");
        }
    }
    #endregion
}
#endif
