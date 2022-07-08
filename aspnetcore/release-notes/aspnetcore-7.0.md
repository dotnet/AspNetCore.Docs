---
title: What's new in ASP.NET Core 7.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 7.0.
ms.author: riande
ms.custom: mvc
ms.date: 10/29/2021
uid: aspnetcore-7
---
# What's new in ASP.NET Core 7.0 preview

This article highlights the most significant changes in ASP.NET Core 7.0 with links to relevant documentation.

## API controllers

### Parameter binding with DI in API controllers

Parameter binding for API controller actions binds parameters through [dependency injection](xref:fundamentals/dependency-injection) when the type is configured as a service. This means it’s no longer required to explicitly apply the [`[FromServices]`](xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute) attribute to a parameter. In the following code, both actions return the time:

[!code-csharp[](~/release-notes/aspnetcore-7/samples/ApiController/Controllers/MyController.cs?name=snippet)]

In rare cases, automatic DI can break apps that have a type in DI that is also accepted in an API controllers action methods. It's not common to have a type in DI and as an argument in an API controller action. To disable automatic binding of parameters, set [DisableImplicitFromServicesParameters](/dotnet/api/microsoft.aspnetcore.mvc.apibehavioroptions.disableimplicitfromservicesparameters)

[!code-csharp[](~/release-notes/aspnetcore-7/samples/ApiController/Program.cs?name=snippet_dis&highlight=8-11)]

In ASP.NET Core 7.0, types in DI are checked at app startup with <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> to determine if an argument in an API controller action comes from DI or from the other sources.

The new mechanism to infer binding source of API Controller action parameters uses the following rules:

1. A previously specified [`BindingInfo.BindingSource`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BindingSource) is never overwritten.
1. A complex type parameter, registered in the DI container, is assigned [`BindingSource.Services`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Services).
1. A complex type parameter, not registered in the DI container, is assigned [`BindingSource.Body`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Body).
1. A parameter with a name that appears as a route value in ***any*** route template is assigned [`BindingSource.Path`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Path).
1. All other parameters are [`BindingSource.Query`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Query).

## Minimal APIs

### Filters in Minimal API apps

Minimal API filters allow developers to implement business logic that supports:

* Running code before and after the route handler.
* Inspecting and modifying parameters provided during a route handler invocation.
* Intercepting the response behavior of a route handler.

Filters can be helpful in the following scenarios:

* Validating the request parameters and body that are sent to an endpoint.
* Logging information about the request and response.
* Validating that a request is targeting a supported API version.

For more information, see <xref:fundamentals/minimal-apis/min-api-filters>

## Signal R

### Dependency injection for SignalR hub methods

SignalR hub methods now support injecting services through dependency injection (DI).

Hub constructors can accept services from DI as parameters, which can be stored in properties on the class for use in a hub method. For more information, see [Inject services into a hub](xref:signalr/hubs?view=aspnetcore-7.0&preserve-view=true#inject-services-into-a-hub)

## Performance

### Improved HTTP/2 performance when using many streams on a connection

The HTTP/2 frame writing improves performance when there are multiple streams trying to write data on a single HTTP/2 connection. TLS work is dispatched to the thread pool and more quickly releases a write lock that other streams can acquire to write data. The reduction in wait times can yield significant performance improvements in cases where there is contention for this write lock. A gRPC benchmark with 70 streams on a single connection, with TLS, showed a ~15% improvement in requests per second.

## Server

### New ServerReady event for measuring startup time

The [`ServerReady`](https://github.com/dotnet/aspnetcore/blob/v7.0.0-preview.5.22303.8/src/Hosting/Hosting/src/Internal/HostingEventSource.cs#L75-L79) event has been added to measure [startup time](https://github.com/dotnet/aspnetcore/blob/v7.0.0-preview.5.22303.8/src/Hosting/Hosting/src/GenericHost/GenericWebHostService.cs#L138) of ASP.NET Core apps.

## IIS

### Shadow copying in IIS

Shadow copying app assemblies to the [ASP.NET Core Module (ANCM)](xref:host-and-deploy/aspnet-core-module) for IIS can provide a better end user experience than stopping the app by deploying an [app offline file](xref:host-and-deploy/iis/app-offline).

For more information, see [Shadow copying in IIS](xref:host-and-deploy/iis/advanced?view=aspnetcore-7.0#shadow-copy)

<!--
## Miscellaneous

### Customize the cookie consent value

In previous versions, cookie consent validation performed an equality comparison against the constant cookie value `yes`. In .NET 7, the value can be customized.
-->

