---
uid: web-api/overview/security/integrated-windows-authentication
title: "Integrated Windows Authentication | Microsoft Docs"
author: MikeWasson
description: "Describes using Integrated Windows Authentication in ASP.NET Web API."
ms.author: aspnetcontent
manager: wpickett
ms.date: 12/18/2012
ms.topic: article
ms.assetid: 71ee4c78-c500-4d1c-b761-b4e161a291b5
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/security/integrated-windows-authentication
msc.type: authoredcontent
---
Integrated Windows Authentication
====================
by [Mike Wasson](https://github.com/MikeWasson)

Integrated Windows authentication enables users to log in with their Windows credentials, using Kerberos or NTLM. The client sends credentials in the Authorization header. Windows authentication is best suited for an intranet environment. For more information, see [Windows Authentication](https://www.iis.net/configreference/system.webserver/security/authentication/windowsauthentication).

| Advantages | Disadvantages |
| --- | --- |
| - Built into IIS. - Does not send the user credentials in the request. - If the client computer belongs to the domain (for example, intranet application), the user does not need to enter credentials. | - Not recommended for Internet applications. - Requires Kerberos or NTLM support in the client. - Client must be in the Active Directory domain. |

> [!NOTE]
> If your application is hosted on Azure and you have an on-premise Active Directory domain, consider federating your on-premise AD with Azure Active Directory. That way, users can log in with their on-premise credentials, but the authentication is performed by Azure AD. For more information, see [Azure Authentication](../../../visual-studio/overview/2012/windows-azure-authentication.md).


To create an application that uses Integrated Windows authentication, select the "Intranet Application" template in the MVC 4 project wizard. This project template puts the following setting in the Web.config file:

[!code-xml[Main](integrated-windows-authentication/samples/sample1.xml)]

On the client side, Integrated Windows authentication works with any browser that supports the [Negotiate](http://www.ietf.org/rfc/rfc4559.txt) authentication scheme, which includes most major browsers. For .NET client applications, the **HttpClient** class supports Windows authentication:

[!code-csharp[Main](integrated-windows-authentication/samples/sample2.cs)]

Windows authentication is vulnerable to cross-site request forgery (CSRF) attacks. See [Preventing Cross-Site Request Forgery (CSRF) Attacks](preventing-cross-site-request-forgery-csrf-attacks.md).