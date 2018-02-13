using System;
using Microsoft.AspNetCore.Hosting;

namespace BackgroundTasksSample.Services
{
    #region snippet1
    internal interface IScopedProcessingService
    {
        void DoWork();
    }

    internal class ScopedProcessingService : IScopedProcessingService
    {
        private readonly IHostingEnvironment _env;
        
        public ScopedProcessingService(IHostingEnvironment env)
        {
            _env = env;
        }

        public void DoWork()
        {
            Console.WriteLine($"{DateTime.UtcNow} - Scoped Processing Service is working.");
            Console.WriteLine($"Scoped Processing Service Env: {_env.EnvironmentName}");
        }
    }
    #endregion
}
