---
title: ASP.NET Core Blazor dependency injection
author: guardrex
description: Learn how Blazor apps can inject services into components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/fundamentals/dependency-injection
---
# ASP.NET Core Blazor dependency injection

By [Rainer Stropek](https://www.timecockpit.com) and [Mike Rousos](https://github.com/mjrousos)

This article explains how Blazor apps can inject services into components.

:::moniker range=">= aspnetcore-7.0"

[Dependency injection (DI)](xref:fundamentals/dependency-injection) is a technique for accessing services configured in a central location:

* Framework-registered services can be injected directly into components of Blazor apps.
* Blazor apps define and register custom services and make them available throughout the app via DI.

> [!NOTE]
> We recommend reading <xref:fundamentals/dependency-injection> before reading this topic.

## Default services

The services shown in the following table are commonly used in Blazor apps.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Scoped | <p>Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</p><p>The instance of <xref:System.Net.Http.HttpClient> in a Blazor WebAssembly app is registered by the app in `Program.cs` and uses the browser for handling the HTTP traffic in the background.</p><p>Blazor Server apps don't include an <xref:System.Net.Http.HttpClient> configured as a service by default. Provide an <xref:System.Net.Http.HttpClient> to a Blazor Server app.</p><p>For more information, see <xref:blazor/call-web-api>.</p><p>An <xref:System.Net.Http.HttpClient> is registered as a scoped service, not singleton. For more information, see the [Service lifetime](#service-lifetime) section.</p> |
| <xref:Microsoft.JSInterop.IJSRuntime> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p><p>The Blazor framework registers <xref:Microsoft.JSInterop.IJSRuntime> in the app's service container.</p> | <p>Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet>.</p><p>When seeking to inject the service into a singleton service in Blazor Server apps, take either of the following approaches:</p><ul><li>Change the service registration to scoped to match <xref:Microsoft.JSInterop.IJSRuntime>'s registration, which is appropriate if the service deals with user-specific state.</li><li>Pass the <xref:Microsoft.JSInterop.IJSRuntime> into the singleton service's implementation as an argument of its method calls instead of injecting it into the singleton.</li></ul> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p><p>The Blazor framework registers <xref:Microsoft.AspNetCore.Components.NavigationManager> in the app's service container.</p> | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers). |

Additional services registered by the Blazor framework are described in the documentation where they're used to describe Blazor features, such as configuration and logging.

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

If one or more common services are required by the **:::no-loc text="Server":::** and **:::no-loc text="Client":::** projects of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln), you can place the common service registrations in a method in the **:::no-loc text="Client":::** project and call the method to register the services in both projects.

First, factor common service registrations into a separate method. For example, create a `ConfigureCommonServices` method in the **:::no-loc text="Client":::** project:

```csharp
public static void ConfigureCommonServices(IServiceCollection services)
{
    services.Add...;
}
```

In the **:::no-loc text="Client":::** project's `Program.cs` file, call `ConfigureCommonServices` to register the common services:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

...

ConfigureCommonServices(builder.Services);
```

In the **:::no-loc text="Server":::** project's `Program.cs` file, call `ConfigureCommonServices` to register the common services for the **:::no-loc text="Server":::** project:

```csharp
var builder = WebApplication.CreateBuilder(args);

...

Client.Program.ConfigureCommonServices(builder.Services);
```

For an example of this approach, see <xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication>.

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

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Pages/dependency-injection/CustomerList.razor" highlight="2,19":::

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

Two versions of <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type are available and described in the next two sections:

* [`OwningComponentBase`](#owningcomponentbase)
* [`OwningComponentBase<TService>`](#owningcomponentbasetservice)

### `OwningComponentBase`

<xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract, disposable child of the <xref:Microsoft.AspNetCore.Components.ComponentBase> type with a protected <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property of type <xref:System.IServiceProvider>. The provider can be used to resolve services that are scoped to the lifetime of the component.

DI services injected into the component using [`@inject`](xref:mvc/views/razor#inject) or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute) aren't created in the component's scope. To use the component's scope, services must be resolved using <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> with either <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> or <xref:System.IServiceProvider.GetService%2A>. Any services resolved using the <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> provider have their dependencies provided in the component's scope.
  
The following example demonstrates the difference between injecting a scoped service directly and resolving a service using <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> in a Blazor Server app. The following interface and implementation for a time travel class include a `DT` property to hold a <xref:System.DateTime> value. The implementation calls <xref:System.DateTime.Now?displayProperty=nameWithType> to set `DT` when the `TimeTravel` class is instantiated.
  
`ITimeTravel.cs`:
  
```csharp
public interface ITimeTravel
{
    public DateTime DT { get; set; }
}
```
  
`TimeTravel.cs`:

```csharp
public class TimeTravel : ITimeTravel
{
    public DateTime DT { get; set; } = DateTime.Now;
}
```
  
The service is registered as scoped in `Program.cs` of a Blazor Server app. In a Blazor Server app, scoped services have a lifetime equal to the duration of the client connection, known as a [circuit](xref:blazor/hosting-models#blazor-server).
  
In `Program.cs`:
  
```csharp
builder.Services.AddScoped<ITimeTravel, TimeTravel>();
```

In the following `TimeTravel` component:

* The time travel service is directly injected with `@inject` as `TimeTravel1`.
* The service is also resolved separately with <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> as `TimeTravel2`.

`Pages/TimeTravel.razor`:
  
```razor
@page "/time-travel"
@inject ITimeTravel TimeTravel1
@inherits OwningComponentBase

<h1><code>OwningComponentBase</code> Example</h1>

<ul>
    <li>TimeTravel1.DT: @TimeTravel1?.DT</li>
    <li>TimeTravel2.DT: @TimeTravel2?.DT</li>
</ul>

@code {
    private ITimeTravel? TimeTravel2 { get; set; }

    protected override void OnInitialized()
    {
        TimeTravel2 = ScopedServices.GetRequiredService<ITimeTravel>();
    }
}
```
  
If you're placing this example into a test app, add the `TimeTravel` component to the `NavMenu` component.
  
In `Shared/NavMenu.razor`:
  
```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="time-travel">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Time travel
    </NavLink>
</div>
```

Initially navigating to the `TimeTravel` component, the time travel service is instantiated twice when the component loads, and `TimeTravel1` and `TimeTravel2` have the same initial value:
  
> :::no-loc text="TimeTravel1.DT: 8/31/2022 2:54:45 PM":::  
> :::no-loc text="TimeTravel2.DT: 8/31/2022 2:54:45 PM":::
  
When navigating away from the `TimeTravel` component to another component and back to the `TimeTravel` component:

* `TimeTravel1` is provided the same service instance that was created when the component first loaded, so the value of `DT` remains the same.
* `TimeTravel2` obtains a new `ITimeTravel` service instance in `TimeTravel2` with a new DT value.
  
> :::no-loc text="TimeTravel1.DT: 8/31/2022 2:54:45 PM":::  
> :::no-loc text="TimeTravel2.DT: 8/31/2022 2:54:48 PM":::
  
`TimeTravel1` is tied to the user's circuit, which remains intact and isn't disposed until the underlying circuit is deconstructed. For example, the service is disposed if the circuit is disconnected for the [disconnected circuit retention period](xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod).

In spite of the scoped service registration in `Program.cs` and the longevity of the user's circuit, `TimeTravel2` receives a new `ITimeTravel` service instance each time the component is initialized.

### `OwningComponentBase<TService>`

<xref:Microsoft.AspNetCore.Components.OwningComponentBase%601> derives from <xref:Microsoft.AspNetCore.Components.OwningComponentBase> and adds a <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601.Service%2A> property that returns an instance of `T` from the scoped DI provider. This type is a convenient way to access scoped services without using an instance of <xref:System.IServiceProvider> when there's one primary service the app requires from the DI container using the component's scope. The <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property is available, so the app can get services of other types, if necessary.

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

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs":::

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

> [!NOTE]
> Transient service registrations for <xref:System.Net.Http.IHttpClientFactory> handlers are recommended. The `TransientExample` component in this section indicates the following transient disposables in Blazor WebAssembly apps that use authentication, which is expected:
>
> * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.BaseAddressAuthorizationMessageHandler>
> * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler>

## Detect transient disposables in Blazor Server apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_Server/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs":::

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
  
## Access Blazor services from a different DI scope
  
*This section only applies to Blazor Server apps.**

There may be times when a Razor component invokes asynchronous methods that execute code in a different DI scope. Without the correct approach, these DI scopes don't have access to Blazor's services, such as <xref:Microsoft.JSInterop.IJSRuntime> and <xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage>.

For example, <xref:System.Net.Http.HttpClient> instances created using <xref:System.Net.Http.IHttpClientFactory> have their own DI service scope. As a result, <xref:System.Net.Http.HttpMessageHandler> instances configured on the <xref:System.Net.Http.HttpClient> aren't able to directly inject Blazor services.

Create a class `BlazorServiceAccessor` that defines an [`AsyncLocal`](xref:System.Threading.AsyncLocal`1), which stores the Blazor <xref:System.IServiceProvider> for the current asynchronous context. A `BlazorServiceAcccessor` instance can be acquired from within a different DI service scope to access Blazor services.

`BlazorServiceAccessor.cs`:

```csharp
internal sealed class BlazorServiceAccessor
{
    private static readonly AsyncLocal<BlazorServiceHolder> s_currentServiceHolder = new();

    public IServiceProvider? Services
    {
        get => s_currentServiceHolder.Value?.Services;
        set
        {
            if (s_currentServiceHolder.Value is { } holder)
            {
                // Clear the current IServiceProvider trapped in the AsyncLocal.
                holder.Services = null;
            }

            if (value is not null)
            {
                // Use object indirection to hold the IServiceProvider in an AsyncLocal
                // so it can be cleared in all ExecutionContexts when it's cleared.
                s_currentServiceHolder.Value = new() { Services = value };
            }
        }
    }

    private sealed class BlazorServiceHolder
    {
        public IServiceProvider? Services { get; set; }
    }
}
```

To set the value of `BlazorServiceAccessor.Services` automatically when an `async` component method is invoked, create a custom base component that re-implements the three primary asynchronous entry points into Razor component code:

* <xref:Microsoft.AspNetCore.Components.IComponent.SetParametersAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.IHandleEvent.HandleEventAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.IHandleAfterRender.OnAfterRenderAsync%2A?displayProperty=nameWithType>

The following class demonstrates the implementation for the base component.
  
`CustomComponentBase.cs`:

```csharp
using Microsoft.AspNetCore.Components;

public class CustomComponentBase : ComponentBase, IHandleEvent, IHandleAfterRender
{
    private bool hasCalledOnAfterRender;

    [Inject]
    private IServiceProvider Services { get; set; } = default!;

    [Inject]
    private BlazorServiceAccessor BlazorServiceAccessor { get; set; } = default!;

    public override Task SetParametersAsync(ParameterView parameters)
        => InvokeWithBlazorServiceContext(() => base.SetParametersAsync(parameters));

    Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object? arg)
        => InvokeWithBlazorServiceContext(() =>
        {
            var task = callback.InvokeAsync(arg);
            var shouldAwaitTask = task.Status != TaskStatus.RanToCompletion &&
                task.Status != TaskStatus.Canceled;

            StateHasChanged();

            return shouldAwaitTask ?
                CallStateHasChangedOnAsyncCompletion(task) :
                Task.CompletedTask;
        });

    Task IHandleAfterRender.OnAfterRenderAsync()
        => InvokeWithBlazorServiceContext(() =>
        {
            var firstRender = !hasCalledOnAfterRender;
            hasCalledOnAfterRender |= true;

            OnAfterRender(firstRender);

            return OnAfterRenderAsync(firstRender);
        });

    private async Task CallStateHasChangedOnAsyncCompletion(Task task)
    {
        try
        {
            await task;
        }
        catch
        {
            if (task.IsCanceled)
            {
                return;
            }

            throw;
        }

        StateHasChanged();
    }

    private async Task InvokeWithBlazorServiceContext(Func<Task> func)
    {
        try
        {
            BlazorServiceAccessor.Services = Services;
            await func();
        }
        finally
        {
            BlazorServiceAccessor.Services = null;
        }
    }
}
```

Any components extending `CustomComponentBase` automatically have `BlazorServiceAccessor.Services` set to the <xref:System.IServiceProvider> in the current Blazor DI scope.

Finally, in `Program.cs`, add the `BlazorServiceAccessor` as a scoped service:

```csharp
var builder = WebApplication.CreateBuilder(args);
// ...
builder.Services.AddScoped<BlazorServiceAccessor>();
// ...
```

## Additional resources

* <xref:fundamentals/dependency-injection>
* [`IDisposable` guidance for Transient and shared instances](xref:fundamentals/dependency-injection#idisposable-guidance-for-transient-and-shared-instances)
* <xref:mvc/views/dependency-injection>

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

[Dependency injection (DI)](xref:fundamentals/dependency-injection) is a technique for accessing services configured in a central location:

* Framework-registered services can be injected directly into components of Blazor apps.
* Blazor apps define and register custom services and make them available throughout the app via DI.

> [!NOTE]
> We recommend reading <xref:fundamentals/dependency-injection> before reading this topic.

## Default services

The services shown in the following table are commonly used in Blazor apps.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Scoped | <p>Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</p><p>The instance of <xref:System.Net.Http.HttpClient> in a Blazor WebAssembly app is registered by the app in `Program.cs` and uses the browser for handling the HTTP traffic in the background.</p><p>Blazor Server apps don't include an <xref:System.Net.Http.HttpClient> configured as a service by default. Provide an <xref:System.Net.Http.HttpClient> to a Blazor Server app.</p><p>For more information, see <xref:blazor/call-web-api>.</p><p>An <xref:System.Net.Http.HttpClient> is registered as a scoped service, not singleton. For more information, see the [Service lifetime](#service-lifetime) section.</p> |
| <xref:Microsoft.JSInterop.IJSRuntime> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p><p>The Blazor framework registers <xref:Microsoft.JSInterop.IJSRuntime> in the app's service container.</p> | <p>Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet>.</p><p>When seeking to inject the service into a singleton service in Blazor Server apps, take either of the following approaches:</p><ul><li>Change the service registration to scoped to match <xref:Microsoft.JSInterop.IJSRuntime>'s registration, which is appropriate if the service deals with user-specific state.</li><li>Pass the <xref:Microsoft.JSInterop.IJSRuntime> into the singleton service's implementation as an argument of its method calls instead of injecting it into the singleton.</li></ul> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p><p>The Blazor framework registers <xref:Microsoft.AspNetCore.Components.NavigationManager> in the app's service container.</p> | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers). |

Additional services registered by the Blazor framework are described in the documentation where they're used to describe Blazor features, such as configuration and logging.

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

If one or more common services are required by the **:::no-loc text="Server":::** and **:::no-loc text="Client":::** projects of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln), you can place the common service registrations in a method in the **:::no-loc text="Client":::** project and call the method to register the services in both projects.

First, factor common service registrations into a separate method. For example, create a `ConfigureCommonServices` method in the **:::no-loc text="Client":::** project:

```csharp
public static void ConfigureCommonServices(IServiceCollection services)
{
    services.Add...;
}
```

In the **:::no-loc text="Client":::** project's `Program.cs` file, call `ConfigureCommonServices` to register the common services:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

...

ConfigureCommonServices(builder.Services);
```

In the **:::no-loc text="Server":::** project's `Program.cs` file, call `ConfigureCommonServices` to register the common services for the **:::no-loc text="Server":::** project:

```csharp
var builder = WebApplication.CreateBuilder(args);

...

Client.Program.ConfigureCommonServices(builder.Services);
```

For an example of this approach, see <xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication>.

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

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/dependency-injection/CustomerList.razor" highlight="2,19":::

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

Two versions of <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type are available and described in the next two sections:

* [`OwningComponentBase`](#owningcomponentbase)
* [`OwningComponentBase<TService>`](#owningcomponentbasetservice)

### `OwningComponentBase`

<xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract, disposable child of the <xref:Microsoft.AspNetCore.Components.ComponentBase> type with a protected <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property of type <xref:System.IServiceProvider>. The provider can be used to resolve services that are scoped to the lifetime of the component.

DI services injected into the component using [`@inject`](xref:mvc/views/razor#inject) or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute) aren't created in the component's scope. To use the component's scope, services must be resolved using <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> with either <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> or <xref:System.IServiceProvider.GetService%2A>. Any services resolved using the <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> provider have their dependencies provided in the component's scope.
  
The following example demonstrates the difference between injecting a scoped service directly and resolving a service using <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> in a Blazor Server app. The following interface and implementation for a time travel class include a `DT` property to hold a <xref:System.DateTime> value. The implementation calls <xref:System.DateTime.Now?displayProperty=nameWithType> to set `DT` when the `TimeTravel` class is instantiated.
  
`ITimeTravel.cs`:
  
```csharp
public interface ITimeTravel
{
    public DateTime DT { get; set; }
}
```
  
`TimeTravel.cs`:

```csharp
public class TimeTravel : ITimeTravel
{
    public DateTime DT { get; set; } = DateTime.Now;
}
```
  
The service is registered as scoped in `Program.cs` of a Blazor Server app. In a Blazor Server app, scoped services have a lifetime equal to the duration of the client connection, known as a [circuit](xref:blazor/hosting-models#blazor-server).
  
In `Program.cs`:
  
```csharp
builder.Services.AddScoped<ITimeTravel, TimeTravel>();
```

In the following `TimeTravel` component:

* The time travel service is directly injected with `@inject` as `TimeTravel1`.
* The service is also resolved separately with <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> as `TimeTravel2`.

`Pages/TimeTravel.razor`:
  
```razor
@page "/time-travel"
@inject ITimeTravel TimeTravel1
@inherits OwningComponentBase

<h1><code>OwningComponentBase</code> Example</h1>

<ul>
    <li>TimeTravel1.DT: @TimeTravel1?.DT</li>
    <li>TimeTravel2.DT: @TimeTravel2?.DT</li>
</ul>

@code {
    private ITimeTravel? TimeTravel2 { get; set; }

    protected override void OnInitialized()
    {
        TimeTravel2 = ScopedServices.GetRequiredService<ITimeTravel>();
    }
}
```
  
If you're placing this example into a test app, add the `TimeTravel` component to the `NavMenu` component.
  
In `Shared/NavMenu.razor`:
  
```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="time-travel">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Time travel
    </NavLink>
</div>
```

Initially navigating to the `TimeTravel` component, the time travel service is instantiated twice when the component loads, and `TimeTravel1` and `TimeTravel2` have the same initial value:
  
> :::no-loc text="TimeTravel1.DT: 8/31/2022 2:54:45 PM":::  
> :::no-loc text="TimeTravel2.DT: 8/31/2022 2:54:45 PM":::
  
When navigating away from the `TimeTravel` component to another component and back to the `TimeTravel` component:

* `TimeTravel1` is provided the same service instance that was created when the component first loaded, so the value of `DT` remains the same.
* `TimeTravel2` obtains a new `ITimeTravel` service instance in `TimeTravel2` with a new DT value.
  
> :::no-loc text="TimeTravel1.DT: 8/31/2022 2:54:45 PM":::  
> :::no-loc text="TimeTravel2.DT: 8/31/2022 2:54:48 PM":::
  
`TimeTravel1` is tied to the user's circuit, which remains intact and isn't disposed until the underlying circuit is deconstructed. For example, the service is disposed if the circuit is disconnected for the [disconnected circuit retention period](xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod).

In spite of the scoped service registration in `Program.cs` and the longevity of the user's circuit, `TimeTravel2` receives a new `ITimeTravel` service instance each time the component is initialized.

### `OwningComponentBase<TService>`

<xref:Microsoft.AspNetCore.Components.OwningComponentBase%601> derives from <xref:Microsoft.AspNetCore.Components.OwningComponentBase> and adds a <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601.Service%2A> property that returns an instance of `T` from the scoped DI provider. This type is a convenient way to access scoped services without using an instance of <xref:System.IServiceProvider> when there's one primary service the app requires from the DI container using the component's scope. The <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property is available, so the app can get services of other types, if necessary.

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

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs":::

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

> [!NOTE]
> Transient service registrations for <xref:System.Net.Http.IHttpClientFactory> handlers are recommended. The `TransientExample` component in this section indicates the following transient disposables in Blazor WebAssembly apps that use authentication, which is expected:
>
> * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.BaseAddressAuthorizationMessageHandler>
> * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler>

## Detect transient disposables in Blazor Server apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_Server/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs":::

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
  
## Access Blazor services from a different DI scope
  
*This section only applies to Blazor Server apps.**

There may be times when a Razor component invokes asynchronous methods that execute code in a different DI scope. Without the correct approach, these DI scopes don't have access to Blazor's services, such as <xref:Microsoft.JSInterop.IJSRuntime> and <xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage>.

For example, <xref:System.Net.Http.HttpClient> instances created using <xref:System.Net.Http.IHttpClientFactory> have their own DI service scope. As a result, <xref:System.Net.Http.HttpMessageHandler> instances configured on the <xref:System.Net.Http.HttpClient> aren't able to directly inject Blazor services.

Create a class `BlazorServiceAccessor` that defines an [`AsyncLocal`](xref:System.Threading.AsyncLocal`1), which stores the Blazor <xref:System.IServiceProvider> for the current asynchronous context. A `BlazorServiceAcccessor` instance can be acquired from within a different DI service scope to access Blazor services.

`BlazorServiceAccessor.cs`:

```csharp
internal sealed class BlazorServiceAccessor
{
    private static readonly AsyncLocal<BlazorServiceHolder> s_currentServiceHolder = new();

    public IServiceProvider? Services
    {
        get => s_currentServiceHolder.Value?.Services;
        set
        {
            if (s_currentServiceHolder.Value is { } holder)
            {
                // Clear the current IServiceProvider trapped in the AsyncLocal.
                holder.Services = null;
            }

            if (value is not null)
            {
                // Use object indirection to hold the IServiceProvider in an AsyncLocal
                // so it can be cleared in all ExecutionContexts when it's cleared.
                s_currentServiceHolder.Value = new() { Services = value };
            }
        }
    }

    private sealed class BlazorServiceHolder
    {
        public IServiceProvider? Services { get; set; }
    }
}
```

To set the value of `BlazorServiceAccessor.Services` automatically when an `async` component method is invoked, create a custom base component that re-implements the three primary asynchronous entry points into Razor component code:

* <xref:Microsoft.AspNetCore.Components.IComponent.SetParametersAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.IHandleEvent.HandleEventAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.IHandleAfterRender.OnAfterRenderAsync%2A?displayProperty=nameWithType>

The following class demonstrates the implementation for the base component.
  
`CustomComponentBase.cs`:

```csharp
using Microsoft.AspNetCore.Components;

public class CustomComponentBase : ComponentBase, IHandleEvent, IHandleAfterRender
{
    private bool hasCalledOnAfterRender;

    [Inject]
    private IServiceProvider Services { get; set; } = default!;

    [Inject]
    private BlazorServiceAccessor BlazorServiceAccessor { get; set; } = default!;

    public override Task SetParametersAsync(ParameterView parameters)
        => InvokeWithBlazorServiceContext(() => base.SetParametersAsync(parameters));

    Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object? arg)
        => InvokeWithBlazorServiceContext(() =>
        {
            var task = callback.InvokeAsync(arg);
            var shouldAwaitTask = task.Status != TaskStatus.RanToCompletion &&
                task.Status != TaskStatus.Canceled;

            StateHasChanged();

            return shouldAwaitTask ?
                CallStateHasChangedOnAsyncCompletion(task) :
                Task.CompletedTask;
        });

    Task IHandleAfterRender.OnAfterRenderAsync()
        => InvokeWithBlazorServiceContext(() =>
        {
            var firstRender = !hasCalledOnAfterRender;
            hasCalledOnAfterRender |= true;

            OnAfterRender(firstRender);

            return OnAfterRenderAsync(firstRender);
        });

    private async Task CallStateHasChangedOnAsyncCompletion(Task task)
    {
        try
        {
            await task;
        }
        catch
        {
            if (task.IsCanceled)
            {
                return;
            }

            throw;
        }

        StateHasChanged();
    }

    private async Task InvokeWithBlazorServiceContext(Func<Task> func)
    {
        try
        {
            BlazorServiceAccessor.Services = Services;
            await func();
        }
        finally
        {
            BlazorServiceAccessor.Services = null;
        }
    }
}
```

Any components extending `CustomComponentBase` automatically have `BlazorServiceAccessor.Services` set to the <xref:System.IServiceProvider> in the current Blazor DI scope.

Finally, in `Program.cs`, add the `BlazorServiceAccessor` as a scoped service:

```csharp
var builder = WebApplication.CreateBuilder(args);
// ...
builder.Services.AddScoped<BlazorServiceAccessor>();
// ...
```

## Additional resources

* <xref:fundamentals/dependency-injection>
* [`IDisposable` guidance for Transient and shared instances](xref:fundamentals/dependency-injection#idisposable-guidance-for-transient-and-shared-instances)
* <xref:mvc/views/dependency-injection>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

[Dependency injection (DI)](xref:fundamentals/dependency-injection) is a technique for accessing services configured in a central location:

* Framework-registered services can be injected directly into components of Blazor apps.
* Blazor apps define and register custom services and make them available throughout the app via DI.

> [!NOTE]
> We recommend reading <xref:fundamentals/dependency-injection> before reading this topic.

## Default services

The services shown in the following table are commonly used in Blazor apps.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Scoped | <p>Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</p><p>The instance of <xref:System.Net.Http.HttpClient> in a Blazor WebAssembly app uses the browser for handling the HTTP traffic in the background.</p><p>Blazor Server apps don't include an <xref:System.Net.Http.HttpClient> configured as a service by default. Provide an <xref:System.Net.Http.HttpClient> to a Blazor Server app.</p><p>For more information, see <xref:blazor/call-web-api>.</p><p>An <xref:System.Net.Http.HttpClient> is registered as a scoped service, not singleton. For more information, see the [Service lifetime](#service-lifetime) section.</p> |
| <xref:Microsoft.JSInterop.IJSRuntime> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p><p>The Blazor framework registers <xref:Microsoft.JSInterop.IJSRuntime> in the app's service container.</p> | <p>Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet>.</p><p>When seeking to inject the service into a singleton service in Blazor Server apps, take either of the following approaches:</p><ul><li>Change the service registration to scoped to match <xref:Microsoft.JSInterop.IJSRuntime>'s registration, which is appropriate if the service deals with user-specific state.</li><li>Pass the <xref:Microsoft.JSInterop.IJSRuntime> into the singleton service's implementation as an argument of its method calls instead of injecting it into the singleton.</li></ul> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p><p>The Blazor framework registers <xref:Microsoft.AspNetCore.Components.NavigationManager> in the app's service container.</p> | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers). |

Additional services registered by the Blazor framework are described in the documentation where they're used to describe Blazor features, such as configuration and logging.

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

If one or more common services are required by the **:::no-loc text="Server":::** and **:::no-loc text="Client":::** projects of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln), you can place the common service registrations in a method in the **:::no-loc text="Client":::** project and call the method to register the services in both projects.

First, factor common service registrations into a separate method. For example, create a `ConfigureCommonServices` method in the **:::no-loc text="Client":::** project:

```csharp
public static void ConfigureCommonServices(IServiceCollection services)
{
    services.Add...;
}
```

In the client (**:::no-loc text="Client":::**) project's `Program.cs` file, call `ConfigureCommonServices` to register the common services:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

...

ConfigureCommonServices(builder.Services);
```

In the **:::no-loc text="Server":::** project's `ConfigureServices` method of `Startup.cs`, call `ConfigureCommonServices` to register the common services for the **:::no-loc text="Server":::** project:

```csharp
Client.Program.ConfigureCommonServices(services);
```

For an example of this approach, see <xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication>.

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

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_Server/Pages/dependency-injection/CustomerList.razor" highlight="2,19":::

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

Two versions of <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type are available and described in the next two sections:

* [`OwningComponentBase`](#owningcomponentbase)
* [`OwningComponentBase<TService>`](#owningcomponentbasetservice)

### `OwningComponentBase`

<xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract, disposable child of the <xref:Microsoft.AspNetCore.Components.ComponentBase> type with a protected <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property of type <xref:System.IServiceProvider>. The provider can be used to resolve services that are scoped to the lifetime of the component.

DI services injected into the component using [`@inject`](xref:mvc/views/razor#inject) or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute) aren't created in the component's scope. To use the component's scope, services must be resolved using <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> with either <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> or <xref:System.IServiceProvider.GetService%2A>. Any services resolved using the <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> provider have their dependencies provided in the component's scope.
  
The following example demonstrates the difference between injecting a scoped service directly and resolving a service using <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> in a Blazor Server app. The following interface and implementation for a time travel class include a `DT` property to hold a <xref:System.DateTime> value. The implementation calls <xref:System.DateTime.Now?displayProperty=nameWithType> to set `DT` when the `TimeTravel` class is instantiated.
  
`ITimeTravel.cs`:
  
```csharp
public interface ITimeTravel
{
    public DateTime DT { get; set; }
}
```
  
`TimeTravel.cs`:

```csharp
public class TimeTravel : ITimeTravel
{
    public DateTime DT { get; set; } = DateTime.Now;
}
```
  
The service is registered as scoped in `Program.cs` of a Blazor Server app. In a Blazor Server app, scoped services have a lifetime equal to the duration of the client connection, known as a [circuit](xref:blazor/hosting-models#blazor-server).
  
In `Program.cs`:
  
```csharp
builder.Services.AddScoped<ITimeTravel, TimeTravel>();
```

In the following `TimeTravel` component:

* The time travel service is directly injected with `@inject` as `TimeTravel1`.
* The service is also resolved separately with <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> as `TimeTravel2`.

`Pages/TimeTravel.razor`:
  
```razor
@page "/time-travel"
@inject ITimeTravel TimeTravel1
@inherits OwningComponentBase

<h1><code>OwningComponentBase</code> Example</h1>

<ul>
    <li>TimeTravel1.DT: @TimeTravel1.DT</li>
    <li>TimeTravel2.DT: @TimeTravel2.DT</li>
</ul>

@code {
    private ITimeTravel TimeTravel2 { get; set; }

    protected override void OnInitialized()
    {
        TimeTravel2 = ScopedServices.GetRequiredService<ITimeTravel>();
    }
}
```
  
If you're placing this example into a test app, add the `TimeTravel` component to the `NavMenu` component.
  
In `Shared/NavMenu.razor`:
  
```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="time-travel">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Time travel
    </NavLink>
</div>
```

Initially navigating to the `TimeTravel` component, the time travel service is instantiated twice when the component loads, and `TimeTravel1` and `TimeTravel2` have the same initial value:
  
> :::no-loc text="TimeTravel1.DT: 8/31/2022 2:54:45 PM":::  
> :::no-loc text="TimeTravel2.DT: 8/31/2022 2:54:45 PM":::
  
When navigating away from the `TimeTravel` component to another component and back to the `TimeTravel` component:

* `TimeTravel1` is provided the same service instance that was created when the component first loaded, so the value of `DT` remains the same.
* `TimeTravel2` obtains a new `ITimeTravel` service instance in `TimeTravel2` with a new DT value.
  
> :::no-loc text="TimeTravel1.DT: 8/31/2022 2:54:45 PM":::  
> :::no-loc text="TimeTravel2.DT: 8/31/2022 2:54:48 PM":::
  
`TimeTravel1` is tied to the user's circuit, which remains intact and isn't disposed until the underlying circuit is deconstructed. For example, the service is disposed if the circuit is disconnected for the [disconnected circuit retention period](xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod).

In spite of the scoped service registration in `Program.cs` and the longevity of the user's circuit, `TimeTravel2` receives a new `ITimeTravel` service instance each time the component is initialized.

### `OwningComponentBase<TService>`

<xref:Microsoft.AspNetCore.Components.OwningComponentBase%601> derives from <xref:Microsoft.AspNetCore.Components.OwningComponentBase> and adds a <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601.Service%2A> property that returns an instance of `T` from the scoped DI provider. This type is a convenient way to access scoped services without using an instance of <xref:System.IServiceProvider> when there's one primary service the app requires from the DI container using the component's scope. The <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property is available, so the app can get services of other types, if necessary.

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

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs":::

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

> [!NOTE]
> Transient service registrations for <xref:System.Net.Http.IHttpClientFactory> handlers are recommended. The `TransientExample` component in this section indicates the following transient disposables in Blazor WebAssembly apps that use authentication, which is expected:
>
> * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.BaseAddressAuthorizationMessageHandler>
> * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler>

## Detect transient disposables in Blazor Server apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_Server/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs":::

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

## Access Blazor services from a different DI scope
  
*This section only applies to Blazor Server apps.**

There may be times when a Razor component invokes asynchronous methods that execute code in a different DI scope. Without the correct approach, these DI scopes don't have access to Blazor's services, such as <xref:Microsoft.JSInterop.IJSRuntime> and <xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage>.

For example, <xref:System.Net.Http.HttpClient> instances created using <xref:System.Net.Http.IHttpClientFactory> have their own DI service scope. As a result, <xref:System.Net.Http.HttpMessageHandler> instances configured on the <xref:System.Net.Http.HttpClient> aren't able to directly inject Blazor services.

Create a class `BlazorServiceAccessor` that defines an [`AsyncLocal`](xref:System.Threading.AsyncLocal`1), which stores the Blazor <xref:System.IServiceProvider> for the current asynchronous context. A `BlazorServiceAcccessor` instance can be acquired from within a different DI service scope to access Blazor services.

`BlazorServiceAccessor.cs`:

```csharp
internal sealed class BlazorServiceAccessor
{
    private static readonly AsyncLocal<BlazorServiceHolder> s_currentServiceHolder = new();

    public IServiceProvider? Services
    {
        get => s_currentServiceHolder.Value?.Services;
        set
        {
            if (s_currentServiceHolder.Value is { } holder)
            {
                // Clear the current IServiceProvider trapped in the AsyncLocal.
                holder.Services = null;
            }

            if (value is not null)
            {
                // Use object indirection to hold the IServiceProvider in an AsyncLocal
                // so it can be cleared in all ExecutionContexts when it's cleared.
                s_currentServiceHolder.Value = new() { Services = value };
            }
        }
    }

    private sealed class BlazorServiceHolder
    {
        public IServiceProvider? Services { get; set; }
    }
}
```

To set the value of `BlazorServiceAccessor.Services` automatically when an `async` component method is invoked, create a custom base component that re-implements the three primary asynchronous entry points into Razor component code:

* <xref:Microsoft.AspNetCore.Components.IComponent.SetParametersAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.IHandleEvent.HandleEventAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.IHandleAfterRender.OnAfterRenderAsync%2A?displayProperty=nameWithType>

The following class demonstrates the implementation for the base component.
  
`CustomComponentBase.cs`:

```csharp
using Microsoft.AspNetCore.Components;

public class CustomComponentBase : ComponentBase, IHandleEvent, IHandleAfterRender
{
    private bool hasCalledOnAfterRender;

    [Inject]
    private IServiceProvider Services { get; set; } = default!;

    [Inject]
    private BlazorServiceAccessor BlazorServiceAccessor { get; set; } = default!;

    public override Task SetParametersAsync(ParameterView parameters)
        => InvokeWithBlazorServiceContext(() => base.SetParametersAsync(parameters));

    Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object? arg)
        => InvokeWithBlazorServiceContext(() =>
        {
            var task = callback.InvokeAsync(arg);
            var shouldAwaitTask = task.Status != TaskStatus.RanToCompletion &&
                task.Status != TaskStatus.Canceled;

            StateHasChanged();

            return shouldAwaitTask ?
                CallStateHasChangedOnAsyncCompletion(task) :
                Task.CompletedTask;
        });

    Task IHandleAfterRender.OnAfterRenderAsync()
        => InvokeWithBlazorServiceContext(() =>
        {
            var firstRender = !hasCalledOnAfterRender;
            hasCalledOnAfterRender |= true;

            OnAfterRender(firstRender);

            return OnAfterRenderAsync(firstRender);
        });

    private async Task CallStateHasChangedOnAsyncCompletion(Task task)
    {
        try
        {
            await task;
        }
        catch
        {
            if (task.IsCanceled)
            {
                return;
            }

            throw;
        }

        StateHasChanged();
    }

    private async Task InvokeWithBlazorServiceContext(Func<Task> func)
    {
        try
        {
            BlazorServiceAccessor.Services = Services;
            await func();
        }
        finally
        {
            BlazorServiceAccessor.Services = null;
        }
    }
}
```

Any components extending `CustomComponentBase` automatically have `BlazorServiceAccessor.Services` set to the <xref:System.IServiceProvider> in the current Blazor DI scope.

Finally, in `Program.cs`, add the `BlazorServiceAccessor` as a scoped service:

```csharp
var builder = WebApplication.CreateBuilder(args);
// ...
builder.Services.AddScoped<BlazorServiceAccessor>();
// ...
```

## Additional resources

* <xref:fundamentals/dependency-injection>
* [`IDisposable` guidance for Transient and shared instances](xref:fundamentals/dependency-injection#idisposable-guidance-for-transient-and-shared-instances)
* <xref:mvc/views/dependency-injection>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

[Dependency injection (DI)](xref:fundamentals/dependency-injection) is a technique for accessing services configured in a central location:

* Framework-registered services can be injected directly into components of Blazor apps.
* Blazor apps define and register custom services and make them available throughout the app via DI.

> [!NOTE]
> We recommend reading <xref:fundamentals/dependency-injection> before reading this topic.

## Default services

The services shown in the following table are commonly used in Blazor apps.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Scoped | <p>Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</p><p>The instance of <xref:System.Net.Http.HttpClient> in a Blazor WebAssembly app uses the browser for handling the HTTP traffic in the background.</p><p>Blazor Server apps don't include an <xref:System.Net.Http.HttpClient> configured as a service by default. Provide an <xref:System.Net.Http.HttpClient> to a Blazor Server app.</p><p>For more information, see <xref:blazor/call-web-api>.</p><p>An <xref:System.Net.Http.HttpClient> is registered as a scoped service, not singleton. For more information, see the [Service lifetime](#service-lifetime) section.</p> |
| <xref:Microsoft.JSInterop.IJSRuntime> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p><p>The Blazor framework registers <xref:Microsoft.JSInterop.IJSRuntime> in the app's service container.</p> | <p>Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet>.</p><p>When seeking to inject the service into a singleton service in Blazor Server apps, take either of the following approaches:</p><ul><li>Change the service registration to scoped to match <xref:Microsoft.JSInterop.IJSRuntime>'s registration, which is appropriate if the service deals with user-specific state.</li><li>Pass the <xref:Microsoft.JSInterop.IJSRuntime> into the singleton service's implementation as an argument of its method calls instead of injecting it into the singleton.</li></ul> |
| <xref:Microsoft.AspNetCore.Components.NavigationManager> | <p>**Blazor WebAssembly**: Singleton</p><p>**Blazor Server**: Scoped</p><p>The Blazor framework registers <xref:Microsoft.AspNetCore.Components.NavigationManager> in the app's service container.</p> | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/fundamentals/routing#uri-and-navigation-state-helpers). |

Additional services registered by the Blazor framework are described in the documentation where they're used to describe Blazor features, such as configuration and logging.

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

If one or more common services are required by the **:::no-loc text="Server":::** and **:::no-loc text="Client":::** projects of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln), you can place the common service registrations in a method in the **:::no-loc text="Client":::** project and call the method to register the services in both projects.

First, factor common service registrations into a separate method. For example, create a `ConfigureCommonServices` method in the **:::no-loc text="Client":::** project:

```csharp
public static void ConfigureCommonServices(IServiceCollection services)
{
    services.Add...;
}
```

In the **:::no-loc text="Client":::** project's `Program.cs` file, call `ConfigureCommonServices` to register the common services:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

...

ConfigureCommonServices(builder.Services);
```

In the **:::no-loc text="Server":::** project's `ConfigureServices` method of `Startup.cs`, call `ConfigureCommonServices` to register the common services for the **:::no-loc text="Server":::** project:

```csharp
Client.Program.ConfigureCommonServices(services);
```

For an example of this approach, see <xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication>.

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

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_Server/Pages/dependency-injection/CustomerList.razor" highlight="2,19":::

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

Two versions of <xref:Microsoft.AspNetCore.Components.OwningComponentBase> type are available and described in the next two sections:

* [`OwningComponentBase`](#owningcomponentbase)
* [`OwningComponentBase<TService>`](#owningcomponentbasetservice)

### `OwningComponentBase`

<xref:Microsoft.AspNetCore.Components.OwningComponentBase> is an abstract, disposable child of the <xref:Microsoft.AspNetCore.Components.ComponentBase> type with a protected <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property of type <xref:System.IServiceProvider>. The provider can be used to resolve services that are scoped to the lifetime of the component.

DI services injected into the component using [`@inject`](xref:mvc/views/razor#inject) or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute) aren't created in the component's scope. To use the component's scope, services must be resolved using <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> with either <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> or <xref:System.IServiceProvider.GetService%2A>. Any services resolved using the <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> provider have their dependencies provided in the component's scope.
  
The following example demonstrates the difference between injecting a scoped service directly and resolving a service using <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> in a Blazor Server app. The following interface and implementation for a time travel class include a `DT` property to hold a <xref:System.DateTime> value. The implementation calls <xref:System.DateTime.Now?displayProperty=nameWithType> to set `DT` when the `TimeTravel` class is instantiated.
  
`ITimeTravel.cs`:
  
```csharp
public interface ITimeTravel
{
    public DateTime DT { get; set; }
}
```
  
`TimeTravel.cs`:

```csharp
public class TimeTravel : ITimeTravel
{
    public DateTime DT { get; set; } = DateTime.Now;
}
```
  
The service is registered as scoped in `Program.cs` of a Blazor Server app. In a Blazor Server app, scoped services have a lifetime equal to the duration of the client connection, known as a [circuit](xref:blazor/hosting-models#blazor-server).
  
In `Program.cs`:
  
```csharp
builder.Services.AddScoped<ITimeTravel, TimeTravel>();
```

In the following `TimeTravel` component:

* The time travel service is directly injected with `@inject` as `TimeTravel1`.
* The service is also resolved separately with <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> as `TimeTravel2`.

`Pages/TimeTravel.razor`:
  
```razor
@page "/time-travel"
@inject ITimeTravel TimeTravel1
@inherits OwningComponentBase

<h1><code>OwningComponentBase</code> Example</h1>

<ul>
    <li>TimeTravel1.DT: @TimeTravel1.DT</li>
    <li>TimeTravel2.DT: @TimeTravel2.DT</li>
</ul>

@code {
    private ITimeTravel TimeTravel2 { get; set; }

    protected override void OnInitialized()
    {
        TimeTravel2 = ScopedServices.GetRequiredService<ITimeTravel>();
    }
}
```
  
If you're placing this example into a test app, add the `TimeTravel` component to the `NavMenu` component.
  
In `Shared/NavMenu.razor`:
  
```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="time-travel">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Time travel
    </NavLink>
</div>
```

Initially navigating to the `TimeTravel` component, the time travel service is instantiated twice when the component loads, and `TimeTravel1` and `TimeTravel2` have the same initial value:
  
> :::no-loc text="TimeTravel1.DT: 8/31/2022 2:54:45 PM":::  
> :::no-loc text="TimeTravel2.DT: 8/31/2022 2:54:45 PM":::
  
When navigating away from the `TimeTravel` component to another component and back to the `TimeTravel` component:

* `TimeTravel1` is provided the same service instance that was created when the component first loaded, so the value of `DT` remains the same.
* `TimeTravel2` obtains a new `ITimeTravel` service instance in `TimeTravel2` with a new DT value.
  
> :::no-loc text="TimeTravel1.DT: 8/31/2022 2:54:45 PM":::  
> :::no-loc text="TimeTravel2.DT: 8/31/2022 2:54:48 PM":::
  
`TimeTravel1` is tied to the user's circuit, which remains intact and isn't disposed until the underlying circuit is deconstructed. For example, the service is disposed if the circuit is disconnected for the [disconnected circuit retention period](xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod).

In spite of the scoped service registration in `Program.cs` and the longevity of the user's circuit, `TimeTravel2` receives a new `ITimeTravel` service instance each time the component is initialized.

### `OwningComponentBase<TService>`

<xref:Microsoft.AspNetCore.Components.OwningComponentBase%601> derives from <xref:Microsoft.AspNetCore.Components.OwningComponentBase> and adds a <xref:Microsoft.AspNetCore.Components.OwningComponentBase%601.Service%2A> property that returns an instance of `T` from the scoped DI provider. This type is a convenient way to access scoped services without using an instance of <xref:System.IServiceProvider> when there's one primary service the app requires from the DI container using the component's scope. The <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices> property is available, so the app can get services of other types, if necessary.

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

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs":::

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

> [!NOTE]
> Transient service registrations for <xref:System.Net.Http.IHttpClientFactory> handlers are recommended. The `TransientExample` component in this section indicates the following transient disposables in Blazor WebAssembly apps that use authentication, which is expected:
>
> * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.BaseAddressAuthorizationMessageHandler>
> * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler>

## Detect transient disposables in Blazor Server apps

The following example shows how to detect disposable transient services in an app that should use <xref:Microsoft.AspNetCore.Components.OwningComponentBase>. For more information, see the [Utility base component classes to manage a DI scope](#utility-base-component-classes-to-manage-a-di-scope) section.

`DetectIncorrectUsagesOfTransientDisposables.cs`:

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_Server/dependency-injection/DetectIncorrectUsagesOfTransientDisposables.cs":::

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

## Access Blazor services from a different DI scope
  
*This section only applies to Blazor Server apps.**

There may be times when a Razor component invokes asynchronous methods that execute code in a different DI scope. Without the correct approach, these DI scopes don't have access to Blazor's services, such as <xref:Microsoft.JSInterop.IJSRuntime> and <xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage>.

For example, <xref:System.Net.Http.HttpClient> instances created using <xref:System.Net.Http.IHttpClientFactory> have their own DI service scope. As a result, <xref:System.Net.Http.HttpMessageHandler> instances configured on the <xref:System.Net.Http.HttpClient> aren't able to directly inject Blazor services.

Create a class `BlazorServiceAccessor` that defines an [`AsyncLocal`](xref:System.Threading.AsyncLocal`1), which stores the Blazor <xref:System.IServiceProvider> for the current asynchronous context. A `BlazorServiceAcccessor` instance can be acquired from within a different DI service scope to access Blazor services.

`BlazorServiceAccessor.cs`:

```csharp
internal sealed class BlazorServiceAccessor
{
    private static readonly AsyncLocal<BlazorServiceHolder> s_currentServiceHolder = new();

    public IServiceProvider? Services
    {
        get => s_currentServiceHolder.Value?.Services;
        set
        {
            if (s_currentServiceHolder.Value is { } holder)
            {
                // Clear the current IServiceProvider trapped in the AsyncLocal.
                holder.Services = null;
            }

            if (value is not null)
            {
                // Use object indirection to hold the IServiceProvider in an AsyncLocal
                // so it can be cleared in all ExecutionContexts when it's cleared.
                s_currentServiceHolder.Value = new() { Services = value };
            }
        }
    }

    private sealed class BlazorServiceHolder
    {
        public IServiceProvider? Services { get; set; }
    }
}
```

To set the value of `BlazorServiceAccessor.Services` automatically when an `async` component method is invoked, create a custom base component that re-implements the three primary asynchronous entry points into Razor component code:

* <xref:Microsoft.AspNetCore.Components.IComponent.SetParametersAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.IHandleEvent.HandleEventAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.IHandleAfterRender.OnAfterRenderAsync%2A?displayProperty=nameWithType>

The following class demonstrates the implementation for the base component.
  
`CustomComponentBase.cs`:

```csharp
using Microsoft.AspNetCore.Components;

public class CustomComponentBase : ComponentBase, IHandleEvent, IHandleAfterRender
{
    private bool hasCalledOnAfterRender;

    [Inject]
    private IServiceProvider Services { get; set; } = default!;

    [Inject]
    private BlazorServiceAccessor BlazorServiceAccessor { get; set; } = default!;

    public override Task SetParametersAsync(ParameterView parameters)
        => InvokeWithBlazorServiceContext(() => base.SetParametersAsync(parameters));

    Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object? arg)
        => InvokeWithBlazorServiceContext(() =>
        {
            var task = callback.InvokeAsync(arg);
            var shouldAwaitTask = task.Status != TaskStatus.RanToCompletion &&
                task.Status != TaskStatus.Canceled;

            StateHasChanged();

            return shouldAwaitTask ?
                CallStateHasChangedOnAsyncCompletion(task) :
                Task.CompletedTask;
        });

    Task IHandleAfterRender.OnAfterRenderAsync()
        => InvokeWithBlazorServiceContext(() =>
        {
            var firstRender = !hasCalledOnAfterRender;
            hasCalledOnAfterRender |= true;

            OnAfterRender(firstRender);

            return OnAfterRenderAsync(firstRender);
        });

    private async Task CallStateHasChangedOnAsyncCompletion(Task task)
    {
        try
        {
            await task;
        }
        catch
        {
            if (task.IsCanceled)
            {
                return;
            }

            throw;
        }

        StateHasChanged();
    }

    private async Task InvokeWithBlazorServiceContext(Func<Task> func)
    {
        try
        {
            BlazorServiceAccessor.Services = Services;
            await func();
        }
        finally
        {
            BlazorServiceAccessor.Services = null;
        }
    }
}
```

Any components extending `CustomComponentBase` automatically have `BlazorServiceAccessor.Services` set to the <xref:System.IServiceProvider> in the current Blazor DI scope.

Finally, in `Program.cs`, add the `BlazorServiceAccessor` as a scoped service:

```csharp
var builder = WebApplication.CreateBuilder(args);
// ...
builder.Services.AddScoped<BlazorServiceAccessor>();
// ...
```

## Additional resources

* <xref:fundamentals/dependency-injection>
* [`IDisposable` guidance for Transient and shared instances](xref:fundamentals/dependency-injection#idisposable-guidance-for-transient-and-shared-instances)
* <xref:mvc/views/dependency-injection>

:::moniker-end
