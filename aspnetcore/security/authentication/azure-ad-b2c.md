---
title: Cloud authentication with Azure Active Directory B2C in ASP.NET Core
author: camsoper
description: Discover how to set up Azure Active Directory B2C authentication with ASP.NET Core.
ms.author: casoper
ms.custom: "devx-track-csharp, mvc"
ms.date: 07/21/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/azure-ad-b2c
---
# Cloud authentication with Azure Active Directory B2C in ASP.NET Core

[Azure Active Directory B2C](/azure/active-directory-b2c/active-directory-b2c-overview) (Azure AD B2C) is a cloud identity management solution for web and mobile apps. The service provides authentication for apps hosted in the cloud and on-premises. Authentication types include individual accounts, social network accounts, and federated enterprise accounts. Additionally, Azure AD B2C can provide multi-factor authentication with minimal configuration.

> [!TIP]
> Azure Active Directory (Azure AD) and Azure AD B2C are separate product offerings. An Azure AD tenant represents an organization, while an Azure AD B2C tenant represents a collection of identities to be used with relying party applications. To learn more, see [Azure AD B2C: Frequently asked questions (FAQ)](/azure/active-directory-b2c/active-directory-b2c-faqs).

In this tutorial, you will learn how to configure an ASP.NET Core app for authentication with Azure AD B2C.

## Prerequisites

The following are required for this walkthrough:

* [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/?ref=microsoft.com&utm_source=microsoft.com&utm_medium=docs&utm_campaign=visualstudio)
* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019)

## Preparation

1. [Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant).
1. [Create a new ASP.NET Core Razor app](/aspnet/core/getting-started/).
1. [Create a web app registration in the tenant](/azure/active-directory-b2c/tutorial-register-applications#register-a-web-application). For **Redirect URI**, use `https://localhost:5001/signin-oidc`, substituting your configured SSL port for `5001` as required.

## Configure the app

1. NuGet Package
1. appsettings.json
1. Startup.cs 
## Run the app

1. Success!

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create an Azure Active Directory B2C tenant
> * Register an app in Azure AD B2C
> * Use Visual Studio to create an ASP.NET Core Web Application configured to use the Azure AD B2C tenant for authentication
> * Configure policies controlling the behavior of the Azure AD B2C tenant

Now that the ASP.NET Core app is configured to use Azure AD B2C for authentication, the [Authorize attribute](xref:security/authorization/simple) can be used to secure your app. Continue developing your app by learning to:

* [Customize the Azure AD B2C user interface](/azure/active-directory-b2c/active-directory-b2c-reference-ui-customization).
* [Configure password complexity requirements](/azure/active-directory-b2c/active-directory-b2c-reference-password-complexity).
* [Enable multi-factor authentication](/azure/active-directory-b2c/active-directory-b2c-reference-mfa).
* Configure additional identity providers, such as [Microsoft](/azure/active-directory-b2c/active-directory-b2c-setup-msa-app), [Facebook](/azure/active-directory-b2c/active-directory-b2c-setup-fb-app), [Google](/azure/active-directory-b2c/active-directory-b2c-setup-goog-app), [Amazon](/azure/active-directory-b2c/active-directory-b2c-setup-amzn-app), [Twitter](/azure/active-directory-b2c/active-directory-b2c-setup-twitter-app), and others.
* [Use the Azure AD Graph API](/azure/active-directory-b2c/active-directory-b2c-devquickstarts-graph-dotnet) to retrieve additional user information, such as group membership, from the Azure AD B2C tenant.
* [How to secure a Web API built with ASP.NET Core using the Azure AD B2C](https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/tree/master/4-WebApp-your-API/4-2-B2C).
* [Tutorial: Grant access to an ASP.NET web API using Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-web-api-dotnet).
