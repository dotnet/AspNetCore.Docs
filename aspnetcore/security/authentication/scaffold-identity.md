---
title: Scaffold Identity in ASP.NET Core projects
author: rick-anderson
description: Learn how to scaffold Identity in an ASP.NET Core project.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 07/22/2024
uid: security/authentication/scaffold-identity
---
# Scaffold Identity in ASP.NET Core projects

By [Rick Anderson](https://twitter.com/RickAndMSFT)

<!-- VS add Microsoft.EntityFrameworkCore.Design -->

:::moniker range=">= aspnetcore-8.0"

## Blazor Identity scaffolding

ASP.NET Core Identity scaffolding adds [ASP.NET Core Identity](xref:security/authentication/identity) to Blazor Web Apps and Blazor Server apps. After the scaffolder adds the Identity Razor components to the app, you can customize the components to suit your app's requirements.

Although the scaffolder generates the necessary C# code to scaffold Identity into the app, you must update the project's database with an Entity Framework (EF) Core database migration to complete the process. This article explains the steps required to migrate a database.

Inspect the changes after running the Identity scaffolder. We recommend using GitHub or another source control system that shows file changes with a revert changes feature.

Services are required when using [two-factor authentication (2FA)](xref:blazor/security/server/qrcodes-for-authenticator-apps), [account confirmation and password recovery](xref:blazor/security/server/account-confirmation-and-password-recovery), and other security features with Identity. Services or service stubs aren't generated when scaffolding Identity. Services to enable these features must be added manually.

## Razor Pages and MVC Identity scaffolding

ASP.NET Core provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor class library (RCL)](xref:razor-pages/ui-class). Applications that include Identity can apply the scaffolder to selectively add the source code contained in the Identity RCL. You might want to generate source code so you can modify the code and change the behavior. For example, you could instruct the scaffolder to generate the code used in registration. Customized Identity code overrides the default implementation provided by the Identity RCL. To gain full control of the UI and not use the default RCL, see the [Create full Identity UI source](#full) section.

Applications that do **not** include authentication can apply the scaffolder to add the RCL Identity package. You have the option of selecting Identity code to be generated.

Although the scaffolder generates most of the necessary code, you need to update your project to complete the process. This document explains the steps needed to complete an Identity scaffolding update.

We recommend using a source control system that shows file differences and allows you to back out of changes. Inspect the changes after running the Identity scaffolder.

Services are required when using [Two Factor Authentication](xref:security/authentication/identity-enable-qrcodes), [Account confirmation and password recovery](xref:security/authentication/accconfirm), and other security features with Identity. Services or service stubs aren't generated when scaffolding Identity. Services to enable these features must be added manually. For example, see [Require Email Confirmation](xref:security/authentication/accconfirm#require-email-confirmation).

Typically, apps created with individual accounts should ***not*** create a new data context.

## Scaffold Identity into a Blazor project

*This section applies to Blazor Web Apps and Blazor Server apps.*

Run the Identity scaffolder:

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add New Scaffolded Item** dialog, select **Identity**. Select **Blazor Identity** in the center pane. Select the **Add** button.
* In the **Add Blazor Identity** dialog:
  * Select or add with the plus (**+**) button the database context class (**DbContext class**).
  * Select the database provider (**Database provider**), which defaults to SQL Server.
  * Select or add with the plus (**+**) button the user class (**User class**).
  * Select the **Add** button.

# [.NET CLI](#tab/net-cli)

To add the required NuGet packages and tools, execute the following .NET CLI commands in a command shell opened to the project's root folder.

Paste all of the following commands at the prompt (`>`) of the command shell. When you paste multiple commands, a warning appears stating that multiple commands will execute. Select the **Paste anyway** button.

When you paste multiple commands, all but the last one runs. Press <kbd>Enter</kbd> to run the last command.

The following commands assume that you're using a SQL Server database and the SQL Server Entity EF Core database provider package ([`Microsoft.EntityFrameworkCore.SqlServer`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)). If you're using a different database, swap the EF Core database provider package. The following providers are supported by the scaffolding tool&dagger;:

* SQLServer: [`Microsoft.EntityFrameworkCore.SqlServer`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)
* SQLite: [`Microsoft.EntityFrameworkCore.Sqlite`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite)
* Cosmos: [`Microsoft.EntityFrameworkCore.Cosmos`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Cosmos)
* Postgres: [`Npgsql.EntityFrameworkCore.PostgreSQL`](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL)

&dagger;The SQL Server, SQLite, and Cosmos database provider packages are owned, maintained, and supported by Microsoft. The PostgreSQL database provider package is owned, maintained, and supported by [The Npgsql Development Team](https://www.npgsql.org/) ([`npgsql/efcore.pg` Github repository)](https://github.com/npgsql/efcore.pg)).

```dotnetcli
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

> [!IMPORTANT]
> After the first five commands execute, make sure that you press <kbd>Enter</kbd> on the keyboard to execute the last command.

The preceding commands add:

* [Command-line interface (CLI) tools for EF Core](/ef/core/miscellaneous/cli/dotnet)
* [`aspnet-codegenerator` scaffolding tool](xref:fundamentals/tools/dotnet-aspnet-codegenerator)
* Design time tools for EF Core
* The SQLite and SQL Server providers with the EF Core package as a dependency
* [`Microsoft.VisualStudio.Web.CodeGeneration.Design`](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design) for scaffolding

Run the following command to list the Identity scaffolder options:

```dotnetcli
dotnet aspnet-codegenerator identity -h
```

In the project folder, run the Identity scaffolder with the options you want. To scaffold Identity with the default Identity UI and the minimum number of files, run the following command:

```dotnetcli
dotnet aspnet-codegenerator identity --useDefaultUI
```

---

The generated Identity database code requires [EF Core Migrations](/ef/core/managing-schemas/migrations/). The following steps explain how to create and apply a migration to the database.

# [Visual Studio](#tab/visual-studio)

[Visual Studio Connected Services](/visualstudio/azure/overview-connected-services) are used to add an EF Core migration and update the database.

In **Solution Explorer**, double-click **Connected Services**. In the **SQL Server Express LocalDB** area of **Service Dependencies**, select the ellipsis (**`...`**) followed by **Add migration**.

Give the migration a **Migration name**, such as `CreateIdentitySchema`, which is a name that describes the migration. Wait for the database context to load in the **DbContext class names** field, which may take a few seconds. Select **Finish** to create the migration.

Select the **Close** button after the operation finishes.

Select the ellipsis (**`...`**) again followed by the **Update database** command.

The **Update database with the latest migration** dialog opens. Wait for the **DbContext class names** field to update and for prior migrations to load, which may take a few seconds. Select the **Finish** button.

Select the **Close** button after the operation finishes.

The update database command executes the `Up` method migrations that haven't been applied in a migration code file created by the scaffolder. In this case, the command executes the `Up` method in the `Migrations/{TIME STAMP}_{MIGRATION NAME}.cs` file, which creates the Identity tables, constraints, and indexes. The `{TIME STAMP}` placeholder is a time stamp, and the `{MIGRATION NAME}` placeholder is the migration name.

# [.NET CLI](#tab/net-cli)

From the project's root folder, execute the following .NET CLI command to add a migration. The `{MIGRATION NAME}` placeholder is used to name the migration, such as `CreateIdentitySchema`. Any name can be used, but the convention is to use a name that describes the migration.

```dotnetcli
dotnet ef migrations add {MIGRATION NAME}
```

Example:

```dotnetcli
dotnet ef migrations add CreateIdentitySchema
```

After the preceding command completes, update the database with the `update` command.

```dotnetcli
dotnet ef database update
```

The `update` command executes the `Up` method migrations that haven't been applied in a migration code file created by the scaffolder. In this case, the command executes the `Up` method in the `Migrations/{TIME STAMP}_{MIGRATION NAME}.cs` file, which creates the Identity tables, constraints, and indexes. The `{TIME STAMP}` placeholder is a time stamp, and the `{MIGRATION NAME}` placeholder is the migration name.

---

## Client-side Blazor apps (Standalone Blazor WebAssembly)

Client-side Blazor apps (Standalone Blazor WebAssembly) use their own Identity UI approaches and can't use ASP.NET Core Identity scaffolding.

For more information, see the [Blazor Security and Identity articles](xref:blazor/security/index).

<a name="RPNA"></a>

## Scaffold Identity into a Razor project without existing authorization

<!--  Updated for 3.0
set projNam=RPnoAuth
set projType=webapp

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef database drop
dotnet ef migrations add CreateIdentitySchema0
dotnet ef database update
-->

<!-- ERROR
There is already an object named 'AspNetRoles' in the database.

Fixed via dotnet ef database drop
before dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

<a name="efm"></a>

### Migrations, UseAuthentication, and layout

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

<a name="useauthentication"></a>

<!--
### Enable authentication

Update the `Startup` class with code similar to the following:

[!code-csharp[](scaffold-identity/3.1sample/StartupRP.cs?name=snippet)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)] -->

### Layout changes

Optional: Add the login partial (`_LoginPartial`) to the layout file:

[!code-cshtml[](scaffold-identity/6.0sample/_Layout.cshtml?highlight=29)]

## Scaffold Identity into a Razor project with authorization

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

<!--
Use >=2.1: dotnet new webapp -au Individual -o RPauth
Use = 2.0: dotnet new razor -au Individual -o RPauth
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

## Scaffold Identity into an MVC project without existing authorization

<!--
set projNam=MvcNoAuth
set projType=mvc
set version=2.1.0

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v %version%
dotnet restore
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Optional: Add the login partial (`_LoginPartial`) to the `Views/Shared/_Layout.cshtml` file:

[!code-cshtml[](scaffold-identity/6.0sample/_Layout.cshtml?highlight=29)]

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

Add `MapRazorPages` to `Program.cs` as shown in the following highlighted code:

[!code-csharp[](scaffold-identity/6.0sample/ProgramMRP.cs?highlight=39)]

## Scaffold Identity into an MVC project with authorization

<!--
dotnet new mvc -au Individual -o MvcAuth
cd MvcAuth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator identity -dc MvcAuth.Data.ApplicationDbContext  --files "Account.Login;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

<a name="full"></a>

## Create full Identity UI source

<!-- remove AllowAreas  #23280 -->
To maintain full control of the Identity UI, run the Identity scaffolder and select **Override all files**.

<!--
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
-->

## Password configuration

If <xref:Microsoft.AspNetCore.Identity.PasswordOptions> are configured in `Startup.ConfigureServices`, [`[StringLength]` attribute](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute) configuration might be required for the `Password` property in scaffolded Identity pages. `InputModel` `Password` properties are found in the following files:

* `Areas/Identity/Pages/Account/Register.cshtml.cs`
* `Areas/Identity/Pages/Account/ResetPassword.cshtml.cs`

## Disable a page

This section shows how to disable the register page but the approach can be used to disable any page.

To disable user registration:

* Scaffold Identity. Include Account.Register, Account.Login, and Account.RegisterConfirmation. For example:

  ```dotnetcli
   dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
  ```

* Update `Areas/Identity/Pages/Account/Register.cshtml.cs` so users can't register from this endpoint:

  [!code-csharp[](scaffold-identity/sample/Register.cshtml.cs?name=snippet)]

* Update `Areas/Identity/Pages/Account/Register.cshtml` to be consistent with the preceding changes:

  [!code-cshtml[](scaffold-identity/sample/Register.cshtml)]

* Comment out or remove the registration link from `Areas/Identity/Pages/Account/Login.cshtml`

  ```cshtml
  @*
  <p>
      <a asp-page="./Register" asp-route-returnUrl="@Model.ReturnUrl">Register as a new user</a>
  </p>
  *@
  ```

* Update the `Areas/Identity/Pages/Account/RegisterConfirmation` page.

  * Remove the code and links from the cshtml file.
  * Remove the confirmation code from the `PageModel`:

  ```csharp
   [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        public IActionResult OnGet()
        {  
            return Page();
        }
    }
  ```
  
### Use another app to add users

Provide a mechanism to add users outside the web app. Options to add users include:

* A dedicated admin web app.
* A console app.

The following code outlines one approach to adding users:

* A list of users is read into memory.
* A strong unique password is generated for each user.
* The user is added to the Identity database.
* The user is notified and told to change the password.

[!code-csharp[](scaffold-identity/consoleAddUser/Program.cs?name=snippet)]

The following code outlines adding a user:

[!code-csharp[](scaffold-identity/consoleAddUser/Data/SeedData.cs?name=snippet)]

A similar approach can be followed for production scenarios.

## Prevent publish of static Identity assets

To prevent publishing static Identity assets to the web root, see <xref:security/authentication/identity#prevent-publish-of-static-identity-assets>.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

ASP.NET Core provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor class library (RCL)](xref:razor-pages/ui-class). Applications that include Identity can apply the scaffolder to selectively add the source code contained in the Identity RCL. You might want to generate source code so you can modify the code and change the behavior. For example, you could instruct the scaffolder to generate the code used in registration. Generated code takes precedence over the same code in the Identity RCL. To gain full control of the UI and not use the default RCL, see the section [Create full Identity UI source](#full).

Applications that do **not** include authentication can apply the scaffolder to add the RCL Identity package. You have the option of selecting Identity code to be generated.

Although the scaffolder generates most of the necessary code, you need to update your project to complete the process. This document explains the steps needed to complete an Identity scaffolding update.

We recommend using a source control system that shows file differences and allows you to back out of changes. Inspect the changes after running the Identity scaffolder.

Services are required when using [Two Factor Authentication](xref:security/authentication/identity-enable-qrcodes), [Account confirmation and password recovery](xref:security/authentication/accconfirm), and other security features with Identity. Services or service stubs aren't generated when scaffolding Identity. Services to enable these features must be added manually. For example, see [Require Email Confirmation](xref:security/authentication/accconfirm#require-email-confirmation).

Typically, apps created with individual accounts should ***not*** create a new data context.

<a name="RPNA"></a>

## Scaffold Identity into a Razor project without existing authorization

<!--  Updated for 3.0
set projNam=RPnoAuth
set projType=webapp

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef database drop
dotnet ef migrations add CreateIdentitySchema0
dotnet ef database update
-->

<!-- ERROR
There is already an object named 'AspNetRoles' in the database.

Fixed via dotnet ef database drop
before dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

<a name="efm"></a>

### Migrations, UseAuthentication, and layout

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

<a name="useauthentication"></a>

<!--
### Enable authentication

Update the `Startup` class with code similar to the following:

[!code-csharp[](scaffold-identity/3.1sample/StartupRP.cs?name=snippet)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)] -->

### Layout changes

Optional: Add the login partial (`_LoginPartial`) to the layout file:

[!code-cshtml[](scaffold-identity/6.0sample/_Layout.cshtml?highlight=29)]

## Scaffold Identity into a Razor project with authorization

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

<!--
Use >=2.1: dotnet new webapp -au Individual -o RPauth
Use = 2.0: dotnet new razor -au Individual -o RPauth
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

## Scaffold Identity into an MVC project without existing authorization

<!--
set projNam=MvcNoAuth
set projType=mvc
set version=2.1.0

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v %version%
dotnet restore
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Optional: Add the login partial (`_LoginPartial`) to the `Views/Shared/_Layout.cshtml` file:

[!code-cshtml[](scaffold-identity/6.0sample/_Layout.cshtml?highlight=29)]

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

Add `MapRazorPages` to `Program.cs` as shown in the following highlighted code:

[!code-cshtml[](scaffold-identity/6.0sample/ProgramMRP.cs?highlight=39)]

## Scaffold Identity into an MVC project with authorization

<!--
dotnet new mvc -au Individual -o MvcAuth
cd MvcAuth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator identity -dc MvcAuth.Data.ApplicationDbContext  --files "Account.Login;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

## Scaffold Identity into a server-side Blazor app with authorization

[!INCLUDE[](~/includes/scaffold-identity/install-pkg.md)]

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

### Migrations

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

### Style authentication endpoints

Because server-side Blazor apps use Razor Pages Identity pages, the styling of the UI changes when a visitor navigates between Identity pages and components. You have two options to address the incongruous styles:

* [Custom Identity components](#custom-identity-components)
* [Use a custom layout with Blazor app styles](#use-a-custom-layout-with-blazor-app-styles)

#### Custom Identity components

ASP.NET Core Identity is designed to work in the context of HTTP request and response communication, which isn't the primary client-server communication model in Blazor apps. ASP.NET Core apps that use ASP.NET Core Identity for user management should use Razor Pages instead of Razor components for Identity-related UI, such as user registration, login, logout, and other user management tasks.

Because <xref:Microsoft.AspNetCore.Identity.SignInManager%601> and <xref:Microsoft.AspNetCore.Identity.UserManager%601> aren't supported in Razor components, we recommend using web API to manage Identity actions from Razor components via a server-side Identity-enabled ASP.NET Core app. For guidance on creating web APIs for Blazor apps, see <xref:blazor/call-web-api>.

An approach to using Razor components for Identity instead of Razor pages is to build your own custom Identity Razor components, but Microsoft doesn't recommend or support the approach. For additional context, explore the following discussions. In the following discussions, code examples in issue comments and code examples cross-linked in non-Microsoft GitHub repositories aren't supported by Microsoft but might be helpful to some developers:

* [Support Custom Login Component when using Identity (dotnet/aspnetcore #13601)](https://github.com/dotnet/aspnetcore/issues/13601)
* [Reiteration on the `SigninManager<T>` not being supported in Razor Components (dotnet/aspnetcore #34095)](https://github.com/dotnet/aspnetcore/issues/34095)
* [There is no info on how to actually implement custom login form for server-side blazor (dotnet/AspNetCore.Docs #16813)](https://github.com/dotnet/AspNetCore.Docs/issues/16813)

For additional assistance when seeking to build custom Identity Razor components or searching for third-party Razor components, we recommend the following resources:

* [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor) (Public support forum)
* [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ) (Public support chat)
* [Blazor Gitter](https://gitter.im/aspnet/Blazor) (Public support chat)
* [Awesome Blazor](https://github.com/AdrienTorris/awesome-blazor) (Links to community-maintained Blazor resources)

#### Use a custom layout with Blazor app styles

The Identity pages layout and styles can be modified to produce pages that use styles similar to the default Blazor theme. This approach isn't covered by the documentation.

## Client-side Blazor apps

Client-side Blazor apps use their own Identity UI approaches and can't use ASP.NET Core Identity scaffolding. Server-side ASP.NET Core apps of hosted Blazor solutions can follow the Razor Pages/MVC guidance in this article and are configured just like any other type of ASP.NET Core app that supports Identity.

The Blazor framework doesn't include Razor component versions of Identity UI pages. Identity UI Razor components can be custom built or obtained from unsupported third-party sources.

For more information, see the [Blazor Security and Identity articles](xref:blazor/security/index).

<a name="full"></a>

## Create full Identity UI source
<!-- remove AllowAreas  #23280 -->
To maintain full control of the Identity UI, run the Identity scaffolder and select **Override all files**.

<!--
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
-->

## Password configuration

If <xref:Microsoft.AspNetCore.Identity.PasswordOptions> are configured in `Startup.ConfigureServices`, [`[StringLength]` attribute](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute) configuration might be required for the `Password` property in scaffolded Identity pages. `InputModel` `Password` properties are found in the following files:

* `Areas/Identity/Pages/Account/Register.cshtml.cs`
* `Areas/Identity/Pages/Account/ResetPassword.cshtml.cs`

## Disable a page

This section shows how to disable the register page but the approach can be used to disable any page.

To disable user registration:

* Scaffold Identity. Include Account.Register, Account.Login, and Account.RegisterConfirmation. For example:

  ```dotnetcli
   dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
  ```

* Update `Areas/Identity/Pages/Account/Register.cshtml.cs` so users can't register from this endpoint:

  [!code-csharp[](scaffold-identity/sample/Register.cshtml.cs?name=snippet)]

* Update `Areas/Identity/Pages/Account/Register.cshtml` to be consistent with the preceding changes:

  [!code-cshtml[](scaffold-identity/sample/Register.cshtml)]

* Comment out or remove the registration link from `Areas/Identity/Pages/Account/Login.cshtml`

  ```cshtml
  @*
  <p>
      <a asp-page="./Register" asp-route-returnUrl="@Model.ReturnUrl">Register as a new user</a>
  </p>
  *@
  ```

* Update the `Areas/Identity/Pages/Account/RegisterConfirmation` page.

  * Remove the code and links from the cshtml file.
  * Remove the confirmation code from the `PageModel`:

  ```csharp
   [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        public IActionResult OnGet()
        {  
            return Page();
        }
    }
  ```
  
### Use another app to add users

Provide a mechanism to add users outside the web app. Options to add users include:

* A dedicated admin web app.
* A console app.

The following code outlines one approach to adding users:

* A list of users is read into memory.
* A strong unique password is generated for each user.
* The user is added to the Identity database.
* The user is notified and told to change the password.

[!code-csharp[](scaffold-identity/consoleAddUser/Program.cs?name=snippet)]

The following code outlines adding a user:

[!code-csharp[](scaffold-identity/consoleAddUser/Data/SeedData.cs?name=snippet)]

A similar approach can be followed for production scenarios.

## Prevent publish of static Identity assets

To prevent publishing static Identity assets to the web root, see <xref:security/authentication/identity#prevent-publish-of-static-identity-assets>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

ASP.NET Core provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor class library (RCL)](xref:razor-pages/ui-class). Applications that include Identity can apply the scaffolder to selectively add the source code contained in the Identity RCL. You might want to generate source code so you can modify the code and change the behavior. For example, you could instruct the scaffolder to generate the code used in registration. Generated code takes precedence over the same code in the Identity RCL. To gain full control of the UI and not use the default RCL, see the section [Create full Identity UI source](#full).

Applications that do **not** include authentication can apply the scaffolder to add the RCL Identity package. You have the option of selecting Identity code to be generated.

Although the scaffolder generates most of the necessary code, you need to update your project to complete the process. This document explains the steps needed to complete an Identity scaffolding update.

We recommend using a source control system that shows file differences and allows you to back out of changes. Inspect the changes after running the Identity scaffolder.

Services are required when using [Two Factor Authentication](xref:security/authentication/identity-enable-qrcodes), [Account confirmation and password recovery](xref:security/authentication/accconfirm), and other security features with Identity. Services or service stubs aren't generated when scaffolding Identity. Services to enable these features must be added manually. For example, see [Require Email Confirmation](xref:security/authentication/accconfirm#require-email-confirmation).

When scaffolding Identity with a new data context into a project with existing individual accounts, open `Startup.ConfigureServices` and remove the calls to:

* `AddDbContext`
* `AddDefaultIdentity`

For example, `AddDbContext` and `AddDefaultIdentity` are commented out in the following code:

[!code-csharp[](scaffold-identity/3.1sample/StartupRemove.cs?name=snippet)]

The preceding code comments out the code that is duplicated in `Areas/Identity/IdentityHostingStartup.cs`

Typically, apps created with individual accounts should ***not*** create a new data context.

## Scaffold Identity into an empty project

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Update the `Startup` class with code similar to the following:

[!code-csharp[](scaffold-identity/3.1sample/StartupMVC.cs?name=snippet)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

## Scaffold Identity into a Razor project without existing authorization

<!--  Updated for 3.0
set projNam=RPnoAuth
set projType=webapp

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef database drop
dotnet ef migrations add CreateIdentitySchema0
dotnet ef database update
-->

<!-- ERROR
There is already an object named 'AspNetRoles' in the database.

Fixed via dotnet ef database drop
before dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Identity is configured in `Areas/Identity/IdentityHostingStartup.cs`. For more information, see [`IHostingStartup`](xref:fundamentals/configuration/platform-specific-configuration).

<a name="efm"></a>

### Migrations, UseAuthentication, and layout

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

<a name="useauthentication"></a>

### Enable authentication

Update the `Startup` class with code similar to the following:

[!code-csharp[](scaffold-identity/3.1sample/StartupRP.cs?name=snippet)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

### Layout changes

Optional: Add the login partial (`_LoginPartial`) to the layout file:

[!code-cshtml[](scaffold-identity/3.1sample/_Layout.cshtml?highlight=20)]

## Scaffold Identity into a Razor project with authorization

<!--
Use >=2.1: dotnet new webapp -au Individual -o RPauth
Use = 2.0: dotnet new razor -au Individual -o RPauth
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

Some Identity options are configured in `Areas/Identity/IdentityHostingStartup.cs`. For more information, see [`IHostingStartup`](xref:fundamentals/configuration/platform-specific-configuration).

## Scaffold Identity into an MVC project without existing authorization

<!--
set projNam=MvcNoAuth
set projType=mvc
set version=2.1.0

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v %version%
dotnet restore
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Optional: Add the login partial (`_LoginPartial`) to the `Views/Shared/_Layout.cshtml` file:

[!code-cshtml[](scaffold-identity/3.1sample/_Layout.cshtml?highlight=20)]

Move the `Pages/Shared/_LoginPartial.cshtml` file to `Views/Shared/_LoginPartial.cshtml`.

Identity is configured in `Areas/Identity/IdentityHostingStartup.cs`. For more information, see [`IHostingStartup`](xref:fundamentals/configuration/platform-specific-configuration).

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

Update the `Startup` class with code similar to the following:

[!code-csharp[](scaffold-identity/3.1sample/StartupMVC.cs?name=snippet)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

## Scaffold Identity into an MVC project with authorization

<!--
dotnet new mvc -au Individual -o MvcAuth
cd MvcAuth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator identity -dc MvcAuth.Data.ApplicationDbContext  --files "Account.Login;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

## Scaffold Identity into a server-side Blazor app without existing authorization

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Identity is configured in `Areas/Identity/IdentityHostingStartup.cs`. For more information, see [`IHostingStartup`](xref:fundamentals/configuration/platform-specific-configuration).

### Migrations

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

### Style authentication endpoints

Because server-side Blazor apps use Razor Pages Identity pages, the styling of the UI changes when a visitor navigates between Identity pages and components. You have two options to address the incongruous styles:

* [Custom Identity components](#custom-identity-components)
* [Use a custom layout with Blazor app styles](#use-a-custom-layout-with-blazor-app-styles)

#### Custom Identity components

An approach to using components for Identity instead of pages is to build Identity components. Because `SignInManager` and `UserManager` aren't supported in Razor components, use web API endpoints in the Blazor app to process user account actions.

#### Use a custom layout with Blazor app styles

The Identity pages layout and styles can be modified to produce pages that use styles similar to the default Blazor theme. This approach isn't covered by the documentation.

## Scaffold Identity into a server-side Blazor app with authorization

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

Some Identity options are configured in `Areas/Identity/IdentityHostingStartup.cs`. For more information, see [`IHostingStartup`](xref:fundamentals/configuration/platform-specific-configuration).

## Client-side Blazor apps

Client-side Blazor apps use their own Identity UI approaches and can't use ASP.NET Core Identity scaffolding. Server-side ASP.NET Core apps of hosted Blazor solutions can follow the Razor Pages/MVC guidance in this article and are configured just like any other type of ASP.NET Core app that supports Identity.

The Blazor framework doesn't include Razor component versions of Identity UI pages. Identity UI Razor components can be custom built or obtained from unsupported third-party sources.

For more information, see the [Blazor Security and Identity articles](xref:blazor/security/index).

<a name="full"></a>

## Create full Identity UI source
<!-- remove AllowAreas  #23280 -->
To maintain full control of the Identity UI, run the Identity scaffolder and select **Override all files**.

The following highlighted code shows the changes to replace the default Identity UI with Identity in an ASP.NET Core 2.1 web app. You might want to do this to have full control of the Identity UI.

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet1&highlight=13-14,17-999)]

The default Identity is replaced in the following code:

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet2)]

The following code sets the <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions.LoginPath%2A>, <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions.LogoutPath%2A>, and <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions.AccessDeniedPath%2A>):

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet3)]

Register an `IEmailSender` implementation, for example:

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet4)]

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet)]

<!--
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
-->

## Password configuration

If <xref:Microsoft.AspNetCore.Identity.PasswordOptions> are configured in `Startup.ConfigureServices`, [`[StringLength]` attribute](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute) configuration might be required for the `Password` property in scaffolded Identity pages. `InputModel` `Password` properties are found in the following files:

* `Areas/Identity/Pages/Account/Register.cshtml.cs`
* `Areas/Identity/Pages/Account/ResetPassword.cshtml.cs`

## Disable a page

This section shows how to disable the register page but the approach can be used to disable any page.

To disable user registration:

* Scaffold Identity. Include Account.Register, Account.Login, and Account.RegisterConfirmation. For example:

  ```dotnetcli
   dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
  ```

* Update `Areas/Identity/Pages/Account/Register.cshtml.cs` so users can't register from this endpoint:

  [!code-csharp[](scaffold-identity/sample/Register.cshtml.cs?name=snippet)]

* Update `Areas/Identity/Pages/Account/Register.cshtml` to be consistent with the preceding changes:

  [!code-cshtml[](scaffold-identity/sample/Register.cshtml)]

* Comment out or remove the registration link from `Areas/Identity/Pages/Account/Login.cshtml`

  ```cshtml
  @*
  <p>
      <a asp-page="./Register" asp-route-returnUrl="@Model.ReturnUrl">Register as a new user</a>
  </p>
  *@
  ```

* Update the `Areas/Identity/Pages/Account/RegisterConfirmation` page.

  * Remove the code and links from the cshtml file.
  * Remove the confirmation code from the `PageModel`:

  ```csharp
   [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        public IActionResult OnGet()
        {  
            return Page();
        }
    }
  ```
  
### Use another app to add users

Provide a mechanism to add users outside the web app. Options to add users include:

* A dedicated admin web app.
* A console app.

The following code outlines one approach to adding users:

* A list of users is read into memory.
* A strong unique password is generated for each user.
* The user is added to the Identity database.
* The user is notified and told to change the password.

[!code-csharp[](scaffold-identity/consoleAddUser/Program.cs?name=snippet)]

The following code outlines adding a user:

[!code-csharp[](scaffold-identity/consoleAddUser/Data/SeedData.cs?name=snippet)]

A similar approach can be followed for production scenarios.

## Prevent publish of static Identity assets

To prevent publishing static Identity assets to the web root, see <xref:security/authentication/identity#prevent-publish-of-static-identity-assets>.

## Additional resources

[Changes to authentication code to ASP.NET Core 2.1 and later](xref:migration/20_21#changes-to-authentication-code)

:::moniker-end
