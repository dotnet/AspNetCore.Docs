---
uid: fundamentals/servers/yarp/config-files
title: YARP Configuration Files
description: Explore how to work with YARP configuration files, examine the file structure and properties, define routes, clusters, and sources, and load proxy configuration. 
author: wadepickett
ms.author: wpickett
ms.date: 04/24/2026
ms.topic: concept-article
content_well_notification: AI-contribution
ai-usage: ai-assisted

# customer intent: As an ASP.NET developer, I want to get started with the YARP library, so I can learn how customize the modules.
---
# YARP Configuration Files

The reverse proxy can load configuration for routes and clusters from files by using the [IConfiguration](/dotnet/api/microsoft.extensions.configuration.iconfiguration) abstraction from Microsoft.Extensions.

This article provides example proxy configuration for YARP. Although the configuration example uses JSON, any `IConfiguration` source should work. Also, the configuration updates without restarting the proxy when the source file changes.

## Load the proxy configuration

To load the proxy configuration from the `IConfiguration` instance, add the following code in the _Program.cs_ file:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add the reverse proxy capability to the server
builder.Services.AddReverseProxy()
    // Initialize the reverse proxy from the "ReverseProxy" section of configuration
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Register the reverse proxy routes
app.MapReverseProxy();

app.Run();
```

> [!NOTE]
> For details about middleware ordering, see [ASP.NET Core Middleware > Middleware order](/aspnet/core/fundamentals/middleware/#middleware-order).

Configuration can be modified during the load sequence by using [YARP configuration filters](xref:fundamentals/servers/yarp/config-filters).

## Load from multiple configuration sources

Starting in version 1.1, YARP supports loading the proxy configuration from multiple sources. You can call the `LoadFromConfig` method multiple times and reference different `IConfiguration` sections. You can also combine the call with a different config source, such as InMemory. Routes can reference clusters from other sources.

> [!NOTE]
> Merging partial config from different sources for a given route or cluster isn't supported.

```csharp
services.AddReverseProxy()
    .LoadFromConfig(Configuration.GetSection("ReverseProxy1"))
    .LoadFromConfig(Configuration.GetSection("ReverseProxy2"));
```
Another example:

```csharp

services.AddReverseProxy()
    .LoadFromMemory(routes, clusters)
    .LoadFromConfig(Configuration.GetSection("ReverseProxy"));
```

## Review the configuration contract

File-based configuration is dynamically mapped to the types in the [Yarp.ReverseProxy.Configuration](xref:Yarp.ReverseProxy.Configuration) namespace by an [IProxyConfigProvider](xref:Yarp.ReverseProxy.Configuration.IProxyConfigProvider) implementation. The contract converts at application start and each time the configuration changes.

## Examine the configuration structure

The configuration consists of a named section and subsections for routes and clusters. In the previous example, the named section is `Configuration.GetSection("ReverseProxy")`.

```json
{
  "ReverseProxy": {
    "Routes": {
      "route1" : {
        "ClusterId": "cluster1",
        "Match": {
          "Path": "{**catch-all}",
          "Hosts" : [ "www.aaaaa.com", "www.bbbbb.com"]
        }
      }
    },
    "Clusters": {
      "cluster1": {
        "Destinations": {
          "cluster1/destination1": {
            "Address": "https://example.com/"
          }
        }
      }
    }
  }
}
```

### Define configuration routes

The `Routes` section is an unordered collection of route matches and their associated configuration.

Each route requires at least the following fields:

* `RouteId`: A unique name for the route.
* `ClusterId`: The name of an entry in the `Clusters` section.
* `Match`: Either a `Hosts` array or a `Path` pattern string. You can define the path by using [Routing in ASP.NET Core > Route templates](/aspnet/core/fundamentals/routing#route-templates).

Route matching is based on the most specific routes having highest precedence, as described in [URL matching](/aspnet/core/fundamentals/routing#url-matching). Explicit ordering can be achieved by using the `order` field, where lower values take higher priority.

[YARP headers](xref:fundamentals/servers/yarp/header-routing), [authentication and authorization](xref:fundamentals/servers/yarp/authn-authz), [cross-origin requests (CORS)](xref:fundamentals/servers/yarp/cors), and other route-based policies can be configured on each route entry. For other fields, see the [RouteConfig](xref:Yarp.ReverseProxy.Configuration.RouteConfig) reference.

The proxy applies the given matching criteria and policies, and passes off the request to the specified cluster.

### Define configuration clusters

The `Clusters` section is an unordered collection of named clusters. A cluster primarily contains a collection of named destinations and their addresses, any of which is considered capable of handling requests for a given route. The proxy processes the request according to the route and cluster configuration to select a destination.

For other fields, see the [ClusterConfig](xref:Yarp.ReverseProxy.Configuration.ClusterConfig) reference.

## Review all config properties

The following JSON example shows all properties available for the YARP proxy configuration.

```json
{
  // Base URLs the server listens on, must be configured independently of the routes defined below
  "Urls": "http://localhost:5000;https://localhost:5001",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      // Uncomment to hide diagnostic messages from runtime and proxy
      // "Microsoft": "Warning",
      // "Yarp" : "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ReverseProxy": {
    // Routes inform the proxy which requests to forward
    "Routes": {
      "minimumroute" : {
        // Matches anything and routes to www.example.com
        "ClusterId": "minimumcluster",
        "Match": {
          "Path": "{**catch-all}"
        }
      },
      "allrouteprops" : {
        // Matches /something/* and routes to "allclusterprops"
        "ClusterId": "allclusterprops", // Name of a cluster
        "Order" : 100, // Lower numbers have higher precedence
        "MaxRequestBodySize" : 1000000, // In bytes. An optional override of the server's limit (30MB default). Set to -1 to disable.
        "AuthorizationPolicy" : "Anonymous", // Name of the policy or "Default", "Anonymous"
        "CorsPolicy" : "Default", // Name of the CorsPolicy to apply to this route or "Default", "Disable"
        "Match": {
          "Path": "/something/{**remainder}", // Path to match by using ASP.NET syntax
          "Hosts" : [ "www.aaaaa.com", "www.bbbbb.com"], // Host names to match, unspecified is any
          "Methods" : [ "GET", "PUT" ], // HTTP methods that match, unspecified is all
          "Headers": [ // Headers to match, unspecified is any
            {
              "Name": "MyCustomHeader", // Name of the header
              "Values": [ "value1", "value2", "another value" ], // Match any of these values
              "Mode": "ExactHeader", // Or, match "HeaderPrefix", "Exists" , "Contains", "NotContains", "NotExists"
              "IsCaseSensitive": true
            }
          ],
          "QueryParameters": [ // Query parameters to match, unspecified is any
            {
              "Name": "MyQueryParameter", // Name of the query parameter
              "Values": [ "value1", "value2", "another value" ], // Match any of these values
              "Mode": "Exact", // Or, match "Prefix", "Exists" , "Contains", "NotContains"
              "IsCaseSensitive": true
            }
          ]
        },
        "Metadata" : { // List of key value pairs that can be used by custom extensions
          "MyName" : "MyValue"
        },
        "Transforms" : [ // List of transforms. See the Transforms article for more details
          {
            "RequestHeader": "MyHeader",
            "Set": "MyValue"
          }
        ]
      }
    },
    // Clusters tell the proxy where and how to forward requests
    "Clusters": {
      "minimumcluster": {
        "Destinations": {
          "example.com": {
            "Address": "http://www.example.com/"
          }
        }
      },
      "allclusterprops": {
        "Destinations": {
          "first_destination": {
            "Address": "https://contoso.com"
          },
          "another_destination": {
            "Address": "https://10.20.30.40",
            "Health" : "https://10.20.30.40:12345/test" // Override for active health checks
          }
        },
        "LoadBalancingPolicy" : "PowerOfTwoChoices", // Alternatively "FirstAlphabetical", "Random", "RoundRobin", "LeastRequests"
        "SessionAffinity": {
          "Enabled": true, // Default is 'false'
          "Policy": "Cookie", // Default, alternatively "CustomHeader"
          "FailurePolicy": "Redistribute", // Default, alternatively "Return503Error"
          "Settings" : {
              "CustomHeaderName": "MySessionHeaderName" // Default is 'X-Yarp-Proxy-Affinity`
          }
        },
        "HealthCheck": {
          "Active": { // Makes API calls to validate the health
            "Enabled": "true",
            "Interval": "00:00:10",
            "Timeout": "00:00:10",
            "Policy": "ConsecutiveFailures",
            "Path": "/api/health", // API endpoint to query for health state
            "Query": "?foo=bar"
          },
          "Passive": { // Disables destinations based on HTTP response codes
            "Enabled": true, // Default is false
            "Policy" : "TransportFailureRateHealthPolicy", // Required
            "ReactivationPeriod" : "00:00:10" // 10s
          }
        },
        "HttpClient" : { // Configuration of HttpClient instance used to contact destinations
          "SSLProtocols" : "Tls13",
          "DangerousAcceptAnyServerCertificate" : false,
          "MaxConnectionsPerServer" : 1024,
          "EnableMultipleHttp2Connections" : true,
          "RequestHeaderEncoding" : "Latin1", // How to interpret non ASCII characters in request header values
          "ResponseHeaderEncoding" : "Latin1" // How to interpret non ASCII characters in response header values
        },
        "HttpRequest" : { // Options for sending request to destination
          "ActivityTimeout" : "00:02:00",
          "Version" : "2",
          "VersionPolicy" : "RequestVersionOrLower",
          "AllowResponseBuffering" : "false"
        },
        "Metadata" : { // Custom Key value pairs
          "TransportFailureRateHealthPolicy.RateLimit": "0.5", // Used by Passive health policy
          "MyKey" : "MyValue"
        }
      }
    }
  }
}
```

## Related content

- [Logging configuration](diagnosing-yarp-issues.md#logging)
- [HTTP client configuration](xref:fundamentals/servers/yarp/http-client-config)