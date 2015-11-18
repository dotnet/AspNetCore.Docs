using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Services
{
    public class OperationService
    {
        public IOperationTransient TransientOperation { get; private set; }
        public IOperationScoped ScopedOperation { get; private set; }
        public IOperationSingleton SingletonOperation { get; private set; }
        public IOperationInstance InstanceOperation { get; private set; }

        public OperationService(IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationInstance instanceOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            InstanceOperation = instanceOperation;
        }
    }
}