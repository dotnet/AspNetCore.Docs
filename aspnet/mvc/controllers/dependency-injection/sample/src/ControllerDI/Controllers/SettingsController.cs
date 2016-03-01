using ControllerDI.Model;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;

namespace ControllerDI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly SampleWebSettings _settings;

        public SettingsController(IOptions<SampleWebSettings> settingsOptions )
        {
            _settings = settingsOptions.Value;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _settings.Title;
            ViewData["Updates"] = _settings.Updates;
            return View();
        }
    }
}