//#define First
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
        private readonly IOptions<MySubOptions> _subOptionsAccessor;

        public HomeController(IOptions<MyOptions> optionsAccessor, 
                              IOptions<MySubOptions> subOptionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
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
