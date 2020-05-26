---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library
author: guardrex
description: 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/blazor/webassembly/standalone-with-authentication-library
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

*For Azure Active Directory (AAD) and Azure Active Directory B2C (AAD B2C), don't follow the guidance in this topic. See the AAD and AAD B2C topics in this table of contents node.*

To create a Blazor WebAssembly standalone app that uses [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) library, execute the following command in a command shell:

```dotnetcli
dotnet new blazorwasm -au Individual
```

To specify the output location, which creates a project folder if it doesn't exist, include the output option in the command with a path (for example, `-o BlazorSample`). The folder name also becomes part of the project's name.

In Visual Studio, [create a Blazor WebAssembly app](xref:blazor/get-started). Set **Authentication** to **Individual User Accounts** with the **Store user accounts in-app** option.

## Authentication package

When an app is created to use Individual User Accounts, the app automatically receives a package reference for the [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) package in the app's project file. The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference 
  Include="Microsoft.AspNetCore.Components.WebAssembly.Authentication" 
  Version="3.2.0" />
```

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> extension method provided by the [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

*Program.cs*:

```csharp
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});
```

Configuration is supplied by the *wwwroot/appsettings.json* file:

```json
{
    "Local": {
        "Authority": "{AUTHORITY}",
        "ClientId": "{CLIENT ID}"
    }
}
```

Authentication support for standalone apps is offered using Open ID Connect (OIDC). The <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app using OIDC. The values required for configuring the app can be obtained from the OIDC-compliant IP. Obtain the values when you register the app, which typically occurs in their online portal.

## Access token scopes

The Blazor WebAssembly template doesn't automatically configure the app to request an access token for a secure API. To provision an access token as part of the sign-in flow, add the scope to the default token scopes of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.OidcProviderOptions>:

```csharp
builder.Services.AddOidcAuthentication(options =>
{
    ...
    options.ProviderOptions.DefaultScopes.Add("{SCOPE URI}");
});
```

[!INCLUDE[](~/includes/blazor-security/azure-scope.md)]

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:security/blazor/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:security/blazor/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

## Imports file

[!INCLUDE[](~/includes/blazor-security/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/includes/blazor-security/index-page-authentication.md)]

## App component

[!INCLUDE[](~/includes/blazor-security/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/includes/blazor-security/redirecttologin-component.md)]

## LoginDisplay component

The `LoginDisplay` component (*Shared/LoginDisplay.razor*) is rendered in the `MainLayout` component (*Shared/MainLayout.razor*) and manages the following behaviors:

* For authenticated users:
  * Displays the current username.
  * Offers a button to log out of the app.
* For anonymous users, offers the option to log in.

```razor
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject NavigationManager Navigation
@inject SignOutSessionStateManager SignOutManager

<AuthorizeView>
    <Authorized>
        Hello, @context.User.Identity.Name!
        <button class="nav-link btn btn-link" @onclick="BeginSignOut">
            Log out
        </button>
    </Authorized>
    <NotAuthorized>
        <a href="authentication/login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code {
    private async Task BeginSignOut(MouseEventArgs args)
    {
        await SignOutManager.SetSignOutState();
        Navigation.NavigateTo("authentication/logout");
    }
}
```

## Authentication component

[!INCLUDE[](~/includes/blazor-security/authentication-component.md)]

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]

## Additional resources

* <xref:security/blazor/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:security/blazor/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
