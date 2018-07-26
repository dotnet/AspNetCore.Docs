---
title: Overview of ASP.NET Core Security
author: tdykstra
description: Learn about authentication, authorization, and security basics in ASP.NET Core.
ms.author: tdykstra
ms.date: 11/01/2017
uid: security/index
---
# Overview of ASP.NET Core Security

ASP.NET Core enables developers to easily configure and manage security for their apps. ASP.NET Core contains features for managing authentication, authorization, data protection, SSL enforcement, app secrets, anti-request forgery protection, and CORS management. These security features allow you to build robust yet secure ASP.NET Core apps.

## ASP.NET Core security features

ASP.NET Core provides many tools and libraries to secure your apps including built-in Identity providers but you can use 3rd party identity services such as Facebook, Twitter, or LinkedIn. With ASP.NET Core, you can easily manage app secrets, which are a way to store and use confidential information without having to expose it in the code.

## Authentication vs. Authorization

Authentication is a process in which a user provides credentials that are then compared to those stored in an operating system, database, app or resource. If they match, users authenticate successfully, and can then perform actions that they're authorized for, during an authorization process. The authorization refers to the process that determines what a user is allowed to do.

Another way to think of authentication is to consider it as a way to enter a space, such as a server, database, app or resource, while authorization is which actions the user can perform to which objects inside that space (server, database, or app).

## Common Vulnerabilities in software

ASP.NET Core and EF contain features that help you secure your apps and prevent security breaches. The following list of links takes you to documentation detailing techniques to avoid the most common security vulnerabilities in web apps:

* [Cross-site scripting attacks](xref:security/cross-site-scripting)
* [SQL injection attacks](https://docs.microsoft.com/ef/core/querying/raw-sql)
* [Cross-Site Request Forgery (CSRF)](xref:security/anti-request-forgery)
* [Open redirect attacks](xref:security/preventing-open-redirects)

There are more vulnerabilities that you should be aware of. For more information, see the section in this document on *ASP.NET Security Documentation*.

## ASP.NET Security Documentation

*   [Authentication](xref:security/authentication/index)
    *   [Introduction to Identity](xref:security/authentication/identity)
    *   [Enable authentication using Facebook, Google, and other external providers](xref:security/authentication/social/index)
    *   [Enable authentication with WS-Federation](xref:security/authentication/ws-federation)
    * [Configure Windows Authentication](xref:security/authentication/windowsauth)
    *   [Account confirmation and password recovery](xref:security/authentication/accconfirm)
    *   [Two-factor authentication with SMS](xref:security/authentication/2fa)
    *   [Use cookie authentication without Identity](xref:security/authentication/cookie)
    *   [Azure Active Directory](xref:security/authentication/azure-active-directory/index)
        *   [Integrate Azure AD into an ASP.NET Core web app](https://azure.microsoft.com/documentation/samples/active-directory-dotnet-webapp-openidconnect-aspnetcore/)
        *   [Call an ASP.NET Core Web API from a WPF app using Azure AD](https://azure.microsoft.com/documentation/samples/active-directory-dotnet-native-aspnetcore/)
        *   [Call a Web API in an ASP.NET Core web app using Azure AD](https://azure.microsoft.com/documentation/samples/active-directory-dotnet-webapp-webapi-openidconnect-aspnetcore/)
        *   [An ASP.NET Core web app with Azure AD B2C](https://azure.microsoft.com/resources/samples/active-directory-b2c-dotnetcore-webapp/)
    *   [Secure ASP.NET Core apps with IdentityServer4](https://identityserver4.readthedocs.io)
*   [Authorization](xref:security/authorization/index)
    *   [Introduction](xref:security/authorization/introduction)
    *   [Create an app with user data protected by authorization](xref:security/authorization/secure-data)
    *   [Simple authorization](xref:security/authorization/simple)
    *   [Role-based authorization](xref:security/authorization/roles)
    *   [Claims-based authorization](xref:security/authorization/claims)
    *   [Policy-based authorization](xref:security/authorization/policies)
    *   [Dependency injection in requirement handlers](xref:security/authorization/dependencyinjection)
    *   [Resource-based authorization](xref:security/authorization/resourcebased)
    *   [View-based authorization](xref:security/authorization/views)
    *   [Limit identity by scheme](xref:security/authorization/limitingidentitybyscheme)
*   [Data protection](xref:security/data-protection/index)
    *   [Introduction to data protection](xref:security/data-protection/introduction)
    *   [Get started with the Data Protection APIs](xref:security/data-protection/using-data-protection)
    *   [Consumer APIs](xref:security/data-protection/consumer-apis/index)
        *   [Consumer APIs Overview](xref:security/data-protection/consumer-apis/overview)
        *   [Purpose strings](xref:security/data-protection/consumer-apis/purpose-strings)
        *   [Purpose hierarchy and multi-tenancy](xref:security/data-protection/consumer-apis/purpose-strings-multitenancy)
        *   [Hash passwords](xref:security/data-protection/consumer-apis/password-hashing)
        *   [Limit the lifetime of protected payloads](xref:security/data-protection/consumer-apis/limited-lifetime-payloads)
        *   [Unprotect payloads whose keys have been revoked](xref:security/data-protection/consumer-apis/dangerous-unprotect)
    *   [Configuration](xref:security/data-protection/configuration/index)
        *   [Configure data protection](xref:security/data-protection/configuration/overview)
        *   [Default settings](xref:security/data-protection/configuration/default-settings)
        *   [Machine-wide policy](xref:security/data-protection/configuration/machine-wide-policy)
        *   [Non DI-aware scenarios](xref:security/data-protection/configuration/non-di-scenarios)
    *   [Extensibility APIs](xref:security/data-protection/extensibility/index)
        *   [Core cryptography extensibility](xref:security/data-protection/extensibility/core-crypto)
        *   [Key management extensibility](xref:security/data-protection/extensibility/key-management)
        *   [Miscellaneous APIs](xref:security/data-protection/extensibility/misc-apis)
    *   [Implementation](xref:security/data-protection/implementation/index)
        *   [Authenticated encryption details](xref:security/data-protection/implementation/authenticated-encryption-details)
        *   [Subkey derivation and authenticated encryption](xref:security/data-protection/implementation/subkeyderivation)
        *   [Context headers](xref:security/data-protection/implementation/context-headers)
        *   [Key management](xref:security/data-protection/implementation/key-management)
        *   [Key storage providers](xref:security/data-protection/implementation/key-storage-providers)
        *   [Key encryption at rest](xref:security/data-protection/implementation/key-encryption-at-rest)
        *   [Key immutability and settings](xref:security/data-protection/implementation/key-immutability)
        *   [Key storage format](xref:security/data-protection/implementation/key-storage-format)
        *   [Ephemeral data protection providers](xref:security/data-protection/implementation/key-storage-ephemeral)
    *   [Compatibility](xref:security/data-protection/compatibility/index)
        *   [Replace <machineKey> in ASP.NET](xref:security/data-protection/compatibility/replacing-machinekey)
*   [Create an app with user data protected by authorization](xref:security/authorization/secure-data)
*   [Safe storage of app secrets in development](xref:security/app-secrets)
*   [Azure Key Vault configuration provider](xref:security/key-vault-configuration)
*   [Enforce SSL](xref:security/enforcing-ssl)
*   [Anti-Request Forgery](xref:security/anti-request-forgery)
*   [Prevent open redirect attacks](xref:security/preventing-open-redirects)
*   [Prevent Cross-Site Scripting](xref:security/cross-site-scripting)
*   [Enable Cross-Origin Requests (CORS)](xref:security/cors)
*   [Share cookies among apps](xref:security/cookie-sharing)
