---
title: SignalR authentication and authorization
ai-usage: ai-assisted
author: wadepickett
description: Learn how to use authentication and authorization in your ASP.NET Core apps with SignalR, and compare the process for using cookies versus bearer tokens.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 08/25/2026
uid: signalr/authn-and-authz
---

# Authentication and authorization in ASP.NET Core SignalR

:::moniker range=">= aspnetcore-6.0"

This article describes how to authenticate and authorize users in ASP.NET Core applications with SignalR.

## Authenticate users connecting to a SignalR hub

SignalR can be used with [ASP.NET Core authentication](xref:security/authentication/identity) to associate a user with each connection. In a hub, authentication data can be accessed from the <xref:Microsoft.AspNetCore.SignalR.HubConnectionContext.User?displayProperty=nameWithType> property. Authentication allows the hub to call methods on all connections associated with a user. For more information, see [Manage users and groups in SignalR](xref:signalr/groups). Multiple connections can be associated with a single user.

The following code is an example that uses SignalR and ASP.NET Core authentication:

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet1)]

> [!NOTE]
> If a token expires during the lifetime of a connection, by default the connection continues to work. `LongPolling` and `ServerSentEvents` connections fail on subsequent requests if they don't send new access tokens. For connections to close when the authentication token expires, set the [CloseOnAuthenticationExpiration](xref:signalr/configuration#configure-advanced-http-options) option.

### User and role changes during the connection lifetime

SignalR captures the authenticated user when a connection is established and caches it for the lifetime of the connection. The cached principal is exposed to hub methods through the `Context.User` property (<xref:Microsoft.AspNetCore.SignalR.HubCallerContext.User?displayProperty=nameWithType>) and is used to authorize hub method invocations. SignalR doesn't automatically revalidate the user during the life of the connection, regardless of the authentication scheme. This behavior applies to all schemes, including cookie authentication and bearer token authentication.

Changes to a user's identity, roles, or claims that occur after the connection is established aren't reflected on an existing connection. This behavior applies even when the underlying transport makes new HTTP requests, such as the `LongPolling` and `ServerSentEvents` transports. Although the ASP.NET Core authentication middleware reauthenticates each of these HTTP requests, SignalR continues to use the principal that was cached when the connection was established.

Consider the following scenario:

* An app uses cookie authentication and the `LongPolling` transport. The same behavior applies to bearer token authentication and the `ServerSentEvents` transport.
* A user is signed in with the `Editor` role and has an open SignalR connection.
* The app removes the `Editor` role from that user.

On the next long-poll request, the authentication middleware might authenticate the user without the `Editor` role. For example, this can happen if roles are loaded from a data store or the cookie is refreshed. However, the hub continues to authorize the user's `[Authorize(Roles = "Editor")]` hub method invocations because `Context.User` (<xref:Microsoft.AspNetCore.SignalR.HubCallerContext.User?displayProperty=nameWithType>) still holds the principal that was cached before the role was removed. The user can keep calling `Editor`-only hub methods until the connection is closed.

To enforce updated authorization on an active connection, take one of the following approaches:

* Close affected connections so that clients reconnect and reauthenticate. For bearer token authentication, the [CloseOnAuthenticationExpiration](xref:signalr/configuration#configure-advanced-http-options) option closes connections when the authentication token expires.
* Perform authorization checks in hub methods against current data, such as the user's current roles or claims from a data store, instead of relying only on the cached principal.

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

In .NET 11 and later, a client can refresh the credentials for an active connection without reconnecting. When the client presents an updated token, the server re-authenticates it and replaces the cached `Context.User` in place, so later hub method invocations authorize against the refreshed roles and claims. The refreshed principal must map to the same SignalR user, so a refresh updates roles and claims but doesn't change the connection's user identity or routing. For more information, see [Authentication refresh](#authentication-refresh).

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

### Cookie authentication

In a browser-based app, cookie authentication allows existing user credentials to automatically flow to SignalR connections. When the browser client is used, no extra configuration is needed. If the user is signed in to an app, the SignalR connection automatically inherits this authentication.

Cookies are a browser-specific way to send access tokens, but nonbrowser clients can send them. When the [.NET client](xref:signalr/dotnet-client) is used, the `Cookies` property can be configured in the `.WithUrl` call to provide a cookie. However, using cookie authentication from the .NET client requires the app to provide an API to exchange authentication data for a cookie.

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

[!INCLUDE[](~/includes/api-endpoint-auth.md)]

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

### Bearer token authentication

The client can provide an access token instead of using a cookie. The server validates the token and uses it to identify the user. For transports that make multiple HTTP requests (for example, `LongPolling` and `ServerSentEvents`), authentication runs on each request, but SignalR caches the resulting principal for the lifetime of the connection. As with cookie authentication, SignalR doesn't automatically revalidate the user during the life of the connection to check for token revocation or for changes to the user's roles or claims. For more information, see [User and role changes during the connection lifetime](#user-and-role-changes-during-the-connection-lifetime).

In the JavaScript client, the token can be provided by using the [accessTokenFactory](xref:signalr/configuration#configure-bearer-authentication) option.

[!code-typescript[Configure Access Token](authn-and-authz/sample/wwwroot/js/chat.ts?range=52-55)]

In the .NET client, there's a similar [AccessTokenProvider](xref:signalr/configuration#configure-bearer-authentication) property that can be used to configure the token:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", options =>
    { 
        options.AccessTokenProvider = () => Task.FromResult(_myAccessToken);
    })
    .Build();
```

> [!NOTE]
> The access token function is called before **every** HTTP request made by SignalR. If the token needs to be renewed in order to keep the connection active, do the renewal from within this function and return the updated token. The token might need to be renewed so it doesn't expire during the connection.

In standard web APIs, bearer tokens are sent in an HTTP header. However, SignalR is unable to set these headers in browsers when some transports are used. When WebSockets and Server-Sent Events are used, the token is transmitted as a query string parameter.

#### Built-in JWT authentication

On the server, bearer token authentication is configured by using the [JSON web token (JWT) Bearer middleware](xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A):

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet2&highlight=25-60)]

> [!NOTE]
> The query string is used on browsers when connecting with WebSockets and Server-Sent Events due to browser API limitations. When you use HTTPS, the TLS connection secures the query string values. However, many servers log query string values. For more information, see [Security considerations in ASP.NET Core SignalR](xref:signalr/security). SignalR uses headers to transmit tokens in environments that support them, such as the .NET and Java clients.

#### Identity Server JWT authentication

When using Duende IdentityServer, add a <xref:Microsoft.Extensions.Options.PostConfigureOptions%601> service to the project:

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/ConfigureJwtBearerOptions.cs)]

Register the service after adding services for authentication (with the <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A> method) and the authentication handler for Identity Server (with the <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A> method):

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet_i&highlight=7-11)]

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

### Authentication refresh

A SignalR connection can outlive the access token that established it. When [CloseOnAuthenticationExpiration](xref:signalr/configuration#configure-advanced-http-options) is enabled, the server closes the connection after the token expires, and the client must reconnect to continue. Messages sent during the gap are missed, and group and user routing are disrupted until the client reconnects.

Authentication refresh, available in .NET 11 and later, lets a client update the credentials for an active connection without reconnecting. The server re-authenticates the refresh request through the normal endpoint authorization pipeline and replaces the connection's <xref:System.Security.Claims.ClaimsPrincipal> in place, as long as the refreshed principal maps to the same SignalR user.

#### Enable authentication refresh on the server

Enable authentication refresh in the hub's `MapHub` options by setting `EnableAuthenticationRefresh` to `true`. Enable it together with `CloseOnAuthenticationExpiration` so that a connection whose token expires without being refreshed in time is closed, rather than left open with stale credentials:

```csharp
app.MapHub<ChatHub>("/chat", options =>
{
    options.CloseOnAuthenticationExpiration = true;
    options.EnableAuthenticationRefresh = true;
});
```

When authentication refresh is enabled and the authentication ticket has an expiration, the negotiate response reports the remaining token lifetime so the client can schedule refreshes.

To inspect or reject a refresh, set the `OnAuthenticationRefresh` callback. It runs after the refresh request is authenticated but before the connection's user is replaced. Return `false` to reject the refresh, in which case the endpoint responds with an HTTP 403 status code and the connection keeps its current user. The callback is an additional check on top of the built-in verification that the refreshed principal maps to the same SignalR user. It can reject a refresh, but it can't approve one that fails the built-in check:

```csharp
app.MapHub<ChatHub>("/chat", options =>
{
    options.CloseOnAuthenticationExpiration = true;
    options.EnableAuthenticationRefresh = true;
    options.OnAuthenticationRefresh = context =>
    {
        if (!context.NewUser.HasClaim("tenant", "contoso"))
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    };
});
```

The refreshed principal must map to the same SignalR user as the connection. If it maps to a different user ID, the refresh is rejected: the endpoint responds with an HTTP 403 status code, and the connection keeps its current user and stays connected. A refresh never changes the connection's `Context.UserIdentifier` or reroutes messages sent with `Clients.User`, even for a successful refresh. The routing identifier is fixed when the connection starts. To change it, reconnect the client.

To bound how far a refresh can extend a connection's authentication expiration, set `MaximumAuthenticationExpiration`. The refreshed expiration is capped to at most this amount of time from the current time, even when the token reports a longer lifetime. This cap applies whenever authentication refresh is enabled, including when the token doesn't set an expiration of its own. In that case, the cap gives the connection a known expiration, so the negotiate response reports a token lifetime and the client can schedule automatic refreshes. The value must be greater than zero and doesn't apply to Windows authentication, which is never tracked or refreshed.

#### Refresh authentication from the .NET client

The .NET client refreshes credentials using the `AccessTokenProvider` configured on the connection. Each refresh calls `AccessTokenProvider` to fetch a fresh access token rather than reusing the token cached when the connection started.

To refresh explicitly, call `RefreshAuthenticationAsync`, which returns the new token lifetime reported by the server:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chat", options =>
    {
        options.AccessTokenProvider = GetAccessTokenAsync;
    })
    .Build();

await connection.StartAsync();

TimeSpan? newLifetime = await connection.RefreshAuthenticationAsync();
```

To refresh automatically before the token expires, call `WithAuthenticationRefresh` and configure `AuthenticationRefreshOptions`:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chat", options =>
    {
        options.AccessTokenProvider = GetAccessTokenAsync;
    })
    .WithAuthenticationRefresh(options =>
    {
        options.RefreshBeforeExpiration = TimeSpan.FromMinutes(2);
    })
    .Build();
```

`AuthenticationRefreshOptions` provides the following settings:

* `EnableAutoRefresh`: Enables automatic refresh before the token expires. Defaults to `true`. The client only schedules a refresh when the server reports a token lifetime. If the server doesn't report a lifetime, no automatic refresh is scheduled, and `RefreshAuthenticationAsync` can still be called manually.
* `RefreshBeforeExpiration`: How far ahead of the reported expiration to refresh. Defaults to five minutes.

To observe refreshes, handle the `AuthenticationRefreshed` and `AuthenticationRefreshFailed` events on the connection. Both automatic and manual refreshes raise these events:

```csharp
connection.AuthenticationRefreshed += context =>
{
    Console.WriteLine(
        $"Authentication refreshed. New lifetime: {context.NewTokenLifetime}");
    return Task.CompletedTask;
};

connection.AuthenticationRefreshFailed += context =>
{
    Console.WriteLine(
        $"Authentication refresh failed: {context.Exception}");
    return Task.CompletedTask;
};
```

#### Refresh authentication from the JavaScript client

The JavaScript client refreshes credentials using the `accessTokenFactory` configured on the connection. Each refresh calls `accessTokenFactory` to fetch a fresh access token.

To refresh explicitly, call `refreshAuthentication`, which resolves with the new token lifetime in seconds reported by the server:

```javascript
const newLifetimeInSeconds = await connection.refreshAuthentication();
```

To refresh automatically before the token expires, call `withAuthenticationRefresh` and optionally configure `IAuthenticationRefreshOptions`. Handle refresh results with `onAuthenticationRefreshed` and `onAuthenticationRefreshFailed`:

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat", {
        accessTokenFactory: () => getAccessToken()
    })
    .withAuthenticationRefresh({
        refreshBeforeExpirationInMilliseconds: 120000
    })
    .build();

connection.onAuthenticationRefreshed(context => {
    console.log(
        `Authentication refreshed. New lifetime: ${context.newTokenLifetimeInSeconds}`);
});

connection.onAuthenticationRefreshFailed(context => {
    console.log(`Authentication refresh failed: ${context.error}`);
});
```

`IAuthenticationRefreshOptions` provides the following settings:

* `enableAutoRefresh`: Enables automatic refresh before the token expires. Defaults to `true`. As with the .NET client, automatic refresh is only scheduled when the server reports a token lifetime.
* `refreshBeforeExpirationInMilliseconds`: How far ahead of the reported expiration to refresh, in milliseconds. Defaults to 300,000 (five minutes).

#### React to a refresh in the hub

Override `OnAuthenticationRefreshedAsync` in the hub to run code after the refreshed principal is applied to the connection. `Context.User` reflects the refreshed principal. As described earlier, `Context.UserIdentifier` and SignalR user routing don't change on a refresh:

```csharp
public class ChatHub : Hub
{
    public override Task OnAuthenticationRefreshedAsync()
    {
        return Clients.Caller.SendAsync(
            "AuthenticationRefreshed", Context.UserIdentifier);
    }
}
```

A hub method that's already running keeps the `Context.User` it started with. Later invocations observe the refreshed `Context.User`. For more information about how SignalR caches the authenticated user, see [User and role changes during the connection lifetime](#user-and-role-changes-during-the-connection-lifetime).

Authentication refresh requires a connection that negotiated protocol version 1 or later. Automatic refresh is scheduled only when the server reports a token lifetime, which typically comes from an authentication scheme that sets an expiration, such as bearer tokens. Windows authentication doesn't report an expiration and isn't tracked or refreshed by this feature.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

### Cookies versus bearer tokens

Cookies are specific to browsers. Sending them from other kinds of clients adds complexity compared to sending bearer tokens. Cookie authentication isn't recommended unless the app only needs to authenticate users from the browser client. Bearer token authentication is the recommended approach when using clients other than the browser client.

### Windows authentication

If [Windows authentication](xref:security/authentication/windowsauth) is configured in the app, SignalR can use that identity to secure hubs. However, to send messages to individual users, add a custom User ID provider. The Windows authentication system doesn't provide the "Name Identifier" claim. SignalR uses the claim to determine the user name.

Add a new class that implements `IUserIdProvider` and retrieve one of the claims from the user for use as the identifier. For example, to use the "Name" claim (which is the Windows username in the form `[Domain]/[Username]`), create the following class:

[!code-csharp[Name based provider](authn-and-authz/sample/nameuseridprovider.cs?name=NameUserIdProvider)]

Rather than `ClaimTypes.Name`, use any value from the `User`, such as the Windows SID identifier, and so on.

> [!NOTE]
> The specified value must be unique among all the users in the system. Otherwise, a message intended for one user might end up reaching a different user.

Register this component in the `Program.cs` file:

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet_win&highlight=17-18)]

In the .NET client, Windows authentication must be enabled by setting the <xref:Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionOptions.UseDefaultCredentials%2A> property:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", options =>
    {
        options.UseDefaultCredentials = true;
    })
    .Build();
```

Windows authentication is supported in Microsoft Edge, but not in all browsers. For example, in Chrome and Safari, attempting to use Windows authentication and WebSockets fails. When Windows authentication fails, the client attempts to fall back to other transports, which might work.

### Use claims to customize identity handling

An app that authenticates users can derive SignalR user IDs from user claims. To specify how SignalR creates user IDs, implement `IUserIdProvider` and register the implementation.

The sample code demonstrates how to use claims to select the user's email address as the identifying property.

> [!NOTE]
> The specified value must be unique among all the users in the system. Otherwise, a message intended for one user might end up reaching a different user.

[!code-csharp[Email provider](authn-and-authz/6.0sample/SignalRAuthenticationSample/EmailBasedUserIdProvider.cs?name=EmailBasedUserIdProvider)]

The account registration adds a claim with type `ClaimsTypes.Email` to the ASP.NET identity database.

[!code-csharp[Adding the email to the ASP.NET identity claims](authn-and-authz/6.0sample/SignalRAuthenticationSample/Areas/Identity/Pages/Account/Register.cshtml.cs?name=AddEmailClaim&highlight=14)]

Register this component in the `Program.cs` file:

```csharp
builder.Services.AddSingleton<IUserIdProvider, EmailBasedUserIdProvider>();
```

## Authorize users to access hubs and hub methods

By default, an unauthenticated user can call all methods in a hub. To require authentication, apply the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> attribute to the hub:

[!code-csharp[Restrict a hub to only authorized users](authn-and-authz/sample/Hubs/ChatHub.cs?range=8-10,32)]

The constructor arguments and properties of the `[Authorize]` attribute can be used to restrict access to only users matching specific [authorization policies](xref:security/authorization/policies). For example, with the custom authorization policy called `MyAuthorizationPolicy`, only users matching that policy can access the hub by using the following code:

[!code-csharp[Restrict a hub to only authorized users](authn-and-authz/6.0sample/SignalRAuthenticationSample/Hubs/ChatPolicyHub.cs?name=snippet&highlight=1)]

The `[Authorize]` attribute can be applied to individual hub methods. If the current user doesn't match the policy applied to the method, an error is returned to the caller:

```csharp
[Authorize]
public class ChatHub : Hub
{
    public async Task Send(string message)
    {
        // ... Send a message to all users ...
    }

    [Authorize("Administrators")]
    public void BanUser(string userName)
    {
        // ... Ban a user from the chat room (something only Administrators can do) ...
    }
}
```

### Use authorization handlers to customize hub method authorization

SignalR provides a custom resource to authorization handlers when a hub method requires authorization. The resource is an instance of <xref:Microsoft.AspNetCore.SignalR.HubInvocationContext>. The `HubInvocationContext` includes the <xref:Microsoft.AspNetCore.SignalR.HubCallerContext>, the name of the hub method being invoked, and the arguments to the hub method.

Consider the example of a chat room that allows multiple organizations to sign in via Microsoft Entra ID. Anyone with a Microsoft account can sign in to chat, but only members of the owning organization should be able to ban users or view users' chat histories. Also, there might be a need to restrict some functionality from specific users. In this scenario, notice how the `DomainRestrictedRequirement` serves as a custom <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>. Because the `HubInvocationContext` resource parameter is passed in, the internal logic can inspect the context in which the hub is being called, and make decisions on allowing the user to execute individual hub methods:

```csharp
[Authorize]
public class ChatHub : Hub
{
    public void SendMessage(string message)
    {
    }

    [Authorize("DomainRestricted")]
    public void BanUser(string username)
    {
    }

    [Authorize("DomainRestricted")]
    public void ViewUserHistory(string username)
    {
    }
}
```

[!code-csharp[Restrict a hub only DomainRestrictedRequirement users](authn-and-authz/6.0sample/SignalRAuthenticationSample/DomainRestrictedRequirement.cs)]

In the `Program.cs` file, add the new policy, providing the custom `DomainRestrictedRequirement` requirement as a parameter to create the `DomainRestricted` policy:

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet_drr&highlight=19-25)]

In the preceding example, the `DomainRestrictedRequirement` class is both an `IAuthorizationRequirement` and its own `AuthorizationHandler` for that requirement. It's acceptable to split these two components into separate classes to separate concerns. The approach in this example provides the benefit of not having to inject the `AuthorizationHandler` during startup because the requirement and the handler are the same thing.

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

As an alternative to registering the `DomainRestricted` policy and referencing it with `[Authorize("DomainRestricted")]`, you can apply an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> attribute directly to a hub or hub method. SignalR combines the attribute's requirements into the effective policy for the method invocation. For more information, see <xref:security/authorization/iard>.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Additional resources

* [Bearer token authentication in ASP.NET Core (blog)](https://devblogs.microsoft.com/dotnet/bearer-token-authentication-in-asp-net-core/)
* [Resource-based authorization](xref:security/authorization/resource-based)
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/authn-and-authz/sample/) [(how to download)](xref:fundamentals/index#how-to-download-a-sample)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/authn-and-authz/sample/) [(how to download)](xref:fundamentals/index#how-to-download-a-sample)

## Authenticate users connecting to a SignalR hub

SignalR can be used with [ASP.NET Core authentication](xref:security/authentication/identity) to associate a user with each connection. In a hub, authentication data can be accessed from the <xref:Microsoft.AspNetCore.SignalR.HubConnectionContext.User?displayProperty=nameWithType> property. Authentication allows the hub to call methods on all connections associated with a user. For more information, see [Manage users and groups in SignalR](xref:signalr/groups). Multiple connections may be associated with a single user.

The following is an example of `Startup.Configure` which uses SignalR and ASP.NET Core authentication:

```csharp
public void Configure(IApplicationBuilder app)
{
    ...

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHub<ChatHub>("/chat");
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    });
}
```

> [!NOTE]
> If a token expires during the lifetime of a connection, the connection continues to work. `LongPolling` and `ServerSentEvents` connections fail on subsequent requests if they don't send new access tokens.

### Cookie authentication

In a browser-based app, cookie authentication allows your existing user credentials to automatically flow to SignalR connections. When using the browser client, no additional configuration is needed. If the user is logged in to your app, the SignalR connection automatically inherits this authentication.

Cookies are a browser-specific way to send access tokens, but non-browser clients can send them. When using the [.NET Client](xref:signalr/dotnet-client), the `Cookies` property can be configured in the `.WithUrl` call to provide a cookie. However, using cookie authentication from the .NET client requires the app to provide an API to exchange authentication data for a cookie.

### Bearer token authentication

The client can provide an access token instead of using a cookie. The server validates the token and uses it to identify the user. This validation is done only when the connection is established. During the life of the connection, the server doesn't automatically revalidate to check for token revocation.

In the JavaScript client, the token can be provided using the [accessTokenFactory](xref:signalr/configuration#configure-bearer-authentication) option.

[!code-typescript[Configure Access Token](authn-and-authz/sample/wwwroot/js/chat.ts?range=52-55)]

In the .NET client, there's a similar [AccessTokenProvider](xref:signalr/configuration#configure-bearer-authentication) property that can be used to configure the token:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", options =>
    { 
        options.AccessTokenProvider = () => Task.FromResult(_myAccessToken);
    })
    .Build();
```

> [!NOTE]
> The access token function you provide is called before **every** HTTP request made by SignalR. If you need to renew the token in order to keep the connection active (because it may expire during the connection), do so from within this function and return the updated token.

In standard web APIs, bearer tokens are sent in an HTTP header. However, SignalR is unable to set these headers in browsers when using some transports. When using WebSockets and Server-Sent Events, the token is transmitted as a query string parameter. 

#### Built-in JWT authentication

On the server, bearer token authentication is configured using the [JWT bearer middleware](xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A):

[!code-csharp[Configure Server to accept access token from Query String](authn-and-authz/sample/Startup.cs?name=snippet)]

> [!NOTE]
> The query string is used on browsers when connecting with WebSockets and Server-Sent Events due to browser API limitations. When using HTTPS, query string values are secured by the TLS connection. However, many servers log query string values. For more information, see [Security considerations in ASP.NET Core SignalR](xref:signalr/security). SignalR uses headers to transmit tokens in environments which support them (such as the .NET and Java clients).

#### Identity Server JWT authentication

When using Identity Server, add a <xref:Microsoft.Extensions.Options.PostConfigureOptions%601> service to the project:

```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
public class ConfigureJwtBearerOptions : IPostConfigureOptions<JwtBearerOptions>
{
    public void PostConfigure(string name, JwtBearerOptions options)
    {
        var originalOnMessageReceived = options.Events.OnMessageReceived;
        options.Events.OnMessageReceived = async context =>
        {
            await originalOnMessageReceived(context);
                
            if (string.IsNullOrEmpty(context.Token))
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                
                if (!string.IsNullOrEmpty(accessToken) && 
                    path.StartsWithSegments("/hubs"))
                {
                    context.Token = accessToken;
                }
            }
        };
    }
}
```

Register the service in `Startup.ConfigureServices` after adding services for authentication (<xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>) and the authentication handler for Identity Server (<xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A>):

```csharp
services.AddAuthentication()
    .AddIdentityServerJwt();
services.TryAddEnumerable(
    ServiceDescriptor.Singleton<IPostConfigureOptions<JwtBearerOptions>, 
        ConfigureJwtBearerOptions>());
```

### Cookies vs. bearer tokens 

Cookies are specific to browsers. Sending them from other kinds of clients adds complexity compared to sending bearer tokens. Consequently, cookie authentication isn't recommended unless the app only needs to authenticate users from the browser client. Bearer token authentication is the recommended approach when using clients other than the browser client.

### Windows authentication

If [Windows authentication](xref:security/authentication/windowsauth) is configured in your app, SignalR can use that identity to secure hubs. However, to send messages to individual users, you need to add a custom User ID provider. The Windows authentication system doesn't provide the "Name Identifier" claim. SignalR uses the claim to determine the user name.

Add a new class that implements `IUserIdProvider` and retrieve one of the claims from the user to use as the identifier. For example, to use the "Name" claim (which is the Windows username in the form `[Domain]\[Username]`), create the following class:

[!code-csharp[Name based provider](authn-and-authz/sample/nameuseridprovider.cs?name=NameUserIdProvider)]

Rather than `ClaimTypes.Name`, you can use any value from the `User` (such as the Windows SID identifier, and so on).

> [!NOTE]
> The value you choose must be unique among all the users in your system. Otherwise, a message intended for one user could end up going to a different user.

Register this component in your `Startup.ConfigureServices` method.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ... other services ...

    services.AddSignalR();
    services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
}
```

In the .NET Client, Windows Authentication must be enabled by setting the <xref:Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionOptions.UseDefaultCredentials%2A> property:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", options =>
    {
        options.UseDefaultCredentials = true;
    })
    .Build();
```

Windows authentication is supported in Internet Explorer and Microsoft Edge, but not in all browsers. For example, in Chrome and Safari, attempting to use Windows authentication and WebSockets fails. When Windows authentication fails, the client attempts to fall back to other transports which might work.

### Use claims to customize identity handling

An app that authenticates users can derive SignalR user IDs from user claims. To specify how SignalR creates user IDs, implement `IUserIdProvider` and register the implementation.

The sample code demonstrates how you would use claims to select the user's email address as the identifying property. 

> [!NOTE]
> The value you choose must be unique among all the users in your system. Otherwise, a message intended for one user could end up going to a different user.

[!code-csharp[Email provider](authn-and-authz/sample/EmailBasedUserIdProvider.cs?name=EmailBasedUserIdProvider)]

The account registration adds a claim with type `ClaimsTypes.Email` to the ASP.NET identity database.

[!code-csharp[Adding the email to the ASP.NET identity claims](authn-and-authz/sample/pages/account/Register.cshtml.cs?name=AddEmailClaim)]

Register this component in your `Startup.ConfigureServices`.

```csharp
services.AddSingleton<IUserIdProvider, EmailBasedUserIdProvider>();
```

## Authorize users to access hubs and hub methods

By default, all methods in a hub can be called by an unauthenticated user. To require authentication, apply the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> attribute to the hub:

[!code-csharp[Restrict a hub to only authorized users](authn-and-authz/sample/Hubs/ChatHub.cs?range=8-10,32)]

You can use the constructor arguments and properties of the `[Authorize]` attribute to restrict access to only users matching specific [authorization policies](xref:security/authorization/policies). For example, if you have a custom authorization policy called `MyAuthorizationPolicy` you can ensure that only users matching that policy can access the hub using the following code:

```csharp
[Authorize("MyAuthorizationPolicy")]
public class ChatHub : Hub
{
}
```

Individual hub methods can have the `[Authorize]` attribute applied as well. If the current user doesn't match the policy applied to the method, an error is returned to the caller:

```csharp
[Authorize]
public class ChatHub : Hub
{
    public async Task Send(string message)
    {
        // ... send a message to all users ...
    }

    [Authorize("Administrators")]
    public void BanUser(string userName)
    {
        // ... ban a user from the chat room (something only Administrators can do) ...
    }
}
```

### Use authorization handlers to customize hub method authorization

SignalR provides a custom resource to authorization handlers when a hub method requires authorization. The resource is an instance of `HubInvocationContext`. The `HubInvocationContext` includes the `HubCallerContext`, the name of the hub method being invoked, and the arguments to the hub method.

Consider the example of a chat room allowing multiple organization sign-in via Microsoft Entra ID. Anyone with a Microsoft account can sign in to chat, but only members of the owning organization should be able to ban users or view users' chat histories. Furthermore, we might want to restrict certain functionality from certain users. Using the updated features in ASP.NET Core 3.0, this is entirely possible. Note how the `DomainRestrictedRequirement` serves as a custom `IAuthorizationRequirement`. Now that the `HubInvocationContext` resource parameter is being passed in, the internal logic can inspect the context in which the Hub is being called and make decisions on allowing the user to execute individual Hub methods.

```csharp
[Authorize]
public class ChatHub : Hub
{
    public void SendMessage(string message)
    {
    }

    [Authorize("DomainRestricted")]
    public void BanUser(string username)
    {
    }

    [Authorize("DomainRestricted")]
    public void ViewUserHistory(string username)
    {
    }
}

public class DomainRestrictedRequirement : 
    AuthorizationHandler<DomainRestrictedRequirement, HubInvocationContext>, 
    IAuthorizationRequirement
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        DomainRestrictedRequirement requirement, 
        HubInvocationContext resource)
    {
        if (IsUserAllowedToDoThis(resource.HubMethodName, context.User.Identity.Name) && 
            context.User.Identity.Name.EndsWith("@microsoft.com"))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }

    private bool IsUserAllowedToDoThis(string hubMethodName,
        string currentUsername)
    {
        return !(currentUsername.Equals("asdf42@microsoft.com") && 
            hubMethodName.Equals("banUser", StringComparison.OrdinalIgnoreCase));
    }
}
```

In `Startup.ConfigureServices`, add the new policy, providing the custom `DomainRestrictedRequirement` requirement as a parameter to create the `DomainRestricted` policy.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ... other services ...

    services
        .AddAuthorization(options =>
        {
            options.AddPolicy("DomainRestricted", policy =>
            {
                policy.Requirements.Add(new DomainRestrictedRequirement());
            });
        });
}
```

In the preceding example, the `DomainRestrictedRequirement` class is both an `IAuthorizationRequirement` and its own `AuthorizationHandler` for that requirement. It's acceptable to split these two components into separate classes to separate concerns. A benefit of the example's approach is there's no need to inject the `AuthorizationHandler` during startup, as the requirement and the handler are the same thing.

## Additional resources

* [Bearer Token Authentication in ASP.NET Core](https://blogs.msdn.microsoft.com/webdev/2016/10/27/bearer-token-authentication-in-asp-net-core/)
* [Resource-based authorization](xref:security/authorization/resource-based)

:::moniker-end
