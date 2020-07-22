using System;
using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Models
{
    #region snippet1
    public class Operation : IOperationTransient,
        IOperationScoped,
        IOperationSingleton,
        IOperationSingletonInstance
    {
        public Operation() : this(DateTime.Now.Millisecond.ToString())
        {
            DoWork();
        }

        public Operation(string id)
        {
            OperationId = id;
        }

        private void DoWork()
        {
            // Do work so different times are recorded.
            int sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                sum += i;
            }
        }

        public string OperationId { get; private set; }
    }
    #endregion
}
