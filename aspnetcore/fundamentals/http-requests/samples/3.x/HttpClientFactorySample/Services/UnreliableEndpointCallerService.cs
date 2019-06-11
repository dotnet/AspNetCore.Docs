using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactorySample.Services
{
    public class UnreliableEndpointCallerService
    {
        public HttpClient Client { get; }

        public UnreliableEndpointCallerService(HttpClient client)
        {
            // Based on the registration for this typed client in ConfigureServices, this client will use a Polly WaitAndRetry handler.
            Client = client;
        }

        public async Task<string> GetDataFromUnreliableEndpoint(string requestUrl)
        {
            var response = await Client.GetAsync(requestUrl);

            return response.IsSuccessStatusCode ? "Succeeded" : "Failed";
        }
    }
}
