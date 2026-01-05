---
title: Identity management solutions for .NET web apps
author: guardrex
description: A list of available products, packages, and services that enable identity management, including authentication and authorization, for ASP.NET Core web apps.
ms.author: wpickett
ms.custom: mvc
ms.date: 12/22/2025
uid: security/identity-management-solutions
---
# Identity management solutions for .NET web apps

The following table provides a nonexhaustive overview of identity management solutions for ASP.NET Core apps in alphabetical order. These solutions offer features and capabilities to manage [user authentication](xref:security/authentication/index), [authorization](xref:security/authorization/introduction), and [user identity](xref:security/authentication/identity), including options for apps that are:

* Container-based.
* Self-hosted, where you manage the app's installation and infrastructure on your own hardware.
* Managed in a cloud-based service, such as [Microsoft Entra](xref:security/authentication/azure-active-directory/index).

Depending on your company size and app requirements, many commercial licenses provide "community" or free options.

Name | Type | License Type | Documentation
--- | --- | --- | ---
[ASP.NET Core Identity](xref:security/authentication/identity) | Self host | [OSS (MIT)](https://github.com/dotnet/aspnetcore/blob/main/LICENSE.txt) | <xref:security/authentication/identity>
[Auth0](https://auth0.com/) | Managed | [Commercial](https://auth0.com/pricing) | [Get started](https://auth0.com/docs/get-started)
[Duende IdentityServer](https://duendesoftware.com/products/identityserver) | Self host | [Commercial](https://duendesoftware.com/products/identityserver#pricing) | [ASP.NET Identity integration](https://docs.duendesoftware.com)
[Keycloak](https://www.keycloak.org) | Container | [OSS (Apache 2.0)](https://github.com/keycloak/keycloak/blob/master/LICENSE.txt) | [Keycloak securing apps documentation](https://www.keycloak.org/guides#securing-apps)
[Microsoft Entra ID](https://www.microsoft.com/security/business/identity-access/microsoft-entra-id) | Managed | [Commercial](https://www.microsoft.com/en-us/security/business/identity-access/microsoft-entra-id#Plansandpricing) | [Entra documentation](/entra/fundamentals/what-is-entra)
[Okta](https://www.okta.com) | Managed | [Commercial](https://www.okta.com/pricing/) | [Okta for ASP.NET Core](https://developer.okta.com/code/)
[OpenIddict](https://github.com/openiddict/openiddict-core) | Self host | [OSS (Apache 2.0)](https://github.com/openiddict/openiddict-core/blob/dev/LICENSE.md) | [OpenIddict documentation](https://documentation.openiddict.com/)
