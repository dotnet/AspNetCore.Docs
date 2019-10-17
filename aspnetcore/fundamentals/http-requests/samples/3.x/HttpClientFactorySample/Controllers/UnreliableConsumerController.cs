using System;
using System.Threading.Tasks;
using HttpClientFactorySample.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactorySample.Controllers
{
    public class UnreliableConsumerController : Controller
    {
        private readonly UnreliableEndpointCallerService _unreliableEndpointCallerService;

        public UnreliableConsumerController(UnreliableEndpointCallerService unreliableEndpointCallerService)
        {
            _unreliableEndpointCallerService = unreliableEndpointCallerService;
        }

        [Route("unreliable-consumer")]
        public async Task<IActionResult> UnreliableEndpointConsumer()
        {
            // Builds a URI to what we will imagine is an external endpoint that is unreliable. For this sample we are hosting our own unreliable endpoint to demonstrate!

            var url = Url.Action("UnreliableEndpoint", "ThirdParty");

            var uriBuilder = new UriBuilder
            {
                Scheme = HttpContext.Request.Scheme,
                Host = HttpContext.Request.Host.Host,
                Port = HttpContext.Request.Host.Port ?? 80,
                Path = url
            };

            // call the typed client that has been registered in ConfigureServices

            var status = await _unreliableEndpointCallerService.GetDataFromUnreliableEndpoint(uriBuilder.Uri.ToString());

            return Ok(status);
        }
    }
}
