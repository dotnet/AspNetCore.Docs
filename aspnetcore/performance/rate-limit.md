---
title: Rate limiting middleware in ASP.NET Core
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-7.0'
description: Learn how limit requests in ASP.NET Core apps
ms.custom: mvc
ms.date: 03/05/2025
uid: performance/rate-limit
---

# Rate limiting middleware in ASP.NET Core

By [Arvin Kahbazi](https://github.com/Kahbazi), [Maarten Balliauw](https://github.com/maartenba), and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-7.0"

The `Microsoft.AspNetCore.RateLimiting` middleware provides rate limiting middleware. Apps configure rate limiting policies and then attach the policies to endpoints. Apps using rate limiting should be carefully load tested and reviewed before deploying. See [Testing endpoints with rate limiting](#test7) in this article for more information.

For an introduction to rate limiting, see [Rate limiting middleware](https://blog.maartenballiauw.be/post/2022/09/26/aspnet-core-rate-limiting-middleware.html).

## Why use rate limiting

Rate limiting can be used for managing the flow of incoming requests to an app. Key reasons to implement rate limiting:

- **Preventing Abuse**: Rate limiting helps protect an app from abuse by limiting the number of requests a user or client can make in a given time period. This is particularly important for public APIs.
- **Ensuring Fair Usage**: By setting limits, all users have fair access to resources, preventing  users from monopolizing the system.
- **Protecting Resources**: Rate limiting helps prevent server overload by controlling the number of requests that can be processed, thus protecting the backend resources from being overwhelmed.
- **Enhancing Security**: It can mitigate the risk of Denial of Service (DoS) attacks by limiting the rate at which requests are processed, making it harder for attackers to flood a system.
- **Improving Performance**: By controlling the rate of incoming requests, optimal performance and responsiveness of an app can be maintained, ensuring a better user experience.
- **Cost Management**: For services that incur costs based on usage, rate limiting can help manage and predict expenses by controlling the volume of requests processed.

Implementing rate limiting in an ASP.NET Core app can help maintain stability, security, and performance, ensuring a reliable and efficient service for all users.

## Preventing DDoS Attacks

While rate limiting can help mitigate the risk of Denial of Service (DoS) attacks by limiting the rate at which requests are processed, it's not a comprehensive solution for Distributed Denial of Service (DDoS) attacks. DDoS attacks involve multiple systems overwhelming an app with a flood of requests, making it difficult to handle with rate limiting alone.

For robust DDoS protection, consider using a commercial DDoS protection service. These services offer advanced features such as:

- **Traffic Analysis**: Continuous monitoring and analysis of incoming traffic to detect and mitigate DDoS attacks in real-time.
- **Scalability**: The ability to handle large-scale attacks by distributing traffic across multiple servers and data centers.
- **Automated Mitigation**: Automated response mechanisms to quickly block malicious traffic without manual intervention.
- **Global Network**: A global network of servers to absorb and mitigate attacks closer to the source.
- **Constant Updates**: Commercial services continuously track and update their protection mechanisms to adapt to new and evolving threats.

When using a cloud hosting service, DDoS protection is usually available as part of the hosting solution, such as [Azure Web Application Firewall](https://azure.microsoft.com/products/web-application-firewall/), [AWS Shield](https://aws.amazon.com/shield/) or [Google Cloud Armor](https://cloud.google.com/armor/docs). Dedicated protections are available as Web Application Firewalls (WAF) or as part of a CDN solution such as [Cloudflare](https://www.cloudflare.com/ddos/) or [Akamai Kona Site Defender](https://www.akamai.com/us/en/products/security/kona-site-defender.jsp)

Implementing a commercial DDoS protection service in conjunction with rate limiting can provide a comprehensive defense strategy, ensuring the stability, security, and performance of an app.

## Use Rate Limiting Middleware

The following steps show how to use the rate limiting middleware in an ASP.NET Core app:

1. Install the `Microsoft.AspNetCore.RateLimiting` package.:

  Add the `Microsoft.AspNetCore.RateLimiting` package to the project, via the NuGet Package Manager or   the following command:
  
  ```sh
     dotnet add package Microsoft.AspNetCore.RateLimiting
  ```

2. Configure rate limiting services.

  In the `Program.cs` file, configure the rate limiting services by adding the appropriate rate limiting  policies. Policies can either be defined as global or named polices. The following example permits 10 requests per minute:
  
  ``` csharp
  builder.Services.AddRateLimiter(options =>
  {
      options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
          RateLimitPartition.GetFixedWindowLimiter(
              partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.  ToString(),
              factory: partition => new FixedWindowRateLimiterOptions
              {
                  AutoReplenishment = true,
                  PermitLimit = 10,
                  QueueLimit = 0,
                  Window = TimeSpan.FromMinutes(1)
              }));
  });
  ```
  
  Named polices need to be explicitly applied to the pages or endpoints. The following example adds a fixed window limiter:
  
  ``` csharp
  var builder = WebApplication.CreateBuilder(args);
  
  builder.Services.AddRateLimiter(options =>
  {
      options.AddFixedWindowLimiter("fixed", opt =>
      {
          opt.PermitLimit = 4;
          opt.Window = TimeSpan.FromSeconds(12);
          opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
          opt.QueueLimit = 2;
      });
  });
  
  var app = builder.Build();
  ```
  
  The global limiter applies to all endpoints automatically when it's configured via [options.  GlobalLimiter](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptions.globallimiter), and no endpoint-specific policy is specified.

3. Enable rate limiting middleware

   In the `Program.cs` file, enable the rate limiting middleware by calling [UseRateLimiter](/dotnet/api/microsoft.aspnetcore.builder.ratelimiterapplicationbuilderextensions.useratelimiter):
  
  ``` csharp
  app.UseRouting();
  
  app.UseRateLimiter();
  
  app.UseEndpoints(endpoints =>
  {
      endpoints.MapControllers();
  });
  
  app.Run();
  ```

### Apply rate limiting policies to endpoints or pages

#### Apply rate limiting to WebAPI Endpoints

Apply a named policy to the endpoint or group, for example:

``` csharp

app.MapGet("/api/resource", () => "This endpoint is rate limited")
   .RequireRateLimiting("fixed"); // Apply specific policy to an endpoint

```

#### Apply rate limiting to MVC Controllers

 Apply the configured rate limiting policies to specific endpoints or globally. For example, to apply the "fixed" policy to all controller endpoints:

``` csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireRateLimiting("fixed");
});

```

#### Apply rate limiting to server-side Blazor apps

To set rate limiting for all of the app's routable Razor components, specify <xref:Microsoft.AspNetCore.Builder.RateLimiterEndpointConventionBuilderExtensions.RequireRateLimiting%2A> with the rate limiting policy name on the <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> call in the `Program` file. In the following example, the rate limiting policy named "`policy`" is applied:

``` csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .RequireRateLimiting("policy");
```

To set a policy for a single routable Razor component or a folder of components via an `_Imports.razor` file, the [`[EnableRateLimiting]` attribute](xref:Microsoft.AspNetCore.RateLimiting.EnableRateLimitingAttribute) is applied with the policy name. In the following example, the rate limiting policy named "`override`" is applied. The policy replaces any policies currently applied to the endpoint. The global limiter still runs on the endpoint with this attribute applied.

``` blazor
@page "/counter"
@using Microsoft.AspNetCore.RateLimiting
@attribute [EnableRateLimiting("override")]

<h1>Counter</h1>
```

The [`DisableRateLimiting` attribute](xref:Microsoft.AspNetCore.RateLimiting.DisableRateLimitingAttribute) is used to disable rate limiting for a routable component or a folder of components via an `_Imports.razor` file.

The [`[EnableRateLimiting]` attribute](xref:Microsoft.AspNetCore.RateLimiting.EnableRateLimitingAttribute) is only applied to a routable component or a folder of components via an `_Imports.razor` file if <xref:Microsoft.AspNetCore.Builder.RateLimiterEndpointConventionBuilderExtensions.RequireRateLimiting%2A> is ***not*** called on <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A>.

## Rate limiter algorithms

The [`RateLimiterOptionsExtensions`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions) class provides the following extension methods for rate limiting:

* [Fixed window](#fixed)
* [Sliding window](#slide)
* [Token bucket](#token)
* [Concurrency](#concur)

The fixed, sliding, and token limiters all limit the maximum number of requests in a time period. The concurrency limiter limits only the number of concurrent requests and doesn't cap the number of requests in a time period. The cost of an endpoint should be considered when selecting a limiter. The cost of an endpoint includes the resources used, for example, time, data access, CPU, and I/O.

<a name="fixed"></a>

### Fixed window limiter

The [`AddFixedWindowLimiter`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions.addfixedwindowlimiter#microsoft-aspnetcore-ratelimiting-ratelimiteroptionsextensions-addfixedwindowlimiter(microsoft-aspnetcore-ratelimiting-ratelimiteroptions-system-string-system-threading-ratelimiting-fixedwindowratelimiteroptions)) method uses a fixed time window to limit requests. When the time window expires, a new time window starts and the request limit is reset.

Consider the following code:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_fixed":::

The preceding code:

* Calls <xref:Microsoft.AspNetCore.Builder.RateLimiterServiceCollectionExtensions.AddRateLimiter%2A> to add a rate limiting service to the service collection.
* Calls `AddFixedWindowLimiter` to create a fixed window limiter with a policy name of `"fixed"` and sets:
* <xref:System.Threading.RateLimiting.FixedWindowRateLimiterOptions.PermitLimit> to 4 and the time <xref:System.Threading.RateLimiting.FixedWindowRateLimiterOptions.Window> to 12. A maximum of 4 requests per each 12-second window are allowed.
* <xref:System.Threading.RateLimiting.FixedWindowRateLimiterOptions.QueueProcessingOrder> to <xref:System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst>.
* <xref:System.Threading.RateLimiting.FixedWindowRateLimiterOptions.QueueLimit> to 2 (set this to 0 to disable the queueing mechanism).
* Calls [UseRateLimiter](/dotnet/api/microsoft.aspnetcore.builder.ratelimiterapplicationbuilderextensions.useratelimiter) to enable rate limiting.

Apps should use [Configuration](xref:fundamentals/configuration/index) to set limiter options. The following code updates the preceding code using [`MyRateLimitOptions`](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/fundamentals/middleware/rate-limit/WebRateLimitAuth/Models/MyRateLimitOptions.cs) for configuration:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_fixed2":::

<xref:Microsoft.AspNetCore.Builder.RateLimiterApplicationBuilderExtensions.UseRateLimiter%2A> must be called after `UseRouting` when rate limiting endpoint specific APIs are used. For example, if the [`[EnableRateLimiting]`](xref:Microsoft.AspNetCore.RateLimiting.EnableRateLimitingAttribute) attribute is used, `UseRateLimiter` must be called after `UseRouting`. When calling only global limiters, `UseRateLimiter` can be called before `UseRouting`.

<a name="slide"></a>

### Sliding window limiter

A sliding window algorithm:

* Is similar to the fixed window limiter but adds segments per window. The window slides one segment each segment interval. The segment interval is (window time)/(segments per window).
* Limits the requests for a window to `permitLimit` requests.
* Each time window is divided in `n` segments per window.
* Requests taken from the expired time segment one window back (`n` segments prior to the current segment) are added to the current segment. We refer to the most expired time segment one window back as the expired segment.

Consider the following table that shows a sliding window limiter with a 30-second window, three segments per window, and a limit of 100 requests:

* The top row and first column shows the time segment.
* The second row shows the remaining requests available. The remaining requests are calculated as the available requests minus the processed requests plus the recycled requests.
* Requests at each time moves along the diagonal blue line.
* From time 30 on, the request taken from the expired time segment are added back to the request limit, as shown in the red lines.

![Table showing requests, limits, and recycled slots](~/performance/rate-limit/_static/rate.png)

<!-- 
| Time | 0  | 10  | 20 | 30 | 40 | 50 | 60 |
| ---- | -- | --  | -- | -- | -- | -- | -- |
| Available | 100-20+0=80 | 80-30+0=50  | 50-40+0=10 | 10-30+20=0 |0+30-10=20 | 20-10+40=50 | 50-35+30=45 |
|  0    | -20            |                                  |  |  |  |  | |
|  10   |               | -30                             |  |  |  |  | |
|  20   |               |            | -40                    |  |  |  | |
|  30   | **[+20]**     |            |         | -30        |  |  | |
|  40   |          |**[+30]**|       |                 | -10   |  | |
|  50   |          |           | **[+40]**  |            |               | -10  | |
|  60   |          |           |            |  **[+30]**  |    |  | -35|
-->

The following table shows the data in the previous graph in a different format. The **Available** column shows the requests available from the previous segment (The **Carry over** from the previous row). The first row shows 100 available requests because there's no previous segment.

| Time | Available | Taken | Recycled from expired | Carry over |
| :--: | :-------: | :---: | :-------------------: | :--------: |
| 0    | 100       | 20    | 0                     | 80         |
| 10   | 80        | 30    | 0                     | 50         |
| 20   | 50        | 40    | 0                     | 10         |
| 30   | 10        | 30    | 20                    | 0          |
| 40   | 0         | 10    | 30                    | 20         |
| 50   | 20        | 10    | 40                    | 50         |
| 60   | 50        | 35    | 30                    | 45         |

The following code uses the sliding window rate limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_slide":::

<a name="token"></a>

### Token bucket limiter

The token bucket limiter is similar to the sliding window limiter, but rather than adding back the requests taken from the expired segment, a fixed number of tokens are added each replenishment period. The tokens added each segment can't increase the available tokens to a number higher than the token bucket limit. The following table shows a token bucket limiter with a limit of 100 tokens and a 10-second replenishment period.

| Time | Available | Taken | Added | Carry over |
| :--: | :-------: | :---: | :---: | :--------: |
| 0    | 100       | 20    | 0     | 80         |
| 10   | 80        | 10    | 20    | 90         |
| 20   | 90        | 5     | 15    | 100        |
| 30   | 100       | 30    | 20    | 90         |
| 40   | 90        | 6     | 16    | 100        |
| 50   | 100       | 40    | 20    | 80         |
| 60   | 80        | 50    | 20    | 50         |

The following code uses the token bucket limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_token":::

When <xref:System.Threading.RateLimiting.TokenBucketRateLimiterOptions.AutoReplenishment%2A> is set to `true`, an internal timer replenishes the tokens every <xref:System.Threading.RateLimiting.TokenBucketRateLimiter.ReplenishmentPeriod%2A>; when set to `false`, the app must call <xref:System.Threading.RateLimiting.TokenBucketRateLimiter.TryReplenish%2A> on the limiter.

<a name="concur"></a>

### Concurrency limiter

The concurrency limiter limits the number of concurrent requests. Each request reduces the concurrency limit by one. When a request completes, the limit is increased by one. Unlike the other requests limiters that limit the total number of requests for a specified period, the concurrency limiter limits only the number of concurrent requests and doesn't cap the number of requests in a time period.

The following code uses the concurrency limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_concur":::

## Rate Limiting Partitions

Rate limiting partitions divide the traffic into separate "buckets" that each get their own rate limit counters. This allows for more granular control than a single global counter. The partition "buckets" are defined by different keys (like user ID, IP address, or API key).

### Benefits of Partitioning
- **Fairness**: One user can't consume the entire rate limit for everyone
- **Granularity**: Different limits for different users/resources
- **Security**: Better protection against targeted abuse
- **Tiered Service**: Support for service tiers with different limits

Partitioned rate limiting gives you fine-grained control over how you manage API traffic while ensuring fair resource allocation.

### By IP Address

``` csharp
options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
        factory: _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 50,
            Window = TimeSpan.FromMinutes(1)
        }));
```

### By User Identity
``` csharp
options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: httpContext.User.Identity?.Name ?? "anonymous",
        factory: _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 100,
            Window = TimeSpan.FromMinutes(1)
        }));
```

### By API Key
``` csharp
options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
{
    string apiKey = httpContext.Request.Headers["X-API-Key"].ToString() ?? "no-key";

    // Different limits based on key tier
    return apiKey switch
    {
        "premium-key" => RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: apiKey,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 1000,
                Window = TimeSpan.FromMinutes(1)
            }),
        
        _ => RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: apiKey,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1)
            }),
    };
});
```

### By Endpoint Path

``` csharp
options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
{
    string path = httpContext.Request.Path.ToString();

    // Different limits for different paths
    if (path.StartsWith("/api/public"))
    {
        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: $"{httpContext.Connection.RemoteIpAddress}-public",
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 30,
                Window = TimeSpan.FromSeconds(10)
            });
    }

    return RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
        factory: _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 100,
            Window = TimeSpan.FromMinutes(1)
        });
});
```

### Create chained limiters

The <xref:System.Threading.RateLimiting.PartitionedRateLimiter.CreateChained%2A> API allows passing in multiple <xref:System.Threading.RateLimiting.PartitionedRateLimiter> which are combined into one `PartitionedRateLimiter`. The combined limiter runs all the input limiters in sequence.

The following code uses `CreateChained`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Program.cs" id="snippet_3" highlight="19,20,33":::

For more information, see the [CreateChained source code](https://github.com/dotnet/runtime/blob/79874806d246670ee5fe76e73ce566578fe675c0/src/libraries/System.Threading.RateLimiting/src/System/Threading/RateLimiting/PartitionedRateLimiter.cs#L52-L64)

## Chosing what happens when a request is rate limited

For simple cases, you can just set the status code:

``` csharp
builder.Services.AddRateLimiter(options =>
{
    // Set a custom status code for rejections
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    // Rate limiter configuration...
});
```

The most common approach is to register an OnRejected callback when configuring rate limiting:

``` csharp
builder.Services.AddRateLimiter(options =>
{
    // Rate limiter configuration...
    
    options.OnRejected = async (context, cancellationToken) =>
    {
        // Custom rejection handling logic
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        context.HttpContext.Response.Headers["Retry-After"] = "60";

        await context.HttpContext.Response.WriteAsync("Rate limit exceeded. Please try again later.", cancellationToken);

        // Optional logging
        logger.LogWarning("Rate limit exceeded for IP: {IpAddress}",
            context.HttpContext.Connection.RemoteIpAddress);
    };
});
```
Another option is to queue the request:

### Request Queuing

With queuing enabled, when a request exceeds the rate limit, it's placed in a queue where the request waits until a permit becomes available or until a timeout occurs. Requests are processed according to a configurable queue order.

``` csharp
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("api", options =>
    {
        options.PermitLimit = 10;           // Allow 10 requests
        options.Window = TimeSpan.FromSeconds(10);  // Per 10-second window
        options.QueueLimit = 5;             // Queue up to 5 additional requests
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; // Process oldest requests first
        options.AutoReplenishment = true; // Default: automatically replenish permits
    });
});
```

## `EnableRateLimiting` and `DisableRateLimiting` attributes

The [`[EnableRateLimiting]`](xref:Microsoft.AspNetCore.RateLimiting.EnableRateLimitingAttribute) and [`[DisableRateLimiting]`](xref:Microsoft.AspNetCore.RateLimiting.DisableRateLimitingAttribute) attributes can be applied to a Controller, action method, or Razor Page. For Razor Pages, the attribute must be applied to the Razor Page and not the page handlers. For example, `[EnableRateLimiting]` can't be applied to `OnGet`, `OnPost`, or any other page handler.

The `[DisableRateLimiting]` attribute ***disables*** rate limiting to the Controller, action method, or Razor Page regardless of named rate limiters or global limiters applied. For example, consider the following code which calls <xref:Microsoft.AspNetCore.Builder.RateLimiterEndpointConventionBuilderExtensions.RequireRateLimiting%2A> to apply the `fixedPolicy` rate limiting to all controller endpoints:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Program.cs" id="snippet_1" highlight="51":::

In the following code, `[DisableRateLimiting]` disables rate limiting and overrides `[EnableRateLimiting("fixed")]` applied to the `Home2Controller` and `app.MapDefaultControllerRoute().RequireRateLimiting(fixedPolicy)` called in `Program.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Controllers/Home2Controller.cs" id="snippet_1" highlight="1,16,22":::

In the preceding code, the `[EnableRateLimiting("sliding")]` is ***not*** applied to the `Privacy` action method because `Program.cs` called `app.MapDefaultControllerRoute().RequireRateLimiting(fixedPolicy)`. <!-- https://github.com/dotnet/AspNetCore.Docs/pull/27294#discussion_r998484867 -->

Consider the following code which doesn't call `RequireRateLimiting` on `MapRazorPages` or `MapDefaultControllerRoute`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Program.cs" id="snippet_2" highlight="51-52":::

Consider the following controller:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Controllers/Home2Controller.cs" id="snippet_1" highlight="1,16,22":::

In the preceding controller:

* The `"fixed"` policy rate limiter is applied to all action methods that don't have `EnableRateLimiting` and `DisableRateLimiting` attributes.
* The `"sliding"` policy rate limiter is applied to the `Privacy` action.
* Rate limiting is disabled on the `NoLimit` action method.

## Rate limiting metrics

The rate limiting middleware provides built-in metrics and monitoring capabilities to help understand how rate limits are affecting app performance and user experience. The following metrics are provided for rate limiting

| Metric  | Description | Type |
| --- | --- | --- |
| `Microsoft.AspNetCore.RateLimiting.RequestsPerformed` | Counts successful (allowed) requests | Counter|
| `Microsoft.AspNetCore.RateLimiting.RequestsRejected` | Counts rejected requests | Counter |
| `Microsoft.AspNetCore.RateLimiting.CurrentLeases` | Current number of active leases | Gauge |
| `Microsoft.AspNetCore.RateLimiting.CurrentQueuedRequests` | Current number of queued requests | Gauge |
| `Microsoft.AspNetCore.RateLimiting.QueueTimeMs` | Time spent in queue | Histogram |

<a name="test7"></a>

## Testing endpoints with rate limiting

Before deploying an app using rate limiting to production, stress test the app to validate the rate limiters and options used. For example, create a [JMeter script](https://jmeter.apache.org/usermanual/jmeter_proxy_step_by_step.html) with a tool like [BlazeMeter](https://www.blazemeter.com/blog/jmeter-tutorial) or [Apache JMeter HTTP(S) Test Script Recorder](https://jmeter.apache.org/usermanual/jmeter_proxy_step_by_step.html) and load the script to [Azure Load Testing](/azure/load-testing/overview-what-is-azure-load-testing).

Creating partitions with user input makes the app vulnerable to [Denial of Service](https://www.cisa.gov/uscert/ncas/tips/ST04-015) (DoS) Attacks. For example, creating partitions on client IP addresses makes the app vulnerable to Denial of Service Attacks that employ IP Source Address Spoofing. For more information, see [BCP 38 RFC 2827 Network Ingress Filtering: Defeating Denial of Service Attacks that employ IP Source Address Spoofing](https://www.rfc-editor.org/info/bcp38).

## Additional resources

* [Rate limiting middleware](https://blog.maartenballiauw.be/post/2022/09/26/aspnet-core-rate-limiting-middleware.html) by Maarten Balliauw provides an excellent introduction and overview to rate limiting.
* [Rate limit an HTTP handler in .NET](/dotnet/core/extensions/http-ratelimiter)

:::moniker-end
