namespace HttpContextInBackgroundThread;

public interface IEmailService
{
    void SendEmail(string email);
}

public class EmailService : IEmailService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<EmailService> _logger;
    private const string UserAgent = "Unknown";

    public EmailService(IHttpContextAccessor httpContextAccessor, ILogger<EmailService> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    // The userAgent should come directly from the caller to the service if possible.
    // An explicit parameter makes the API more usable outside of the request flow, is
    // better for performance and is easier to reason about than relying on ambient state.
    public void SendEmail(string email, string? userAgent = null)
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        var userAgent = request?.Headers["user-agent"].ToString();
        if (string.IsNullOrEmpty(userAgent))
        {
            userAgent = "Unkown";
        }

        await _taskQueue.QueueBackgroundWorkItemAsync(cancellationToken => SendEmailCoreAsync(userAgent, cancellationToken));
    }

    private async Task SendEmailCoreAsync(string userAgent)
    {
        _logger.LogInformation($"Email sent detected user agent: {userAgent}");

        // SendEmailAsync(...
        await Task.CompletedTask;
    }
}
