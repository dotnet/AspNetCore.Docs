---
title: Microsoft Account external login setup with ASP.NET Core
author: rick-anderson
description: This sample demonstrates the integration of Microsoft account user authentication into an existing ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 12/08/2021
monikerRange: '>= aspnetcore-3.1'
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/microsoft-logins
---
# Microsoft Account external login setup with ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-6.0"

This sample shows you how to enable users to sign in with their work, school, or personal Microsoft account using the ASP.NET Core 6.0 project created on the [previous page](xref:security/authentication/social/index).

## Create the app in Microsoft Developer Portal

* Add the [Microsoft.AspNetCore.Authentication.MicrosoftAccount](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.MicrosoftAccount/) NuGet package to the project.
* Navigate to the [Azure portal - App registrations](https://go.microsoft.com/fwlink/?linkid=2083908) page and create or sign into a Microsoft account:

If you don't have a Microsoft account, select **Create one**. After signing in, you are redirected to the **App registrations** page:

* Select **New registration**
* Enter a **Name**.
* Select an option for **Supported account types**.  <!-- Accounts for any org work with MS domain accounts. Most folks probably want the last option, personal MS accounts. It took 24 hours after setting this up for the keys to work -->
  * The `MicrosoftAccount` package supports App Registrations created using "Accounts in any organizational directory" or "Accounts in any organizational directory and Microsoft accounts" options by default.
  * To use other options, set `AuthorizationEndpoint` and `TokenEndpoint` members of `MicrosoftAccountOptions` used to initialize the Microsoft Account authentication to the URLs displayed on **Endpoints** page of the App Registration after it is created (available by clicking Endpoints on the **Overview** page).
* Under **Redirect URI**, enter your development URL with `/signin-microsoft` appended. For example, `https://localhost:5001/signin-microsoft`. The Microsoft authentication scheme configured later in this sample will automatically handle requests at `/signin-microsoft` route to implement the OAuth flow.
* Select **Register**

### Create client secret

* In the left pane, select **Certificates & secrets**.
* Under **Client secrets**, select **New client secret**
  * Add a description for the client secret.
  * Select the **Add** button.
* Under **Client secrets**, copy the value of the client secret.

The URI segment `/signin-microsoft` is set as the default callback of the Microsoft authentication provider. You can change the default callback URI while configuring the Microsoft authentication middleware via the inherited <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.CallbackPath%2A?displayProperty=nameWithType> property of the <xref:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountOptions> class.

## Store the Microsoft client ID and secret

Store sensitive settings such as the Microsoft **Application (client) ID** found on the **Overview** page of the App Registration and **Client Secret** you created on the **Certificates & secrets page** with [Secret Manager](xref:security/app-secrets). For this sample, use the following steps:

1. Initialize the project for secret storage per the instructions at [Enable secret storage](xref:security/app-secrets#enable-secret-storage).
1. Store the sensitive settings in the local secret store with the secret keys `Authentication:Microsoft:ClientId` and `Authentication:Microsoft:ClientSecret`:

    ```dotnetcli
    dotnet user-secrets set "Authentication:Microsoft:ClientId" "<client-id>"
    dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "<client-secret>"
    ```

[!INCLUDE[](~/includes/environmentVarableColon.md)]

## Configure Microsoft Account Authentication

Add the Authentication service to the `Program`:

[!code-csharp[](~/security/authentication/social/social-code/6.x/ProgramMS.cs)]

[!INCLUDE [default settings configuration](includes/default-settings.md)]

For more information about configuration options supported by Microsoft Account authentication, see the <xref:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions> API reference. This can be used to request different information about the user.

## Sign in with Microsoft Account

* Run the app and select **Log in**. An option to sign in with Microsoft appears.
* Select to sign in with Microsoft. You are redirected to Microsoft for authentication. After signing in with your Microsoft Account, you will be prompted to let the app access your info:
* Select **Yes**. You are redirected back to the web site where you can set your email.

You are now logged in using your Microsoft credentials.

[!INCLUDE[](includes/chain-auth-providers.md)]

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

## Troubleshooting

* If the Microsoft Account provider redirects you to a sign in error page, note the error title and description query string parameters directly following the `#` (hashtag) in the Uri.

  Although the error message seems to indicate a problem with Microsoft authentication, the most common cause is your application Uri not matching any of the **Redirect URIs** specified for the **Web** platform.

* If Identity isn't configured by calling `services.AddIdentity` in `ConfigureServices`, attempting to authenticate will result in *ArgumentException: The 'SignInScheme' option must be provided*. The project template used in this sample ensures that this is done.

* If the site database has not been created by applying the initial migration, you will get *A database operation failed while processing the request* error. Tap **Apply Migrations** to create the database and refresh to continue past the error.

## Next steps

* This article showed how you can authenticate with Microsoft. You can follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).
* Once you publish your web site to Azure web app, create a new client secrets in the Microsoft Developer Portal.
* Set the `Authentication:Microsoft:ClientId` and `Authentication:Microsoft:ClientSecret` as application settings in the Azure portal. The configuration system is set up to read keys from environment variables.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This sample shows you how to enable users to sign in with their work, school, or personal Microsoft account using the ASP.NET Core 3.0 project created on the [previous page](xref:security/authentication/social/index).

## Create the app in Microsoft Developer Portal

* Add the [Microsoft.AspNetCore.Authentication.MicrosoftAccount](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.MicrosoftAccount/) NuGet package to the project.
* Navigate to the [Azure portal - App registrations](https://go.microsoft.com/fwlink/?linkid=2083908) page and create or sign into a Microsoft account:

If you don't have a Microsoft account, select **Create one**. After signing in, you are redirected to the **App registrations** page:

* Select **New registration**
* Enter a **Name**.
* Select an option for **Supported account types**.  <!-- Accounts for any org work with MS domain accounts. Most folks probably want the last option, personal MS accounts. It took 24 hours after setting this up for the keys to work -->
  * The `MicrosoftAccount` package supports App Registrations created using "Accounts in any organizational directory" or "Accounts in any organizational directory and Microsoft accounts" options by default.
  * To use other options, set `AuthorizationEndpoint` and `TokenEndpoint` members of `MicrosoftAccountOptions` used to initialize the Microsoft Account authentication to the URLs displayed on **Endpoints** page of the App Registration after it is created (available by clicking Endpoints on the **Overview** page).
* Under **Redirect URI**, enter your development URL with `/signin-microsoft` appended. For example, `https://localhost:5001/signin-microsoft`. The Microsoft authentication scheme configured later in this sample will automatically handle requests at `/signin-microsoft` route to implement the OAuth flow.
* Select **Register**

### Create client secret

* In the left pane, select **Certificates & secrets**.
* Under **Client secrets**, select **New client secret**
  * Add a description for the client secret.
  * Select the **Add** button.
* Under **Client secrets**, copy the value of the client secret.

The URI segment `/signin-microsoft` is set as the default callback of the Microsoft authentication provider. You can change the default callback URI while configuring the Microsoft authentication middleware via the inherited <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.CallbackPath%2A?displayProperty=nameWithType> property of the <xref:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountOptions> class.

## Store the Microsoft client ID and secret

Store sensitive settings such as the Microsoft **Application (client) ID** found on the **Overview** page of the App Registration and **Client Secret** you created on the **Certificates & secrets page** with [Secret Manager](xref:security/app-secrets). For this sample, use the following steps:

1. Initialize the project for secret storage per the instructions at [Enable secret storage](xref:security/app-secrets#enable-secret-storage).
1. Store the sensitive settings in the local secret store with the secret keys `Authentication:Microsoft:ClientId` and `Authentication:Microsoft:ClientSecret`:

    ```dotnetcli
    dotnet user-secrets set "Authentication:Microsoft:ClientId" "<client-id>"
    dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "<client-secret>"
    ```

[!INCLUDE[](~/includes/environmentVarableColon.md)]

## Configure Microsoft Account Authentication

Add the Microsoft Account service to the `Startup.ConfigureServices`:

:::code language="csharp" source="~/security/authentication/social/social-code/3.x/StartupMS3x.cs" id="snippet" highlight="10-14":::

[!INCLUDE [default settings configuration](includes/default-settings.md)]

For more information about configuration options supported by Microsoft Account authentication, see the <xref:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions> API reference. This can be used to request different information about the user.

## Sign in with Microsoft Account

Run the app and select **Log in**. An option to sign in with Microsoft appears. When you select on Microsoft, you are redirected to Microsoft for authentication. After signing in with your Microsoft Account, you will be prompted to let the app access your info:

Tap **Yes** and you will be redirected back to the web site where you can set your email.

You are now logged in using your Microsoft credentials.

[!INCLUDE[](includes/chain-auth-providers.md)]

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

## Troubleshooting

* If the Microsoft Account provider redirects you to a sign in error page, note the error title and description query string parameters directly following the `#` (hashtag) in the Uri.

  Although the error message seems to indicate a problem with Microsoft authentication, the most common cause is your application Uri not matching any of the **Redirect URIs** specified for the **Web** platform.
* If Identity isn't configured by calling `services.AddIdentity` in `ConfigureServices`, attempting to authenticate will result in *ArgumentException: The 'SignInScheme' option must be provided*. The project template used in this sample ensures that this is done.
* If the site database has not been created by applying the initial migration, you will get *A database operation failed while processing the request* error. Tap **Apply Migrations** to create the database and refresh to continue past the error.

## Next steps

* This article showed how you can authenticate with Microsoft. You can follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).
* Once you publish your web site to Azure web app, create a new client secrets in the Microsoft Developer Portal.
* Set the `Authentication:Microsoft:ClientId` and `Authentication:Microsoft:ClientSecret` as application settings in the Azure portal. The configuration system is set up to read keys from environment variables.

:::moniker-end
