---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with Microsoft Accounts
author: guardrex
description: 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/09/2020
no-loc: [Blazor, SignalR]
uid: security/blazor/webassembly/standalone-with-microsoft-accounts
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with Microsoft Accounts

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

[!INCLUDE[](~/includes/blazorwasm-3.2-template-article-notice.md)]

To create a Blazor WebAssembly standalone app that uses [Microsoft Accounts with Azure Active Directory (AAD)](/azure/active-directory/develop/quickstart-register-app#register-a-new-application-using-the-azure-portal) for authentication:

1. [Create an AAD tenant and web application](/azure/active-directory/develop/v2-overview)

   Register a AAD app in the **Azure Active Directory** > **App registrations** area of the Azure portal:

   1\. Provide a **Name** for the app (for example, **Blazor Client AAD**).<br>
   2\. In **Supported account types**, select **Accounts in any organizational directory**.<br>
   3\. Leave the **Redirect URI** drop down set to **Web**, and provide a redirect URI of `https://localhost:5001/authentication/login-callback`.<br>
   4\. Disable the **Permissions** > **Grant admin concent to openid and offline_access permissions** check box.<br>
   5\. Select **Register**.

   In **Authentication** > **Platform configurations** > **Web**:

   1\. Confirm the **Redirect URI** of `https://localhost:5001/authentication/login-callback` is present.<br>
   2\. For **Implicit grant**, select the check boxes for **Access tokens** and **ID tokens**.<br>
   3\. The remaining defaults for the app are acceptable for this experience.<br>
   4\. Select the **Save** button.

   Record the Application ID (Client ID) (for example, `11111111-1111-1111-1111-111111111111`).

1. Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

   ```dotnetcli
   dotnet new blazorwasm -au SingleOrg --client-id "{CLIENT ID}" --tenant-id "common"
   ```

   To specify the output location, which creates a project folder if it doesn't exist, include the output option in the command with a path (for example, `-o BlazorSample`). The folder name also becomes part of the project's name.

After creating the app, you should be able to:

* Log into the app using a Microsoft Account.
* Request access tokens for Microsoft APIs using the same approach as for standalone Blazor apps provided that you have configured the app correctly. For more information, see [Quickstart: Configure an application to expose web APIs](/azure/active-directory/develop/quickstart-configure-app-expose-web-apis).

## Authentication package

When an app is created to use Work or School Accounts (`SingleOrg`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) (`Microsoft.Authentication.WebAssembly.Msal`). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" 
    Version="{VERSION}" />
```

Replace `{VERSION}` in the preceding package reference with the version of the `Microsoft.AspNetCore.Blazor.Templates` package shown in the <xref:blazor/get-started> article.

The `Microsoft.Authentication.WebAssembly.Msal` package transitively adds the `Microsoft.AspNetCore.Components.WebAssembly.Authentication` package to the app.

## Authentication service support

Support for authenticating users is registered in the service container with the `AddMsalAuthentication` extension method provided by the `Microsoft.Authentication.WebAssembly.Msal` package. This method sets up all of the services required for the app to interact with the Identity Provider (IP).

*Program.cs*:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    var authentication = options.ProviderOptions.Authentication;
    authentication.Authority = "{AUTHORITY}";
    authentication.ClientId = "{CLIENT ID}";
});
```

The `AddMsalAuthentication` method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Microsoft Accounts configuration when you register the app.

### Imports file

[!INCLUDE[](~/includes/blazor-security/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/includes/blazor-security/index-page-msal.md)]

## App component

[!INCLUDE[](~/includes/blazor-security/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/includes/blazor-security/redirecttologin-component.md)]

## LoginDisplay component

[!INCLUDE[](~/includes/blazor-security/logindisplay-component.md)]

## Authentication component

[!INCLUDE[](~/includes/blazor-security/authentication-component.md)]

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]

## Additional resources

* [Quickstart: Register an application with the Microsoft identity platform](/azure/active-directory/develop/quickstart-register-app#register-a-new-application-using-the-azure-portal)
* [Quickstart: Configure an application to expose web APIs](/azure/active-directory/develop/quickstart-configure-app-expose-web-apis)
