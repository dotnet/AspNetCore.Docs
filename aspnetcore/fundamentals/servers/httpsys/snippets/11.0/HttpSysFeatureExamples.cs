#nullable enable

using System.Security.Authentication.ExtendedProtection;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.HttpSys;

internal static class HttpSysFeatureExamples
{
    public static void LogCipherSuite(HttpContext context, ILogger logger)
    {
        // <snippet_cipher_suite>
        var handshake = context.Features.Get<ITlsHandshakeFeature>();
        if (handshake?.NegotiatedCipherSuite is { } cipherSuite)
        {
            logger.LogInformation("Negotiated TLS cipher suite: {CipherSuite}", cipherSuite);
        }
        else
        {
            logger.LogInformation("The negotiated TLS cipher suite isn't available.");
        }
        // </snippet_cipher_suite>
    }

    public static void LogClientHello(HttpContext context, ILogger logger)
    {
        // <snippet_client_hello>
        var feature = context.Features.GetRequiredFeature<IHttpSysRequestPropertyFeature>();
        _ = feature.TryGetTlsClientHello(Span<byte>.Empty, out var requiredSize);
        var buffer = new byte[requiredSize];

        if (!feature.TryGetTlsClientHello(buffer, out var bytesReturned))
        {
            throw new InvalidOperationException(
                $"The TLS ClientHello buffer must be resized to {bytesReturned} bytes.");
        }

        logger.LogInformation("Retrieved {ByteCount} TLS ClientHello bytes.", bytesReturned);
        // </snippet_client_hello>
    }

    public static void LogRequestProperty(HttpContext context, ILogger logger)
    {
        // <snippet_request_property>
        const int HttpRequestPropertyTlsClientHello = 11;
        var feature = context.Features.GetRequiredFeature<IHttpSysRequestPropertyFeature>();
        _ = feature.TryGetRequestProperty(
            HttpRequestPropertyTlsClientHello, qualifier: default, output: default,
            out var requiredSize);
        var buffer = new byte[requiredSize];

        if (!feature.TryGetRequestProperty(
            HttpRequestPropertyTlsClientHello, qualifier: default, output: buffer,
            out var bytesReturned))
        {
            throw new InvalidOperationException(
                $"The request property buffer must be resized to {bytesReturned} bytes.");
        }

        logger.LogInformation("Retrieved {ByteCount} native request property bytes.", bytesReturned);
        // </snippet_request_property>
    }

    public static void LogChannelBinding(HttpContext context, ILogger logger)
    {
        // <snippet_channel_binding>
        var tls = context.Features.Get<ITlsConnectionFeature>();
        if (tls is not null &&
            tls.TryGetChannelBindingBytes(ChannelBindingKind.Endpoint, out var token))
        {
            logger.LogInformation("TLS endpoint binding contains {ByteCount} bytes.", token.Length);
        }
        else
        {
            logger.LogInformation("TLS endpoint channel binding isn't available.");
        }
        // </snippet_channel_binding>
    }
}
