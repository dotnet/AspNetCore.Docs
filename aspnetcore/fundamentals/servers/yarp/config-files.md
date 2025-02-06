# Configuration Files

## Introduction
The reverse proxy can load configuration for routes and clusters from files using the IConfiguration abstraction from Microsoft.Extensions. The examples given here use JSON, but any IConfiguration source should work. The configuration will also be updated without restarting the proxy if the source file changes.

## Loading Configuration
To load the proxy configuration from IConfiguration add the following code in Program.cs:
```c#
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
**Note**: For details about middleware ordering see [here](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/#middleware-order).

Configuration can be modified during the load sequence using [Configuration Filters](config-filters.md).

## Multiple Configuration Sources
As of 1.1, YARP supports loading the proxy configuration from multiple sources. LoadFromConfig may be called multiple times referencing different IConfiguration sections or may be combine with a different config source like InMemory. Routes can reference clusters from other sources. Note merging partial config from different sources for a given route or cluster is not supported.

```c#
services.AddReverseProxy()
    .LoadFromConfig(Configuration.GetSection("ReverseProxy1"))
    .LoadFromConfig(Configuration.GetSection("ReverseProxy2"));
```
or
```c#

services.AddReverseProxy()
    .LoadFromMemory(routes, clusters)
    .LoadFromConfig(Configuration.GetSection("ReverseProxy"));
```

## Configuration contract
File-based configuration is dynamically mapped to the types in [Yarp.ReverseProxy.Configuration](xref:Yarp.ReverseProxy.Configuration) namespace by an [IProxyConfigProvider](xref:Yarp.ReverseProxy.Configuration.IProxyConfigProvider) implementation converts at application start and each time the configuration changes.

## Configuration Structure
The configuration consists of a named section that you specified above via `Configuration.GetSection("ReverseProxy")`, and contains subsections for routes and clusters.

Example:
```JSON
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

### Routes

The routes section is an unordered collection of route matches and their associated configuration. A route requires at least the following fields:
- RouteId - a unique name
- ClusterId - refers to the name of an entry in the clusters section.
- Match - contains either a Hosts array or a Path pattern string. Path is an ASP.NET Core route template that can be defined as [explained here](https://docs.microsoft.com/aspnet/core/fundamentals/routing#route-templates).
Route matching is based on the most specific routes having highest precedence as described [here]( https://docs.microsoft.com/aspnet/core/fundamentals/routing#url-matching). Explicit ordering can be achieved using the `order` field, with lower values taking higher priority.

[Headers](header-routing.md), [Authorization](authn-authz.md), [CORS](cors.md), and other route based policies can be configured on each route entry. For additional fields see [RouteConfig](xref:Yarp.ReverseProxy.Configuration.RouteConfig).

The proxy will apply the given matching criteria and policies, and then pass off the request to the specified cluster.

### Clusters
The clusters section is an unordered collection of named clusters. A cluster primarily contains a collection of named destinations and their addresses, any of which is considered capable of handling requests for a given route. The proxy will process the request according to the route and cluster configuration in order to select a destination.

For additional fields see [ClusterConfig](xref:Yarp.ReverseProxy.Configuration.ClusterConfig).

## All config properties
```JSON
{
  // Base URLs the server listens on, must be configured independently of the routes below
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
    // Routes tell the proxy which requests to forward
    "Routes": {
      "minimumroute" : {
        // Matches anything and routes it to www.example.com
        "ClusterId": "minimumcluster",
        "Match": {
          "Path": "{**catch-all}"
        }
      },
      "allrouteprops" : {
        // matches /something/* and routes to "allclusterprops"
        "ClusterId": "allclusterprops", // Name of one of the clusters
        "Order" : 100, // Lower numbers have higher precedence
        "MaxRequestBodySize" : 1000000, // In bytes. An optional override of the server's limit (30MB default). Set to -1 to disable.
        "AuthorizationPolicy" : "Anonymous", // Name of the policy or "Default", "Anonymous"
        "CorsPolicy" : "Default", // Name of the CorsPolicy to apply to this route or "Default", "Disable"
        "Match": {
          "Path": "/something/{**remainder}", // The path to match using ASP.NET syntax.
          "Hosts" : [ "www.aaaaa.com", "www.bbbbb.com"], // The host names to match, unspecified is any
          "Methods" : [ "GET", "PUT" ], // The HTTP methods that match, uspecified is all
          "Headers": [ // The headers to match, unspecified is any
            {
              "Name": "MyCustomHeader", // Name of the header
              "Values": [ "value1", "value2", "another value" ], // Matches are against any of these values
              "Mode": "ExactHeader", // or "HeaderPrefix", "Exists" , "Contains", "NotContains", "NotExists"
              "IsCaseSensitive": true
            }
          ],
          "QueryParameters": [ // The query parameters to match, unspecified is any
            {
              "Name": "MyQueryParameter", // Name of the query parameter
              "Values": [ "value1", "value2", "another value" ], // Matches are against any of these values
              "Mode": "Exact", // or "Prefix", "Exists" , "Contains", "NotContains"
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
            "Health" : "https://10.20.30.40:12345/test" // override for active health checks
          }
        },
        "LoadBalancingPolicy" : "PowerOfTwoChoices", // Alternatively "FirstAlphabetical", "Random", "RoundRobin", "LeastRequests"
        "SessionAffinity": {
          "Enabled": true, // Defaults to 'false'
          "Policy": "Cookie", // Default, alternatively "CustomHeader"
          "FailurePolicy": "Redistribute", // default, Alternatively "Return503Error"
          "Settings" : {
              "CustomHeaderName": "MySessionHeaderName" // Defaults to 'X-Yarp-Proxy-Affinity`
          }
        },
        "HealthCheck": {
          "Active": { // Makes API calls to validate the health.
            "Enabled": "true",
            "Interval": "00:00:10",
            "Timeout": "00:00:10",
            "Policy": "ConsecutiveFailures",
            "Path": "/api/health", // API endpoint to query for health state
            "Query": "?foo=bar"
          },
          "Passive": { // Disables destinations based on HTTP response codes
            "Enabled": true, // Defaults to false
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

For more information see [logging configuration](diagnosing-yarp-issues.md#logging) and [HTTP client configuration](http-client-config.md).
