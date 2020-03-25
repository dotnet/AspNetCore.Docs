using System.Threading.Tasks;
using DependencyInjectionSample.Interfaces;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionSample.Services
{
    #region snippet1
    public class MyDependency : IMyDependency
    {
        private readonly ILogger<MyDependency> _logger;

        public MyDependency(ILogger<MyDependency> logger)
        {
            _logger = logger;
        }

        public Task WriteMessage(string message)
        {
            _logger.LogInformation(
                "MyDependency.WriteMessage called. Message: {Message}", 
                message);

            return Task.FromResult(0);
        }
    }
    #endregion
}
