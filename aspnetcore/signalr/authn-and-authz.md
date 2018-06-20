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

## Authenticate users connecting to a SignalR Hub

SignalR can be used with [ASP.NET Core Authentication](xref:security/authentication/index) to associate a User with each connection. In a Hub, authentication data can be accessed from the [`HubConnectionContext.User`](/dotnet/api/microsoft.aspnetcore.signalr.hubconnectioncontext.user?view=aspnetcore-2.1) property. Once a connection is authenticated, it is possible to invoke methods on all connections associated with a specific user. See [Manage users and groups in SignalR](xref:signalr/groups) for more information.

### Cookie Authentication

In a simple web application, cookie authentication allows your existing user credentials to automatically flow to SignalR connections. When using the browser client, no additional configuration is needed. If the user is logged in to your application, the SignalR connection will automatically inherit this authentication.

We do not recommend using Cookie authentication unless you only need to authenticate users from the browser client. When using the .NET Client, the `Cookies` property can be configured in the `.WithUrl` call in order to provide a cookie. However, this requires that you provide an API to exchange authentication data for a Cookie.

### Bearer Token Authentication

When using the .NET Client, or when your SignalR Hubs are located on a different server from your web application, we recommend using bearer token authentication. In this authentication scheme, you configure the SignalR client with an access token to send to the server. The server validates this token and uses the data within it to identify the user. The details of bearer token authentication are beyond the scope of this document, but there are some things to note when using this form of authentication in SignalR. On the server, bearer token authentication is configured using the [JWT Bearer middleware](/dotnet/api/microsoft.extensions.dependencyinjection.jwtbearerextensions.addjwtbearer?view=aspnetcore-2.1).

On the client, the access token can be provided through the `AccessTokenProvider` property in the .NET Client and the `accessTokenFactory` property in the JavaScript client (see [ASP.NET Core SignalR configuration](xref:signalr/configuration) for more information).

```
Sample of providing the access token in both .NET and JS.
```

In standard Web APIs, bearer tokens are sent via an HTTP header. However, due to security limitations imposed by browsers, the browser client is not able to set these headers when using the WebSockets or Server-Sent Events transports. When using those transports, the token is transmitted as a query string parameter. In order to support this on the server, additional configuration is required:

```
Sample of adding code to the server to retrieve the token from the query string
```

## Authorize users to access Hubs and Hub methods

By default, all methods in a Hub can be called by an unauthenticated user. In order to require authentication, apply the [`Authorize`](/dotnet/api/microsoft.aspnetcore.authorization.authorizeattribute?view=aspnetcore-2.1) attribute to the Hub:

```
Sample of applying the Authorize attribute to a Hub
```

You can use the constructor arguments and properties of the `Authorize` attribute to restrict access to only users matching specific authorization policies:

```
Sample of restricting access to a specific auth policy
```

Individual hub methods can have authorization policies applied as well:

```
Sample of restricting access to a Hub method
```