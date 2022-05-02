namespace HttpContextInBackgroundThread;

public class BulkEmailService : BackgroundService
{
    private readonly ILogger<BulkEmailService> _logger;

    public BulkEmailService(IBackgroundTaskQueue taskQueue,
        ILogger<BulkEmailService> logger)
    {
        TaskQueue = taskQueue;
        _logger = logger;
    }

    public IBackgroundTaskQueue TaskQueue { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Bulk Email Hosted Service is running.");

        await BackgroundProcessing(stoppingToken);
    }

    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var workItem =
                await TaskQueue.DequeueAsync(stoppingToken);

            try
            {
                var userAgent = await workItem(stoppingToken);
                await SendEmailAsync(userAgent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred executing {WorkItem}.", nameof(workItem));
            }
        }
    }

    private Task SendEmailAsync(string userAgent)
    {
        _logger.LogInformation($"Email sent from user agent {userAgent}");
        return Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Bulk Email Hosted Service is stopping.");
        await base.StopAsync(stoppingToken);
    }
}
