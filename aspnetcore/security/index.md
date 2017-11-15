---
title: Overview of ASP.NET Core Security | Microsoft Docs
author: rachelappel
description: Learn about authentication, authorization, and security basics in ASP.NET Core
ms.author: rachelap
manager: wpickett
ms.date: 11/01/2017
ms.topic: article
ms.assetid: a8fb7eb7-e0e5-4394-84f3-1f1dbe012345
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/index
---
# ASP.NET Core Security Overview

ASP.NET Core enables developers to easily configure and manage security for their apps. ASP.NET Core contains features for managing authentication, authorization, data protection, SSL enforcement, app secrets, anti-request forgery protection, and CORS management. These security features allow you to build robust yet secure ASP.NET Core apps. 

## ASP.NET Core security features

ASP.NET Core provides many tools and libraries to secure your apps including built-in Identity providers but you can use 3rd party identity services such as Facebook, Twitter, or LinkedIn. With ASP.NET Core, you can easily manage app secrets, which are a way to store and use confidential information without having to expose it in the code. 

## Authentication vs. Authorization

Authentication is a process in which a user provides credentials that are then compared to those stored in an operating system, database, app or resource. If they match, users authenticate successfully, and can then perform actions that they are authorized for, during an authorization process. The authorization refers to the process that determines what a user is allowed to do. 

Another way to think of authentication is to consider it as a way to enter a space, such as a server, database, app or resource, while authorization is which actions the user can perform to which objects inside that space (server, database, or app).

## Common Vulnerabilities in software

ASP.NET Core and EF contain features that help you secure your apps and prevent security breaches. The following list of links takes you to documentation detailing techniques to avoid the most common security vulnerabilities in web apps:

* [Cross site scripting attacks](https://docs.microsoft.com/aspnet/core/security/cross-site-scripting)
* [SQL Injection attacks](https://docs.microsoft.com/ef/core/querying/raw-sql)
* [Cross-Site Request Forgery (CSRF)](https://docs.microsoft.com/aspnet/core/security/anti-request-forgery)
* [Open redirect attacks](https://docs.microsoft.com/aspnet/core/security/preventing-open-redirects)

There are more vulnerabilities that you should be aware of. For more information, see the section in this document on *ASP.NET Security Documentation*. 

## ASP.NET Security Documentation

*   [Authentication](authentication/index.md)
    *   [Introduction to Identity](authentication/identity.md)
    *   [Enabling authentication using Facebook, Google and other external providers](authentication/social/index.md)
    * [Configure Windows Authentication](authentication/windowsauth.md)
    *   [Account Confirmation and Password Recovery](authentication/accconfirm.md)
    *   [Two-factor authentication with SMS](authentication/2fa.md) 
    *   [Using Cookie Authentication without ASP.NET Core Identity](authentication/cookie.md)
    *   [Azure Active Directory](authentication/azure-active-directory/index.md)
        *   [Integrating Azure AD Into an ASP.NET Core Web App](https://azure.microsoft.com/documentation/samples/active-directory-dotnet-webapp-openidconnect-aspnetcore/)
        *   [Calling a ASP.NET Core Web API From a WPF Application Using Azure AD](https://azure.microsoft.com/documentation/samples/active-directory-dotnet-native-aspnetcore/)
        *   [Calling a Web API in an ASP.NET Core Web Application Using Azure AD](https://azure.microsoft.com/documentation/samples/active-directory-dotnet-webapp-webapi-openidconnect-aspnetcore/)
        *   [An ASP.NET Core web app with Azure AD B2C](https://azure.microsoft.com/resources/samples/active-directory-b2c-dotnetcore-webapp/)
    *   [Securing ASP.NET Core apps with IdentityServer4](https://identityserver4.readthedocs.io)
*   [Authorization](authorization/index.md)
    *   [Introduction](authorization/introduction.md)
    *   [Create an app with user data protected by authorization](xref:security/authorization/secure-data)
    *   [Simple Authorization](authorization/simple.md)
    *   [Role based Authorization](authorization/roles.md)
    *   [Claims-Based Authorization](authorization/claims.md)
    *   [Custom Policy-Based Authorization](authorization/policies.md)
    *   [Dependency Injection in requirement handlers](authorization/dependencyinjection.md)
    *   [Resource-based authorization](authorization/resourcebased.md)
    *   [View-based authorization](authorization/views.md)
    *   [Limiting identity by scheme](authorization/limitingidentitybyscheme.md)
*   [Data Protection](data-protection/index.md)
    *   [Introduction to Data Protection](data-protection/introduction.md)
    *   [Getting Started with the Data Protection APIs](data-protection/using-data-protection.md)
    *   [Consumer APIs](data-protection/consumer-apis/index.md)
        *   [Consumer APIs Overview](data-protection/consumer-apis/overview.md)
        *   [Purpose Strings](data-protection/consumer-apis/purpose-strings.md)
        *   [Purpose hierarchy and multi-tenancy](data-protection/consumer-apis/purpose-strings-multitenancy.md)
        *   [Password Hashing](data-protection/consumer-apis/password-hashing.md)
        *   [Limiting the lifetime of protected payloads](data-protection/consumer-apis/limited-lifetime-payloads.md)
        *   [Unprotecting payloads whose keys have been revoked](data-protection/consumer-apis/dangerous-unprotect.md)
    *   [Configuration](data-protection/configuration/index.md)
        *   [Configuring Data Protection](data-protection/configuration/overview.md)
        *   [Default Settings](data-protection/configuration/default-settings.md)
        *   [Machine Wide Policy](data-protection/configuration/machine-wide-policy.md)
        *   [Non DI Aware Scenarios](data-protection/configuration/non-di-scenarios.md)
    *   [Extensibility APIs](data-protection/extensibility/index.md)
        *   [Core cryptography extensibility](data-protection/extensibility/core-crypto.md)
        *   [Key management extensibility](data-protection/extensibility/key-management.md)
        *   [Miscellaneous APIs](data-protection/extensibility/misc-apis.md)
    *   [Implementation](data-protection/implementation/index.md)
        *   [Authenticated encryption details](data-protection/implementation/authenticated-encryption-details.md)
        *   [Subkey Derivation and Authenticated Encryption](data-protection/implementation/subkeyderivation.md)
        *   [Context headers](data-protection/implementation/context-headers.md)
        *   [Key Management](data-protection/implementation/key-management.md)
        *   [Key Storage Providers](data-protection/implementation/key-storage-providers.md)
        *   [Key Encryption At Rest](data-protection/implementation/key-encryption-at-rest.md)
        *   [Key Immutability and Changing Settings](data-protection/implementation/key-immutability.md)
        *   [Key Storage Format](data-protection/implementation/key-storage-format.md)
        *   [Ephemeral data protection providers](data-protection/implementation/key-storage-ephemeral.md)
    *   [Compatibility](data-protection/compatibility/index.md)
        *   [Sharing cookies between applications](data-protection/compatibility/cookie-sharing.md)
        *   [Replacing <machineKey> in ASP.NET](data-protection/compatibility/replacing-machinekey.md)
*   [Create an app with user data protected by authorization](xref:security/authorization/secure-data)
*   [Safe storage of app secrets during development](app-secrets.md)
*   [Azure Key Vault configuration provider](key-vault-configuration.md)
*   [Enforcing SSL](enforcing-ssl.md)
*   [Anti-Request Forgery](anti-request-forgery.md)
*   [Preventing Open Redirect Attacks](preventing-open-redirects.md)
*   [Preventing Cross-Site Scripting](cross-site-scripting.md)
*   [Enabling Cross-Origin Requests (CORS)](cors.md)
