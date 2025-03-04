---
title: Google external login setup in ASP.NET Core
author: rick-anderson
description: This tutorial demonstrates the integration of Google account user authentication into an existing ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 3/3/2022
uid: security/authentication/google-logins
---
# Google external login setup in ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary), [Rick Anderson](https://twitter.com/RickAndMSFT) and [Sharaf Abacery](https://github.com/sharafabacery)

This tutorial shows you how to enable users to sign in with their Google account using the ASP.NET Core project created on the [previous page](xref:security/authentication/social/index).

## Create the Google OAuth 2.0 Client ID and secret

* Follow the guidance in [Integrating Google Sign-In into your web app](https://developers.google.com/identity/gsi/web/guides/overview) (Google documentation)
* Go to [Google API & Services](https://console.cloud.google.com/apis).
* A **Project** must exist first, you may have to create one. Once a project is selected, enter the **Dashboard**.

* In the **Oauth consent screen** of the **Dashboard**:
  * Select **User Type - External** and **CREATE**.
  * In the **App information** dialog, Provide an **app name** for the app, **user support email**, and **developer contact information**.
  * Step through the **Scopes** step.
  * Step through the **Test users** step.
  * Review the **OAuth consent screen** and go back to the app **Dashboard**.

* In the **Credentials** tab of the application Dashboard, select **CREATE CREDENTIALS** > **OAuth client ID**.
* Select **Application type** > **Web application**, choose a **name**.
* In the **Authorized redirect URIs** section, select **ADD URI** to set the redirect URI. Example redirect URI: `https://localhost:{PORT}/signin-google`, where the `{PORT}` placeholder is the app's port.
* Select the **CREATE** button.
* Save the **Client ID** and **Client Secret** for use in the app's configuration.
* When deploying the site, either:
  * Update the app's redirect URI in the **Google Console** to the app's deployed redirect URI.
  * Create a new Google API registration in the **Google Console** for the production app with its production redirect URI.

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

* Add the [`Google.Apis.Auth.AspNetCore3`](https://www.nuget.org/packages/Google.Apis.Auth.AspNetCore3) NuGet package to the app.
* Add the Authentication service to the `program.cs`:
* Follow [`Add Authtication for asp.net app`](https://developers.google.com/api-client-library/dotnet/guide/aaa_oauth#configure-your-application-to-use-google.apis.auth.aspnetcore3)

[!INCLUDE [default settings configuration](includes/default-settings2-2.md)]

## Sign in with Google
* Get a link to the libary at [google developer library link ](https://developers.google.com/identity/gsi/web/guides/client-library) to get link of library.
* Then go to [google developer button genration ](https://developers.google.com/identity/gsi/web/tools/configurator)
* Setup your Controller to match with ` data-login_uri="{HostName}/{ControllerName}/{actionName}" ` attrbute because after success login it will forward you to that link.
* Create a controller and action that takes one argument `string credential`, which is returned by Google upon completing the login process.
* Verify the `credential` using the following line of code:
`GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(credential);`
* This will retrieve the available information about the logged-in user, which could then be stored in a database.


## Change the default callback URI

The URI segment `/signin-google` is set as the default callback of the Google authentication provider. You can change the default callback URI while configuring the Google authentication middleware via the inherited <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.CallbackPath?displayProperty=nameWithType> property of the <xref:Microsoft.AspNetCore.Authentication.Google.GoogleOptions> class.

## Troubleshooting

* If the sign-in doesn't work and you aren't getting any errors, switch to development mode to make the issue easier to debug.
* If Identity isn't configured by calling `services.AddIdentity` in `ConfigureServices`, attempting to authenticate results in *ArgumentException: The 'SignInScheme' option must be provided*. The project template used in this tutorial ensures Identity is configured.
* If the site database has not been created by applying the initial migration, you get *A database operation failed while processing the request* error. Select **Apply Migrations** to create the database, and refresh the page to continue past the error.
* HTTP 500 error after successfully authenticating the request by the OAuth 2.0 provider such as Google: See [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/14169).
* How to implement external authentication with Google for React and other SPA apps: See [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/14169).

## Next steps

* This article showed how you can authenticate with Google. You can follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).
* Once you publish the app to Azure, reset the `ClientSecret` in the Google API Console.
* Set the `Authentication:Google:ClientId` and `Authentication:Google:ClientSecret` as application settings in the Azure portal. The configuration system is set up to read keys from environment variables.
