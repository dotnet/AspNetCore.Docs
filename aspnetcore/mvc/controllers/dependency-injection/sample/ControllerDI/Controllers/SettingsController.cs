using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllerDI.Models;
using Microsoft.Extensions.Options;

namespace ControllerDI.Controllers
{
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
}