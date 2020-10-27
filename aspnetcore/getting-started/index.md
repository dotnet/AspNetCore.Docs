---
title: Get started with ASP.NET Core
author: rick-anderson
description: A short tutorial that creates and runs a basic Hello World app using ASP.NET Core. 
ms.author: riande
ms.custom: mvc
ms.date: 01/07/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
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

![Web app home page](_static/home-page.png)

## Prerequisites

[!INCLUDE[](~/includes/3.1-SDK.md)]

## Create a web app project

Open a command shell, and enter the following command:

```dotnetcli
dotnet new webapp -o aspnetcoreapp
```

The preceding command:

* Creates a new web app.  
* The `-o aspnetcoreapp` parameter creates a directory named *aspnetcoreapp* with the source files for the app.

### Trust the development certificate

Trust the HTTPS development certificate:

# [Windows](#tab/windows)

```dotnetcli
dotnet dev-certs https --trust
```

The preceding command displays the following dialog:

![Security warning dialog](~/getting-started/_static/cert.png)

Select **Yes** if you agree to trust the development certificate.

# [macOS](#tab/macos)

```dotnetcli
dotnet dev-certs https --trust
```

The preceding command displays the following message:

*Trusting the HTTPS development certificate was requested. If the certificate is not already trusted, we will run the following command:* `'sudo security add-trusted-cert -d -r trustRoot -k /Library/Keychains/System.keychain <<certificate>>'`

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

After the command shell indicates that the app has started, browse to `https://localhost:5001`.

## Edit a Razor page

Open *Pages/Index.cshtml* and modify and save the page with the following highlighted markup:

[!code-cshtml[](sample/index.cshtml?highlight=9)]

Browse to `https://localhost:5001`, refresh the page, and verify the changes are displayed.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a web app project.
> * Trust the development certificate.
> * Run the project.
> * Make a change.

To learn more about ASP.NET Core, see the recommended learning path in the introduction:

> [!div class="nextstepaction"]
> <xref:index#recommended-learning-path>
