using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientFactorySample.Handlers
{
    public class SecureRequestHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.RequestUri.Scheme == Uri.UriSchemeHttp)
            {
                var builder = new UriBuilder(request.RequestUri) { Scheme = Uri.UriSchemeHttps };
                request.RequestUri = builder.Uri;
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}