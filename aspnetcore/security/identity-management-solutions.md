---
title: Identity management solutions for .NET web apps
description: A list of available products, packages, and services that enable identity management, including authentication and authorization, for ASP.NET Core web apps.
author: JeremyLikness
ms.author: jeliknes
ms.date: 6/14/2023
uid: security/identity-management-solutions
---
# Identity management solutions for .NET web apps

The following table provides an overview of various identity management solutions that developers can use in their ASP.NET Core applications. These solutions offer features and capabilities to manage [user authentication](xref:security/authentication/index), [authorization](xref:security/authorization/introduction), and [user identity](xref:security/authentication/identity) within your application. It includes options for container-based solutions, self-hosted (you manage the installation and infrastructure to support it), and managed (cloud-based or "identity-as-a-service"). 

 The table lists both open source and commercial solutions in alphabetical order, each accompanied by essential details such as license type, website, and documentation that is specific to ASP.NET Core integration. Explore the table below to discover the identity management solutions that best align with your application needs.

> [!TIP]
> Many of the commercial licenses provide "community" and/or free options that may be available depending on your company size and application requirements.

|Name  |Type | License Type  |Website  |Docs  |
|---------|-----|--------|---------|---------|
|**ASP.NET Core Identity**| Self host |[OSS (MIT)](https://github.com/dotnet/aspnetcore/blob/main/LICENSE.txt)|[https://dotnet.microsoft.com/](https://dotnet.microsoft.com/apps/aspnet)|[Secure a web app with ASP.NET Core Identity](/training/modules/secure-aspnet-core-identity/)|
|**Auth0**|Managed|[Commercial](https://auth0.com/pricing)|[https://auth0.com/](https://auth0.com/)|[Get started](https://auth0.com/docs/get-started)|
|**Duende IdentityServer**|Self host|[Commercial](https://duendesoftware.com/products/identityserver#pricing)|[https://duendesoftware.com/](https://duendesoftware.com/products/identityserver)|[ASP.NET Identity integration](https://docs.duendesoftware.com/identityserver/v6/aspnet_identity/)|
|**Microsoft Azure AD**|Managed|[Commercial](https://azure.microsoft.com/pricing/details/active-directory/)|[https://azure.microsoft.com/services/active-directory/](https://azure.microsoft.com/services/active-directory/)|[Azure AD documentation](/azure/active-directory/)|
|**OpenIddict**|Self host|[OSS (Apache 2.0)](https://github.com/openiddict/openiddict-core/blob/dev/LICENSE.md)|[https://www.openiddict.com/](https://www.openiddict.com/)|[OpenIddict Documentation](https://documentation.openiddict.com/)|
|**Keycloak**|Container|[OSS (Apache 2.0)](https://github.com/keycloak/keycloak/blob/master/LICENSE.txt)|[https://www.keycloak.org/](https://www.keycloak.org/)|[Keycloak client adapters documentation](https://www.keycloak.org/docs/latest/securing_apps/#client-adapters)|
|**Okta**|Managed|[Commercial](https://www.okta.com/pricing/)|[https://www.okta.com/](https://www.okta.com/)|[Okta for ASP.NET Core](https://developer.okta.com/code/dotnet/aspnetcore/)|

Is there a solution that should be added to this list? Do you have a correction, suggestion, or feedback? We welcome your contributions. Learn [how to contribute](https://github.com/dotnet/aspnetcore/blob/main/CONTRIBUTING.md).
