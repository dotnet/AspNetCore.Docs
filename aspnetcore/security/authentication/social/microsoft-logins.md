---
title: Microsoft Account external login setup with ASP.NET Core
author: tdykstra
description: This sample demonstrates the integration of Microsoft account user authentication into an existing ASP.NET Core app.
ms.author: tdykstra
ms.custom: mvc
ms.date: 12/17/2025
monikerRange: '>= aspnetcore-3.1'
uid: security/authentication/microsoft-logins
---
# Microsoft Account external login setup with ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-6.0"

This sample shows how to enable users to sign in with their work, school, or personal Microsoft account using the ASP.NET Core  project created on the [previous page](xref:security/authentication/social/index).

## Create the app in the Microsoft Entra admin center

* Add the [Microsoft.AspNetCore.Authentication.MicrosoftAccount](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.MicrosoftAccount/) NuGet package to the project.
* Register the application in the Microsoft Entra admin center by following the steps in [Register an application with the Microsoft identity platform](/entra/identity-platform/quickstart-register-app?tabs=client-secret)

### Create a client secret

Generate a client secret in the Microsoft Entra admin center by following the steps in [Register an application with the Microsoft identity platform: Add Credentials](/entra/identity-platform/how-to-add-credentials).

## Store the Microsoft client ID and secret

Store sensitive settings such as the Microsoft **Application (client) ID** and **Client Secret** created in the previous step with [Secret Manager](xref:security/app-secrets). For this sample, use the following steps:

1. Initialize the project for secret storage per the instructions at [Enable secret storage](xref:security/app-secrets#enable-secret-storage).
1. Store the sensitive settings in the local secret store with the secret keys `Authentication:Microsoft:ClientId` and `Authentication:Microsoft:ClientSecret`. The `<client-id>` is listed on the Azure App registrations blade under **Application (client) ID**. The `<client-secret>` is on listed under **Certificates & secrets** as the **Value**, not the **Secret ID**. 

    ```dotnetcli
    dotnet user-secrets set "Authentication:Microsoft:ClientId" "<client-id>"
    dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "<client-secret>"
    ```

[!INCLUDE[](~/includes/environmentVarableColon.md)]

## Configure Microsoft Account Authentication

Add the Authentication service to the `Program`:

:::code language="csharp" source="~/security/authentication/social/social-code/6.x/ProgramMS.cs" id="snippet_AddServices":::

[!INCLUDE [default settings configuration](includes/default-settings.md)]

For more information about configuration options supported by Microsoft Account authentication, see the <xref:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions> API reference. This can be used to request different information about the user.

## Sign in with Microsoft Account

* Run the app and select **Log in**. An option to sign in with Microsoft appears.
* Select to sign in with Microsoft to navigate to Microsoft for authentication. After signing in with your Microsoft Account, you'll be prompted to let the app access your info:
* Select **Yes** to navigate back to the web site where to set your email.

You're now logged in using your Microsoft credentials.

To use multiple authentication providers, see <xref:security/authentication/social/index#multiple-authentication-providers>.

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

## Troubleshooting

* If the Microsoft Account provider redirects to a sign in error page, note the error title and description query string parameters directly following the `#` (hashtag) in the Uri.

  Although the error message seems to indicate a problem with Microsoft authentication, the most common cause is your application Uri not matching any of the **Redirect URIs** specified for the **Web** platform.

* If Identity isn't configured by calling `services.AddIdentity` in `ConfigureServices`, attempting to authenticate will result in *ArgumentException: The 'SignInScheme' option must be provided*. The project template used in this sample ensures that this is done.

* If the site database hasn't been created by applying the initial migration, *A database operation failed while processing the request* error occurs. Tap **Apply Migrations** to create the database and refresh to continue past the error.

## Next steps

* This article showed how to authenticate with Microsoft. Follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).
* Once the web site is published to Azure web app, create a new client secrets in the Microsoft Entra admin center.
* Set the `Authentication:Microsoft:ClientId` and `Authentication:Microsoft:ClientSecret` as application settings in the Microsoft Entra admin center. The configuration system is set up to read keys from environment variables.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This sample shows you how to enable users to sign in with their work, school, or personal Microsoft account using the ASP.NET Core 3.0 project created on the [previous page](xref:security/authentication/social/index).

## Create the app in the Microsoft Entra admin center

* Add the [Microsoft.AspNetCore.Authentication.MicrosoftAccount](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.MicrosoftAccount/) NuGet package to the project.
* Register the application in the Microsoft Entra admin center by following the steps in [Register an application with the Microsoft identity platform](/entra/identity-platform/quickstart-register-app?tabs=client-secret#register-an-application)

### Create client secret

Generate a client secret in the Microsoft Entra admin center by following the steps in [Register an application with the Microsoft identity platform: Add Credentials](/entra/identity-platform/how-to-add-credentials).

## Store the Microsoft client ID and secret

Store sensitive settings such as the Microsoft **Application (client) ID** and **Client Secret** you created in the previous step with [Secret Manager](xref:security/app-secrets). For this sample, use the following steps:

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

Run the app and select **Log in**. An option to sign in with Microsoft appears. Select **Microsoft** to navigate to Microsoft for authentication. After signing in with your Microsoft Account, you'll be prompted to let the app access your info:

Tap **Yes** and you'll be redirected back to the web site where you can set your email.

You're now logged in using your Microsoft credentials.

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

## Troubleshooting

* If the Microsoft Account provider redirects you to a sign in error page, note the error title and description query string parameters directly following the `#` (hashtag) in the Uri.

  Although the error message seems to indicate a problem with Microsoft authentication, the most common cause is your application Uri not matching any of the **Redirect URIs** specified for the **Web** platform.
* If Identity isn't configured by calling `services.AddIdentity` in `ConfigureServices`, attempting to authenticate will result in *ArgumentException: The 'SignInScheme' option must be provided*. The project template used in this sample ensures that this is done.
* If the site database hasn't been created by applying the initial migration, you'll get *A database operation failed while processing the request* error. Tap **Apply Migrations** to create the database and refresh to continue past the error.

## Next steps

* This article showed how you can authenticate with Microsoft. You can follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).
* Once you publish your web site to Azure web app, create a new client secrets in the Microsoft Entra admin center.
* Set the `Authentication:Microsoft:ClientId` and `Authentication:Microsoft:ClientSecret` as application settings in Microsoft Entra admin center. The configuration system is set up to read keys from environment variables.

:::moniker-end

## Additional resources

[Multiple authentication providers](xref:security/authentication/social/index#multiple-authentication-providers)
