using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ConfigurationSample.Models;

namespace ConfigurationSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<KeyValuePair<string, string>> FilteredConfiguration { get; private set; }

        public Starship Starship { get; private set; }

        public TvShow TvShow { get; private set; }

        public ArrayExample ArrayExample { get; private set; }

        public JsonArrayExample JsonArrayExample { get; private set; }

        public void OnGet()
        {
            // Take a subset of the configuration entries because the 
            // AddEnvironmentVariables call provided by CreateDefaultBuilder 
            // doesn't have a prefix filter. All environment variables available 
            // are provided to the app's configuration. Without the filtering
            // applied here, the list of configuration entries shown by the app
            // can number over 50.
            var configEntryFilter = new string[] { "ASPNETCORE_", "urls", "Logging", "ENVIRONMENT", "contentRoot", "AllowedHosts", "applicationName", "CommandLine" };

            var config = _config.AsEnumerable();

            FilteredConfiguration = config.Where(
                kvp => config.Any(
                    i => configEntryFilter.Any(prefix => kvp.Key.StartsWith(prefix))));

            #region snippet_starship
            // using Microsoft.Extensions.Configuration;

            var starship = new Starship();
            _config.GetSection("starship").Bind(starship);
            Starship = starship;
            #endregion

            #region snippet_tvshow
            // using Microsoft.Extensions.Configuration;

            TvShow = _config.GetSection("tvshow").Get<TvShow>();
            #endregion

            #region snippet_array
            // using Microsoft.Extensions.Configuration;

            ArrayExample = _config.GetSection("array").Get<ArrayExample>();
            #endregion

            JsonArrayExample = _config.GetSection("json_array").Get<JsonArrayExample>();
        }
    }
}
