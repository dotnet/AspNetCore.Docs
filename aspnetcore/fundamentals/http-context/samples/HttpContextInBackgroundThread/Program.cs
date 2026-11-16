using System.Text.Json;
using HttpContextInBackgroundThread;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHostedService<PeriodicBranchesLoggerService>();

builder.Services.AddHttpClient("GitHub", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");

    // The GitHub API requires two headers. The Use-Agent header is added
    // dynamically through UserAgentHeaderHandler
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/vnd.github.v3+json");
}).AddHttpMessageHandler<UserAgentHeaderHandler>();

builder.Services.AddTransient<UserAgentHeaderHandler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/branches", async (IHttpClientFactory httpClientFactory,
                         HttpContext context, Logger<Program> logger) =>
{
    var httpClient = httpClientFactory.CreateClient("GitHub");
    var httpResponseMessage = await httpClient.GetAsync(
        "repos/dotnet/AspNetCore.Docs/branches");

    if (!httpResponseMessage.IsSuccessStatusCode) 
        return Results.BadRequest();

    await using var contentStream =
        await httpResponseMessage.Content.ReadAsStreamAsync();

    var response = await JsonSerializer.DeserializeAsync
        <IEnumerable<GitHubBranch>>(contentStream);

    app.Logger.LogInformation($"/branches request: " +
                              $"{JsonSerializer.Serialize(response)}");

    return Results.Ok(response);
});

app.Run();
