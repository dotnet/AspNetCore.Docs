---
title: Filters in Minimal API apps
ai-usage: ai-assisted
description: Use filters in Minimal API apps, including validation of an object with a filter, and registering a filter.
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/21/2026

# customer intent: As an ASP.NET developer, I want to use filters in Minimal APIs, so I can validate and log request and response data for my apps.
---

# Filters in Minimal API apps

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Fiyaz Bin Hasan](https://github.com/fiyazbinhasan), [Martin Costello](https://twitter.com/martin_costello), and [Rick Anderson](https://twitter.com/RickAndMSFT)

Minimal API filters allow developers to implement business logic that supports the following tasks:

* Run code before and after the endpoint handler
* Inspect and modify parameters provided during an endpoint handler invocation
* Intercept the response behavior of an endpoint handler

Filters are helpful in many scenarios:

* Validate request parameters and body sent to an endpoint
* Log information about the request and response
* Validate a request targets a supported API version

This article describes how to use filters in your Minimal API apps, such as for validating request data sent to your app and logging the response.

## Work with filters

Filters are registered by providing a [Delegate](/dotnet/csharp/programming-guide/delegates/) that takes a [EndpointFilterInvocationContext](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Http.Abstractions/src/EndpointFilterInvocationContext.cs) and returns a [EndpointFilterDelegate](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Http.Abstractions/src/EndpointFilterDelegate.cs). The `EndpointFilterInvocationContext` provides access to the `HttpContext` of the request and an `Arguments` list. The list specifies the arguments passed to the handler in the order in which they appear in the declaration of the handler.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/Filters/Program.cs?name=snippet1)]

The preceding code:

* Calls the `AddEndpointFilter` extension method to add a filter to the `/colorSelector/{color}` endpoint.
* Returns the color specified, except for the value `"Red"`.
* Returns [Results.Problem](xref:Microsoft.AspNetCore.Http.Results.Problem*) when the `/colorSelector/Red` is requested.
* Uses `next` as the `EndpointFilterDelegate` and `invocationContext` as the `EndpointFilterInvocationContext` to invoke the next filter in the pipeline, or the request delegate if the last filter is already invoked.

The filter runs before the endpoint handler. When multiple `AddEndpointFilter` invocations are made on a handler:

* The execution order of filter code called _before_ the call to `EndpointFilterDelegate` (`next`) is First In, First Out (FIFO).
* The execution order of filter code called _after_ the call to `EndpointFilterDelegate` (`next`) is First In, Last Out (FILO).

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/Filters/Program.cs?name=snippet_xyz)]

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

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/Filters/Program.cs?name=snippet_abc)]

In the preceding code, the logs for the filters and handlers show the run order:

```dotnetcli
AEndpointFilter Before next
BEndpointFilter Before next
CEndpointFilter Before next
      Endpoint
CEndpointFilter After next
BEndpointFilter After next
AEndpointFilter After next
```

Filters that implement the `IEndpointFilter` interface are shown in the following example:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/Filters/EndpointFilters/AbcEndpointFilters.cs)]

## Validate an object with a filter

Consider a filter that validates a `Todo` object:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/todo/Program.cs?name=snippet_filter1)]

In the preceding code:

* The `EndpointFilterInvocationContext` object provides access to the parameters associated with a particular request issued to the endpoint via the `GetArguments` method.
* The filter is registered by using a `delegate` that takes a `EndpointFilterInvocationContext` and returns a `EndpointFilterDelegate`.

In addition to being passed as delegates, filters can be registered by implementing the `IEndpointFilter` interface. The following code shows the preceding filter encapsulated in a class that implements `IEndpointFilter`:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/todo/EndpointFilters/ToDoIsValidFilter.cs?name=snippet)]

Filters that implement the `IEndpointFilter` interface can resolve dependencies from [Dependency Injection (DI)](../dependency-injection.md), as shown in the previous code. Although filters can resolve dependencies from DI, filters themselves **can't** be resolved from DI.

The `ToDoIsValidFilter` is applied to the following endpoints:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/todo/Program.cs?name=snippet_2flt&highlight=13,21)]

The following filter validates the `Todo` object and modifies the `Name` property:

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/todo/EndpointFilters/ToDoIsValidFilter.cs?name=snippet2&highlight=7)]

## Register a filter by using an endpoint filter factory

In some scenarios, it might be necessary to cache some of the information provided in the [MethodInfo](/dotnet/api/system.reflection.methodinfo) in a filter. Suppose you want to verify that the handler attached to an endpoint filter has a first parameter that evaluates to a `Todo` type.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/todo/Program.cs?name=snippet_filterfactory1)]

In the preceding code:

* The `EndpointFilterFactoryContext` object provides access to the [MethodInfo](/dotnet/api/system.reflection.methodinfo) associated with the endpoint's handler.
* The signature of the handler is examined by inspecting `MethodInfo` for the expected type signature. If the expected signature is found, the validation filter is registered onto the endpoint. This factory pattern is useful to register a filter that depends on the signature of the target endpoint handler.
* If a matching signature isn't found, a pass-through filter is registered.

:::moniker range=">= aspnetcore-8.0"

## Filters and parameter binding failures

Endpoint filters can run when a parameter-check failure occurs, such as a failed route, query, or header parse, or a missing required parameter. When a filter pipeline is built for an endpoint, `ThrowOnBadRequest` is `false`, and a parameter check fails, the framework:

* Sets `HttpContext.Response.StatusCode` to `400`.
* Invokes the filter pipeline.
* Skips the route handler. The innermost step of the pipeline returns an empty result instead of calling the handler whenever the response status code is `400` or greater.

Endpoint filters don't run for body-reading failures (such as malformed JSON or unsupported media types) or when an exception is thrown during parameter binding (such as from a custom `BindAsync` method); in those cases, the framework returns or throws before invoking the filter pipeline.

A filter therefore sees the failed request and can replace the empty `400` with a response body of its own:

```csharp
app.MapGet("/products/{id}", (Guid id) => TypedResults.Ok(id))
    .AddEndpointFilter(async (context, next) =>
    {
        if (context.HttpContext.Response.StatusCode >= StatusCodes.Status400BadRequest)
        {
            return TypedResults.Problem(
                title: "The request couldn't be bound.",
                statusCode: context.HttpContext.Response.StatusCode);
        }

        return await next(context);
    });
```

Test the status code with `>=` rather than `== 400`. That's the same comparison the framework uses to decide whether to skip the handler, and a filter that runs earlier in the pipeline can set a different code.

Because parameter binding did not fully succeed, values in <xref:Microsoft.AspNetCore.Http.EndpointFilterInvocationContext.Arguments?displayProperty=nameWithType> might only be partially bound. A filter that inspects arguments should check the status code first before relying on argument values.

## Observe binding failures in the Development environment

<xref:Microsoft.AspNetCore.Routing.RouteHandlerOptions.ThrowOnBadRequest> controls whether the framework throws <xref:Microsoft.AspNetCore.Http.BadHttpRequestException> in addition to writing a `Debug`-level log entry when it handles an invalid request. It defaults to the value of <xref:Microsoft.Extensions.Hosting.HostEnvironmentEnvExtensions.IsDevelopment*>, so it's `true` in the `Development` environment and `false` in other environments.

In the `Development` environment with the default value of `true`, the exception reaches the developer exception page before a filter can respond. Set <xref:Microsoft.AspNetCore.Routing.RouteHandlerOptions.ThrowOnBadRequest> to `false` to receive the `400` response that the filter can observe:

```csharp
builder.Services.Configure<RouteHandlerOptions>(options =>
{
    options.ThrowOnBadRequest = false;
});
```

No change is needed in other environments, where `false` is already the default.

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

An endpoint whose filter factories all return `next` unchanged—so that no filter pipeline is actually built—no longer runs its route handler after a parameter-binding failure. In earlier releases, that configuration set the `400` status code and then invoked the handler anyway with unbound argument values. For more information, see [Refactor param binding failure handling in RequestDelegate (`dotnet/aspnetcore` #64539)](https://github.com/dotnet/aspnetcore/pull/64539). (Please don't comment on closed issues and PRs.)

:::moniker-end

## Register a filter on controller actions

In some scenarios, it might be necessary to apply the same filter logic for both route-handler based endpoints and controller actions. For this scenario, you can invoke `AddEndpointFilter` on `ControllerActionEndpointConventionBuilder` to support executing the same filter logic on actions and endpoints.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/samples/7/Filters/Program.cs?name=snippet_action_endpoint_filters)]

## Related content

* [View or download sample code](https://github.com/aspnet/Docs/tree/main/aspnetcore/fundamentals/minimal-apis/min-api-filters/samples/7) ([How to download](../index.md#how-to-download-a-sample))
* [ValidationFilterRouteHandlerBuilderExtensions (Validation extension methods)](https://github.com/DamianEdwards/MinimalApis.Extensions/blob/main/src/MinimalApis.Extensions/Filters/ValidationFilterRouteHandlerBuilderExtensions.cs)
* [Tutorial: Create a Minimal API with ASP.NET Core](xref:tutorials/min-web-api)
* [Authentication and authorization in Minimal APIs](security.md)