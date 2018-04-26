using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientFactorySample.GitHub
{
    #region snippet1
    public class RepoService
    {
        private readonly HttpClient _httpClient; // not exposed publically

        public RepoService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<string>> GetRepos()
        {
            var result = await _httpClient.GetAsync("aspnet/repos");

            IEnumerable<string> resultObj = null;

            if (result.IsSuccessStatusCode)
            {
                resultObj = JsonConvert.DeserializeObject<IEnumerable<string>>(await result.Content.ReadAsStringAsync()).ToList();
            }

            return resultObj ?? Array.Empty<string>();
        }
    }
    #endregion
}