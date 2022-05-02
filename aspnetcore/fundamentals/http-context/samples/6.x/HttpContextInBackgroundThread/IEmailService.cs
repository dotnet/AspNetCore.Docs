namespace HttpContextInBackgroundThread;

public interface IEmailService
{
    Task SendEmail(CancellationToken token, string? userAgent = null);
}
