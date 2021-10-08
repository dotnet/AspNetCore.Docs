---
title: Code samples migrated from ASP.NET Core 5.0 to 6.0
author: rick-anderson
description: Learn how to migrate an ASP.NET Core 5.0 project to ASP.NET Core 6.0.
ms.author: riande
ms.date: 10/15/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/50-to-60-samples
---
# Code samples migrated from ASP.NET Core 5.0 to 6.0

This article provides samples of code migrated from ASP.NET Core 5.0  to ASP.NET Core 6.0.

## Middleware

The following example adds static file middleware to an ASP.NET Core 5 app:

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles();
    }
}
```

The following example adds static file middleware to an ASP.NET Core 6 app:

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_mid)]

For more information, see <xref:fundamentals/middleware/index?view=aspnetcore-6.0>

## Routing

The following example adds an endpoint to an ASP.NET Core 5 app:

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", () => "Hello World");
        });
    }
}
```

In .NET 6, routes can be added directly to the `WebApplication` without an explicit call to `UseEndpoints`. The following example adds an endpoint to an ASP.NET Core 6 app:

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_rt)]

Routes added directly to the `WebApplication` execute at the ***end*** of the pipeline.

<!-- TODO, uncomment when article is updated for .NET 6
For more information, see <xref:fundamentals/routing?view=aspnetcore-6.0>
-->

## Change the content root, app name, and environment

### ASP.NET Core 5

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseEnvironment(Environments.Staging)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>()
                      .UseSetting(WebHostDefaults.ApplicationKey, typeof(Program).Assembly.FullName);
        });
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_root)]

<!-- TODO, uncomment when article is updated for .NET 6
For more information, see <xref:fundamentals/view=aspnetcore-6.0>
-->

## Add configuration providers

### ASP.NET Core 5

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(config =>
        {
            config.AddIniFile("appsettings.ini");
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_conf)]

For more information, see [File configuration providers](xref:fundamentals/configuration/?view=aspnetcore-6.0#file-configuration-provider).

## Add logging providers

### ASP.NET Core 5

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.AddJsonConsole();
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_log)]

For more information, see  <xref:fundamentals/logging/index?view=aspnetcore-6.0#>.
