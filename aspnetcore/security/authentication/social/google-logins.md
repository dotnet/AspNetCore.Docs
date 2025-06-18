---
title: Google external login setup in ASP.NET Core
author: rick-anderson
description: This tutorial demonstrates the integration of Google account user authentication into an existing ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 06/16/2025
uid: security/authentication/google-logins
---
# Google external login setup in ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Sharaf Abacery](https://github.com/sharafabacery)

This tutorial shows how to enable user sign in with Google accounts using a sample ASP.NET Core project created in <xref:security/authentication/social/index>. Follow Google's official guidance in [Sign in with Google for Web: Setup](https://developers.google.com/identity/gsi/web/guides/get-google-api-clientid) to create a Google API client ID.

## Create the app in Google

* Navigate to the [Google API & Services](https://console.cloud.google.com/apis) page of the Google Cloud platform.
* Create a new project by selecting the **Create Project** button. To select a different existing project or add a project, select the loaded project's button in the top-left corner of the UI, followed by either selecting the project or the **New project** button.
* When creating a new project:
  * Enter a **Project name**.
  * Optionally, select an **Organization** for the project.
  * Select the **Create** button.

After creating the project, the **Dashboard** page of the project loads, where it's possible to configure the project.

Open the **Credentials** tab to create the OAuth client.

The prerequisite to creating the credentials is to configure the OAuth consent screen. If the consent isn't configured, there's a prompt to configure the consent screen.

* Select **Configure consent screen** or select **OAuth consent screen** in the sidebar.
* In the **OAuth consent screen**, select **Get started**.
* Set the **App name** and **User support email**.
* Set the audience type to **External**.
* Add **Contact information** by entering a contact email address.
* Agree to the terms. 
* Select **Create**.

Create the client credentials for the app by opening the **Clients** sidebar menu item:

* Select the **Create client** button.
* Select **Web application** as the **Application type**.
* Enter a **Name** for the client.
* Add an **Authorized redirect URI**. For local testing, use the default address `https://localhost:{PORT}/signin-google`, where the `{PORT}` placeholder is the app's port.
* Select the **Create** button to create the client.
* Save the **Client ID** and **Client secret**, which are used later in the ASP.NET app configuration.

> [!NOTE]
> The URI segment `/signin-google` is set as the default callback of the Google authentication provider. It's possible to change the default callback URI while configuring the Google authentication middleware via the inherited <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.CallbackPath%2A?displayProperty=nameWithType> property of the <xref:Microsoft.AspNetCore.Authentication.Google.GoogleOptions> class.

When deploying the app, either:

* Update the app's redirect URI in the **Google Console** to the app's deployed redirect URI.
* Create a new Google API registration in the **Google Console** for the production app with its production redirect URI.

## Store the Google client ID and secret

Store sensitive settings, such as the Google client ID and secret values, with [Secret Manager](xref:security/app-secrets). For this sample, follow these steps:

1. Initialize the project for secret storage according to the instructions in <xref:security/app-secrets>.
1. Store the sensitive settings in the local secret store with the secret keys `Authentication:Google:ClientId` (value: `{CLIENT ID}` placeholder) and `Authentication:Google:ClientSecret` (value: `{CLIENT SECRET}` placeholder):

    ```dotnetcli
    dotnet user-secrets set "Authentication:Google:ClientId" "{CLIENT ID}"
    dotnet user-secrets set "Authentication:Google:ClientSecret" "{CLIENT SECRET}"
    ```

[!INCLUDE[](~/includes/environmentVarableColon.md)]

Manage API credentials and usage in the [API Console](https://console.developers.google.com/apis/dashboard).

## Configure Google authentication

:::moniker range=">= aspnetcore-6.0"

Add the authentication service to the `Program` file:

:::code language="csharp" source="~/security/authentication/social/social-code/6.x/ProgramGoogle.cs" id="snippet1":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Add the authentication service to `Startup.ConfigureServices`:

```csharp
services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});
```

:::moniker-end

[!INCLUDE [default settings configuration](includes/default-settings.md)]

## Sign in with Google

* Run the app and select **Log in**. 
* Under **Use another service to log in.**, select Google.
* The browser is redirected to **Google** for authentication.
* Select the Google account to log in or enter Google credentials.
* If this is the first time signing in, there's a prompt to allow the app to access the Google account information.
* The browser is redirected back to the app, where it's possible to set the email.

The user is now logged in using Google credentials.

## Troubleshooting

* If the sign-in doesn't work without receiving any errors, switch to development mode to make the app and Google registration easier to debug.
* If the site's database hasn't been created by applying the initial migration, the following error occurs: *A database operation failed while processing the request*. Select **Apply Migrations** to create the database and refresh the page to continue past the error.
* For information about an HTTP 500 error after successfully authenticating the request by the OAuth 2.0 provider, such as Google, and information on how to implement external authentication with Google for React and other SPA apps, see [Middleware not handling 'signin-google' route after successful authentication in Asp.Net Core Web Api External Login Authentication (`dotnet/AspNetCore.Docs` #14169)](https://github.com/dotnet/AspNetCore.Docs/issues/14169).

## Next steps

* This article demonstrates authentication with Google. For information on authenticating with other external providers, see <xref:security/authentication/social/index>.
* After the app is deployed to Azure, reset the `ClientSecret` in the Google API console.
* Set the `Authentication:Google:ClientId` and `Authentication:Google:ClientSecret` as app settings in the Azure portal. The configuration system is set up to read keys from the environment variables.
