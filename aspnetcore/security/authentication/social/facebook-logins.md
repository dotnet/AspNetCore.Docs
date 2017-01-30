---
title: Facebook external login setup | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 11/1/2016
ms.topic: article
ms.assetid: 8c65179b-688c-4af1-8f5e-1862920cda95
ms.technology: aspnet
ms.prod: aspnet-core
uid: security/authentication/facebook-logins
---
# Configuring Facebook authentication

<a name=security-authentication-facebook-logins></a>

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Pranav Rastogi](https://github.com/rustd), and [Valeriy Novytskyy](https://github.com/01binary)

This tutorial shows you how to enable your users to sign in with their Facebook account using a sample ASP.NET Core project created on the [previous page](index.md). We start by creating a Facebook App ID by following the [official steps](https://developers.facebook.com/docs/apps/register).

## Creating the app in Facebook

*  Navigate to the [Facebook for Developers](https://developers.facebook.com/apps) page and sign in. If you don't already have a Facebook account, use the **Sign up for Facebook** link on the login page to create one.

* Tap the **+ Add a New App** button in the upper right corner to create a new App ID. (If this is your first app with Facebook, the text of the button will be **Create a New App**.)

![Facebook for developers portal open in Microsoft Edge](index/_static/FBMyApps.png)

* Fill out the form and tap the **Create App ID** button.

![Create a New App ID form](index/_static/FBNewAppId.png)

* The **Product Setup** page is displayed, letting you select the features for your new app. Click **Get Started** on **Facebook Login**.

![Product Setup page](index/_static/FBProductSetup.png)

* Next, a quick start process begins at the **Choose a Platform** screen. This will help you set up client-side login integration, which isn't covered in this tutorial. 

    To bypass this, click the **Settings** link in the menu at the left.


* You are presented with the **Client OAuth Settings** page with some defaults already set.

![Client OAuth Settings page](index/_static/FBOAuthSetup.png)

* Enter your base URI with *signin-facebook* appended into the **Valid OAuth Redirect URIs** field (for example: `https://localhost:44320/signin-facebook`). 
* Click **Save Changes**.
  
  > [!NOTE]
  > When deploying the site you'll need to register a new public url.

  > [!NOTE]
  > You don't need to configure **signin-facebook** as a route in your app. The Facebook middleware automatically intercepts requests at this route and handles them to implement the OAuth flow.

* Click the **Dashboard** link in the left navigation. 
    
    On this page, you'll need to make a note of your `App ID` and your `App Secret`. Later in this tutorial, you will add both into your ASP.NET Core application.

## Storing Facebook App ID and AppSecret

Link sensitive settings like Facebook `App ID` and `App Secret` to your application configuration by using the [Secret Manager tool](../../app-secrets.md) instead of storing them in your configuration file directly, as described in the [social login overview page](index.md). Execute the following commands in your project working directory:

* Set the Facebook AppId

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ```
  dotnet user-secrets set Authentication:Facebook:AppId <app-Id>
     ```

* Set the Facebook AppSecret

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ```
  dotnet user-secrets set Authentication:Facebook:AppSecret <app-secret>
     ```

The following code reads the configuration values stored by the [Secret Manager](../../app-secrets.md#security-app-secrets):

[!code-csharp[Main](../../../common/samples/WebApplication1/Startup.cs?highlight=11&range=20-36)]

## Enable Facebook middleware

> [!NOTE]
> You will need to use NuGet to install the [Microsoft.AspNetCore.Authentication.Facebook](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Facebook) package if it hasn't already been installed. Alternatively, execute the following commands in your project directory:
>
> `dotnet install Microsoft.AspNetCore.Authentication.Facebook`

Add the Facebook middleware in the `Configure` method in `Startup.cs`:

```csharp
app.UseFacebookAuthentication(new FacebookOptions()
{
    AppId = Configuration["Authentication:Facebook:AppId"],
    AppSecret = Configuration["Authentication:Facebook:AppSecret"]
});
```

## Sign in with Facebook

Run your application and click **Log in**. You will see an option to sign in with Facebook.

![Web application: User not authenticated](index/_static/DoneFacebook.png)

When you click on Facebook, you will be redirected to Facebook for authentication.

![Facebook authentication page](index/_static/FBLogin2a.png)

Once you enter your Facebook credentials, then you will be redirected back to the web site where you can set your email.

You are now logged in using your Facebook credentials:

![Web application: User authenticated](index/_static/Done.png)

## Next steps

* This article showed how you can authenticate with Facebook. You can follow a similar approach to authenticate with other providers listed on the [previous page](index.md).

* Once you publish your web site to Azure web app, you should reset the `AppSecret` in the Facebook developer portal.

* Set the `Authentication:Facebook:AppId` and `Authentication:Facebook:AppSecret` as application settings in the Azure portal. The configuration system is set up to read keys from environment variables.
