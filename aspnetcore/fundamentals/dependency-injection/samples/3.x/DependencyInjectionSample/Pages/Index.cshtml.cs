using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;

namespace DependencyInjectionSample.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly IMyDependency _myDependency;

        public IndexModel(
            IMyDependency myDependency, 
            OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance singletonInstanceOperation)
        {
            _myDependency = myDependency;
            OperationService = operationService;
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = singletonInstanceOperation;
        }

        public OperationService OperationService { get; }
        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
        public IOperationSingletonInstance SingletonInstanceOperation { get; }

        public async Task OnGetAsync()
        {
            await _myDependency.WriteMessage(
                "IndexModel.OnGetAsync created this message.");
        }
    }
    #endregion
}
