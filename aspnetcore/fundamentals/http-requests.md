---
title: Make HTTP requests using IHttpClientFactory in ASP.NET Core
author: stevejgordon
description: Learn about using the IHttpClientFactory interface to manage logical HttpClient instances in ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 11/09/2021
uid: fundamentals/http-requests
---
# Make HTTP requests using IHttpClientFactory in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

By [Kirk Larkin](https://github.com/serpent5), [Steve Gordon](https://github.com/stevejgordon), [Glenn Condron](https://github.com/glennc), and [Ryan Nowak](https://github.com/rynowak).

An <xref:System.Net.Http.IHttpClientFactory> can be registered and used to configure and create <xref:System.Net.Http.HttpClient> instances in an app. `IHttpClientFactory` offers the following benefits:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, a client named  *github* could be registered and configured to access [GitHub](https://github.com/). A default client can be registered for general access.
* Codifies the concept of outgoing middleware via delegating handlers in `HttpClient`. Provides extensions for Polly-based middleware to take advantage of delegating handlers in `HttpClient`.
* Manages the pooling and lifetime of underlying `HttpClientMessageHandler` instances. Automatic management avoids common DNS (Domain Name System) problems that occur when manually managing `HttpClient` lifetimes.
* Adds a configurable logging experience (via `ILogger`) for all requests sent through clients created by the factory.

The sample code in this topic version uses <xref:System.Text.Json> to deserialize JSON content returned in HTTP responses. For samples that use `Json.NET` and `ReadAsAsync<T>`, use the version selector to select a 2.x version of this topic.

## Consumption patterns

There are several ways `IHttpClientFactory` can be used in an app:

* [Basic usage](#basic-usage)
* [Named clients](#named-clients)
* [Typed clients](#typed-clients)
* [Generated clients](#generated-clients)

The best approach depends upon the app's requirements.

### Basic usage

Register `IHttpClientFactory` by calling `AddHttpClient` in `Program.cs`:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientBasic" highlight="4":::

An `IHttpClientFactory` can be requested using [dependency injection (DI)](xref:fundamentals/dependency-injection). The following code uses `IHttpClientFactory` to create an `HttpClient` instance:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Pages/Consumption/Basic.cshtml.cs" id="snippet_Class" highlight="5-6,23":::

Using `IHttpClientFactory` like in the preceding example is a good way to refactor an existing app. It has no impact on how `HttpClient` is used. In places where `HttpClient` instances are created in an existing app, replace those occurrences with calls to <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A>.

### Named clients

Named clients are a good choice when:

* The app requires many distinct uses of `HttpClient`.
* Many `HttpClient`s have different configuration.

Specify configuration for a named `HttpClient` during its registration in `Program.cs`:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientNamed":::

In the preceding code the client is configured with:

* The base address `https://api.github.com/`.
* Two headers required to work with the GitHub API.

#### CreateClient

Each time <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A> is called:

* A new instance of `HttpClient` is created.
* The configuration action is called.

To create a named client, pass its name into `CreateClient`:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Pages/Consumption/NamedClient.cshtml.cs" id="snippet_Class" highlight="12":::

In the preceding code, the request doesn't need to specify a hostname. The code can pass just the path, since the base address configured for the client is used.

### Typed clients

Typed clients:

* Provide the same capabilities as named clients without the need to use strings as keys.
* Provides IntelliSense and compiler help when consuming clients.
* Provide a single location to configure and interact with a particular `HttpClient`. For example, a single typed client might be used:
  * For a single backend endpoint.
  * To encapsulate all logic dealing with the endpoint.
* Work with DI and can be injected where required in the app.

A typed client accepts an `HttpClient` parameter in its constructor:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/GitHub/GitHubService.cs" id="snippet_Class" highlight="5":::

In the preceding code:

* The configuration is moved into the typed client.
* The provided `HttpClient` instance is stored as a private field.

API-specific methods can be created that expose `HttpClient` functionality. For example, the `GetAspNetCoreDocsBranches` method encapsulates code to retrieve docs GitHub branches.

The following code calls <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> in `Program.cs` to register the `GitHubService` typed client class:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientTyped":::

The typed client is registered as transient with DI. In the preceding code, `AddHttpClient` registers `GitHubService` as a transient service. This registration uses a factory method to:

1. Create an instance of `HttpClient`.
1. Create an instance of `GitHubService`, passing in the instance of `HttpClient` to its constructor.

The typed client can be injected and consumed directly:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Pages/Consumption/TypedClient.cshtml.cs" id="snippet_Class" highlight="5-6,14":::

The configuration for a typed client can also be specified during its registration in `Program.cs`, rather than in the typed client's constructor:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Snippets/Program.cs" id="snippet_AddHttpClientTypedInline":::

### Generated clients

`IHttpClientFactory` can be used in combination with third-party libraries such as [Refit](https://github.com/reactiveui/refit). Refit is a REST library for .NET. It converts REST APIs into live interfaces. Call `AddRefitClient` to generate a dynamic implementation of an interface, which uses `HttpClient` to make the external HTTP calls.

A custom interface represents the external API:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/GitHub/IGitHubClient.cs" id="snippet_Interface":::

Call `AddRefitClient` to generate the dynamic implementation and then call `ConfigureHttpClient` to configure the underlying `HttpClient`:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddRefitClient" highlight="1-2":::

Use DI to access the dynamic implementation of `IGitHubClient`:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Pages/Refit.cshtml.cs" id="snippet_Class" highlight="5-6,14":::

## Make POST, PUT, and DELETE requests

In the preceding examples, all HTTP requests use the GET HTTP verb. `HttpClient` also supports other HTTP verbs, including:

* POST
* PUT
* DELETE
* PATCH

For a complete list of supported HTTP verbs, see <xref:System.Net.Http.HttpMethod>.

The following example shows how to make an HTTP POST request:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Snippets/TodoClient.cs" id="snippet_POST":::

In the preceding code, the `CreateItemAsync` method:

* Serializes the `TodoItem` parameter to JSON using `System.Text.Json`.
* Creates an instance of <xref:System.Net.Http.StringContent> to package the serialized JSON for sending in the HTTP request's body.
* Calls <xref:System.Net.Http.HttpClient.PostAsync%2A> to send the JSON content to the specified URL. This is a relative URL that gets added to the [HttpClient.BaseAddress](xref:System.Net.Http.HttpClient.BaseAddress).
* Calls <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode%2A> to throw an exception if the response status code doesn't indicate success.

`HttpClient` also supports other types of content. For example, <xref:System.Net.Http.MultipartContent> and <xref:System.Net.Http.StreamContent>. For a complete list of supported content, see <xref:System.Net.Http.HttpContent>.

The following example shows an HTTP PUT request:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Snippets/TodoClient.cs" id="snippet_PUT":::

The preceding code is similar to the POST example. The `SaveItemAsync` method calls <xref:System.Net.Http.HttpClient.PutAsync%2A> instead of `PostAsync`.

The following example shows an HTTP DELETE request:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Snippets/TodoClient.cs" id="snippet_DELETE":::

In the preceding code, the `DeleteItemAsync` method calls <xref:System.Net.Http.HttpClient.DeleteAsync%2A>. Because HTTP DELETE requests typically contain no body, the `DeleteAsync` method doesn't provide an overload that accepts an instance of `HttpContent`.

To learn more about using different HTTP verbs with `HttpClient`, see <xref:System.Net.Http.HttpClient>.

## Outgoing request middleware

`HttpClient` has the concept of delegating handlers that can be linked together for outgoing HTTP requests. `IHttpClientFactory`:

* Simplifies defining the handlers to apply for each named client.
* Supports registration and chaining of multiple handlers to build an outgoing request middleware pipeline. Each of these handlers is able to perform work before and after the   outgoing request. This pattern:
  * Is similar to the inbound middleware pipeline in ASP.NET Core.
  * Provides a mechanism to manage cross-cutting concerns around HTTP requests, such as:
    * caching
    * error handling
    * serialization
    * logging

To create a delegating handler:

* Derive from <xref:System.Net.Http.DelegatingHandler>.
* Override <xref:System.Net.Http.DelegatingHandler.SendAsync%2A>. Execute code before passing the request to the next handler in the pipeline:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Handlers/ValidateHeaderHandler.cs" id="snippet_Class":::

The preceding code checks if the `X-API-KEY` header is in the request. If `X-API-KEY` is missing, <xref:System.Net.HttpStatusCode.BadRequest> is returned.

More than one handler can be added to the configuration for an `HttpClient` with <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A?displayProperty=fullName>:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpMessageHandler":::

In the preceding code, the `ValidateHeaderHandler` is registered with DI. Once registered, <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> can be called, passing in the type for the handler.

Multiple handlers can be registered in the order that they should execute. Each handler wraps the next handler until the final `HttpClientHandler` executes the request:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpMessageHandlerMultiple":::

In the preceding code, `SampleHandler1` runs first, before `SampleHandler2`.

### Use DI in outgoing request middleware

When `IHttpClientFactory` creates a new delegating handler, it uses DI to fulfill the handler's constructor parameters. `IHttpClientFactory` creates a **separate** DI scope for each handler, which can lead to surprising behavior when a handler consumes a *scoped* service.

For example, consider the following interface and its implementation, which represents a task as an operation with an identifier, `OperationId`:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Models/OperationScoped.cs" id="snippet_Types":::

As its name suggests, `IOperationScoped` is registered with DI using a *scoped* lifetime:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_OperationScoped":::

The following delegating handler consumes and uses `IOperationScoped` to set the `X-OPERATION-ID` header for the outgoing request:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Handlers/OperationHandler.cs" id="snippet_Class" highlight="5-6,11":::

In the [`HttpRequestsSample` download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/http-requests/samples/6.x/HttpRequestsSample), navigate to `/Operation` and refresh the page. The request scope value changes for each request, but the handler scope value only changes every 5 seconds.

Handlers can depend upon services of any scope. Services that handlers depend upon are disposed when the handler is disposed.

Use one of the following approaches to share per-request state with message handlers:

* Pass data into the handler using <xref:System.Net.Http.HttpRequestMessage.Options%2A?displayProperty=nameWithType>.
* Use <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> to access the current request.
* Create a custom <xref:System.Threading.AsyncLocal%601> storage object to pass the data.

## Use Polly-based handlers

`IHttpClientFactory` integrates with the third-party library [Polly](https://github.com/App-vNext/Polly). Polly is a comprehensive resilience and transient fault-handling library for .NET. It allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.

Extension methods are provided to enable the use of Polly policies with configured `HttpClient` instances. The Polly extensions support adding Polly-based handlers to clients. Polly requires the [Microsoft.Extensions.Http.Polly](https://www.nuget.org/packages/Microsoft.Extensions.Http.Polly/) NuGet package.

### Handle transient faults

Faults typically occur when external HTTP calls are transient. <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddTransientHttpErrorPolicy%2A> allows a policy to be defined to handle transient errors. Policies configured with `AddTransientHttpErrorPolicy` handle the following responses:

* <xref:System.Net.Http.HttpRequestException>
* HTTP 5xx
* HTTP 408

`AddTransientHttpErrorPolicy` provides access to a `PolicyBuilder` object configured to handle errors representing a possible transient fault:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientPollyWaitAndRetry":::

In the preceding code, a `WaitAndRetryAsync` policy is defined. Failed requests are retried up to three times with a delay of 600 ms between attempts.

### Dynamically select policies

Extension methods are provided to add Polly-based handlers, for example, <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddPolicyHandler%2A>. The following `AddPolicyHandler` overload inspects the request to decide which policy to apply:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientPollyDynamic":::

In the preceding code, if the outgoing request is an HTTP GET, a 10-second timeout is applied. For any other HTTP method, a 30-second timeout is used.

### Add multiple Polly handlers

It's common to nest Polly policies:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientPollyMultiple":::

In the preceding example:

* Two handlers are added.
* The first handler uses <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddTransientHttpErrorPolicy%2A> to add a retry policy. Failed requests are retried up to three times.
* The second `AddTransientHttpErrorPolicy` call adds a circuit breaker policy. Further external requests are blocked for 30 seconds if 5 failed attempts occur sequentially. Circuit breaker policies are stateful. All calls through this client share the same circuit state.

### Add policies from the Polly registry

An approach to managing regularly used policies is to define them once and register them with a `PolicyRegistry`. For example:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Snippets/Program.cs" id="snippet_AddHttpClientPollyRegistry":::

In the preceding code:

* Two policies, `Regular` and `Long`, are added to the Polly registry.
* <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddPolicyHandlerFromRegistry%2A> configures individual named clients to use these policies from the Polly registry.

For more information on `IHttpClientFactory` and Polly integrations, see the [Polly wiki](https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory).

## HttpClient and lifetime management

A new `HttpClient` instance is returned each time `CreateClient` is called on the `IHttpClientFactory`. An <xref:System.Net.Http.HttpMessageHandler> is created per named client. The factory manages the lifetimes of the `HttpMessageHandler` instances.

`IHttpClientFactory` pools the `HttpMessageHandler` instances created by the factory to reduce resource consumption. An `HttpMessageHandler` instance may be reused from the pool when creating a new `HttpClient` instance if its lifetime hasn't expired.

Pooling of handlers is desirable as each handler typically manages its own underlying HTTP connections. Creating more handlers than necessary can result in connection delays. Some handlers also keep connections open indefinitely, which can prevent the handler from reacting to DNS (Domain Name System) changes.

The default handler lifetime is two minutes. The default value can be overridden on a per named client basis:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientHandlerLifetime":::

`HttpClient` instances can generally be treated as .NET objects **not** requiring disposal. Disposal cancels outgoing requests and guarantees the given `HttpClient` instance can't be used after calling <xref:System.IDisposable.Dispose%2A>. `IHttpClientFactory` tracks and disposes resources used by `HttpClient` instances.

Keeping a single `HttpClient` instance alive for a long duration is a common pattern used before the inception of `IHttpClientFactory`. This pattern becomes unnecessary after migrating to `IHttpClientFactory`.

### Alternatives to IHttpClientFactory

Using `IHttpClientFactory` in a DI-enabled app avoids:

* Resource exhaustion problems by pooling `HttpMessageHandler` instances.
* Stale DNS problems by cycling `HttpMessageHandler` instances at regular intervals.

There are alternative ways to solve the preceding problems using a long-lived <xref:System.Net.Http.SocketsHttpHandler> instance.

* Create an instance of `SocketsHttpHandler` when the app starts and use it for the life of the app.
* Configure <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> to an appropriate value based on DNS refresh times.
* Create `HttpClient` instances using `new HttpClient(handler, disposeHandler: false)` as needed.

The preceding approaches solve the resource management problems that `IHttpClientFactory` solves in a similar way.

* The `SocketsHttpHandler` shares connections across `HttpClient` instances. This sharing prevents socket exhaustion.
* The `SocketsHttpHandler` cycles connections according to `PooledConnectionLifetime` to avoid stale DNS problems.

## Logging

Clients created via `IHttpClientFactory` record log messages for all requests. Enable the appropriate information level in the logging configuration to see the default log messages. Additional logging, such as the logging of request headers, is only included at trace level.

The log category used for each client includes the name of the client. A client named *MyNamedClient*, for example, logs messages with a category of "System.Net.Http.HttpClient.**MyNamedClient**.LogicalHandler". Messages suffixed with *LogicalHandler* occur outside the request handler pipeline. On the request, messages are logged before any other handlers in the pipeline have processed it. On the response, messages are logged after any other pipeline handlers have received the response.

Logging also occurs inside the request handler pipeline. In the *MyNamedClient* example, those messages are logged with the log category "System.Net.Http.HttpClient.**MyNamedClient**.ClientHandler". For the request, this occurs after all other handlers have run and immediately before the request is sent. On the response, this logging includes the state of the response before it passes back through the handler pipeline.

Enabling logging outside and inside the pipeline enables inspection of the changes made by the other pipeline handlers. This may include changes to request headers or to the response status code.

Including the name of the client in the log category enables log filtering for specific named clients.

## Configure the HttpMessageHandler

It may be necessary to control the configuration of the inner `HttpMessageHandler` used by a client.

An `IHttpClientBuilder` is returned when adding named or typed clients. The <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method can be used to define a delegate. The delegate is used to create and configure the primary `HttpMessageHandler` used by that client:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientConfigureHttpMessageHandler":::

## Cookies

The pooled `HttpMessageHandler` instances results in `CookieContainer` objects being shared. Unanticipated `CookieContainer` object sharing often results in incorrect code. For apps that require cookies, consider either:

* Disabling automatic cookie handling
* Avoiding `IHttpClientFactory`

Call <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> to disable automatic cookie handling:

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Program.cs" id="snippet_AddHttpClientNoAutomaticCookies":::

## Use IHttpClientFactory in a console app

In a console app, add the following package references to the project:

* [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting)
* [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)

In the following example:

* <xref:System.Net.Http.IHttpClientFactory> and `GitHubService` are registered in the [Generic Host's](xref:fundamentals/host/generic-host) service container.
* `GitHubService` is requested from DI, which in-turn requests an instance of `IHttpClientFactory`.
* `GitHubService` uses `IHttpClientFactory` to create an instance of `HttpClient`, which it uses to retrieve docs GitHub branches.

:::code language="csharp" source="http-requests/samples/6.x/HttpRequestsConsoleSample/Program.cs" highlight="10-11,17-18,40-41,56":::

## Header propagation middleware

Header propagation is an ASP.NET Core middleware to propagate HTTP headers from the incoming request to the outgoing `HttpClient` requests. To use header propagation:

* Install the [Microsoft.AspNetCore.HeaderPropagation](https://www.nuget.org/packages/Microsoft.AspNetCore.HeaderPropagation) package.
* Configure the `HttpClient` and middleware pipeline in `Program.cs`:

  :::code language="csharp" source="http-requests/samples/6.x/HttpRequestsSample/Snippets/Program.cs" id="snippet_AddHttpClientHeaderPropagation" highlight="4-10,17":::

* Make outbound requests using the configured `HttpClient` instance, which includes the added headers.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/http-requests/samples) ([how to download](xref:index#how-to-download-a-sample))
* [Use HttpClientFactory to implement resilient HTTP requests](/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)
* [Implement HTTP call retries with exponential backoff with HttpClientFactory and Polly policies](/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly)
* [Implement the Circuit Breaker pattern](/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-circuit-breaker-pattern)
* [How to serialize and deserialize JSON in .NET](/dotnet/standard/serialization/system-text-json-how-to)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

By [Kirk Larkin](https://github.com/serpent5), [Steve Gordon](https://github.com/stevejgordon), [Glenn Condron](https://github.com/glennc), and [Ryan Nowak](https://github.com/rynowak).

An <xref:System.Net.Http.IHttpClientFactory> can be registered and used to configure and create <xref:System.Net.Http.HttpClient> instances in an app. `IHttpClientFactory` offers the following benefits:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, a client named  *github* could be registered and configured to access [GitHub](https://github.com/). A default client can be registered for general access.
* Codifies the concept of outgoing middleware via delegating handlers in `HttpClient`. Provides extensions for Polly-based middleware to take advantage of delegating handlers in `HttpClient`.
* Manages the pooling and lifetime of underlying `HttpClientMessageHandler` instances. Automatic management avoids common DNS (Domain Name System) problems that occur when manually managing `HttpClient` lifetimes.
* Adds a configurable logging experience (via `ILogger`) for all requests sent through clients created by the factory.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/http-requests/samples) ([how to download](xref:index#how-to-download-a-sample)).

The sample code in this topic version uses <xref:System.Text.Json> to deserialize JSON content returned in HTTP responses. For samples that use `Json.NET` and `ReadAsAsync<T>`, use the version selector to select a 2.x version of this topic.

## Consumption patterns

There are several ways `IHttpClientFactory` can be used in an app:

* [Basic usage](#basic-usage)
* [Named clients](#named-clients)
* [Typed clients](#typed-clients)
* [Generated clients](#generated-clients)

The best approach depends upon the app's requirements.

### Basic usage

`IHttpClientFactory` can be registered by calling `AddHttpClient`:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet1" highlight="13":::

An `IHttpClientFactory` can be requested using [dependency injection (DI)](xref:fundamentals/dependency-injection). The following code uses `IHttpClientFactory` to create an `HttpClient` instance:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Pages/BasicUsage.cshtml.cs" id="snippet1" highlight="9-12,21":::

Using `IHttpClientFactory` like in the preceding example is a good way to refactor an existing app. It has no impact on how `HttpClient` is used. In places where `HttpClient` instances are created in an existing app, replace those occurrences with calls to <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A>.

### Named clients

Named clients are a good choice when:

* The app requires many distinct uses of `HttpClient`.
* Many `HttpClient`s have different configuration.

Configuration for a named `HttpClient` can be specified during registration in `Startup.ConfigureServices`:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet2":::

In the preceding code the client is configured with:

* The base address `https://api.github.com/`.
* Two headers required to work with the GitHub API.

#### CreateClient

Each time <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A> is called:

* A new instance of `HttpClient` is created.
* The configuration action is called.

To create a named client, pass its name into `CreateClient`:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Pages/NamedClient.cshtml.cs" id="snippet1" highlight="21":::

In the preceding code, the request doesn't need to specify a hostname. The code can pass just the path, since the base address configured for the client is used.

### Typed clients

Typed clients:

* Provide the same capabilities as named clients without the need to use strings as keys.
* Provides IntelliSense and compiler help when consuming clients.
* Provide a single location to configure and interact with a particular `HttpClient`. For example, a single typed client might be used:
  * For a single backend endpoint.
  * To encapsulate all logic dealing with the endpoint.
* Work with DI and can be injected where required in the app.

A typed client accepts an `HttpClient` parameter in its constructor:

:::code language="csharp" source="http-requests/samples/5.x/HttpClientFactorySample/GitHub/GitHubService.cs" id="snippet1" highlight="5":::

In the preceding code:

* The configuration is moved into the typed client.
* The `HttpClient` object is exposed as a public property.

<!-- 
The preceding code can be written as: 
:::code language="csharp" source="http-requests/samples/5.x/HttpClientFactorySample/GitHub/GitHubService.cs" id="snippet2":::
-->
API-specific methods can be created that expose `HttpClient` functionality. For example, the `GetAspNetDocsIssues` method encapsulates code to retrieve open issues.

The following code calls <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> in `Startup.ConfigureServices` to register a typed client class:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet3":::

The typed client is registered as transient with DI. In the preceding code, `AddHttpClient` registers `GitHubService` as a transient service. This registration uses a factory method to:

1. Create an instance of `HttpClient`.
1. Create an instance of `GitHubService`, passing in the instance of `HttpClient` to its constructor.

The typed client can be injected and consumed directly:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Pages/TypedClient.cshtml.cs" id="snippet1" highlight="11-14,20":::

The configuration for a typed client can be specified during registration in `Startup.ConfigureServices`, rather than in the typed client's constructor:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet4":::

The `HttpClient` can be encapsulated within a typed client. Rather than exposing it as a property, define a method which calls the `HttpClient` instance internally:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/GitHub/RepoService.cs" id="snippet1" highlight="4":::

In the preceding code, the `HttpClient` is stored in a private field. Access to the `HttpClient` is by the public `GetRepos` method.

### Generated clients

`IHttpClientFactory` can be used in combination with third-party libraries such as [Refit](https://github.com/paulcbetts/refit). Refit is a REST library for .NET. It converts REST APIs into live interfaces. An implementation of the interface is generated dynamically by the `RestService`, using `HttpClient` to make the external HTTP calls.

An interface and a reply are defined to represent the external API and its response:

```csharp
public interface IHelloClient
{
    [Get("/helloworld")]
    Task<Reply> GetMessageAsync();
}

public class Reply
{
    public string Message { get; set; }
}
```

A typed client can be added, using Refit to generate the implementation:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient("hello", c =>
    {
        c.BaseAddress = new Uri("http://localhost:5000");
    })
    .AddTypedClient(c => Refit.RestService.For<IHelloClient>(c));

    services.AddControllers();
}
```

The defined interface can be consumed where necessary, with the implementation provided by DI and Refit:

```csharp
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IHelloClient _client;

    public ValuesController(IHelloClient client)
    {
        _client = client;
    }

    [HttpGet("/")]
    public async Task<ActionResult<Reply>> Index()
    {
        return await _client.GetMessageAsync();
    }
}
```

## Make POST, PUT, and DELETE requests

In the preceding examples, all HTTP requests use the GET HTTP verb. `HttpClient` also supports other HTTP verbs, including:

* POST
* PUT
* DELETE
* PATCH

For a complete list of supported HTTP verbs, see <xref:System.Net.Http.HttpMethod>.

The following example shows how to make an HTTP POST request:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Models/TodoClient.cs" id="snippet_POST":::

In the preceding code, the `CreateItemAsync` method:

* Serializes the `TodoItem` parameter to JSON using `System.Text.Json`. This uses an instance of <xref:System.Text.Json.JsonSerializerOptions> to configure the serialization process.
* Creates an instance of <xref:System.Net.Http.StringContent> to package the serialized JSON for sending in the HTTP request's body.
* Calls <xref:System.Net.Http.HttpClient.PostAsync%2A> to send the JSON content to the specified URL. This is a relative URL that gets added to the [HttpClient.BaseAddress](xref:System.Net.Http.HttpClient.BaseAddress).
* Calls <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode%2A> to throw an exception if the response status code does not indicate success.

`HttpClient` also supports other types of content. For example, <xref:System.Net.Http.MultipartContent> and <xref:System.Net.Http.StreamContent>. For a complete list of supported content, see <xref:System.Net.Http.HttpContent>.

The following example shows an HTTP PUT request:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Models/TodoClient.cs" id="snippet_PUT":::

The preceding code is very similar to the POST example. The `SaveItemAsync` method calls <xref:System.Net.Http.HttpClient.PutAsync%2A> instead of `PostAsync`.

The following example shows an HTTP DELETE request:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Models/TodoClient.cs" id="snippet_DELETE":::

In the preceding code, the `DeleteItemAsync` method calls <xref:System.Net.Http.HttpClient.DeleteAsync%2A>. Because HTTP DELETE requests typically contain no body, the `DeleteAsync` method doesn't provide an overload that accepts an instance of `HttpContent`.

To learn more about using different HTTP verbs with `HttpClient`, see <xref:System.Net.Http.HttpClient>.

## Outgoing request middleware

`HttpClient` has the concept of delegating handlers that can be linked together for outgoing HTTP requests. `IHttpClientFactory`:

* Simplifies defining the handlers to apply for each named client.
* Supports registration and chaining of multiple handlers to build an outgoing request middleware pipeline. Each of these handlers is able to perform work before and after the   outgoing request. This pattern:
  * Is similar to the inbound middleware pipeline in ASP.NET Core.
  * Provides a mechanism to manage cross-cutting concerns around HTTP requests, such as:
    * caching
    * error handling
    * serialization
    * logging

To create a delegating handler:

* Derive from <xref:System.Net.Http.DelegatingHandler>.
* Override <xref:System.Net.Http.DelegatingHandler.SendAsync%2A>. Execute code before passing the request to the next handler in the pipeline:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Handlers/ValidateHeaderHandler.cs" id="snippet1":::

The preceding code checks if the `X-API-KEY` header is in the request. If `X-API-KEY` is missing, <xref:System.Net.HttpStatusCode.BadRequest> is returned.

More than one handler can be added to the configuration for an `HttpClient` with <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A?displayProperty=fullName>:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup2.cs" id="snippet1":::

In the preceding code, the `ValidateHeaderHandler` is registered with DI. Once registered, <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> can be called, passing in the type for the handler.

Multiple handlers can be registered in the order that they should execute. Each handler wraps the next handler until the final `HttpClientHandler` executes the request:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet6":::

### Use DI in outgoing request middleware

When `IHttpClientFactory` creates a new delegating handler, it uses DI to fulfill the handler's constructor parameters. `IHttpClientFactory` creates a **separate** DI scope for each handler, which can lead to surprising behavior when a handler consumes a *scoped* service.

For example, consider the following interface and its implementation, which represents a task as an operation with an identifier, `OperationId`:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Models/OperationScoped.cs" id="snippet_Types":::

As its name suggests, `IOperationScoped` is registered with DI using a *scoped* lifetime:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Startup.cs" id="snippet_IOperationScoped" highlight="18,26":::

The following delegating handler consumes and uses `IOperationScoped` to set the `X-OPERATION-ID` header for the outgoing request:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Handlers/OperationHandler.cs" id="snippet_Class" highlight="13":::

In the [`HttpRequestsSample` download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/http-requests/samples/3.x/HttpRequestsSample)], navigate to `/Operation` and refresh the page. The request scope value changes for each request, but the handler scope value only changes every 5 seconds.

Handlers can depend upon services of any scope. Services that handlers depend upon are disposed when the handler is disposed.

Use one of the following approaches to share per-request state with message handlers:

* Pass data into the handler using <xref:System.Net.Http.HttpRequestMessage.Options%2A?displayProperty=nameWithType>.
* Use <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> to access the current request.
* Create a custom <xref:System.Threading.AsyncLocal%601> storage object to pass the data.

## Use Polly-based handlers

`IHttpClientFactory` integrates with the third-party library [Polly](https://github.com/App-vNext/Polly). Polly is a comprehensive resilience and transient fault-handling library for .NET. It allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.

Extension methods are provided to enable the use of Polly policies with configured `HttpClient` instances. The Polly extensions support adding Polly-based handlers to clients. Polly requires the [Microsoft.Extensions.Http.Polly](https://www.nuget.org/packages/Microsoft.Extensions.Http.Polly/) NuGet package.

### Handle transient faults

Faults typically occur when external HTTP calls are transient. <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddTransientHttpErrorPolicy%2A> allows a policy to be defined to handle transient errors. Policies configured with `AddTransientHttpErrorPolicy` handle the following responses:

* <xref:System.Net.Http.HttpRequestException>
* HTTP 5xx
* HTTP 408

`AddTransientHttpErrorPolicy` provides access to a `PolicyBuilder` object configured to handle errors representing a possible transient fault:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup3.cs" id="snippet1":::

In the preceding code, a `WaitAndRetryAsync` policy is defined. Failed requests are retried up to three times with a delay of 600 ms between attempts.

### Dynamically select policies

Extension methods are provided to add Polly-based handlers, for example, <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddPolicyHandler%2A>. The following `AddPolicyHandler` overload inspects the request to decide which policy to apply:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet8":::

In the preceding code, if the outgoing request is an HTTP GET, a 10-second timeout is applied. For any other HTTP method, a 30-second timeout is used.

### Add multiple Polly handlers

It's common to nest Polly policies:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet9":::

In the preceding example:

* Two handlers are added.
* The first handler uses <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddTransientHttpErrorPolicy%2A> to add a retry policy. Failed requests are retried up to three times.
* The second `AddTransientHttpErrorPolicy` call adds a circuit breaker policy. Further external requests are blocked for 30 seconds if 5 failed attempts occur sequentially. Circuit breaker policies are stateful. All calls through this client share the same circuit state.

### Add policies from the Polly registry

An approach to managing regularly used policies is to define them once and register them with a `PolicyRegistry`.

In the following code:

* The "regular" and "long" policies are added.
* <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddPolicyHandlerFromRegistry%2A> adds the "regular" and "long" policies from the registry.

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup4.cs" id="snippet1":::

For more information on `IHttpClientFactory` and Polly integrations, see the [Polly wiki](https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory).

## HttpClient and lifetime management

A new `HttpClient` instance is returned each time `CreateClient` is called on the `IHttpClientFactory`. An <xref:System.Net.Http.HttpMessageHandler> is created per named client. The factory manages the lifetimes of the `HttpMessageHandler` instances.

`IHttpClientFactory` pools the `HttpMessageHandler` instances created by the factory to reduce resource consumption. An `HttpMessageHandler` instance may be reused from the pool when creating a new `HttpClient` instance if its lifetime hasn't expired.

Pooling of handlers is desirable as each handler typically manages its own underlying HTTP connections. Creating more handlers than necessary can result in connection delays. Some handlers also keep connections open indefinitely, which can prevent the handler from reacting to DNS (Domain Name System) changes.

The default handler lifetime is two minutes. The default value can be overridden on a per named client basis:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup5.cs" id="snippet1":::

`HttpClient` instances can generally be treated as .NET objects **not** requiring disposal. Disposal cancels outgoing requests and guarantees the given `HttpClient` instance can't be used after calling <xref:System.IDisposable.Dispose%2A>. `IHttpClientFactory` tracks and disposes resources used by `HttpClient` instances.

Keeping a single `HttpClient` instance alive for a long duration is a common pattern used before the inception of `IHttpClientFactory`. This pattern becomes unnecessary after migrating to `IHttpClientFactory`.

### Alternatives to IHttpClientFactory

Using `IHttpClientFactory` in a DI-enabled app avoids:

* Resource exhaustion problems by pooling `HttpMessageHandler` instances.
* Stale DNS problems by cycling `HttpMessageHandler` instances at regular intervals.

There are alternative ways to solve the preceding problems using a long-lived <xref:System.Net.Http.SocketsHttpHandler> instance.

* Create an instance of `SocketsHttpHandler` when the app starts and use it for the life of the app.
* Configure <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> to an appropriate value based on DNS refresh times.
* Create `HttpClient` instances using `new HttpClient(handler, disposeHandler: false)` as needed.

The preceding approaches solve the resource management problems that `IHttpClientFactory` solves in a similar way.

* The `SocketsHttpHandler` shares connections across `HttpClient` instances. This sharing prevents socket exhaustion.
* The `SocketsHttpHandler` cycles connections according to `PooledConnectionLifetime` to avoid stale DNS problems.

### Cookies

The pooled `HttpMessageHandler` instances results in `CookieContainer` objects being shared. Unanticipated `CookieContainer` object sharing often results in incorrect code. For apps that require cookies, consider either:

* Disabling automatic cookie handling
* Avoiding `IHttpClientFactory`

Call <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> to disable automatic cookie handling:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet13":::

## Logging

Clients created via `IHttpClientFactory` record log messages for all requests. Enable the appropriate information level in the logging configuration to see the default log messages. Additional logging, such as the logging of request headers, is only included at trace level.

The log category used for each client includes the name of the client. A client named *MyNamedClient*, for example, logs messages with a category of "System.Net.Http.HttpClient.**MyNamedClient**.LogicalHandler". Messages suffixed with *LogicalHandler* occur outside the request handler pipeline. On the request, messages are logged before any other handlers in the pipeline have processed it. On the response, messages are logged after any other pipeline handlers have received the response.

Logging also occurs inside the request handler pipeline. In the *MyNamedClient* example, those messages are logged with the log category "System.Net.Http.HttpClient.**MyNamedClient**.ClientHandler". For the request, this occurs after all other handlers have run and immediately before the request is sent. On the response, this logging includes the state of the response before it passes back through the handler pipeline.

Enabling logging outside and inside the pipeline enables inspection of the changes made by the other pipeline handlers. This may include changes to request headers or to the response status code.

Including the name of the client in the log category enables log filtering for specific named clients.

## Configure the HttpMessageHandler

It may be necessary to control the configuration of the inner `HttpMessageHandler` used by a client.

An `IHttpClientBuilder` is returned when adding named or typed clients. The <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method can be used to define a delegate. The delegate is used to create and configure the primary `HttpMessageHandler` used by that client:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup6.cs" id="snippet1":::

## Use IHttpClientFactory in a console app

In a console app, add the following package references to the project:

* [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting)
* [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)

In the following example:

* <xref:System.Net.Http.IHttpClientFactory> is registered in the [Generic Host's](xref:fundamentals/host/generic-host) service container.
* `MyService` creates a client factory instance from the service, which is used to create an `HttpClient`. `HttpClient` is used to retrieve a webpage.
* `Main` creates a scope to execute the service's `GetPage` method and write the first 500 characters of the webpage content to the console.

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactoryConsoleSample/Program.cs" highlight="14-15,20,26-27,59-62":::

## Header propagation middleware

Header propagation is an ASP.NET Core middleware to propagate HTTP headers from the incoming request to the outgoing HTTP Client requests. To use header propagation:

* Reference the [Microsoft.AspNetCore.HeaderPropagation](https://www.nuget.org/packages/Microsoft.AspNetCore.HeaderPropagation) package.
* Configure the middleware and `HttpClient` in `Startup`:

  :::code language="csharp" source="http-requests/samples/3.x/Startup.cs" id="snippet" highlight="5-9,21":::

* The client includes the configured headers on outbound requests:

  ```csharp
  var client = clientFactory.CreateClient("MyForwardingClient");
  var response = client.GetAsync(...);
  ```

## Additional resources

* [Use HttpClientFactory to implement resilient HTTP requests](/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)
* [Implement HTTP call retries with exponential backoff with HttpClientFactory and Polly policies](/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly)
* [Implement the Circuit Breaker pattern](/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-circuit-breaker-pattern)
* [How to serialize and deserialize JSON in .NET](/dotnet/standard/serialization/system-text-json-how-to)

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-5.0"

By [Kirk Larkin](https://github.com/serpent5), [Steve Gordon](https://github.com/stevejgordon), [Glenn Condron](https://github.com/glennc), and [Ryan Nowak](https://github.com/rynowak).

An <xref:System.Net.Http.IHttpClientFactory> can be registered and used to configure and create <xref:System.Net.Http.HttpClient> instances in an app. `IHttpClientFactory` offers the following benefits:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, a client named  *github* could be registered and configured to access [GitHub](https://github.com/). A default client can be registered for general access.
* Codifies the concept of outgoing middleware via delegating handlers in `HttpClient`. Provides extensions for Polly-based middleware to take advantage of delegating handlers in `HttpClient`.
* Manages the pooling and lifetime of underlying `HttpClientMessageHandler` instances. Automatic management avoids common DNS (Domain Name System) problems that occur when manually managing `HttpClient` lifetimes.
* Adds a configurable logging experience (via `ILogger`) for all requests sent through clients created by the factory.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/http-requests/samples) ([how to download](xref:index#how-to-download-a-sample)).

The sample code in this topic version uses <xref:System.Text.Json> to deserialize JSON content returned in HTTP responses. For samples that use `Json.NET` and `ReadAsAsync<T>`, use the version selector to select a 2.x version of this topic.

## Consumption patterns

There are several ways `IHttpClientFactory` can be used in an app:

* [Basic usage](#basic-usage)
* [Named clients](#named-clients)
* [Typed clients](#typed-clients)
* [Generated clients](#generated-clients)

The best approach depends upon the app's requirements.

### Basic usage

`IHttpClientFactory` can be registered by calling `AddHttpClient`:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet1" highlight="13":::

An `IHttpClientFactory` can be requested using [dependency injection (DI)](xref:fundamentals/dependency-injection). The following code uses `IHttpClientFactory` to create an `HttpClient` instance:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Pages/BasicUsage.cshtml.cs" id="snippet1" highlight="9-12,21":::

Using `IHttpClientFactory` like in the preceding example is a good way to refactor an existing app. It has no impact on how `HttpClient` is used. In places where `HttpClient` instances are created in an existing app, replace those occurrences with calls to <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A>.

### Named clients

Named clients are a good choice when:

* The app requires many distinct uses of `HttpClient`.
* Many `HttpClient`s have different configuration.

Configuration for a named `HttpClient` can be specified during registration in `Startup.ConfigureServices`:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet2":::

In the preceding code the client is configured with:

* The base address `https://api.github.com/`.
* Two headers required to work with the GitHub API.

#### CreateClient

Each time <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A> is called:

* A new instance of `HttpClient` is created.
* The configuration action is called.

To create a named client, pass its name into `CreateClient`:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Pages/NamedClient.cshtml.cs" id="snippet1" highlight="21":::

In the preceding code, the request doesn't need to specify a hostname. The code can pass just the path, since the base address configured for the client is used.

### Typed clients

Typed clients:

* Provide the same capabilities as named clients without the need to use strings as keys.
* Provides IntelliSense and compiler help when consuming clients.
* Provide a single location to configure and interact with a particular `HttpClient`. For example, a single typed client might be used:
  * For a single backend endpoint.
  * To encapsulate all logic dealing with the endpoint.
* Work with DI and can be injected where required in the app.

A typed client accepts an `HttpClient` parameter in its constructor:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/GitHub/GitHubService.cs" id="snippet1" highlight="5":::
[!INCLUDE[about the series](~/includes/code-comments-loc.md)]

In the preceding code:

* The configuration is moved into the typed client.
* The `HttpClient` object is exposed as a public property.

API-specific methods can be created that expose `HttpClient` functionality. For example, the `GetAspNetDocsIssues` method encapsulates code to retrieve open issues.

The following code calls <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> in `Startup.ConfigureServices` to register a typed client class:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet3":::

The typed client is registered as transient with DI. In the preceding code, `AddHttpClient` registers `GitHubService` as a transient service. This registration uses a factory method to:

1. Create an instance of `HttpClient`.
1. Create an instance of `GitHubService`, passing in the instance of `HttpClient` to its constructor.

The typed client can be injected and consumed directly:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Pages/TypedClient.cshtml.cs" id="snippet1" highlight="11-14,20":::

The configuration for a typed client can be specified during registration in `Startup.ConfigureServices`, rather than in the typed client's constructor:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet4":::

The `HttpClient` can be encapsulated within a typed client. Rather than exposing it as a property, define a method which calls the `HttpClient` instance internally:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/GitHub/RepoService.cs" id="snippet1" highlight="4":::

In the preceding code, the `HttpClient` is stored in a private field. Access to the `HttpClient` is by the public `GetRepos` method.

### Generated clients

`IHttpClientFactory` can be used in combination with third-party libraries such as [Refit](https://github.com/paulcbetts/refit). Refit is a REST library for .NET. It converts REST APIs into live interfaces. An implementation of the interface is generated dynamically by the `RestService`, using `HttpClient` to make the external HTTP calls.

An interface and a reply are defined to represent the external API and its response:

```csharp
public interface IHelloClient
{
    [Get("/helloworld")]
    Task<Reply> GetMessageAsync();
}

public class Reply
{
    public string Message { get; set; }
}
```

A typed client can be added, using Refit to generate the implementation:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient("hello", c =>
    {
        c.BaseAddress = new Uri("http://localhost:5000");
    })
    .AddTypedClient(c => Refit.RestService.For<IHelloClient>(c));

    services.AddControllers();
}
```

The defined interface can be consumed where necessary, with the implementation provided by DI and Refit:

```csharp
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IHelloClient _client;

    public ValuesController(IHelloClient client)
    {
        _client = client;
    }

    [HttpGet("/")]
    public async Task<ActionResult<Reply>> Index()
    {
        return await _client.GetMessageAsync();
    }
}
```

## Make POST, PUT, and DELETE requests

In the preceding examples, all HTTP requests use the GET HTTP verb. `HttpClient` also supports other HTTP verbs, including:

* POST
* PUT
* DELETE
* PATCH

For a complete list of supported HTTP verbs, see <xref:System.Net.Http.HttpMethod>.

The following example shows how to make an HTTP POST request:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Models/TodoClient.cs" id="snippet_POST":::

In the preceding code, the `CreateItemAsync` method:

* Serializes the `TodoItem` parameter to JSON using `System.Text.Json`. This uses an instance of <xref:System.Text.Json.JsonSerializerOptions> to configure the serialization process.
* Creates an instance of <xref:System.Net.Http.StringContent> to package the serialized JSON for sending in the HTTP request's body.
* Calls <xref:System.Net.Http.HttpClient.PostAsync%2A> to send the JSON content to the specified URL. This is a relative URL that gets added to the [HttpClient.BaseAddress](xref:System.Net.Http.HttpClient.BaseAddress).
* Calls <xref:System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode%2A> to throw an exception if the response status code does not indicate success.

`HttpClient` also supports other types of content. For example, <xref:System.Net.Http.MultipartContent> and <xref:System.Net.Http.StreamContent>. For a complete list of supported content, see <xref:System.Net.Http.HttpContent>.

The following example shows an HTTP PUT request:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Models/TodoClient.cs" id="snippet_PUT":::

The preceding code is very similar to the POST example. The `SaveItemAsync` method calls <xref:System.Net.Http.HttpClient.PutAsync%2A> instead of `PostAsync`.

The following example shows an HTTP DELETE request:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Models/TodoClient.cs" id="snippet_DELETE":::

In the preceding code, the `DeleteItemAsync` method calls <xref:System.Net.Http.HttpClient.DeleteAsync%2A>. Because HTTP DELETE requests typically contain no body, the `DeleteAsync` method doesn't provide an overload that accepts an instance of `HttpContent`.

To learn more about using different HTTP verbs with `HttpClient`, see <xref:System.Net.Http.HttpClient>.

## Outgoing request middleware

`HttpClient` has the concept of delegating handlers that can be linked together for outgoing HTTP requests. `IHttpClientFactory`:

* Simplifies defining the handlers to apply for each named client.
* Supports registration and chaining of multiple handlers to build an outgoing request middleware pipeline. Each of these handlers is able to perform work before and after the   outgoing request. This pattern:
  * Is similar to the inbound middleware pipeline in ASP.NET Core.
  * Provides a mechanism to manage cross-cutting concerns around HTTP requests, such as:
    * caching
    * error handling
    * serialization
    * logging

To create a delegating handler:

* Derive from <xref:System.Net.Http.DelegatingHandler>.
* Override <xref:System.Net.Http.DelegatingHandler.SendAsync%2A>. Execute code before passing the request to the next handler in the pipeline:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Handlers/ValidateHeaderHandler.cs" id="snippet1":::

The preceding code checks if the `X-API-KEY` header is in the request. If `X-API-KEY` is missing, <xref:System.Net.HttpStatusCode.BadRequest> is returned.

More than one handler can be added to the configuration for an `HttpClient` with <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A?displayProperty=fullName>:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup2.cs" id="snippet1":::

In the preceding code, the `ValidateHeaderHandler` is registered with DI. Once registered, <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> can be called, passing in the type for the handler.

Multiple handlers can be registered in the order that they should execute. Each handler wraps the next handler until the final `HttpClientHandler` executes the request:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet6":::

### Use DI in outgoing request middleware

When `IHttpClientFactory` creates a new delegating handler, it uses DI to fulfill the handler's constructor parameters. `IHttpClientFactory` creates a **separate** DI scope for each handler, which can lead to surprising behavior when a handler consumes a *scoped* service.

For example, consider the following interface and its implementation, which represents a task as an operation with an identifier, `OperationId`:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Models/OperationScoped.cs" id="snippet_Types":::

As its name suggests, `IOperationScoped` is registered with DI using a *scoped* lifetime:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Startup.cs" id="snippet_IOperationScoped" highlight="18,26":::

The following delegating handler consumes and uses `IOperationScoped` to set the `X-OPERATION-ID` header for the outgoing request:

:::code language="csharp" source="http-requests/samples/3.x/HttpRequestsSample/Handlers/OperationHandler.cs" id="snippet_Class" highlight="13":::

In the [`HttpRequestsSample` download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/http-requests/samples/3.x/HttpRequestsSample)], navigate to `/Operation` and refresh the page. The request scope value changes for each request, but the handler scope value only changes every 5 seconds.

Handlers can depend upon services of any scope. Services that handlers depend upon are disposed when the handler is disposed.

Use one of the following approaches to share per-request state with message handlers:

* Pass data into the handler using <xref:System.Net.Http.HttpRequestMessage.Properties%2A?displayProperty=nameWithType>.
* Use <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> to access the current request.
* Create a custom <xref:System.Threading.AsyncLocal%601> storage object to pass the data.

## Use Polly-based handlers

`IHttpClientFactory` integrates with the third-party library [Polly](https://github.com/App-vNext/Polly). Polly is a comprehensive resilience and transient fault-handling library for .NET. It allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.

Extension methods are provided to enable the use of Polly policies with configured `HttpClient` instances. The Polly extensions support adding Polly-based handlers to clients. Polly requires the [Microsoft.Extensions.Http.Polly](https://www.nuget.org/packages/Microsoft.Extensions.Http.Polly/) NuGet package.

### Handle transient faults

Faults typically occur when external HTTP calls are transient. <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddTransientHttpErrorPolicy%2A> allows a policy to be defined to handle transient errors. Policies configured with `AddTransientHttpErrorPolicy` handle the following responses:

* <xref:System.Net.Http.HttpRequestException>
* HTTP 5xx
* HTTP 408

`AddTransientHttpErrorPolicy` provides access to a `PolicyBuilder` object configured to handle errors representing a possible transient fault:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup3.cs" id="snippet1":::

In the preceding code, a `WaitAndRetryAsync` policy is defined. Failed requests are retried up to three times with a delay of 600 ms between attempts.

### Dynamically select policies

Extension methods are provided to add Polly-based handlers, for example, <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddPolicyHandler%2A>. The following `AddPolicyHandler` overload inspects the request to decide which policy to apply:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet8":::

In the preceding code, if the outgoing request is an HTTP GET, a 10-second timeout is applied. For any other HTTP method, a 30-second timeout is used.

### Add multiple Polly handlers

It's common to nest Polly policies:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup.cs" id="snippet9":::

In the preceding example:

* Two handlers are added.
* The first handler uses <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddTransientHttpErrorPolicy%2A> to add a retry policy. Failed requests are retried up to three times.
* The second `AddTransientHttpErrorPolicy` call adds a circuit breaker policy. Further external requests are blocked for 30 seconds if 5 failed attempts occur sequentially. Circuit breaker policies are stateful. All calls through this client share the same circuit state.

### Add policies from the Polly registry

An approach to managing regularly used policies is to define them once and register them with a `PolicyRegistry`.

In the following code:

* The "regular" and "long" policies are added.
* <xref:Microsoft.Extensions.DependencyInjection.PollyHttpClientBuilderExtensions.AddPolicyHandlerFromRegistry%2A> adds the "regular" and "long" policies from the registry.

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup4.cs" id="snippet1":::

For more information on `IHttpClientFactory` and Polly integrations, see the [Polly wiki](https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory).

## HttpClient and lifetime management

A new `HttpClient` instance is returned each time `CreateClient` is called on the `IHttpClientFactory`. An <xref:System.Net.Http.HttpMessageHandler> is created per named client. The factory manages the lifetimes of the `HttpMessageHandler` instances.

`IHttpClientFactory` pools the `HttpMessageHandler` instances created by the factory to reduce resource consumption. An `HttpMessageHandler` instance may be reused from the pool when creating a new `HttpClient` instance if its lifetime hasn't expired.

Pooling of handlers is desirable as each handler typically manages its own underlying HTTP connections. Creating more handlers than necessary can result in connection delays. Some handlers also keep connections open indefinitely, which can prevent the handler from reacting to DNS (Domain Name System) changes.

The default handler lifetime is two minutes. The default value can be overridden on a per named client basis:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup5.cs" id="snippet1":::

`HttpClient` instances can generally be treated as .NET objects **not** requiring disposal. Disposal cancels outgoing requests and guarantees the given `HttpClient` instance can't be used after calling <xref:System.IDisposable.Dispose%2A>. `IHttpClientFactory` tracks and disposes resources used by `HttpClient` instances.

Keeping a single `HttpClient` instance alive for a long duration is a common pattern used before the inception of `IHttpClientFactory`. This pattern becomes unnecessary after migrating to `IHttpClientFactory`.

### Alternatives to IHttpClientFactory

Using `IHttpClientFactory` in a DI-enabled app avoids:

* Resource exhaustion problems by pooling `HttpMessageHandler` instances.
* Stale DNS problems by cycling `HttpMessageHandler` instances at regular intervals.

There are alternative ways to solve the preceding problems using a long-lived <xref:System.Net.Http.SocketsHttpHandler> instance.

* Create an instance of `SocketsHttpHandler` when the app starts and use it for the life of the app.
* Configure <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> to an appropriate value based on DNS refresh times.
* Create `HttpClient` instances using `new HttpClient(handler, disposeHandler: false)` as needed.

The preceding approaches solve the resource management problems that `IHttpClientFactory` solves in a similar way.

* The `SocketsHttpHandler` shares connections across `HttpClient` instances. This sharing prevents socket exhaustion.
* The `SocketsHttpHandler` cycles connections according to `PooledConnectionLifetime` to avoid stale DNS problems.

### Cookies

The pooled `HttpMessageHandler` instances results in `CookieContainer` objects being shared. Unanticipated `CookieContainer` object sharing often results in incorrect code. For apps that require cookies, consider either:

* Disabling automatic cookie handling
* Avoiding `IHttpClientFactory`

Call <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> to disable automatic cookie handling:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet13":::

## Logging

Clients created via `IHttpClientFactory` record log messages for all requests. Enable the appropriate information level in the logging configuration to see the default log messages. Additional logging, such as the logging of request headers, is only included at trace level.

The log category used for each client includes the name of the client. A client named *MyNamedClient*, for example, logs messages with a category of "System.Net.Http.HttpClient.**MyNamedClient**.LogicalHandler". Messages suffixed with *LogicalHandler* occur outside the request handler pipeline. On the request, messages are logged before any other handlers in the pipeline have processed it. On the response, messages are logged after any other pipeline handlers have received the response.

Logging also occurs inside the request handler pipeline. In the *MyNamedClient* example, those messages are logged with the log category "System.Net.Http.HttpClient.**MyNamedClient**.ClientHandler". For the request, this occurs after all other handlers have run and immediately before the request is sent. On the response, this logging includes the state of the response before it passes back through the handler pipeline.

Enabling logging outside and inside the pipeline enables inspection of the changes made by the other pipeline handlers. This may include changes to request headers or to the response status code.

Including the name of the client in the log category enables log filtering for specific named clients.

## Configure the HttpMessageHandler

It may be necessary to control the configuration of the inner `HttpMessageHandler` used by a client.

An `IHttpClientBuilder` is returned when adding named or typed clients. The <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method can be used to define a delegate. The delegate is used to create and configure the primary `HttpMessageHandler` used by that client:

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactorySample/Startup6.cs" id="snippet1":::

## Use IHttpClientFactory in a console app

In a console app, add the following package references to the project:

* [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting)
* [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)

In the following example:

* <xref:System.Net.Http.IHttpClientFactory> is registered in the [Generic Host's](xref:fundamentals/host/generic-host) service container.
* `MyService` creates a client factory instance from the service, which is used to create an `HttpClient`. `HttpClient` is used to retrieve a webpage.
* `Main` creates a scope to execute the service's `GetPage` method and write the first 500 characters of the webpage content to the console.

:::code language="csharp" source="http-requests/samples/3.x/HttpClientFactoryConsoleSample/Program.cs" highlight="14-15,20,26-27,59-62":::

## Header propagation middleware

Header propagation is an ASP.NET Core middleware to propagate HTTP headers from the incoming request to the outgoing HTTP Client requests. To use header propagation:

* Reference the [Microsoft.AspNetCore.HeaderPropagation](https://www.nuget.org/packages/Microsoft.AspNetCore.HeaderPropagation) package.
* Configure the middleware and `HttpClient` in `Startup`:

  :::code language="csharp" source="http-requests/samples/3.x/Startup.cs" id="snippet" highlight="5-9,21":::

* The client includes the configured headers on outbound requests:

  ```csharp
  var client = clientFactory.CreateClient("MyForwardingClient");
  var response = client.GetAsync(...);
  ```

## Additional resources

* [Use HttpClientFactory to implement resilient HTTP requests](/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)
* [Implement HTTP call retries with exponential backoff with HttpClientFactory and Polly policies](/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly)
* [Implement the Circuit Breaker pattern](/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-circuit-breaker-pattern)
* [How to serialize and deserialize JSON in .NET](/dotnet/standard/serialization/system-text-json-how-to)

:::moniker-end

:::moniker range="< aspnetcore-3.0"

By [Glenn Condron](https://github.com/glennc), [Ryan Nowak](https://github.com/rynowak), and [Steve Gordon](https://github.com/stevejgordon)

An <xref:System.Net.Http.IHttpClientFactory> can be registered and used to configure and create <xref:System.Net.Http.HttpClient> instances in an app. It offers the following benefits:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, a *github* client can be registered and configured to access [GitHub](https://github.com/). A default client can be registered for other purposes.
* Codifies the concept of outgoing middleware via delegating handlers in `HttpClient` and provides extensions for Polly-based middleware to take advantage of that.
* Manages the pooling and lifetime of underlying `HttpClientMessageHandler` instances to avoid common DNS problems that occur when manually managing `HttpClient` lifetimes.
* Adds a configurable logging experience (via `ILogger`) for all requests sent through clients created by the factory.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/http-requests/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

Projects targeting .NET Framework require installation of the [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http/) NuGet package. Projects that target .NET Core and reference the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) already include the `Microsoft.Extensions.Http` package.

## Consumption patterns

There are several ways `IHttpClientFactory` can be used in an app:

* [Basic usage](#basic-usage)
* [Named clients](#named-clients)
* [Typed clients](#typed-clients)
* [Generated clients](#generated-clients)

None of them are strictly superior to another. The best approach depends upon the app's constraints.

### Basic usage

The `IHttpClientFactory` can be registered by calling the `AddHttpClient` extension method on the `IServiceCollection`, inside the `Startup.ConfigureServices` method.

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet1":::

Once registered, code can accept an `IHttpClientFactory` anywhere services can be injected with [dependency injection (DI)](xref:fundamentals/dependency-injection). The `IHttpClientFactory` can be used to create an `HttpClient` instance:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Pages/BasicUsage.cshtml.cs" id="snippet1" highlight="9-12,21":::

Using `IHttpClientFactory` in this fashion is a good way to refactor an existing app. It has no impact on the way `HttpClient` is used. In places where `HttpClient` instances are currently created, replace those occurrences with a call to <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A>.

### Named clients

If an app requires many distinct uses of `HttpClient`, each with a different configuration, an option is to use **named clients**. Configuration for a named `HttpClient` can be specified during registration in `Startup.ConfigureServices`.

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet2":::

In the preceding code, `AddHttpClient` is called, providing the name *github*. This client has some default configuration applied&mdash;namely the base address and two headers required to work with the GitHub API.

Each time `CreateClient` is called, a new instance of `HttpClient` is created and the configuration action is called.

To consume a named client, a string parameter can be passed to `CreateClient`. Specify the name of the client to be created:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Pages/NamedClient.cshtml.cs" id="snippet1" highlight="21":::

In the preceding code, the request doesn't need to specify a hostname. It can pass just the path, since the base address configured for the client is used.

### Typed clients

Typed clients:

* Provide the same capabilities as named clients without the need to use strings as keys.
* Provides IntelliSense and compiler help when consuming clients.
* Provide a single location to configure and interact with a particular `HttpClient`. For example, a single typed client might be used for a single backend endpoint and encapsulate all logic dealing with that endpoint.
* Work with DI and can be injected where required in your app.

A typed client accepts an `HttpClient` parameter in its constructor:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/GitHub/GitHubService.cs" id="snippet1" highlight="5":::

In the preceding code, the configuration is moved into the typed client. The `HttpClient` object is exposed as a public property. It's possible to define API-specific methods that expose `HttpClient` functionality. The `GetAspNetDocsIssues` method encapsulates the code needed to query for and parse out the latest open issues from a GitHub repository.

To register a typed client, the generic <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> extension method can be used within `Startup.ConfigureServices`, specifying the typed client class:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet3":::

The typed client is registered as transient with DI. The typed client can be injected and consumed directly:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Pages/TypedClient.cshtml.cs" id="snippet1" highlight="11-14,20":::

If preferred, the configuration for a typed client can be specified during registration in `Startup.ConfigureServices`, rather than in the typed client's constructor:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet4":::

It's possible to entirely encapsulate the `HttpClient` within a typed client. Rather than exposing it as a property, public methods can be provided which call the `HttpClient` instance internally.

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/GitHub/RepoService.cs" id="snippet1" highlight="4":::

In the preceding code, the `HttpClient` is stored as a private field. All access to make external calls goes through the `GetRepos` method.

### Generated clients

`IHttpClientFactory` can be used in combination with other third-party libraries such as [Refit](https://github.com/paulcbetts/refit). Refit is a REST library for .NET. It converts REST APIs into live interfaces. An implementation of the interface is generated dynamically by the `RestService`, using `HttpClient` to make the external HTTP calls.

An interface and a reply are defined to represent the external API and its response:

```csharp
public interface IHelloClient
{
    [Get("/helloworld")]
    Task<Reply> GetMessageAsync();
}

public class Reply
{
    public string Message { get; set; }
}
```

A typed client can be added, using Refit to generate the implementation:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient("hello", c =>
    {
        c.BaseAddress = new Uri("http://localhost:5000");
    })
    .AddTypedClient(c => Refit.RestService.For<IHelloClient>(c));

    services.AddMvc();
}
```

The defined interface can be consumed where necessary, with the implementation provided by DI and Refit:

```csharp
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IHelloClient _client;

    public ValuesController(IHelloClient client)
    {
        _client = client;
    }

    [HttpGet("/")]
    public async Task<ActionResult<Reply>> Index()
    {
        return await _client.GetMessageAsync();
    }
}
```

## Outgoing request middleware

`HttpClient` already has the concept of delegating handlers that can be linked together for outgoing HTTP requests. The `IHttpClientFactory` makes it easy to define the handlers to apply for each named client. It supports registration and chaining of multiple handlers to build an outgoing request middleware pipeline. Each of these handlers is able to perform work before and after the outgoing request. This pattern is similar to the inbound middleware pipeline in ASP.NET Core. The pattern provides a mechanism to manage cross-cutting concerns around HTTP requests, including caching, error handling, serialization, and logging.

To create a handler, define a class deriving from <xref:System.Net.Http.DelegatingHandler>. Override the `SendAsync` method to execute code before passing the request to the next handler in the pipeline:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Handlers/ValidateHeaderHandler.cs" id="snippet1":::

The preceding code defines a basic handler. It checks to see if an `X-API-KEY` header has been included on the request. If the header is missing, it can avoid the HTTP call and return a suitable response.

During registration, one or more handlers can be added to the configuration for an `HttpClient`. This task is accomplished via extension methods on the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder>.

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet5":::

In the preceding code, the `ValidateHeaderHandler` is registered with DI. The handler **must** be registered in DI as a transient service, never scoped. If the handler is registered as a scoped service and any services that the handler depends upon are disposable:

* The handler's services could be disposed before the handler goes out of scope.
* The disposed handler services causes the handler to fail.

Once registered, <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> can be called, passing in the handler type.

Multiple handlers can be registered in the order that they should execute. Each handler wraps the next handler until the final `HttpClientHandler` executes the request:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet6":::

Use one of the following approaches to share per-request state with message handlers:

* Pass data into the handler using `HttpRequestMessage.Properties`.
* Use `IHttpContextAccessor` to access the current request.
* Create a custom `AsyncLocal` storage object to pass the data.

## Use Polly-based handlers

`IHttpClientFactory` integrates with a popular third-party library called [Polly](https://github.com/App-vNext/Polly). Polly is a comprehensive resilience and transient fault-handling library for .NET. It allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.

Extension methods are provided to enable the use of Polly policies with configured `HttpClient` instances. The Polly extensions:

* Support adding Polly-based handlers to clients.
* Can be used after installing the [Microsoft.Extensions.Http.Polly](https://www.nuget.org/packages/Microsoft.Extensions.Http.Polly/) NuGet package. The package isn't included in the ASP.NET Core shared framework.

### Handle transient faults

Most common faults occur when external HTTP calls are transient. A convenient extension method called `AddTransientHttpErrorPolicy` is included which allows a policy to be defined to handle transient errors. Policies configured with this extension method handle `HttpRequestException`, HTTP 5xx responses, and HTTP 408 responses.

The `AddTransientHttpErrorPolicy` extension can be used within `Startup.ConfigureServices`. The extension provides access to a `PolicyBuilder` object configured to handle errors representing a possible transient fault:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet7":::

In the preceding code, a `WaitAndRetryAsync` policy is defined. Failed requests are retried up to three times with a delay of 600 ms between attempts.

### Dynamically select policies

Additional extension methods exist which can be used to add Polly-based handlers. One such extension is `AddPolicyHandler`, which has multiple overloads. One overload allows the request to be inspected when defining which policy to apply:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet8":::

In the preceding code, if the outgoing request is an HTTP GET, a 10-second timeout is applied. For any other HTTP method, a 30-second timeout is used.

### Add multiple Polly handlers

It's common to nest Polly policies to provide enhanced functionality:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet9":::

In the preceding example, two handlers are added. The first uses the `AddTransientHttpErrorPolicy` extension to add a retry policy. Failed requests are retried up to three times. The second call to `AddTransientHttpErrorPolicy` adds a circuit breaker policy. Further external requests are blocked for 30 seconds if five failed attempts occur sequentially. Circuit breaker policies are stateful. All calls through this client share the same circuit state.

### Add policies from the Polly registry

An approach to managing regularly used policies is to define them once and register them with a `PolicyRegistry`. An extension method is provided which allows a handler to be added using a policy from the registry:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet10":::

In the preceding code, two policies are registered when the `PolicyRegistry` is added to the `ServiceCollection`. To use a policy from the registry, the `AddPolicyHandlerFromRegistry` method is used, passing the name of the policy to apply.

Further information about `IHttpClientFactory` and Polly integrations can be found on the [Polly wiki](https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory).

## HttpClient and lifetime management

A new `HttpClient` instance is returned each time `CreateClient` is called on the `IHttpClientFactory`. There's an <xref:System.Net.Http.HttpMessageHandler> per named client. The factory manages the lifetimes of the `HttpMessageHandler` instances.

`IHttpClientFactory` pools the `HttpMessageHandler` instances created by the factory to reduce resource consumption. An `HttpMessageHandler` instance may be reused from the pool when creating a new `HttpClient` instance if its lifetime hasn't expired.

Pooling of handlers is desirable as each handler typically manages its own underlying HTTP connections. Creating more handlers than necessary can result in connection delays. Some handlers also keep connections open indefinitely, which can prevent the handler from reacting to DNS changes.

The default handler lifetime is two minutes. The default value can be overridden on a per named client basis. To override it, call <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.SetHandlerLifetime%2A> on the `IHttpClientBuilder` that is returned when creating the client:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet11":::

Disposal of the client isn't required. Disposal cancels outgoing requests and guarantees the given `HttpClient` instance can't be used after calling <xref:System.IDisposable.Dispose%2A>. `IHttpClientFactory` tracks and disposes resources used by `HttpClient` instances. The `HttpClient` instances can generally be treated as .NET objects not requiring disposal.

Keeping a single `HttpClient` instance alive for a long duration is a common pattern used before the inception of `IHttpClientFactory`. This pattern becomes unnecessary after migrating to `IHttpClientFactory`.

### Alternatives to IHttpClientFactory

Using `IHttpClientFactory` in a DI-enabled app avoids:

* Resource exhaustion problems by pooling `HttpMessageHandler` instances.
* Stale DNS problems by cycling `HttpMessageHandler` instances at regular intervals.

There are alternative ways to solve the preceding problems using a long-lived <xref:System.Net.Http.SocketsHttpHandler> instance.

* Create an instance of `SocketsHttpHandler` when the app starts and use it for the life of the app.
* Configure <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> to an appropriate value based on DNS refresh times.
* Create `HttpClient` instances using `new HttpClient(handler, disposeHandler: false)` as needed.

The preceding approaches solve the resource management problems that `IHttpClientFactory` solves in a similar way.

* The `SocketsHttpHandler` shares connections across `HttpClient` instances. This sharing prevents socket exhaustion.
* The `SocketsHttpHandler` cycles connections according to `PooledConnectionLifetime` to avoid stale DNS problems.

### Cookies

The pooled `HttpMessageHandler` instances results in `CookieContainer` objects being shared. Unanticipated `CookieContainer` object sharing often results in incorrect code. For apps that require cookies, consider either:

* Disabling automatic cookie handling
* Avoiding `IHttpClientFactory`

Call <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> to disable automatic cookie handling:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet13":::

## Logging

Clients created via `IHttpClientFactory` record log messages for all requests. Enable the appropriate information level in your logging configuration to see the default log messages. Additional logging, such as the logging of request headers, is only included at trace level.

The log category used for each client includes the name of the client. A client named *MyNamedClient*, for example, logs messages with a category of `System.Net.Http.HttpClient.MyNamedClient.LogicalHandler`. Messages suffixed with *LogicalHandler* occur outside the request handler pipeline. On the request, messages are logged before any other handlers in the pipeline have processed it. On the response, messages are logged after any other pipeline handlers have received the response.

Logging also occurs inside the request handler pipeline. In the *MyNamedClient* example, those messages are logged against the log category `System.Net.Http.HttpClient.MyNamedClient.ClientHandler`. For the request, this occurs after all other handlers have run and immediately before the request is sent out on the network. On the response, this logging includes the state of the response before it passes back through the handler pipeline.

Enabling logging outside and inside the pipeline enables inspection of the changes made by the other pipeline handlers. This may include changes to request headers, for example, or to the response status code.

Including the name of the client in the log category enables log filtering for specific named clients where necessary.

## Configure the HttpMessageHandler

It may be necessary to control the configuration of the inner `HttpMessageHandler` used by a client.

An `IHttpClientBuilder` is returned when adding named or typed clients. The <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method can be used to define a delegate. The delegate is used to create and configure the primary `HttpMessageHandler` used by that client:

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactorySample/Startup.cs" id="snippet12":::

## Use IHttpClientFactory in a console app

In a console app, add the following package references to the project:

* [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting)
* [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)

In the following example:

* <xref:System.Net.Http.IHttpClientFactory> is registered in the [Generic Host's](xref:fundamentals/host/generic-host) service container.
* `MyService` creates a client factory instance from the service, which is used to create an `HttpClient`. `HttpClient` is used to retrieve a webpage.
* The service's `GetPage` method is executed to write the first 500 characters of the webpage content to the console. For more information on calling services from `Program.Main`, see <xref:fundamentals/dependency-injection#call-services-from-main>.

:::code language="csharp" source="http-requests/samples/2.x/HttpClientFactoryConsoleSample/Program.cs" highlight="14-15,22":::

## Header propagation middleware

Header propagation is a community supported middleware to propagate HTTP headers from the incoming request to the outgoing HTTP Client requests. To use header propagation:

* Reference the community supported port of the package [HeaderPropagation](https://www.nuget.org/packages/HeaderPropagation). ASP.NET Core 3.1 and later supports [Microsoft.AspNetCore.HeaderPropagation](https://www.nuget.org/packages/Microsoft.AspNetCore.HeaderPropagation).

* Configure the middleware and `HttpClient` in `Startup`:

  :::code language="csharp" source="http-requests/samples/2.x/Startup21.cs" id="snippet" highlight="5-9,25":::

* The client includes the configured headers on outbound requests:

  ```csharp
  var client = clientFactory.CreateClient("MyForwardingClient");
  var response = client.GetAsync(...);
  ```

## Additional resources

* [Use HttpClientFactory to implement resilient HTTP requests](/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)
* [Implement HTTP call retries with exponential backoff with HttpClientFactory and Polly policies](/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly)
* [Implement the Circuit Breaker pattern](/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-circuit-breaker-pattern)

:::moniker-end
