using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;

namespace AspNetCoreService
{
    #region ExtensionsClass
    public static class WebHostServiceExtensions
    {
        public static void RunAsCustomService(this IWebHost host)
        {
            var webHostService = new CustomWebHostService(host);
            ServiceBase.Run(webHostService);
        }
    }
    #endregion
}
