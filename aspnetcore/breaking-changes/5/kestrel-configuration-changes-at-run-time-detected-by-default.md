---
title: "Breaking change: Kestrel: Configuration changes at runtime detected by default"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Kestrel: Configuration changes at runtime detected by default"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/419
---
# Kestrel: Configuration changes at runtime detected by default

Kestrel now reacts to changes made to the `Kestrel` section of the project's `IConfiguration` instance (for example, *appsettings.json*) at runtime. To learn more about how to configure Kestrel using *appsettings.json*, see the *appsettings.json* example in [Endpoint configuration](/aspnet/core/fundamentals/servers/kestrel#endpoint-configuration).

Kestrel will bind, unbind, and rebind endpoints as necessary to react to these configuration changes.

For discussion, see issue [dotnet/aspnetcore#22807](https://github.com/dotnet/aspnetcore/issues/22807).

## Version introduced

5.0 Preview 7

## Old behavior

Before ASP.NET Core 5.0 Preview 6, Kestrel didn't support changing configuration at runtime.

In ASP.NET Core 5.0 Preview 6, you could opt in to the now-default behavior of reacting to configuration changes at runtime. Opting in required binding Kestrel's configuration manually:

```csharp
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
                webBuilder.UseKestrel((builderContext, kestrelOptions) =>
                {
                    kestrelOptions.Configure(
                        builderContext.Configuration.GetSection("Kestrel"), reloadOnChange: true);
                });

                webBuilder.UseStartup<Startup>();
            });
}
```

## New behavior

Kestrel reacts to configuration changes at runtime by default. To support that change, <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> calls `KestrelServerOptions.Configure(IConfiguration, bool)` with `reloadOnChange: true` by default.

## Reason for change

The change was made to support endpoint reconfiguration at runtime without completely restarting the server. Unlike with a full server restart, unchanged endpoints aren't unbound even temporarily.

## Recommended action

* For most scenarios in which Kestrel's default configuration section doesn't change at runtime, this change has no impact and no action is needed.
* For scenarios in which Kestrel's default configuration section does change at runtime and Kestrel should react to it, this is now the default behavior.
* For scenarios in which Kestrel's default configuration section changes at runtime and Kestrel shouldn't react to it, you can opt out as follows:

    ```csharp
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
                    webBuilder.UseKestrel((builderContext, kestrelOptions) =>
                    {
                        kestrelOptions.Configure(
                            builderContext.Configuration.GetSection("Kestrel"), reloadOnChange: false);
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
    ```

**Notes:**

This change doesn't modify the behavior of the `KestrelServerOptions.Configure(IConfiguration)` overload, which still defaults to the `reloadOnChange: false` behavior.

It's also important to make sure the configuration source supports reloading. For JSON sources, reloading is configured by calling `AddJsonFile(path, reloadOnChange: true)`. Reloading is already configured by default for *appsettings.json* and *appsettings.{Environment}.json*.

## Affected APIs

<xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A?displayProperty=nameWithType>

<!--

### Category

ASP.NET Core

### Affected APIs

`Overload:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults`

-->
