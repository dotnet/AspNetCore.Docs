---
title: Overview of ASP.NET Core Security
author: rick-anderson
description: Learn about authentication, authorization, and security basics in ASP.NET Core.
ms.author: riande
ms.custom: mvc
ms.date: 10/24/2018
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/index
---
# Overview of ASP.NET Core Security

ASP.NET Core enables developers to easily configure and manage security for their apps. ASP.NET Core contains features for managing:

* [Authentication](xref:security/authentication/index)
* [Authorization](xref:security/authorization/introduction)
* [Data protection](xref:security/data-protection/introduction)
* [HTTPS enforcement](xref:security/enforcing-ssl)
* [App secrets](xref:security/app-secrets)
* [XSRF/CSRF prevention](xref:security/anti-request-forgery)
* [Cross Origin Resource Sharing (CORS)](xref:security/cors)
* [Cross-Site Scripting (XSS) attacks](xref:security/cross-site-scripting)

These security features allow you to build robust and secure ASP.NET Core apps.

## ASP.NET Core security features

ASP.NET Core provides many tools and libraries to secure your apps including built-in identity providers, but you can use third-party identity services such as Facebook, Twitter, and LinkedIn. With ASP.NET Core, you can easily manage app secrets, which are a way to store and use confidential information without having to expose it in the code.

## Authentication vs. Authorization

[Authentication](xref:security/authentication/index) is a process in which a user provides credentials that are then compared to those stored in an operating system, database, app or resource. If they match, users authenticate successfully, and can then perform actions that they're authorized for, during an [authorization](xref:security/authorization/introduction) process. The authorization refers to the process that determines what a user is allowed to do.

Another way to think of authentication is to consider it as a way to enter a space, such as a server, database, app or resource, while authorization is which actions the user can perform to which objects inside that space (server, database, or app).

## Common Vulnerabilities in software

ASP.NET Core and EF contain features that help you secure your apps and prevent security breaches. The following list of links takes you to documentation detailing techniques to avoid the most common security vulnerabilities in web apps:

* [Cross-Site Scripting (XSS) attacks](xref:security/cross-site-scripting)
* [SQL injection attacks](/ef/core/querying/raw-sql)
* [Cross-Site Request Forgery (XSRF/CSRF) attacks](xref:security/anti-request-forgery)
* [Open redirect attacks](xref:security/preventing-open-redirects)

There are more vulnerabilities that you should be aware of. For more information, see the other articles in the **Security and Identity** section of the table of contents.

## Additional resources

* <xref:security/authentication/identity>
* <xref:security/authentication/identity-enable-qrcodes>
* <xref:security/authentication/social/index> 
