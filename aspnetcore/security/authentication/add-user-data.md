---
title: Add, download, and delete user data to Identity in an ASP.NET Core project
ai-usage: ai-assisted
description: Learn how to add custom user data to Identity in an ASP.NET Core project. Delete data per GDPR.
monikerRange: '>= aspnetcore-10.0'
ms.date: 07/05/2026
---
# Add, download, and delete custom user data to Identity in an ASP.NET Core project

This article shows how to:

* Add custom user data to an ASP.NET Core web app.
* Mark the custom user data model with the <xref:Microsoft.AspNetCore.Identity.PersonalDataAttribute> attribute so it's automatically available for download and deletion. Making the data able to be downloaded and deleted helps meet [GDPR](../gdpr.md) requirements.

The project sample is created from a Razor Pages web app, but the instructions are similar for an ASP.NET Core MVC web app.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authentication/add-user-data) ([how to download](../../fundamentals/index.md#how-to-download-a-sample))

## Prerequisites

:::moniker range=">= aspnetcore-10.0"

[!INCLUDE [](~/includes/10.0-SDK.md)]

## Quickstart: Add two custom properties

For the common case of adding two custom properties such as `FirstName` and `LastName`:

1. Create a new ASP.NET Core project with Individual Accounts authentication
1. Scaffold Identity to override the Register and Manage/Index pages
1. Add custom properties such as `FirstName` and `LastName` to the user class, with the `[PersonalData]` attribute.
1. Update the Register and Manage/Index pages to include input fields for your properties.
1. Create and apply a migration.
1. Test registration and profile management.

The sections below provide detailed step-by-step instructions for this process.

## Create a web app

You can create either a Razor Pages or MVC web app. Both use the same Identity Razor Pages UI.

### Razor Pages

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project/Solution...**.
* Select **ASP.NET Core Web App (Razor Pages)** > **Next**
* Name the project **WebApp1** if you want it to match the namespace of the [download sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authentication/add-user-data) code. Select **Next**.
* Select **Authentication type** > **Individual Accounts** > **Create**
* Build and run the project.

# [.NET CLI](#tab/net-cli)

```dotnetcli
dotnet new webapp -au Individual -o WebApp1
```

---

### MVC

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project/Solution...**.
* Select **ASP.NET Core Web App (Model-View-Controller)** > **Next**
* Name the project **WebApp1** if you want it to match the namespace of the [download sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authentication/add-user-data) code. Select **Next**.
* Select **Authentication type** > **Individual Accounts** > **Create**
* Build and run the project.

# [.NET CLI](#tab/net-cli)

```dotnetcli
dotnet new mvc -au Individual -o WebApp1
```

---

> [!NOTE]
> Identity UI is implemented as a Razor Class Library. When you create an MVC project with authentication, the Identity pages are served from the Razor Class Library, which means your MVC project uses Razor Pages for Identity even though the rest of the project uses MVC controllers and views.

## Run the Identity scaffolder

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add Scaffold** dialog, select **Identity** > **Add**.
* In the **Add Identity** dialog, the following options:
  * Select the existing layout file `~/Pages/Shared/_Layout.cshtml` for Razor Pages or `~/Views/Shared/_Layout.cshtml` for MVC
  * Select the following files to override:
    * **Account/Register**
    * **Account/Manage/Index**
  * Select the **+** button to create a new **Data context class**. Accept the type (**WebApp1.Models.WebApp1Context** if the project is named **WebApp1**).
  * Select the **+** button to create a new **User class**. Accept the type (**WebApp1User** if the project is named **WebApp1**) > **Add**.
* Select **Add**.

# [.NET CLI](#tab/net-cli)

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

Follow the instructions in [Migrations, UseAuthentication, and layout](scaffold-identity.md#migrations-useauthentication-and-layout) to perform the following steps:

* Create a migration and update the database.
* Add `UseAuthentication` to [`Program.cs`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/authentication/add-user-data/samples/10.x/SampleApp/Program.cs#L24)
* Add `<partial name="_LoginPartial" />` to the layout file.
* Test the app:
  * Register a user
  * Select the new user name (next to the **Logout** link). You might need to expand the window or select the navigation bar icon to show the user name and other links.
  * Select the **Personal Data** tab.
  * Select the **Download** button and examine the `PersonalData.json` file.
  * Test the **Delete** button, which deletes the logged on user.

## Add custom user data to the Identity DB

Update the `IdentityUser` derived class with custom properties. If you named the project WebApp1, the file is named `Areas/Identity/Data/WebApp1User.cs`. Update the file with the following code:

[!code-csharp[](add-user-data/samples/10.x/SampleApp/Areas/Identity/Data/WebApp1User.cs)]

Properties with the [PersonalData](xref:Microsoft.AspNetCore.Identity.PersonalDataAttribute) attribute are:

* Deleted when the `Areas/Identity/Pages/Account/Manage/DeletePersonalData.cshtml` Razor Page calls `UserManager.Delete`.
* Included in the downloaded data by the `Areas/Identity/Pages/Account/Manage/DownloadPersonalData.cshtml` Razor Page.

### Update the `Account/Manage/Index.cshtml` page

Update the `InputModel` in `Areas/Identity/Pages/Account/Manage/Index.cshtml.cs` with the following highlighted code:

[!code-csharp[](add-user-data/samples/10.x/SampleApp/Areas/Identity/Pages/Account/Manage/Index.cshtml.cs?name=snippet&highlight=30-38,54-55,97-107)]

Update the `Areas/Identity/Pages/Account/Manage/Index.cshtml` with the following highlighted markup:

[!code-cshtml[](add-user-data/samples/10.x/SampleApp/Areas/Identity/Pages/Account/Manage/Index.cshtml?highlight=18-25)]

### Update the `Account/Register.cshtml` page

Update the `InputModel` in `Areas/Identity/Pages/Account/Register.cshtml.cs` with the following highlighted code:

[!code-csharp[](add-user-data/samples/10.x/SampleApp/Areas/Identity/Pages/Account/Register.cshtml.cs?name=snippet&highlight=39-47,81-82)]

Update the `Areas/Identity/Pages/Account/Register.cshtml` with the following highlighted markup:

[!code-cshtml[](add-user-data/samples/10.x/SampleApp/Areas/Identity/Pages/Account/Register.cshtml?highlight=16-25)]

Build the project.

### Update the layout

See [Layout changes](scaffold-identity.md#layout-changes) for instructions to add sign-in and sign-out links to every page.

### Add a migration for the custom user data

# [Visual Studio](#tab/visual-studio)

In the Visual Studio **Package Manager Console**:

```powershell
Add-Migration CustomUserData
Update-Database
```

# [.NET CLI](#tab/net-cli)

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

## Troubleshooting

If you encounter issues:

| Symptom | Likely Cause | Solution |
|---------|--------------|----------|
| Custom fields don't appear in registration form | Forgot to update Register.cshtml | Ensure you've scaffolded and modified `Areas/Identity/Pages/Account/Register.cshtml` |
| Custom data not saving | Forgot to add migration or update database | Run `dotnet ef migrations add CustomUserData` then `dotnet ef database update` |
| Custom fields not in downloaded data | Missing `[PersonalData]` attribute | Add `[PersonalData]` attribute to properties in your user class |
| Build errors after scaffolding | Package version mismatch | Ensure all Identity packages match your target framework version |

:::moniker-end
