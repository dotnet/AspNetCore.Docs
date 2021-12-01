using HttpRequestsSample.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpRequestsSample.Pages;

public class OperationModel : PageModel
{
    private readonly IOperationScoped _operationScoped;
    private readonly IHttpClientFactory _httpClientFactory;

    public OperationModel(IOperationScoped operationScoped, IHttpClientFactory httpClientFactory) =>
        (_operationScoped, _httpClientFactory) = (operationScoped, httpClientFactory);

    public string OperationIdFromRequestScope { get; set; } = string.Empty;

    public string OperationIdFromHandlerScope { get; set; } = string.Empty;

    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("Operation");

        OperationIdFromRequestScope = _operationScoped.OperationId;
        OperationIdFromHandlerScope = await httpClient.GetStringAsync("https://example.com");
    }
}
