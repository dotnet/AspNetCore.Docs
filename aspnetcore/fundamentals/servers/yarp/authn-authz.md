# Authentication and Authorization

## Introduction
The reverse proxy can be used to authenticate and authorize requests before they are proxied to the destination servers. This can reduce load on the destination servers, add a layer of protection, and ensure consistent policies are implemented across your applications.

## Defaults

No authentication or authorization is performed on requests unless enabled in the route or application configuration.

## Configuration
Authorization policies can be specified per route via [RouteConfig.AuthorizationPolicy](xref:Yarp.ReverseProxy.Configuration.RouteConfig) and can be bound from the `Routes` sections of the config file. As with other route properties, this can be modified and reloaded without restarting the proxy. Policy names are case insensitive.

Example:
```JSON
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

[Authorization policies](https://docs.microsoft.com/aspnet/core/security/authorization/policies) are an ASP.NET Core concept that the proxy utilizes. The proxy provides the above configuration to specify a policy per route and the rest is handled by existing ASP.NET Core authentication and authorization components.

Authorization policies can be configured in the application as follows:
```
services.AddAuthorization(options =>
{
    options.AddPolicy("customPolicy", policy =>
        policy.RequireAuthenticatedUser());
});
```

In Program.cs add the Authorization and Authentication middleware.

```
app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();
```

See the [Authentication](https://docs.microsoft.com/aspnet/core/security/authentication/) docs for setting up your preferred kind of authentication.

### Special values:

In addition to custom policy names, there are two special values that can be specified in a route's authorization parameter: `default` and `anonymous`. ASP.NET Core also has a FallbackPolicy setting that applies to routes that do not specify a policy.

#### DefaultPolicy

Specifying the value `default` in a route's authorization parameter means that route will use the policy defined in [AuthorizationOptions.DefaultPolicy](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.authorization.authorizationoptions.defaultpolicy?#Microsoft_AspNetCore_Authorization_AuthorizationOptions_DefaultPolicy). That policy is pre-configured to require authenticated users.

#### Anonymous

Specifying the value `anonymous` in a route's authorization parameter means that route will not require authorization regardless of any other configuration in the application such as the FallbackPolicy.

#### FallbackPolicy

[AuthorizationOptions.FallbackPolicy](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.authorization.authorizationoptions.fallbackpolicy) is the policy that will be used for any request or route that was not configured with a policy. FallbackPolicy does not have a value by default, any request will be allowed.

## Flowing Credentials

Even after a request has been authorized in the proxy, the destination server may still need to know who the user is (authentication) and what they're allowed to do (authorization). How you flow that information will depend on the type of authentication being used.

### Cookie, bearer, API keys

These authentication types already pass their values in the request headers and these will flow to the destination server by default. That server will still need to verify and interpret those values, causing some double work.

### OAuth2, OpenIdConnect, WsFederation

These protocols are commonly used with remote identity providers. The authentication process can be configured in the proxy application and will result in an authentication cookie. That cookie will flow to the destination server as a normal request header.

### Windows, Negotiate, NTLM, Kerberos

These authentication types are often bound to a specific connection. They are not supported as means of authenticating a user in a destination server behind the YARP proxy (see [#166](https://github.com/microsoft/reverse-proxy/issues/166). They can be used to authenticate an incoming request to the proxy, but that identity information will have to be communicated to the destination server in another form. They can also be used to authenticate the proxy to the destination servers, but only as the proxy's own user, impersonating the client is not supported.

### Client Certificates

Client certificates are a TLS feature and are negotiated as part of a connection. See [these docs](https://docs.microsoft.com/aspnet/core/security/authentication/certauth) for additional information. The certificate can be forwarded to the destination server as an HTTP header using the [ClientCert](transforms.md#clientcert) transform.

### Swapping authentication types

Authentication types like Windows that don't flow naturally to the destination server will need to be converted in the proxy to an alternate form. For example a JWT bearer token can be created with the user information and set on the proxy request.

These swaps can be performed using [custom request transforms](transforms.md#from-code). Detailed examples can be developed for specific scenarios if there is enough community interest. We need more community feedback on how you want to convert and flow identity information.
