---
title: Using external login providers with Identity in ASP.NET Core
author: rick-anderson
description: Create an ASP.NET Core app using Identity with external authentication providers such as Facebook, Twitter, Google, and Microsoft.
ms.author: riande
ms.custom: mvc, sfi-image-nochange
ms.date: 07/09/2025
uid: security/authentication/social/index
---
# External provider authentication in ASP.NET Core Identity

By [Valeriy Novytskyy](https://github.com/01binary) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This article explains how to build an ASP.NET Core app that enables users to sign in using OAuth 2.0 with credentials from external authentication providers.

[Facebook](xref:security/authentication/facebook-logins), [Twitter](xref:security/authentication/twitter-logins), [Google](xref:security/authentication/google-logins), and [Microsoft](xref:security/authentication/microsoft-logins) providers are covered in the following sections and use the starter project created in this article. Other providers are available in third-party packages such as [OpenIddict](https://documentation.openiddict.com/integrations/web-providers), [AspNet.Security.OAuth.Providers](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers) and [AspNet.Security.OpenId.Providers](https://github.com/aspnet-contrib/AspNet.Security.OpenId.Providers).

Enabling users to sign in with their existing credentials is convenient for the users and shifts many of the complexities of managing the sign-in process onto a third party.

## Create a New ASP.NET Core Project

# [Visual Studio](#tab/visual-studio)

* Select the **ASP.NET Core Web App** template. Select **OK**.
* In the **Authentication type** input,  select  **Individual Accounts**.

# [Visual Studio Code / .NET CLI](#tab/visual-studio-code+net-cli)

* Open a command shell. For Visual Studio Code, you can use the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).

* Change directories (`cd`) to a folder for the sample app.

* For Windows, run the following command:

  ```dotnetcli
  dotnet new webapp -o WebApp1 -au Individual -uld
  ```

  For macOS and Linux, run the following command:

  ```dotnetcli
  dotnet new webapp -o WebApp1 -au Individual
  ```

  * The `dotnet new` command uses the `-o|--output` option to create a new Razor Pages project in the `WebApp1` folder.
  * `-au Individual` creates the code for Individual authentication.
  * `-uld` uses LocalDB, a lightweight version of SQL Server Express for Windows. Omit `-uld` to use SQLite.

  For more information, see [`dotnet new <TEMPLATE>`](/dotnet/core/tools/dotnet-new).

---

## Apply migrations

* Run the app and select the **Register** link.
* Enter the email and password for the new account, and then select **Register**.
* Follow the instructions to apply migrations.

[!INCLUDE[Forward request information when behind a proxy or load balancer section](includes/forwarded-headers-middleware.md)]

## Use Secret Manager to store tokens assigned by login providers

Social login providers assign **Application Id** and **Application Secret** tokens during the registration process. The exact token names vary by provider. These tokens represent the credentials that the app uses to access the provider's API. The tokens constitute *user secrets* that can be linked to your app configuration with the help of [Secret Manager](xref:security/app-secrets#secret-manager). User secrets are a more secure alternative to storing the tokens in a configuration file, such as `appsettings.json`.

> [!IMPORTANT]
> Secret Manager is only for local development and testing. Protect staging and production secrets with the [Azure Key Vault configuration provider](xref:security/key-vault-configuration), which can also be used for local development and testing if you prefer not to use the Secret Manager locally.

For guidance on storing the tokens assigned by each login provider, see <xref:security/app-secrets>.

## Configure login providers

Use the following articles to configure login providers and the app:

* [Facebook](xref:security/authentication/facebook-logins) instructions
* [Twitter](xref:security/authentication/twitter-logins) instructions
* [Google](xref:security/authentication/google-logins) instructions
* [Microsoft](xref:security/authentication/microsoft-logins) instructions
* [Other provider](xref:security/authentication/otherlogins) instructions

## Multiple authentication providers

When the app requires multiple providers, chain the provider extension methods on <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>:

```csharp
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        // Google configuration options
    })
    .AddFacebook(options =>
    {
        // Facebook configuration options
    })
    .AddMicrosoftAccount(options =>
    {
        // Microsoft Account configuration options
    })
    .AddTwitter(options =>
    {
        // Twitter configuration options
    });
```

For detailed configuration guidance on each provider, see their respective articles.

## Optionally set a password

When you register with an external login provider, you don't have a password registered with the app. This alleviates you from creating and remembering a password for the site, but it also makes you completely dependent on the external login provider for site access. If the external login provider is unavailable, you won't be able to sign in to the app.

To create a password and sign in using your email that you set during the sign-in process with external providers:

* Select the **Hello &lt;email alias&gt;** link at the top-right corner to navigate to the **Manage** view:

![Web application Manage view](index/_static/pass1a.png)

* Select **Create**:

![Set your password page](index/_static/pass2a.png)

* Set a valid password, and you can use this credential to sign in with your email address.

## Additional information

* [Sign in with Apple Example Integration](https://github.com/martincostello/SignInWithAppleSample)
* [How to customize the login buttons (`dotnet/AspNetCore.Docs` #10563)](https://github.com/dotnet/AspNetCore.Docs/issues/10563)
* [Persist additional data about the user and their access and refresh tokens](xref:security/authentication/social/additional-claims)
