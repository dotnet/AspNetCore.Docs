---
title: Get started with ASP.NET Core
author: rick-anderson
description: A quick tutorial that creates and runs a simple Hello World app using ASP.NET Core. 
ms.author: riande
ms.custom: mvc
ms.date: 05/31/2018
uid: getting-started

# As a developer, I want to build an ASP.NET Core Hello World app so that I can try out ASP.NET Core.
---

# Tutorial: Get started with ASP.NET Core

This tutorial shows how to use the .NET Core command-line interface to create an ASP.NET Core web app. You'll learn how to:

> [!div class="checklist"]
> * Create a web app project.
> * Enable local HTTPS.
> * Run the app.
> * Edit a Razor page.

At the end, you'll have a working web app running on your local machine.

![Web app home page](_static/home-page.png)


## Prerequisites

* Install the [!INCLUDE [](~/includes/2.1-SDK.md)].

## Create a web app project

* Open a command shell, and enter the following command:

   ```console
   dotnet new webapp -o aspnetcoreapp
   ```

## Enable local HTTPS

* Trust the HTTPS development certificate:

# [Windows](#tab/windows)

  ```console
  dotnet dev-certs https --trust
  ```

  The preceding command displays the following dialog:

  ![Security warning dialog](_static/cert.png)

  Select **Yes** if you agree to trust the development certificate.

# [macOS](#tab/macos)

  ```console
  dotnet dev-certs https --trust
  ```

  The preceding command displays the following message:

  *Trusting the HTTPS development certificate was requested. If the certificate is not already trusted we will run the following command:* `'sudo security add-trusted-cert -d -r trustRoot -k /Library/Keychains/System.keychain <<certificate>>'`.  
  *This command might prompt you for your password to install the certificate on the system keychain.
  
  Password:*

  Enter your password if you agree to trust the development certificate.

# [Linux](#tab/linux)

  See the documentation for your Linux distribution on how to trust the HTTPS development certificate.
   
---

## Run the app

* Run the following commands:

   ```console
   cd aspnetcoreapp
   dotnet run
   ```

* Browse to [https://localhost:5001](https://localhost:5001). Click **Accept** to accept the privacy and cookie policy. This app doesn't keep personal information.

## Edit a Razor page

* Open *Pages/About.cshtml* and modify the page with the following highlighted markup:

   [!code-cshtml[](sample/getting-started/about.cshtml?highlight=9)]

* Browse to [https://localhost:5001/About](https://localhost:5001/About) and verify the changes are displayed.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a web app project.
> * Enable local HTTPS.
> * Run the project.
> * Make a change.

To learn more about ASP.NET Core, see the introduction:

> [!div class="nextstepaction"]
> <xref:index>



> [!NOTE]
> We’re testing the usability of a proposed new structure for the ASP.NET Core table of contents.  If you have a few minutes to try an exercise of finding 7 different topics in the current or proposed table of contents, please [click here to participate in the study](https://dpk4xbh5.optimalworkshop.com/treejack/rps16hd5).