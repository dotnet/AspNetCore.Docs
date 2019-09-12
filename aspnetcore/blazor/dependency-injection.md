---
title: ASP.NET Core Blazor dependency injection
author: guardrex
description: See how Blazor apps can inject services into components.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/06/2019
uid: blazor/dependency-injection
---
# ASP.NET Core Blazor dependency injection

By [Rainer Stropek](https://www.timecockpit.com)

Blazor supports [dependency injection (DI)](xref:fundamentals/dependency-injection). Apps can use built-in services by injecting them into components. Apps can also define and register custom services and make them available throughout the app via DI.

DI is a technique for accessing services configured in a central location. This can be useful in Blazor apps to:

* Share a single instance of a service class across many components, known as a *singleton* service.
* Decouple components from concrete service classes by using reference abstractions. For example, consider an interface `IDataAccess` for accessing data in the app. The interface is implemented by a concrete `DataAccess` class and registered as a service in the app's service container. When a component uses DI to receive an `IDataAccess` implementation, the component isn't coupled to the concrete type. The implementation can be swapped, perhaps for a mock implementation in unit tests.

## Default services

Default services are automatically added to the app's service collection.

| Service | Lifetime | Description |
| ------- | -------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Singleton | Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI. Note that this instance of `HttpClient` uses the browser for handling the HTTP traffic in the background. [HttpClient.BaseAddress](xref:System.Net.Http.HttpClient.BaseAddress) is automatically set to the base URI prefix of the app. For more information, see <xref:blazor/call-web-api>. |
| `IJSRuntime` | Singleton | Represents an instance of a JavaScript runtime where JavaScript calls are dispatched. For more information, see <xref:blazor/javascript-interop>. |
| `NavigationManager` | Singleton | Contains helpers for working with URIs and navigation state. For more information, see [URI and navigation state helpers](xref:blazor/routing#uri-and-navigation-state-helpers). |

A custom service provider doesn't automatically provide the default services listed in the table. If you use a custom service provider and require any of the services shown in the table, add the required services to the new service provider.

## Add services to an app

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

[!code-cshtml[](dependency-injection/samples_snapshot/3.x/CustomerList.razor?highlight=2-3,23)]

Internally, the generated property (`DataRepository`) is decorated with the `InjectAttribute` attribute. Typically, this attribute isn't used directly. If a base class is required for components and injected properties are also required for the base class, manually add the `InjectAttribute`:

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

```cshtml
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

In ASP.NET Core apps, scoped services are typically scoped to the current request. After the request completes, any scoped or transient services are disposed by the DI system. In Blazor Server apps, the request scope lasts for the duration of the client connection, which can result in transient and scoped services living much longer than expected.

To scope services to the lifetime of a component, can use the `OwningComponentBase` and `OwningComponentBase<TService>` base classes. These base classes expose a `ScopedServices` property of type `IServiceProvider` that resolve services that are scoped to the lifetime of the component. To author a component that inherits from a base class in Razor, use the `@inherits` directive.

```cshtml
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

> [!NOTE]
> Services injected into the component using `@inject` or the `InjectAttribute` aren't created in the component's scope and are tied to the request scope.

## Additional resources

* <xref:fundamentals/dependency-injection>
* <xref:mvc/views/dependency-injection>
