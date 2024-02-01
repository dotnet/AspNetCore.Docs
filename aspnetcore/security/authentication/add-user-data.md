---
title: Add, download, and delete user data to Identity in an ASP.NET Core project
author: rick-anderson
description: Learn how to add custom user data to Identity in an ASP.NET Core project. Delete data per GDPR.
ms.author: riande
ms.date: 03/15/2022
ms.custom: mvc
uid: security/authentication/add-user-data
---
# Add, download, and delete custom user data to Identity in an ASP.NET Core project

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This article shows how to:

* Add custom user data to an ASP.NET Core web app.
* Mark the custom user data model with the <xref:Microsoft.AspNetCore.Identity.PersonalDataAttribute> attribute so it's automatically available for download and deletion. Making the data able to be downloaded and deleted helps meet [GDPR](xref:security/gdpr) requirements.

The project sample is created from a Razor Pages web app, but the instructions are similar for an ASP.NET Core MVC web app.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authentication/add-user-data) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

:::moniker range=">= aspnetcore-6.0"

[!INCLUDE [](~/includes/6.0-SDK.md)]

## Create a Razor web app

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project**. Name the project **WebApp1** if you want to it match the namespace of the [download sample](https://github.com/dotnet/AspNetCore.Docs/tree/live/aspnetcore/security/authentication/add-user-data) code.
* Select **ASP.NET Core Web Application** > **OK**
* Select **Web Application** > **OK**
* Build and run the project.

# [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet new webapp -o WebApp1
```

---

## Run the Identity scaffolder

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add Scaffold** dialog, select **Identity** > **Add**.
* In the **Add Identity** dialog, the following options:
  * Select the existing layout  file  `~/Pages/Shared/_Layout.cshtml`
  * Select the following files to override:
    * **Account/Register**
    * **Account/Manage/Index**
  * Select the **+** button to create a new **Data context class**. Accept the type (**WebApp1.Models.WebApp1Context** if the project is named **WebApp1**).
  * Select the **+** button to create a new **User class**. Accept the type (**WebApp1User** if the project is named **WebApp1**) > **Add**.
* Select **Add**.

# [.NET Core CLI](#tab/netcore-cli)

If you have not previously installed the ASP.NET Core scaffolder, install it now:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

Add a package reference to [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/) to the project (.csproj) file. Run the following command in the project directory:

```dotnetcli
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
```

Run the following command to list the Identity scaffolder options:

```dotnetcli
dotnet aspnet-codegenerator identity -h
```

In the project folder, run the Identity scaffolder:

```dotnetcli
dotnet aspnet-codegenerator identity -u WebApp1User -fi Account.Register;Account.Manage.Index
```

PowerShell uses semicolon as a command separator. When using PowerShell, escape the semi-colons in the file list or put the file list in double quotes.

---

Follow the instruction in [Migrations, UseAuthentication, and layout](xref:security/authentication/scaffold-identity#efm) to perform the following steps:

* Create a migration and update the database.
* Add `UseAuthentication` to [`Program.cs`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/authentication/add-user-data/samples/6.x/SampleApp/Program.cs#L24)
* Add `<partial name="_LoginPartial" />` to the layout file.
* Test the app:
  * Register a user
  * Select the new user name (next to the **Logout** link). You might need to expand the window or select the navigation bar icon to show the user name and other links.
  * Select the **Personal Data** tab.
  * Select the **Download** button and examined the `PersonalData.json` file.
  * Test the **Delete** button, which deletes the logged on user.

## Add custom user data to the Identity DB

Update the `IdentityUser` derived class with custom properties. If you named the project WebApp1, the file is named `Areas/Identity/Data/WebApp1User.cs`. Update the file with the following code:

[!code-csharp[](add-user-data/samples/6.x/SampleApp/Areas/Identity/Data/WebApp1User.cs)]

Properties with the [PersonalData](xref:Microsoft.AspNetCore.Identity.PersonalDataAttribute) attribute are:

* Deleted when the `Areas/Identity/Pages/Account/Manage/DeletePersonalData.cshtml` Razor Page calls `UserManager.Delete`.
* Included in the downloaded data by the `Areas/Identity/Pages/Account/Manage/DownloadPersonalData.cshtml` Razor Page.

### Update the `Account/Manage/Index.cshtml` page

Update the `InputModel` in `Areas/Identity/Pages/Account/Manage/Index.cshtml.cs` with the following highlighted code:

[!code-csharp[](add-user-data/samples/6.x/SampleApp/Areas/Identity/Pages/Account/Manage/Index.cshtml.cs?name=snippet&highlight=30-38,54-55,97-107)]

Update the `Areas/Identity/Pages/Account/Manage/Index.cshtml` with the following highlighted markup:

[!code-cshtml[](add-user-data/samples/6.x/SampleApp/Areas/Identity/Pages/Account/Manage/Index.cshtml?highlight=18-25,81-82)]

### Update the `Account/Register.cshtml` page

Update the `InputModel` in `Areas/Identity/Pages/Account/Register.cshtml.cs` with the following highlighted code:

[!code-csharp[](add-user-data/samples/6.x/SampleApp/Areas/Identity/Pages/Account/Register.cshtml.cs?name=snippet&highlight=39-47,81-82)]

Update the `Areas/Identity/Pages/Account/Register.cshtml` with the following highlighted markup:

[!code-cshtml[](add-user-data/samples/6.x/SampleApp/Areas/Identity/Pages/Account/Register.cshtml?highlight=16-25)]

Build the project.

### Update the layout

See [Layout changes](xref:security/authentication/scaffold-identity#layout-changes) for instructions to add sign-in and sign-out links to every page.

### Add a migration for the custom user data

# [Visual Studio](#tab/visual-studio)

In the Visual Studio **Package Manager Console**:

```powershell
Add-Migration CustomUserData
Update-Database
```

# [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet ef migrations add CustomUserData
dotnet ef database update
```

---

## Test create, view, download, delete custom user data

Test the app:

* Register a new user.
* View the custom user data on the `/Identity/Account/Manage` page.
* Download and view the users personal data from the `/Identity/Account/Manage/PersonalData` page.
:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

[!INCLUDE [](~/includes/3.0-SDK.md)]

## Create a Razor web app

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project**. Name the project **WebApp1** if you want to it match the namespace of the [download sample](https://github.com/dotnet/AspNetCore.Docs/tree/live/aspnetcore/security/authentication/add-user-data) code.
* Select **ASP.NET Core Web Application** > **OK**
* Select **Web Application** > **OK**
* Build and run the project.

# [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet new webapp -o WebApp1
```

---

## Run the Identity scaffolder

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add Scaffold** dialog, select **Identity** > **Add**.
* In the **Add Identity** dialog, the following options:
  * Select the existing layout  file  `~/Pages/Shared/_Layout.cshtml`
  * Select the following files to override:
    * **Account/Register**
    * **Account/Manage/Index**
  * Select the **+** button to create a new **Data context class**. Accept the type (**WebApp1.Models.WebApp1Context** if the project is named **WebApp1**).
  * Select the **+** button to create a new **User class**. Accept the type (**WebApp1User** if the project is named **WebApp1**) > **Add**.
* Select **Add**.

# [.NET Core CLI](#tab/netcore-cli)

If you have not previously installed the ASP.NET Core scaffolder, install it now:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

Add a package reference to [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/) to the project (.csproj) file. Run the following command in the project directory:

```dotnetcli
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
```

Run the following command to list the Identity scaffolder options:

```dotnetcli
dotnet aspnet-codegenerator identity -h
```

In the project folder, run the Identity scaffolder:

```dotnetcli
dotnet aspnet-codegenerator identity -u WebApp1User -fi Account.Register;Account.Manage.Index
```

PowerShell uses semicolon as a command separator. When using PowerShell, escape the semi-colons in the file list or put the file list in double quotes.

---

Follow the instruction in [Migrations, UseAuthentication, and layout](xref:security/authentication/scaffold-identity#efm) to perform the following steps:

* Create a migration and update the database.
* Add `UseAuthentication` to `Startup.Configure`.
* Add `<partial name="_LoginPartial" />` to the layout file.
* Test the app:
  * Register a user
  * Select the new user name (next to the **Logout** link). You might need to expand the window or select the navigation bar icon to show the user name and other links.
  * Select the **Personal Data** tab.
  * Select the **Download** button and examined the `PersonalData.json` file.
  * Test the **Delete** button, which deletes the logged on user.

## Add custom user data to the Identity DB

Update the `IdentityUser` derived class with custom properties. If you named the project WebApp1, the file is named `Areas/Identity/Data/WebApp1User.cs`. Update the file with the following code:

[!code-csharp[](add-user-data/samples/3.x/SampleApp/Areas/Identity/Data/WebApp1User.cs)]

Properties with the [PersonalData](xref:Microsoft.AspNetCore.Identity.PersonalDataAttribute) attribute are:

* Deleted when the `Areas/Identity/Pages/Account/Manage/DeletePersonalData.cshtml` Razor Page calls `UserManager.Delete`.
* Included in the downloaded data by the `Areas/Identity/Pages/Account/Manage/DownloadPersonalData.cshtml` Razor Page.

### Update the Account/Manage/Index.cshtml page

Update the `InputModel` in `Areas/Identity/Pages/Account/Manage/Index.cshtml.cs` with the following highlighted code:

[!code-csharp[](add-user-data/samples/3.x/SampleApp/Areas/Identity/Pages/Account/Manage/Index.cshtml.cs?name=snippet&highlight=24-32,48-49,96-104,106)]

Update the `Areas/Identity/Pages/Account/Manage/Index.cshtml` with the following highlighted markup:

[!code-cshtml[](add-user-data/samples/3.x/SampleApp/Areas/Identity/Pages/Account/Manage/Index.cshtml?highlight=18-25)]

### Update the Account/Register.cshtml page

Update the `InputModel` in `Areas/Identity/Pages/Account/Register.cshtml.cs` with the following highlighted code:

[!code-csharp[](add-user-data/samples/3.x/SampleApp/Areas/Identity/Pages/Account/Register.cshtml.cs?name=snippet&highlight=30-38,70-71)]

Update the `Areas/Identity/Pages/Account/Register.cshtml` with the following highlighted markup:

[!code-cshtml[](add-user-data/samples/3.x/SampleApp/Areas/Identity/Pages/Account/Register.cshtml?highlight=16-25)]

Build the project.

### Add a migration for the custom user data

# [Visual Studio](#tab/visual-studio)

In the Visual Studio **Package Manager Console**:

```powershell
Add-Migration CustomUserData
Update-Database
```

# [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet ef migrations add CustomUserData
dotnet ef database update
```

---

## Test create, view, download, delete custom user data

Test the app:

* Register a new user.
* View the custom user data on the `/Identity/Account/Manage` page.
* Download and view the users personal data from the `/Identity/Account/Manage/PersonalData` page.

## Add claims to Identity using `IUserClaimsPrincipalFactory<ApplicationUser>`

> [!NOTE]
> This section isn't an extension of the previous tutorial. To apply the following steps to the app built using the tutorial, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/18797).

Additional claims can be added to ASP.NET Core Identity by using the `IUserClaimsPrincipalFactory<T>` interface. This class can be added to the app in the `Startup.ConfigureServices` method. Add the custom implementation of the class as follows:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, 
        AdditionalUserClaimsPrincipalFactory>();
```

The demo code uses the `ApplicationUser` class. This class adds an `IsAdmin` property which is used to add the additional claim.

```csharp
public class ApplicationUser : IdentityUser
{
    public bool IsAdmin { get; set; }
}
```

The `AdditionalUserClaimsPrincipalFactory` implements the `UserClaimsPrincipalFactory` interface. A new role claim is added to the `ClaimsPrincipal`.

```csharp
public class AdditionalUserClaimsPrincipalFactory 
        : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
{
    public AdditionalUserClaimsPrincipalFactory( 
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, 
        IOptions<IdentityOptions> optionsAccessor) 
        : base(userManager, roleManager, optionsAccessor)
    {}

    public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
    {
        var principal = await base.CreateAsync(user);
        var identity = (ClaimsIdentity)principal.Identity;

        var claims = new List<Claim>();
        if (user.IsAdmin)
        {
            claims.Add(new Claim(JwtClaimTypes.Role, "admin"));
        }
        else
        {
            claims.Add(new Claim(JwtClaimTypes.Role, "user"));
        }

        identity.AddClaims(claims);
        return principal;
    }
}
```

The additional claim can then be used in the app. In a Razor Page, the `IAuthorizationService` instance can be used to access the claim value.

```cshtml
@using Microsoft.AspNetCore.Authorization
@inject IAuthorizationService AuthorizationService

@if ((await AuthorizationService.AuthorizeAsync(User, "IsAdmin")).Succeeded)
{
    <ul class="mr-auto navbar-nav">
        <li class="nav-item">
            <a class="nav-link" asp-controller="Admin" asp-action="Index">ADMIN</a>
        </li>
    </ul>
}
```

:::moniker-end

:::moniker range="< aspnetcore-3.0"

[!INCLUDE [](~/includes/2.2-SDK.md)]

## Create a Razor web app

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project**. Name the project **WebApp1** if you want to it match the namespace of the [download sample](https://github.com/dotnet/AspNetCore.Docs/tree/live/aspnetcore/security/authentication/add-user-data) code.
* Select **ASP.NET Core Web Application** > **OK**
* Select **ASP.NET Core 2.2** in the dropdown
* Select **Web Application** > **OK**
* Build and run the project.

# [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet new webapp -o WebApp1
```

---

## Run the Identity scaffolder

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add Scaffold** dialog, select **Identity** > **Add**.
* In the **Add Identity** dialog, the following options:
  * Select the existing layout  file  `~/Pages/Shared/_Layout.cshtml`
  * Select the following files to override:
    * **Account/Register**
    * **Account/Manage/Index**
  * Select the **+** button to create a new **Data context class**. Accept the type (**WebApp1.Models.WebApp1Context** if the project is named **WebApp1**).
  * Select the **+** button to create a new **User class**. Accept the type (**WebApp1User** if the project is named **WebApp1**) > **Add**.
* Select **Add**.

# [.NET Core CLI](#tab/netcore-cli)

If you have not previously installed the ASP.NET Core scaffolder, install it now:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

Add a package reference to [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/) to the project (.csproj) file. Run the following command in the project directory:

```dotnetcli
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
```

Run the following command to list the Identity scaffolder options:

```dotnetcli
dotnet aspnet-codegenerator identity -h
```

In the project folder, run the Identity scaffolder:

```dotnetcli
dotnet aspnet-codegenerator identity -u WebApp1User -fi Account.Register;Account.Manage.Index
```

PowerShell uses semicolon as a command separator. When using PowerShell, escape the semi-colons in the file list or put the file list in double quotes.

---

Follow the instruction in [Migrations, UseAuthentication, and layout](xref:security/authentication/scaffold-identity#efm) to perform the following steps:

* Create a migration and update the database.
* Add `UseAuthentication` to `Startup.Configure`.
* Add `<partial name="_LoginPartial" />` to the layout file.
* Test the app:
  * Register a user
  * Select the new user name (next to the **Logout** link). You might need to expand the window or select the navigation bar icon to show the user name and other links.
  * Select the **Personal Data** tab.
  * Select the **Download** button and examined the `PersonalData.json` file.
  * Test the **Delete** button, which deletes the logged on user.

## Add custom user data to the Identity DB

Update the `IdentityUser` derived class with custom properties. If you named the project WebApp1, the file is named `Areas/Identity/Data/WebApp1User.cs`. Update the file with the following code:

[!code-csharp[](add-user-data/samples/2.x/SampleApp/Areas/Identity/Data/WebApp1User.cs)]


Properties with the [PersonalData](xref:Microsoft.AspNetCore.Identity.PersonalDataAttribute) attribute are:

* Deleted when the `Areas/Identity/Pages/Account/Manage/DeletePersonalData.cshtml` Razor Page calls `UserManager.Delete`.
* Included in the downloaded data by the `Areas/Identity/Pages/Account/Manage/DownloadPersonalData.cshtml` Razor Page.

### Update the Account/Manage/Index.cshtml page

Update the `InputModel` in `Areas/Identity/Pages/Account/Manage/Index.cshtml.cs` with the following highlighted code:

[!code-csharp[](add-user-data/samples/2.x/SampleApp/Areas/Identity/Pages/Account/Manage/Index.cshtml.cs?name=snippet&highlight=28-36,63-64,98-106,119)]

Update the `Areas/Identity/Pages/Account/Manage/Index.cshtml` with the following highlighted markup:

[!code-cshtml[](add-user-data/samples/2.x/SampleApp/Areas/Identity/Pages/Account/Manage/Index.cshtml?highlight=35-42)]

### Update the Account/Register.cshtml page

Update the `InputModel` in `Areas/Identity/Pages/Account/Register.cshtml.cs` with the following highlighted code:

[!code-csharp[](add-user-data/samples/2.x/SampleApp/Areas/Identity/Pages/Account/Register.cshtml.cs?name=snippet&highlight=28-36,67,66)]

Update the `Areas/Identity/Pages/Account/Register.cshtml` with the following highlighted markup:

[!code-cshtml[](add-user-data/samples/2.x/SampleApp/Areas/Identity/Pages/Account/Register.cshtml?highlight=16-25)]

Build the project.

### Add a migration for the custom user data

# [Visual Studio](#tab/visual-studio)

In the Visual Studio **Package Manager Console**:

```powershell
Add-Migration CustomUserData
Update-Database
```

# [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet ef migrations add CustomUserData
dotnet ef database update
```

---

## Test create, view, download, delete custom user data

Test the app:

* Register a new user.
* View the custom user data on the `/Identity/Account/Manage` page.
* Download and view the users personal data from the `/Identity/Account/Manage/PersonalData` page.

:::moniker-end
