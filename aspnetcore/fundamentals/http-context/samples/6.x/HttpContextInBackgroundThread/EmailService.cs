namespace HttpContextInBackgroundThread;

public interface IEmailService
{
    Task SendEmail(string email, string? userAgent = null);
}

public class EmailService : IEmailService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IHttpContextAccessor httpContextAccessor, ILogger<EmailService> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    // The userAgent should come directly from the caller to the service if possible.
    // An explicit parameter makes the API more usable outside of the request flow, is
    // better for performance and is easier to reason about than relying on ambient state.
    public async Task SendEmail(string email, string? userAgent = null)
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        string ? userAgentString = userAgent ?? request?.Headers["user-agent"].ToString();
        if (string.IsNullOrEmpty(userAgentString))
        {
            userAgentString = "Unkown";
        }

        _ = SendEmailCoreAsync(userAgentString);
        //await _taskQueue.QueueBackgroundWorkItemAsync(cancellationToken => 
        //                           SendEmailCoreAsync(userAgentString, cancellationToken));
    }

    private async Task SendEmailCoreAsync(string userAgent)
    {
        _logger.LogInformation($"Email sent detected user agent: {userAgent}");

        // SendEmailAsync(...
        await Task.CompletedTask;
    }
}
