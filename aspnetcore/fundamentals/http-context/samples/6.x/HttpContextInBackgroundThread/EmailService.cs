namespace HttpContextInBackgroundThread;

public interface IEmailService
{
    void SendEmail(string? userAgent = null);
}

public class EmailService : IEmailService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAsyncConcurrentQueue<string> _queue;

    public EmailService(IHttpContextAccessor httpContextAccessor, IAsyncConcurrentQueue<string> queue)
    {
        _httpContextAccessor = httpContextAccessor;
        _queue = queue;
    }

    // The userAgent should come directly from the caller to the service if possible.
    // An explicit parameter makes the API more usable outside of the request flow, is
    // better for performance and is easier to reason about than relying on ambient state.
    public void SendEmail(string? userAgent = null)
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        string? userAgentString = userAgent ?? request?.Headers["user-agent"].ToString();

        if (string.IsNullOrEmpty(userAgentString))
        {
            userAgentString = "Unknown";
        }

        _queue.Enqueue(userAgentString);
    }
}
