---
uid: signalr/overview/security/hub-authorization
title: "Authentication and Authorization for SignalR Hubs | Microsoft Docs"
author: pfletcher
description: "This topic describes how to restrict which users or roles can access hub methods. Software versions used in this topic Visual Studio 2013 .NET 4.5 SignalR ve..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/05/2015
ms.topic: article
ms.assetid: a610c796-c131-473c-baef-2e6c568cb2a2
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/security/hub-authorization
msc.type: authoredcontent
---
Authentication and Authorization for SignalR Hubs
====================
by [Patrick Fletcher](https://github.com/pfletcher), [Tom FitzMacken](https://github.com/tfitzmac)

> This topic describes how to restrict which users or roles can access hub methods. 
> 
> ## Software versions used in this topic
> 
> 
> - [Visual Studio 2013](https://www.microsoft.com/visualstudio/eng/2013-downloads)
> - .NET 4.5
> - SignalR version 2
>   
> 
> 
> ## Previous versions of this topic
> 
> For information about earlier versions of SignalR, see [SignalR Older Versions](../older-versions/index.md).
> 
> ## Questions and comments
> 
> Please leave feedback on how you liked this tutorial and what we could improve in the comments at the bottom of the page. If you have questions that are not directly related to the tutorial, you can post them to the [ASP.NET SignalR forum](https://forums.asp.net/1254.aspx/1?ASP+NET+SignalR) or [StackOverflow.com](http://stackoverflow.com/).


## Overview

This topic contains the following sections:

- [Authorize attribute](#authorizeattribute)
- [Require authentication for all hubs](#requireauth)
- [Customized authorization](#custom)
- [Pass authentication information to clients](#passauth)
- [Authentication options for .NET clients](#authoptions)

    - [Cookie with Forms Authentication](#cookie)
    - [Windows Authentication](#windows)
    - [Connection header](#header)
    - [Certificate](#certificate)

<a id="authorizeattribute"></a>

## Authorize attribute

SignalR provides the [Authorize](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.authorizeattribute(v=vs.111).aspx) attribute to specify which users or roles have access to a hub or method. This attribute is located in the `Microsoft.AspNet.SignalR` namespace. You apply the `Authorize` attribute to either a hub or particular methods in a hub. When you apply the `Authorize` attribute to a hub class, the specified authorization requirement is applied to all of the methods in the hub. This topic provides examples of the different types of authorization requirements that you can apply. Without the `Authorize` attribute, a connected client can access any public method on the hub.

If you have defined a role named "Admin" in your web application, you could specify that only users in that role can access a hub with the following code.

[!code-csharp[Main](hub-authorization/samples/sample1.cs)]

Or, you can specify that a hub contains one method that is available to all users, and a second method that is only available to authenticated users, as shown below.

[!code-csharp[Main](hub-authorization/samples/sample2.cs)]

The following examples address different authorization scenarios:

- `[Authorize]` – only authenticated users
- `[Authorize(Roles = "Admin,Manager")]` – only authenticated users in the specified roles
- `[Authorize(Users = "user1,user2")]` – only authenticated users with the specified user names
- `[Authorize(RequireOutgoing=false)]` – only authenticated users can invoke the hub, but calls from the server back to clients are not limited by authorization, such as, when only certain users can send a message but all others can receive the message. The RequireOutgoing property can only be applied to the entire hub, not on individuals methods within the hub. When RequireOutgoing is not set to false, only users that meet the authorization requirement are called from the server.

<a id="requireauth"></a>

## Require authentication for all hubs

You can require authentication for all hubs and hub methods in your application by calling the [RequireAuthentication](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.hubpipelineextensions.requireauthentication(v=vs.111).aspx) method when the application starts. You might use this method when you have multiple hubs and want to enforce an authentication requirement for all of them. With this method, you cannot specify requirements for role, user, or outgoing authorization. You can only specify that access to the hub methods is restricted to authenticated users. However, you can still apply the Authorize attribute to hubs or methods to specify additional requirements. Any requirement you specify in an attribute is added to the basic requirement of authentication.

The following example shows a Startup file which restricts all hub methods to authenticated users.

[!code-csharp[Main](hub-authorization/samples/sample3.cs)]

If you call the `RequireAuthentication()` method after a SignalR request has been processed, SignalR will throw a `InvalidOperationException` exception. SignalR throws this exception because you cannot add a module to the HubPipeline after the pipeline has been invoked. The previous example shows calling the `RequireAuthentication` method in the `Configuration` method which is executed one time prior to handling the first request.

<a id="custom"></a>

## Customized authorization

If you need to customize how authorization is determined, you can create a class that derives from `AuthorizeAttribute` and override the [UserAuthorized](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.authorizeattribute.userauthorized(v=vs.111).aspx) method. For each request, SignalR invokes this method to determine whether the user is authorized to complete the request. In the overridden method, you provide the necessary logic for your authorization scenario. The following example shows how to enforce authorization through claims-based identity.

[!code-csharp[Main](hub-authorization/samples/sample4.cs)]

<a id="passauth"></a>

## Pass authentication information to clients

You may need to use authentication information in the code that runs on the client. You pass the required information when calling the methods on the client. For example, a chat application method could pass as a parameter the user name of the person posting a message, as shown below.

[!code-csharp[Main](hub-authorization/samples/sample5.cs)]

Or, you can create an object to represent the authentication information and pass that object as a parameter, as shown below.

[!code-csharp[Main](hub-authorization/samples/sample6.cs)]

You should never pass one client's connection id to other clients, as a malicious user could use it to mimic a request from that client.

<a id="authoptions"></a>

## Authentication options for .NET clients

When you have a .NET client, such as a console app, which interacts with a hub that is limited to authenticated users, you can pass the authentication credentials in a cookie, the connection header, or a certificate. The examples in this section show how to use those different methods for authenticating a user. They are not fully-functional SignalR apps. For more information about .NET clients with SignalR, see [Hubs API Guide - .NET Client](../guide-to-the-api/hubs-api-guide-net-client.md).

<a id="cookie"></a>

### Cookie

When your .NET client interacts with a hub that uses ASP.NET Forms Authentication, you will need to manually set the authentication cookie on the connection. You add the cookie to the `CookieContainer` property on the [HubConnection](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.hubs.hubconnection(v=vs.111).aspx) object. The following example shows a console app that retrieves an authentication cookie from a web page and adds that cookie to the connection.

[!code-csharp[Main](hub-authorization/samples/sample7.cs)]

The console app posts the credentials to **www.contoso.com/RemoteLogin** which could refer to an empty page that contains the following code-behind file.

[!code-csharp[Main](hub-authorization/samples/sample8.cs)]

<a id="windows"></a>

### Windows authentication

When using Windows authentication, you can pass the current user's credentials by using the [DefaultCredentials](https://msdn.microsoft.com/en-us/library/system.net.credentialcache.defaultcredentials.aspx) property. You set the credentials for the connection to the value of the DefaultCredentials.

[!code-csharp[Main](hub-authorization/samples/sample9.cs?highlight=6)]

<a id="header"></a>

### Connection header

If your application is not using cookies, you can pass user information in the connection header. For example, you can pass a token in the connection header.

[!code-csharp[Main](hub-authorization/samples/sample10.cs?highlight=6)]

Then, in the hub, you would verify the user's token.

<a id="certificate"></a>

### Certificate

You can pass a client certificate to verify the user. You add the certificate when creating the connection. The following example shows only how to add a client certificate to the connection; it does not show the full console app. It uses the [X509Certificate](https://msdn.microsoft.com/en-us/library/system.security.cryptography.x509certificates.x509certificate.aspx) class which provides several different ways to create the certificate.

[!code-csharp[Main](hub-authorization/samples/sample11.cs?highlight=6)]