using System.Text.Json;

namespace HttpContextInBackgroundThread;

public class PeriodicBranchesLoggerService : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger _logger;
    private readonly PeriodicTimer _timer;

    public PeriodicBranchesLoggerService(IHttpClientFactory httpClientFactory,
                                         ILogger<PeriodicBranchesLoggerService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(30));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                // Cancel sending the request to sync branches if it takes too long
                // rather than miss sending the next request scheduled 30 seconds from now.
                // Having a single loop prevents this service from sending an unbounded
                // number of requests simultaneously.
                using var syncTokenSource = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
                syncTokenSource.CancelAfter(TimeSpan.FromSeconds(30));
                
                var httpClient = _httpClientFactory.CreateClient("GitHub");
                var httpResponseMessage = await httpClient.GetAsync("repos/dotnet/AspNetCore.Docs/branches",
                                                                    stoppingToken);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    await using var contentStream =
                        await httpResponseMessage.Content.ReadAsStreamAsync(stoppingToken);

                    // Sync the response with preferred datastore.
                    var response = await JsonSerializer.DeserializeAsync<
                        IEnumerable<GitHubBranch>>(contentStream, cancellationToken: stoppingToken);

                    _logger.LogInformation(
                        $"Branch sync successful! Response: {JsonSerializer.Serialize(response)}");
                }
                else
                {
                    _logger.LogError(1, $"Branch sync failed! HTTP status code: {httpResponseMessage.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(1, ex, "Branch sync failed!");
            }
        }
    }

    public override Task StopAsync(CancellationToken stoppingToken)
    {
        // This will cause any active call to WaitForNextTickAsync() to return false immediately.
        _timer.Dispose();
        // This will cancel the stoppingToken and await ExecuteAsync(stoppingToken).
        return base.StopAsync(stoppingToken);
    }
}
