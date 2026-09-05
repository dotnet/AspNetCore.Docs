### TLS handshake observability in Kestrel

Two related changes make it easier to diagnose and customize TLS connections in Kestrel.

`ITlsHandshakeFeature` now exposes an `Exception` property containing the exception thrown during a failed TLS handshake, so middleware and logging can record why a connection failed instead of seeing a bare `IOException` further up the stack. The feature continues to work after the handshake fails — Kestrel snapshots the relevant fields off the underlying `SslStream` before it is disposed.

The `TlsClientHelloBytesCallback` option on `HttpsConnectionAdapterOptions` was reworked as a connection middleware. The previous callback shape is now obsolete; configure ClientHello inspection via the new `ListenOptions.UseTlsClientHelloListener` extension instead. The example below uses both features together — connection middleware reads `ITlsHandshakeFeature.Exception` after the handshake, and `UseTlsClientHelloListener` inspects the ClientHello before TLS:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.Use(next => async context =>
        {
            await next(context);

            var tlsHandshakeFeature = context.Features.Get<ITlsHandshakeFeature>();
            if (tlsHandshakeFeature?.Exception is { } ex)
            {
                Console.WriteLine($"[TLS Handshake Failed] ConnectionId={context.ConnectionId}, Exception={ex.GetType().Name}: {ex.Message}");
            }
        });

        // UseTlsClientHelloListener must be called before UseHttps()
        listenOptions.UseTlsClientHelloListener((connection, clientHelloBytes) =>
        {
            Console.WriteLine($"TLS Client Hello received on {connection.ConnectionId}, {clientHelloBytes.Length} bytes");
        });
        listenOptions.UseHttps();
    });
});
```
