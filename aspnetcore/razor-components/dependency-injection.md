---
title: Razor Components dependency injection
author: guardrex
description: See how Blazor and Razor Components apps can use built-in services by having them injected into components.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/29/2019
uid: razor-components/dependency-injection
---
# Razor Components dependency injection

By [Rainer Stropek](https://www.timecockpit.com)

[Dependency injection (DI)](/aspnet/core/fundamentals/dependency-injection) is built-in. Apps can use built-in services by having them injected into components. Apps can also define custom services and make them available via DI.

## Dependency injection

DI is a technique for accessing services configured in a central location. This can be useful to:

* Share a single instance of a service class across many components (known as a *singleton* service).
* Decouple components from particular concrete service classes and only reference abstractions. For example, an interface `IDataAccess` is implemented by a concrete class `DataAccess`. When a component uses DI to receive an `IDataAccess` implementation, the component isn't coupled to the concrete type. The implementation can be swapped, perhaps to a mock implementation in unit tests.

The DI system is responsible for supplying instances of services to components. DI also resolves dependencies recursively so that services themselves can depend on further services. DI is configured during startup of the app. An example is shown later in this topic.

## Add services to DI

After creating a new app, examine the `Startup.ConfigureServices` method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Add custom services here
}
```

The `ConfigureServices` method is passed an [IServiceCollection](/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection), which is a list of service descriptor objects ([ServiceDescriptor](/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor)). Services are added by providing service descriptors to the service collection. The following code sample demonstrates the concept:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDataAccess, DataAccess>();
}
```

Services can be configured with the following lifetimes:

| Method      | Description |
| ----------- | ----------- |
| [Singleton](/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor.singleton#Microsoft_Extensions_DependencyInjection_ServiceDescriptor_Singleton__1_System_Func_System_IServiceProvider___0__) | DI creates a *single instance* of the service. All components requiring this service receive a reference to this instance. |
| [Transient](/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor.transient) | Whenever a component requires this service, it receives a *new instance* of the service. |
| [Scoped](/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor.scoped) | Client-side Blazor doesn't currently have the concept of DI scopes. `Scoped` behaves like `Singleton`. However, ASP.NET Core Razor Components support the `Scoped` lifetime. In a Razor Component, a scoped service registration is scoped to the connection. For this reason, using scoped services is preferred for services that should be scoped to the current user (even if the current intent is to run client-side in the browser). |

The DI system is based on the DI system in ASP.NET Core. For more information, see [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection).

## Default services

Default services are automatically added to the service collection of an app. The following table shows some of the useful default services provided.

| Method       | Description |
| ------------ | ----------- |
| [HttpClient](/dotnet/api/system.net.http.httpclient) | Provides methods for sending HTTP requests and receiving HTTP responses from a resource identified by a URI (singleton). Note that this instance of `HttpClient` uses the browser for handling the HTTP traffic in the background. [HttpClient.BaseAddress](/dotnet/api/system.net.http.httpclient.baseaddress) is automatically set to the base URI prefix of the app. `HttpClient` is only provided to client-side Blazor apps. |
| `IJSRuntime` | Represents an instance of a JavaScript runtime to which calls may be dispatched. For more information, see <xref:razor-components/javascript-interop>. |
| `IUriHelper` | Helpers for working with URIs and navigation state (singleton). `IUriHelper` is provided to both client-side Blazor and ASP.NET Core Razor Components apps. |

Note that it is possible to use a custom services provider instead of the default service provider that's added by the default template. A custom service provider doesn't automatically provide the default services listed in the table. Those services must be added to the new service provider explicitly.

## Request a service in a component

Once services are added to the service collection, they can be injected into the components' Razor templates using the `@inject` Razor directive. `@inject` has two parameters:

* Type name: The type of the service to inject.
* Property name: The name of the property receiving the injected app service. Note that the property doesn't require manual creation. The compiler creates the property.

Multiple `@inject` statements can be used to inject different services.

The following example shows how to use `@inject`. The service implementing `Services.IDataAccess` is injected into the component's property `DataRepository`. Note how the code is only using the `IDataAccess` abstraction:

```csharp
@page "/customer-list"
@using Services
@inject IDataAccess DataRepository

<ul>
    @if (Customers != null)
    {
        @foreach (var customer in Customers)
        {
            <li>@customer.FirstName @customer.LastName</li>
        }
    }
</ul>

@functions {
    private IReadOnlyList<Customer> Customers;

    protected override async Task OnInitAsync()
    {
        // The property DataRepository received an implementation
        // of IDataAccess through dependency injection. Use 
        // DataRepository to obtain data from the server.
        Customers = await DataRepository.GetAllCustomersAsync();
    }
}
```

Internally, the generated property (`DataRepository`) is decorated with the `InjectAttribute` attribute. Typically, this attribute isn't used directly. If a base class is required for components and injected properties are also required for the base class, `InjectAttribute` can be manually added:

```csharp
public class ComponentBase : BlazorComponent
{
    // Dependency injection works even if using the
    // InjectAttribute in a component's base class.
    [Inject]
    protected IDataAccess DataRepository { get; set; }
    ...
}
```

In components derived from the base class, the `@inject` directive isn't required. The `InjectAttribute` of the base class is sufficient:

```csharp
@page "/demo"
@inherits ComponentBase

<h1>...</h1>
...
```

## Dependency injection in services

Complex services might require additional services. In the prior example, `DataAccess` might require the `HttpClient` default service. `@inject` or the `InjectAttribute` can't be used in services. *Constructor injection* must be used instead. Required services are added by adding parameters to the service's constructor. When dependency injection creates the service, it recognizes the services it requires in the constructor and provides them accordingly.

The following code sample demonstrates the concept:

```csharp
public class DataAccess : IDataAccess
{
    // The constructor receives an HttpClient via dependency
    // injection. HttpClient is a default service.
    public DataAccess(HttpClient client)
    {
        ...
    }
    ...
}
```

Note the following prerequisites for constructor injection:

* There must be one constructor whose arguments can all be fulfilled by dependency injection. Note that additional parameters not covered by DI are allowed if default values are specified for them.
* The applicable constructor must be *public*.
* There must only be one applicable constructor. In case of an ambiguity, DI throws an exception.

## Additional resources

* [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection)
