---
uid: queryparameter-routing
title: Query Parameter Routing
---

# Query Parameter Based Routing

Proxy routes specified in [config](config-files.md) or via [code](config-providers.md) must include at least a path or host to match against. In addition to these, a route can also specify one or more query parameters that must be present on the request.

### Precedence

The default route match precedence order is 1) path, 2) method, 3) host, 4) headers 5) query parameters. That means a route which specifies methods and no query parameters will match before a route which specifies query parameters and no methods. This can be overridden by setting the `Order` property on a route.

## Configuration

Query Parameters are specified in the `Match` section of a proxy route.

If multiple query parameter rules are specified on a route then all must match for a route to be taken. OR logic must be implemented either within a query parameter rule or as separate routes.

Configuration:
```JSON
"Routes": {
  "route1" : {
    "ClusterId": "cluster1",
    "Match": {
      "Path": "{**catch-all}",
      "QueryParameters": [
        {
          "Name": "queryparam1",
          "Values": [ "value1" ],
          "Mode": "Exact"
        }
      ]
    }
  },
  "route2" : {
    "ClusterId": "cluster1",
    "Match": {
      "Path": "{**catch-all}",
      "QueryParameters": [
        {
          "Name": "queryparam2",
          "Values": [ "1prefix", "2prefix" ],
          "Mode": "Prefix"
        }
      ]
    }
  },
  "route3" : {
    "ClusterId": "cluster1",
    "Match": {
      "Path": "{**catch-all}",
      "QueryParameters": [
        {
          "Name": "queryparam3",
          "Mode": "Exists"
        }
      ]
    }
  },
  "route4" : {
    "ClusterId": "cluster1",
    "Match": {
      "Path": "{**catch-all}",
      "QueryParameters": [
        {
          "Name": "queryparam4",
          "Values": [ "value1", "value2" ],
          "Mode": "Exact"
        },
        {
          "Name": "queryparam5",
          "Mode": "Exists"
        }
      ]
    }
  },
  "route5" : {
    "ClusterId": "cluster1",
    "Match": {
      "Path": "{**catch-all}",
      "QueryParameters": [
        {
          "Name": "queryparam5",
          "Values": [ "value1", "value2" ],
          "Mode": "Contains"
        },
        {
          "Name": "queryparam6",
          "Mode": "Exists"
        }
      ]
    }
  },
   "route6" : {
    "ClusterId": "cluster1",
    "Match": {
      "Path": "{**catch-all}",
      "QueryParameters": [
        {
          "Name": "queryparam6",
          "Values": [ "value1", "value2" ],
          "Mode": "NotContains"
        },
        {
          "Name": "queryparam7",
          "Mode": "Exists"
        }
      ]
    }
  }
}
```

Code:
```C#
var routes = new[]
{
    new RouteConfig()
    {
        RouteId = "route1",
        ClusterId = "cluster1",
        Match = new RouteMatch
        {
            Path = "{**catch-all}",
            QueryParameters = new[]
            {
                new RouteQueryParameter()
                {
                    Name = "QueryParam1",
                    Values = new[] { "value1" },
                    Mode = QueryParameterMatchMode.Exact
                }
            }
        }
    },
    new RouteConfig()
    {
        RouteId = "route2",
        ClusterId = "cluster1",
        Match = new RouteMatch
        {
            Path = "{**catch-all}",
            QueryParameters = new[]
            {
                new RouteQueryParameter()
                {
                    Name = "QueryParam2",
                    Values = new[] { "1prefix", "2prefix" },
                    Mode = QueryParameterMatchMode.Prefix
                }
            }
        }
    },
    new RouteConfig()
    {
        RouteId = "route3",
        ClusterId = "cluster1",
        Match = new RouteMatch
        {
            Path = "{**catch-all}",
            QueryParameters = new[]
            {
                new RouteQueryParameter()
                {
                    Name = "QueryParam3",
                    Mode = QueryParameterMatchMode.Exists
                }
            }
        }
    },
    new RouteConfig()
    {
        RouteId = "route4",
        ClusterId = "cluster1",
        Match = new RouteMatch
        {
            Path = "{**catch-all}",
            QueryParameters = new[]
            {
            new RouteQueryParameter()
                {
                    Name = "QueryParam4",
                    Values = new[] { "value1", "value2" },
                    Mode = QueryParameterMatchMode.Exact
                },
                new RouteQueryParameter()
                {
                    Name = "QueryParam5",
                    Mode = QueryParameterMatchMode.Exists
                }
            }
        }
    },
    new RouteConfig()
    {
        RouteId = "route5",
        ClusterId = "cluster1",
        Match = new RouteMatch
        {
            Path = "{**catch-all}",
            QueryParameters = new[]
            {
                new RouteQueryParameter()
                {
                    Name = "QueryParam5",
                    Values = new[] { "value1", "value2" },
                    Mode = QueryParameterMatchMode.Contains
                }
            }
        }
    },
    new RouteConfig()
    {
        RouteId = "route6",
        ClusterId = "cluster1",
        Match = new RouteMatch
        {
            Path = "{**catch-all}",
            QueryParameters = new[]
            {
                new RouteQueryParameter()
                {
                    Name = "QueryParam6",
                    Values = new[] { "value1", "value2" },
                    Mode = QueryParameterMatchMode.NotContains
                }
            }
        }
    }
};
```

## Contract

[RouteQueryParameter](xref:Yarp.ReverseProxy.Configuration.RouteQueryParameter) defines the code contract and is mapped from config.

### Name

The query parameter name to check for on the request. A non-empty value is required. This field is case-insensitive.

### Values

A list of possible values to search for. The query parameter must match at least one of these values according to the specified `Mode` except for the 'NotContains'. At least one value is required unless `Mode` is set to `Exists`.

### Mode

[QueryParameterMatchMode](xref:Yarp.ReverseProxy.Configuration.QueryParameterMatchMode) specifies how to match the value(s) against the request query parameter. The default is `Exact`.
- Exact - The query parameter must match in its entirety, subject to the value of `IsCaseSensitive`. Only single query parameters are supported. If there are multiple query parameters with the same name then the match fails.
- Prefix - The query parameter must match by prefix, subject to the value of `IsCaseSensitive`. Only single query parameters are supported. If there are multiple query parameters with the same name then the match fails.
- Exists - The query parameter must exist and contain any non-empty value.
- Contains - The query parameter must contain the value for a match, subject to the value of `IsCaseSensitive`. Only single query parameters are supported. If there are multiple query parameters with the same name then the match fails.
- NotContains - The query parameter must not contain any of the match values, subject to the value of `IsCaseSensitive`. Only single query parameters are supported. If there are multiple query parameters with the same name then the match fails.

### IsCaseSensitive

Indicates if the value match should be performed as case sensitive or insensitive. The default is `false`, insensitive.

### Encoding

The request query string will be parsed and decoded before matching against the route rules.

```
   "route8" : {
    "ClusterId": "cluster1",
    "Match": {
      "Path": "{**catch-all}",
      "QueryParameters": [
        {
          "Name": "queryparam8",
          "Values": [ "another value" ],
          "Mode": "Exact"
        }
      ]
    }
```

Matches to
```
?queryparam8=another%20value
```
or
```
?queryparam8=another+value
```

## Examples

These examples use the configuration specified above.

### Scenario 1 - Exact Query Parameter Match

A request with the following query parameter will match against route1.
```
?QueryParam1=Value1
```

Multiple query parameters with the same name are not currently supported and will _not_ match.
```
?QueryParam1=Value1&QueryParam1=Value2
```


### Scenario 2 - Multiple Values

Route2 defined multiple values to search for in a query parameter ("1prefix", "2prefix"), any of the values are acceptable. It also specified the `Mode` as `Prefix`, so any query parameter that starts with those values is acceptable.

Any of the following query parameters will match route2.
```
?QueryParam2=1prefix
```
```
?QueryParam2=2prefix
```
```
?QueryParam2=1prefix-extra
```
```
?QueryParam2=2prefix-extra
```

Multiple query parameters with the same name are not currently supported and will _not_ match.
```
?QueryParam2=2prefix&QueryParam2=1prefix
```

### Scenario 3 - Exists

Route3 only requires that the query parameter "QueryParam3" exists with any non-empty value

The following is an example that will match route3.
```
?QueryParam3=value
```

An empty query parameter will _not_ match.
```
?QueryParam3
?QueryParam3=
```

This mode does support query parameters with multiple values and multiple query parameters with the same name since it does not look at the query parameter contents. The following will match.
```
?QueryParam3=value1&QueryParam3=value2
```

### Scenario 4 - Multiple QueryParameters

Route4 requires both `QueryParam4` and `QueryParam5`, each matching according to their specified `Mode`. The following query parameters will match route4:
```
?QueryParam4=value1&QueryParam5=AnyValue
```
```
?QueryParam4=value2&QueryParam5=AnyValue
```

These will _not_ match route4 because they are missing one of the required query parameters:
```
?QueryParam4=value2
```
```
?QueryParam5=AnyValue
```
