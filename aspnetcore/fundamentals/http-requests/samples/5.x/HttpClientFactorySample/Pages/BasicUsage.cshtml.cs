using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HttpClientFactorySample.GitHub;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpClientFactorySample.Pages
{
    // <snippet1>
    public class BasicUsageModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<GitHubBranch> Branches { get; private set; }

        public bool GetBranchesError { get; private set; }

        public BasicUsageModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                Branches = await JsonSerializer.DeserializeAsync
                    <IEnumerable<GitHubBranch>>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
            }
        }
    }
    // </snippet1>
}
