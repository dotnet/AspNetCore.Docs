# Load Balancing

## Introduction

Whenever there are multiple healthy destinations available, YARP has to decide which one to use for a given request.
YARP ships with built-in load-balancing algorithms, but also offers extensibility for any custom load balancing approach.

## Configuration

### Services and middleware registration

Load balancing policies are registered in the DI container via the `AddLoadBalancingPolicies()` method, which is automatically called by `AddReverseProxy()`.

The middleware is added with `UseLoadBalancing()`, which is included by default in the parameterless `MapReverseProxy` method.

### Cluster configuration

The algorithm used to determine the destination can be configured by setting the `LoadBalancingPolicy`.

If no policy is specified, `PowerOfTwoChoices` will be used.

#### File example

```JSON
"ReverseProxy": {
  "Clusters": {
    "cluster1": {
      "LoadBalancingPolicy": "RoundRobin",
      "Destinations": {
        "cluster1/destination1": {
          "Address": "https://localhost:10000/"
        },
        "cluster1/destination2": {
          "Address": "https://localhost:10010/"
        }
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
        LoadBalancingPolicy = LoadBalancingPolicies.RoundRobin,
        Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
        {
            { "destination1", new DestinationConfig() { Address = "https://localhost:10000" } },
            { "destination2", new DestinationConfig() { Address = "https://localhost:10010" } }
        }
    }
};
```

## Built-in policies

YARP ships with the following built-in policies:
- `FirstAlphabetical`

    Select the alphabetically first available destination without considering load. This is useful for dual destination fail-over systems.
- `Random`

    Select a destination randomly.
- `PowerOfTwoChoices` (default)

    Select two random destinations and then select the one with the least assigned requests.
    This avoids the overhead of `LeastRequests` and the worst case for `Random` where it selects a busy destination.
- `RoundRobin`

    Select a destination by cycling through them in order.
- `LeastRequests`

    Select the destination with the least assigned requests. This requires examining all destinations.

## Extensibility

`ILoadBalancingPolicy` is responsible for picking a destination from a list of available healthy destinations.

A custom implementation can be provided in DI.

```c#
// Implement the ILoadBalancingPolicy
public sealed class LastLoadBalancingPolicy : ILoadBalancingPolicy
{
    public string Name => "Last";

    public DestinationState? PickDestination(HttpContext context, ClusterState cluster, IReadOnlyList<DestinationState> availableDestinations)
    {
        return availableDestinations[^1];
    }
}

// Register it in DI in ConfigureServices method
services.AddSingleton<ILoadBalancingPolicy, LastLoadBalancingPolicy>();

// Set the LoadBalancingPolicy on the cluster
cluster.LoadBalancingPolicy = "Last";
```
