using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HttpRequestsSample.Models;

namespace HttpRequestsSample.Handlers
{
    public class OperationHandler : DelegatingHandler
    {
        private readonly IOperationScoped _operationService;

        public OperationHandler(IOperationScoped operationScoped)
        {
            _operationService = operationScoped;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-OPERATION-ID", _operationService.OperationId);

            // For sample purposes, also return the OperationId as the body.
            return Task.FromResult(new HttpResponseMessage
            {
                Content = new StringContent(_operationService.OperationId)
            });
        }
    }
}
