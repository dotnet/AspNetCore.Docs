namespace HttpContextInBackgroundThread;

public class EmailService : IEmailService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IBackgroundTaskQueue _taskQueue;

    public EmailService(IHttpContextAccessor httpContextAccessor, IBackgroundTaskQueue taskQueue)
    {
        _httpContextAccessor = httpContextAccessor;
        _taskQueue = taskQueue;
    }

    // The userAgent should come directly from the caller to the service if possible.
    // An explicit parameter makes the API more usable outside of the request flow, is
    // better for performance and is easier to reason about than relying on ambient state.
    public Task SendEmail(CancellationToken token, string? userAgent = null)
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        string? userAgentString = userAgent ?? request?.Headers["user-agent"].ToString();

        if (string.IsNullOrEmpty(userAgentString))
        {
            userAgentString = "Unknown";
        }

        _taskQueue.QueueBackgroundWorkItemAsync(cancellationToken =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    return new ValueTask<string>(userAgentString);
                }
                catch (OperationCanceledException)
                {
                    // throw if cancellation is requested
                }
            }

            return default;
        });

        return Task.CompletedTask;
    }
}
