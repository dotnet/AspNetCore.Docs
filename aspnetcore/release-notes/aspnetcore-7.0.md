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

### Improved HTTP/2 performance

Previously, the HTTP/2 multiplexing implementation relied on a [lock](/dotnet/csharp/language-reference/statements/lock) controlling which request can write to the underlying TCP connection. A thread-safe queue replaces the write lock. Now, rather than fighting over which thread gets to use the write lock, requests now queue up and a dedicated consumer processes them. Previously wasted CPU resources are available to the rest of the app.

One place where these improvements can be noticed is in gRPC, a popular RPC framework that uses HTTP/2. Kestrel + gRPC benchmarks show a dramatic improvement:

![Entity diagram](https://user-images.githubusercontent.com/219224/177910504-e93579b4-02e4-4079-8a8c-d9d24857aabf.png)

## Server

### New ServerReady event for measuring startup time

The [`ServerReady`](https://github.com/dotnet/aspnetcore/blob/v7.0.0-preview.5.22303.8/src/Hosting/Hosting/src/Internal/HostingEventSource.cs#L75-L79) event has been added to measure [startup time](https://github.com/dotnet/aspnetcore/blob/v7.0.0-preview.5.22303.8/src/Hosting/Hosting/src/GenericHost/GenericWebHostService.cs#L138) of ASP.NET Core apps.

## IIS

### Shadow copying in IIS

Shadow copying app assemblies to the [ASP.NET Core Module (ANCM)](xref:host-and-deploy/aspnet-core-module) for IIS can provide a better end user experience than stopping the app by deploying an [app offline file](xref:host-and-deploy/iis/app-offline).

For more information, see [Shadow copying in IIS](xref:host-and-deploy/iis/advanced?view=aspnetcore-7.0#shadow-copy)

## Miscellaneous

### Developer exception page dark mode

Dark mode support has been added to the developer exception page, thanks to a contribution by [Patrick Westerhoff](https://twitter.com/poke). To test dark mode in a browser, from the developer tools page, set the mode to dark. For example, in Firefox:

![F12 tools FF dark mode](https://user-images.githubusercontent.com/3605364/178082215-7bd1dfbe-3f11-421c-9918-fa11d8b99736.png)

In Chrome:

![F12 tools Chrome dark mode](https://user-images.githubusercontent.com/3605364/178082535-7719b77f-563a-4d0d-b70a-267801bb6526.png)
