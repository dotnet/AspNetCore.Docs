using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientFactorySample.GitHub
{
    // <snippet1>
    public class RepoService
    {
        // _httpClient isn't exposed publicly
        private readonly HttpClient _httpClient;

        public RepoService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<string>> GetRepos()
        {
            var response = await _httpClient.GetAsync("aspnet/repos");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<string>>(responseStream);
        }
    }
    // </snippet1>
}