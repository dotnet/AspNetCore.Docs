using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionSample.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly ILogger _logger;
        private readonly IOperationTransient TransientOperation;
        private readonly IOperationSingleton SingletonOperation;
        private readonly IOperationScoped ScopedOperation;

        public IndexModel(
            ILogger<IndexModel> logger,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation)
        {
            _logger = logger;
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
        }

        public void  OnGet()
        {
            _logger.LogInformation("IOperationTransient: " + TransientOperation.OperationId);
            _logger.LogInformation("IOperationScoped: " + ScopedOperation.OperationId);
            _logger.LogInformation("SingletonOperation: " + SingletonOperation.OperationId);
        }
    }
    #endregion
}
