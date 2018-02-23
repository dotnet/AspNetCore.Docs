using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientFactorySample.GitHub
{
    /// <summary>
    /// Exposes methods to return GitHub API data
    /// </summary>
    public class GitHubService
    {
        public HttpClient Client { get; }

        public GitHubService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.github.com/");
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json"); // GitHub API versioning
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample"); // GitHub requires a user-agent

            Client = client;
        }

        public async Task<GitHubIssue> GetLatestDocsIssue()
        {
            using (var stream = await Client.GetStreamAsync("/repos/aspnet/docs/issues?state=open&sort=created&direction=desc"))
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();

                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonToken.StartObject)
                    {
                        var issue = serializer.Deserialize<GitHubIssue>(jsonReader);

                        if (issue != null)
                        { 
                            return issue; // we only want the first object
                        }
                    }
                }
            }

            return null;
        }
    }
}