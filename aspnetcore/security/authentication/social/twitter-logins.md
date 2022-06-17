---
title: Twitter external sign-in setup with ASP.NET Core
author: rick-anderson
description: This tutorial demonstrates the integration of Twitter account user authentication into an existing ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 12/08/2021
monikerRange: '>= aspnetcore-3.0'
uid: security/authentication/twitter-logins
---
# Twitter external sign-in setup with ASP.NET Core

By [Valeriy Novytskyy](https://github.com/01binary) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This sample shows how to enable users to [sign in with their Twitter account](https://dev.twitter.com/web/sign-in/desktop-browser) using a sample ASP.NET Core project created on the [previous page](xref:security/authentication/social/index).

> [!NOTE]
> The Microsoft.AspNetCore.Authentication.Twitter package described below uses the OAuth 1a APIs provided by Twitter. Twitter has since added OAuth 2 APIs with a different set of functionality. The [AspNet.Security.OAuth.Twitter](https://www.nuget.org/packages/AspNet.Security.OAuth.Twitter/) package is a community implementation that uses the new OAuth 2 APIs.

## Create the app in Twitter

* Add the [Microsoft.AspNetCore.Authentication.Twitter](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Twitter) NuGet package to the project.

* Navigate to [twitter developer portal Dashboard](https://developer.twitter.com/en/portal/dashboard) and sign in. If you don't already have a Twitter account, use the **[Sign up now](https://twitter.com/signup)** link to create one.

* If you don't have a project, create one.

* Select **+ Add app**. Fill out the **App name** then record the generated API Key, API Key Secret and Bearer Token. These will be needed
later.

* In the **App Settings** page, select **Edit** in the **Authentication settings** section, then:
  * Enable 3-legged OAuth
  * Request email address from users
  * Fill out the required fields and select **Save**

  > [!NOTE]
  > Microsoft.AspNetCore.Identity requires users to have an email address by default. For Callback URLs during development, use `https://localhost:{PORT}/signin-twitter`, where the `{PORT}` placeholder is the app's port.

  > [!NOTE]
  > The URI segment `/signin-twitter` is set as the default callback of the Twitter authentication provider. You can change the default callback URI while configuring the Twitter authentication middleware via the inherited <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.CallbackPath%2A?displayProperty=nameWithType> property of the <xref:Microsoft.AspNetCore.Authentication.Twitter.TwitterOptions> class.


## Store the Twitter consumer API key and secret

Store sensitive settings such as the Twitter consumer API key and secret with [Secret Manager](xref:security/app-secrets). For this sample, use the following steps:

1. Initialize the project for secret storage per the instructions at [Enable secret storage](xref:security/app-secrets#enable-secret-storage).
1. Store the sensitive settings in the local secret store with the secrets keys `Authentication:Twitter:ConsumerKey` and `Authentication:Twitter:ConsumerSecret`:

    ```dotnetcli
    dotnet user-secrets set "Authentication:Twitter:ConsumerAPIKey" "<consumer-api-key>"
    dotnet user-secrets set "Authentication:Twitter:ConsumerSecret" "<consumer-secret>"
    ```

[!INCLUDE[](~/includes/environmentVarableColon.md)]

These tokens can be found on the **Keys and Access Tokens** tab after creating a new Twitter application:

## Configure Twitter Authentication

:::moniker range="< aspnetcore-6.0"

Add the Authentication service to the `Startup.ConfigureServices`:

[!code-csharp[](~/security/authentication/social/social-code/3.x/StartupTwitter3x.cs?name=snippet&highlight=10-15)]

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

[!code-csharp[](~/security/authentication/social/social-code/6.x/ProgramTwitter.cs)]

:::moniker-end


[!INCLUDE [default settings configuration](includes/default-settings.md)]

[!INCLUDE[](includes/chain-auth-providers.md)]

For more information on configuration options supported by Twitter authentication, see the <xref:Microsoft.AspNetCore.Builder.TwitterOptions> API reference. This can be used to request different information about the user.

## Sign in with Twitter

Run the app and select **Log in**. An option to sign in with Twitter appears:

Selecting **Twitter** redirects to Twitter for authentication:

After entering your Twitter credentials, you are redirected back to the web site where you can set your email.

You are now logged in using your Twitter credentials:

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

<!-- 
### React to cancel Authorize External sign-in
Twitter doesn't support AccessDeniedPath
Rather in the twitter setup, you can provide an External sign-in homepage. The external sign-in homepage doesn't support localhost. Tested with https://cors3.azurewebsites.net/ and that works.
-->

## Troubleshooting

* **ASP.NET Core 2.x only:** If Identity isn't configured by calling `services.AddIdentity` in `ConfigureServices`, attempting to authenticate will result in *ArgumentException: The 'SignInScheme' option must be provided*. The project template used in this sample ensures Identity is configured.
* If the site database has not been created by applying the initial migration, you will get *A database operation failed while processing the request* error. Tap **Apply Migrations** to create the database and refresh to continue past the error.

## Next steps

* This article showed how you can authenticate with Twitter. You can follow a similar approach to authenticate with other providers listed on the [previous page](xref:security/authentication/social/index).

* Once you publish your web site to Azure web app, you should reset the `ConsumerSecret` in the Twitter developer portal.

* Set the `Authentication:Twitter:ConsumerKey` and `Authentication:Twitter:ConsumerSecret` as application settings in the Azure portal. The configuration system is set up to read keys from environment variables.
