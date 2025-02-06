# HTTPS & TLS

HTTPS (HTTP over TLS encrypted connections) is the standard way to make HTTP requests on the Internet for security, integrity, and privacy reasons. There are several HTTPS/TLS considerations to account for when using a reverse proxy like YARP.

## TLS Termination

YARP is a level 7 HTTP proxy which means that incoming HTTPS/TLS connections are fully decrypted by the proxy so it can process and forward the HTTP requests. This is commonly known as TLS Termination. The outgoing connections to the destination(s) may or may not be encrypted, depending on the configuration provided.

## TLS tunneling (CONNECT)

TLS tunneling using the CONNECT method is a feature used to proxy requests without decrypting them. This is _not_ supported by YARP and there are no plans to add it.

## Configuring incoming connections

YARP can run on top of all ASP.NET Core servers and configuring HTTPS/TLS for incoming connections is server specific. Check the docs for [Kestrel](https://docs.microsoft.com/aspnet/core/fundamentals/servers/kestrel/endpoints#listenoptionsusehttps), [IIS](https://docs.microsoft.com/iis/manage/configuring-security/how-to-set-up-ssl-on-iis), and [Http.Sys](https://docs.microsoft.com/aspnet/core/fundamentals/servers/httpsys#configure-windows-server-1) for configuration details.

### Advanced TLS filters with Kestrel

Kestrel supports intercepting incoming connections before the TLS handshake. YARP includes a [TlsFrameHelper](xref:Yarp.ReverseProxy.Utilities.Tls.TlsFrameHelper) API that can parse the raw TLS handshake and enable you to gather custom telemetry or eagerly reject connections. These APIs cannot modify the TLS handshake or decrypt the data stream. See this [example](https://github.com/microsoft/reverse-proxy/blob/v1.0.0-rc.1/testassets/ReverseProxy.Direct/TlsFilter.cs).

## Configuring outgoing connections

To enable TLS encryption when communicating with a destination specify the destination address as `https` like `"https://destinationHost"`. See the [configuration docs](config-files.md#configuration-structure) for examples.

The host name specified in the destination address will be used for the TLS handshake by default, including SNI and server certificate validation. If proxying the [original host header](transforms.md#requestheaderoriginalhost) is enabled, that value will be used for the TLS handshake instead. If a custom host value needs to be used then use the [RequestHeader](transforms.md#requestheader) transform to set the host header.

Outbound connections to the destinations are handled by HttpClient/SocketsHttpHandler. A different instance and settings can be configured per cluster. Some settings are available in the configuration model, while others can only be configured in code. See the [HttpClient](http-client-config.md) docs for details.

Destination server certificates need to be trusted by the proxy or custom validation needs to be applied via the [HttpClient](http-client-config.md) configuration.
