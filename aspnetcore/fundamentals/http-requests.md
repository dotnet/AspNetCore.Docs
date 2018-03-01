---
title: Initiate HTTP requests
author: stevejgordon
description: Learn about using the IHttpClientFactory to managed logic HttpClient instances.
manager: wpickett
ms.author: 
ms.custom: mvc
ms.date: 02/21/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: fundamentals/http-requests
---
# Initiate HTTP requests

By [Glenn Condron](https://github.com/glennc), [Ryan Nowak](https://github.com/rynowak), and [Steve Gordon](https://github.com/stevejgordon) 

A [IHttpClientFactory](/dotnet/api/microsoft.extensions.http.ihttpclientfactory) can be registered and used to configure and create [HttpClient](/dotnet/api/system.net.http.httpclient) instances in an app. It offers the following benefits:

- Provides a central location for naming and configuring logical `HttpClient` instances. For example, a "github" client can be registered and pre-configured to access GitHub. A default client can be registered for other purposes.
- Codifies the concept of outgoing middleware via delegating handlers in `HttpClient` and provides extensions for Polly-based middleware to take advantage of that.
- Manages the pooling and lifetime of underlying `HttpClientMessageHandler` instances to avoid common DNS problems that occur when manually managing `HttpClient` lifetimes.

## Consumption patterns

There are several ways `IHttpClientFactory` can be used in an app. None of them are strictly superior to another and it depends on the app's constraints.

## Basic usage

The `IHttpClientFactory` can be used directly in code to access `HttpClient` instances. The service must first be registered with the ServiceProvider:

[!code-csharp[Main](http-requests/samples/Startup.cs?name=snippet1&highlight=4)]

Once registered, code can accept an `IHttpClientFactory` anywhere services can be injected with [dependency injection](xref:fundamentals/dependency-injection) (DI). The `IHttpClientFactory` can be used to create a `HttpClient` instance:

[!code-csharp[Main](http-requests/samples/Pages/BasicUsage.cshtml?name=snippet1&highlight=7-10,18)]

Using `IHttpClientFactory` in this fashion is a great way to begin refactoring an existing app. It has no impact on the way `HttpClient` is used. In places where `HttpClient` instances are currently created, replace those with a call to `CreateClient`.

## Named clients

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

To consume a named client, a string parameter can be passed to `CreateClient`, specifying the name of the client to be created:

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

In the preceding code, the `gitHubClient` variable has the `BaseAddress` and `DefaultRequestHeaders` set. The `defaultClient` variable doesn't. This provides the ability to have different configurations for different purposes. This could mean different configurations per endpoint/API, for example.

## Typed clients

Typed clients provide the same capabilities as named clients without the need to use strings as keys. This provides IntelliSense and compiler help when consuming clients. They provide a single location to configure and interact with a particular `HttpClient`. For example, a single typed client might be used for a single backend endpoint and encapsulate all logic dealing with that endpoint. Another advantage is that they work with DI and can be injected where required in your app.

A typed client accepts a `HttpClient` parameter in its constructor:

```csharp
public class GitHubService
{
    public HttpClient Client { get; private set; }

    public GitHubService(HttpClient client)
    {
        client.BaseAddress = new Uri("https://api.github.com/");
        client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json"); // GitHub API versioning
        client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");   // GitHub requires a user-agent

        Client = client;
    }
}
```

In the preceding code, only the configuration is moved into the typed client. The `HttpClient` object is exposed as a public property. It's possible to define API-specific methods which expose `HttpClient` functionality.

To register a typed client, the generic `AddHttpClient` extension method can be used, specifying the typed client class:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient<GitHubService>();
    services.AddMvc();
}
```

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

If preferred, the configuration for a typed client can be specified during registration, rather than in the typed client's constructor:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient<GitHubService>(c =>
    {
        c.BaseAddress = new Uri("https://api.github.com/");

        c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json"); // GitHub API versioning
        c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample"); // GitHub requires a user-agent
    });
    services.AddMvc();
}
```

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

## Generated clients

`IHttpClientFactory` can be used in combination with other third-party libraries such as [Refit](https://github.com/paulcbetts/refit). Refit is a REST library for .NET which turns REST APIs into live interfaces. An implementation of the interface is generated dynamically by the `RestService`, using `HttpClient` to make the external HTTP calls.

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

`HttpClient` already has the concept of delegating handlers that can be linked together for outgoing HTTP requests. The `IHttpClientFactory` makes registration of per-named clients more intuitive. It supports registration and chaining of multiple handlers together to build an outgoing request middleware pipeline. Each of these handlers is able to perform work before and after the outgoing request. This pattern is similar to the inbound middleware pipeline in ASP.NET Core. This provides a mechanism to manage cross-cutting concerns around HTTP requests, including caching, error handling, serialization, and logging.

To create a handler, a class can be added, deriving from `DelegatingHandler`. The `SendAsync` method can then be overridden to execute code before passing the request to the next handler in the pipeline:

```csharp
private class RetryHandler : DelegatingHandler
{
    public int RetryCount { get; set; } = 5;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        for (var i = 0; i < RetryCount; i++)
        {
            try
            {
                return base.SendAsync(request, cancellationToken);
            }
            catch (HttpRequestException) when (i == RetryCount - 1)
            {
                throw;
            }
            catch (HttpRequestException)
            {
                // Retry
                Task.Delay(TimeSpan.FromMilliseconds(50));
            }
        }

        // Unreachable.
        throw null;
    }
}
```

The preceding code defines a basic retry handler which retries up to five times if a `HttpRequestException` is caught.

During registration, one or more handlers can be added to the configuration for a `HttpClient` via extension methods on the `HttpClientBuilder`.

```csharp
public static void Configure(IServiceCollection services)
{
    services.AddTransient<RetryHandler>();

    services.AddHttpClient("example", c =>
    {
        c.BaseAddress = new Uri("https://localhost:5000/");
    })
    .AddHttpMessageHandler<RetryHandler>(); // Retry requests to GitHub using the retry handler
}
```

In the preceding code, the `RetryHandler` is registered as a transient service with DI. Once registered, `AddHttpMessageHandler` can be called, passing in the type for the handler.

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

## Handling errors with Polly

_NOTE: This is a WIP since the Polly Extensions API is still currently under design._

The preceding example demonstrated building a simple retry handler manually. A more robust and feature-rich approach is to leverage a popular third-party library called [Polly](https://github.com/App-vNext/Polly).

Polly is a comprehensive resilience and transient-fault-handling library for .NET which allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.

Extension methods are provided for `IHttpClientFactory`, which enable easy integration and use of Polly policies with configured `HttpClient` instances. Rather than manually defining a handler, extension methods can be used which accept a Polly policy. This policy is used when executing HTTP requests.

```csharp
public static void Configure(IServiceCollection services)
{
    services.AddTransient<OuterHandler>();
    services.AddTransient<InnerHandler>();

    services.AddHttpClient("example", c =>
    {
        c.BaseAddress = new Uri("https://localhost:5000/");
    })

    // Build a totally custom policy using any criteria
    .AddPolicyHandler(Policy.Handle<HttpRequestException>().RetryAsync())

    // Build a policy that handles exceptions (connection failures)
    .AddExceptionPolicyHandler(p => p.RetryAsync())

    // Build a policy that handles exceptions and 500s from the remote server
    .AddServerErrorPolicyHandler(p => p.RetryAsync())

    // Build a policy that handles exceptions, 400s, and 500s from the remote server
    .AddBadRequestPolicyHandler(p => p.RetryAsync());
}
```

## HttpClient and lifetime management

Each time `CreateClient` is called on the `IHttpClientFactory`, a new instance of a `HttpClient` is returned. `IHttpClientFactory` creates, and caches, a single `HttpMessageHandler` per named client. The `IHttpClientFactory` may reuse the underlying `HttpMessageHandler` when appropriate. The `HttpMessageHandler` is responsible for creating and maintaining the underlying operating system connection. Reusing the `HttpMessageHandler` avoids creating too many connections on the host machine, which can lead to socket exhaustion.

## Logging

TODO