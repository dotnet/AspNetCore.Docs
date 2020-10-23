using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Services
{
    #region snippet1
    public class OperationService
    {
        public OperationService(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
        }

        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
    }
    #endregion
}
