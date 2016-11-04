---
title: Enabling authentication using Facebook, Google and other external providers
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 11/1/2016
ms.topic: article
ms.assetid: eda7ee17-f38c-462e-8d1d-63f459901cf3
ms.prod: aspnet-core
uid: security/authentication/sociallogins
---
# Enabling authentication using Facebook, Google and other external providers

<a name=security-authentication-social-logins></a>

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Pranav Rastogi](https://github.com/rustd)

This tutorial will demonstrate how to build an ASP.NET Core app that enables users to log in using OAuth 2.0 with credentials from external authentication providers.

[Facebook](facebook-logins.md), [Twitter](twitter-logins.md), [Google](google-logins.md), and [Microsoft](microsoft-logins.md) providers are available out-of-the-box and will be covered in the following sections. Many third-party packages such as the ones by [aspnet-contrib](https://www.nuget.org/packages?q=owners%3Aaspnet-contrib+title%3AOAuth) facilitate the use of other providers not covered here, including GitHub, LinkedIn, Reddit, and so on.

<img src="sociallogins/_static/facebook.svg" width="24">&nbsp;
<img src="sociallogins/_static/twitter.svg" width="24">&nbsp;
<img src="sociallogins/_static/google.svg" width="24">&nbsp;
<img src="sociallogins/_static/microsoft.svg" width="24">

Enabling users to login with their existing credentials is convenient for the users and shifts many of the complexities of managing the sign-in process onto a third party. For examples of how social logins can drive traffic and customer conversions, see case studies by [Facebook](https://developers.facebook.com/case-studies) and [Twitter](https://developers.facebook.com/case-studies/).

> [!NOTE]
> Packages presented here abstract a great deal of complexity of the OAuth 2.0 authentication flow, but understanding the details may become necessary when troubleshooting. Many resources are available; for example, see [Introduction to OAuth 2](https://www.digitalocean.com/community/tutorials/an-introduction-to-oauth-2) or [Understanding OAuth 2](http://www.bubblecode.net/en/2016/01/22/understanding-oauth2/). Some issues can be resolved by looking at [ASP.NET Core implementation](https://github.com/aspnet/Security/tree/dev/src).

## Create a New ASP.NET Core Project

> [!NOTE]
> The tutorial requires the latest version of Visual Studio 2015 and ASP.NET Core.

* In Visual Studio, create a New Project (from the Start Page, or via **File > New > Project**):

![image](sociallogins/_static/new-project.png)

* Tap **Web Application** and verify **Authentication** is set to **Individual User Accounts**:

![image](sociallogins/_static/select-project.png)

## Enable SSL

Some external authentication providers will reject requests coming from origins that don't use the **https** protocol. This reflects the trend of major providers like [Google](https://security.googleblog.com/2014/08/https-as-ranking-signal_6.html) moving their public API services to https and discontinuing the use of unencrypted endpoints. We encourage you to follow this trend and enable SSL for your entire site.

* In solution explorer, right click the project and select **Properties**.

* On the left pane, tap **Debug**.

* Check **Enable SSL**.

* Copy the SSL URL and paste it into the **App URL**:

![image](sociallogins/_static/ssl.png)

* Modify the services.AddMvc(); code in `Startup.cs` under `ConfigureServices` to reject all requests that are not coming over *https*:

````csharp
services.AddMvc(options =>
{
    options.Filters.Add(new RequireHttpsAttribute ());
});
````

* Test the app to ensure that static files are still being served and publicly exposed routes are accessible.
   * There shouldn't be any warnings logged to the browser console in Developer Tools.
   * Attempting to navigate to the previous URI that used the *http* protocol should now result in **connection rejected** errors from the browser or a blank page.

## Use SecretManager to store tokens assigned by login providers

The template used to create the sample project in this tutorial has code in `Startup.cs` which reads the configuration values from a secret store:

````csharp
if (env.IsDevelopment())
{
    builder.AddUserSecrets();
}
````

* Install the [Secret Manager tool](../app-secrets.md).

* Set the Facebook AppId:

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ````
  dotnet user-secrets set Authentication:Facebook:AppId <app-Id>
     ````

* Set the Facebook AppSecret:

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ````
  dotnet user-secrets set Authentication:Facebook:AppSecret <app-secret>
     ````

The following code reads the configuration values stored by the [Secret Manager](../app-secrets.md#security-app-secrets).

[!code-csharp[Main](../../common/samples/WebApplication1/Startup.cs?highlight=11&range=20-36)]

## Enable Facebook middleware

**Note:** You will need to use NuGet to install the Microsoft.AspNetCore.Authentication.Facebook package if it hasn't already been installed.

Add the Facebook middleware in the `Configure` method in `Startup`:

[!code-csharp[Main](./sociallogins/sample/Startup.cs?highlight=21,22,23,24,25&range=64-96)]

## Login with Facebook

Run your application and click Login. You will see an option for Facebook.

![image](sociallogins/_static/FBLogin1.PNG)

When you click on Facebook, you will be redirected to Facebook for authentication.

![image](sociallogins/_static/FBLogin2.PNG)

Once you enter your Facebook credentials, then you will be redirected back to the Web site where you can set your email.

You are now logged in using your Facebook credentials.

![image](sociallogins/_static/DoneFacebook.PNG)

## Optionally set password

As a best practice, it is not recommended to store the secrets in a configuration file in the application since they can be checked into source control which may be publicly accessible.

The **SecretManager** tool will store sensitive application settings in the user profile folder on the local machine. These settings are then seamlessly merged with settings from all other sources during application startup.

> [NOTE!]
> Most login providers will assign **Application Id** and **Application Secret** during the registration process. These values are effectively the *user name* and *password* your application will use to access their API, and constitute the "secrets" linked to your application configuration with the help of **Secret Manager** instead of storing them in configuration files directly.

Install the Secret Manager tool using the steps in [this section](../app-secrets.md) so that you can use it to store tokens assigned by each login provider below.

## Setup login providers required by your application

Please use the following pages to configure your application to use the respective providers:

* [Facebook](facebook-logins.md) instructions
* [Twitter](twitter-logins.md) instructions
* [Google](google-logins.md) instructions
* [Microsoft](microsoft-logins.md) instructions
* [Other provider](other-logins.md) instructions

## Next steps

* This article introduced external authentication and explained the prerequisites required to add external logins to your ASP.NET Core app.

* Please reference provider-specific pages to configure logins for the providers required by your app.