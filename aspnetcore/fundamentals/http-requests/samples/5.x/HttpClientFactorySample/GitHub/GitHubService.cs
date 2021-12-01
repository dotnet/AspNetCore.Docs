#define First

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientFactorySample.GitHub
{
    /// <summary>
    /// Exposes methods to return GitHub API data
    /// </summary>
#if First
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
            return await Client.GetFromJsonAsync<IEnumerable<GitHubIssue>>(
              "/repos/aspnet/AspNetCore.Docs/issues?state=open&sort=created&direction=desc");
        }
    }
    // </snippet1>
#else
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
        // <snippet2>
        public async Task<IEnumerable<GitHubIssue>> GetAspNetDocsIssues()
        {
            return await Client.GetFromJsonAsync<IEnumerable<GitHubIssue>>(
              "/repos/aspnet/AspNetCore.Docs/issues?state=open&sort=created&direction=desc");
        }
        // </snippet2>
    }
#endif
}