---
title: Initiate HTTP requests
author: stevejgordon
description: Learn about using the IHttpClientFactory interface to manage logical HttpClient instances in ASP.NET Core.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 04/05/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: fundamentals/http-requests
---
# Initiate HTTP requests

By [Glenn Condron](https://github.com/glennc), [Ryan Nowak](https://github.com/rynowak), and [Steve Gordon](https://github.com/stevejgordon)

An `IHttpClientFactory` can be registered and used to configure and create [HttpClient](/dotnet/api/system.net.http.httpclient) instances in an app. It offers the following benefits:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, a "github" client can be registered and configured to access GitHub. A default client can be registered for other purposes.
* Codifies the concept of outgoing middleware via delegating handlers in `HttpClient` and provides extensions for Polly-based middleware to take advantage of that.
* Manages the pooling and lifetime of underlying `HttpClientMessageHandler` instances to avoid common DNS problems that occur when manually managing `HttpClient` lifetimes.

## Consumption patterns

There are several ways `IHttpClientFactory` can be used in an app:

* [Basic usage](#basic-usage)
* [Named clients](#named-clients)
* [Typed clients](#typed-clients)
* [Generated clients](#generated-clients)

None of them are strictly superior to another. The best approach depends upon the app's constraints.

### Basic usage

The `IHttpClientFactory` can be used directly in code to access `HttpClient` instances. Register the service with the services provider:

[!code-csharp[](http-requests/samples/Startup.cs?name=snippet1&highlight=4)]

Once registered, code can accept an `IHttpClientFactory` anywhere services can be injected with [dependency injection](xref:fundamentals/dependency-injection) (DI). The `IHttpClientFactory` can be used to create a `HttpClient` instance:

[!code-csharp[](http-requests/samples/Pages/BasicUsage.cshtml.cs?name=snippet1&highlight=7-10,18)]

Using `IHttpClientFactory` in this fashion is a great way to refactor an existing app. It has no impact on the way `HttpClient` is used. In places where `HttpClient` instances are currently created, replace those occurrences with a call to `CreateClient`.

### Named clients

If an app requires multiple distinct uses of `HttpClient`, each with different configurations, an option is to use **named clients**. Any common configuration for a named `HttpClient` can be specified during registration.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient("github", c =>
    {
        c.BaseAddress = new Uri("https://api.github.com/");

        c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json"); // GitHub API versioning
        c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");   // GitHub requires a user-agent
    });
    services.AddHttpClient();
}
```

In the preceding code, `AddHttpClient` is called twice: once with the name "github" and once without. The GitHub-specific client has some default configuration applied&mdash;namely the base address and two headers required to work with the GitHub API.

Each time `CreateClient` is called, a new instance of `HttpClient` is created and the configuration function is called.

To consume a named client, a string parameter can be passed to `CreateClient`. Specify the name of the client to be created:

```csharp
public class MyController : Controller
{
    IHttpClientFactory _httpClientFactory;

    public MyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        var defaultClient = _httpClientFactory.CreateClient();
        var gitHubClient = _httpClientFactory.CreateClient("github");
        return View();
    }
}
```

In the preceding code, the `gitHubClient` variable has the `BaseAddress` and `DefaultRequestHeaders` set. The `defaultClient` variable doesn't. This scenario enables different configurations per endpoint/API, for example.

### Typed clients

Typed clients provide the same capabilities as named clients without the need to use strings as keys. The typed client approach provides IntelliSense and compiler help when consuming clients. They provide a single location to configure and interact with a particular `HttpClient`. For example, a single typed client might be used for a single backend endpoint and encapsulate all logic dealing with that endpoint. Another advantage is that they work with DI and can be injected where required in your app.

A typed client accepts a `HttpClient` parameter in its constructor:

[!code-csharp[](http-requests/samples/GitHub/GitHubService.cs?start=12&end=49)]

In the preceding code, the configuration is moved into the typed client. The `HttpClient` object is exposed as a public property. It's possible to define API-specific methods that expose `HttpClient` functionality. The `GetLatestDocsIssue` method encapsulates the code needed to query for and parse out the latest issue from a repository.

To register a typed client, the generic `AddHttpClient` extension method can be used within `ConfigureServices`, specifying the typed client class:

[!code-csharp[](http-requests/samples/Startup.cs?range=43)]

The typed client is registered as transient with DI. The typed client can be injected and consumed directly:

```csharp
public class MyController : Controller
{
    private GitHubService _gitHubService;

    public MyController(GitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _gitHubService.Client.GetStringAsync("/orgs/octokit/repos");
        return Ok(result);
    }
}
```

If preferred, the configuration for a typed client can be specified during registration in `ConfigureServices`, rather than in the typed client's constructor:

[!code-csharp[](http-requests/samples/Startup.cs?start=53&end=59)]

It's possible to entirely encapsulate the `HttpClient` within a typed client. Rather than exposing it as a property, public methods can be provided which call the `HttpClient` instance internally.

```csharp
public class ValuesService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    private readonly ILogger<ValuesService> _logger;

    public ValuesService() { }

    public ValuesService(HttpClient client, IMemoryCache cache, ILogger<ValuesService> logger)
    {
        _httpClient = client;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IEnumerable<string>> GetValues()
    {
        var result = await _httpClient.GetAsync("api/values");
        var resultObj = Enumerable.Empty<string>();

        if (result.IsSuccessStatusCode)
        {
            resultObj = JsonConvert.DeserializeObject<IEnumerable<string>>(await result.Content.ReadAsStringAsync());
            _cache.Set("GetValue", resultObj);
        }
        else
        {
            if (_cache.TryGetValue("GetValue", out resultObj))
            {
                _logger.LogWarning("Returning cached values as the values service is unavailable.");
                return resultObj;
            }
            result.EnsureSuccessStatusCode();
        }        
        return resultObj;
    }
}
```

In the preceding code, the `HttpClient` is stored as a private field. All access to make external calls goes through the `GetValues` method.

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

`HttpClient` already has the concept of delegating handlers that can be linked together for outgoing HTTP requests. The `IHttpClientFactory` makes registration of per-named clients more intuitive. It supports registration and chaining of multiple handlers together to build an outgoing request middleware pipeline. Each of these handlers is able to perform work before and after the outgoing request. This pattern is similar to the inbound middleware pipeline in ASP.NET Core. The pattern provides a mechanism to manage cross-cutting concerns around HTTP requests, including caching, error handling, serialization, and logging.

To create a handler, define a class deriving from `DelegatingHandler`. Override the `SendAsync` method to execute code before passing the request to the next handler in the pipeline:

[!code-csharp[Main](http-requests/samples/Handlers/RequestDataHandler.cs?name=snippet1)]

The preceding code defines a basic handler. It adds a source and request identifier to the headers in the outgoing request.

During registration, one or more handlers can be added to the configuration for a `HttpClient`. This task is accomplished via extension methods on the `HttpClientBuilder`.

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet1&highlight=21-25)]

In the preceding code, the `RequestDataHandler` is registered as a transient service with DI. Once registered, `AddHttpMessageHandler` can be called, passing in the type for the handler.

Multiple handlers can be registered in the order that they should execute. Each handler wraps the next handler until the final `HttpClientHandler` executes the request.

```csharp
public static void Configure(IServiceCollection services)
{
    services.AddTransient<OuterHandler>();
    services.AddTransient<InnerHandler>();

    services.AddHttpClient("example", c =>
    {
        c.BaseAddress = new Uri("https://localhost:5000/");
    })
    .AddHttpMessageHandler<OuterHandler>() // This handler is on the outside and executes first on the way out and last on the way in.
    .AddHttpMessageHandler<InnerHandler>(); // This handler is on the inside, closest to the request.
}
```

## Add Polly-based handlers

_NOTE: This is still a WIP since the Polly Extensions API is still currently under design._

The preceding example demonstrated manually building a simple retry handler. A more robust and feature-rich approach is to leverage a popular third-party library called [Polly](https://github.com/App-vNext/Polly). Polly is a comprehensive resilience and transient fault-handling library for .NET. It allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.

Extension methods are provided to enable integration and use of Polly policies with configured `HttpClient` instances.

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet2)]

The preceding code, used within `ConfigureServices`, demonstrates using the `AddTransientHttpErrorPolicy` extension. The extension provides access to a `PolicyBuilder` object configured to handle errors representing a possible transient fault. Examples of errors include `HttpRequestException`, HTTP 5xx responses, and HTTP 408 responses.

Using the `PolicyBuilder`, a `RetryPolicy` is specified. Failed requests matching the preceding criteria are retried up to three times. The created policy is cached indefinitely per named client.

Additional extension methods exist which can be used to add Polly-based handlers.

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet3)]

In the preceding example, two handlers are added. The first uses the `AddPolicyHandler` extension, which allows you to provide an `IAsyncPolicy` directly. It's applied to HTTP requests made from the `HttpClient`.

The second handler is added using a different overload of `AddPolicyHandler`. The overload allows the request to be inspected before determining which policy to apply. If the outgoing request is a GET, a 10-second timeout is applied. For any other HTTP method, a 30-second timeout is used.

## HttpClient and lifetime management

Each time `CreateClient` is called on the `IHttpClientFactory`, a new instance of a `HttpClient` is returned. `IHttpClientFactory` creates, and caches, a single `HttpMessageHandler` per named client. The `IHttpClientFactory` may reuse the underlying `HttpMessageHandler` when appropriate. The `HttpMessageHandler` is responsible for creating and maintaining the underlying operating system connection. Reusing the `HttpMessageHandler` avoids creating too many connections on the host machine, which can lead to socket exhaustion.

## Logging

Clients created via `IHttpClientFactory` record log messages for all requests. You'll need to enable the appropriate information level in your logging configuration to see the default log messages. Additional logging, such as the logging of request headers, is only included at trace level. 

The log category used for each client includes the name of the client. A client named "MyNamedClient", for example, logs messages with a category of `System.Net.Http.HttpClient.MyNamedClient.LogicalHandler`. Messages with the suffix of LogicalHandler occur on the outside of request handler pipeline. On the request, messages are logged before any other handlers in the pipeline have processed it. On the response, messages are logged after any other pipeline handlers have received the response.

Logging also occurs on the inside of the request handler pipeline. In the case of the "MyNameClient" example, those messages are logged against the log category `System.Net.Http.HttpClient.MyNamedClient.ClientHandler`. For the request, this occurs after all other handlers have run and immediately before the request is sent out on the network. On the response, this logging includes the state of the response before it passes back through the handler pipeline.

Enabling logging on the outside and inside of the pipeline enables inspection of the changes made by the other pipeline handlers. This may include changes to request headers, for example, or even to the response status code.

By including the name of the client in the log category, it enables log filtering to be applied for specific named clients where necessary.
