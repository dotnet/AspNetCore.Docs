# Destination health checks
In most of the real-world systems, it's expected for their nodes to occasionally experience transient issues and go down completely due to a variety of reasons such as an overload, resource leakage, hardware failures, etc. Ideally, it'd be desirable to completely prevent those unfortunate events from occurring in a proactive way, but the cost of designing and building such an ideal system is generally prohibitively high. However, there is another reactive approach which is cheaper and aimed to minimizing a negative impact failures cause on client requests. The proxy can analyze each nodes health and stop sending client traffic to unhealthy ones until they recover. YARP implements this approach in the form of active and passive destination health checks. They are independent from each other and stored on the relative properties for each destination. Health states are initialized with `Unknown` value which can be later changed to either `Healthy` or `Unhealthy` by the corresponding policies as explained below.

## Active health checks
YARP can proactively monitor destination health by sending periodic probing requests to designated health endpoints and analyzing responses. That analysis is performed by an active health check policy specified for a cluster and results in the calculation of the new destination health states. In the end, the policy marks each destination as healthy or unhealthy based on the HTTP response code (2xx is considered healthy) and rebuilds the cluster's healthy destination collection.

There are several cluster-wide configuration settings controlling active health checks that can be set either in the config file or in code. A dedicated health endpoint can also be specified per destination.

#### File example
```JSON
"Clusters": {
  "cluster1": {
    "HealthCheck": {
      "Active": {
        "Enabled": "true",
        "Interval": "00:00:10",
        "Timeout": "00:00:10",
        "Policy": "ConsecutiveFailures",
        "Path": "/api/health",
        "Query": "?foo=bar"
      }
    },
    "Metadata": {
      "ConsecutiveFailuresHealthPolicy.Threshold": "3"
    },
    "Destinations": {
      "cluster1/destination1": {
        "Address": "https://localhost:10000/"
      },
      "cluster1/destination2": {
        "Address": "http://localhost:10010/",
        "Health": "http://localhost:10020/"
      }
    }
  }
}
```

#### Code example
```C#
var clusters = new[]
{
    new ClusterConfig()
    {
        ClusterId = "cluster1",
        HealthCheck = new HealthCheckConfig
        {
            Active = new ActiveHealthCheckConfig
            {
                Enabled = true,
                Interval = TimeSpan.FromSeconds(10),
                Timeout = TimeSpan.FromSeconds(10),
                Policy = HealthCheckConstants.ActivePolicy.ConsecutiveFailures,
                Path = "/api/health",
                Query = "?foo=bar",
            }
        },
        Metadata = new Dictionary<string, string> { { ConsecutiveFailuresHealthPolicyOptions.ThresholdMetadataName, "5" } },
        Destinations =
        {
            { "destination1", new DestinationConfig() { Address = "https://localhost:10000" } },
            { "destination2", new DestinationConfig() { Address = "https://localhost:10010", Health = "https://localhost:10010" } }
        }
    }
};
```

### Configuration
All but one of active health check settings are specified on the cluster level in `Cluster/HealthCheck/Active` section. The only exception is an optional `Destination/Health` element specifying a separate active health check endpoint. The actual health probing URI is constructed as `Destination/Address` (or `Destination/Health` when it's set) + `Cluster/HealthCheck/Active/Path`.

Active health check settings can also be defined in code via the corresponding types in [Yarp.ReverseProxy.Configuration](xref:Yarp.ReverseProxy.Configuration) namespace mirroring the configuration contract.

`Cluster/HealthCheck/Active` section and [ActiveHealthCheckConfig](xref:Yarp.ReverseProxy.Configuration.ActiveHealthCheckConfig):

- `Enabled` - flag indicating whether active health check is enabled for a cluster. Default `false`
- `Interval` - period of sending health probing requests. Default `00:00:15`
- `Timeout` - probing request timeout. Default `00:00:10`
- `Policy` - name of a policy evaluating destinations' active health states. Mandatory parameter
- `Path` -  health check path on all cluster's destinations. Default `null`.
- `Query` -  health check query on all cluster's destinations. Default `null`.

`Destination` section and [DestinationConfig](xref:Yarp.ReverseProxy.Configuration.DestinationConfig).

- `Health` - A dedicated health probing endpoint such as `http://destination:12345/`. Defaults `null` and falls back to `Destination/Address`.

### Built-in policies
There is currently one built-in active health check policy - `ConsecutiveFailuresHealthPolicy`. It counts consecutive health probe failures and marks a destination as unhealthy once the given threshold is reached. On the first successful response, a destination is marked as healthy and the counter is reset.
The policy parameters are set in the cluster's metadata as follows:

`ConsecutiveFailuresHealthPolicy.Threshold` - number of consecutively failed active health probing requests required to mark a destination as unhealthy. Default `2`.

### Design
The main service in this process is [IActiveHealthCheckMonitor](xref:Yarp.ReverseProxy.Health.IActiveHealthCheckMonitor) that periodically creates probing requests via [IProbingRequestFactory](xref:Yarp.ReverseProxy.Health.IProbingRequestFactory), sends them to all [DestinationConfig](xref:Yarp.ReverseProxy.Configuration.DestinationConfig) of each [ClusterConfig](xref:Yarp.ReverseProxy.Configuration.ClusterConfig) with enabled active health checks and then passes all the responses down to a [IActiveHealthCheckPolicy](xref:Yarp.ReverseProxy.Health.IActiveHealthCheckPolicy) specified for a cluster. `IActiveHealthCheckMonitor` doesn't make the actual decision on whether a destination is healthy or not, but delegates this duty to an `IActiveHealthCheckPolicy` specified for a cluster. A policy is called to evaluate the new health states once all probing of all cluster's destination completed. It takes in a [ClusterState](xref:Yarp.ReverseProxy.Model.ClusterState) representing the cluster's dynamic state and a set of [DestinationProbingResult](xref:Yarp.ReverseProxy.Health.DestinationProbingResult) storing cluster's destinations' probing results. Having evaluated a new health state for each destination, the policy calls [IDestinationHealthUpdater](xref:Yarp.ReverseProxy.Health.IDestinationHealthUpdater) to actually update [DestinationHealthState.Active](xref:Yarp.ReverseProxy.Model.DestinationHealthState.Active) values.

```
-{For each cluster's destination}-
IActiveHealthCheckMonitor <--(Create probing request)--> IProbingRequestFactory
        |
        V
 HttpMessageInvoker <--(Send probe and receive response)--> Destination
        |
(Save probing result)
        |
        V
DestinationProbingResult
--------------{END}---------------
        |
(Evaluate new destination active health states using probing results)
        |
        V
IActiveHealthCheckPolicy --(New active health states)--> IDestinationHealthUpdater --(Update each destination's)--> DestinationState.Health.Active
```
There are default built-in implementations for all of the aforementioned components which can also be replaced with custom ones when necessary.

### Extensibility
There are 2 main extensibility points in the active health check subsystem.

#### IActiveHealthCheckPolicy
[IActiveHealthCheckPolicy](xref:Yarp.ReverseProxy.Health.IActiveHealthCheckPolicy) analyzes how destinations respond to active health probes sent by `IActiveHealthCheckMonitor`, evaluates new active health states for all the probed destinations, and then call `IDestinationHealthUpdater.SetActive` to set new active health states and rebuild the healthy destination collection based on the updated values.

The below is a simple example of a custom `IActiveHealthCheckPolicy` marking destination as `Healthy`, if a successful response code was returned for a probe, and as `Unhealthy` otherwise.

```C#
public class FirstUnsuccessfulResponseHealthPolicy : IActiveHealthCheckPolicy
{
    private readonly IDestinationHealthUpdater _healthUpdater;

    public FirstUnsuccessfulResponseHealthPolicy(IDestinationHealthUpdater healthUpdater)
    {
        _healthUpdater = healthUpdater;
    }

    public string Name => "FirstUnsuccessfulResponse";

    public void ProbingCompleted(ClusterState cluster, IReadOnlyList<DestinationProbingResult> probingResults)
    {
        if (probingResults.Count == 0)
        {
            return;
        }

        var newHealthStates = new NewActiveDestinationHealth[probingResults.Count];
        for (var i = 0; i < probingResults.Count; i++)
        {
            var response = probingResults[i].Response;
            var newHealth = response is not null && response.IsSuccessStatusCode ? DestinationHealth.Healthy : DestinationHealth.Unhealthy;
            newHealthStates[i] = new NewActiveDestinationHealth(probingResults[i].Destination, newHealth);
        }

        _healthUpdater.SetActive(cluster, newHealthStates);
    }
}
```

#### IProbingRequestFactory
[IProbingRequestFactory](xref:Yarp.ReverseProxy.Health.IProbingRequestFactory) creates active health probing requests to be sent to destination health endpoints. It can take into account `ActiveHealthCheckOptions.Path`, `DestinationConfig.Health`, and other configuration settings to construct probing requests.

The default `IProbingRequestFactory` uses the same `HttpRequest` configuration as proxy requests, to customize that implement your own `IProbingRequestFactory` and register it in DI like the below.

```C#
services.AddSingleton<IProbingRequestFactory, CustomProbingRequestFactory>();
```

The below is a simple example of a customer `IProbingRequestFactory` concatenating `DestinationConfig.Address` and a fixed health probe path to create the probing request URI.

```C#
public class CustomProbingRequestFactory : IProbingRequestFactory
{
    public HttpRequestMessage CreateRequest(ClusterConfig clusterConfig, DestinationConfig destinationConfig)
    {
        var probeUri = new Uri(destinationConfig.Address + "/api/probe-health");
        return new HttpRequestMessage(HttpMethod.Get, probeUri) { Version = ProtocolHelper.Http11Version };
    }
}
```

## Passive health checks
YARP can passively watch for successes and failures in client request proxying to reactively evaluate destination health states. Responses to the proxied requests are intercepted by a dedicated passive health check middleware which passes them to a policy configured on the cluster. The policy analyzes the responses to evaluate if the destinations that produced them are healthy or not. Then, it calculates and assigns new passive health states to the respective destinations and rebuilds the cluster's healthy destination collection.

Note the response is normally sent to the client before the passive health policy runs, so a policy cannot intercept the response body, nor modify anything in the response headers unless the proxy application introduces full response buffering.

There is one important difference from the active health check logic. Once a destination gets assigned an unhealthy passive state, it stops receiving all new traffic which blocks future health reevaluation. The policy also schedules a destination reactivation after the configured period. Reactivation means resetting the passive health state from `Unhealthy` back to the initial `Unknown` value which makes destination eligible for traffic again.

There are several cluster-wide configuration settings controlling passive health checks that can be set either in the config file or in code.

#### File example
```JSON
"Clusters": {
  "cluster1": {
    "HealthCheck": {
      "Passive": {
        "Enabled": "true",
        "Policy": "TransportFailureRate",
        "ReactivationPeriod": "00:02:00"
      }
    },
    "Metadata": {
      "TransportFailureRateHealthPolicy.RateLimit": "0.5"
    },
    "Destinations": {
      "cluster1/destination1": {
        "Address": "https://localhost:10000/"
      },
      "cluster1/destination2": {
        "Address": "http://localhost:10010/"
      }
    }
  }
}
```

#### Code example
```C#
var clusters = new[]
{
    new ClusterConfig()
    {
        ClusterId = "cluster1",
        HealthCheck = new HealthCheckConfig
        {
            Passive = new PassiveHealthCheckConfig
            {
                Enabled = true,
                Policy = HealthCheckConstants.PassivePolicy.TransportFailureRate,
                ReactivationPeriod = TimeSpan.FromMinutes(2)
            }
        },
        Metadata = new Dictionary<string, string> { { TransportFailureRateHealthPolicyOptions.FailureRateLimitMetadataName, "0.5" } },
        Destinations =
        {
            { "destination1", new DestinationConfig() { Address = "https://localhost:10000" } },
            { "destination2", new DestinationConfig() { Address = "https://localhost:10010" } }
        }
    }
};
```

### Configuration
Passive health check settings are specified on the cluster level in `Cluster/HealthCheck/Passive` section. Alternatively, they can be defined in code via the corresponding types in [Yarp.ReverseProxy.Configuration](xref:Yarp.ReverseProxy.Configuration) namespace mirroring the configuration contract.

Passive health checks require the `PassiveHealthCheckMiddleware` added into the pipeline for them to work. The default `MapReverseProxy(this IEndpointRouteBuilder endpoints)` method does it automatically, but in case of a manual pipeline construction the [UsePassiveHealthChecks](xref:Microsoft.AspNetCore.Builder.AppBuilderHealthExtensions) method must be called to add that middleware as shown in the example below.

```C#
endpoints.MapReverseProxy(proxyPipeline =>
{
    proxyPipeline.UseAffinitizedDestinationLookup();
    proxyPipeline.UseProxyLoadBalancing();
    proxyPipeline.UseRequestAffinitizer();
    proxyPipeline.UsePassiveHealthChecks();
});
```

`Cluster/HealthCheck/Passive` section and [PassiveHealthCheckConfig](xref:Yarp.ReverseProxy.Configuration.PassiveHealthCheckConfig):

- `Enabled` - flag indicating whether passive health check is enabled for a cluster. Default `false`
- `Policy` - name of a policy evaluating destinations' passive health states. Mandatory parameter
- `ReactivationPeriod` - period after which an unhealthy destination's passive health state is reset to `Unknown` and it starts receiving traffic again. Default value is `null` which means the period will be set by a `IPassiveHealthCheckPolicy`

### Built-in policies
There is currently one built-in passive health check policy - [`TransportFailureRateHealthPolicy`](xref:Yarp.ReverseProxy.Health.TransportFailureRateHealthPolicyOptions). It calculates the proxied requests failure rate for each destination and marks it as unhealthy if the specified limit is exceeded. Rate is calculated as a percentage of failed requests to the total number of request proxied to a destination in the given period of time. Failed and total counters are tracked in a sliding time window which means that only the recent readings fitting in the window are taken into account.
There are two sets of policy parameters defined globally and on per cluster level.

Global parameters are set via the options mechanism using `TransportFailureRateHealthPolicyOptions` type with the following properties:

- `DetectionWindowSize` - period of time while detected failures are kept and taken into account in the rate calculation. Default is `00:01:00`.
- `MinimalTotalCountThreshold` - minimal total number of requests which must be proxied to a destination within the detection window before this policy starts evaluating the destination's health and enforcing the failure rate limit. Default is `10`.
- `DefaultFailureRateLimit` - default failure rate limit for a destination to be marked as unhealthy that is applied if it's not set on a cluster's metadata. The value is in range `(0,1)`. Default is `0.3` (30%).

Global policy options can be set in code as follows:
```C#
services.Configure<TransportFailureRateHealthPolicyOptions>(o =>
{
    o.DetectionWindowSize = TimeSpan.FromSeconds(30);
    o.MinimalTotalCountThreshold = 5;
    o.DefaultFailureRateLimit = 0.5;
});
```

Cluster-specific parameters are set in the cluster's metadata as follows:
`TransportFailureRateHealthPolicy.RateLimit` - failure rate limit for a destination to be marked as unhealthy. The value is in range `(0,1)`. Default value is provided by the global `DefaultFailureRateLimit` parameter.

### Design
The main component is [PassiveHealthCheckMiddleware](xref:Yarp.ReverseProxy.Health.PassiveHealthCheckMiddleware) sitting in the request pipeline and analyzing responses returned by destinations. For each response from a destination belonging to a cluster with enabled passive health checks, `PassiveHealthCheckMiddleware` invokes an [IPassiveHealthCheckPolicy](xref:Yarp.ReverseProxy.Health.IPassiveHealthCheckPolicy) specified for the cluster. The policy analyzes the given response, evaluates a new destination's passive health state and calls [IDestinationHealthUpdater](xref:Yarp.ReverseProxy.Health.IDestinationHealthUpdater) to actually update [DestinationHealthState.Passive](xref:Yarp.ReverseProxy.Model.DestinationHealthState.Passive) value. The update happens asynchronously in the background and doesn't block the request pipeline. When a destination gets marked as unhealthy, it stops receiving new requests until it gets reactivated after a configured period. Reactivation means the destination's `DestinationHealthState.Passive` state is reset from `Unhealthy` to `Unknown` and the cluster's list of healthy destinations is rebuilt to include it. A reactivation is scheduled by `IDestinationHealthUpdater` right after setting the destination's `DestinationHealthState.Passive` to `Unhealthy`.

```
      (Response to a proxied request)
                  |
      PassiveHealthCheckMiddleware
                  |
                  V
      IPassiveHealthCheckPolicy
                  |
    (Evaluate new passive health state)
                  |
      IDestinationHealthUpdater --(Asynchronously update passive state)--> DestinationState.Health.Passive
                  |
                  V
      (Schedule a reactivation) --(Set to Unknown)--> DestinationState.Health.Passive
```

### Extensibility
There is one main extensibility point in the passive health check subsystem, the `IPassiveHealthCheckPolicy`.

#### IPassiveHealthCheckPolicy
[IPassiveHealthCheckPolicy](xref:Yarp.ReverseProxy.Health.IPassiveHealthCheckPolicy) analyzes how a destination responded to a proxied client request, evaluates its new passive health state and finally calls `IDestinationHealthUpdater.SetPassiveAsync` to create an async task actually updating the passive health state and rebuilding the healthy destination collection.

The below is a simple example of a custom `IPassiveHealthCheckPolicy` marking destination as `Unhealthy` on the first unsuccessful response to a proxied request.

```C#
public class FirstUnsuccessfulResponseHealthPolicy : IPassiveHealthCheckPolicy
{
    private static readonly TimeSpan _defaultReactivationPeriod = TimeSpan.FromSeconds(60);
    private readonly IDestinationHealthUpdater _healthUpdater;

    public FirstUnsuccessfulResponseHealthPolicy(IDestinationHealthUpdater healthUpdater)
    {
        _healthUpdater = healthUpdater;
    }

    public string Name => "FirstUnsuccessfulResponse";

    public void RequestProxied(HttpContext context, ClusterState cluster, DestinationState destination)
    {
        var error = context.Features.Get<IForwarderErrorFeature>();
        if (error is not null)
        {
            var reactivationPeriod = cluster.Model.Config.HealthCheck?.Passive?.ReactivationPeriod ?? _defaultReactivationPeriod;
            _healthUpdater.SetPassive(cluster, destination, DestinationHealth.Unhealthy, reactivationPeriod);
        }
    }
}
```

## Available destination collection
Destinations health state is used to determine which of them are eligible for receiving proxied requests. Each cluster maintains its own list of available destinations on `AvailableDestinations` property of the [ClusterDestinationState](xref:Yarp.ReverseProxy.Model.ClusterDestinationsState) type. That list gets rebuilt when any destination's health state changes. The [IClusterDestinationsUpdater](xref:Yarp.ReverseProxy.Health.IClusterDestinationsUpdater) controls that process and calls an [IAvailableDestinationsPolicy](xref:Yarp.ReverseProxy.Health.IAvailableDestinationsPolicy) configured on the cluster to actually choose the available destinations from the all cluster's destinations. There are the following built-in policies provided and custom ones can be implemented if necessary.

- `HealthyAndUnknown` - inspects each `DestinationState` and adds it on the available destination list if all of the following statements are TRUE. If no destinations are available then requests will get a 503 error.
    - Active health checks are disabled on the cluster OR `DestinationHealthState.Active != DestinationHealth.Unhealthy`
    - Passive health checks are disabled on the cluster OR `DestinationHealthState.Passive != DestinationHealth.Unhealthy`
- `HealthyOrPanic` - calls `HealthyAndUnknown` policy at first to get the available destinations. If none of them are returned from this call, it marks all cluster's destinations as available. This is the default policy.

**NOTE**: An available destination policy configured on a cluster will be always called regardless of if any health check is enabled on the given cluster. The health state of a disabled health check is set to `Unknown`.

### Configuration
#### File example
```JSON
"Clusters": {
  "cluster1": {    
    "HealthCheck": {
      "AvailableDestinationsPolicy": "HealthyOrPanic",
      "Passive": {
        "Enabled": "true"
      }
    },
    "Destinations": {
      "cluster1/destination1": {
        "Address": "https://localhost:10000/"
      },
      "cluster1/destination2": {
        "Address": "http://localhost:10010/"
      }
    }
  }
}
```

#### Code example
```C#
var clusters = new[]
{
    new ClusterConfig()
    {
        ClusterId = "cluster1",
        HealthCheck = new HealthCheckConfig
        {
            AvailableDestinationsPolicy = HealthCheckConstants.AvailableDestinations.HealthyOrPanic,
            Passive = new PassiveHealthCheckConfig
            {
                Enabled = true
            }
        },
        Destinations =
        {
            { "destination1", new DestinationConfig() { Address = "https://localhost:10000" } },
            { "destination2", new DestinationConfig() { Address = "https://localhost:10010" } }
        }
    }
};
```
