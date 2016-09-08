using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace FileProviderSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private static string _dateFileLastChanged = "Never";

        public HomeController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            var contents = _fileProvider.GetDirectoryContents("");
            return View(contents);
        }

        public IActionResult Watch()
        {
            var token = _fileProvider.Watch("wwwroot/js/site.js");
            token.RegisterChangeCallback(state =>
            {
                _dateFileLastChanged = DateTime.Now.ToString("HH:mm:ss");
            }, state: null);

            ViewData.Add("LastChanged", _dateFileLastChanged);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
