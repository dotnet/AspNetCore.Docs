using ControllerDI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ControllerDI.Controllers
{
    #region snippet
    public class SettingsController : Controller
    {
        private readonly SampleWebSettings _settings;

        public SettingsController(IOptions<SampleWebSettings> settingsOptions)
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
    #endregion
}