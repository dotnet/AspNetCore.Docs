using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddTransient<GitHubService>();
    })
    .Build();

try
{
    var gitHubService = host.Services.GetRequiredService<GitHubService>();
    var gitHubBranches = await gitHubService.GetAspNetCoreDocsBranchesAsync();

    Console.WriteLine($"{gitHubBranches?.Count() ?? 0} GitHub Branches");

    if (gitHubBranches is not null)
    {
        foreach (var gitHubBranch in gitHubBranches)
        {
            Console.WriteLine($"- {gitHubBranch.Name}");
        }
    }
}
catch (Exception ex)
{
    host.Services.GetRequiredService<ILogger<Program>>()
        .LogError(ex, "Unable to load branches from GitHub.");
}

public class GitHubService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GitHubService(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

    public async Task<IEnumerable<GitHubBranch>?> GetAspNetCoreDocsBranchesAsync()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches")
        {
            Headers =
            {
                { "Accept", "application/vnd.github.v3+json" },
                { "User-Agent", "HttpRequestsConsoleSample" }
            }
        };

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        httpResponseMessage.EnsureSuccessStatusCode();

        using var contentStream =
            await httpResponseMessage.Content.ReadAsStreamAsync();
        
        return await JsonSerializer.DeserializeAsync
            <IEnumerable<GitHubBranch>>(contentStream);
    }
}

public record GitHubBranch(
    [property: JsonPropertyName("name")] string Name);
