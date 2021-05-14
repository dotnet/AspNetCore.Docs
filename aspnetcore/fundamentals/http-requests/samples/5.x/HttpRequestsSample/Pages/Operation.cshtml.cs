using System.Net.Http;
using System.Threading.Tasks;
using HttpRequestsSample.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpRequestsSample.Pages
{
    public class OperationModel : PageModel
    {
        private readonly IOperationScoped _operationScoped;
        private readonly IHttpClientFactory _httpClientFactory;

        public OperationModel(IOperationScoped operationScoped, IHttpClientFactory httpClientFactory)
        {
            _operationScoped = operationScoped;
            _httpClientFactory = httpClientFactory;
        }

        public string OperationIdFromRequestScope { get; set; }

        public string OperationIdFromHandlerScope { get; set; }

        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("Operation");

            OperationIdFromRequestScope = _operationScoped.OperationId;
            OperationIdFromHandlerScope = await httpClient.GetStringAsync("https://example.com");
        }
    }
}
