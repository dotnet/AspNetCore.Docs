---
title: ASP.NET Core Blazor dependency injection
author: guardrex
description: Learn how Blazor apps can inject services into components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/dependency-injection
---
# ASP.NET Core Blazor dependency injection

By [Rainer Stropek](https://www.timecockpit.com) and [Mike Rousos](https://github.com/mjrousos)

This article explains how Blazor apps can inject services into components.

:::moniker range=">= aspnetcore-6.0"

[Dependency injection (DI)](xref:fundamentals/dependency-injection) is a technique for accessing services configured in a central location:

* Framework-registered services can be injected directly into components of Blazor apps.
* Blazor apps define and register custom services and make them available throughout the app via DI.

## Default services

The services shown in the following table are commonly used in Blazor apps.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Scoped | <p>Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</p><p>The instance of <xref:System.Net.Http.HttpClient> in a Blazor WebAssembly app uses the browser for handling the HTTP traffic in the background.</p><p>Blazor Server apps don't include an <xref:System.Net.Http.HttpClient> configured as a service by default. Provide an <xref:System.Net.Http.HttpClient> to a Blazor Server app.</p><p>For more information, see <xref:blazor/call-web-api>.</p><p>An <xref:System.Net.Http.HttpClient> is registered as a scoped service, not singleton. For more information, see the [Service lifetime](#service-lifetime) section.</p> |
| <xref:Microsoft.JSInterop.IJSRuntime> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p> | Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet>. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p> | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers). |

A custom service provider doesn't automatically provide the default services listed in the table. If you use a custom service provider and require any of the services shown in the table, add the required services to the new service provider.

## Add services to a Blazor WebAssembly app

Configure services for the app's service collection in `Program.cs`. In the following example, the `ExampleDependency` implementation is registered for `IExampleDependency`:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
...
builder.Services.AddSingleton<IExampleDependency, ExampleDependency>();
...

await builder.Build().RunAsync();
```

After the host is built, services are available from the root DI scope before any components are rendered. This can be useful for running initialization logic before rendering content:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
...
builder.Services.AddSingleton<WeatherService>();
...

var host = builder.Build();

var weatherService = host.Services.GetRequiredService<WeatherService>();
await weatherService.InitializeWeatherAsync();

await host.RunAsync();
```

The host provides a central configuration instance for the app. Building on the preceding example, the weather service's URL is passed from a default configuration source (for example, `appsettings.json`) to `InitializeWeatherAsync`:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
...
builder.Services.AddSingleton<WeatherService>();
...

var host = builder.Build();

var weatherService = host.Services.GetRequiredService<WeatherService>();
await weatherService.InitializeWeatherAsync(
    host.Configuration["WeatherServiceUrl"]);

await host.RunAsync();
```

## Add services to a Blazor Server app

After creating a new app, examine part of the `Program.cs` file:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
```

The `builder` variable represents a `Microsoft.AspNetCore.Builder.WebApplicationBuilder` with an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>, which is a list of [service descriptor](xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor) objects. Services are added by providing service descriptors to the service collection. The following example demonstrates the concept with the `IDataAccess` interface and its concrete implementation `DataAccess`:

```csharp
builder.Services.AddSingleton<IDataAccess, DataAccess>();
```

## Register common services in a hosted Blazor WebAssembly solution

If one or more common services are required by the **`Server`** and **`Client`** projects of a hosted Blazor WebAssembly solution, you can place the common service registrations in a method in the **`Client`** project and call the method to register the services in both projects.

First, factor common service registrations into a separate method. For example, create a `ConfigureCommonServices` method in the **`Client`** project:

```csharp
public static void ConfigureCommonServices(IServiceCollection services)
{
    services.Add...;
}
```

In the **`Client`** project's `Program.cs` file, call `ConfigureCommonServices` to register the common services:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

...

ConfigureCommonServices(builder.Services);
```

In the **`Server`** project's `Program.cs` file, call `ConfigureCommonServices` to register the common services for the **`Server`** project:

```csharp
var builder = WebApplication.CreateBuilder(args);

...

Client.Program.ConfigureCommonServices(builder.Services);
```

For an example of this approach, see <xref:blazor/security/webassembly/additional-scenarios#support-prerendering-with-authentication>.

## Service lifetime

Services can be configured with the lifetimes shown in the following table.

| Lifetime | Description |
| -------- | ----------- |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped%2A> | <p>Blazor WebAssembly apps don't currently have a concept of DI scopes. `Scoped`-registered services behave like `Singleton` services.</p><p>The Blazor Server hosting model supports the `Scoped` lifetime across HTTP requests but not across SignalR connection/circuit messages among components that are loaded on the client. The Razor Pages or MVC portion of the app treats scoped services normally and recreates the services on *each HTTP request* when navigating among pages or views or from a page or view to a component. Scoped services aren't reconstructed when navigating among components on the client, where the communication to the server takes place over the SignalR connection of the user's circuit, not via HTTP requests. In the following component scenarios on the client, scoped services are reconstructed because a new circuit is created for the user:</p><ul><li>The user closes the browser's window. The user opens a new window and navigates back to the app.</li><li>The user closes a tab of the app in a browser window. The user opens a new tab and navigates back to the app.</li><li>The user selects the browser's reload/refresh button.</li></ul><p>For more information on preserving user state across scoped services in Blazor Server apps, see <xref:blazor/hosting-models?pivots=server>.</p> |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton%2A> | DI creates a *single instance* of the service. All components requiring a `Singleton` service receive the same instance of the service. |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient%2A> | Whenever a component obtains an instance of a `Transient` service from the service container, it receives a *new instance* of the service. |

The DI system is based on the DI system in ASP.NET Core. For more information, see <xref:fundamentals/dependency-injection>.

## Request a service in a component

After services are added to the service collection, inject the services into the components using the [`@inject`](xref:mvc/views/razor#inject) Razor directive, which has two parameters:

* Type: The type of the service to inject.
* Property: The name of the property receiving the injected app service. The property doesn't require manual creation. The compiler creates the property.

For more information, see <xref:mvc/views/dependency-injection>.

Use multiple [`@inject`](xref:mvc/views/razor#inject) statements to inject different services.

The following example shows how to use [`@inject`](xref:mvc/views/razor#inject). The service implementing `Services.IDataAccess` is injected into the component's property `DataRepository`. Note how the code is only using the `IDataAccess` abstraction:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_Server/Pages/dependency-injection/CustomerList.razor?highlight=2,19)]

Internally, the generated property (`DataRepository`) uses the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute). Typically, this attribute isn't used directly. If a base class is required for components and injected properties are also required for the base class, manually add the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute):

```csharp
using Microsoft.AspNetCore.Components;

public class ComponentBase : IComponent
{
    [Inject]
    protected IDataAccess DataRepository { get; set; }

    ...
}
```

> [!NOTE]
> Since injected services are expected to be available, don't mark injected services as nullable. Instead, assign a default literal with the null-forgiving operator (`default!`). For example:
>
> ```csharp
> [Inject]
> private IExampleService ExampleService { get; set; } = default!;
> ```
>
> For more information, see the following resources:
>
> * [Nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis)
> * [Nullable reference types (C# guide)](/dotnet/csharp/nullable-references)
> * [default value expressions (C# reference)](/dotnet/csharp/language-reference/operators/default#default-literal)
> * [! (null-forgiving) operator (C# reference)](/dotnet/csharp/language-reference/operators/null-forgiving)

In components derived from the base class, the [`@inject`](xref:mvc/views/razor#inject) directive isn't required. The <xref:Microsoft.AspNetCore.Components.InjectAttribute> of the base class is sufficient:

```razor
@page "/demo"
@inherits ComponentBase

<h1>Demo Component</h1>
```

## Use DI in services

Complex services might require additional services. In the following example, `DataAccess` requires the <xref:System.Net.Http.HttpClient> default service. [`@inject`](xref:mvc/views/razor#inject) (or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute)) isn't available for use in services. *Constructor injection* must be used instead. Required services are added by adding parameters to the service's constructor. When DI creates the service, it recognizes the services it requires in the constructor and provides them accordingly. In the following example, the constructor receives an <xref:System.Net.Http.HttpClient> via DI. <xref:System.Net.Http.HttpClient> is a default service.

```csharp
using System.Net.Http;

public class DataAccess : IDataAccess
{
    public DataAccess(HttpClient http)
    {
        ...
    }
}
```

Prerequisites for constructor injection:

* One constructor must exist whose arguments can all be fulfilled by DI. Additional parameters not covered by DI are allowed if they specify default values.
* The applicable constructor must be `public`.
* One applicable constructor must exist. In case of an ambiguity, DI throws an exception.

## Utility base component classes to manage a DI scope

In ASP.NET Core apps, scoped services are typically scoped to the current request. After the request completes, any scoped or transient services are disposed by the DI system. In Blazor Server apps, the request scope lasts for the duration of the client connection, which can result in transient and scoped services living much longer than expected. In Blazor WebAssembly apps, services registered with a scoped lifetime are treated as singletons, so they live longer than scoped services in typical ASP.NET Core apps.

> [!NOTE]
> To detect disposable transient services in an app, see the following sections:
>
> [Detect transient disposables in Blazor WebAssembly apps](#detect-transient-disposables-in-blazor-webassembly-apps)
> [Detect transient disposables in Blazor Server apps](#detect-transient-disposables-in-blazor-server-apps)

An approach that limits a service lifetime in Blazor apps is use of the <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type. <xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract type derived from <xref:Microsoft.AspNetCore.Components.ComponentBase> that creates a DI scope corresponding to the lifetime of the component. Using this scope, it's possible to use DI services with a scoped lifetime and have them live as long as the component. When the component is destroyed, services from the component's scoped service provider are disposed as well. This can be useful for services that:

* Should be reused within a component, as the transient lifetime is inappropriate.
* Shouldn't be shared across components, as the singleton lifetime is inappropriate.

Two versions of the <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type are available:

* <xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract, disposable child of the <xref:Microsoft.AspNetCore.Components.ComponentBase> type with a protected <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property of type <xref:System.IServiceProvider>. This provider can be used to resolve services that are scoped to the lifetime of the component.

  DI services injected into the component using [`@inject`](xref:mvc/views/razor#inject) or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute) aren't created in the component's scope. To use the component's scope, services must be resolved using <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> or <xref:System.IServiceProvider.GetService%2A>. Any services resolved using the <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> provider have their dependencies provided from that same scope.

  [!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/dependency-injection/Preferences.razor?highlight=3,23-24)]

* <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601> derives from <xref:Microsoft.AspNetCore.Components.OwningComponentBase> and adds a <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601.Service%2A> property that returns an instance of `T` from the scoped DI provider. This type is a convenient way to access scoped services without using an instance of <xref:System.IServiceProvider> when there's one primary service the app requires from the DI container using the component's scope. The <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property is available, so the app can get services of other types, if necessary.

  ```razor
  @page "/users"
  @attribute [Authorize]
  @inherits OwningComponentBase<AppDbContext>

  <h1>Users (@Service.Users.Count())</h1>

  <ul>
      @foreach (var user in Service.Users)
      {
          <li>@user.UserName</li>
      }
  </ul>
  ```

## Use of an Entity Framework Core (EF Core) DbContext from DI

For more information, see <xref:blazor/blazor-server-ef-core>.

## Detect transient disposables in Blazor WebAssembly apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs` for Blazor WebAssembly apps:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs)]

`TransientDisposable.cs`:

```csharp
public class TransientDisposable : IDisposable
{
    public void Dispose() => throw new NotImplementedException();
}
```

The `TransientDisposable` in the following example is detected.

`Program.cs`:

```csharp
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWebAssemblyTransientDisposable;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.DetectIncorrectUsageOfTransients();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<TransientDisposable>();
builder.Services.AddScoped(sp => 
    new HttpClient
    { 
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

var host = builder.Build();
host.EnableTransientDisposableDetection();
await host.RunAsync();
```

The app can register transient disposables without throwing an exception. However, attempting to resolve a transient disposable results in an <xref:System.InvalidOperationException>, as the following example shows.

`Pages/TransientExample.razor`:

```razor
@page "/transient-example"
@inject TransientDisposable TransientDisposable

<h1>Transient Disposable Detection</h1>
```

Navigate to the `TransientExample` component at `/transient-example` and an <xref:System.InvalidOperationException> is thrown when the framework attempts to construct an instance of `TransientDisposable`:

> System.InvalidOperationException: Trying to resolve transient disposable service TransientDisposable in the wrong scope. Use an 'OwningComponentBase\<T>' component base class for the service 'T' you are trying to resolve.

## Detect transient disposables in Blazor Server apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_Server/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs)]

`TransitiveTransientDisposableDependency.cs`:

```csharp
public class TransitiveTransientDisposableDependency 
    : ITransitiveTransientDisposableDependency, IDisposable
{
    public void Dispose() { }
}

public interface ITransitiveTransientDisposableDependency
{
}

public class TransientDependency
{
    private readonly ITransitiveTransientDisposableDependency 
        transitiveTransientDisposableDependency;

    public TransientDependency(ITransitiveTransientDisposableDependency 
        transitiveTransientDisposableDependency)
    {
        this.transitiveTransientDisposableDependency = 
            transitiveTransientDisposableDependency;
    }
}
```

The `TransientDependency` in the following example is detected.

In `Program.cs`:

```csharp
builder.DetectIncorrectUsageOfTransients();
builder.Services.AddTransient<TransientDependency>();
builder.Services.AddTransient<ITransitiveTransientDisposableDependency, 
    TransitiveTransientDisposableDependency>();
```

The app can register transient disposables without throwing an exception. However, attempting to resolve a transient disposable results in an <xref:System.InvalidOperationException>, as the following example shows.

`Pages/TransientExample.razor`:

```razor
@page "/transient-example"
@inject TransientDependency TransientDependency

<h1>Transient Disposable Detection</h1>
```

Navigate to the `TransientExample` component at `/transient-example` and an <xref:System.InvalidOperationException> is thrown when the framework attempts to construct an instance of `TransientDependency`:

> System.InvalidOperationException: Trying to resolve transient disposable service TransientDependency in the wrong scope. Use an 'OwningComponentBase\<T>' component base class for the service 'T' you are trying to resolve.

## Additional resources

* <xref:fundamentals/dependency-injection>
* [`IDisposable` guidance for Transient and shared instances](xref:fundamentals/dependency-injection#idisposable-guidance-for-transient-and-shared-instances)
* <xref:mvc/views/dependency-injection>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

[Dependency injection (DI)](xref:fundamentals/dependency-injection) is a technique for accessing services configured in a central location:

* Framework-registered services can be injected directly into components of Blazor apps.
* Blazor apps define and register custom services and make them available throughout the app via DI.

## Default services

The services shown in the following table are commonly used in Blazor apps.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Scoped | <p>Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</p><p>The instance of <xref:System.Net.Http.HttpClient> in a Blazor WebAssembly app uses the browser for handling the HTTP traffic in the background.</p><p>Blazor Server apps don't include an <xref:System.Net.Http.HttpClient> configured as a service by default. Provide an <xref:System.Net.Http.HttpClient> to a Blazor Server app.</p><p>For more information, see <xref:blazor/call-web-api>.</p><p>An <xref:System.Net.Http.HttpClient> is registered as a scoped service, not singleton. For more information, see the [Service lifetime](#service-lifetime) section.</p> |
| <xref:Microsoft.JSInterop.IJSRuntime> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p> | Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet>. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p> | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers). |

A custom service provider doesn't automatically provide the default services listed in the table. If you use a custom service provider and require any of the services shown in the table, add the required services to the new service provider.

## Add services to a Blazor WebAssembly app

Configure services for the app's service collection in `Program.cs`. In the following example, the `ExampleDependency` implementation is registered for `IExampleDependency`:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        ...
        builder.Services.AddSingleton<IExampleDependency, ExampleDependency>();
        ...

        await builder.Build().RunAsync();
    }
}
```

After the host is built, services are available from the root DI scope before any components are rendered. This can be useful for running initialization logic before rendering content:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        ...
        builder.Services.AddSingleton<WeatherService>();
        ...

        var host = builder.Build();

        var weatherService = host.Services.GetRequiredService<WeatherService>();
        await weatherService.InitializeWeatherAsync();

        await host.RunAsync();
    }
}
```

The host provides a central configuration instance for the app. Building on the preceding example, the weather service's URL is passed from a default configuration source (for example, `appsettings.json`) to `InitializeWeatherAsync`:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        ...
        builder.Services.AddSingleton<WeatherService>();
        ...

        var host = builder.Build();

        var weatherService = host.Services.GetRequiredService<WeatherService>();
        await weatherService.InitializeWeatherAsync(
            host.Configuration["WeatherServiceUrl"]);

        await host.RunAsync();
    }
}
```

## Add services to a Blazor Server app

After creating a new app, examine the `Startup.ConfigureServices` method in `Startup.cs`:

```csharp
using Microsoft.Extensions.DependencyInjection;

...

public void ConfigureServices(IServiceCollection services)
{
    ...
}
```

The <xref:Microsoft.Extensions.Hosting.IHostBuilder.ConfigureServices%2A> method is passed an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>, which is a list of [service descriptor](xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor) objects. Services are added in the `ConfigureServices` method by providing service descriptors to the service collection. The following example demonstrates the concept with the `IDataAccess` interface and its concrete implementation `DataAccess`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDataAccess, DataAccess>();
}
```

## Register common services in a hosted Blazor WebAssembly solution

If one or more common services are required by the **`Server`** and **`Client`** projects of a hosted Blazor WebAssembly solution, you can place the common service registrations in a method in the **`Client`** project and call the method to register the services in both projects.

First, factor common service registrations into a separate method. For example, create a `ConfigureCommonServices` method in the **`Client`** project:

```csharp
public static void ConfigureCommonServices(IServiceCollection services)
{
    services.Add...;
}
```

In the client (**`Client`**) project's `Program.cs` file, call `ConfigureCommonServices` to register the common services:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

...

ConfigureCommonServices(builder.Services);
```

In the **`Server`** project's `ConfigureServices` method of `Startup.cs`, call `ConfigureCommonServices` to register the common services for the **`Server`** project:

```csharp
Client.Program.ConfigureCommonServices(services);
```

For an example of this approach, see <xref:blazor/security/webassembly/additional-scenarios#support-prerendering-with-authentication>.

## Service lifetime

Services can be configured with the lifetimes shown in the following table.

| Lifetime | Description |
| -------- | ----------- |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped%2A> | <p>Blazor WebAssembly apps don't currently have a concept of DI scopes. `Scoped`-registered services behave like `Singleton` services.</p><p>The Blazor Server hosting model supports the `Scoped` lifetime across HTTP requests but not across SignalR connection/circuit messages among components that are loaded on the client. The Razor Pages or MVC portion of the app treats scoped services normally and recreates the services on *each HTTP request* when navigating among pages or views or from a page or view to a component. Scoped services aren't reconstructed when navigating among components on the client, where the communication to the server takes place over the SignalR connection of the user's circuit, not via HTTP requests. In the following component scenarios on the client, scoped services are reconstructed because a new circuit is created for the user:</p><ul><li>The user closes the browser's window. The user opens a new window and navigates back to the app.</li><li>The user closes a tab of the app in a browser window. The user opens a new tab and navigates back to the app.</li><li>The user selects the browser's reload/refresh button.</li></ul><p>For more information on preserving user state across scoped services in Blazor Server apps, see <xref:blazor/hosting-models?pivots=server>.</p> |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton%2A> | DI creates a *single instance* of the service. All components requiring a `Singleton` service receive the same instance of the service. |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient%2A> | Whenever a component obtains an instance of a `Transient` service from the service container, it receives a *new instance* of the service. |

The DI system is based on the DI system in ASP.NET Core. For more information, see <xref:fundamentals/dependency-injection>.

## Request a service in a component

After services are added to the service collection, inject the services into the components using the [`@inject`](xref:mvc/views/razor#inject) Razor directive, which has two parameters:

* Type: The type of the service to inject.
* Property: The name of the property receiving the injected app service. The property doesn't require manual creation. The compiler creates the property.

For more information, see <xref:mvc/views/dependency-injection>.

Use multiple [`@inject`](xref:mvc/views/razor#inject) statements to inject different services.

The following example shows how to use [`@inject`](xref:mvc/views/razor#inject). The service implementing `Services.IDataAccess` is injected into the component's property `DataRepository`. Note how the code is only using the `IDataAccess` abstraction:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_Server/Pages/dependency-injection/CustomerList.razor?highlight=2,19)]

Internally, the generated property (`DataRepository`) uses the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute). Typically, this attribute isn't used directly. If a base class is required for components and injected properties are also required for the base class, manually add the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute):

```csharp
using Microsoft.AspNetCore.Components;

public class ComponentBase : IComponent
{
    [Inject]
    protected IDataAccess DataRepository { get; set; }

    ...
}
```

In components derived from the base class, the [`@inject`](xref:mvc/views/razor#inject) directive isn't required. The <xref:Microsoft.AspNetCore.Components.InjectAttribute> of the base class is sufficient:

```razor
@page "/demo"
@inherits ComponentBase

<h1>Demo Component</h1>
```

## Use DI in services

Complex services might require additional services. In the following example, `DataAccess` requires the <xref:System.Net.Http.HttpClient> default service. [`@inject`](xref:mvc/views/razor#inject) (or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute)) isn't available for use in services. *Constructor injection* must be used instead. Required services are added by adding parameters to the service's constructor. When DI creates the service, it recognizes the services it requires in the constructor and provides them accordingly. In the following example, the constructor receives an <xref:System.Net.Http.HttpClient> via DI. <xref:System.Net.Http.HttpClient> is a default service.

```csharp
using System.Net.Http;

public class DataAccess : IDataAccess
{
    public DataAccess(HttpClient http)
    {
        ...
    }
}
```

Prerequisites for constructor injection:

* One constructor must exist whose arguments can all be fulfilled by DI. Additional parameters not covered by DI are allowed if they specify default values.
* The applicable constructor must be `public`.
* One applicable constructor must exist. In case of an ambiguity, DI throws an exception.

## Utility base component classes to manage a DI scope

In ASP.NET Core apps, scoped services are typically scoped to the current request. After the request completes, any scoped or transient services are disposed by the DI system. In Blazor Server apps, the request scope lasts for the duration of the client connection, which can result in transient and scoped services living much longer than expected. In Blazor WebAssembly apps, services registered with a scoped lifetime are treated as singletons, so they live longer than scoped services in typical ASP.NET Core apps.

> [!NOTE]
> To detect disposable transient services in an app, see the following sections:
>
> [Detect transient disposables in Blazor WebAssembly apps](#detect-transient-disposables-in-blazor-webassembly-apps)
> [Detect transient disposables in Blazor Server apps](#detect-transient-disposables-in-blazor-server-apps)

An approach that limits a service lifetime in Blazor apps is use of the <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type. <xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract type derived from <xref:Microsoft.AspNetCore.Components.ComponentBase> that creates a DI scope corresponding to the lifetime of the component. Using this scope, it's possible to use DI services with a scoped lifetime and have them live as long as the component. When the component is destroyed, services from the component's scoped service provider are disposed as well. This can be useful for services that:

* Should be reused within a component, as the transient lifetime is inappropriate.
* Shouldn't be shared across components, as the singleton lifetime is inappropriate.

Two versions of the <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type are available:

* <xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract, disposable child of the <xref:Microsoft.AspNetCore.Components.ComponentBase> type with a protected <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property of type <xref:System.IServiceProvider>. This provider can be used to resolve services that are scoped to the lifetime of the component.

  DI services injected into the component using [`@inject`](xref:mvc/views/razor#inject) or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute) aren't created in the component's scope. To use the component's scope, services must be resolved using <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> or <xref:System.IServiceProvider.GetService%2A>. Any services resolved using the <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> provider have their dependencies provided from that same scope.

  [!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/dependency-injection/Preferences.razor?highlight=3,20-21)]

* <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601> derives from <xref:Microsoft.AspNetCore.Components.OwningComponentBase> and adds a <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601.Service%2A> property that returns an instance of `T` from the scoped DI provider. This type is a convenient way to access scoped services without using an instance of <xref:System.IServiceProvider> when there's one primary service the app requires from the DI container using the component's scope. The <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property is available, so the app can get services of other types, if necessary.

  ```razor
  @page "/users"
  @attribute [Authorize]
  @inherits OwningComponentBase<AppDbContext>

  <h1>Users (@Service.Users.Count())</h1>

  <ul>
      @foreach (var user in Service.Users)
      {
          <li>@user.UserName</li>
      }
  </ul>
  ```

## Use of an Entity Framework Core (EF Core) DbContext from DI

For more information, see <xref:blazor/blazor-server-ef-core>.

## Detect transient disposables in Blazor WebAssembly apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_WebAssembly/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs)]

The `TransientDisposable` in the following example is detected (`Program.cs`):

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.DetectIncorrectUsageOfTransients();
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddTransient<TransientDisposable>();
        builder.Services.AddScoped(sp =>
            new HttpClient
            {
                BaseAddress = new(builder.HostEnvironment.BaseAddress)
            });

        var host = builder.Build();
        host.EnableTransientDisposableDetection();
        await host.RunAsync();
    }
}

public class TransientDisposable : IDisposable
{
    public void Dispose() => throw new NotImplementedException();
}
```

The app can register transient disposables without throwing an exception. However, attempting to resolve a transient disposable results in an <xref:System.InvalidOperationException>, as the following example shows.

`Pages/TransientExample.razor`:

```razor
@page "/transient-example"
@inject TransientDisposable TransientDisposable

<h1>Transient Disposable Detection</h1>
```

Navigate to the `TransientExample` component at `/transient-example` and an <xref:System.InvalidOperationException> is thrown when the framework attempts to construct an instance of `TransientDisposable`:

> System.InvalidOperationException: Trying to resolve transient disposable service TransientDisposable in the wrong scope. Use an 'OwningComponentBase\<T>' component base class for the service 'T' you are trying to resolve.

## Detect transient disposables in Blazor Server apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_Server/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs)]

Add the namespace for <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> to `Program.cs`:

```csharp
using Microsoft.Extensions.DependencyInjection;
```

In `Program.CreateHostBuilder` of `Program.cs`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .DetectIncorrectUsageOfTransients()
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

The `TransientDependency` in the following example is detected (`Startup.cs`):

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<WeatherForecastService>();
    services.AddTransient<TransientDependency>();
    services.AddTransient<ITransitiveTransientDisposableDependency, 
        TransitiveTransientDisposableDependency>();
}

public class TransitiveTransientDisposableDependency 
    : ITransitiveTransientDisposableDependency, IDisposable
{
    public void Dispose() { }
}

public interface ITransitiveTransientDisposableDependency
{
}

public class TransientDependency
{
    private readonly ITransitiveTransientDisposableDependency 
        _transitiveTransientDisposableDependency;

    public TransientDependency(ITransitiveTransientDisposableDependency 
        transitiveTransientDisposableDependency)
    {
        _transitiveTransientDisposableDependency = 
            transitiveTransientDisposableDependency;
    }
}
```

The app can register transient disposables without throwing an exception. However, attempting to resolve a transient disposable results in an <xref:System.InvalidOperationException>, as the following example shows.

`Pages/TransientExample.razor`:

```razor
@page "/transient-example"
@inject TransientDependency TransientDependency

<h1>Transient Disposable Detection</h1>
```

Navigate to the `TransientExample` component at `/transient-example` and an <xref:System.InvalidOperationException> is thrown when the framework attempts to construct an instance of `TransientDependency`:

> System.InvalidOperationException: Trying to resolve transient disposable service TransientDependency in the wrong scope. Use an 'OwningComponentBase\<T>' component base class for the service 'T' you are trying to resolve.

## Additional resources

* <xref:fundamentals/dependency-injection>
* [`IDisposable` guidance for Transient and shared instances](xref:fundamentals/dependency-injection#idisposable-guidance-for-transient-and-shared-instances)
* <xref:mvc/views/dependency-injection>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

[Dependency injection (DI)](xref:fundamentals/dependency-injection) is a technique for accessing services configured in a central location:

* Framework-registered services can be injected directly into components of Blazor apps.
* Blazor apps define and register custom services and make them available throughout the app via DI.

## Default services

The services shown in the following table are commonly used in Blazor apps.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Scoped | <p>Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</p><p>The instance of <xref:System.Net.Http.HttpClient> in a Blazor WebAssembly app uses the browser for handling the HTTP traffic in the background.</p><p>Blazor Server apps don't include an <xref:System.Net.Http.HttpClient> configured as a service by default. Provide an <xref:System.Net.Http.HttpClient> to a Blazor Server app.</p><p>For more information, see <xref:blazor/call-web-api>.</p><p>An <xref:System.Net.Http.HttpClient> is registered as a scoped service, not singleton. For more information, see the [Service lifetime](#service-lifetime) section.</p> |
| <xref:Microsoft.JSInterop.IJSRuntime> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p> | Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet>. |
| <xref:Microsoft.AspNetCore.Components.NavigationManager> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p> | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers). |

A custom service provider doesn't automatically provide the default services listed in the table. If you use a custom service provider and require any of the services shown in the table, add the required services to the new service provider.

## Add services to a Blazor WebAssembly app

Configure services for the app's service collection in `Program.cs`. In the following example, the `ExampleDependency` implementation is registered for `IExampleDependency`:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        ...
        builder.Services.AddSingleton<IExampleDependency, ExampleDependency>();
        ...

        await builder.Build().RunAsync();
    }
}
```

After the host is built, services are available from the root DI scope before any components are rendered. This can be useful for running initialization logic before rendering content:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        ...
        builder.Services.AddSingleton<WeatherService>();
        ...

        var host = builder.Build();

        var weatherService = host.Services.GetRequiredService<WeatherService>();
        await weatherService.InitializeWeatherAsync();

        await host.RunAsync();
    }
}
```

The host provides a central configuration instance for the app. Building on the preceding example, the weather service's URL is passed from a default configuration source (for example, `appsettings.json`) to `InitializeWeatherAsync`:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        ...
        builder.Services.AddSingleton<WeatherService>();
        ...

        var host = builder.Build();

        var weatherService = host.Services.GetRequiredService<WeatherService>();
        await weatherService.InitializeWeatherAsync(
            host.Configuration["WeatherServiceUrl"]);

        await host.RunAsync();
    }
}
```

## Add services to a Blazor Server app

After creating a new app, examine the `Startup.ConfigureServices` method in `Startup.cs`:

```csharp
using Microsoft.Extensions.DependencyInjection;

...

public void ConfigureServices(IServiceCollection services)
{
    ...
}
```

The <xref:Microsoft.Extensions.Hosting.IHostBuilder.ConfigureServices%2A> method is passed an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>, which is a list of [service descriptor](xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor) objects. Services are added in the `ConfigureServices` method by providing service descriptors to the service collection. The following example demonstrates the concept with the `IDataAccess` interface and its concrete implementation `DataAccess`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDataAccess, DataAccess>();
}
```

## Register common services in a hosted Blazor WebAssembly solution

If one or more common services are required by the **`Server`** and **`Client`** projects of a hosted Blazor WebAssembly solution, you can place the common service registrations in a method in the **`Client`** project and call the method to register the services in both projects.

First, factor common service registrations into a separate method. For example, create a `ConfigureCommonServices` method in the **`Client`** project:

```csharp
public static void ConfigureCommonServices(IServiceCollection services)
{
    services.Add...;
}
```

In the **`Client`** project's `Program.cs` file, call `ConfigureCommonServices` to register the common services:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

...

ConfigureCommonServices(builder.Services);
```

In the **`Server`** project's `ConfigureServices` method of `Startup.cs`, call `ConfigureCommonServices` to register the common services for the **`Server`** project:

```csharp
Client.Program.ConfigureCommonServices(services);
```

For an example of this approach, see <xref:blazor/security/webassembly/additional-scenarios#support-prerendering-with-authentication>.

## Service lifetime

Services can be configured with the lifetimes shown in the following table.

| Lifetime | Description |
| -------- | ----------- |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped%2A> | <p>Blazor WebAssembly apps don't currently have a concept of DI scopes. `Scoped`-registered services behave like `Singleton` services.</p><p>The Blazor Server hosting model supports the `Scoped` lifetime across HTTP requests but not across SignalR connection/circuit messages among components that are loaded on the client. The Razor Pages or MVC portion of the app treats scoped services normally and recreates the services on *each HTTP request* when navigating among pages or views or from a page or view to a component. Scoped services aren't reconstructed when navigating among components on the client, where the communication to the server takes place over the SignalR connection of the user's circuit, not via HTTP requests. In the following component scenarios on the client, scoped services are reconstructed because a new circuit is created for the user:</p><ul><li>The user closes the browser's window. The user opens a new window and navigates back to the app.</li><li>The user closes a tab of the app in a browser window. The user opens a new tab and navigates back to the app.</li><li>The user selects the browser's reload/refresh button.</li></ul><p>For more information on preserving user state across scoped services in Blazor Server apps, see <xref:blazor/hosting-models?pivots=server>.</p> |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton%2A> | DI creates a *single instance* of the service. All components requiring a `Singleton` service receive the same instance of the service. |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient%2A> | Whenever a component obtains an instance of a `Transient` service from the service container, it receives a *new instance* of the service. |

The DI system is based on the DI system in ASP.NET Core. For more information, see <xref:fundamentals/dependency-injection>.

## Request a service in a component

After services are added to the service collection, inject the services into the components using the [`@inject`](xref:mvc/views/razor#inject) Razor directive, which has two parameters:

* Type: The type of the service to inject.
* Property: The name of the property receiving the injected app service. The property doesn't require manual creation. The compiler creates the property.

For more information, see <xref:mvc/views/dependency-injection>.

Use multiple [`@inject`](xref:mvc/views/razor#inject) statements to inject different services.

The following example shows how to use [`@inject`](xref:mvc/views/razor#inject). The service implementing `Services.IDataAccess` is injected into the component's property `DataRepository`. Note how the code is only using the `IDataAccess` abstraction:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_Server/Pages/dependency-injection/CustomerList.razor?highlight=2,19)]

Internally, the generated property (`DataRepository`) uses the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute). Typically, this attribute isn't used directly. If a base class is required for components and injected properties are also required for the base class, manually add the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute):

```csharp
using Microsoft.AspNetCore.Components;

public class ComponentBase : IComponent
{
    [Inject]
    protected IDataAccess DataRepository { get; set; }

    ...
}
```

In components derived from the base class, the [`@inject`](xref:mvc/views/razor#inject) directive isn't required. The <xref:Microsoft.AspNetCore.Components.InjectAttribute> of the base class is sufficient:

```razor
@page "/demo"
@inherits ComponentBase

<h1>Demo Component</h1>
```

## Use DI in services

Complex services might require additional services. In the following example, `DataAccess` requires the <xref:System.Net.Http.HttpClient> default service. [`@inject`](xref:mvc/views/razor#inject) (or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute)) isn't available for use in services. *Constructor injection* must be used instead. Required services are added by adding parameters to the service's constructor. When DI creates the service, it recognizes the services it requires in the constructor and provides them accordingly. In the following example, the constructor receives an <xref:System.Net.Http.HttpClient> via DI. <xref:System.Net.Http.HttpClient> is a default service.

```csharp
using System.Net.Http;

public class DataAccess : IDataAccess
{
    public DataAccess(HttpClient http)
    {
        ...
    }
}
```

Prerequisites for constructor injection:

* One constructor must exist whose arguments can all be fulfilled by DI. Additional parameters not covered by DI are allowed if they specify default values.
* The applicable constructor must be `public`.
* One applicable constructor must exist. In case of an ambiguity, DI throws an exception.

## Utility base component classes to manage a DI scope

In ASP.NET Core apps, scoped services are typically scoped to the current request. After the request completes, any scoped or transient services are disposed by the DI system. In Blazor Server apps, the request scope lasts for the duration of the client connection, which can result in transient and scoped services living much longer than expected. In Blazor WebAssembly apps, services registered with a scoped lifetime are treated as singletons, so they live longer than scoped services in typical ASP.NET Core apps.

> [!NOTE]
> To detect disposable transient services in an app, see the following sections:
>
> [Detect transient disposables in Blazor WebAssembly apps](#detect-transient-disposables-in-blazor-webassembly-apps)
> [Detect transient disposables in Blazor Server apps](#detect-transient-disposables-in-blazor-server-apps)

An approach that limits a service lifetime in Blazor apps is use of the <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type. <xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract type derived from <xref:Microsoft.AspNetCore.Components.ComponentBase> that creates a DI scope corresponding to the lifetime of the component. Using this scope, it's possible to use DI services with a scoped lifetime and have them live as long as the component. When the component is destroyed, services from the component's scoped service provider are disposed as well. This can be useful for services that:

* Should be reused within a component, as the transient lifetime is inappropriate.
* Shouldn't be shared across components, as the singleton lifetime is inappropriate.

Two versions of the <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type are available:

* <xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract, disposable child of the <xref:Microsoft.AspNetCore.Components.ComponentBase> type with a protected <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property of type <xref:System.IServiceProvider>. This provider can be used to resolve services that are scoped to the lifetime of the component.

  DI services injected into the component using [`@inject`](xref:mvc/views/razor#inject) or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute) aren't created in the component's scope. To use the component's scope, services must be resolved using <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> or <xref:System.IServiceProvider.GetService%2A>. Any services resolved using the <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> provider have their dependencies provided from that same scope.

  [!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/dependency-injection/Preferences.razor?highlight=3,20-21)]

* <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601> derives from <xref:Microsoft.AspNetCore.Components.OwningComponentBase> and adds a <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601.Service%2A> property that returns an instance of `T` from the scoped DI provider. This type is a convenient way to access scoped services without using an instance of <xref:System.IServiceProvider> when there's one primary service the app requires from the DI container using the component's scope. The <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property is available, so the app can get services of other types, if necessary.

  ```razor
  @page "/users"
  @attribute [Authorize]
  @inherits OwningComponentBase<AppDbContext>

  <h1>Users (@Service.Users.Count())</h1>

  <ul>
      @foreach (var user in Service.Users)
      {
          <li>@user.UserName</li>
      }
  </ul>
  ```

## Use of an Entity Framework Core (EF Core) DbContext from DI

For more information, see <xref:blazor/blazor-server-ef-core>.

## Detect transient disposables in Blazor WebAssembly apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_WebAssembly/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs)]

The `TransientDisposable` in the following example is detected (`Program.cs`):

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.DetectIncorrectUsageOfTransients();
        builder.RootComponents.Add<App>("app");

        builder.Services.AddTransient<TransientDisposable>();
        builder.Services.AddScoped(sp =>
            new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

        var host = builder.Build();
        host.EnableTransientDisposableDetection();
        await host.RunAsync();
    }
}

public class TransientDisposable : IDisposable
{
    public void Dispose() => throw new NotImplementedException();
}
```

The app can register transient disposables without throwing an exception. However, attempting to resolve a transient disposable results in an <xref:System.InvalidOperationException>, as the following example shows.

`Pages/TransientExample.razor`:

```razor
@page "/transient-example"
@inject TransientDisposable TransientDisposable

<h1>Transient Disposable Detection</h1>
```

Navigate to the `TransientExample` component at `/transient-example` and an <xref:System.InvalidOperationException> is thrown when the framework attempts to construct an instance of `TransientDisposable`:

> System.InvalidOperationException: Trying to resolve transient disposable service TransientDisposable in the wrong scope. Use an 'OwningComponentBase\<T>' component base class for the service 'T' you are trying to resolve.

## Detect transient disposables in Blazor Server apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_Server/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs)]

Add the namespace for <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> to `Program.cs`:

```csharp
using Microsoft.Extensions.DependencyInjection;
```

In `Program.CreateHostBuilder` of `Program.cs`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .DetectIncorrectUsageOfTransients()
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

The `TransientDependency` in the following example is detected (`Startup.cs`):

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<WeatherForecastService>();
    services.AddTransient<TransientDependency>();
    services.AddTransient<ITransitiveTransientDisposableDependency, 
        TransitiveTransientDisposableDependency>();
}

public class TransitiveTransientDisposableDependency 
    : ITransitiveTransientDisposableDependency, IDisposable
{
    public void Dispose() { }
}

public interface ITransitiveTransientDisposableDependency
{
}

public class TransientDependency
{
    private readonly ITransitiveTransientDisposableDependency 
        _transitiveTransientDisposableDependency;

    public TransientDependency(ITransitiveTransientDisposableDependency 
        transitiveTransientDisposableDependency)
    {
        _transitiveTransientDisposableDependency = 
            transitiveTransientDisposableDependency;
    }
}
```

The app can register transient disposables without throwing an exception. However, attempting to resolve a transient disposable results in an <xref:System.InvalidOperationException>, as the following example shows.

`Pages/TransientExample.razor`:

```razor
@page "/transient-example"
@inject TransientDependency TransientDependency

<h1>Transient Disposable Detection</h1>
```

Navigate to the `TransientExample` component at `/transient-example` and an <xref:System.InvalidOperationException> is thrown when the framework attempts to construct an instance of `TransientDependency`:

> System.InvalidOperationException: Trying to resolve transient disposable service TransientDependency in the wrong scope. Use an 'OwningComponentBase\<T>' component base class for the service 'T' you are trying to resolve.

## Additional resources

* <xref:fundamentals/dependency-injection>
* [`IDisposable` guidance for Transient and shared instances](xref:fundamentals/dependency-injection#idisposable-guidance-for-transient-and-shared-instances)
* <xref:mvc/views/dependency-injection>

:::moniker-end
