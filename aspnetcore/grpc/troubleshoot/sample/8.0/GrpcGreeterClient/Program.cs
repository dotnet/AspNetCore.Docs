#define StandardHTTPS  // Options: StandardHTTPS | IgnoreInvalidCertificate | IgnoreInvalidCertificateClientFactory | CallInsecureGrpcServices | DotNet3InsecureGrpcServices | SubdirectoryHandler | Http3Handler

#if StandardHTTPS
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
// <snippet_StandardHTTPS>
var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Greeter.GreeterClient(channel);
// </snippet_StandardHTTPS>
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
#endif

#if IgnoreInvalidCertificate
// Warning: Untrusted certificates should only be used during app development. 
// Production apps should always use valid certificates.
// The following gRPC client factory allows calls without a trusted certificate.

using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

// <snippet_IgnoreInvalidCertificate>
var handler = new HttpClientHandler();
handler.ServerCertificateCustomValidationCallback = 
    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

var channel = GrpcChannel.ForAddress("https://localhost:5001",
    new GrpcChannelOptions { HttpHandler = handler });
var client = new Greeter.GreeterClient(channel);
// </snippet_IgnoreInvalidCertificate>

var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
#endif

#if IgnoreInvalidCertificateClientFactory
// Warning: Untrusted certificates should only be used during app development. 
// Production apps should always use valid certificates.
// The following gRPC client factory allows calls without a trusted certificate.

using GrpcGreeterClient;
using Microsoft.Extensions.DependencyInjection;
using Grpc.Net.ClientFactory;

// <snippet_IgnoreInvalidCertificateClientFactory>

var services = new ServiceCollection();

services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        return handler;
    });
// </snippet_IgnoreInvalidCertificateClientFactory>
#endif


#if CallInsecureGrpcServices
using Grpc.Net.Client;
using GrpcGreeterClient;

// <snippet_CallInsecureGrpcServices>
AppContext.SetSwitch(
    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

var channel = GrpcChannel.ForAddress("http://localhost:5000");
var client = new Greeter.GreeterClient(channel);
// </snippet_CallInsecureGrpcServices>
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
#endif

#if DotNet3InsecureGrpcServices
// Warning: Untrusted certificates should only be used during app development. 
// Production apps should always use valid certificates.
// The following gRPC client factory allows calls without a trusted certificate.

using Grpc.Net.Client;
using GrpcGreeterClient;

// <snippet_DotNet3InsecureGrpcServices>
var handler = new HttpClientHandler();
handler.ServerCertificateCustomValidationCallback = 
    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

var channel = GrpcChannel.ForAddress("https://localhost:5001",
    new GrpcChannelOptions { HttpHandler = handler });
var client = new Greeter.GreeterClient(channel);
// </snippet_DotNet3InsecureGrpcServices>

var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
#endif


#if SubdirectoryHandler
using Grpc.Net.Client;
using GrpcGreeterClient;

// <snippet_CallSubdirectoryHandler>
var handler = new SubdirectoryHandler(new HttpClientHandler(), "/MyApp");

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = handler });
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
// </snippet_CallSubdirectoryHandler>
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

/// <summary>
/// A delegating handler that adds a subdirectory to the URI of gRPC requests.
/// </summary>

// <snippet_SubdirectoryHandler>
public class SubdirectoryHandler : DelegatingHandler
{
    private readonly string _subdirectory;

    public SubdirectoryHandler(HttpMessageHandler innerHandler, string subdirectory)
        : base(innerHandler)
    {
        _subdirectory = subdirectory;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var old = request.RequestUri;

        var url = $"{old.Scheme}://{old.Host}:{old.Port}";
        url += $"{_subdirectory}{request.RequestUri.AbsolutePath}";
        request.RequestUri = new Uri(url, UriKind.Absolute);

        return base.SendAsync(request, cancellationToken);
    }
}
// </snippet_SubdirectoryHandler>
#endif

#if Http3Handler
using Grpc.Net.Client;
using GrpcGreeterClient;
using System.Net;

// <snippet_CallHttp3Handler>
var handler = new Http3Handler(new HttpClientHandler());

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = handler });
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
// </snippet_CallHttp3Handler>
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

/// <summary>
/// A delegating handler that changes the request HTTP version to HTTP/3.
/// </summary>

// <snippet_Http3Handler>
public class Http3Handler : DelegatingHandler
{
    public Http3Handler() { }
    public Http3Handler(HttpMessageHandler innerHandler) : base(innerHandler) { }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Version = HttpVersion.Version30;
        request.VersionPolicy = HttpVersionPolicy.RequestVersionExact;

        return base.SendAsync(request, cancellationToken);
    }
}
// </snippet_Http3Handler>
#endif