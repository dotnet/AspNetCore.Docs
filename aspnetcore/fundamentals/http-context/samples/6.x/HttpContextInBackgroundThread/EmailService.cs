namespace HttpContextInBackgroundThread;

public class EmailService : IEmailService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<EmailService> _logger;
    private const string? UserAgent = "Unknown";

    public EmailService(IHttpContextAccessor httpContextAccessor, 
                                     ILogger<EmailService> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public void SendEmail(string email)
    {
        // Services should account for the possibility of HttpContext being null
        // if not called from a request thread. For example, when a service is 
        // called from a BackgroundWorker, the HttpContextcan be null.
        // The service should either throw or gracefully handle a null HttpContext.

        var request = _httpContextAccessor.HttpContext?.Request;
        var userAgent = request?.Headers["user-agent"].ToString()
                                         ?? UserAgent;

        _ = SendEmailCoreAsync(userAgent);
    }

    private async Task SendEmailCoreAsync(string? userAgent)
    {
            _logger.LogInformation($"Email sent detected user agent: {userAgent}");
        
        await Task.CompletedTask;
    }
}
