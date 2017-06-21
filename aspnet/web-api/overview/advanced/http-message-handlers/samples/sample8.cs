// .Net 4.5
public class CustomHeaderHandler : DelegatingHandler
{
    async protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
        response.Headers.Add("X-Custom-Header", "This is my custom header.");
        return response;
    }
}