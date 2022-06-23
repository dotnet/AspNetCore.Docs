---
title: Filters in Minimal API applications
author: rick-anderson
description: Use filters in Minimal API applications
ms.author: riande
ms.date: 6/22/2022
monikerRange: '>= aspnetcore-7.0'
uid: fundamentals/minimal-apis/min-api-filters
---
# Filters in Minimal API apps

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Minimal API filters allow developers to implement business logic that supports:

* Running code before and after the route handler.
* Inspecting and modifying parameters provided during a route handler invocation.
* Intercepting the response behavior of a route handler.

Filters can be helpful in the following scenarios:

* Validating the request parameters and body that are sent to an endpoint.
* Logging information about the request and response.
* Validating that a request is targeting a supported API version.

Filters can be registered by providing a [Delegate](/dotnet/csharp/programming-guide/delegates/) that takes a [`RouteHandlerInvocationContext`](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Http.Abstractions/src/RouteHandlerInvocationContext.cs) and returns a [`RouteHandlerFilterDelegate`](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Http.Abstractions/src/RouteHandlerFilterDelegate.cs). The `RouteHandlerInvocationContext` provides access to the `HttpContext` associated with the request and an `Arguments` list indicating the arguments passed to the handler in the order in which they appear in the declaration of the handler.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet1)]

The preceding code:

* Calls the `AddFilter` extension method to add a filter to the `/colorSelector/{color}` endpoint.
* Returns the color specified except for the `Red`.
* Returns [Results.Problem](xref:Microsoft.AspNetCore.Http.Results.Problem%2A) when the `/colorSelector/Red` is requested.
* Uses `next` as the `RouteHandlerFilterDelegate` and `rhiContext` as the `RouteHandlerInvocationContext`.

The filter is run before the endpoint handler. When multiple `AddFilter` invocations are made on a handler:

* The filters are executed in order of First In, First Out (FIFO) order.
* The first filter registered runs first, the last filter registered runs last.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet_xyz)]

In the preceding code, the filters log the following output:

```dotnetcli
info: Filters[0]
      First filter
info: Filters[0]
      2nd filter
info: Filters[0]
      3rd filter

```

The following code uses filters that implement the `IRouteHandlerFilter` interface:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet_abc)]

In the preceding code, the filters and handlers are executed in the following order:

* `ArouteFilter` -> `BrouteFilter` -> `CrouteFilter` -> route handler
* The `next` delegate (`RouteHandlerFilterDelegate`) for `FilterA` is `FilterB` and so on.

Filters implementing the `IRouteHandlerFilter` interface is explained later in this document. The `ArouteFilter`, `BrouteFilter`, and `CrouteFilter` filters:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/RouteFilters/AbcRouteFilters.cs)]

## Validate an object with a filter

Consider a filter that validates a `Todo` object:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/Program.cs?name=snippet_filter1)]

In the preceding code:

* The `RouteHandlerInvocationContext` object provides access to the [`MethodInfo`](/dotnet/api/system.reflection.methodinfo) associated with the endpoint's handler and the `EndpointMetadata` that has been applied on the endpoint.
* The filter is registered using a `delegate` that takes a `RouteHandlerInvocationContext` and returns a `RouteHandlerFilterDelegate`. This factory pattern is useful to register a filter that depends on the signature of the target route handler.

In addition to being passed as delegates, filters can be registered by implementing the `IRouteHandlerFilter` interface. The follow code shows the preceding filter encapsulated in a class which implements `IRouteHandlerFilter`:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/RouteFilters/ToDoIsValidFilter.cs?name=snippet)]

Filters that implement the `IRouteHandlerFilter` interface can resolve dependencies from [Dependency Injection(DI)](xref:fundamentals/dependency-injection), as shown in the previous code. Although filters can resolve dependencies from DI, filters themselves can ***not*** be resolved from DI.

The `ToDoIsValidFilter` is applied to the following endpoints:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/Program.cs?name=snippet_2flt&highlight=13,21)]

The following filter validates the `Todo` object and modifies the `Name` property:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/RouteFilters/ToDoIsValidFilter.cs?name=snippet2&highlight=7)]

## Additional Resources

* [View or download sample code](https://github.com/aspnet/Docs/tree/main/aspnetcore/fundamentals/minimal-apis/min-api-filters/7samples) ([how to download](xref:index#how-to-download-a-sample))
* [ValidationFilterRouteHandlerBuilderExtensions](https://github.com/DamianEdwards/MinimalApis.Extensions/blob/main/src/MinimalApis.Extensions/Filters/ValidationFilterRouteHandlerBuilderExtensions.cs) Validation extension methods.
* <xref:tutorials/min-web-api>
