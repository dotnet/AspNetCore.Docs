---
title: Facebook external login setup
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 11/1/2016
ms.topic: article
ms.assetid: 8c65179b-688c-4af1-8f5e-1862920cda95
ms.prod: aspnet-core
﻿uid: security/authentication/facebook-logins
---
# Configuring Facebook authentication

<a name=security-authentication-facebook-logins></a>

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Pranav Rastogi](https://github.com/rustd)

This tutorial shows you how to enable your users to log in with their Facebook account using a sample ASP.NET Core project created in the [previous section](sociallogins.md). We start by creating a Facebook AppId by following the [official steps](https://developers.facebook.com/docs/apps/register).

## Creating the app in Facebook

*  Navigate to [https://developers.facebook.com/apps](https://developers.facebook.com/apps) and log in. If you don't already have a Facebook account, use the *sign up* link on the login page to create one.

* Tap **My Apps** in the upper right corner:

![image](sociallogins/_static/FBMyApps.png)

* Tap **+ Add a New App** and fill out the form to create a new app ID:

![image](sociallogins/_static/FBNewAppID.png)

* The **Product Setup** page will be displayed, letting you select the features your new app will support. Tap **Get Started** on *Facebook Login*:

![image](sociallogins/_static/FBProductSetup.png)

* You will be presented with the **Client OAuth Settings** page with some defaults already set:

![image](sociallogins/_static/FBOAuthSetup.png)

* Enter your base URI with *signin-facebook* appended into the **Valid OAuth Redirect URIs** field. For example, https://localhost:44320/**signin-facebook**.

> [!NOTE]
> You don't need to configure **signin-facebook** as a route in your app. The ASP.NET Core team's implementation of the OAuth flow will create a temporary socket (called a *backchannel*) that listens at this route just for the duration of the OAuth flow.

* Make a note of your *App ID* and your *App Secret* before dismissing this page so that you can add both into your ASP.NET Core app later in this tutorial.

* Tap **Save Changes** to complete the new application configuration.

## Storing Facebook AppId and AppSecret

Link sensitive settings like Facebook *AppID* and *Secret* to your application configuration by using the [Secret Manager tool](../app-secrets.md) instead of storing them in your configuration file directly, as described in the [previous section](sociallogins.md). Execute the following in your project working directory:

* Set the Facebook AppId

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ````
  dotnet user-secrets set Authentication:Facebook:AppId <app-Id>
     ````

* Set the Facebook AppSecret

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ````
  dotnet user-secrets set Authentication:Facebook:AppSecret <app-secret>
     ````

The following code reads the configuration values stored by the [Secret Manager](../app-secrets.md#security-app-secrets):

[!code-csharp[Main](../../common/samples/WebApplication1/Startup.cs?highlight=11&range=20-36)]

## Enable Facebook middleware

> [!NOTE]
> You will need to use NuGet to install the [Microsoft.AspNetCore.Authentication.Facebook](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Facebook/1.1.0-preview1-final) package if it hasn't already been installed. Alternatively, execute the following in your project directory:
>
> `dotnet install Microsoft.AspNetCore.Authentication.Facebook`

Add the Facebook middleware in the `Configure` method in `Startup.cs`:

[!code-csharp[Main](./sociallogins/sample/Startup.cs?highlight=21,22,23,24,25&range=58-110)]

## Login with Facebook

Run your application and click Login. You will see an option for Facebook.

![image](sociallogins/_static/FBLogin1.PNG)

When you click on Facebook, you will be redirected to Facebook for authentication.

![image](sociallogins/_static/FBLogin2.PNG)

Once you enter your Facebook credentials, then you will be redirected back to the Web site where you can set your email.

You are now logged in using your Facebook credentials:

![image](sociallogins/_static/Done.PNG)

## Optionally set password

When you register with an external login provider, you do not have a password registered with the app. This alleviates you from creating and remembering a password for the site, but it also makes you dependent on the external login provider. If the external login provider is unavailable, you won't be able to log in to the web site.

To create a password and login using your email that you set during the login process with external providers:

* Tap the **Hello <email alias>** link at the top right corner to navigate to the **Manage** view.

![image](sociallogins/_static/pass1.PNG)

* Tap **Create**

![image](sociallogins/_static/pass2.PNG)

* Set a valid password and you can use this to login with your email

## Next steps

* This article showed how you can authenticate with Facebook. You can follow a similar approach to authenticate with [Microsoft Account](microsoft-logins.md), [Twitter](twitter-logins.md), [Google](google-logins.md) and other providers.

* Once you publish your Web site to Azure Web App, you should reset the *AppSecret* in the Facebook developer portal.

* Set the *Authentication:Facebook:AppId* and Authentication:Facebook:AppSecret as application setting in the Azure Web App portal. The configuration system is setup to read keys from environment variables.