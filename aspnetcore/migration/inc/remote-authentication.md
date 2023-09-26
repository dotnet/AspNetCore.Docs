---
title: Remote Authentication
description: Remote Authentication
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/remote-authentication
---

# Remote Authentication

The System.Web adapters' remote authentication feature allows an ASP.NET Core app to determine a user's identity (authenticate an HTTP request) by deferring to an ASP.NET app. Enabling the feature adds an endpoint to the ASP.NET app that returns a serialized <xref:System.Security.Claims.ClaimsPrincipal> representing the authenticated user for any requests made to the endpoint. The ASP.NET Core app, then, registers a custom authentication handler that will (for endpoints with remote authentication enabled) determine a user's identity by calling that endpoint on the ASP.NET app and passing selected headers and cookies from the original request received by the ASP.NET Core app.

## Configuration

There are just a few small code changes needed to enable remote authentication in a solution that's already set up according to the [Getting Started](xref:migration/inc/overview).

First, follow the [remote app setup](xref:migration/inc/remote-app-setup) instructions to connect the ASP.NET Core and ASP.NET apps. Then, there are just a couple extra extension methods to call to enable remote app authentication.

### ASP.NET app configuration

The ASP.NET app needs to be configured to add the authentication endpoint. Adding the authentication endpoint is done by calling the `AddAuthenticationServer` extension method to set up the HTTP module that watches for requests to the authentication endpoint. Note that remote authentication scenarios typically want to add proxy support as well, so that any authentication related redirects correctly route to the ASP.NET Core app rather than the ASP.NET one.

:::code language="csharp" source="~/migration/inc/samples/remote-authentication/AspNetApp.cs" id="snippet_SystemWebAdapterConfiguration" :::

### ASP.NET Core app configuration

Next, the ASP.NET Core app needs to be configured to enable the authentication handler that will authenticate users by making an HTTP request to the ASP.NET app. Again, this is done by calling `AddAuthenticationClient` when registering System.Web adapters services:

:::code language="csharp" source="~/migration/inc/samples/remote-authentication/AspNetCore.cs" id="snippet_AddSystemWebAdapters" highlight="8" :::

The boolean that is passed to the `AddAuthenticationClient` call specifies whether remote app authentication should be the default authentication scheme. Passing `true` will cause the user to be authenticated via remote app authentication for all requests, whereas passing `false` means that the user will only be authenticated with remote app authentication if the remote app scheme is specifically requested (with `[Authorize(AuthenticationSchemes = RemoteAppAuthenticationDefaults.AuthenticationScheme)]` on a controller or action method, for example). Passing false for this parameter has the advantage of only making HTTP requests to the original ASP.NET app for authentication for endpoints that require remote app authentication but has the disadvantage of requiring annotating all such endpoints to indicate that they will use remote app auth.

In addition to the require boolean, an optional callback may be passed to `AddAuthenticationClient` to modify some other aspects of the remote authentication process's behavior:

* `RequestHeadersToForward`: This property contains headers that should be forwarded from a request when calling the authenticate API. By default, the only headers forwarded are `Authorization` and `Cookie`. Additional headers can be forwarded by adding them to this list. Alternatively, if the list is cleared (so that no headers are specified), then all headers will be forwarded.
* `ResponseHeadersToForward`: This property lists response headers that should be propagated back from the authenticate request to the original call that prompted authentication in scenarios where identity is challenged. By default, this includes `Location`, `Set-Cookie`, and `WWW-Authenticate` headers.
* `AuthenticationEndpointPath`: The endpoint on the ASP.NET app where authenticate requests should be made. This defaults to `/systemweb-adapters/authenticate` and must match the endpoint specified in the ASP.NET authentication endpoint configuration.

Finally, if the ASP.NET Core app didn't previously include authentication middleware, that will need to be enabled (after routing middleware, but before authorization middleware):

:::code language="csharp" source="~/migration/inc/samples/remote-authentication/AspNetCore.cs" id="snippet_UseAuthentication" :::

## Design

1. When requests are processed by the ASP.NET Core app, if remote app authentication is the default scheme or specified by the request's endpoint, the `RemoteAuthenticationAuthHandler` will attempt to authenticate the user.
    1. The handler will make an HTTP request to the ASP.NET app's authenticate endpoint. It will copy configured headers from the current request onto this new one in order to forward auth-relevant data. As mentioned above, default behavior is to copy the `Authorize` and `Cookie` headers. The API key header is also added for security purposes.
1. The ASP.NET app will serve requests sent to the authenticate endpoint. As long as the API keys match, the ASP.NET app will return either the current user's <xref:System.Security.Claims.ClaimsPrincipal> serialized into the response body or it will return an HTTP status code (like 401 or 302) and response headers indicating failure.
1. When the ASP.NET Core app's `RemoteAuthenticationAuthHandler` receives the response from the ASP.NET app:
    1. If a ClaimsPrincipal was successfully returned, the auth handler will deserialize it and use it as the current user's identity.
    1. If a ClaimsPrincipal was not successfully returned, the handler will store the result and if authentication is challenged (because the user is accessing a protected resource, for example), the request's response will be updated with the status code and selected response headers from the response from the authenticate endpoint. This enables challenge responses (like redirects to a login page) to be propagated to end users.
        1. Because results from the ASP.NET app's authenticate endpoint may include data specific to that endpoint, users can register `IRemoteAuthenticationResultProcessor` implementations with the ASP.NET Core app which will run on any authentication results before they are used. As an example, the one built-in `IRemoteAuthenticationResultProcessor` is `RedirectUrlProcessor` which looks for `Location` response headers returned from the authenticate endpoint and ensures that they redirect back to the host of the ASP.NET Core app and not the ASP.NET app directly.

## Known limitations

This remote authentication approach has a couple known limitations:

1. Because Windows authentication depends on a handle to a Windows identity, Windows authentication is not supported by this feature. Future work is planned to explore how shared Windows authentication might work. See [dotnet/systemweb-adapters#246](https://github.com/dotnet/systemweb-adapters/issues/246) for more information.
1. This feature allows the ASP.NET Core app to make use of an identity authenticated by the ASP.NET app, but all actions related to users (logging on, logging off, etc.) still need to be routed through the ASP.NET app.

## Alternatives

If authentication in the ASP.NET app is done using `Microsoft.Owin` Cookie Authentication Middleware, an alternative solution to sharing identity is to configure the ASP.NET and ASP.NET Core apps so that they are able to share an authentication cookie. Sharing an authentication cookie enables:

* Both apps to determine the user identity from the same cookie.
* Signing in or out of one app signs the user in or out of the other app.

Note that because signing in typically depends on a specific database, not all authentication functionality will work in both apps:

* Users should sign in through only one of the apps, either the ASP.NET or ASP.NET Core app, whichever the database is setup to work with.
* Both apps are able to see the users' identity and claims.
* Both apps are able to sign the user out.

Details on how to configure sharing auth cookies between ASP.NET and ASP.NET Core apps are available in [cookie sharing documentation](xref:security/cookie-sharing). The following samples in the [System.Web adapters](https://github.com/dotnet/systemweb-adapters) GitHub repo demonstrates remote app authentication with shared cookie configuration enabling both apps to sign users in and out :

* [ASP.NET app](https://github.com/dotnet/systemweb-adapters/tree/main/samples/RemoteAuth/Identity/MvcApp)
* [ASP.NET Core app](https://github.com/dotnet/systemweb-adapters/tree/main/samples/RemoteAuth/Identity/MvcCoreApp)

Sharing authentication is a good option if both the following are true:

* The ASP.NET app is already using `Microsoft.Owin` cookie authentication.
* It's possible to update the ASP.NET app and ASP.NET Core apps to use matching data protection settings. Matching shared data protection settings includes a shared file path, Redis cache, or Azure Blob Storage for storing data protection keys.

For other scenarios, the remote authentication approach described previously in this doc is more flexible and is probably a better fit.
