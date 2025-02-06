# Rate Limiting

## Introduction
The reverse proxy can be used to rate-limit requests before they are proxied to the destination servers. This can reduce load on the destination servers, add a layer of protection, and ensure consistent policies are implemented across your applications.

> This feature is only available when using .NET 7.0 or later

## Defaults

No rate limiting is performed on requests unless enabled in the route or application configuration. However, the Rate Limiting middleware (`app.UseRateLimiter()`) can apply a default limiter applied to all routes, and this doesn't require any opt-in from the config.

Example:
```c#
services.AddRateLimiter(options => options.GlobalLimiter = globalLimiter);
```

## Configuration
Rate Limiter policies can be specified per route via [RouteConfig.RateLimiterPolicy](xref:Yarp.ReverseProxy.Configuration.RouteConfig) and can be bound from the `Routes` sections of the config file. As with other route properties, this can be modified and reloaded without restarting the proxy. Policy names are case insensitive.

Example:
```JSON
{
  "ReverseProxy": {
    "Routes": {
      "route1" : {
        "ClusterId": "cluster1",
        "RateLimiterPolicy": "customPolicy",
        "Match": {
          "Hosts": [ "localhost" ]
        }
      }
    },
    "Clusters": {
      "cluster1": {
        "Destinations": {
          "cluster1/destination1": {
            "Address": "https://localhost:10001/"
          }
        }
      }
    }
  }
}
```

[RateLimiter policies](https://learn.microsoft.com/aspnet/core/performance/rate-limit) are an ASP.NET Core concept that the proxy utilizes. The proxy provides the above configuration to specify a policy per route and the rest is handled by existing ASP.NET Core rate limiting middleware.

RateLimiter policies can be configured in services as follows:
```c#
services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("customPolicy", opt =>
    {
        opt.PermitLimit = 4;
        opt.Window = TimeSpan.FromSeconds(12);
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 2;
    });
});
```

Then add the RateLimiter middleware.

```c#
app.UseRateLimiter();

app.MapReverseProxy();
```

See the [Rate Limiting](https://learn.microsoft.com/aspnet/core/performance/rate-limit) docs for setting up your preferred kind of rate limiting.

### Disable Rate Limiting

Specifying the value `disable` in a route's `RateLimiterPolicy` parameter means the rate limiter middleware will not apply any policies to this route, even the default policy.
