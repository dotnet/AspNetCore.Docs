---
title: Twitter external login setup
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 11/1/2016
ms.topic: article
ms.assetid: E5931607-31C0-4B20-B416-85E3550F5EA8
ms.prod: aspnet-core
uid: security/authentication/twitter-logins
---
# Configuring Twitter authentication

<a name=security-authentication-twitter-logins></a>

This tutorial shows you how to enable your users to [log in with their Twitter account](https://dev.twitter.com/web/sign-in/desktop-browser) using a sample ASP.NET Core project created in the [previous section](sociallogins.md).

## Creating the app in Twitter

* Navigate to [https://apps.twitter.com/](https://apps.twitter.com/) and sign in. If you don't already have a Twitter account, use the *[Sign up now](https://twitter.com/signup)* link to create one. After signing in you will be redirected to the *Application Management* page:

![image](sociallogins/_static/TwitterAppManage.png)

* Tap **Create New App** in the upper right corner and fill out the *application name*, *description*, and the expected *website* address after deployment:

![image](sociallogins/_static/TwitterCreate.png)

* Enter your current site URL with *signin-twitter* appended into the **Callback URL** field. For example, `https://localhost:44320/signin-twitter`.

* When deploying the site you'll need to register a new public url.

> [!NOTE]
> You don't need to configure **signin-twitter** as a route in your app. The Twitter middleware will automatically intercept requests at this route and handle them to implement the OAuth flow.

* Tap **Create your Twitter application**. New application details will be displayed:

![image](sociallogins/_static/TwitterAppDetails.png)

## Storing Twitter ConsumerKey and ConsumerSecret

Link sensitive settings like Twitter `ConsumerKey` and `ConsumerSecret` to your application configuration by using the [Secret Manager tool](../app-secrets.md) instead of storing them in your configuration file directly, as described in the [previous section](sociallogins.md).

* Switch to the **Keys and Access Tokens** tab. Note the `Consumer Key` and `Consumer Secret`:

![image](sociallogins/_static/TwitterKeys.png)

* Execute the following in your project working directory to store the Twitter secrets:

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ````
  dotnet user-secrets set Authentication:Twitter:ConsumerKey <consumer-key>
  dotnet user-secrets set Authentication:Twitter:ConsumerSecret <consumer-secret>
     ````

The following code reads the configuration values stored by the [Secret Manager](../app-secrets.md#security-app-secrets):

[!code-csharp[Main](../../common/samples/WebApplication1/Startup.cs?highlight=11&range=20-36)]

## Enable Twitter middleware

> [!NOTE]
> You will need to use NuGet to install the [Microsoft.AspNetCore.Authentication.Twitter](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Twitter) package if it hasn't already been installed. Alternatively, execute the following in your project directory:
>
> `dotnet install Microsoft.AspNetCore.Authentication.Twitter`

Add the Twitter middleware in the `Configure` method in `Startup.cs`:

[!code-csharp[Main](./sociallogins/sample/Startup.cs?highlight=27,28,29,30,31&range=64-115)]

## Login with Twitter

Run your application and click Login. You will see an option for Twitter:

![image](sociallogins/_static/DoneTwitter.PNG)

When you click on Twitter, you will be redirected to Twitter for authentication:

![image](sociallogins/_static/TwitterLogin.PNG)

Once you enter your Twitter credentials, then you will be redirected back to the Web site where you can set your email.

You are now logged in using your Twitter credentials:

![image](sociallogins/_static/Done.PNG)

## Next steps

* This article showed how you can authenticate with Twitter. You can follow a similar approach to authenticate with other providers listed in the [previous section](sociallogins.md).

* Once you publish your Web site to Azure Web App, you should reset the `ConsumerSecret` in the Twitter developer portal.

* Set the `Authentication:Twitter:ConsumerKey` and `Authentication:Twitter:ConsumerSecret` as application setting in the Azure Web App portal. The configuration system is setup to read keys from environment variables.