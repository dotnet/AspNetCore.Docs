---
title: Introduction to Identity on ASP.NET Core
author: rick-anderson
description: Use Identity with an ASP.NET Core app. Includes, Setting password requirements (RequireDigit,RequiredLength,RequiredUniqueChars and more).
ms.author: riande
ms.date: 01/24/2018
uid: security/authentication/identity
---
# Introduction to Identity on ASP.NET Core

By  [Rick Anderson](https://twitter.com/RickAndMSFT), [Tom Dykstra](https://github.com/tdykstra), [Jon Galloway](https://twitter.com/jongalloway), and [Steve Smith](https://ardalis.com/)

ASP.NET Core Identity is a membership system which adds login functionality to ASP.NET Core apps. Users can create an account with the login information stored in Identity or they can use an external login provider. Supported external login providers include [Facebook, Google, Microsoft Account, and Twitter](xref:security/authentication/social).

Identity can be configured using a SQL Server database to store user names, passwords, and profile data. Alternatively, another persistent store can be used, for example, Azure Table Storage.

[View or download the sample code.](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/authentication/identity/sample/src/ASPNETCore-IdentityDemoComplete/) [(How to download)](xref:tutorials/index#how-to-download-a-sample)

## Overview of Identity

In this topic, you learn how to use ASP.NET Core Identity to add functionality to register, log in, and log out a user. For more detailed instructions about creating apps using ASP.NET Core Identity, see the Next Steps section at the end of this article.

### Create a Web app with authentication

Create an ASP.NET Core Web Application project with Individual User Accounts.

# [Visual Studio](#tab/visual-studio)

* Select **File** > **New** > **Project**. 
* Select **ASP.NET Core Web Application**. Name the project **WebApp1** to have the same namespace as the project download. Click **OK**.
* Select an ASP.NET Core **Web Application** for ASP.NET Core 2.1, then select **Change Authentication**.
* Select **Individual User Accounts** and click **OK**.

# [.NET Core CLI](#tab/netcore-cli)

```cli
dotnet new webapp --auth Individual -o WebApp1
```

---

The generated project provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor Class Library](xref:razor-pages/ui-class).

### Test Register and Login

Run the app and register a user. Depending on your screen size, you might need to select the navigation toggle button to see the **Register** and **Login** links.

![toggle navbar button](identity/_static/navToggle.png)

[!INCLUDE[](~/includes/view-identity-db.md)]

### Configure Identity services

   # [ASP.NET Core 2.x](#tab/aspnetcore2x/)

::: moniker range=">= aspnetcore-2.1"

::: moniker-end

::: moniker range="<= aspnetcore-2.0"

   [!code-csharp[](identity/sample/src/ASPNETv2-IdentityDemo/Startup.cs?name=snippet_configureservices&highlight=7-9,11-28,30-42)]

   These services are made available to the application through [dependency injection](xref:fundamentals/dependency-injection).

   Identity is enabled for the application by calling `UseAuthentication` in the `Configure` method. `UseAuthentication` adds authentication [middleware](xref:fundamentals/middleware/index) to the request pipeline.

   [!code-csharp[](identity/sample/src/ASPNETv2-IdentityDemo/Startup.cs?name=snippet_configure&highlight=17)]

::: moniker-end

   # [ASP.NET Core 1.x](#tab/aspnetcore1x/)

   [!code-csharp[](identity/sample/src/ASPNET-IdentityDemo/Startup.cs?name=snippet_configureservices&highlight=7-9,13-33)]

   These services are made available to the application through [dependency injection](xref:fundamentals/dependency-injection).

   Identity is enabled for the application by calling `UseIdentity` in the `Configure` method. `UseIdentity` adds cookie-based authentication [middleware](xref:fundamentals/middleware/index) to the request pipeline.

   [!code-csharp[](identity/sample/src/ASPNET-IdentityDemo/Startup.cs?name=snippet_configure&highlight=21)]

   ---

For more information, see [IdentityOptions Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.identityoptions?view=aspnetcore-2.0) and [Application Startup](xref:fundamentals/startup).



   When the user clicks the **Register** link, the `Register` action is invoked on `AccountController`. The `Register` action creates the user by calling `CreateAsync` on the `_userManager` object (provided to `AccountController` by dependency injection):

   [!code-csharp[](identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs?name=snippet_register&highlight=11)]

   If the user was created successfully, the user is logged in by the call to `_signInManager.SignInAsync`.

   **Note:** See [account confirmation](xref:security/authentication/accconfirm#prevent-login-at-registration) for steps to prevent immediate login at registration.

4. Log in.

   Users can sign in by clicking the **Log in** link at the top of the site, or they may be navigated to the Login page if they attempt to access a part of the site that requires authorization. When the user submits the form on the Login page, the `AccountController` `Login` action is called.

   The `Login` action calls `PasswordSignInAsync` on the `_signInManager` object (provided to `AccountController` by dependency injection).

   [!code-csharp[](identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs?name=snippet_login&highlight=13-14)]

   The base `Controller` class exposes a `User` property that you can access from controller methods. For instance, you can enumerate `User.Claims` and make authorization decisions. For more information, see [Authorization](xref:security/authorization/index).

5. Log out.

   Clicking the **Log out** link calls the `LogOut` action.

   [!code-csharp[](identity/sample/src/ASPNET-IdentityDemo/Controllers/AccountController.cs?name=snippet_logout&highlight=7)]

   The preceding code above calls the `_signInManager.SignOutAsync` method. The `SignOutAsync` method clears the user's claims stored in a cookie.

<a name="pw"></a>
6. Configuration.

   Identity has some default behaviors that can be overridden in the app's startup class. `IdentityOptions` don't need to be configured when using the default behaviors. The following code sets several password strength options:

   # [ASP.NET Core 2.x](#tab/aspnetcore2x/)

   [!code-csharp[](identity/sample/src/ASPNETv2-IdentityDemo/Startup.cs?name=snippet_configureservices&highlight=7-9,11-28,30-42)]

   # [ASP.NET Core 1.x](#tab/aspnetcore1x/)

   [!code-csharp[](identity/sample/src/ASPNET-IdentityDemo/Startup.cs?name=snippet_configureservices&highlight=13-33)]

   ---

   For more information about how to configure Identity, see [Configure Identity](xref:security/authentication/identity-configuration).

   You also can configure the data type of the primary key, see [Configure Identity primary keys data type](xref:security/authentication/identity-primary-key-configuration).

7. View the database.

   If your app is using a SQL Server database (the default on Windows and for Visual Studio users), you can view the database the app created. You can use **SQL Server Management Studio**. Alternatively, from Visual Studio, select **View** > **SQL Server Object Explorer**. Connect to **(localdb)\MSSQLLocalDB**. The database with a name matching `aspnet-<name of your project>-<guid>` is displayed.

   ![Contextual menu on AspNetUsers database table](identity/_static/04-db.png)

   Expand the database and its **Tables**, then right-click the **dbo.AspNetUsers** table and select **View Data**.

8. Verify Identity works

    The default *ASP.NET Core Web Application* project template allows users to access any action in the application without having to login. To verify that ASP.NET Identity works, add an`[Authorize]` attribute to the `About` action of the `Home` Controller.

    ```csharp
    [Authorize]
    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";
        return View();
    }
    ```

    # [Visual Studio](#tab/visual-studio)

    Run the project using **Ctrl** + **F5** and navigate to the **About** page. Only authenticated users may access the **About** page now, so ASP.NET redirects you to the login page to login or register.

    # [.NET Core CLI](#tab/netcore-cli)

    Open a command window and navigate to the project's root directory containing the `.csproj` file. Run the [dotnet run](/dotnet/core/tools/dotnet-run) command to run the app:

    ```csharp
    dotnet run 
    ```

    Browse the URL specified in the output from the [dotnet run](/dotnet/core/tools/dotnet-run) command. The URL should point to `localhost` with a generated port number. Navigate to the **About** page. Only authenticated users may access the **About** page now, so ASP.NET redirects you to the login page to login or register.

    ---

## Identity Components

The primary reference assembly for the Identity system is `Microsoft.AspNetCore.Identity`. This package contains the core set of interfaces for ASP.NET Core Identity, and is included by `Microsoft.AspNetCore.Identity.EntityFrameworkCore`.

These dependencies are needed to use the Identity system in ASP.NET Core applications:

* `Microsoft.AspNetCore.Identity.EntityFrameworkCore` - Contains the required types to use Identity with Entity Framework Core.

* `Microsoft.EntityFrameworkCore.SqlServer` - Entity Framework Core is Microsoft's recommended data access technology for relational databases like SQL Server. For testing, you can use `Microsoft.EntityFrameworkCore.InMemory`.

* `Microsoft.AspNetCore.Authentication.Cookies` - Middleware that enables an app to use cookie-based authentication.

## Migrating to ASP.NET Core Identity

For additional information and guidance on migrating your existing Identity store see [Migrate Authentication and Identity](xref:migration/identity).

## Setting password strength

See [Configuration](#pw) for a sample that sets the minimum password requirements.

## Next Steps

* <xref:migration/identity>
* <xref:security/authentication/accconfirm>
* <xref:security/authentication/2fa>
* <xref:security/authentication/social/index>
* <xref:host-and-deploy/web-farm>
