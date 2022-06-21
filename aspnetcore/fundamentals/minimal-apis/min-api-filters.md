---
title: Filters in Minimal API applications
author: rick-anderson
description: Use filters in Minimal API applications
ms.author: riande
ms.date: 6/22/2022
uid: fundamentals/minimal-apis/min-api-filters
---
# Filters in Minimal API apps

:::moniker range=">= aspnetcore-7.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Minimal API filters allows developers to implement business logic that supports:

* Inspecting and modifying parameters provided during a route handler invocation.
* Intercepting the response behavior of a route handler.

Filters can be helpful in the following scenarios:

* Validating the request parameters and body that are sent to an endpoint.
* Logging information about the request and response.
* Validating that a request is targeting a supported API version

Filters can be registered by providing a [Delegte](/dotnet/csharp/programming-guide/delegates/) that takes a `routeHandlerInvocationContext` and a `RouteHandlerFilterDelegate`. The `RouteHandlerInvocationContext` provides access to the `HttpContext` associated with the request and a `Arguments` list indicating the arguments passed to the handler in the order in which they appear in the argument list of the handler.

[!code-csharp[](~/fundamentals/minimal-apis/min-api-filters/7samples/Filters/Program.cs?name=snippet1)]

In preceding code:

* The `AddFilter` extension method adds a filter to the `/colorSelector/{color}` endpoint.
* `next` is the `RouteHandlerFilterDelegate`.
* Returns the color specified except for the `Red`.
* Returns [Results.Problem](xref:Microsoft.AspNetCore.Http.Results.Problem(ProblemDetails)) when `Red` is specified.

When registered, the contents of the delegate are executed before the handler is invoked. When multiple `AddFilter` invocations are made on a handler, the filters are executed in order of First In, Last Out (FILO) order, so the first filter registered run lasts.

```csharp
app.MapGet("/todos/{id}", (int id) => ...)
  .AddFilter(FilterA)
  .AddFilter(FilterB)
  .AddFilter(FilterC);
```

In the preceding code, the filters and handlers are executed in the following order:

* FilterC -> FilterB -> FilterA -> handler
* The `next` for `FilterC` is `FilterB` and so on.


:::moniker-end