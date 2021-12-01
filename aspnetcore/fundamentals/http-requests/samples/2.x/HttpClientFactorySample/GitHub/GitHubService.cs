using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactorySample.GitHub
{
    /// <summary>
    /// Exposes methods to return GitHub API data
    /// </summary>
    // <snippet1>
    public class GitHubService
    {
        public HttpClient Client { get; }

        public GitHubService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.github.com/");
            // GitHub API versioning
            client.DefaultRequestHeaders.Add("Accept", 
                "application/vnd.github.v3+json");
            // GitHub requires a user-agent
            client.DefaultRequestHeaders.Add("User-Agent", 
                "HttpClientFactory-Sample");

            Client = client;
        }

        public async Task<IEnumerable<GitHubIssue>> GetAspNetDocsIssues()
        {
            var response = await Client.GetAsync(
                "/repos/dotnet/AspNetCore.Docs/issues?state=open&sort=created&direction=desc");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<IEnumerable<GitHubIssue>>();

            return result;
        }
    }
    // </snippet1>
}