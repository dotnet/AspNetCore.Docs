---
title: Secure an ASP.NET Core Blazor WebAssembly hosted app with Identity Server
author: guardrex
description: 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/09/2020
no-loc: [Blazor, SignalR]
uid: security/blazor/webassembly/hosted-with-identity-server
---
# Secure an ASP.NET Core Blazor WebAssembly hosted app with Identity Server

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

[!INCLUDE[](~/includes/blazorwasm-3.2-template-article-notice.md)]

To create a new Blazor hosted application with authentication from within Visual Studio:

1. Use Visual Studio to create a new **Blazor WebAssembly** app.
1. In the **Create a new Blazor app** dialog, select **Change** in the **Authentication** section.
1. Select **Individual User Accounts** followed by **OK**.
1. Select the **ASP.NET Core hosted** checkbox in the **Advanced** section.
1. Select the **Create** button.

To create this project from a command shell, execute the following command:

```dotnetcli
dotnet new blazorwasm -au Individual -ho
```

To specify the output location, which creates a project folder if it doesn't exist, include the output option in the command with a path (for example, `-o BlazorSample`). The folder name also becomes part of the project's name.

## Server app configuration

The following sections describe additions to the project when authentication support is included.

### Startup class

The `Startup` class has the following additions:

* Inside the `Startup.ConfigureServices` method:

  * Identity with the default UI:

    ```csharp
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

    services.AddDefaultIdentity<ApplicationUser>()
        .AddDefaultUI(UIFramework.Bootstrap4)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    ```

  * IdentityServer with an additional `AddApiAuthorization` helper method that sets up some default ASP.NET Core conventions on top of IdentityServer:

    ```csharp
    services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
    ```

  * Authentication with an additional `AddIdentityServerJwt` helper method that configures the app to validate JWT tokens produced by IdentityServer:

    ```csharp
    services.AddAuthentication()
        .AddIdentityServerJwt();
    ```

* Inside the `Startup.Configure` method:

  * The authentication middleware that is responsible for validating the request credentials and setting the user on the request context:

    ```csharp
    app.UseAuthentication();
    ```

  * The IdentityServer middleware that exposes the Open ID Connect endpoints:

    ```csharp
    app.UseIdentityServer();
    ```

### AddApiAuthorization

This helper method configures IdentityServer to use our supported configuration. IdentityServer is a powerful and extensible framework for handling app security concerns. At the same time, that exposes unnecessary complexity for the most common scenarios. Consequently, a set of conventions and configuration options is provided to you that are considered a good starting point. Once your authentication needs change, the full power of IdentityServer is still available to customize authentication to suit your needs.

### AddIdentityServerJwt

This helper method configures a policy scheme for the app as the default authentication handler. The policy is configured to let Identity handle all requests routed to any subpath in the Identity URL space "/Identity". The `JwtBearerHandler` handles all other requests. Additionally, this method registers an `{APPLICATION NAME}API` API resource with IdentityServer with a default scope of `{APPLICATION NAME}API` and configures the JWT Bearer token middleware to validate tokens issued by IdentityServer for the app.

### WeatherForecastController

In the *Controllers\WeatherForecastController.cs* file, notice the `[Authorize]` attribute applied to the class that indicates that the user needs to be authorized based on the default policy to access the resource. The default authorization policy happens to be configured to use the default authentication scheme, which is set up by `AddIdentityServerJwt` to the policy scheme that was mentioned above, making the `JwtBearerHandler` configured by such helper method the default handler for requests to the app.

### ApplicationDbContext

In the *Data\ApplicationDbContext.cs* file, notice the same `DbContext` is used in Identity with the exception that it extends `ApiAuthorizationDbContext` (a more derived class from `IdentityDbContext`) to include the schema for IdentityServer.

To gain full control of the database schema, inherit from one of the available Identity `DbContext` classes and configure the context to include the Identity schema by calling `builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value)` on the `OnModelCreating` method.

### OidcConfigurationController

In the *Controllers\OidcConfigurationController.cs* file, notice the endpoint that's provisioned to serve the OIDC parameters that the client needs to use.

### appsettings.json

In the *appsettings.json* file of the project root, there's a new `IdentityServer` section that describes the list of configured clients. In the following example, there's a single client. The client name corresponds to the app name and is mapped by convention to the OAuth `ClientId` parameter. The profile indicates the app type being configured. It's used internally to drive conventions that simplify the configuration process for the server. <!-- There are several profiles available, as explained in the [Application profiles](#application-profiles) section. -->

```json
"IdentityServer": {
  "Clients": {
    "BlazorApplicationWithAuthentication.Client": {
      "Profile": "IdentityServerSPA"
    }
  }
}
```

### appsettings.Development.json

In the *appsettings.Development.json* file of the project root, there's an `IdentityServer` section that describes the key used to sign tokens. <!-- When deploying to production, a key needs to be provisioned and deployed alongside the app, as explained in the [Deploy to production](#deploy-to-production) section. -->

```json
"IdentityServer": {
  "Key": {
    "Type": "Development"
  }
}
```

## Client app configuration

### Authentication package

When an app is created to use Individual User Accounts, the app automatically receives a package reference for the `Microsoft.AspNetCore.Components.WebAssembly.Authentication` package in the app's project file. The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference 
    Include="Microsoft.AspNetCore.Components.WebAssembly.Authentication" 
    Version="{VERSION}" />
```

Replace `{VERSION}` in the preceding package reference with the version of the `Microsoft.AspNetCore.Blazor.Templates` package shown in the <xref:blazor/get-started> article.

### API authorization support

The support for authenticating users is plugged into the service container by the extension method provided inside the `Microsoft.AspNetCore.Components.WebAssembly.Authentication` package. This method sets up all the services needed for the application to interact with the existing authorization system.

```csharp
builder.Services.AddApiAuthorization();
```

By default, it loads the configuration for the application by convention from `_configuration/{client-id}`. The client ID used by convention is the application assembly name. This url can be changed to point to a separate endpoint by calling the overload with options.

### Index page

[!INCLUDE[](~/includes/blazor-security/index-page.md)]

### App component

[!INCLUDE[](~/includes/blazor-security/app-component.md)]

### RedirectToLogin component

[!INCLUDE[](~/includes/blazor-security/redirecttologin-component.md)]

### LoginDisplay component

The `LoginDisplay` component (*Shared/LoginDisplay.razor*) is rendered in the `MainLayout` component (*Shared/MainLayout.razor*) and manages the following behaviors:

* For authenticated users:
  * Displays the current user name.
  * Offers a link to the user profile page in ASP.NET Core Identity.
  * Offers a button to log out of the application.
* For anonymous users:
  * Offers the option to register.
  * Offers the option to log in.

```razor
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject NavigationManager Navigation
@inject SignOutSessionStateManager SignOutManager

<AuthorizeView>
    <Authorized>
        <a href="authentication/profile">Hello, @context.User.Identity.Name!</a>
        <button class="nav-link btn btn-link" @onclick="BeginSignOut">
            Log out
        </button>
    </Authorized>
    <NotAuthorized>
        <a href="authentication/register">Register</a>
        <a href="authentication/login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code{
    private async Task BeginSignOut(MouseEventArgs args)
    {
        await SignOutManager.SetSignOutState();
        Navigation.NavigateTo("authentication/logout");
    }
}
```

### Authentication component

[!INCLUDE[](~/includes/blazor-security/authentication-component.md)]

### FetchData component

[!INCLUDE[](~/includes/blazor-security/fetchdata-component.md)]

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]
