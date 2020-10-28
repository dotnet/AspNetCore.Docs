---
title: Secure ASP.NET Core Blazor Server apps
author: guardrex
description: Learn how to secure Blazor Server apps as ASP.NET Core applications.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 10/06/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/security/server/index
---
# Secure ASP.NET Core Blazor Server apps

By [Luke Latham](https://github.com/guardrex)

Blazor Server apps are configured for security in the same manner as ASP.NET Core apps. For more information, see the articles under <xref:security/index>. Topics under this overview apply specifically to Blazor Server.

## Blazor Server project template

The Blazor Server project template can be configured for authentication when the project is created.

# [Visual Studio](#tab/visual-studio)

Follow the Visual Studio guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism.

After choosing the **Blazor Server App** template in the **Create a new ASP.NET Core Web Application** dialog, select **Change** under **Authentication**.

A dialog opens to offer the same set of authentication mechanisms available for other ASP.NET Core projects:

* **No Authentication**
* **Individual User Accounts**: User accounts can be stored:
  * Within the app using ASP.NET Core's [Identity](xref:security/authentication/identity) system.
  * With [Azure AD B2C](xref:security/authentication/azure-ad-b2c).
* **Work or School Accounts**
* **Windows Authentication**

# [Visual Studio Code](#tab/visual-studio-code)

Follow the Visual Studio Code guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism:

```dotnetcli
dotnet new blazorserver -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{APP NAME}` placeholder to:

* Create a folder for the project.
* Name the project.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Follow the Visual Studio for Mac guidance in <xref:blazor/tooling>.

1. On the **Configure your new Blazor Server App** step, select **Individual Authentication (in-app)** from the **Authentication** drop down.

1. The app is created for individual users stored in the app with ASP.NET Core Identity.

# [.NET Core CLI](#tab/netcore-cli/)

Create a new Blazor Server project with an authentication mechanism using the following command in a command shell:

```dotnetcli
dotnet new blazorserver -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{APP NAME}` placeholder to:

* Create a folder for the project.
* Name the project.

For more information:

* See the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.
* Execute the help command for the Blazor Server template (`blazorserver`) in a command shell:

  ```dotnetcli
  dotnet new blazorserver --help
  ```

---

## Scaffold Identity

Scaffold Identity into a Blazor Server project:

* [Without existing authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project-without-existing-authorization).
* [With authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project-with-authorization).

## Additional resources

* [Quickstart: Add sign-in with Microsoft to an ASP.NET Core web app](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp)
* [Quickstart: Protect an ASP.NET Core web API with Microsoft identity platform](/azure/active-directory/develop/quickstart-v2-aspnet-core-web-api)
