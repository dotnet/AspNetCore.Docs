---
title: Cloud authentication with Azure Active Directory B2C in ASP.NET Core
author: camsoper
description: Discover how to set up Azure Active Directory B2C authentication with ASP.NET Core.
ms.author: casoper
ms.custom: "devx-track-csharp, mvc"
ms.date: 07/22/2021
uid: security/authentication/azure-ad-b2c
---
# Cloud authentication with Azure Active Directory B2C in ASP.NET Core

By [Damien Bod](https://twitter.com/damien_bod)

[Azure Active Directory B2C](/azure/active-directory-b2c/active-directory-b2c-overview) (Azure AD B2C) is a cloud identity management solution for web and mobile apps. The service provides authentication for apps hosted in the cloud and on-premises. Authentication types include individual accounts, social network accounts, and federated enterprise accounts. Additionally, Azure AD B2C can provide multi-factor authentication with minimal configuration.

> [!TIP]
> Microsoft Entra ID (previously known as Azure AD) and Azure AD B2C are separate product offerings. An Entra ID tenant generally represents an organization, while an Azure AD B2C tenant represents a collection of identities to be used with relying party applications. To learn more, see [Azure AD B2C: Frequently asked questions (FAQ)](/azure/active-directory-b2c/active-directory-b2c-faqs).

> [!TIP]
> [Microsoft Entra External ID for customers](/azure/active-directory/external-identities/customers/overview-customers-ciam) is Microsoft’s new customer identity and access management (CIAM) solution.

In this tutorial, you'll learn how to configure an ASP.NET Core app for authentication with Azure AD B2C.

## Prerequisites

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

1. [Create a web app registration in the tenant](/azure/active-directory-b2c/tutorial-register-applications#register-a-web-application). For **Redirect URI**, use `https://localhost:5001/signin-oidc`.  Replace `5001` with the port used by your app when using Visual Studio generated ports.

## Modify the app

1. Add the `Microsoft.Identity.Web` and `Microsoft.Identity.Web.UI` packages to the project. If you're using Visual Studio, you can use [NuGet Package Manager](/nuget/consume-packages/install-use-packages-visual-studio).

    ```dotnetcli
    dotnet add package Microsoft.Identity.Web
    dotnet add package Microsoft.Identity.Web.UI
    ```
    
    In the preceding:

    - `Microsoft.Identity.Web` includes the basic set of dependencies for authenticating with the Microsoft Identity platform.
    - `Microsoft.Identity.Web.UI` includes UI functionality encapsulated in an area named `MicrosoftIdentity`.

1. Add an `AzureADB2C` object to `appsettings.json`.

    > [!NOTE]
    > When using Azure B2C user flows, you need to set the **Instance** and the PolicyId of the type of flow.

    :::code language="json" source="azure-ad-b2c/sample/appsettings-b2c-userflow.json" highlight="2-17":::

    - For **Domain**, use the domain of your Azure AD B2C tenant.
    - For **ClientId**, use the **Application (client) ID** from the app registration you created in your tenant.
    - For **Instance**, use the domain of your Azure AD B2C tenant.
    - For **SignUpSignInPolicyId**, use the user flow policy defined in the Azure B2C tenant
	- Use either the **ClientSecret** or the **ClientCertificates** configuration. ClientCertificates are recommended.
    - Leave all other values as they are.
	
1. In *Pages/Shared*, create a file named `_LoginPartial.cshtml`. Include the following code:

    :::code language="razor" source="azure-ad-b2c/sample/Pages/Shared/_LoginPartial.cshtml":::    

    The preceding code:

    - Checks if the user is authenticated.
    - Renders a **Sign out** or **Sign in** link as appropriate.
        - The link points to an action method on the `Account` controller in the `MicrosoftIdentity` area.

1. In *Pages/Shared/_Layout.cshtml*, add the highlighted line within the `<header>` element:

    :::code language="razor" source="azure-ad-b2c/sample/Pages/Shared/_Layout.cshtml" range="12-33" highlight="18":::
 
    Adding `<partial name="_LoginPartial" />` renders the `_LoginPartial.cshtml` partial view in every page request that uses this layout.

1. In *Program.cs*, make the following changes:

    1. Add the following `using` directives:
    
        :::code language="csharp" source="azure-ad-b2c/sample/Program.cs" id="snippet_NewUsings":::

        The preceding code resolves references used in the next steps.

    1. Update the `builder.Services` lines with the following code:
        
        :::code language="csharp" source="azure-ad-b2c/sample/Program.cs" id="snippet_builderservices":::

        In the preceding code:

        - Calls to the `AddAuthentication` and `AddMicrosoftIdentityWebApp` methods configure the app to use Open ID Connect, specifically configured for the Microsoft Identity platform.
        - `AddAuthorization` initializes ASP.NET Core authorization.
        - The `AddRazorPages` call configures the app so anonymous browsers can view the Index page. All other requests require authentication.
        - `AddMvcOptions` and `AddMicrosoftIdentityUI` add the required UI components for redirecting to/from Azure AD B2C.
    
    1. Update the highlighted line to the `Configure` method:
        
        :::code language="csharp" source="azure-ad-b2c/sample/Program.cs" id="snippet_app":::

        The preceding code enables authentication in ASP.NET Core.

## Run the app

> [!NOTE]
> Use the profile which matches the Azure App registration **Redirect URIs**
1. Run the app.
    
    ```dotnetcli
    dotnet run --launch-profile https
    ```

1. Browse to the app's secure endpoint, for example, `https://localhost:5001/`.
    - The Index page renders with no authentication challenge.
    - The header includes a **Sign in** link because you're not authenticated.

1. Select the **Privacy** link.
    - The browser is redirected to your tenant's configured authentication method.
    - After signing in, the header displays a welcome message and a **Sign out** link.

## Next steps

In this tutorial, you learned how to configure an ASP.NET Core app for authentication with Azure AD B2C.

Now that the ASP.NET Core app is configured to use Azure AD B2C for authentication, the [Authorize attribute](xref:security/authorization/simple) can be used to secure your app. Continue developing your app by learning to:

* [Customize the Azure AD B2C user interface](/azure/active-directory-b2c/active-directory-b2c-reference-ui-customization).
* [Configure password complexity requirements](/azure/active-directory-b2c/active-directory-b2c-reference-password-complexity).
* [Enable multi-factor authentication](/azure/active-directory-b2c/active-directory-b2c-reference-mfa).
* Configure additional identity providers, such as [Microsoft](/azure/active-directory-b2c/active-directory-b2c-setup-msa-app), [Facebook](/azure/active-directory-b2c/active-directory-b2c-setup-fb-app), [Google](/azure/active-directory-b2c/active-directory-b2c-setup-goog-app), [Amazon](/azure/active-directory-b2c/active-directory-b2c-setup-amzn-app), [Twitter](/azure/active-directory-b2c/active-directory-b2c-setup-twitter-app), and others.
* [Use the Microsoft Graph API](/azure/active-directory-b2c/microsoft-graph-operations) to retrieve additional user information, such as group membership, from the Azure AD B2C tenant.
* [How to secure a Web API built with ASP.NET Core using the Azure AD B2C](https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/tree/master/4-WebApp-your-API/4-2-B2C).
* [Tutorial: Grant access to an ASP.NET web API using Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-web-api-dotnet).
