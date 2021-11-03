using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebAsync.Models;

namespace WebAsync.Controllers
{
    #region snippet
    public class HomeController : Controller, IAsyncDisposable
    {
        private Utf8JsonWriter? _jsonWriter;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _jsonWriter = new Utf8JsonWriter(new MemoryStream());
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region snippet2
        public async ValueTask DisposeAsync()
        {
            // Perform async cleanup.
            await DisposeAsyncCore();
            // Dispose of unmanaged resources.
            Dispose(false);
            // Suppress GC to call the finalizer.
            GC.SuppressFinalize(this);
        }
        #endregion

        #region snippet3
        protected async virtual ValueTask DisposeAsyncCore()
        {
            if (_jsonWriter is not null)
            {
                await _jsonWriter.DisposeAsync();
            }

            _jsonWriter = null;
        }
        #endregion
    }
}