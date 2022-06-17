using Microsoft.Net.Http.Headers;

namespace HttpContextInBackgroundThread;

public class UserAgentHeaderHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger _logger;

    public UserAgentHeaderHandler(IHttpContextAccessor httpContextAccessor,
                                  ILogger<UserAgentHeaderHandler> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> 
                                    SendAsync(HttpRequestMessage request, 
                                    CancellationToken cancellationToken)
    {
        var contextRequest = _httpContextAccessor.HttpContext?.Request;
        string? userAgentString = contextRequest?.Headers["user-agent"].ToString();
        
        if (string.IsNullOrEmpty(userAgentString))
        {
            userAgentString = "Unknown";
        }

        request.Headers.Add(HeaderNames.UserAgent, userAgentString);
        _logger.LogInformation($"User-Agent: {userAgentString}");

        return await base.SendAsync(request, cancellationToken);
    }
}
