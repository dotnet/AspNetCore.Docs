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

## Add services

### ASP.NET Core 5

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add the memory cache services
        services.AddMemoryCache();

        // Add a custom scoped service
        services.AddScoped<ITodoRepository, TodoRepository>();
    }
}
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_svc)]

For more information, see  <xref:fundamentals/dependency-injection?view=aspnetcore-6.0#>.

## Customize IHostBuilder

### ASP.NET Core 5

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_hb)]

## Customize IWebHostBuilder

### ASP.NET Core 5

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            // Change the HTTP server implementation to be HTTP.sys based.
            webBuilder.UseHttpSys()
                      .UseStartup<Startup>();
        });
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_hb)]

## Change the web root

By default, the web root is relative to the content root in the `wwwroot` folder. Web root is where the static files middleware looks for static files. Web root can be changed by using the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseWebRoot%2A> method on the `WebHost` property:

### ASP.NET Core 5

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            // Look for static files in webroot.
            webBuilder.UseWebRoot("webroot")
                      .UseStartup<Startup>();
        });
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_hb)]

## Custom dependency injection (DI) container

The following .NET 5 and .NET 6 samples use [Autofac](https://autofac.readthedocs.io/latest/integration/aspnetcore.html)

### ASP.NET Core 5

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

```csharp
public class Startup
{
    public void ConfigureContainer(ContainerBuilder containerBuilder)
    {
    }
}
```

### ASP.NET Core 6

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MyApplicationModule()));

var app = builder.Build();
```

## Access additional services

`Startup.Configure`  can inject any service added via the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>.

### ASP.NET Core 5

```csharp
public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IService, Service>();
    }

    // Anything added to the service collection can be injected into Configure.
    public void Configure(IApplicationBuilder app, 
                          IWebHostEnvironment env,
                          IHostApplicationLifetime lifetime,
                          IService service,
                          ILogger<Startup> logger)
    {
        lifetime.ApplicationStarted.Register(() => 
            logger.LogInformation($"The application {env.ApplicationName} started in we injected {service}"));
    }
}
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_hb)]
