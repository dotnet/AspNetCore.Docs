# Cross-Origin Requests (CORS)

## Introduction

The reverse proxy can handle cross-origin requests before they are proxied to the destination servers. This can reduce load on the destination servers and ensure consistent policies are implemented across your applications.

## Defaults
The requests won't be automatically matched for cors preflight requests unless enabled in the route or application configuration.

## Configuration
CORS policies can be specified per route via [RouteConfig.CorsPolicy](xref:Yarp.ReverseProxy.Configuration.RouteConfig) and can be bound from the `Routes` sections of the config file. As with other route properties, this can be modified and reloaded without restarting the proxy. Policy names are case insensitive.

Example:
```JSON
{
  "ReverseProxy": {
    "Routes": {
      "route1" : {
        "ClusterId": "cluster1",
        "CorsPolicy": "customPolicy",
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

[CORS policies](https://docs.microsoft.com/aspnet/core/security/cors#cors-with-named-policy-and-middleware) are an ASP.NET Core concept that the proxy utilizes. The proxy provides the above configuration to specify a policy per route and the rest is handled by existing ASP.NET Core CORS Middleware.

CORS policies can be configured in the application as follows:
```
services.AddCors(options =>
{
    options.AddPolicy("customPolicy", builder =>
    {
        builder.AllowAnyOrigin();
    });
});
```

Then add the CORS middleware.

```
app.UseCors();

app.MapReverseProxy();
```


### DefaultPolicy

Specifying the value `default` in a route's `CorsPolicy` parameter means that route will use the policy defined in [CorsOptions.DefaultPolicy](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.cors.infrastructure.corsoptions.defaultpolicyname).

### Disable CORS

Specifying the value `disable` in a route's `CorsPolicy` parameter means the CORS middleware will refuse the CORS requests.
