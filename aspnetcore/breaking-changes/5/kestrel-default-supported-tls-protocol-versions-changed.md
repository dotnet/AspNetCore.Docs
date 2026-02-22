---
title: "Breaking change: Kestrel: Default supported TLS protocol versions changed"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Kestrel: Default supported TLS protocol versions changed"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/418
---
# Kestrel: Default supported TLS protocol versions changed

Kestrel now uses the system default TLS protocol versions rather than restricting connections to the TLS 1.1 and TLS 1.2 protocols like it did previously.

This change allows:

* TLS 1.3 to be used by default in environments that support it.
* TLS 1.0 to be used in some environments (such as Windows Server 2016 by default), which is usually [not desirable](/security/engineering/solving-tls1-problem).

For discussion, see issue [dotnet/aspnetcore#22563](https://github.com/dotnet/aspnetcore/issues/22563).

## Version introduced

5.0 Preview 6

## Old behavior

Kestrel required that connections use TLS 1.1 or TLS 1.2 by default.

## New behavior

Kestrel allows the operating system to choose the best protocol to use and to block insecure protocols. <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.SslProtocols%2A?displayProperty=nameWithType> now defaults to `SslProtocols.None` instead of `SslProtocols.Tls12 | SslProtocols.Tls11`.

## Reason for change

The change was made to support TLS 1.3 and future TLS versions by default as they become available.

## Recommended action

Unless your app has a specific reason not to, you should use the new defaults. Verify your system is configured to allow only secure protocols.

To disable older protocols, take one of the following actions:

* Disable older protocols, such as TLS 1.0, system-wide with the [Windows instructions](/dotnet/framework/network-programming/tls#configure-schannel-protocols-in-the-windows-registry). It's currently enabled by default on all Windows versions.
* Manually select which protocols you want to support in code as follows:

    ```csharp
    using System.Security.Authentication;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(kestrelOptions =>
                    {
                        kestrelOptions.ConfigureHttpsDefaults(httpsOptions =>
                        {
                            httpsOptions.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;
                        });
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
    ```

Unfortunately, there's no API to exclude specific protocols.

## Affected APIs

<xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.SslProtocols%2A?displayProperty=nameWithType>

<!--

### Category

ASP.NET Core

### Affected APIs

`P:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions.SslProtocols`

-->
