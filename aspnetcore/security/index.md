---
title: ASP.NET Core security topics
author: tdykstra
description: Provides links to articles on authentication, authorization, and security in ASP.NET Core.
ms.author: riande
ms.custom: mvc
ms.date: 3/9/2022
uid: security/index
---
# ASP.NET Core security topics

ASP.NET Core enables developers to configure and manage security. The following list provides links to security topics:

* [Authentication](xref:security/authentication/index)
* [Authorization](xref:security/authorization/introduction)
* [Data protection](xref:security/data-protection/introduction)
* [HTTPS enforcement](xref:security/enforcing-ssl)
* [Safe storage of app secrets in development](xref:security/app-secrets)
* [XSRF/CSRF prevention](xref:security/anti-request-forgery)
* [Cross Origin Resource Sharing (CORS)](xref:security/cors)
* [Cross-Site Scripting (XSS) attacks](xref:security/cross-site-scripting)

These security features allow you to build robust and secure ASP.NET Core apps.

## ASP.NET Core security features

ASP.NET Core provides many tools and libraries to secure ASP.NET Core apps such as built-in identity providers and third-party identity services such as Facebook, Twitter, and LinkedIn. ASP.NET Core provides several approaches to store app secrets.

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
* <xref:security/identity-management-solutions>
