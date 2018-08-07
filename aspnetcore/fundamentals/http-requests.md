---
title: Initiate HTTP requests
author: stevejgordon
description: Learn about using the IHttpClientFactory interface to manage logical HttpClient instances in ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.author: scaddie
ms.custom: mvc
ms.date: 08/07/2018
uid: fundamentals/http-requests
---
# Initiate HTTP requests

By [Glenn Condron](https://github.com/glennc), [Ryan Nowak](https://github.com/rynowak), and [Steve Gordon](https://github.com/stevejgordon)

An [IHttpClientFactory](/dotnet/api/system.net.http.ihttpclientfactory) can be registered and used to configure and create [HttpClient](/dotnet/api/system.net.http.httpclient) instances in an app. It offers the following benefits:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, a *github* client can be registered and configured to access GitHub. A default client can be registered for other purposes.
* Codifies the concept of outgoing middleware via delegating handlers in `HttpClient` and provides extensions for Polly-based middleware to take advantage of that.
* Manages the pooling and lifetime of underlying `HttpClientMessageHandler` instances to avoid common DNS problems that occur when manually managing `HttpClient` lifetimes.
* Adds a configurable logging experience (via `ILogger`) for all requests sent through clients created by the factory.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/http-requests/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

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

[!code-csharp[](http-requests/samples/Startup.cs?name=snippet1)]

Once registered, code can accept an `IHttpClientFactory` anywhere services can be injected with [dependency injection](xref:fundamentals/dependency-injection) (DI). The `IHttpClientFactory` can be used to create a `HttpClient` instance:

[!code-csharp[](http-requests/samples/Pages/BasicUsage.cshtml.cs?name=snippet1&highlight=9-12,20)]

Using `IHttpClientFactory` in this fashion is a great way to refactor an existing app. It has no impact on the way `HttpClient` is used. In places where `HttpClient` instances are currently created, replace those occurrences with a call to [CreateClient](/dotnet/api/system.net.http.ihttpclientfactory.createclient).

### Named clients

If an app requires many distinct uses of `HttpClient`, each with a different configuration, an option is to use **named clients**. Configuration for a named `HttpClient` can be specified during registration in `Startup.ConfigureServices`.

[!code-csharp[](http-requests/samples/Startup.cs?name=snippet2)]

In the preceding code, `AddHttpClient` is called, providing the name *github*. This client has some default configuration applied&mdash;namely the base address and two headers required to work with the GitHub API.

Each time `CreateClient` is called, a new instance of `HttpClient` is created and the configuration action is called.

To consume a named client, a string parameter can be passed to `CreateClient`. Specify the name of the client to be created:

[!code-csharp[](http-requests/samples/Pages/NamedClient.cshtml.cs?name=snippet1&highlight=20)]

In the preceding code, the request doesn't need to specify a hostname. It can pass just the path, since the base address configured for the client is used.

### Typed clients

Typed clients provide the same capabilities as named clients without the need to use strings as keys. The typed client approach provides IntelliSense and compiler help when consuming clients. They provide a single location to configure and interact with a particular `HttpClient`. For example, a single typed client might be used for a single backend endpoint and encapsulate all logic dealing with that endpoint. Another advantage is that they work with DI and can be injected where required in your app.

A typed client accepts a `HttpClient` parameter in its constructor:

[!code-csharp[](http-requests/samples/GitHub/GitHubService.cs?name=snippet1&highlight=5)]

In the preceding code, the configuration is moved into the typed client. The `HttpClient` object is exposed as a public property. It's possible to define API-specific methods that expose `HttpClient` functionality. The `GetAspNetDocsIssues` method encapsulates the code needed to query for and parse out the latest open issues from a GitHub repository.

To register a typed client, the generic `AddHttpClient` extension method can be used within `Startup.ConfigureServices`, specifying the typed client class:

[!code-csharp[](http-requests/samples/Startup.cs?name=snippet3)]

The typed client is registered as transient with DI. The typed client can be injected and consumed directly:

[!code-csharp[](http-requests/samples/Pages/TypedClient.cshtml.cs?name=snippet1&highlight=11-14,20)]

If preferred, the configuration for a typed client can be specified during registration in `Startup.ConfigureServices`, rather than in the typed client's constructor:

[!code-csharp[](http-requests/samples/Startup.cs?name=snippet4)]

It's possible to entirely encapsulate the `HttpClient` within a typed client. Rather than exposing it as a property, public methods can be provided which call the `HttpClient` instance internally.

[!code-csharp[](http-requests/samples/GitHub/RepoService.cs?name=snippet1&highlight=3)]

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

To create a handler, define a class deriving from `DelegatingHandler`. Override the `SendAsync` method to execute code before passing the request to the next handler in the pipeline:

[!code-csharp[Main](http-requests/samples/Handlers/ValidateHeaderHandler.cs?name=snippet1)]

The preceding code defines a basic handler. It checks to see if an `X-API-KEY` header has been included on the request. If the header is missing, it can avoid the HTTP call and return a suitable response.

During registration, one or more handlers can be added to the configuration for a `HttpClient`. This task is accomplished via extension methods on the [IHttpClientBuilder](/dotnet/api/microsoft.extensions.dependencyinjection.ihttpclientbuilder).

[!code-csharp[](http-requests/samples/Startup.cs?name=snippet5)]

In the preceding code, the `ValidateHeaderHandler` is registered with DI. The handler **must** be registered in DI as transient. Once registered, [AddHttpMessageHandler](/dotnet/api/microsoft.extensions.dependencyinjection.httpclientbuilderextensions.addhttpmessagehandler) can be called, passing in the type for the handler.

Multiple handlers can be registered in the order that they should execute. Each handler wraps the next handler until the final `HttpClientHandler` executes the request:

[!code-csharp[](http-requests/samples/Startup.cs?name=snippet6)]

## Use Polly-based handlers

`IHttpClientFactory` integrates with a popular third-party library called [Polly](https://github.com/App-vNext/Polly). Polly is a comprehensive resilience and transient fault-handling library for .NET. It allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.

Extension methods are provided to enable the use of Polly policies with configured `HttpClient` instances. The Polly extensions are available in the [Microsoft.Extensions.Http.Polly](https://www.nuget.org/packages/Microsoft.Extensions.Http.Polly/) NuGet package. This package isn't included in the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app). To use the extensions, an explicit `<PackageReference />` should be included in the project.

[!code-csharp[](http-requests/samples/HttpClientFactorySample.csproj?highlight=9)]

After restoring this package, extension methods are available to support adding Polly-based handlers to clients.

### Handle transient faults

Most common faults occur when external HTTP calls are transient. A convenient extension method called `AddTransientHttpErrorPolicy` is included which allows a policy to be defined to handle transient errors. Policies configured with this extension method handle `HttpRequestException`, HTTP 5xx responses, and HTTP 408 responses.

The `AddTransientHttpErrorPolicy` extension can be used within `Startup.ConfigureServices`. The extension provides access to a `PolicyBuilder` object configured to handle errors representing a possible transient fault:

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet7)]

In the preceding code, a `WaitAndRetryAsync` policy is defined. Failed requests are retried up to three times with a delay of 600 ms between attempts.

### Dynamically select policies

Additional extension methods exist which can be used to add Polly-based handlers. One such extension is `AddPolicyHandler`, which has multiple overloads. One overload allows the request to be inspected when defining which policy to apply:

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet8)]

In the preceding code, if the outgoing request is a GET, a 10-second timeout is applied. For any other HTTP method, a 30-second timeout is used.

### Add multiple Polly handlers

It is common to nest Polly policies to provide enhanced functionality:

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet9)]

In the preceding example, two handlers are added. The first uses the `AddTransientHttpErrorPolicy` extension to add a retry policy. Failed requests are retried up to three times. The second call to `AddTransientHttpErrorPolicy` adds a circuit breaker policy. Further external requests are blocked for 30 seconds if five failed attempts occur sequentially. Circuit breaker policies are stateful. All calls through this client share the same circuit state.

### Add policies from the Polly registry

An approach to managing regularly used policies is to define them once and register them with a `PolicyRegistry`. An extension method is provided which allows a handler to be added using a policy from the registry:

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet10)]

In the preceding code, two policies are registered when the `PolicyRegistry` is added to the `ServiceCollection`. To use a policy from the registry, the `AddPolicyHandlerFromRegistry` method is used, passing the name of the policy to apply.

Further information about `IHttpClientFactory` and Polly integrations can be found on the [Polly wiki](https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory).

## HttpClient and lifetime management

A new `HttpClient` instance is returned each time `CreateClient` is called on the `IHttpClientFactory`. There's an [HttpMessageHandler](/dotnet/api/system.net.http.httpmessagehandler) per named client. `IHttpClientFactory` pools the `HttpMessageHandler` instances created by the factory to reduce resource consumption. An `HttpMessageHandler` instance may be reused from the pool when creating a new `HttpClient` instance if its lifetime hasn't expired.

Pooling of handlers is desirable as each handler typically manages its own underlying HTTP connections. Creating more handlers than necessary can result in connection delays. Some handlers also keep connections open indefinitely, which can prevent the handler from reacting to DNS changes.

The default handler lifetime is two minutes. The default value can be overridden on a per named client basis. To override it, call [SetHandlerLifetime](/dotnet/api/microsoft.extensions.dependencyinjection.httpclientbuilderextensions.sethandlerlifetime) on the `IHttpClientBuilder` that is returned when creating the client:

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet11)]

Disposal of the client isn't required. Disposal cancels outgoing requests and guarantees the given `HttpClient` instance can't be used after calling [Dispose](/dotnet/api/system.idisposable.dispose#System_IDisposable_Dispose). `IHttpClientFactory` tracks and disposes resources used by `HttpClient` instances. The `HttpClient` instances can generally be treated as .NET objects not requiring disposal.

Keeping a single `HttpClient` instance alive for a long duration is a common pattern used before the inception of `IHttpClientFactory`. This pattern becomes unnecessary after migrating to `IHttpClientFactory`.

## Logging

Clients created via `IHttpClientFactory` record log messages for all requests. Enable the appropriate information level in your logging configuration to see the default log messages. Additional logging, such as the logging of request headers, is only included at trace level.

The log category used for each client includes the name of the client. A client named *MyNamedClient*, for example, logs messages with a category of `System.Net.Http.HttpClient.MyNamedClient.LogicalHandler`. Messages suffixed with *LogicalHandler* occur outside the request handler pipeline. On the request, messages are logged before any other handlers in the pipeline have processed it. On the response, messages are logged after any other pipeline handlers have received the response.

Logging also occurs inside the request handler pipeline. In the *MyNamedClient* example, those messages are logged against the log category `System.Net.Http.HttpClient.MyNamedClient.ClientHandler`. For the request, this occurs after all other handlers have run and immediately before the request is sent out on the network. On the response, this logging includes the state of the response before it passes back through the handler pipeline.

Enabling logging outside and inside the pipeline enables inspection of the changes made by the other pipeline handlers. This may include changes to request headers, for example, or to the response status code.

Including the name of the client in the log category enables log filtering for specific named clients where necessary.

## Configure the HttpMessageHandler

It may be necessary to control the configuration of the inner `HttpMessageHandler` used by a client.

An `IHttpClientBuilder` is returned when adding named or typed clients. The [ConfigurePrimaryHttpMessageHandler](/dotnet/api/microsoft.extensions.dependencyinjection.httpclientbuilderextensions.configureprimaryhttpmessagehandler) extension method can be used to define a delegate. The delegate is used to create and configure the primary `HttpMessageHandler` used by that client:

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet12)]
