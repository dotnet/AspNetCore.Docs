---
title: "WebHostBuilder, IWebHost, and WebHost are obsolete"
description: "Learn about the breaking change in ASP.NET Core 10 where WebHostBuilder, IWebHost, and WebHost are marked as obsolete."
ms.date: 09/05/2025
ai-usage: ai-generated
ms.custom: https://github.com/aspnet/Announcements/issues/526
---

# WebHostBuilder, IWebHost, and WebHost are obsolete

<xref:Microsoft.AspNetCore.Hosting.WebHostBuilder>, <xref:Microsoft.AspNetCore.Hosting.IWebHost>, and <xref:Microsoft.AspNetCore.WebHost> have been marked as obsolete in .NET 10. `WebHostBuilder` was replaced by `HostBuilder` ([generic host](/aspnet/core/fundamentals/host/generic-host)) in ASP.NET Core 3.0, and `WebApplicationBuilder` was introduced in ASP.NET Core 6.0. These newer alternatives are where future investments will occur.

## Version introduced

.NET 10 RC 1

## Previous behavior

Previously, you could use `WebHostBuilder` to configure and build a web host without any compile-time warnings.

## New behavior

Starting in .NET 10, using `WebHostBuilder` produces a compiler warning with diagnostic ID `ASPDEPR004`:

> warning ASPDEPR004: WebHostBuilder is deprecated in favor of HostBuilder and WebApplicationBuilder. For more information, visit <https://aka.ms/aspnet/deprecate/004>.

Using `IWebHost` or `WebHost` produces a compiler warning with diagnostic ID `ASPDEPR008`:

> warning ASPDEPR008: WebHost is obsolete. Use HostBuilder or WebApplicationBuilder instead. For more information, visit <https://aka.ms/aspnet/deprecate/008>.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

`HostBuilder` and <xref:Microsoft.AspNetCore.Builder.WebApplication> have all the features of `WebHostBuilder` and are the focus of future investment. `WebHostBuilder` was replaced by the generic host in ASP.NET Core 3.0, and minimal APIs with <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> were introduced in ASP.NET Core 6.0. These newer hosting models provide better integration with the .NET ecosystem and are the recommended approach for new applications.

## Recommended action

Migrate from `WebHostBuilder` to either [`HostBuilder`](/aspnet/core/fundamentals/host/generic-host) or [`WebApplication`](/aspnet/core/fundamentals/minimal-apis/webapplication):

- For applications that need the full hosting capabilities, migrate to `HostBuilder`:

  **Before:**

  ```csharp
  var hostBuilder = new WebHostBuilder()
      .UseContentRoot(Directory.GetCurrentDirectory())
      .UseStartup()
      .UseKestrel();
  // Test code might use TestServer:
  var testServer = new TestServer(hostBuilder);
  ```

  **After:**

  ```csharp
  using var host = new HostBuilder()
      .ConfigureWebHost(webHostBuilder =>
      {
          webHostBuilder
              .UseTestServer() // If using TestServer.
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseStartup()
              .UseKestrel();
      })
      .Build();
  await host.StartAsync();

  var testServer = host.GetTestServer();
  ```

- For new applications, especially those using minimal APIs, migrate to <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder>.

## Affected APIs

- <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Hosting.IWebHost?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.WebHost?displayProperty=fullName>

## See also

- [Generic Host in ASP.NET Core](/aspnet/core/fundamentals/host/generic-host)
- [Minimal APIs with WebApplication](/aspnet/core/fundamentals/minimal-apis/webapplication)
- [HostBuilder replaces WebHostBuilder](/aspnet/core/migration/22-to-30#hostbuilder-replaces-webhostbuilder)
- [Introducing WebApplication](/aspnet/core/migration/50-to-60#new-hosting-model)
