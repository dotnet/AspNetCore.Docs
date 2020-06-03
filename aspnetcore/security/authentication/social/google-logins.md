---
title: Google external login setup in ASP.NET Core
author: rick-anderson
description: This tutorial demonstrates the integration of Google account user authentication into an existing ASP.NET Core app.
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 03/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/google-logins
---
# Google external login setup in ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial shows you how to enable users to sign in with their Google account using the ASP.NET Core 3.0 project created on the [previous page](xref:security/authentication/social/index).

## Create a Google API Console project and client ID

* Install [Microsoft.AspNetCore.Authentication.Google](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Google).
* Navigate to [Integrating Google Sign-In into your web app](https://developers.google.com/identity/sign-in/web/sign-in) and select **Configure a project**.
* In the **Configure your OAuth client** dialog, select **Web server**.
* In the **Authorized redirect URIs** text entry box, set the redirect URI. For example, `https://localhost:44312/signin-google`
* Save the **Client ID** and **Client Secret**.
* When deploying the site, register the new public url from the **Google Console**.

## Store the Google client ID and secret

Store sensitive settings such as the Google client ID and secret values with [Secret Manager](xref:security/app-secrets). For this sample, use the following steps:

1. Initialize the project for secret storage per the instructions at [Enable secret storage](xref:security/app-secrets#enable-secret-storage).
1. Store the sensitive settings in the local secret store with the secret keys `Authentication:Google:ClientId` and `Authentication:Google:ClientSecret`:

    ```dotnetcli
    dotnet user-secrets set "Authentication:Google:ClientId" "<client-id>"
    dotnet user-secrets set "Authentication:Google:ClientSecret" "<client-secret>"
    ```

[!INCLUDE[](~/includes/environmentVarableColon.md)]

You can manage your API credentials and usage in the [API Console](https://console.developers.google.com/apis/dashboard).

## Configure Google authentication

Add the Google service to `Startup.ConfigureServices`:

[!code-csharp[](~/security/authentication/social/social-code/3.x/StartupGoogle3x.cs?highlight=11-19)]

[!INCLUDE [default settings configuration](includes/default-settings2-2.md)]

## Sign in with Google

* Run the app and click **Log in**. An option to sign in with Google appears.
* Click the **Google** button, which redirects to Google for authentication.
* After entering your Google credentials, you are redirected back to the web site.

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

[!INCLUDE[](includes/chain-auth-providers.md)]

See the <xref:Microsoft.AspNetCore.Authentication.Google.GoogleOptions> API reference for more information on configuration options supported by Google authentication. This can be used to request different information about the user.

## Change the default callback URI

The URI segment `/signin-google` is set as the default callback of the Google authentication provider. You can change the default callback URI while configuring the Google authentication middleware via the inherited [RemoteAuthenticationOptions.CallbackPath](/dotnet/api/microsoft.aspnetcore.authentication.remoteauthenticationoptions.callbackpath) property of the [GoogleOptions](/dotnet/api/microsoft.aspnetcore.authentication.google.googleoptions) class.

## Troubleshooting

* If the sign-in doesn't work and you aren't getting any errors, switch to development mode to make the issue easier to debug.
* If Identity isn't configured by calling `services.AddIdentity` in `ConfigureServices`, attempting to authenticate results in *ArgumentException: The 'SignInScheme' option must be provided*. The project template used in this tutorial ensures that this is done.
* If the site database has not been created by applying the initial migration, you get *A database operation failed while processing the request* error. Select **Apply Migrations** to create the database, and refresh the page to continue past the error.

## Next steps

* This article showed how you can authenticate with Google. You can follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).
* Once you publish the app to Azure, reset the `ClientSecret` in the Google API Console.
* Set the `Authentication:Google:ClientId` and `Authentication:Google:ClientSecret` as application settings in the Azure portal. The configuration system is set up to read keys from environment variables.
