using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System.Text.Json;


namespace ScalableRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _env;
        private readonly IHttpClientFactory _httpFactory;

        public IndexModel(IConfiguration env, IHttpClientFactory httpFactory)
        {
            _env = env;
            _httpFactory = httpFactory;
        }

        [BindProperty]
        public string SearchTerm { get; set; }

        public IEnumerable<GitHubRepo> Repos { get; set; } = new List<GitHubRepo>();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var client = _httpFactory.CreateClient();

            var gitHubUrl = $"{_env["GitHubUrl"]}/orgs/{SearchTerm}/repos";

            // GitHub API wants a UserAgent specified
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, gitHubUrl)
            {
                Headers =
                {
                    { HeaderNames.UserAgent, "dotnet" }
                }
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                Repos = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubRepo>>(contentStream);
            }

            return Page();
        }
    }
}