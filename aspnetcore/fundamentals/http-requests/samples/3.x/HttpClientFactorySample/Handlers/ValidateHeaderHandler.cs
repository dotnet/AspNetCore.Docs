using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientFactorySample.Handlers
{
    // <snippet1>
    public class ValidateHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("X-API-KEY"))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        "You must supply an API key header called X-API-KEY")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
    // </snippet1>
}