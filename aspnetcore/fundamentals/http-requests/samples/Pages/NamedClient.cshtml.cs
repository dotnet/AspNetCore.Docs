using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientFactorySample.GitHub;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HttpClientFactorySample.Pages
{
    #region snippet1
    public class NamedClientModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<GitHubPullRequest> PullRequests { get; private set; }

        public NamedClientModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "repos/aspnet/docs/pulls");

            var client = _clientFactory.CreateClient("github");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                PullRequests = JsonConvert.DeserializeObject<IEnumerable<GitHubPullRequest>>(data);
            }
            else
            {
                PullRequests = Array.Empty<GitHubPullRequest>();
            }
        }
    }
    #endregion
}