#define Logging // or NoLogging

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreService
{
#if NoLogging
    #region NoLogging
    internal class CustomWebHostService : WebHostService
    {
        public CustomWebHostService(IWebHost host) : base(host)
        {
        }

        protected override void OnStarting(string[] args)
        {
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            base.OnStopping();
        }
    }
    #endregion
#endif
#if Logging
#region Logging
    internal class CustomWebHostService : WebHostService
    {
        private ILogger _logger;

        public CustomWebHostService(IWebHost host) : base(host)
        {
            _logger = host.Services.GetRequiredService<ILogger<CustomWebHostService>>();
        }

        protected override void OnStarting(string[] args)
        {
            _logger.LogDebug("OnStarting method called.");
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            _logger.LogDebug("OnStarted method called.");
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            _logger.LogDebug("OnStopping method called.");
            base.OnStopping();
        }
    }
#endregion
#endif
}
