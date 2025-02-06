# HTTP/3

## Introduction
YARP 1.1 supports HTTP/3 for inbound and outbound connections using the HTTP/3 support in .NET 7. To enable the HTTP/3 protocol in YARP you need to:
- Configure inbound connections in Kestrel
- Configure outbound connections in HttpClient 

## Set up HTTP/3 on Kestrel

Protocols are required in the listener options:
```C#
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(kestrel =>
{
    kestrel.ListenAnyIP(443, portOptions =>
    {
        portOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        portOptions.UseHttps();
    });
});
```

## HttpClient

The default version of HttpRequest should be replaced by "3", find more details about [HttpRequest configuration](http-client-config.md#httprequest).


