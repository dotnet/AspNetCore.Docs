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

    public EmailService(IHttpContextAccessor httpContextAccessor,
                                     ILogger<EmailService> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public void SendEmail(string email)
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        var userAgent = request?.Headers["user-agent"].ToString()
                                         ?? UserAgent;

        _ = SendEmailCoreAsync(userAgent);
    }

    private async Task SendEmailCoreAsync(string userAgent)
    {
        _logger.LogInformation($"Email sent detected user agent: {userAgent}");

        // SendEmailAsync(...
        await Task.CompletedTask;
    }
}
