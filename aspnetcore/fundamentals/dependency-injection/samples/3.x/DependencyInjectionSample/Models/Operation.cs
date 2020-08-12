using System;
using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Models
{
    #region snippet1
    public class Operation : IOperationTransient,
        IOperationScoped,
        IOperationSingleton
    {
        public Operation() : this(Guid.NewGuid().ToString())
        {
        }

        public Operation(string id)
        {
            OperationId = id.Substring(id.Length-4);
        }

        public string OperationId { get; private set; }
    }
    #endregion
}
