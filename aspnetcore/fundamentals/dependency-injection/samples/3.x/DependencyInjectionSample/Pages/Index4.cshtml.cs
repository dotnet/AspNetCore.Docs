using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionSample.Pages
{
    #region snippet1
    public class Index4Model : PageModel
    {
        public Index4Model(
            ILogger<Index4Model> logger,
            OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation)
        {
            _logger = logger;
            OperationService = operationService;
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
        }

        private readonly ILogger _logger;

        public OperationService OperationService { get; }
        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }

        public void  OnGet()
        {
            _logger.LogInformation("IOperationTransient: " + TransientOperation.OperationId.ToString());
            _logger.LogInformation("IOperationScoped: " + ScopedOperation.OperationId.ToString());
            _logger.LogInformation("SingletonOperation: " + SingletonOperation.OperationId.ToString());

        }
    }
    #endregion
}
