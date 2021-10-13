using System;
using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Models
{
    #region snippet1
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
        }

        public string OperationId { get; }
    }
    #endregion
}
