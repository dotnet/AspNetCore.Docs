---
title: Blazor dependency injection
author: guardrex
description: See how Blazor apps can inject services into components.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/15/2019
uid: blazor/dependency-injection
---
# Blazor dependency injection

By [Rainer Stropek](https://www.timecockpit.com)

Blazor supports [dependency injection (DI)](xref:fundamentals/dependency-injection). Apps can use built-in services by injecting them into components. Apps can also define and register custom services and make them available throughout the app via DI.

## Dependency injection

DI is a technique for accessing services configured in a central location. This can be useful in Blazor apps to:

* Share a single instance of a service class across many components, known as a *singleton* service.
* Decouple components from concrete service classes by using reference abstractions. For example, consider an interface `IDataAccess` for accessing data in the app. The interface is implemented by a concrete `DataAccess` class and registered as a service in the app's service container. When a component uses DI to receive an `IDataAccess` implementation, the component isn't coupled to the concrete type. The implementation can be swapped, perhaps to a mock implementation in unit tests.

For more information, see <xref:fundamentals/dependency-injection>.

## Add services to DI

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
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton*> | DI creates a *single instance* of the service. All components requiring a `Singleton` service receive an instance of the same service. |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient*> | Whenever a component obtains an instance of a `Transient` service from the service container, it receives a *new instance* of the service. |
| <xref:Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped*> | Client-side Blazor doesn't currently have the concept of DI scopes. `Scoped` behaves like `Singleton`. However, the server-side hosting model supports the `Scoped` lifetime. In a Razor component, a scoped service registration is scoped to the connection. For this reason, using scoped services is preferred for services that should be scoped to the current user, even if the current intent is to run client-side in the browser. |

The DI system is based on the DI system in ASP.NET Core. For more information, see <xref:fundamentals/dependency-injection>.

## Default services

Default services are automatically added to the app's service collection.

| Service | Description |
| ------- | ----------- |
| <xref:System.Net.Http.HttpClient> | Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI (singleton). Note that this instance of `HttpClient` uses the browser for handling the HTTP traffic in the background. [HttpClient.BaseAddress](xref:System.Net.Http.HttpClient.BaseAddress) is automatically set to the base URI prefix of the app. `HttpClient` is only provided to client-side Blazor apps. |
| `IJSRuntime` | Represents an instance of a JavaScript runtime to which calls may be dispatched. For more information, see <xref:blazor/javascript-interop>. |
| `IUriHelper` | Contains helpers for working with URIs and navigation state (singleton). |

It's possible to use a custom service provider instead of the default service provider added by the default template. A custom service provider doesn't automatically provide the default services listed in the table. If you use a custom service provider and require any of the services shown in the table, add the required services to the new service provider.

## Request a service in a component

After services are added to the service collection, inject the services into the components' Razor templates using the [\@inject](xref:mvc/views/razor#section-4) Razor directive. `@inject` has two parameters:

* Type name: The type of the service to inject.
* Property name: The name of the property receiving the injected app service. Note that the property doesn't require manual creation. The compiler creates the property.

For more information, see <xref:mvc/views/dependency-injection>.

Use multiple `@inject` statements to inject different services.

The following example shows how to use `@inject`. The service implementing `Services.IDataAccess` is injected into the component's property `DataRepository`. Note how the code is only using the `IDataAccess` abstraction:

[!code-cshtml[](dependency-injection/samples_snapshot/3.x/CustomerList.razor?highlight=2-3,23)]

Internally, the generated property (`DataRepository`) is decorated with the `InjectAttribute` attribute. Typically, this attribute isn't used directly. If a base class is required for components and injected properties are also required for the base class, `InjectAttribute` can be manually added:

```csharp
public class ComponentBase : IComponent
{
    // Dependency injection works even if using the
    // InjectAttribute in a component's base class.
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

## Dependency injection in services

Complex services might require additional services. In the prior example, `DataAccess` might require the `HttpClient` default service. `@inject` (or the `InjectAttribute`) isn't available for use in services. *Constructor injection* must be used instead. Required services are added by adding parameters to the service's constructor. When dependency injection creates the service, it recognizes the services it requires in the constructor and provides them accordingly.

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

* There must be one constructor whose arguments can all be fulfilled by dependency injection. Note that additional parameters not covered by DI are allowed if they specify default values.
* The applicable constructor must be *public*.
* There must only be one applicable constructor. In case of an ambiguity, DI throws an exception.

## Additional resources

* <xref:fundamentals/dependency-injection>
* <xref:mvc/views/dependency-injection>
