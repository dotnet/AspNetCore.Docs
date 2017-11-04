using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ChangeTokenSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        private readonly Dictionary<string, string> _styleDict = new Dictionary<string, string>() 
        {
            { "Trace", "default" },
            { "Debug", "success" },
            { "Information", "info" },
            { "Warning", "warning" },
            { "Error", "primary" },
            { "Critical", "danger" }
        };

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public string IncludeScopes { get; private set; }
        public string DefaultLogLevel { get; private set; }
        public string SystemLogLevel { get; private set; }
        public string MicrosoftLogLevel { get; private set; }
        
        public void OnGet()
        {
            #region snippet1
            IncludeScopes = _config["Logging:IncludeScopes"];
            DefaultLogLevel = _config["Logging:LogLevel:Default"];
            SystemLogLevel = _config["Logging:LogLevel:System"];
            MicrosoftLogLevel = _config["Logging:LogLevel:Microsoft"];
            #endregion
            ViewData["IncludeScopesStyle"] = string.Equals(_config["Logging:IncludeScopes"], "True", StringComparison.Ordinal) ? "success" : "danger";
            ViewData["DefaultLogLevelStyle"] = _styleDict[_config["Logging:LogLevel:Default"]];
            ViewData["SystemLogLevelStyle"] = _styleDict[_config["Logging:LogLevel:System"]];
            ViewData["MicrosoftLogLevelStyle"] = _styleDict[_config["Logging:LogLevel:Microsoft"]];
        }
    }
}
