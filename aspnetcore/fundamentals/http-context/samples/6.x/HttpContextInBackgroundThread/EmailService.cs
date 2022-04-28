namespace HttpContextInBackgroundThread;

public interface IEmailService
{
    Task SendEmail(EmailMessage email, CancellationToken cancellationToken, string? userAgent = null);
}

public class EmailService : IEmailService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<EmailService> _logger; 
    private readonly IAsyncConcurrentQueue<EmailMessage> _queue;

    public EmailService(IHttpContextAccessor httpContextAccessor, ILogger<EmailService> logger, IAsyncConcurrentQueue<EmailMessage> queue)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
        _queue = queue;
    }

    // The userAgent should come directly from the caller to the service if possible.
    // An explicit parameter makes the API more usable outside of the request flow, is
    // better for performance and is easier to reason about than relying on ambient state.
    public Task SendEmail(EmailMessage email, CancellationToken cancellationToken, string? userAgent = null)
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        string? userAgentString = userAgent ?? request?.Headers["user-agent"].ToString();

        if (string.IsNullOrEmpty(userAgentString))
        {
            userAgentString = "Unknown";
        }

        _queue.Enqueue(new EmailMessage
        {
            UserAgent = userAgentString,
        });

        return Task.CompletedTask;
    }
}
