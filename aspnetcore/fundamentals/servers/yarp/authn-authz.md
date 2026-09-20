---
title: YARP authentication and authorization
ai-usage: ai-assisted
author: wadepickett
content_well_notification: AI-contribution
description: Learn how to configure authentication and authorization for YARP routes.
ms.author: wpickett
ms.date: 09/18/2026
ms.topic: concept-article
uid: fundamentals/servers/yarp/authn-authz
---

# YARP authentication and authorization

## Introduction
The reverse proxy can be used to authenticate and authorize requests before they are proxied to the destination servers. This can reduce load on the destination servers, add a layer of protection, and ensure consistent policies are implemented across your applications.

## Defaults

No authentication or authorization is performed on requests unless enabled in the route or application configuration.

## Configuration
Authorization policies can be specified per route via [RouteConfig.AuthorizationPolicy](xref:Yarp.ReverseProxy.Configuration.RouteConfig) and can be bound from the `Routes` sections of the config file. As with other route properties, this can be modified and reloaded without restarting the proxy. Policy names are case insensitive.

Example:
```json
{
  "ReverseProxy": {
    "Routes": {
      "route1" : {
        "ClusterId": "cluster1",
        "AuthorizationPolicy": "customPolicy",
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

[Authorization policies](/aspnet/core/security/authorization/policies) are an ASP.NET Core concept that the proxy utilizes. The proxy provides the above configuration to specify a policy per route and the rest is handled by existing ASP.NET Core authentication and authorization components.

Authorization policies can be configured in the application as follows:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("customPolicy", policy =>
        policy.RequireAuthenticatedUser());
});
```

In Program.cs add the Authorization and Authentication middleware.

```csharp
app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();
```

See <xref:security/authentication/index> for setting up your preferred type of authentication.

### Special values

In addition to custom policy names, YARP supports two special values for a route's authorization parameter: `default` and `anonymous`. When a route doesn't specify the parameter, ASP.NET Core uses the fallback policy if one is configured.

#### `default`

The `default` value uses the <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.DefaultPolicy%2A?displayProperty=nameWithType>. By default, this policy requires an authenticated user.

#### `anonymous`

The `anonymous` value allows anonymous access to the route regardless of the configured fallback policy.

#### Fallback policy

The <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.FallbackPolicy%2A?displayProperty=nameWithType> is used for a route that doesn't specify an authorization parameter. By default, the fallback policy is `null`, so such a route doesn't require authorization. For complete policy selection rules, see <xref:security/authorization/policies#default-and-fallback-policies>.

## Flowing Credentials

Even after a request has been authorized in the proxy, the destination server may still need to know who the user is (authentication) and what they're allowed to do (authorization). How you flow that information will depend on the type of authentication being used.

### Cookie, bearer, API keys

These authentication types already pass their values in the request headers and these will flow to the destination server by default. That server will still need to verify and interpret those values, causing some double work.

### OAuth2, OpenIdConnect, WsFederation

These protocols are commonly used with remote identity providers. The authentication process can be configured in the proxy application and will result in an authentication cookie. That cookie will flow to the destination server as a normal request header.

### Windows, Negotiate, NTLM, Kerberos

These authentication types are often bound to a specific connection. They are not supported as means of authenticating a user in a destination server behind the YARP proxy (see [#166](https://github.com/microsoft/reverse-proxy/issues/166). They can be used to authenticate an incoming request to the proxy, but that identity information will have to be communicated to the destination server in another form. They can also be used to authenticate the proxy to the destination servers, but only as the proxy's own user, impersonating the client is not supported.

### Client Certificates

Client certificates are a TLS feature and are negotiated as part of a connection. See [these docs](/aspnet/core/security/authentication/certauth) for additional information. The certificate can be forwarded to the destination server as an HTTP header using the [ClientCert](xref:fundamentals/servers/yarp/transforms#clientcert) transform.

### Swapping authentication types

Authentication types like Windows that don't flow naturally to the destination server will need to be converted in the proxy to an alternate form. For example a JWT bearer token can be created with the user information and set on the proxy request.

These swaps can be performed using [custom request transforms](xref:fundamentals/servers/yarp/transforms#from-code). Detailed examples can be developed for specific scenarios if there is enough community interest. We need more community feedback on how you want to convert and flow identity information.
