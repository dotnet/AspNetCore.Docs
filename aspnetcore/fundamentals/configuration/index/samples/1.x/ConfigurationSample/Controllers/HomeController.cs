using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ConfigurationSample.Models;
using ConfigurationSample.ViewModels;

namespace ConfigurationSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            var viewModel = new Config();

            // Take a subset of the configuration entries because the 
            // AddEnvironmentVariables call provided by CreateDefaultBuilder 
            // doesn't have a prefix filter. All environment variables available 
            // are provided to the app's configuration. Without the filtering
            // applied here, the list of configuration entries shown by the app
            // can number over 50.
            var configEntryFilter = new string[] { "ASPNETCORE_", "urls", "Logging", "ENVIRONMENT", "contentRoot", "AllowedHosts", "applicationName", "CommandLine" };

            var config = _config.AsEnumerable();

            viewModel.FilteredConfiguration = config.Where(
                kvp => config.Any(
                    i => configEntryFilter.Any(prefix => kvp.Key.StartsWith(prefix))));

            // Uncomment the next line to render all configuration key-value pairs.
            //viewModel.FilteredConfiguration = _config.AsEnumerable();

            var starship = new Starship();
            _config.GetSection("starship").Bind(starship);
            viewModel.Starship = starship;

            viewModel.TvShow = _config.GetSection("tvshow").Get<TvShow>();

            return View(viewModel);
        }
    }
}
