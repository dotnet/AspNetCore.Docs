using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorPagesProject.Services
{
    public class GithubClient : IGithubClient
    {
        public GithubClient(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }

        public async Task<GithubUser> GetUserAsync(string userName)
        {
            var response = await Client.GetAsync($"/users/{Uri.EscapeDataString(userName)}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<GithubUser>();
        }
    }
}
