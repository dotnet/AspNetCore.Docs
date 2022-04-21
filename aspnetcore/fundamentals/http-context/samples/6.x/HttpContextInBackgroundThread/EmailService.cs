namespace HttpContextInBackgroundThread;

public class EmailService : IEmailService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<EmailService> _logger;
    private const string? BackgroundCorrelationId = "background-correlation-id";

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
        var correlationId = request!.Headers["X-Correlation-Id"].ToString() 
                                                 ?? BackgroundCorrelationId;

        _ = SendEmailCoreAsync(correlationId);
    }

    private async Task SendEmailCoreAsync(string? correlationId)
    {
        _logger.LogInformation($"Email sent with correlation id: {correlationId}");
        await Task.CompletedTask;
    }
}
