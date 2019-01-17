---
title: Google external login setup in ASP.NET Core
author: rick-anderson
description: This tutorial demonstrates the integration of Google account user authentication into an existing ASP.NET Core app.
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 1/11/2019
uid: security/authentication/google-logins
---
# Google external login setup in ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial shows you how to enable your users to sign in with their Google account using the  ASP.NET Core 2.2 project created on the [previous page](xref:security/authentication/social/index).

## Create a Google API Console project and client ID

* On the [Integrating Google Sign-In into your web app](https://developers.google.com/identity/sign-in/web/devconsole-project) page, select **CONFIGURE A PROJECT**, and create a project.
* On the **Configure your OAuth client**, select **Web server**.
* In the **Authorized redirect URIs**, set the redirect URI. For example, `https://localhost:5001/signin-google`
* Save the **Client ID** and **Client Secret**.

> [!NOTE]
> The URI segment `/signin-google` is set as the default callback of the Google authentication provider. You can change the default callback URI while configuring the Google authentication middleware via the inherited [RemoteAuthenticationOptions.CallbackPath](/dotnet/api/microsoft.aspnetcore.authentication.remoteauthenticationoptions.callbackpath) property of the [GoogleOptions](/dotnet/api/microsoft.aspnetcore.authentication.google.googleoptions) class.

* When deploying the site, register the new public url from the **Google Console**.

## Store Google ClientID and ClientSecret

Link sensitive settings like Google `Client ID` and `Client Secret` to your application configuration using the [Secret Manager](xref:security/app-secrets). For the purposes of this tutorial, name the tokens `Authentication:Google:ClientId` and `Authentication:Google:ClientSecret`:

```console
dotnet user-secrets set "Authentication:Google:ClientId" "12345.apps.googleusercontent.com"
dotnet user-secrets set "Authentication:Google:ClientSecret" "<client secret>"
```

You can manage your API credentials and usage later in the [API Console](https://console.developers.google.com/apis/dashboard).

## Configure Google Authentication

Add the Google service to `Startup.ConfigureServices`:

[!code-csharp[Main](~/security/authentication/social/google-logins/sample/Startup.cs)]

services.AddDefaultIdentity<IdentityUser>()
        .AddDefaultUI(UIFramework.Bootstrap4)
        .AddEntityFrameworkStores<ApplicationDbContext>();

services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
});
```

[!INCLUDE [default settings configuration](includes/default-settings.md)]

[!INCLUDE[](includes/chain-auth-providers.md)]

See the [GoogleOptions](/dotnet/api/microsoft.aspnetcore.builder.googleoptions) API reference for more information on configuration options supported by Google authentication. This can be used to request different information about the user.

## Sign in with Google

Run your application and click **Log in**. An option to sign in with Google appears:

![Web application running in Microsoft Edge: User not authenticated](index/_static/DoneGoogle.png)

When you click on Google, you are redirected to Google for authentication:

![Google authentication dialog](index/_static/GoogleLogin.png)

After entering your Google credentials, then you are redirected back to the web site where you can set your email.

You are now logged in using your Google credentials:

![Web application running in Microsoft Edge: User authenticated](index/_static/Done.png)

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

## Troubleshooting

* If the sign in doesn't work and you aren't getting any errors, switch to development mode to make the issue easier to debug.
* If Identity isn't configured by calling `services.AddIdentity` in `ConfigureServices`, attempting to authenticate will result in *ArgumentException: The 'SignInScheme' option must be provided*. The project template used in this tutorial ensures that this is done.
* If the site database has not been created by applying the initial migration, you will get *A database operation failed while processing the request* error. Tap **Apply Migrations** to create the database and refresh to continue past the error.

## Next steps

* This article showed how you can authenticate with Google. You can follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).

* Once you publish your web site to Azure web app, you should reset the `ClientSecret` in the Google API Console.

* Set the `Authentication:Google:ClientId` and `Authentication:Google:ClientSecret` as application settings in the Azure portal. The configuration system is set up to read keys from environment variables.
