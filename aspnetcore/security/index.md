---
title: Security
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: a8fb7eb7-e0e5-4394-84f3-1f1dbe012345
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/index
---
# Security

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
    *   [Resource Based Authorization](authorization/resourcebased.md)
    *   [View Based Authorization](authorization/views.md)
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
        *   [Authenticated encryption details.](data-protection/implementation/authenticated-encryption-details.md)
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
*   [Setting up HTTPS for development](https.md)
*   [Anti-Request Forgery](anti-request-forgery.md)
*   [Preventing Open Redirect Attacks](preventing-open-redirects.md)
*   [Preventing Cross-Site Scripting](cross-site-scripting.md)
*   [Enabling Cross-Origin Requests (CORS)](cors.md)
