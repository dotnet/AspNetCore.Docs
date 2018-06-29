---
title: Authentication and Authorization in SignalR
author: rachelappel
description: Learn how to use authentication and authorization in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.custom: mvc
ms.date: 05/01/2018
uid: signalr/authn-and-authz
---

# Authentication and authorization in SignalR

By [Andrew Stanton-Nurse](https://twitter.com/anurse)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/authn-and-authz/sample/ ) [(how to download)](xref:tutorials/index#how-to-download-a-sample)

## Authenticate users connecting to a SignalR Hub

SignalR can be used with [ASP.NET Core Authentication](xref:security/authentication/index) to associate a User with each connection. In a Hub, authentication data can be accessed from the [`HubConnectionContext.User`](/dotnet/api/microsoft.aspnetcore.signalr.hubconnectioncontext.user?view=aspnetcore-2.1) property. Once a connection is authenticated, it is possible to invoke methods on all connections associated with a specific user. See [Manage users and groups in SignalR](xref:signalr/groups) for more information.

### Cookie Authentication

In a simple web application, cookie authentication allows your existing user credentials to automatically flow to SignalR connections. When using the browser client, no additional configuration is needed. If the user is logged in to your application, the SignalR connection will automatically inherit this authentication.

We do not recommend using Cookie authentication unless you only need to authenticate users from the browser client. When using the .NET Client, the `Cookies` property can be configured in the `.WithUrl` call in order to provide a cookie. However, this requires that you provide an API to exchange authentication data for a Cookie.

### Bearer Token Authentication

When using the .NET Client, or when your SignalR Hubs are located on a different server from your web application, we recommend using bearer token authentication. In this authentication scheme, you configure the SignalR client with an access token to send to the server. The server validates this token and uses the data within it to identify the user. The details of bearer token authentication are beyond the scope of this document, but there are some things to note when using this form of authentication in SignalR. On the server, bearer token authentication is configured using the [JWT Bearer middleware](/dotnet/api/microsoft.extensions.dependencyinjection.jwtbearerextensions.addjwtbearer?view=aspnetcore-2.1).

In the JavaScript client, the token can be provided using the `accessTokenFactory` option.

[!code-javascript[Configure Access Token](authn-and-authz/sample/wwwroot/js/chat.js?range=63-65)]

In the .NET client, there is a simlar `AccessTokenProvider` property that can be used to configure this:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/myhub", options => options.AccessTokenProvider = () => _myAccessToken)
    .Build();
```

> [!NOTE]
> This function is called before **every** HTTP request made by SignalR. This means that if you need to renew the token in order to keep the connection active (because it may expire during the connection) you can do so from within this function and SignalR will automatically start using the new token.

In standard Web APIs, bearer tokens are sent via an HTTP header. However, due to security limitations imposed by browsers, the browser client is not able to set these headers when using the WebSockets or Server-Sent Events transports. When using those transports, the token is transmitted as a query string parameter. In order to support this on the server, additional configuration is required:

[!code-csharp[Configure Server to accept access token from Query String](authn-and-authz/sample/Startup.cs?range=42-80)]

### Windows Authentication

If you have configured [Windows Authentication](xref:security/windowsauth) in your application, SignalR can use that authentication to secure Hubs. However, in order to send messages to individual users, you need to add a custom User ID provider, because the Windows Authentication system does not provide the "Name Identifier" claim that SignalR uses to determine the user name. To do this, add a new class that implements `IUserIdProvider` and retrieve one of the claims from the user to use as the identifier. For example, to use the "Name" claim (which is the Windows username in the form `[Domain]\[Username]`), create the following class:

```csharp
public class NameUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        return connection.User?.FindFirst(ClaimTypes.Name)?.Value;
    }
}
```

Instead of `ClaimTypes.Name`, you can use any value from the `User` (such as the Windows SID identifier, etc.).

> [!NOTE]
> The value you choose must be unique among all the users in your system. Otherwise, a message intended for one user could end up going to a different user.

Then, register this component in your `ConfigureServices` method **after** the call to `.AddSignalR`

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ... other services ...

    services.AddSignalR();
    services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
}
```

## Authorize users to access Hubs and Hub methods

By default, all methods in a Hub can be called by an unauthenticated user. In order to require authentication, apply the [`Authorize`](/dotnet/api/microsoft.aspnetcore.authorization.authorizeattribute?view=aspnetcore-2.1) attribute to the Hub:

[!code-csharp[Restrict a Hub to only authorized users](authn-and-authz/sample/Hubs/ChatHub.cs?range=8-10,33)]

You can use the constructor arguments and properties of the `Authorize` attribute to restrict access to only users matching specific [authorization policies](xref:security/authorization/policies). For example, if you have a custom authorization policy called `MyAuthorizationPolicy` you can ensure that only users matching that policy can access the hub using the following code:

```csharp
[Authorize("MyAuthorizationPolicy")]
public class ChatHub: Hub
{
}
```

Individual hub methods can have the `Authorize` attribute applied as well. If the current user does not match the policy applied to the method, an error will be returned to the caller:

```csharp
[Authorize]
public class ChatHub: Hub
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