---
title: Cloud authentication with Azure Active Directory B2C
author: camsoper
description: Shows how to set up Azure Active Directory B2C with ASP.NET Core
keywords: ASP.NET Core,authentication,AAD,B2C,Azure Active Directory,Active Directory
ms.author: casoper
manager: wpickett
ms.date: 01/12/2018
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authentication/azure-ad-b2c
---
# Cloud authentication with Azure Active Directory B2C

By [Cam Soper](https://twitter.com/camsoper)

[Azure Active Directory B2C](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-overview) (AAD B2C) is a cloud identity management solution for your web and mobile applications.  The service provides global, scalable, cloud-based authentication to web applications and APIs using individual accounts, social network accounts, and federated enterprise accounts for applications hosted in the cloud and on-premises.  Additionally, AAD B2C can provide multifactor authentication with very little configuration.

This page demonstrates using Azure Active Directory B2C with ASP.NET Core.

## Prerequisites

The following are required for this walkthrough:

* A [Microsoft Azure subscription](https://azure.microsoft.com/free/?ref=microsoft.com&utm_source=microsoft.com&utm_medium=docs&utm_campaign=visualstudio).  
* [Visual Studio 2017](https://www.visualstudio.com/vs/) (any edition).

## Create the Azure Active Directory B2C tenant

Create an Azure Active Directory B2C tenant [as described in the documentation](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-get-started).  When prompted, associating the tenant with an Azure subscription is optional for this tutorial.

## Register the application in AAD B2C

In the newly created AAD B2C tenant, register your application using [the steps in the documentation under the *Register a web app* heading](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-app-registration#register-a-web-app). Stop at the *Create a web app client secret* heading. A client secret isn't required for this tutorial. 

Use the following values:

| Setting      | Value  | Notes                                        |
| ------------ | ------- | -------------------------------------------------- |
| **Name** | *\<application name\>* | Enter a **Name** for the application that describes your application to consumers. | 
| **Include web app / web API** | Yes | |
| **Allow implicit flow** | Yes | |
| **Reply URL** | `https://localhost:44300` | Reply URLs are endpoints where Azure AD B2C returns any tokens that your application requests. Visual Studio will provide the Reply URL to use. For now, enter `https://localhost:44300` to complete the form.
| **App ID URI** | Leave blank | | Not required for this tutorial.
| **Include native client** | No | |

> [!WARNING]
> If setting up a non-localhost Reply URL, be aware of the [constraints on what can be added to the Reply URL list](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-app-registration#choosing-a-web-app-or-api-reply-url). 

After the application registration is created, the list of applications in the tenant is displayed. Select the application that was just registered.  Select the **Copy** icon to the right of the **Application ID** field to copy the Application ID to the clipboard.

Nothing more can be configured in the AAD B2C tenant at this time, but leave the browser window open. There will be more configuration after the ASP.NET Core application is created.

## Create an ASP.NET Core application in Visual Studio 2017

The Visual Studio Web Application template can be configured to use the AAD B2C tenant for authentication.

In Visual Studio:

1. Create a new ASP.NET Core Web Application. 
2. Select Web Application from the list of templates.
3. Select the **Change Authentication** button.
    
    ![Change Authentication Button](./azure-ad-b2c/_static/changeauth.png)

4. In the **Change Authentication** dialog, select **Individual User Accounts**, and then select **Connect to an existing user store in the cloud** in the dropdown. 
    
    ![Change Authentication Dialog](./azure-ad-b2c/_static/changeauthdialog.png)

5. Complete the form with the following values:
    
    | Setting      | Value  | 
    | ------------ | ------- | 
    | **Domain Name** | *\<the domain name of your B2C tenant\>* | 
    | **Application ID** | *\<paste the Application ID from the clipboard\>* |
    | **Callback Path** | *\<use the default value\>* |
    | **Sign-up or sign-in policy** | `B2C_1_SiUpIn` |
    | **Reset password policy** | `B2C_1_SSPR` |
    | **Edit profile policy** | *\<leave blank\>* | 

    Select the **Copy** link next to **Reply URI** to copy the Reply URI to the clipboard.  Select **OK** to close the **Change Authentication** dialog, and then select **OK** to create the web app.

## Finish the B2C application registration

In the browser window, with the B2C application properties still open, change the temporary **Reply URL** specified earlier to the value copied from Visual Studio, and then select **Save** at the top of the window.

> [!TIP]
> If you didn't copy the Reply URL, use the SSL address from the Debug tab in the web project properties, and append the **CallbackPath** value from `appsettings.json`.

## Configure policies

Use the steps in the AAD B2C documentation to [create a sign-up or sign-in policy](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-reference-policies#create-a-sign-up-or-sign-in-policy), and then [create a password reset policy](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-reference-policies#create-a-password-reset-policy).  Use the example values provided in the documentation for **Identity providers**, **Sign-up attributes**, and **Application claims**.  Using the **Run now** button to test the policies as described in the documentation is optional.

> [!WARNING]
> Ensure the policy names are exactly as described in the documentation, as those policies were used in the **Change Authentication** dialog in Visual Studio. The policy names can be verified in `appsettings.json`.

## Run the application

In Visual Studio, press **F5** to build and run the application. After the web app launches, select **Sign in**.

![Sign into the application](./azure-ad-b2c/_static/signin.png)

The browser redirects to the AAD B2C tenant.  Sign-in with an existing account (if one was created testing the policies) or select **Sign up now** to create a new account.  The **Forgot your password?** link can be used to reset a forgotten password.

![AAD B2C login](./azure-ad-b2c/_static/b2csts.png)

After successfully signing in, the browser redirects to the web app.

![Success](./azure-ad-b2c/_static/success.png)

## Next steps

Now that the ASP.NET Core application is configured to use Azure Active Directory B2C for authentication, the [Authorize attribute](../../authorization/simple) can be used to secure your application.  Other tasks that may be performed include:

* [Customizing the AAD B2C user interface](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-reference-ui-customization)
* [Enabling multi-factor authentication](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-reference-mfa)
* Configuring additional identity providers, such as [Microsoft](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-setup-msa-app), [Facebook](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-setup-fb-app), [Google](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-setup-goog-app), [Amazon](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-setup-amzn-app), [Twitter](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-setup-twitter-app) and others. 
* [Using the Azure AD Graph API](https://docs.microsoft.com/azure/active-directory-b2c/active-directory-b2c-devquickstarts-graph-dotnet) to retrieve additional information, such as group membership, from the AAD B2C tenant.