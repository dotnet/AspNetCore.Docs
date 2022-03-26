---
title: Authentication and authorization in ASP.NET Core SignalR
author: bradygaster
description: Learn how to use authentication and authorization in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-3.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 2/05/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: signalr/authn-and-authz
---

# Authentication and authorization in ASP.NET Core SignalR

:::moniker range=">= aspnetcore-6.0"

## Authenticate users connecting to a SignalR hub

SignalR can be used with [ASP.NET Core authentication](xref:security/authentication/identity) to associate a user with each connection. In a hub, authentication data can be accessed from the <xref:Microsoft.AspNetCore.SignalR.HubConnectionContext.User?displayProperty=nameWithType> property. Authentication allows the hub to call methods on all connections associated with a user. For more information, see [Manage users and groups in SignalR](xref:signalr/groups). Multiple connections may be associated with a single user.

The following code is an example that uses SignalR and ASP.NET Core authentication:

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet1)]

> [!NOTE]
> If a token expires during the lifetime of a connection, by default the connection continues to work. `LongPolling` and `ServerSentEvent` connections fail on subsequent requests if they don't send new access tokens. For connections to close when the authentication token expires, set [CloseOnAuthenticationExpiration](xref:signalr/configuration#advanced-http-configuration-options).

### Cookie authentication

In a browser-based app, cookie authentication allows existing user credentials to automatically flow to SignalR connections. When using the browser client, no extra configuration is needed. If the user is logged in to an app, the SignalR connection automatically inherits this authentication.

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
> The access token function provided is called before **every** HTTP request made by SignalR. If the token needs to be renewed in order to keep the connection active, do so from within this function and return the updated token. The token may need to be renewed so it doesn't expire during the connection.

In standard web APIs, bearer tokens are sent in an HTTP header. However, SignalR is unable to set these headers in browsers when using some transports. When using WebSockets and Server-Sent Events, the token is transmitted as a query string parameter.

#### Built-in JWT authentication

On the server, bearer token authentication is configured using the [JWT Bearer middleware](xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A):

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet2&highlight=25-60)]

> [!NOTE]
> The query string is used on browsers when connecting with WebSockets and Server-Sent Events due to browser API limitations. When using HTTPS, query string values are secured by the TLS connection. However, many servers log query string values. For more information, see [Security considerations in ASP.NET Core SignalR](xref:signalr/security). SignalR uses headers to transmit tokens in environments which support them (such as the .NET and Java clients).

#### Identity Server JWT authentication

When using Duende IdentityServer  add a <xref:Microsoft.Extensions.Options.PostConfigureOptions%601> service to the project:

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/ConfigureJwtBearerOptions.cs)]

Register the service after adding services for authentication (<xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>) and the authentication handler for Identity Server (<xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A>):

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet_i&highlight=7-11)]

### Cookies vs. bearer tokens

Cookies are specific to browsers. Sending them from other kinds of clients adds complexity compared to sending bearer tokens. Cookie authentication isn't recommended unless the app only needs to authenticate users from the browser client. Bearer token authentication is the recommended approach when using clients other than the browser client.

### Windows authentication

If [Windows authentication](xref:security/authentication/windowsauth) is configured in the app, SignalR can use that identity to secure hubs. However, to send messages to individual users, add a custom User ID provider. The Windows authentication system doesn't provide the "Name Identifier" claim. SignalR uses the claim to determine the user name.

Add a new class that implements `IUserIdProvider` and retrieve one of the claims from the user to use as the identifier. For example, to use the "Name" claim (which is the Windows username in the form `[Domain]/[Username]`), create the following class:

[!code-csharp[Name based provider](authn-and-authz/sample/nameuseridprovider.cs?name=NameUserIdProvider)]

Rather than `ClaimTypes.Name`, use any value from the `User`, such as the Windows SID identifier, etc.

> [!NOTE]
> The value chosen must be unique among all the users in the system. Otherwise, a message intended for one user could end up going to a different user.

Register this component in `Program.cs`:

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet_win&highlight=17-18)]

In the .NET Client, Windows Authentication must be enabled by setting the <xref:Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionOptions.UseDefaultCredentials%2A> property:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chathub", options =>
    {
        options.UseDefaultCredentials = true;
    })
    .Build();
```

<!--The Internet Explorer 11 desktop application will be retired and go out of support on June 15, 2022  https://docs.microsoft.com/en-us/troubleshoot/developer/browsers/security-privacy/prompt-for-username-and-password -->
Windows authentication is supported in Microsoft Edge, but not in all browsers. For example, in Chrome and Safari, attempting to use Windows authentication and WebSockets fails. When Windows authentication fails, the client attempts to fall back to other transports which might work.

### Use claims to customize identity handling

An app that authenticates users can derive SignalR user IDs from user claims. To specify how SignalR creates user IDs, implement `IUserIdProvider` and register the implementation.

The sample code demonstrates how to use claims to select the user's email address as the identifying property.

> [!NOTE]
> The value chosen must be unique among all the users in the system. Otherwise, a message intended for one user could end up going to a different user.

[!code-csharp[Email provider](authn-and-authz/6.0sample/SignalRAuthenticationSample/EmailBasedUserIdProvider.cs?name=EmailBasedUserIdProvider)]

The account registration adds a claim with type `ClaimsTypes.Email` to the ASP.NET identity database.

[!code-csharp[Adding the email to the ASP.NET identity claims](authn-and-authz/6.0sample/SignalRAuthenticationSample/Areas/Identity/Pages/Account/Register.cshtml.cs?name=AddEmailClaim&highlight=14)]

Register this component in `Program.cs`:

```csharp
builder.Services.AddSingleton<IUserIdProvider, EmailBasedUserIdProvider>();
```

## Authorize users to access hubs and hub methods

By default, all methods in a hub can be called by an unauthenticated user. To require authentication, apply the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> attribute to the hub:

[!code-csharp[Restrict a hub to only authorized users](authn-and-authz/sample/Hubs/ChatHub.cs?range=8-10,32)]

The constructor arguments and properties of the `[Authorize]` attribute can be used to restrict access to only users matching specific [authorization policies](xref:security/authorization/policies). For example, with the custom authorization policy called `MyAuthorizationPolicy`, only users matching that policy can access the hub using the following code:

[!code-csharp[Restrict a hub to only authorized users](authn-and-authz/6.0sample/SignalRAuthenticationSample/Hubs/ChatPolicyHub.cs?name=snippet&highlight=1)]

The `[Authorize]` attribute can be applied to individual hub methods. If the current user doesn't match the policy applied to the method, an error is returned to the caller:

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

SignalR provides a custom resource to authorization handlers when a hub method requires authorization. The resource is an instance of <xref:Microsoft.AspNetCore.SignalR.HubInvocationContext>. The `HubInvocationContext` includes the <xref:Microsoft.AspNetCore.SignalR.HubCallerContext>, the name of the hub method being invoked, and the arguments to the hub method.

Consider the example of a chat room allowing multiple organization sign-in via Azure Active Directory. Anyone with a Microsoft account can sign in to chat, but only members of the owning organization should be able to ban users or view users' chat histories. Furthermore, we might want to restrict some functionality from specific users. Note how the `DomainRestrictedRequirement` serves as a custom <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>. Now that the `HubInvocationContext` resource parameter is being passed in, the internal logic can inspect the context in which the Hub is being called and make decisions on allowing the user to execute individual Hub methods:

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

In `Program.cs`, add the new policy, providing the custom `DomainRestrictedRequirement` requirement as a parameter to create the `DomainRestricted` policy:

[!code-csharp[](authn-and-authz/6.0sample/SignalRAuthenticationSample/Program.cs?name=snippet_drr&highlight=19-25)]

In the preceding example, the `DomainRestrictedRequirement` class is both an `IAuthorizationRequirement` and its own `AuthorizationHandler` for that requirement. It's acceptable to split these two components into separate classes to separate concerns. A benefit of the example's approach is there's no need to inject the `AuthorizationHandler` during startup, as the requirement and the handler are the same thing.

## Additional resources

* [Bearer Token Authentication in ASP.NET Core](https://blogs.msdn.microsoft.com/webdev/2016/10/27/bearer-token-authentication-in-asp-net-core/)
* [Resource-based Authorization](xref:security/authorization/resourcebased)
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/authn-and-authz/sample/) [(how to download)](xref:index#how-to-download-a-sample)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/authn-and-authz/sample/) [(how to download)](xref:index#how-to-download-a-sample)

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
> If a token expires during the lifetime of a connection, the connection continues to work. `LongPolling` and `ServerSentEvent` connections fail on subsequent requests if they don't send new access tokens.

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

On the server, bearer token authentication is configured using the [JWT Bearer middleware](xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A):

[!code-csharp[Configure Server to accept access token from Query String](authn-and-authz/sample/Startup.cs?name=snippet)]

[!INCLUDE[request localized comments](~/includes/code-comments-loc.md)]

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

Consider the example of a chat room allowing multiple organization sign-in via Azure Active Directory. Anyone with a Microsoft account can sign in to chat, but only members of the owning organization should be able to ban users or view users' chat histories. Furthermore, we might want to restrict certain functionality from certain users. Using the updated features in ASP.NET Core 3.0, this is entirely possible. Note how the `DomainRestrictedRequirement` serves as a custom `IAuthorizationRequirement`. Now that the `HubInvocationContext` resource parameter is being passed in, the internal logic can inspect the context in which the Hub is being called and make decisions on allowing the user to execute individual Hub methods.

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
* [Resource-based Authorization](xref:security/authorization/resourcebased)

:::moniker-end
