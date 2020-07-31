using DependencyInjectionSample.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace DependencyInjectionSample.Services
{
    #region snippet1
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(
                $"MyDependency.WriteMessage called. Message: {message}");
        }
    }
    #endregion

    #region snippet1
    public class MyDependency2 : IMyDependency
    {
        private readonly ILogger<MyDependency> _logger;

        public MyDependency2(ILogger<MyDependency> logger)
        {
            _logger = logger;
        }

        public void WriteMessage(string message)
        {
            _logger.LogInformation(
                "MyDependency.WriteMessage called. Message: {MESSAGE}",
                message);
        }
    }
    #endregion
}
