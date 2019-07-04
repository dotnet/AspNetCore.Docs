using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ChangeTokenSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IConfigurationMonitor _monitor;
        private readonly FileService _fileService;

        private readonly Dictionary<string, string> _styleDict = new Dictionary<string, string>() 
        {
            { "Trace", "default" },
            { "Debug", "success" },
            { "Information", "info" },
            { "Warning", "warning" },
            { "Error", "primary" },
            { "Critical", "danger" }
        };

        #region snippet1
        public IndexModel(
            IConfiguration config, 
            IConfigurationMonitor monitor, 
            FileService fileService)
        {
            _config = config;
            _monitor = monitor;
            _fileService = fileService;
        }
        #endregion

        public string DefaultLogLevel { get; private set; }
        public string SystemLogLevel { get; private set; }
        public string MicrosoftLogLevel { get; private set; }
        public HtmlString FileContents { get; private set; }

        [TempData]
        public string CurrentState { get; set; }

        public async Task OnGet()
        {
            DefaultLogLevel = _config["Logging:LogLevel:Default"];
            SystemLogLevel = _config["Logging:LogLevel:System"];
            MicrosoftLogLevel = _config["Logging:LogLevel:Microsoft"];
            ViewData["IncludeScopesStyle"] = string.Equals(_config["Logging:IncludeScopes"], "True", StringComparison.OrdinalIgnoreCase) ? "success" : "danger";
            ViewData["DefaultLogLevelStyle"] = _styleDict[_config["Logging:LogLevel:Default"]];
            ViewData["SystemLogLevelStyle"] = _styleDict[_config["Logging:LogLevel:System"]];
            ViewData["MicrosoftLogLevelStyle"] = _styleDict[_config["Logging:LogLevel:Microsoft"]];

            CurrentState = _monitor.CurrentState;

            #region snippet3
            var fileContent = await _fileService.GetFileContents("poem.txt");
            #endregion

            FileContents = new HtmlString(fileContent.Replace("\r\n", "<br>"));
        }

        #region snippet2
        public IActionResult OnPostStartMonitoring()
        {
            _monitor.MonitoringEnabled = true;
            _monitor.CurrentState = "Monitoring!";

            return RedirectToPage();
        }

        public IActionResult OnPostStopMonitoring()
        {
            _monitor.MonitoringEnabled = false;
            _monitor.CurrentState = "Not monitoring";

            return RedirectToPage();
        }
        #endregion
    }
}
