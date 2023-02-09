---
title: Google external login setup in ASP.NET Core
author: rick-anderson
description: This tutorial demonstrates the integration of Google account user authentication into an existing ASP.NET Core app.
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 3/3/2022
uid: security/authentication/google-logins
---
# Google external login setup in ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial shows you how to enable users to sign in with their Google account using the ASP.NET Core project created on the [previous page](xref:security/authentication/social/index).

## Create the Google OAuth 2.0 Client ID and secret

* Follow the guidance in [Integrating Google Sign-In into your web app](https://developers.google.com/identity/sign-in/web/sign-in) (Google documentation).
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

Add the [`Microsoft.AspNetCore.Authentication.Google`](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Google) NuGet package to the app.

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

:::moniker range="< aspnetcore-6.0"

Add the Authentication service to the `Startup.ConfigureServices`:

[!code-csharp[](~/security/authentication/social/social-code/3.x/StartupGoogle3x.cs?highlight=11-19)]

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Add the Authentication service to the `Program`:

[!code-csharp[](~/security/authentication/social/social-code/6.x/ProgramGoogle.cs)]

:::moniker-end

[!INCLUDE [default settings configuration](includes/default-settings2-2.md)]

## Sign in with Google

* Run the app and select **Log in**. An option to sign in with Google appears.
* Select the **Google** button, which redirects to Google for authentication.
* After entering your Google credentials, you are redirected back to the web site.

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

[!INCLUDE[](includes/chain-auth-providers.md)]

For more information on configuration options supported by Google authentication, see the <xref:Microsoft.AspNetCore.Authentication.Google.GoogleOptions> API reference . This can be used to request different information about the user.

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
