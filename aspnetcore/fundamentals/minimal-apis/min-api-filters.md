---
title: Filters in Minimal API apps
author: rick-anderson
description: Use filters in Minimal API apps
ms.author: riande
ms.date: 8/11/2022
monikerRange: '>= aspnetcore-7.0'
uid: fundamentals/minimal-apis/min-api-filters
---

# Filters in Minimal API apps

By [Fiyaz Bin Hasan](https://github.com/fiyazbinhasan), [Martin Costello](https://twitter.com/martin_costello), and [Rick Anderson](https://twitter.com/RickAndMSFT)

Minimal API filters allow developers to implement business logic that supports:

* Running code before and after the endpoint handler.
* Inspecting and modifying parameters provided during an endpoint handler invocation.
* Intercepting the response behavior of an endpoint handler.

Filters can be helpful in the following scenarios:

* Validating the request parameters and body that are sent to an endpoint.
* Logging information about the request and response.
* Validating that a request is targeting a supported API version.

Filters can be registered by providing a [Delegate](/dotnet/csharp/programming-guide/delegates/) that takes a [`EndpointFilterInvocationContext`](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Http.Abstractions/src/EndpointFilterInvocationContext.cs) and returns a [`EndpointFilterDelegate`](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Http.Abstractions/src/EndpointFilterDelegate.cs). The `EndpointFilterInvocationContext` provides access to the `HttpContext` of the request and an `Arguments` list indicating the arguments passed to the handler in the order in which they appear in the declaration of the handler.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet1)]

The preceding code:

* Calls the `AddEndpointFilter` extension method to add a filter to the `/colorSelector/{color}` endpoint.
* Returns the color specified except for the value `"Red"`.
* Returns [Results.Problem](xref:Microsoft.AspNetCore.Http.Results.Problem%2A) when the `/colorSelector/Red` is requested.
* Uses `next` as the `EndpointFilterDelegate` and `invocationContext` as the `EndpointFilterInvocationContext` to invoke the next filter in the pipeline or the request delegate if the last filter has been invoked.

The filter is run before the endpoint handler. When multiple `AddEndpointFilter` invocations are made on a handler:

* Filter code called before the `EndpointFilterDelegate` (`next`) is called are executed in order of First In, First Out (FIFO) order.
* Filter code called after the `EndpointFilterDelegate` (`next`) is called are executed in order of First In, Last Out (FILO) order.

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

The following code uses filters that implement the `IEndpointFilter` interface:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet_abc)]

In the preceding code, the filters and handlers logs show the order they are run:

```dotnetcli
AEndpointFilter Before next
BEndpointFilter Before next
CEndpointFilter Before next
      Endpoint
CEndpointFilter After next
BEndpointFilter After next
AEndpointFilter After next
```

Filters implementing the `IEndpointFilter` interface are shown in the following example:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/EndpointFilters/AbcEndpointFilters.cs)]

## Validate an object with a filter

Consider a filter that validates a `Todo` object:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/Program.cs?name=snippet_filter1)]

In the preceding code:

* The `EndpointFilterInvocationContext` object provides access to the parameters associated with a particular request issued to the endpoint via the `GetArguments` method.
* The filter is registered using a `delegate` that takes a `EndpointFilterInvocationContext` and returns a `EndpointFilterDelegate`.

In addition to being passed as delegates, filters can be registered by implementing the `IEndpointFilter` interface. The following code shows the preceding filter encapsulated in a class which implements `IEndpointFilter`:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/EndpointFilters/ToDoIsValidFilter.cs?name=snippet)]

Filters that implement the `IEndpointFilter` interface can resolve dependencies from [Dependency Injection(DI)](xref:fundamentals/dependency-injection), as shown in the previous code. Although filters can resolve dependencies from DI, filters themselves can ***not*** be resolved from DI.

The `ToDoIsValidFilter` is applied to the following endpoints:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/Program.cs?name=snippet_2flt&highlight=13,21)]

The following filter validates the `Todo` object and modifies the `Name` property:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/EndpointFilters/ToDoIsValidFilter.cs?name=snippet2&highlight=7)]

## Register a filter using an endpoint filter factory

In some scenarios, it might be necessary to cache some of the information provided in the [`MethodInfo`](/dotnet/api/system.reflection.methodinfo) in a filter. For example, let's assume that we wanted to verify that the handler an endpoint filter is attached to has a first parameter that evaluates to a `Todo` type.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/todo/Program.cs?name=snippet_filterfactory1)]

In the preceding code:

* The `EndpointFilterFactoryContext` object provides access to the [`MethodInfo`](/dotnet/api/system.reflection.methodinfo) associated with the endpoint's handler.
* The signature of the handler is examined by inspecting `MethodInfo` for the expected type signature. If the expected signature is found, the validation filter is registered onto the endpoint. This factory pattern is useful to register a filter that depends on the signature of the target endpoint handler.
* If a matching signature isn't found, then a pass-through filter is registered.

## Register a filter on controller actions

In some scenarios, it might be necessary to apply the same filter logic for both route-handler based endpoints and controller actions. For this scenario, it is possible to invoke `AddEndpointFilter` on `ControllerActionEndpointConventionBuilder` to support executing the same filter logic on actions and endpoints.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet_action_endpoint_filters)]

## Additional Resources

* [View or download sample code](https://github.com/aspnet/Docs/tree/main/aspnetcore/fundamentals/minimal-apis/min-api-filters/7samples) ([how to download](xref:index#how-to-download-a-sample))
* [ValidationFilterRouteHandlerBuilderExtensions](https://github.com/DamianEdwards/MinimalApis.Extensions/blob/main/src/MinimalApis.Extensions/Filters/ValidationFilterRouteHandlerBuilderExtensions.cs) Validation extension methods.
* <xref:tutorials/min-web-api>
* <xref:fundamentals/minimal-apis/security>
