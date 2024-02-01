---
title: Articles based on ASP.NET Core projects created with individual user accounts
author: rick-anderson
description: Discover articles based on ASP.NET Core projects created with individual user accounts.
ms.author: riande
ms.date: 12/11/2019
uid: security/authentication/individual
---
# Articles based on ASP.NET Core projects created with individual user accounts

ASP.NET Core Identity is included in project templates in Visual Studio with the "Individual User Accounts" option.

The authentication templates are available in .NET Core CLI with `-au Individual`:

:::moniker range=">= aspnetcore-2.1"

```dotnetcli
dotnet new mvc -au Individual
dotnet new webapp -au Individual
```

:::moniker-end

:::moniker range="= aspnetcore-2.0"

```dotnetcli
dotnet new mvc -au Individual
dotnet new razor -au Individual
```

:::moniker-end

See [this GitHub issue](https://github.com/dotnet/AspNetCore/issues/5833) for web API authentication.

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

## dotnet new webapp authentication options

The following table shows the authentication options available for new web apps:

| Option | Type of authentication | Link for more information |
 | ----------------- | ------------ | ---------- |
| None            |  No authentication. | | 
| Individual      |  Individual authentication. | <xref:security/authentication/identity>
| IndividualB2C   |  Cloud-hosted individual authentication with Azure AD B2C. | [Azure AD B2C](/azure/active-directory-b2c/) |
| SingleOrg       |  Organizational authentication for a single tenant. Entra External ID tenants also use SingleOrg.| [Entra ID](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp) |
| MultiOrg        |  Organizational authentication for multiple tenants. | [Entra ID](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp) |
| Windows         |  Windows authentication. | [Windows Authentication](xref:security/authentication/windowsauth)

## Visual Studio new webapp authentication options

The following table shows the authentication options available when creating a new web app with Visual Studio:

| Option | Type of authentication | Link for more information |
 | ----------------- | ------------ | ---------- |
| None            |  No authentication | | 
| Individual User Accounts / Store user accounts in-app |  Individual authentication | <xref:security/authentication/identity> |
| Individual User Accounts / Connect to an existing user store in the cloud |  Cloud-hosted individual authentication with Azure AD B2C | [Azure AD B2C](/azure/active-directory-b2c/) |
| Work or School Cloud / Single Org  |  Organizational authentication for a single tenant | [Azure AD](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp) |
| Work or School Cloud / Multiple Org |  Organizational authentication for multiple tenants | [Azure AD](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp) |
| Windows         |  Windows authentication | [Windows Authentication](xref:security/authentication/windowsauth)

## Additional resources

The following articles show how to use the code generated in ASP.NET Core templates that use individual user accounts:

* [Account confirmation and password recovery in ASP.NET Core](xref:security/authentication/accconfirm)
* [Create an ASP.NET Core app with user data protected by authorization](xref:security/authorization/secure-data)
