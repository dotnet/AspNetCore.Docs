using System.Text.Json;
using HttpContextInBackgroundThread;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHostedService<BranchSyncService>();

builder.Services.AddHttpClient("GitHub", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");

    // using Microsoft.Net.Http.Headers;
    // The GitHub API requires two headers. The Use-Agent header will be added dynamically through UserAgentHeaderHandler
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/vnd.github.v3+json");
}).AddHttpMessageHandler<UserAgentHeaderHandler>();

builder.Services.AddTransient<UserAgentHeaderHandler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/branches", async (IHttpClientFactory httpClientFactory) =>
{
    var httpClient = httpClientFactory.CreateClient("GitHub");
    var httpResponseMessage = await httpClient.GetAsync(
        "repos/dotnet/AspNetCore.Docs/branches");

    if (httpResponseMessage.IsSuccessStatusCode)
    {
        using var contentStream =
            await httpResponseMessage.Content.ReadAsStreamAsync();

        return Results.Ok(await JsonSerializer.DeserializeAsync
            <IEnumerable<GitHubBranch>>(contentStream));
    } else
    {
        return Results.BadRequest();
    }
});

app.Run();
