---
title: Implement passkeys in an existing Blazor Web App
author: guardrex
description: Learn how to implement passkeys authentication in an ASP.NET Core Blazor Web App.
ms.author: wpickett
ms.custom: mvc
ms.date: 8/14/2025
uid: blazor/security/passkeys-migration
---
# Implement passkeys in an existing Blazor Web App

This guide explains how to add [passkey support](xref:blazor/security/passkeys) to an existing Blazor Web App that has ASP.NET Core Identity authentication configured.

The guidance in this article relies upon an app that was created with **Individual Accounts** for the app's **Authentication type** or [scaffolding Identity into an existing app](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-project).

## Prerequisites

<!-- UPDATE 10.0 - Remove preview link in favor of the download link ...

* [.NET SDK](https://dotnet.microsoft.com/download) (.NET 10 or later)

-->

* An existing Blazor Web App with ASP.NET Core Identity
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Reference source guidance

The links in this article to .NET reference source load the repository's default branch, which represents the current development for the next release of .NET. To select a tag for a specific release, use the **Switch branches or tags** dropdown list. For more information, see [How to select a version tag of ASP.NET Core source code (dotnet/AspNetCore.Docs #26205)](https://github.com/dotnet/AspNetCore.Docs/discussions/26205).

## Step 1: Update to .NET 10

Update the app to .NET 10 or later. For more information, see <xref:migration/index>.

## Step 2: Update Identity schema version

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

## Step 3: Create passkey model classes

Add the following model classes to the project in the `Components/Account` folder with `BlazorWebCSharp._1.Components.Account` namespace updates for the app (for example: `Contoso.Components.Account`):

* [`Components/Account/PasskeyInputModel.cs`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/PasskeyInputModel.cs)
* [`Components/Account/PasskeyOperation.cs`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/PasskeyOperation.cs)

## Step 4: Create the `PasskeySubmit` component

Add the following `PasskeySubmit` component to handle passkey operations:

[`Components/Account/Shared/PasskeySubmit.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Shared/PasskeySubmit.razor)

## Step 5: Add the JavaScript for passkey operations

Add the following JavaScript file to handle WebAuthn API interactions:

[`Components/Account/Shared/PasskeySubmit.razor.js`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Shared/PasskeySubmit.razor.js)

## Step 6: Add passkey endpoints

Update the `IdentityComponentsEndpointRouteBuilderExtensions.cs` file (or create the file if it doesn't exist and call `MapAdditionalIdentityEndpoints` in the [`Program` file](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Program.cs#L129-L130)) to include the passkey-specific endpoints:

[`/PasskeyCreationOptions` and `/PasskeyRequestOptions` endpoints](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/IdentityComponentsEndpointRouteBuilderExtensions.cs#L53-L90)

## Step 7: Update the Login page

Replace the existing `Login` component with the following component and update the `BlazorWebCSharp._1.Data` namespace to match the app (for example: `Contoso.Components.Account.Data`):

[`Components/Account/Pages/Login.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Pages/Login.razor)

## Step 8: Create passkey management pages for adding and renaming passkeys

Add the following `Passkeys` component for managing passkeys and update the `BlazorWebCSharp._1.Data` namespace to match the app (for example: `Contoso.Components.Account.Data`):

[`Components/Account/Pages/Manage/Passkeys.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Pages/Manage/Passkeys.razor)

Add the following `RenamePasskey` component for renaming passkeys and update the `BlazorWebCSharp._1.Data` namespace to match the app (for example: `Contoso.Components.Account.Data`):

[`Components/Account/Pages/Manage/RenamePasskey.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Pages/Manage/RenamePasskey.razor)

## Step 9: Update the manage navigation menu

Add a link to the passkey management page in the app's `ManageNavMenu` component.

In `Components/Account/Shared/ManageNavMenu.razor`:

```diff
+ <li class="nav-item">
+     <NavLink class="nav-link" href="Account/Manage/Passkeys">Passkeys</NavLink>
+ </li>
```

## Step 10: Include the JavaScript file

In the `App` component, add a reference to the `PasskeySubmit` JavaScript file after the Blazor script.

In `Components/App.razor`:

```diff
<script src="_framework/blazor.web.js"></script>
+ <script src="Components/Account/Shared/PasskeySubmit.razor.js" type="module"></script>
```

## Step 11: Test the implementation

* Run the app and navigate to the login page.
* Log in with a username and password.
* Register a passkey.
* Sign out of the app.
* Sign back into the app with a passkey using the **Log in with a passkey** button.
* Navigate to `Account/Manage/Passkeys` to add, rename, or delete passkeys.
* If the passkey supports autofill, test the autofill feature by selecting the email input field when you have saved passkeys.

## Additional resources

* [Web Authentication API (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API)
* [Get started with phishing-resistant passwordless authentication deployment in Microsoft Entra ID](/entra/identity/authentication/how-to-plan-prerequisites-phishing-resistant-passwordless-authentication)
* [Passkeys configuration guidance](xref:blazor/security/passkeys#configure-passkey-options)
