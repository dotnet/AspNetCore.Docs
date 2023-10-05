---
title: Identity management solutions for .NET web apps
description: A list of available products, packages, and services that enable identity management, including authentication and authorization, for ASP.NET Core web apps.
author: JeremyLikness
ms.author: jeliknes
ms.date: 7/14/2023
uid: security/identity-management-solutions
---
# Identity management solutions for .NET web apps

The following table provides an overview of various identity management solutions that can be used in ASP.NET Core apps. These solutions offer features and capabilities to manage [user authentication](xref:security/authentication/index), [authorization](xref:security/authorization/introduction), and [user identity](xref:security/authentication/identity) within an app. It includes options for apps that are:

* Container-based
* Self-hosted, where you manage the installation and infrastructure to support it.
* Managed, such as cloud-based services like [Microsoft Entra](xref:security/authentication/azure-active-directory/index)

The following table lists both open source and commercial solutions in alphabetical order. Each line contains details such as license type, website, and documentation that is specific to ASP.NET Core integration. The table can help identify the identity management solutions that best align with your app's needs.

Many of the commercial licenses provide "community" or free options that may be available depending on your company size and app requirements.

<!--
|Name  |Type | License Type  |Website  |Article  |
|---------|-----|--------|---------|---------|
|**ASP.NET Core Identity**| Self host |[OSS (MIT)](https://github.com/dotnet/aspnetcore/blob/main/LICENSE.txt)|[https://dotnet.microsoft.com/](https://dotnet.microsoft.com/apps/aspnet)|[Secure a web app with ASP.NET Core Identity](/training/modules/secure-aspnet-core-identity/)|
|**Auth0**|Managed|[Commercial](https://auth0.com/pricing)|[https://auth0.com/](https://auth0.com/)|[Get started](https://auth0.com/docs/get-started)|
|**Duende IdentityServer**|Self host|[Commercial](https://duendesoftware.com/products/identityserver#pricing)|[https://duendesoftware.com/](https://duendesoftware.com/products/identityserver)|[ASP.NET Identity integration](https://docs.duendesoftware.com/identityserver/v6/aspnet_identity/)|
|**Keycloak**|Container|[OSS (Apache 2.0)](https://github.com/keycloak/keycloak/blob/master/LICENSE.txt)|[https://www.keycloak.org/](https://www.keycloak.org/)|[Keycloak client adapters documentation](https://www.keycloak.org/docs/latest/securing_apps/#client-adapters)|
|**Microsoft Entra ID**|Managed|[Commercial](https://azure.microsoft.com/pricing/details/active-directory/)|[https://azure.microsoft.com/services/active-directory/](https://azure.microsoft.com/services/active-directory/)|[Entra documentation](/azure/active-directory/fundamentals/active-directory-whatis)|
|**Okta**|Managed|[Commercial](https://www.okta.com/pricing/)|[https://www.okta.com/](https://www.okta.com/)|[Okta for ASP.NET Core](https://developer.okta.com/code/dotnet/aspnetcore/)|
|**OpenIddict**|Self host|[OSS (Apache 2.0)](https://github.com/openiddict/openiddict-core/blob/dev/LICENSE.md)|[https://github.com/openiddict/openiddict-core](https://github.com/openiddict/openiddict-core)|[OpenIddict Documentation](https://documentation.openiddict.com/)|
-->

|Name  |Type | License Type  | Documentation  |
|---------|-----|--------|---------|
|[ASP.NET Core Identity](https://dotnet.microsoft.com/apps/aspnet)| Self host |[OSS (MIT)](https://github.com/dotnet/aspnetcore/blob/main/LICENSE.txt)|[Secure a web app with ASP.NET Core Identity](/training/modules/secure-aspnet-core-identity/)|
|[Auth0](https://auth0.com/)|Managed|[Commercial](https://auth0.com/pricing)|[Get started](https://auth0.com/docs/get-started)|
|[Duende IdentityServer](https://duendesoftware.com/products/identityserver)|Self host|[Commercial](https://duendesoftware.com/products/identityserver#pricing)|[ASP.NET Identity integration](https://docs.duendesoftware.com/identityserver/v6/aspnet_identity/)|
|[Keycloak](https://www.keycloak.org)|Container|[OSS (Apache 2.0)](https://github.com/keycloak/keycloak/blob/master/LICENSE.txt)|[Keycloak client adapters documentation](https://www.keycloak.org/docs/latest/securing_apps/#client-adapters)|
|[Microsoft Entra ID](https://azure.microsoft.com/services/active-directory)|Managed|[Commercial](https://azure.microsoft.com/pricing/details/active-directory/)|[Entra documentation](/azure/active-directory/fundamentals/active-directory-whatis)|
|[Okta](https://www.okta.com)|Managed|[Commercial](https://www.okta.com/pricing/)|[Okta for ASP.NET Core](https://developer.okta.com/code/dotnet/aspnetcore/)|
|[OpenIddict](https://github.com/openiddict/openiddict-core)|Self host|[OSS (Apache 2.0)](https://github.com/openiddict/openiddict-core/blob/dev/LICENSE.md)|[OpenIddict Documentation](https://documentation.openiddict.com/)|

Is there a solution that should be added to this list? Do you have a correction, suggestion, or feedback? We welcome your contributions. Learn [how to contribute](https://github.com/dotnet/aspnetcore/blob/main/CONTRIBUTING.md).
