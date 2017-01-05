using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace FileProviderSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileProvider _fileProvider;

        public HomeController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            var contents = _fileProvider.GetDirectoryContents("");
            return View(contents);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
