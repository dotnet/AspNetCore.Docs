using System.Text.Json;

namespace CertAuthSample.Snippets;

// <snippet_Class>
public class SampleHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SampleHttpService(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;

    public async Task<JsonDocument> GetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("namedClient");
        var httpResponseMessage = await httpClient.GetAsync("https://example.com");

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            return JsonDocument.Parse(
                await httpResponseMessage.Content.ReadAsStringAsync());
        }

        throw new ApplicationException($"Status code: {httpResponseMessage.StatusCode}");
    }
}
// </snippet_Class>
