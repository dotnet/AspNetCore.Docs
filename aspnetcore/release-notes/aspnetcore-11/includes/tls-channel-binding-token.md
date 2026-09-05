### TLS channel-binding token access from `ITlsConnectionFeature`

Applications using TLS can read the connection's channel binding token to defend against relay attacks:

```csharp
using System.Security.Authentication.ExtendedProtection;

app.Use(async (context, next) =>
{
    var tls = context.Features.Get<ITlsConnectionFeature>();
    if (tls is not null && tls.TryGetChannelBindingBytes(
            ChannelBindingKind.Endpoint,
            out ReadOnlyMemory<byte> cbt))
    {
        // Compare cbt against the token the client presented during authentication.
    }

    await next(context);
});
```

Kestrel returns the binding from `SslStream.TransportContext.GetChannelBinding`. IIS and HTTP.sys return it from the request. On HTTP.sys, `HttpSysOptions.HttpAuthenticationHardeningLevel` controls Extended Protection and channel-binding token exposure:

* `Legacy` disables channel-binding validation and doesn't expose the token.
* `Medium`, the default, exposes the token and validates it when supplied, but tolerates its absence.
* `Strict` requires the token for authenticated requests and rejects requests without one. It also fails startup if the OS can't apply the configuration, while `Legacy` and `Medium` log the configuration failure and continue.
