---
title: Google external login setup in ASP.NET Core
author: rick-anderson
description: This tutorial demonstrates the integration of Google account user authentication into an existing ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 05/28/2025
uid: security/authentication/google-logins
---

# Google external login setup in ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary), [Rick Anderson](https://twitter.com/RickAndMSFT) and [Sharaf Abacery](https://github.com/sharafabacery)

This tutorial with code examples shows how to enable your users to sign in with their Google account using a sample ASP.NET Core project created on the  [previous page](xref:security/authentication/social/index). We start by creating a Google App ID by following the [official steps](https://developers.google.com/identity/gsi/web/guides/overview).

## Create the app in Google

* Navigate to the [Google API & Services](https://console.cloud.google.com/apis) page of the Google Cloud platform.
* Create a new project by clicking on the **Create Project** button. If you already have a project, select the project.
* Enter a **Project name**.
* Optionally, select a **Organization** for the project.

After creating the project you are redirected to the **Dashboard** page of the project, where it's possible to configure the project.

Open the **Credentials** tab to create the OAuth client.
The prerequisite to create credentials is to configure the OAuth consent screen.
If the consent is not configured yet, you are prompted to configure the consent screen first.

* Click on **Configure consent screen** (or go to OAuth consent screen by clicking on the menu item).
* In the **OAuth consent screen** click on **Get started**.
* Provide the App information, such as the **App name** and a **User support email**.
* Set the audience type to **External**.
* Add **contact information** by entering a contact email address.
* Agree the terms. 
* Click on **Create**. 

Next, create the client credentials for the app by opening to the **Clients** tab.

* Click on **Create client**
* Select **Web application** as the **Application type**.
* Enter a **name** for the client.
* Add an **Authorized redirect URI**. By default this is set to `https://localhost:{PORT}/signin-google`, where the `{PORT}` placeholder is the app's port.
* **Create** the Client.
* Save the Client ID and client secret, which is going to be used in the ASP.NET application configuration.

  > [!NOTE]
  > The URI segment `/signin-google` is set as the default callback of the Google authentication provider. You can change the default callback URI while configuring the Google authentication middleware via the inherited <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.CallbackPath%2A?displayProperty=nameWithType> property of the <xref:Microsoft.AspNetCore.Authentication.Google.GoogleOptions> class.

When deploying the site, either:
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

Add the Authentication service to the `Program`:

:::moniker range="< aspnetcore-6.0"

Add the Authentication service to the `Startup.ConfigureServices`:

```csharp
services.AddAuthentication().AddGoogle(googleOptions =>
{
      googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
      googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Add the Authentication service to the `Program`:

:::code language="csharp" source="~/security/authentication/social/social-code/6.x/ProgramGoogle.cs" id="snippet1":::

:::moniker-end

[!INCLUDE [default settings configuration](includes/default-settings.md)]

## Sign in with Google

* Run the app and select **Log in**. 
* Under **Use another service to log in.**, select Google.
* You are redirected to **Google** for authentication.
* Select the Google account you want to log in with, or enter your Google credentials.
* If this is the first time you are signing in, you may be prompted to allow the app to access your Google account.
* You are redirected back to your site where you can set your email.

You are now logged in using your Google credentials.

## Troubleshooting

* If the sign-in doesn't work and you aren't getting any errors, switch to development mode to make the issue easier to debug.
* If the site database has not been created by applying the initial migration, you get *A database operation failed while processing the request* error. Select **Apply Migrations** to create the database, and refresh the page to continue past the error.
* HTTP 500 error after successfully authenticating the request by the OAuth 2.0 provider such as Google: See [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/14169).
* How to implement external authentication with Google for React and other SPA apps: See [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/14169).

## Next steps

* This article showed how you can authenticate with Google. You can follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).
* Once you publish the app to Azure, reset the `ClientSecret` in the Google API Console.
* Set the `Authentication:Google:ClientId` and `Authentication:Google:ClientSecret` as application settings in the Azure portal. The configuration system is set up to read keys from environment variables.
