---
title: Get started with ASP.NET Core
author: tdykstra
description: A short tutorial using the .NET CLI to create and run a basic Hello World app using ASP.NET Core.
monikerRange: ">= aspnetcore-3.1"
ms.author: riande
ms.custom: mvc
ms.date: 03/07/2022
uid: getting-started
---
# Tutorial: Get started with ASP.NET Core

This tutorial shows how to create and run an ASP.NET Core web app using the .NET Core CLI.

You'll learn how to:

> [!div class="checklist"]
> * Create a web app project.
> * Trust the development certificate.
> * Run the app.
> * Edit a Razor page.

At the end, you'll have a working web app running on your local machine.

:::image source="_static/home-page.png" alt-text="Web app home page":::

## Prerequisites

:::moniker range=">= aspnetcore-7.0"
[!INCLUDE[](~/includes/7.0-SDK.md)]
:::moniker-end
:::moniker range=">= aspnetcore-6.0  < aspnetcore-7.0"
[!INCLUDE[](~/includes/6.0-SDK.md)]
:::moniker-end
:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"
[!INCLUDE[](~/includes/5.0-SDK.md)]
:::moniker-end
:::moniker range="< aspnetcore-5.0"
[!INCLUDE[](~/includes/3.1-SDK.md)]
:::moniker-end

## Create a web app project

Open a command shell, and enter the following command:

```dotnetcli
dotnet new webapp -o aspnetcoreapp
```

The preceding command:

* Creates a new web app.  
* The `-o aspnetcoreapp` parameter creates a directory named `aspnetcoreapp` with the source files for the app.

### Trust the development certificate

Trust the HTTPS development certificate:

# [Windows](#tab/windows)

```dotnetcli
dotnet dev-certs https --trust
```

The preceding command displays the following dialog:

:::image source="~/getting-started/_static/cert.png" alt-text="Security warning dialog":::

Select **Yes** if you agree to trust the development certificate.

# [macOS](#tab/macos)

```dotnetcli
dotnet dev-certs https --trust
```

The preceding command displays the following message:

*Trusting the HTTPS development certificate was requested. If the certificate isn't already trusted, we'll run the following command:* `'sudo security add-trusted-cert -d -r trustRoot -k /Library/Keychains/System.keychain <<certificate>>'`

This command might prompt you for your password to install the certificate on the system keychain. Enter your password if you agree to trust the development certificate.

# [Linux](#tab/linux)

See the documentation for your Linux distribution on how to trust the HTTPS development certificate.

---

For more information, see [Trust the ASP.NET Core HTTPS development certificate](xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos)

## Run the app

Run the following commands:

```dotnetcli
cd aspnetcoreapp
dotnet watch run
```

After the command shell indicates that the app has started, browse to `https://localhost:{port}`, where `{port}`is the random port used.

## Edit a Razor page

Open `Pages/Index.cshtml` and modify and save the page with the following highlighted markup:

:::code language="cshtml" source="sample/index.cshtml" highlight="9":::

Browse to `https://localhost:{port}`, refresh the page, and verify the changes are displayed.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a web app project.
> * Trust the development certificate.
> * Run the project.
> * Make a change.

To learn more about ASP.NET Core, see the following:

> [!div class="nextstepaction"]
> <xref:index#recommended-learning-path>
