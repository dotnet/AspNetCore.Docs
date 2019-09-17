---
title: Articles based on ASP.NET Core projects created with individual user accounts
author: rick-anderson
description: Discover articles based on ASP.NET Core projects created with individual user accounts.
ms.author: riande
ms.date: 11/30/2017
uid: security/authentication/individual
---
# Articles based on ASP.NET Core projects created with individual user accounts

ASP.NET Core Identity is included in project templates in Visual Studio with the "Individual User Accounts" option.

The authentication templates are available in .NET Core CLI with `-au Individual`:

::: moniker range=">= aspnetcore-2.1"

```dotnetcli
dotnet new mvc -au Individual
dotnet new webapp -au Individual
```

::: moniker-end

::: moniker range="= aspnetcore-2.0"

```dotnetcli
dotnet new mvc -au Individual
dotnet new razor -au Individual
```

::: moniker-end

See [this GitHub issue](https://github.com/aspnet/AspNetCore/issues/5833) for web API authentication.

<a name="no"></a>

## No Authentication

Authentication is specified in the .NET Core CLI with the `-au` option. In Visual Studio, the **Change Authentication** dialog is available for new web applications. The default for new web apps in Visual Studio is **No Authentication**.

Projects created with no authentication:

* Don't contain web pages and UI to sign in and sign out.
* Don't contain authentication code.

<a name="win"></a>

## Windows Authentication

Windows Authentication is specified for new web apps in the .NET Core CLI with the `-au Windows` option. In Visual Studio, the **Change Authentication** dialog provides the **Windows Authentication** options.

If Windows Authentication is selected, the app is configured to use the [Windows Authentication IIS module](xref:host-and-deploy/iis/modules). Windows Authentication is intended for Intranet web sites.

## Additional resources

The following articles show how to use the code generated in ASP.NET Core templates that use individual user accounts:

* [Two-factor authentication with SMS](xref:security/authentication/2fa)
* [Account confirmation and password recovery in ASP.NET Core](xref:security/authentication/accconfirm)
* [Create an ASP.NET Core app with user data protected by authorization](xref:security/authorization/secure-data)
