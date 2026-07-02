---
title: Dependency injection in ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
description: Learn how ASP.NET Core implements dependency injection and how to use it.
ms.author: tdykstra
ms.custom: mvc
ms.date: 03/06/2026
uid: fundamentals/dependency-injection
---
# Dependency injection in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Kirk Larkin](https://twitter.com/serpent5), [Steve Smith](https://ardalis.com/), and [Brandon Dahler](https://github.com/brandondahler)

ASP.NET Core supports the dependency injection (DI) software design pattern, which is a technique for achieving [Inversion of Control (IoC)](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#dependency-inversion) between classes and their dependencies.

This article provides information on DI in ASP.NET Core web apps. For information on DI in all types of apps, including apps other than web apps, see [Dependency injection in .NET](/dotnet/core/extensions/dependency-injection/overview).

Guidance that adds to or supersedes the guidance in this article is found the following articles:

* <xref:blazor/fundamentals/dependency-injection>
* <xref:mvc/controllers/dependency-injection>
* [Use DI services to configure options](xref:fundamentals/configuration/options#use-di-services-to-configure-options)

Code examples in this article are based on [Blazor](xref:blazor/index). To see Razor Pages examples, see the [7.0 version of this article](?view=aspnetcore-7.0&preserve-view=true).

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/dependency-injection) ([how to download](xref:fundamentals/index#how-to-download-a-sample))

When using the sample code in this article in a local Blazor Web App for demonstration purposes, adopt an [interactive render mode](xref:blazor/components/render-modes).

## Overview of dependency injection

A *dependency* is an object that another object depends on. Consider the following `MyDependency` class with a `WriteMessage` method:

```csharp
public class MyDependency
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"MyDependency.WriteMessage: {message}");
    }
}
```

:::moniker range=">= aspnetcore-8.0"

A class can create an instance of the `MyDependency` class to call its `WriteMessage` method. In the following example, the `MyDependency` class is a dependency of a Razor component.

`Pages/DependencyExample1.razor`:

```razor
@page "/dependency-example-1"

<button @onclick="WriteMessage">Write message</button>

@code {
    private readonly MyDependency dependency = new MyDependency();

    private void WriteMessage() =>
        dependency.WriteMessage("DependencyExample1.WriteMessage called");
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

A class can create an instance of the `MyDependency` class to call its `WriteMessage` method. In the following example, the `MyDependency` class is a dependency of an `IndexModel` page class.

`Pages/Index.cshtml.cs`:

```csharp
public class IndexModel : PageModel
{
    private readonly MyDependency _dependency = new MyDependency();

    public void OnGet()
    {
        _dependency.WriteMessage("IndexModel.OnGet called");
    }
}
```

:::moniker-end

The consuming class creates and directly depends on the `MyDependency` class. Taking a direct dependency, such as in the previous example, is problematic and should be avoided for the following reasons:

* To replace `MyDependency` with a different implementation, the consuming class must be modified.
* If `MyDependency` has dependencies, they must also be configured by the consuming class. In a large project with multiple classes depending on `MyDependency`, the configuration code becomes scattered around the app.
* The implementation is difficult to [unit test](/dotnet/core/testing/#unit-tests).

DI addresses these problems through:

* The use of an interface or base class to abstract the dependency implementation.
* Registration of the dependency in a *service container*, also called a *DI container*. ASP.NET Core provides a built-in service container, <xref:System.IServiceProvider>. Services are typically registered in the app's `Program` file (.NET 6 or later) or the app's `Startup` file (.NET 5 or earlier).
* *Injection* of the service into classes where it's used. The framework creates instances of dependencies and disposes of them when they're no longer required.

In the following example, the `IMyDependency` interface defines the `WriteMessage` method signature.

`Interfaces/IMyDependency.cs`:

```csharp
public interface IMyDependency
{
    void WriteMessage(string message);
}
```

The preceding interface is implemented by the following concrete type, `MyDependency`.

`Services/MyDependency.cs`:

```csharp
public class MyDependency : IMyDependency
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"MyDependency.WriteMessage: {message}");
    }
}
```

The app registers the `IMyDependency` service with the concrete type `MyDependency` where services are added to the service container, usually either in the `Program` file (.NET 6 or later) or `Startup.ConfigureServices` method (.NET 5 or earlier). The <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped%2A> method registers the service with a scoped lifetime, which is the lifetime of a [Blazor circuit](xref:blazor/hosting-models#blazor-server) (.NET 8 or later) or a single request in an MVC or Razor Pages app. [Service lifetimes](#service-lifetimes) are described later in this article.

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddScoped<IMyDependency, MyDependency>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddScoped<IMyDependency, MyDependency>();
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

The `IMyDependency` service is requested and used to call the `WriteMessage` method, as the following Razor component demonstrates.

`Pages/DependencyExample2.razor`:

```razor
@page "/dependency-example-2"
@inject IMyDependency Dependency

<button @onclick="WriteMessage">Write message</button>

@code {
    private void WriteMessage() =>
        Dependency.WriteMessage("DependencyExample2.WriteMessage called");
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The `IMyDependency` service is requested and used to call the `WriteMessage` method, as the following page model class demonstrates.

`Pages/Index.cshtml.cs`:

```csharp
public class IndexModel(IMyDependency dependency) : PageModel
{
    public void OnGet()
    {
        dependency.WriteMessage("IndexModel.OnGet called");
    }
}
```

:::moniker-end

By using the DI pattern, the class that consumes the dependency:

* Doesn't use the concrete type `MyDependency`, only the `IMyDependency` interface it implements. That makes it easy to change the implementation without modifying the consumer.
* Doesn't directly create an instance of `MyDependency` or dispose of it. The dependency is created and disposed by the service container.

The `IMyDependency` interface implementation can be improved by using the built-in [logging API](xref:fundamentals/logging/index), which is injected as a dependency in the following example.

`Services/MyDependency.cs`:

```csharp
public class MyDependency(ILogger<MyDependency> logger) : IMyDependency
{
    public void WriteMessage(string message)
    {
        logger.LogInformation($"MyDependency.WriteMessage: {message}");
    }
}
```

`MyDependency` depends on <xref:Microsoft.Extensions.Logging.ILogger%601>, a [framework-provided service](#framework-provided-services).

It's common to use DI in a chained fashion. Each requested dependency in turn requests its own dependencies. The container resolves the dependencies in the graph and returns the fully resolved service. The collective set of dependencies that must be resolved is typically referred to as a *dependency tree*, *dependency graph*, or *object graph*.

The container resolves <xref:Microsoft.Extensions.Logging.ILogger%601> by taking advantage of [(generic) open types](/dotnet/csharp/language-reference/language-specification/types#843-open-and-closed-types), eliminating the need to register every [(generic) constructed type](/dotnet/csharp/language-reference/language-specification/types#84-constructed-types).

In DI terminology, a service:

* Is typically an object that provides a service to other objects, such as the preceding `IMyDependency` service.
* Isn't related to a web service, although the service might use a web service.

The `IMyDependency` implementations shown in the preceding examples were written to demonstrate general DI principles, not to implement logging. Most apps shouldn't need to create loggers, as the preceding examples show. The following code demonstrates directly using the [framework's built-in logging API](xref:fundamentals/logging/index), which doesn't require the registration of a custom service (`IMyDependency`).

:::moniker range=">= aspnetcore-8.0"

`Pages/LoggingExample.razor`:

```razor
@page "/logging-example"
@inject ILogger<LoggingExample> Logger

<button @onclick="WriteMessage">Write message</button>

@code {
    private void WriteMessage() => 
        Logger.LogInformation("LoggingExample.WriteMessage called");
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

`Pages/IndexModel.cshtml.cs`:

```csharp
public class IndexModel(ILogger<IndexModel> logger) : PageModel
{ 
    public void OnGet()
    {
        logger.LogInformation("IndexModel.OnGet called");
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

## Services injected into `Startup`

Services can be injected into the `Startup` constructor and the `Startup.Configure` method.

The Generic Host (<xref:Microsoft.Extensions.Hosting.IHostBuilder>) of ASP.NET Core 3.0 or later, uses a single service container throughout the app's lifecycle after a temporary "root" service provider uses essential services for the host to start and configure the app's main service container. Most services, including custom services and framework services not involved in host startup, aren't configured or available in the service container when the `Startup` constructor is called. Only the following services can be injected into the `Startup` constructor when using the Generic Host:

* <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment>
* <xref:Microsoft.Extensions.Hosting.IHostEnvironment>
* <xref:Microsoft.Extensions.Configuration.IConfiguration>

By restricting the available services available in the `Startup` class constructor, the Generic Host prevents you from trying to use a service before it's created or available and from creating multiple instances of custom or framework singleton services, where a singleton service created in the temporary service container could be different from one created in the final service container.

Any service registered with the service container can be injected into the `Startup.Configure` method. In the following example, an <xref:Microsoft.Extensions.Logging.ILogger%601> is injected:

```csharp
public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
{
    ...
}
```

For more information, see <xref:fundamentals/startup> and [Access configuration in Startup](xref:fundamentals/configuration/index#access-configuration-in-startup).

:::moniker-end

## Service registration methods

For general guidance on service registrations, see [Service registration](/dotnet/core/extensions/dependency-injection/service-registration).

It's common to use multiple implementations when mocking types for testing. For more information, see <xref:test/integration-tests#inject-mock-services>.

Registering a service with only an implementation type is equivalent to registering the service with the same implementation and service type:

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddSingleton<MyDependency>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddSingleton<MyDependency>();
```

:::moniker-end

Service registration methods can be used to register multiple service instances of the same service type. In the following example, <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A> is called twice with `IMyDependency` as the service type. The second call to `AddSingleton` overrides the previous one when resolved as `IMyDependency` and adds to the previous one when multiple services are resolved via `IEnumerable<IMyDependency>`.

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddSingleton<IMyDependency, MyDependency>();
builder.Services.AddSingleton<IMyDependency, DifferentDependency>();

public class MyService
{
    public MyService(IMyDependency myDependency, 
       IEnumerable<IMyDependency> myDependencies)
    {
        Trace.Assert(myDependency is DifferentDependency);

        var dependencyArray = myDependencies.ToArray();
        Trace.Assert(dependencyArray[0] is MyDependency);
        Trace.Assert(dependencyArray[1] is DifferentDependency);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddSingleton<IMyDependency, MyDependency>();
services.AddSingleton<IMyDependency, DifferentDependency>();

public class MyService
{
    public MyService(IMyDependency myDependency, 
       IEnumerable<IMyDependency> myDependencies)
    {
        Trace.Assert(myDependency is DifferentDependency);

        var dependencyArray = myDependencies.ToArray();
        Trace.Assert(dependencyArray[0] is MyDependency);
        Trace.Assert(dependencyArray[1] is DifferentDependency);
    }
}
```

:::moniker-end

## Register groups of services with extension methods

The ASP.NET Core framework convention for registering a group of related services is to use a single `Add{GROUP NAME}` extension method to register all of the services required by a framework feature, where the `{GROUP NAME}` placeholder is a descriptive group name. For example, the <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A> extension method registers services required for server-side rendering of Razor components.

Consider the following example that configures options and registers services:

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.Configure<PositionOptions>(
    builder.Configuration.GetSection(PositionOptions.Position));
builder.Services.Configure<ColorOptions>(
    builder.Configuration.GetSection(ColorOptions.Color));

builder.Services.AddScoped<IMyDependency, MyDependency>();
builder.Services.AddScoped<IMyDependency2, MyDependency2>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.Configure<PositionOptions>(
    builder.Configuration.GetSection(PositionOptions.Position));
services.Configure<ColorOptions>(
    builder.Configuration.GetSection(ColorOptions.Color));

services.AddScoped<IMyDependency, MyDependency>();
services.AddScoped<IMyDependency2, MyDependency2>();
```

:::moniker-end

Related groups of registrations can be moved to an extension method to register services. In the following example:

* The `AddConfig` extension method binds configuration data to strongly-typed C# classes and registers the classes in the service container.
* The `AddDependencyGroup` extension method adds additional class (service) dependencies.

```csharp
namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigServiceCollectionExtensions
{
    public static IServiceCollection AddConfig(
        this IServiceCollection services, IConfiguration config)
    {
        services.Configure<PositionOptions>(
            config.GetSection(PositionOptions.Position));
        services.Configure<ColorOptions>(
            config.GetSection(ColorOptions.Color));

        return services;
    }

    public static IServiceCollection AddDependencyGroup(
        this IServiceCollection services)
    {
        services.AddScoped<IMyDependency, MyDependency>();
        services.AddScoped<IMyDependency2, MyDependency2>();

        return services;
    }
}
```

The following code calls the preceding `AddConfig` and `AddDependencyGroup` extension methods to register the services:

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services
    .AddConfig(builder.Configuration)
    .AddDependencyGroup();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services
    .AddConfig(builder.Configuration)
    .AddDependencyGroup();
```

:::moniker-end

We recommend that apps follow the naming convention of creating extension methods in the <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> namespace, which:

* Encapsulates groups of service registrations.
* Provides convenient [IntelliSense](/visualstudio/ide/using-intellisense) access to the service.

## Service lifetimes

For general guidance on service lifetimes, see [Service lifetimes](/dotnet/core/extensions/dependency-injection/service-lifetimes). For additional service lifetime guidance that applies to Blazor apps, see <xref:blazor/fundamentals/dependency-injection#utility-base-component-classes-to-manage-a-di-scope>.

To use scoped services in middleware, use one of the following approaches:

* Inject the service into the middleware's `Invoke` or `InvokeAsync` method. Using [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) throws a runtime exception because it forces the scoped service to behave like a singleton. The sample in the [Lifetime and registration options](#lifetime-and-registration-options) section demonstrates the `InvokeAsync` approach.
* Use [factory-based middleware](xref:fundamentals/middleware/extensibility). Middleware registered using this approach is activated per client request (connection), which allows scoped services to be injected into the middleware's constructor.

For more information, see the following resources:

* <xref:fundamentals/middleware/write#per-request-middleware-dependencies>
* For more information on using keyed services with Razor components, see <xref:blazor/fundamentals/dependency-injection#service-lifetime>.

:::moniker range=">= aspnetcore-8.0"

## Keyed services

*Keyed services* registers and retrieves services using keys. A service is associated with a key by calling any of the following extension methods for service registration:

* <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddKeyedSingleton%2A>
* <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddKeyedScoped%2A>
* <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddKeyedTransient%2A>

The following example demonstrates keyed services with the following API:

* `IStringCache` is the service interface with a `Get` method signature.
* `StringCache1` and `StringCache2` are concrete service implementations for `IStringCache`.

`Interfaces/IStringCache.cs`:

```csharp
public interface IStringCache
{
    string Get(int key);
}
```

`Services/StringCache1.cs`:

```csharp
public class StringCache1 : IStringCache
{
    public string Get(int key) => $"Resolving {key} from StringCache1.";
}
```

`Services/StringCache2.cs`:

```csharp
public class StringCache2 : IStringCache
{
    public string Get(int key) => $"Resolving {key} from StringCache2.";
}
```

Access a registered service by specifying the key with the [`[FromKeyedServices]` attribute](xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute).

Keyed service and example Minimal API endpoints in the `Program` file:

```csharp
builder.Services.AddKeyedSingleton<IStringCache, StringCache1>("cache1");
builder.Services.AddKeyedSingleton<IStringCache, StringCache2>("cache2");

...

app.MapGet("/cache1", ([FromKeyedServices("cache1")] IStringCache stringCache1) => 
    stringCache1.Get(1));
app.MapGet("/cache2", ([FromKeyedServices("cache2")] IStringCache stringCache2) =>
    stringCache2.Get(2));
```

Example use in a Razor componment (`Pages/KeyedServicesExample.razor`) using the `[Inject]` attribute. Use the <xref:Microsoft.AspNetCore.Components.InjectAttribute.Key?displayProperty=nameWithType> property to specify the key for the service to inject:

```razor
@page "/keyed-services-example"

@Cache?.Get(3)

@code {
    [Inject(Key = "cache1")]
    public IStringCache? Cache { get; set; }
}
```

For more information on using keyed services with Razor components, see <xref:blazor/fundamentals/dependency-injection#inject-keyed-services-into-components>.

Example use in a SignalR hub (`Hubs/MyHub1.cs`) with primary constructor injection:

```csharp
using Microsoft.AspNetCore.SignalR;

public class MyHub1([FromKeyedServices("cache2")] IStringCache cache) : Hub
{
    public void Method()
    {
        Console.WriteLine(cache.Get(4));
    }
}
```

Example use in a SignalR hub (`Hubs/MyHub2.cs`) with method injection:

```csharp
using Microsoft.AspNetCore.SignalR;

public class MyHub2 : Hub
{
    public void Method([FromKeyedServices("cache2")] IStringCache cache)
    {
        Console.WriteLine(cache.Get(5));
    }
}
```

Middleware supports keyed services in both the middleware's constructor and its `Invoke`/`InvokeAsync` method:

```csharp
internal class MyMiddleware
{
    private readonly RequestDelegate _next;

    public MyMiddleware(RequestDelegate next,
        [FromKeyedServices("cache1")] IStringCache cache)
    {
        _next = next;

        Console.WriteLine(cache.Get(6));
    }

    public Task Invoke(HttpContext context,
        [FromKeyedServices("cache2")] IStringCache cache)
        {
            Console.WriteLine(cache.Get(7));

            return _next(context);
        } 
}
```

In the app processing pipeline of the `Program` file (.NET 6 or later) or the `Startup.Configure` method (.NET 5 or earlier):

```csharp
app.UseMiddleware<MyMiddleware>();
```

For more information on creating middleware, see <xref:fundamentals/middleware/write>.

:::moniker-end

## Constructor injection behavior

For more information on constructor injection behavior, see the following resources:

* [Constructor injection behavior](/dotnet/core/extensions/dependency-injection/overview#constructor-injection-behavior)
* <xref:blazor/fundamentals/dependency-injection#constructor-injection>

## Entity Framework contexts

For guidance on EF Core in server-side Blazor apps, see <xref:blazor/blazor-ef-core>.

By default, Entity Framework contexts are added to the service container using the [scoped lifetime](#service-lifetimes) because web app database operations are normally scoped to the client request. To use a different lifetime, specify the lifetime by using an <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> overload. Services of a given lifetime shouldn't use a database context with a lifetime that's shorter than the service's lifetime.

## Lifetime and registration options

To demonstrate the difference between service lifetimes and their registration options, consider the following interfaces that represent a task as an operation with an identifier, `OperationId`. Depending on how the lifetime of an operation's service is configured for the following interfaces, the container provides either the same or different instances of the service when requested by a class.

`IOperation.cs`:

```csharp
public interface IOperation
{
    string OperationId { get; }
}

public interface IOperationTransient : IOperation { }
public interface IOperationScoped : IOperation { }
public interface IOperationSingleton : IOperation { }
```

The following `Operation` class implements all of the preceding interfaces. The `Operation` constructor generates a GUID and stores the last four characters in the `OperationId` property.

`Operation.cs`:

```csharp
public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
{
    public Operation()
    {
        OperationId = Guid.NewGuid().ToString()[^4..];
    }

    public string OperationId { get; }
}
```

The following code creates multiple registrations of the `Operation` class according to the named lifetimes.

Where services are registered:

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddTransient<IOperationTransient, Operation>();
services.AddScoped<IOperationScoped, Operation>();
services.AddSingleton<IOperationSingleton, Operation>();
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

The following example demonstrates object lifetimes both within and between requests. The `Operation` component and the middleware request each kind of `IOperation` type and log the `OperationId` for each.

`Pages/OperationExample.razor`:

```razor
@page "/operation-example"
@inject IOperationTransient TransientOperation
@inject IOperationScoped ScopedOperation
@inject IOperationSingleton SingletonOperation

<ul>
    <li>Transient: @TransientOperation.OperationId</li>
    <li>Scoped: @ScopedOperation.OperationId</li>
    <li>Singleton: @SingletonOperation.OperationId</li>
</ul>
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The following example demonstrates object lifetimes both within and between requests. The `IndexModel` and the middleware request each kind of `IOperation` type and log the `OperationId` for each.

`IndexModel.cshtml.cs`:

```csharp
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IOperationTransient _transientOperation;
    private readonly IOperationScoped _scopedOperation;
    private readonly IOperationSingleton _singletonOperation;

    public IndexModel(ILogger<IndexModel> logger,
        IOperationTransient transientOperation,
        IOperationScoped scopedOperation,
        IOperationSingleton singletonOperation)
    {
        _logger = logger;
        _transientOperation = transientOperation;
        _scopedOperation = scopedOperation;
        _singletonOperation = singletonOperation;
    }

    public void OnGet()
    {
        _logger.LogInformation($"Transient: {_transientOperation.OperationId}");
        _logger.LogInformation($"Scoped: {_scopedOperation.OperationId}");
        _logger.LogInformation($"Singleton: {_singletonOperation.OperationId}");
    }
}
```

:::moniker-end

Middleware can also resolve and use the same services. Scoped and transient services must be resolved in the `InvokeAsync` method.

`MyMiddleware.cs`:

:::moniker range=">= aspnetcore-8.0"

```csharp
public class MyMiddleware(ILogger<IndexModel> logger,
    IOperationSingleton singletonOperation)
{
    public async Task InvokeAsync(HttpContext context,
        IOperationTransient transientOperation, IOperationScoped scopedOperation)
    {
        logger.LogInformation($"Transient: {transientOperation.OperationId}");
        logger.LogInformation($"Scoped: {scopedOperation.OperationId}");
        logger.LogInformation($"Singleton: {singletonOperation.OperationId}");

        await _next(context);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class MyMiddleware
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IOperationSingleton _singletonOperation;

    public MyMiddleware(ILogger<IndexModel> logger,
        IOperationSingleton singletonOperation)
    {
        _logger = logger;
        _singletonOperation = singletonOperation;
    }

    public async Task InvokeAsync(HttpContext context,
        IOperationTransient transientOperation, IOperationScoped scopedOperation)
    {
        _logger.LogInformation($"Transient: {transientOperation.OperationId}");
        _logger.LogInformation($"Scoped: {scopedOperation.OperationId}");
        _logger.LogInformation($"Singleton: {_singletonOperation.OperationId}");

        await _next(context);
    }
}
```

:::moniker-end

In the app processing pipeline of the `Program` file (.NET 6 or later) or the `Startup.Configure` method (.NET 5 or earlier):

```csharp
app.UseMiddleware<MyMiddleware>();
```

For more information on creating middleware, see <xref:fundamentals/middleware/write>.

Output from the preceding examples shows:

:::moniker range=">= aspnetcore-8.0"

* *Transient* objects are always different. The transient `OperationId` value is different for the Razor component and in the middleware.
* *Scoped* objects are the same for a given request but differ across new Blazor circuits.
* *Singleton* objects are the same for every request or Blazor circuit.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* *Transient* objects are always different. The transient `OperationId` value is different for the page and in the middleware.
* *Scoped* objects are the same for a given request but differ across new requests.
* *Singleton* objects are the same for every request.

:::moniker-end

## Resolve a service at app startup

The following code shows how to resolve a scoped service for a limited duration when the app starts:

```csharp
var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var dependency = services.GetRequiredService<IMyDependency>();
    dependency.WriteMessage("Call services from main");
}
```

## Scope validation

For guidance on scope validation, see the following resources:

* [.NET dependency injection: Scope validation](/dotnet/core/extensions/dependency-injection/overview#scope-validation)
* [ASP.NET Core Web Host: Scope validation](xref:fundamentals/host/web-host#scope-validation)

## Request Services

Services and their dependencies within an ASP.NET Core request are exposed through <xref:Microsoft.AspNetCore.Http.HttpContext.RequestServices?displayProperty=nameWithType>.

The framework creates a scope per request, and `RequestServices` exposes the scoped service provider. All scoped services are valid for as long as the request is active.

> [!NOTE]
> Prefer requesting dependencies as constructor parameters over resolving services from `RequestServices`. Requesting dependencies as constructor parameters yields classes that are easier to test.

## Design services for dependency injection

When designing services for DI:

* Avoid stateful, static classes and members. Avoid creating global state by designing apps to use singleton services instead.
* Avoid direct instantiation of dependent classes within services. Direct instantiation couples the code to a particular implementation.
* Make services small, well-factored, and easily tested.

If a class has many injected dependencies, it might be a sign that the class has too many responsibilities and violates the [Single Responsibility Principle (SRP)](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#single-responsibility). Attempt to refactor the class by moving some of its responsibilities into new classes. Keep in mind that Razor Pages page model classes and MVC controller classes should focus on UI concerns.

### Disposal of services

The container calls <xref:System.IDisposable.Dispose%2A> for the <xref:System.IDisposable> types it creates. Services resolved from the container should never be disposed by the developer. If a type or factory is registered as a singleton, the container disposes the singleton automatically.

In the following example, the services are created by the service container and disposed automatically.

`Services/Service1.cs`:

```csharp
public class Service1 : IDisposable
{
    private bool _disposed;

    public void Write(string message)
    {
        Console.WriteLine($"Service1: {message}");
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        Console.WriteLine("Service1.Dispose");
        _disposed = true;

        GC.SuppressFinalize(this);
    }
}
```

`Services/Service2.cs`:

```csharp
public class Service2 : IDisposable
{
    private bool _disposed;

    public void Write(string message)
    {
        Console.WriteLine($"Service2: {message}");
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        Console.WriteLine("Service2.Dispose");
        _disposed = true;

        GC.SuppressFinalize(this);
    }
}
```

`Services/Service3.cs`:

```csharp
public interface IService3
{
    public void Write(string message);
}

public class Service3(string myKey) : IService3, IDisposable
{
    private bool _disposed;

    public void Write(string message)
    {
        Console.WriteLine($"Service3: {message}, Key = {myKey}");
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        Console.WriteLine("Service3.Dispose");
        _disposed = true;

        GC.SuppressFinalize(this);
    }
}
```

In `appsettings.Development.json`:

```json
"Key": "Value from appsettings.Development.json"
```

Where services are registered by the app:

:::moniker range=">= aspnetcore-8.0"

```csharp
builder.Services.AddScoped<Service1>();
builder.Services.AddSingleton<Service2>();

var key = builder.Configuration["Key"] ?? string.Empty;
builder.Services.AddSingleton<IService3>(sp => new Service3(key));
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
services.AddScoped<Service1>();
services.AddSingleton<Service2>();

var myKey = builder.Configuration["Key"] ?? string.Empty;
services.AddSingleton<IService3>(sp => new Service3(myKey));
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

`Pages/DisposalExample.razor`:

```razor
@page "/disposal-example"
@inject Service1 Service1
@inject Service2 Service2
@inject IService3 Service3

@code {
    protected override void OnInitialized()
    {
        Service1.Write("DisposalExample.OnInitialized");
        Service2.Write("DisposalExample.OnInitialized");
        Service3.Write("DisposalExample.OnInitialized");
    }
}
```

The debug console shows the following output after each refresh of the Index page:

```console
Service1: DisposalExample.OnInitialized
Service2: DisposalExample.OnInitialized
Service3: DisposalExample.OnInitialized, Key = Value from appsettings.Development.json
Service1.Dispose
```

To see the entry for the disposal of `Service1`, navigate away from the `DisposalExample` component to trigger its disposal.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

`Pages/Index.cshtml.cs`:

```csharp
public class IndexModel(
    Service1 service1, Service2 service2, IService3 service3) 
    : PageModel
{
    public void OnGet()
    {
        service1.Write("IndexModel.OnGet");
        service2.Write("IndexModel.OnGet");
        service3.Write("IndexModel.OnGet");
    }
}
```

The debug console shows the following output after each refresh of the Index page:

```console
Service1: IndexModel.OnGet
Service2: IndexModel.OnGet
Service3: IndexModel.OnGet, Key = Value from appsettings.Development.json
Service1.Dispose
```

:::moniker-end

### Services not created by the service container

Consider the following code:

:::moniker range=">= aspnetcore-8.0"

```csharp
builder.Services.AddSingleton(new Service1());
builder.Services.AddSingleton(new Service2());
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
services.AddSingleton(new Service1());
services.AddSingleton(new Service2());
```

:::moniker-end

For the preceding code:

* The service instances aren't created by the service container.
* The framework doesn't dispose of the services automatically.
* The developer is responsible for disposing of the services.

### `IDisposable` guidance for transient and shared instances

For more information, see [Dependency injection in .NET: IDisposable guidance for transient and shared instance](/dotnet/core/extensions/dependency-injection/guidelines#idisposable-guidance-for-transient-and-shared-instances).

## Default service container replacement

For more information, see [Dependency injection in .NET: Default service container replacement](/dotnet/core/extensions/dependency-injection/guidelines#default-service-container-replacement).

## Recommendations

For more information, see [Dependency injection guidelines: Recommendations](/dotnet/core/extensions/dependency-injection/guidelines#recommendations).

Avoid using the *service locator pattern*. For example, don't invoke <xref:System.IServiceProvider.GetService%2A> to obtain a service instance when you can use DI instead:

**Incorrect:**

![Incorrect code](~/fundamentals/dependency-injection/_static/bad.png)

**Correct**:

```csharp
public class MyClass(IOptionsMonitor<MyOptions> optionsMonitor)
{
    public void MyMethod()
    {
        var option = optionsMonitor.CurrentValue.Option;

        ...
    }
}
```

Another service locator variation to avoid is injecting a factory that resolves dependencies at runtime. Both of these practices mix [Inversion of Control](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#dependency-inversion) strategies.

Avoid static access to <xref:Microsoft.AspNetCore.Http.HttpContext> (for example, <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor.HttpContext%2A?displayProperty=nameWithType>).

DI is an *alternative* to static/global object access patterns. You might not be able to realize the benefits of DI if you mix it with static object access.

## Recommended patterns for multitenancy in dependency injection

[Orchard Core](https://github.com/OrchardCMS/OrchardCore) is an app framework for building modular, multitenant apps on ASP.NET Core. For more information, see the [Orchard Core Documentation](https://docs.orchardcore.net).

For examples of how to build modular and multitenant apps using just the Orchard Core Framework without its CMS-specific features, see the [Orchard Core samples](https://github.com/OrchardCMS/OrchardCore.Samples).

## Framework-provided services

The `Program` file (.NET 6 or later) or the `Startup` file (.NET 5 or earlier) registers services that the app uses, including platform features, such as Entity Framework Core and services to support Razor components in Blazor (.NET 8 or later). Initially, the `IServiceCollection` has services defined by the framework depending on [how the host was configured](xref:fundamentals/index#host). For apps based on the ASP.NET Core templates, the framework registers more than 250 services.

The following table describes a small sample of framework-registered services:

Service type | Lifetime
--- | ---
<xref:Microsoft.AspNetCore.Hosting.Builder.IApplicationBuilderFactory?displayProperty=fullName> | Transient
<xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> | Singleton
<xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> | Singleton
<xref:Microsoft.AspNetCore.Hosting.IStartup?displayProperty=fullName> | Singleton
<xref:Microsoft.AspNetCore.Hosting.IStartupFilter?displayProperty=fullName> | Transient
<xref:Microsoft.AspNetCore.Hosting.Server.IServer?displayProperty=fullName> | Singleton
<xref:Microsoft.AspNetCore.Http.IHttpContextFactory?displayProperty=fullName> | Transient
<xref:Microsoft.Extensions.Logging.ILogger%601?displayProperty=fullName> | Singleton
<xref:Microsoft.Extensions.Logging.ILoggerFactory?displayProperty=fullName> | Singleton
<xref:Microsoft.Extensions.ObjectPool.ObjectPoolProvider?displayProperty=fullName> | Singleton
<xref:Microsoft.Extensions.Options.IConfigureOptions%601?displayProperty=fullName> | Transient
<xref:Microsoft.Extensions.Options.IOptions%601?displayProperty=fullName> | Singleton
<xref:System.Diagnostics.DiagnosticSource?displayProperty=fullName> | Singleton
<xref:System.Diagnostics.DiagnosticListener?displayProperty=fullName> | Singleton

## Additional resources

* <xref:blazor/fundamentals/dependency-injection>
* <xref:mvc/views/dependency-injection>
* <xref:mvc/controllers/dependency-injection>
* <xref:security/authorization/dependencyinjection>
* [NDC Conference Patterns for DI app development](https://www.youtube.com/watch?v=x-C-CNBVTaY)
* <xref:fundamentals/startup>
* <xref:fundamentals/middleware/extensibility>
* [Understand dependency injection basics in .NET](/dotnet/core/extensions/dependency-injection/basics)
* [Dependency injection guidelines](/dotnet/core/extensions/dependency-injection/guidelines)
* [Tutorial: Use dependency injection in .NET](/dotnet/core/extensions/dependency-injection/usage)
* [.NET dependency injection](/dotnet/core/extensions/dependency-injection/overview)
* [ASP.NET Core Dependency Injection: What is the IServiceCollection?](https://www.stevejgordon.co.uk/aspnet-core-dependency-injection-what-is-the-iservicecollection)
* [Four ways to dispose IDisposables in ASP.NET Core](https://andrewlock.net/four-ways-to-dispose-idisposables-in-asp-net-core/)
* [Writing Clean Code in ASP.NET Core with Dependency Injection (MSDN)](/archive/msdn-magazine/2016/may/asp-net-writing-clean-code-in-asp-net-core-with-dependency-injection)
* [Explicit Dependencies Principle](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#explicit-dependencies)
* [Inversion of Control Containers and the Dependency Injection Pattern (Martin Fowler)](https://www.martinfowler.com/articles/injection.html)
* [How to register a service with multiple interfaces in ASP.NET Core DI (Andrew Lock)](https://andrewlock.net/how-to-register-a-service-with-multiple-interfaces-for-in-asp-net-core-di/)
* [Avoiding Startup service injection in ASP.NET Core 3 (Andrew Lock)](https://andrewlock.net/avoiding-startup-service-injection-in-asp-net-core-3/)
