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

By [Martin Costello](https://twitter.com/martin_costello), [Fiyaz Bin Hasan](https://github.com/fiyazbinhasan), and [Rick Anderson](https://twitter.com/RickAndMSFT)

Minimal API filters allow developers to implement business logic that supports:

* Running code before and after the route handler.
* Inspecting and modifying parameters provided during a route handler invocation.
* Intercepting the response behavior of a route handler.

Filters can be helpful in the following scenarios:

* Validating the request parameters and body that are sent to an endpoint.
* Logging information about the request and response.
* Validating that a request is targeting a supported API version.

Filters can be registered by providing a [Delegate](/dotnet/csharp/programming-guide/delegates/) that takes a [`RouteHandlerInvocationContext`](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Http.Abstractions/src/RouteHandlerInvocationContext.cs) and returns a [`RouteHandlerFilterDelegate`](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Http.Abstractions/src/RouteHandlerFilterDelegate.cs). The `RouteHandlerInvocationContext` provides access to the `HttpContext` of the request and an `Arguments` list indicating the arguments passed to the handler in the order in which they appear in the declaration of the handler.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet1)]

The preceding code:

* Calls the `AddFilter` extension method to add a filter to the `/colorSelector/{color}` endpoint.
* Returns the color specified except for the value `"Red"`.
* Returns [Results.Problem](xref:Microsoft.AspNetCore.Http.Results.Problem%2A) when the `/colorSelector/Red` is requested.
* Uses `next` as the `RouteHandlerFilterDelegate` and `invocationContext` as the `RouteHandlerInvocationContext` to invoke the next filter in the pipeline or the request delegate if the last filter has been invoked.

The filter is run before the endpoint handler. When multiple `AddFilter` invocations are made on a handler:

* Filter code called before the `RouteHandlerFilterDelegate` (`next`) is called are executed in order of First In, First Out (FIFO) order.
* Filter code called after the `RouteHandlerFilterDelegate` (`next`) is called are executed in order of First In, Last Out (FILO) order.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet_xyz)]

In the preceding code, the filters and endpoint log the following output:

```dotnetcli
Before first filter
    Before 2nd filter
        Before 3rd filter
            Endpoint
        After 3rd filter
    After 2nd filter
After first filter
```

The following code uses filters that implement the `IRouteHandlerFilter` interface:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet_abc)]

In the preceding code, the filters and handlers logs show the order they are run:

```dotnetcli
ArouteFilter Before next
BrouteFilter Before next
CrouteFilter Before next
      Endpoint
CrouteFilter After next
BrouteFilter After next
ArouteFilter After next
```

Filters implementing the `IRouteHandlerFilter` interface are shown in the following example:

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
