using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HttpRequestsSample.Models;

namespace HttpRequestsSample.Handlers
{
    // <snippet_Class>
    public class OperationHandler : DelegatingHandler
    {
        private readonly IOperationScoped _operationService;

        public OperationHandler(IOperationScoped operationScoped)
        {
            _operationService = operationScoped;
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-OPERATION-ID", _operationService.OperationId);

            return await base.SendAsync(request, cancellationToken);
        }
    }
    // </snippet_Class>
}
