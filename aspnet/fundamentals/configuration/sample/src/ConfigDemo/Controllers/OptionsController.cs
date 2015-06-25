using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace ConfigDemo.Controllers
{
    public class OptionsController : Controller
    {
        private readonly AppSettings _appSettings;

        public OptionsController(IOptions<AppSettings> settingsAccessor)
        {
            _appSettings = settingsAccessor.Options;
        }

        public IActionResult Index()
        {
            return View(_appSettings);
        }
    }
}
