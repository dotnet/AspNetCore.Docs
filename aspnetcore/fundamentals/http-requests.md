---
title: Making HTTP Requests
author: stevejgordon
description: Learn about using the HttpClientFactory features to 
manager: wpickett
ms.author: riande
ms.date: 02/15/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: fundamentals/http-requests
---
# Making HTTP Requests

By [Glenn Condron](https://github.com/glennc), [Ryan Nowak](https://github.com/rynowak) and [Steve Gordon](https://github.com/stevejgordon) 

A HttpClientFactory can be registered and used to configure and consume HttpClients in your application. It provides several benefits:

1. Provides a central location for naming and configuring logical HttpClients. For example, you may configure a “github” client that is pre-configured to access github and a default client for other purposes.
2. Codifies the concept of outgoing middleware via delegating handlers in HttpClient and implementing Polly based middleware to take advantage of that. HttpClient already has the concept of delegating handlers that could be linked together for outgoing HTTP requests. The factory will make registering of these per named client more intuitive as well as implement a Polly handler that allows Polly policies to be used for Retry, CircuitBreakers, etc.
3. Manage the lifetime of HttpClientMessageHandlers to avoid common DNS problems that can be hit when managing HttpClient lifetimes yourself.

## Consumption Patterns

There are several ways that HttpClientFactory can be used in your application. None of them are strictly superior to another, it really depends on your application and the constraints you are working under.

## Basic Usage

HttpClientFactory can be used directly in code to access HttpClient instances. First the services must be registered with the ServiceProvider.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient();
    services.AddMvc();
}
```

Once registered, you can accept an `IHttpClientFactory` in your constructor which can then be used to create a `HttpClient`.

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
        var client = _httpClientFactory.CreateClient();
        var result = client.GetStringAsync("http://myurl/");
        return View();
    }
}
```

Using HttpClientFactory like this is a good way to start refactoring an existing application, as it has no impact on the way you use HttpClient. In places where you create HttpClients, replace those with a call to `CreateClient()`.

## Named clients

 If you have multiple distinct uses of HttpClient, each with different configurations, then you may want to use **named clients**. The common configuration for the use of that named HttpClient can be specified during registration.

```csharp
 public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient("github", c =>
    {
        c.BaseAddress = new Uri("https://api.github.com/");

        c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json"); // Github API versioning
        c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample"); // Github requires a user-agent
    });
    services.AddHttpClient();
}
```

Here `AddHttpClient` has been called twice; once with the name 'github' and once without. The github specific client has some default configuration applied, namely the base address and two headers required to work with the GitHub API.

The configuration function here will get called every time CreateClient is called, as a new instance of HttpClient is created each time.

To consume a named client in your code you can pass the name of the client to `CreateClient`.

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

In the above code the gitHubClient will have the BaseAddress and headers set whereas the defaultClient does not. This provides you the with the ability to have different configurations for different purposes. This may mean different configurations per endpoint/API for example.

HttpClientFactory will create, and cache, a single HttpMessageHandler per named client. Meaning that if you were to use netstat or some other tool to view connections on the host machine you would generally see a single TCP connection for each named client, rather than one per instance when you new-up and dispose of a HttpClient manually.

## Typed clients

Typed Clients give you the same capabilities as named clients without the need for using strings as keys. This provides intellisense and compiler help when consuming clients. They also provide a single location to configure and interact with a particular HttpClient. For example, a single typed client might be used for a single backend endpoint and encapsulate all logic which deals with that endpoint. 

A typed client is expected to accept a HttpClient via it's constructor. 

```csharp
public class GitHubService
{
    public HttpClient Client { get; private set; }

    public GitHubService(HttpClient client)
    {
        client.BaseAddress = new Uri("https://api.github.com/");
        client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json"); // Github API versioning
        client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample"); // Github requires a user-agent

        Client = client;
    }
}
```

To register a typed client the generic AddHttpClient method can be used, specifying our typed client class. 

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient<GitHubService>();
    services.AddMvc();
}
```

The typed client is registered as transient with the DI framework.

The typed client can then be injected and consumed directly. 

```csharp
public class IndexModel : PageModel
{
    private GitHubService _gitHubService;

    public IndexModel(GitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    public async Task OnGet()
    {
        var result = await _gitHubService.Client.GetStringAsync("/orgs/octokit/repos");
    }
}

public class MyController : Controller
{
    private GitHubService _gitHubService;

    public MyController(GitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    public IActionResult Index()
    {
        var result = await _gitHubService.Client.GetStringAsync("/orgs/octokit/repos");
        return Ok(result);
    }
}
```

In this example we only moved configuration into the type, but we could also have methods with behaviour and not actually expose the HttpClient if we want all access to go through this type. 

If you prefer, the configuration for a typed client can be specified during registration, rather than in the constructor for the typed client.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient<GitHubService>(c =>
    {
        c.BaseAddress = new Uri("https://api.github.com/");

        c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json"); // Github API versioning
        c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample"); // Github requires a user-agent
    });
    services.AddMvc();
}
```

If we want to entirely encapsulate the HttpClient in our typed client, rather than exposing it as a property we can define our own methods which control the client

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

In this example the HttpClient is stored as a private field and all access to make external calls goes through the GetValues method.

## Generated clients

TODO - Refit?

## Outgoing request middleware

TODO

## Handling errors with Polly

TODO

## DNS and handler rotation

Each time you call CreateClient you get a new instance of HttpClient, but the factory will reuse the underlying HttpMessageHandler when appropriate. The HttpMessageHandler is responsible for creating and maintainging the underlying Operating System connection. Reusing the HttpMessageHandler will save you from creating many connections on your host machine.


