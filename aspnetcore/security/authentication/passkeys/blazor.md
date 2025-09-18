---
title: Implement passkeys in ASP.NET Core Blazor Web Apps
author: guardrex
description: Learn how to implement passkeys authentication in ASP.NET Core Blazor Web Apps.
ms.author: wpickett
monikerRange: '>= aspnetcore-10.0'
ms.custom: mvc
ms.date: 09/10/2025
uid: security/authentication/passkeys/blazor
zone_pivot_groups: implementation
---
# Implement passkeys in ASP.NET Core Blazor Web Apps

This guide explains how to implement [passkey support](xref:security/authentication/passkeys/index) for a new or existing Blazor Web App with ASP.NET Core Identity.

For an overview of passkeys and general configuration guidance, see <xref:security/authentication/passkeys/index>.

:::zone pivot="new-development"

## Prerequisites

<!-- UPDATE 10.0 - Remove preview link in favor of the download link ...

[.NET SDK](https://dotnet.microsoft.com/download) (.NET 10 or later)

-->

[.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Create a Blazor Web App

Use the following guidance to create a new Blazor Web App with ASP.NET Core Identity, which includes passkeys support.

# [Visual Studio](#tab/visual-studio)

> [!NOTE]
> Visual Studio 2022 or later and .NET 10 or later SDK are required.

In Visual Studio:

* Select **Create a new project** from the **Start Window** or select **File** > **New** > **Project** from the menu bar.
* In the **Create a new project** dialog, select **Blazor Web App** from the list of project templates. Select the **Next** button.
* In the **Configure your new project** dialog, name the project `BlazorWebAppPasskeys` in the **Project name** field, including matching the capitalization. Using this exact project name is important to ensure that the namespaces match for code that you copy from the article into the app that you're building.
* Confirm that the **Location** for the app is suitable. Leave the **Place solution and project in the same directory** checkbox selected. Select the **Next** button.
* In the **Additional information** dialog, set the **Authentication type** to **Individual Accounts**. Use the following settings for the other options:
  * **Framework**: Latest framework release (.NET 10 or later)
  * **Configure for HTTPS**: Selected
  * **Interactive render mode**: **Server**
  * **Interactivity location**: **Global**
  * **Include sample pages**: Selected
  * **Do not use top-level statements**: Not selected
  * **Use the .dev.localhost TLD in the application URL**: Not selected
  * Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

This guidance assumes that you have familiarity with VS Code. If you're new to VS Code, see the [VS Code documentation](https://code.visualstudio.com/docs). The videos listed by the [Introductory Videos page](https://code.visualstudio.com/docs/getstarted/introvideos) are designed to give you an overview of VS Code's features.

In VS Code:

* Go to the **Explorer** view and select the **Create .NET Project** button. Alternatively, you can bring up the **Command Palette** using <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>P</kbd>, and then type "`.NET`" and find and select the **.NET: New Project** command.

* Select the **Blazor Web App** project template from the list.

* In the **Project Location** dialog, create or select a folder for the project.

* In the **Command Palette**, name the project `BlazorWebAppPasskeys`, including matching the capitalization. Using this exact project name is important to ensure that the namespaces match for code that you copy from the article into the app that you're building.

* Select **Create project** from the **Command Palette**.

# [.NET CLI](#tab/net-cli/)

In a command shell:

Change to the directory using the `cd` command to where you want to create the project folder (for example, `cd c:/users/Bernie_Kopell/Documents`).

Use the [`dotnet new` command](/dotnet/core/tools/dotnet-new) with the [`blazor` project template](/dotnet/core/tools/dotnet-new-sdk-templates#blazor) to create a new Blazor Web App project. The [`-o|--output` option](/dotnet/core/tools/dotnet-new#options) passed to the command creates the project in a new folder named `BlazorWebAppPasskeys` at the current directory location.

> [!IMPORTANT]
> Name the project `BlazorWebAppPasskeys`, including matching the capitalization, so the namespaces match for code that you copy from the article to the app.

```dotnetcli
dotnet new blazor -au Individual -o BlazorWebAppPasskeys
```

---

The preceding instructions create a Blazor Web App with:

* ASP.NET Core Identity configured for user authentication using the [`-au|--authentication` option](/dotnet/core/tools/dotnet-new-sdk-templates#blazor).
* Entity Framework Core with SQLite for data storage.
* Passkey registration and authentication endpoints.
* UI components for managing passkeys.

> [!NOTE]
> Currently, only the Blazor Web App project template includes built-in passkey support.

## Run the application

# [Visual Studio](#tab/visual-studio)

Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app without debugging.

# [Visual Studio Code](#tab/visual-studio-code)

Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app without debugging.

# [.NET CLI](#tab/net-cli/)

In a command shell opened to the root folder of the server `BlazorWebAppPasskeys` project, execute the following command:

```dotnetcli
dotnet watch
```

:::zone-end

:::zone pivot="existing-app"

The following guidance relies upon an app that was created with **Individual Accounts** for the app's **Authentication type** or [scaffolding Identity into an existing app](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-project).

## Prerequisites

<!-- UPDATE 10.0 - Remove preview link in favor of the download link ...

* [.NET SDK](https://dotnet.microsoft.com/download) (.NET 10 or later)

-->

* An existing Blazor Web App (.NET 10 or later) with ASP.NET Core Identity
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

For migration guidance, see <xref:migration/index>.

## Reference source guidance

The links in this article to .NET reference source load the repository's default branch, which represents the current development for the next release of .NET. To select a tag for a specific release, use the **Switch branches or tags** dropdown list. For more information, see [How to select a version tag of ASP.NET Core source code (dotnet/AspNetCore.Docs #26205)](https://github.com/dotnet/AspNetCore.Docs/discussions/26205).

## Update Identity schema version

In `Program.cs`, update the Identity configuration to use schema version 3, which includes passkey support:

```csharp
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();
```

## Create and run a database migration

# [Visual Studio](#tab/visual-studio)

In Visual Studio **Solution Explorer**, double-click **Connected Services**. In the **Service Dependencies** area, select the ellipsis (`...`) followed by **Add migration** in the **SQL Server Express LocalDB** area.

Give the migration a **Migration name** of `AddPasskeySupport` to describe the migration. Wait for the database context to load in the **DbContext class names** field. Select **Finish** to create the migration. Select the **Close** button when the operation completes.

Select the ellipsis (`...`) again followed by the **Update database** command.

The **Update database with the latest migration** dialog opens. Wait for the **DbContext class names** field to update and for prior migrations to load. Select the **Finish** button. Select the **Close** button when the operation completes.

# [Visual Studio Code](#tab/visual-studio-code)

Use the following command in the **Terminal** (**Terminal** menu > **New Terminal**) to add a migration for the new data annotations:

```dotnetcli
dotnet ef migrations add AddPasskeySupport
```

To apply the migration to the database, execute the following command:

```dotnetcli
dotnet ef database update
```

# [.NET CLI](#tab/net-cli/)

To add a migration for the new data annotations, execute the following command in a command shell opened to the project's root folder:

```dotnetcli
dotnet ef migrations add AddPasskeySupport
```

To apply the migration to the database, execute the following command:

```dotnetcli
dotnet ef database update
```

---

## Create passkey model classes

Add the following model classes to the project in the `Components/Account` folder with `BlazorWebCSharp._1.Components.Account` namespace updates for the app (for example: `Contoso.Components.Account`):

* [`Components/Account/PasskeyInputModel.cs`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/PasskeyInputModel.cs): Holds the JSON passkey credential for passkey sign-in operations (`Login` component) and adding passkeys (`Passkeys` component).
* [`Components/Account/PasskeyOperation.cs`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/PasskeyOperation.cs): Defines the authentication action to be performed (`PassKeySubmit` component), either registering a new passkey (`Create`/0) or authenticating with an existing passkey (`Request`/1).

## Create the `PasskeySubmit` component

Add the following `PasskeySubmit` component to handle passkey operations:

[`Components/Account/Shared/PasskeySubmit.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Shared/PasskeySubmit.razor)

## Add the JavaScript for passkey operations

Add the following JavaScript file to handle WebAuthn API interactions:

[`Components/Account/Shared/PasskeySubmit.razor.js`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Shared/PasskeySubmit.razor.js)

## Add passkey endpoints

Update the `IdentityComponentsEndpointRouteBuilderExtensions.cs` file (or create the file if it doesn't exist and call `MapAdditionalIdentityEndpoints` in the [`Program` file](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Program.cs#L129-L130)) to include the passkey-specific endpoints:

[`/PasskeyCreationOptions` and `/PasskeyRequestOptions` endpoints](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/IdentityComponentsEndpointRouteBuilderExtensions.cs#L53-L90)

## Update the Login page

Replace the existing `Login` component with the following component and update the `BlazorWebCSharp._1.Data` namespace to match the app (for example: `Contoso.Components.Account.Data`):

[`Components/Account/Pages/Login.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Pages/Login.razor)

## Create passkey management pages for adding and renaming passkeys

Add the following `Passkeys` component for managing passkeys and update the `BlazorWebCSharp._1.Data` namespace to match the app (for example: `Contoso.Components.Account.Data`):

[`Components/Account/Pages/Manage/Passkeys.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Pages/Manage/Passkeys.razor)

Add the following `RenamePasskey` component for renaming passkeys and update the `BlazorWebCSharp._1.Data` namespace to match the app (for example: `Contoso.Components.Account.Data`):

[`Components/Account/Pages/Manage/RenamePasskey.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Pages/Manage/RenamePasskey.razor)

## Update the manage navigation menu

Add a link to the passkey management page in the app's `ManageNavMenu` component.

In `Components/Account/Shared/ManageNavMenu.razor`, add the following [`NavLink` component](xref:blazor/fundamentals/routing#navlink-component) for the `Passkeys` component:

```razor
<li class="nav-item">
    <NavLink class="nav-link" href="Account/Manage/Passkeys">Passkeys</NavLink>
</li>
```

## Include the JavaScript file

In the `App` component (`Components/App.razor`), locate the [Blazor script](xref:blazor/project-structure#location-of-the-blazor-script) tag:

```razor
<script src="_framework/blazor.web.js"></script>
```

Immediately after the Blazor script tag, add a reference to the `PasskeySubmit` JavaScript module:

```razor
<script src="Components/Account/Shared/PasskeySubmit.razor.js" type="module"></script>
```

:::zone-end

## Register a passkey

To test passkey functionality:

1. Register a new account or sign in with an existing account.
1. Navigate to **Manage your account** (select the username in the navigation menu).
1. Select **Passkeys** from the navigation menu.
1. Select **Add a new passkey**
1. Follow the browser's prompts to create a passkey using your device's authenticator.

## Sign in with a passkey

After a passkey is registered:

1. Sign out of the app.
1. On the login page, enter your email address.
1. Select **Log in with a passkey**.
4. Follow the browser's prompts to authenticate with your passkey.
1. Navigate to `Account/Manage/Passkeys` to add, rename, or delete passkeys.
1. If the passkey supports passkey autofill (conditional UI) for login, test the passkey autofill feature by selecting the email input field when you have saved passkeys.

## Mitigate `PublicKeyCredential.toJSON` error (`TypeError: Illegal invocation`)

Some password managers don't implement the [`PublicKeyCredential.toJSON` method](https://developer.mozilla.org/docs/Web/API/PublicKeyCredential/toJSON) correctly, which is required for [`JSON.stringify`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify) to work when serializing passkey credentials. When registering or authenticating a user with an app based on the Blazor Web App project template, the following error is thrown when attempting to add a passkey:

> :::no-loc text="Error: Could not add a passkey: Illegal invocation":::

For guidance on mitigating this error, see <xref:security/authentication/passkeys/index#mitigate-publickeycredentialtojson-error-typeerror-illegal-invocation>.

## Additional resources

* [Web Authentication API (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API)
* [Get started with phishing-resistant passwordless authentication deployment in Microsoft Entra ID](/entra/identity/authentication/how-to-plan-prerequisites-phishing-resistant-passwordless-authentication)
