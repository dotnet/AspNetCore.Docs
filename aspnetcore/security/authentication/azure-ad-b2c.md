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
> Azure Active Directory (Azure AD) and Azure AD B2C are separate product offerings. An Azure AD tenant generally represents an organization, while an Azure AD B2C tenant represents a collection of identities to be used with relying party applications. To learn more, see [Azure AD B2C: Frequently asked questions (FAQ)](/azure/active-directory-b2c/active-directory-b2c-faqs).

In this tutorial, you'll learn how to configure an ASP.NET Core app for authentication with Azure AD B2C.

## Prerequisites

The following are required for this walkthrough:

- An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/dotnet).
- .NET 5.0 SDK or later. [Install the latest .NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) for your platform.

## Preparation

1. [Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant).
1. Create a new ASP.NET Core Razor pages app:
    
    ```dotnetcli
    dotnet new razor -o azure-ad-b2c
    ```
    
    The previous command creates a Razor pages app in a directory named *azure-ad-b2c*. 
    
    > [!TIP]
    > You may prefer to [use Visual Studio to create your app](/visualstudio/ide/quickstart-aspnet-core).

1. [Create a web app registration in the tenant](/azure/active-directory-b2c/tutorial-register-applications#register-a-web-application). For **Redirect URI**, use `https://localhost:5001/signin-oidc`.
 
## Modify the app

1. From inside the project directory, add the `Microsoft.Identity.Web` and `Microsoft.Identity.Web.UI` packages to the project. If you're using Visual Studio, you can use [NuGet Package Manager](/nuget/consume-packages/install-use-packages-visual-studio).

    ```dotnetcli
    dotnet add package Microsoft.Identity.Web --version 1.4.0 
    dotnet add package Microsoft.Identity.Web.UI --version 1.4.0
    ```
    
    In the preceding:

    - `Microsoft.Identity.Web` includes the basic set of dependencies for authenticating with the Microsoft Identity platform.
    - `Microsoft.Identity.Web.UI` includes UI functionality encapsulated in an area named `MicrosoftIdentity`.

1. Add an `AzureAd` object to *appsettings.json*.

    :::code language="javascript" source="azure-ad-b2c/sample/appsettings.json" highlight="2-8":::
    
    - For **Domain**, use the domain of your Azure AD B2C tenant.
    - For **ClientId**, use the **Application (client) ID** from the app registration you created in your tenant.
    - Leave all other values as they are.
    
1. In *Views/Shared*, create a file named *_LoginPartial.cshtml*. Include the following code:

    :::code language="razor" source="azure-ad-b2c/sample/Pages/Shared/_LoginPartial.cshtml":::    

    In the preceding code:

    - The partial view checks if the user is authenticated.
    - Renders a "Sign out" or "Sign in" link as appropriate.
    - The link points to an action method on the `Account` controller in the `MicrosoftIdentity` area.

1. In *Views/Shared/_Layout.cshtml*, add the highlighted line:

    :::code language="razor" source="azure-ad-b2c/sample/Pages/Shared/_Layout.cshtml" range="11-32" highlight="10":::
 
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
