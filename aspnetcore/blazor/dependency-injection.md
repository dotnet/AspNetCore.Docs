---
title: ASP.NET Core Blazor dependency injection
author: guardrex
description: See how Blazor apps can inject services into components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/29/2020
no-loc: [Blazor, SignalR]
uid: blazor/dependency-injection
---
# ASP.NET Core Blazor dependency injection

By [Rainer Stropek](https://www.timecockpit.com)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

Blazor supports [dependency injection (DI)](xref:fundamentals/dependency-injection). Apps can use built-in services by injecting them into components. Apps can also define and register custom services and make them available throughout the app via DI.

DI is a technique for accessing services configured in a central location. This can be useful in Blazor apps to:

* Share a single instance of a service class across many components, known as a *singleton* service.
* Decouple components from concrete service classes by using reference abstractions. For example, consider an interface `IDataAccess` for accessing data in the app. The interface is implemented by a concrete `DataAccess` class and registered as a service in the app's service container. When a component uses DI to receive an `IDataAccess` implementation, the component isn't coupled to the concrete type. The implementation can be swapped, perhaps for a mock implementation in unit tests.

## Default services

Default services are automatically added to the app's service collection.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Singleton | Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.<br><br>The instance of `HttpClient` in a Blazor WebAssembly app uses the browser for handling the HTTP traffic in the background.<br><br>Blazor Server apps don't include an `HttpClient` configured as a service by default. Provide an `HttpClient` to a Blazor Server app.<br><br>For more information, see <xref:blazor/call-web-api>. |
| `IJSRuntime` | Singleton (Blazor WebAssembly)<br>Scoped (Blazor Server) | Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/javascript-interop>. |
| `NavigationManager` | Singleton (Blazor WebAssembly)<br>Scoped (Blazor Server) | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/routing#uri-and-navigation-state-helpers). |

A custom service provider doesn't automatically provide the default services listed in the table. If you use a custom service provider and require any of the services shown in the table, add the required services to the new service provider.

## Add services to an app

### Blazor WebAssembly

Configure services for the app's service collection in the `Main` method of *Program.cs*. In the following example, the `MyDependency` implementation is registered for `IMyDependency`:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddSingleton<IMyDependency, MyDependency>();
        builder.RootComponents.Add<App>("app");

        await builder.Build().RunAsync();
    }
}
```

Once the host is built, services can be accessed from the root DI scope before any components are rendered. This can be useful for running initialization logic before rendering content:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddSingleton<WeatherService>();
        builder.RootComponents.Add<App>("app");

        var host = builder.Build();

        var weatherService = host.Services.GetRequiredService<WeatherService>();
        await weatherService.InitializeWeatherAsync();

        await host.RunAsync();
    }
}
```

The host also provides a central configuration instance for the app. Building on the preceding example, the weather service's URL is passed from a default configuration source (for example, *appsettings.json*) to `InitializeWeatherAsync`:

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddSingleton<WeatherService>();
        builder.RootComponents.Add<App>("app");

        var host = builder.Build();

        var weatherService = host.Services.GetRequiredService<WeatherService>();
        await weatherService.InitializeWeatherAsync(
            host.Configuration["WeatherServiceUrl"]);

        await host.RunAsync();
    }
}
```

### Blazor Server

After creating a new app, examine the `Startup.ConfigureServices` method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Add custom services here
}
```

The `ConfigureServices` method is passed an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>, which is a list of service descriptor objects (<xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor>). Services are added by providing service descriptors to the service collection. The following example demonstrates the concept with the `IDataAccess` interface and its concrete implementation `DataAccess`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDataAccess, DataAccess>();
}
```

### Service lifetime

Services can be configured with the lifetimes shown in the following table.

| Lifetime | Description |
| -------- | ----------- |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped*> | Blazor WebAssembly apps don't currently have a concept of DI scopes. `Scoped`-registered services behave like `Singleton` services. However, the Blazor Server hosting model supports the `Scoped` lifetime. In Blazor Server apps, a scoped service registration is scoped to the *connection*. For this reason, using scoped services is preferred for services that should be scoped to the current user, even if the current intent is to run client-side in the browser. |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton*> | DI creates a *single instance* of the service. All components requiring a `Singleton` service receive an instance of the same service. |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient*> | Whenever a component obtains an instance of a `Transient` service from the service container, it receives a *new instance* of the service. |

The DI system is based on the DI system in ASP.NET Core. For more information, see <xref:fundamentals/dependency-injection>.

## Request a service in a component

After services are added to the service collection, inject the services into the components using the [\@inject](xref:mvc/views/razor#inject) Razor directive. `@inject` has two parameters:

* Type &ndash; The type of the service to inject.
* Property &ndash; The name of the property receiving the injected app service. The property doesn't require manual creation. The compiler creates the property.

For more information, see <xref:mvc/views/dependency-injection>.

Use multiple `@inject` statements to inject different services.

The following example shows how to use `@inject`. The service implementing `Services.IDataAccess` is injected into the component's property `DataRepository`. Note how the code is only using the `IDataAccess` abstraction:

[!code-razor[](dependency-injection/samples_snapshot/3.x/CustomerList.razor?highlight=2-3,23)]

Internally, the generated property (`DataRepository`) uses the `InjectAttribute` attribute. Typically, this attribute isn't used directly. If a base class is required for components and injected properties are also required for the base class, manually add the `InjectAttribute`:

```csharp
public class ComponentBase : IComponent
{
    // DI works even if using the InjectAttribute in a component's base class.
    [Inject]
    protected IDataAccess DataRepository { get; set; }
    ...
}
```

In components derived from the base class, the `@inject` directive isn't required. The `InjectAttribute` of the base class is sufficient:

```razor
@page "/demo"
@inherits ComponentBase

<h1>Demo Component</h1>
```

## Use DI in services

Complex services might require additional services. In the prior example, `DataAccess` might require the `HttpClient` default service. `@inject` (or the `InjectAttribute`) isn't available for use in services. *Constructor injection* must be used instead. Required services are added by adding parameters to the service's constructor. When DI creates the service, it recognizes the services it requires in the constructor and provides them accordingly.

```csharp
public class DataAccess : IDataAccess
{
    // The constructor receives an HttpClient via dependency
    // injection. HttpClient is a default service.
    public DataAccess(HttpClient client)
    {
        ...
    }
}
```

Prerequisites for constructor injection:

* One constructor must exist whose arguments can all be fulfilled by DI. Additional parameters not covered by DI are allowed if they specify default values.
* The applicable constructor must be *public*.
* One applicable constructor must exist. In case of an ambiguity, DI throws an exception.

## Utility base component classes to manage a DI scope

In ASP.NET Core apps, scoped services are typically scoped to the current request. After the request completes, any scoped or transient services are disposed by the DI system. In Blazor Server apps, the request scope lasts for the duration of the client connection, which can result in transient and scoped services living much longer than expected. Similarly, in Blazor WebAssembly apps, scoped services are treated as singletons, so they will live longer than scoped services would in most ASP.NET Core apps.

An option for limiting service lifetime in Blazor apps is the `OwningComponentBase` type. `OwningComponentBase` is an abstract type derived from `ComponentBase` that creates a DI scope corresponding to the lifetime of the component. Using this scope, it's possible to use DI services with a scoped lifetime and have them live as long as the component. When the component is destroyed, services from the component's scoped service provider will be disposed, as well. This can be useful for services that should be reused within a component (so the transient lifetime isn't appropriate), but should not be shared across components (making the singleton lifetime inappropriate).

There are two versions of the `OwningComponentBase` type:

* `OwningComponentBase` is an abstract disposable child of the `ComponentBase` type with a protected `ScopedServices` property of type `IServiceProvider`. This provider can be used to resolve services that are scoped to the lifetime of the component. Note that DI services injected into the component using `@inject` or the `InjectAttribute` aren't created in the component's scope. To use the component's scope, services must be resolved using `ScopedServices.GetRequiredService` or `ScopedServices.GetService`. Any services resolved using the `ScopedServices` provider will have their dependencies provided from that same scope.

    ```razor
    @page "/preferences"
    @using Microsoft.Extensions.DependencyInjection
    @inherits OwningComponentBase

    <h1>User (@UserService.Name)</h1>
    <ul>
        @foreach (var setting in SettingService.GetSettings())
        {
            <li>@setting.SettingName: @setting.SettingValue</li>
        }
    </ul>

    @code {
        private IUserService UserService { get; set; }
        private ISettingService SettingService { get; set; }
        
        protected override void OnInitialized()
        {
            UserService = ScopedServices.GetRequiredService<IUserService>();
            SettingService = ScopedServices.GetRequiredService<ISettingService>();
        }
    }
    ```

* `OwningComponentBase<T>` derives from `OwningComponentBase` and adds a property `Service` that returns an instance of `T` from the scoped DI provider. This type is a convenient way to access scoped services without using an instance of `IServiceProvider` when there's one primary service you will need from the DI container using the component's scope. Note that the `ScopedServices` property is still available, so you can get services of other types from there, if necessary.

    ```razor
    @page "/users"
    @attribute [Authorize]
    @inherits OwningComponentBase<Data.ApplicationDbContext>

    <h1>Users (@Service.Users.Count())</h1>
    <ul>
        @foreach (var user in Service.Users)
        {
            <li>@user.UserName</li>
        }
    </ul>
    ```

### Using Entity Framework DbContexts from DI in Blazor apps

One common type of service to retrieve from DI in ASP.NET Core web apps is Entity Framework `DbContext` objects. Registering EF services using `IServiceCollection.AddDbContext` will add the `DbContext` as a scoped service, by default. This can easily lead to problems in Blazor apps since this will cause `DbContext` instances to be long-lived and shared across the app. `DbContext` is not thread-safe and must not be used concurrently.

Depending on the app, using `OwningComponentBase` to limit the scope of a `DbContext` to a single component may solve the issue. Keep in mind, though, that if a single component might use a `DbContext` concurrently (every time a user clicks a button, for example) then even using `OwningComponentBase` won't avoid issues with concurrent EF operations. In that case, you should use a different `DbContext` for each logical EF operation, either by creating the `DbContext` directly (using `DbContextOptions<TContext>` as an argument, which can be retrieved from DI and is thread safe) or by registering the `DbContext` in DI with a transient lifetime (by passing `ServiceLifetime.Transient` when registering the context with DI) and requesting a new instance for each logical EF operation.

If a component will not use a `DbContext` in parallel, however, deriving the component from `OwningComponentBase` and retrieving the `DbContext` from `ScopedServices` will be sufficient because it will ensure that separate components do not share a `DbContext` and that the `DbContext` lives only as long as the component depending on it.

## Additional resources

* <xref:fundamentals/dependency-injection>
* <xref:mvc/views/dependency-injection>
