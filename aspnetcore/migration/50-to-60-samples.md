---
title: Code samples migrated to the new minimal hosting model in 6.0
author: rick-anderson
description: Learn how to migrate ASP.NET Core samples to the new minimal hosting model in 6.0.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.date: 10/22/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/50-to-60-samples
---

# Code samples migrated to the new minimal hosting model in ASP.NET Core 6.0

<!-- 
This content from https://gist.github.com/davidfowl/0e0372c3c1d895c3ce195ba983b1e03d#differences-in-the-hosting-model
 -->

This article provides samples of code migrated to ASP.NET Core 6.0. ASP.NET Core 6.0 uses a new minimal hosting model. For more information, see [New hosting model](xref:migration/50-to-60#nhm).

## Middleware

The following code adds the Static File Middleware to an ASP.NET Core 5 app:

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles();
    }
}
```

The following code adds the Static File Middleware to an ASP.NET Core 6 app:

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_mid)]

[WebApplication.CreateBuilder](xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A) initializes a new instance of the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> class with preconfigured defaults. For more information, see <xref:fundamentals/middleware/index?view=aspnetcore-6.0>

## Routing

The following code adds an endpoint to an ASP.NET Core 5 app:

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

In .NET 6, routes can be added directly to the <xref:Microsoft.AspNetCore.Builder.WebApplication> without an explicit call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> or <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>. The following code adds an endpoint to an ASP.NET Core 6 app:

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_rt)]

**Note:** Routes added directly to the <xref:Microsoft.AspNetCore.Builder.WebApplication> execute at the ***end*** of the pipeline.

<!-- TODO, uncomment when article is updated for .NET 6
For more information, see <xref:fundamentals/routing?view=aspnetcore-6.0>
-->

<a name="ccr"></a>

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
                      .UseSetting(WebHostDefaults.ApplicationKey,
                                  typeof(Program).Assembly.FullName);
        });
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_root)]

<!-- TODO, uncomment the following link when article is updated for .NET 6
For more information, see <xref:fundamentals/index/?view=aspnetcore-6.0>
-->

#### Change the content root, app name, and environment by environment variables or command line

The following table shows the environment variable and command-line argument used to change the content root, app name, and environment:

| feature   | Environment variable | Command-line argument |
| ------------- | ------------- | -- |
| Application name | ASPNETCORE_APPLICATIONNAME  | --applicationName |
| Environment name |  ASPNETCORE_ENVIRONMENT | --environment |
| Content root  | ASPNETCORE_CONTENTROOT  | --contentRoot |

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

For detailed information, see [File configuration providers](xref:fundamentals/configuration/index?view=aspnetcore-6.0#file-configuration-provider) in <xref:fundamentals/configuration/index?view=aspnetcore-6.0>.

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

<a name="cii"></a>

## Customize IHostBuilder or IWebHostBuilder

### Customize IHostBuilder

#### ASP.NET Core 5

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

#### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_hb)]

### Customize IWebHostBuilder

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

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_whb)]

## Change the web root

By default, the web root is relative to the content root in the `wwwroot` folder. Web root is where the static files middleware looks for static files. Web root can be changed by setting the <xref:Microsoft.AspNetCore.Builder.WebApplicationOptions.WebRootPath> property on <xref:Microsoft.AspNetCore.Builder.WebApplicationOptions>:

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

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_wr)]

<a name="cdi"></a>

## Custom dependency injection (DI) container

The following .NET 5 and .NET 6 samples use [Autofac](https://autofac.readthedocs.io/latest/integration/aspnetcore.html)

### ASP.NET Core 5

**Program class**

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

**Startup**

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
    // This method gets called by the runtime. Use this method to add services
    // to the container.
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
            logger.LogInformation($"The application {env.ApplicationName} started" +
                                  $" in the injected {service}"));
    }
}
```

### ASP.NET Core 6

In ASP.NET Core 6:

* There are a few common services available as top level properties on <xref:Microsoft.AspNetCore.Builder.WebApplication>.
* Additional services need to be manually resolved from the `IServiceProvider` via [WebApplication.Services](xref:Microsoft.AspNetCore.Builder.WebApplication.Services).

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_af)]

<a name="twa"></a>

## Test with WebApplicationFactory or TestServer

### ASP.NET Core 5

In the following samples, the test project uses `TestServer` and <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601>. These ship as separate packages that require explicit reference:

#### WebApplicationFactory

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="{Version}" />
</ItemGroup>
```

#### TestServer

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.TestHost" Version="{Version}" />
</ItemGroup>
```

#### ASP.NET Core 5 code

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IHelloService, HelloService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHelloService helloService)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync(helloService.HelloMessage);
            });
        });
    }
}
```

#### With TestServer

```csharp
[Fact]
public async Task HelloWorld()
{
    using var host = Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(builder =>
        {
            // Use the test server and point to the application's startup
            builder.UseTestServer()
                    .UseStartup<WebApplication1.Startup>();
        })
        .ConfigureServices(services =>
        {
            // Replace the service
            services.AddSingleton<IHelloService, MockHelloService>();
        })
        .Build();

    await host.StartAsync();

    var client = host.GetTestClient();

    var response = await client.GetStringAsync("/");

    Assert.Equal("Test Hello", response);
}

class MockHelloService : IHelloService
{
    public string HelloMessage => "Test Hello";
}
```

#### With WebApplicationFactory

```csharp
[Fact]
public async Task HelloWorld()
{
    var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IHelloService, MockHelloService>();
            });
        });

    var client = application.CreateClient();

    var response = await client.GetStringAsync("/");

    Assert.Equal("Test Hello", response);
}

class MockHelloService : IHelloService
{
    public string HelloMessage => "Test Hello";
}
```

### ASP.NET Core 6

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_test)]

#### Project file (.csproj)

The project file can contain one of the following:

```xml
<ItemGroup>
    <InternalsVisibleTo Include="MyTestProject" />
</ItemGroup>
```

Or

```
[assembly: InternalsVisibleTo("MyTestProject")]
```

An alternative solution is to make the `Program` class public. `Program` can be made public with  [Top-level statements](/dotnet/csharp/fundamentals/program-structure/top-level-statements) by defining a `public partial Program` class in the project or in `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

// ... Configure services, routes, etc.

app.Run();

public partial class Program { }
```

```csharp
[Fact]
public async Task HelloWorld()
{
    var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IHelloService, MockHelloService>();
            });
        });

    var client = application.CreateClient();

    var response = await client.GetStringAsync("/");

    Assert.Equal("Test Hello", response);
}

class MockHelloService : IHelloService
{
    public string HelloMessage => "Test Hello";
}
```

The .NET 5 version and .NET 6 version with the `WebApplicationFactory` are identical by design.
