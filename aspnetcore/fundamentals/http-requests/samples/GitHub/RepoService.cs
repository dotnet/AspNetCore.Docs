using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactorySample.GitHub
{
    #region snippet1
    public class RepoService
    {
        private readonly HttpClient _httpClient; // not exposed publicly

        public RepoService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<string>> GetRepos()
        {
            var response = await _httpClient.GetAsync("aspnet/repos");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<string>>();

            return result;
        }
    }
    #endregion
}