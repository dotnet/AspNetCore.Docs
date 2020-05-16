---
title: Secure an ASP.NET Core Blazor WebAssembly hosted app with Identity Server
author: guardrex
description: To create a new Blazor hosted app with authentication from within Visual Studio that uses an [IdentityServer](https://identityserver.io/) backend
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/26/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/blazor/webassembly/hosted-with-identity-server
---
# Secure an ASP.NET Core Blazor WebAssembly hosted app with Identity Server

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

[!INCLUDE[](~/includes/blazorwasm-3.2-template-article-notice.md)]

To create a new Blazor hosted app in Visual Studio that uses [IdentityServer](https://identityserver.io/) to authenticate users and API calls:

1. Use Visual Studio to create a new **Blazor WebAssembly** app. For more information, see <xref:blazor/get-started>.
1. In the **Create a new Blazor app** dialog, select **Change** in the **Authentication** section.
1. Select **Individual User Accounts** followed by **OK**.
1. Select the **ASP.NET Core hosted** checkbox in the **Advanced** section.
1. Select the **Create** button.

To create the app in a command shell, execute the following command:

```dotnetcli
dotnet new blazorwasm -au Individual -ho
```

To specify the output location, which creates a project folder if it doesn't exist, include the output option in the command with a path (for example, `-o BlazorSample`). The folder name also becomes part of the project's name.

## Server app configuration

The following sections describe additions to the project when authentication support is included.

### Startup class

The `Startup` class has the following additions:

* In `Startup.ConfigureServices`:

  * Identity:

    ```csharp
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(
            Configuration.GetConnectionString("DefaultConnection")));

    services.AddDefaultIdentity<ApplicationUser>(options => 
            options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    ```

  * IdentityServer with an additional <xref:Microsoft.Extensions.DependencyInjection.IdentityServerBuilderConfigurationExtensions.AddApiAuthorization%2A> helper method that sets up some default ASP.NET Core conventions on top of IdentityServer:

    ```csharp
    services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
    ```

  * Authentication with an additional <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A> helper method that configures the app to validate JWT tokens produced by IdentityServer:

    ```csharp
    services.AddAuthentication()
        .AddIdentityServerJwt();
    ```

* In `Startup.Configure`:

  * The authentication middleware that is responsible for validating the request credentials and setting the user on the request context:

    ```csharp
    app.UseAuthentication();
    ```

  * The IdentityServer middleware that exposes the Open ID Connect (OIDC) endpoints:

    ```csharp
    app.UseIdentityServer();
    ```

  * Authentication and Authorization Middleware:

    ```csharp
    app.UseAuthentication();
    app.UseAuthorization();
    ```

### AddApiAuthorization

The <xref:Microsoft.Extensions.DependencyInjection.IdentityServerBuilderConfigurationExtensions.AddApiAuthorization%2A> helper method configures [IdentityServer](https://identityserver.io/) for ASP.NET Core scenarios. IdentityServer is a powerful and extensible framework for handling app security concerns. IdentityServer exposes unnecessary complexity for the most common scenarios. Consequently, a set of conventions and configuration options is provided that we consider a good starting point. Once your authentication needs change, the full power of IdentityServer is still available to customize authentication to suit an app's requirements.

### AddIdentityServerJwt

The <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A> helper method configures a policy scheme for the app as the default authentication handler. The policy is configured to allow Identity to handle all requests routed to any subpath in the Identity URL space `/Identity`. The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler> handles all other requests. Additionally, this method:

* Registers an `{APPLICATION NAME}API` API resource with IdentityServer with a default scope of `{APPLICATION NAME}API`.
* Configures the JWT Bearer Token Middleware to validate tokens issued by IdentityServer for the app.

### WeatherForecastController

In the `WeatherForecastController` (*Controllers/WeatherForecastController.cs*), the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute is applied to the class. The attribute indicates that the user must be authorized based on the default policy to access the resource. The default authorization policy is configured to use the default authentication scheme, which is set up by <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A> to the policy scheme that was mentioned earlier. The helper method configures <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler> as the default handler for requests to the app.

### ApplicationDbContext

In the `ApplicationDbContext` (*Data/ApplicationDbContext.cs*), the same <xref:Microsoft.EntityFrameworkCore.DbContext> is used in Identity with the exception that it extends <xref:Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ApiAuthorizationDbContext%601> to include the schema for IdentityServer. <xref:Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ApiAuthorizationDbContext%601> is derived from <xref:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext>.

To gain full control of the database schema, inherit from one of the available Identity <xref:Microsoft.EntityFrameworkCore.DbContext> classes and configure the context to include the Identity schema by calling `builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value)` in the `OnModelCreating` method.

### OidcConfigurationController

In the `OidcConfigurationController` (*Controllers/OidcConfigurationController.cs*), the client endpoint is provisioned to serve OIDC parameters.

### App settings files

In the app settings file (*appsettings.json*) at the project root, the `IdentityServer` section describes the list of configured clients. In the following example, there's a single client. The client name corresponds to the app name and is mapped by convention to the OAuth `ClientId` parameter. The profile indicates the app type being configured. The profile is used internally to drive conventions that simplify the configuration process for the server. <!-- There are several profiles available, as explained in the [Application profiles](#application-profiles) section. -->

```json
"IdentityServer": {
  "Clients": {
    "{APP ASSEMBLY}.Client": {
      "Profile": "IdentityServerSPA"
    }
  }
}
```

## Client app configuration

### Authentication package

When an app is created to use Individual User Accounts (`Individual`), the app automatically receives a package reference for the `Microsoft.AspNetCore.Components.WebAssembly.Authentication` package in the app's project file. The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference 
    Include="Microsoft.AspNetCore.Components.WebAssembly.Authentication" 
    Version="{VERSION}" />
```

Replace `{VERSION}` in the preceding package reference with the version of the `Microsoft.AspNetCore.Blazor.Templates` package shown in the <xref:blazor/get-started> article.

### API authorization support

The support for authenticating users is plugged into the service container by the extension method provided inside the `Microsoft.AspNetCore.Components.WebAssembly.Authentication` package. This method sets up all the services needed for the app to interact with the existing authorization system.

```csharp
builder.Services.AddApiAuthorization();
```

By default, it loads the configuration for the app by convention from `_configuration/{client-id}`. By convention, the client ID is set to the app's assembly name. This URL can be changed to point to a separate endpoint by calling the overload with options.

### Imports file

[!INCLUDE[](~/includes/blazor-security/imports-file-hosted.md)]

### Index page

[!INCLUDE[](~/includes/blazor-security/index-page-authentication.md)]

### App component

[!INCLUDE[](~/includes/blazor-security/app-component.md)]

### RedirectToLogin component

[!INCLUDE[](~/includes/blazor-security/redirecttologin-component.md)]

### LoginDisplay component

The `LoginDisplay` component (*Shared/LoginDisplay.razor*) is rendered in the `MainLayout` component (*Shared/MainLayout.razor*) and manages the following behaviors:

* For authenticated users:
  * Displays the current user name.
  * Offers a link to the user profile page in ASP.NET Core Identity.
  * Offers a button to log out of the app.
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

@code {
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

## Run the app

Run the app from the Server project. When using Visual Studio, select the Server project in **Solution Explorer** and select the **Run** button in the toolbar or start the app from the **Debug** menu.

## Name and role claim with API authorization

Identity Server can be configured to send `name` and `role` claims for authenticated users.

> [!NOTE]
> Currently, only one assigned role per user is supported.

<!-- HOLD until the factory pattern issues are resolved

In the Client app, create a custom user by extending `RemoteUserAccount`.

*CustomUserAccount.cs*:

```csharp
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomUserAccount : RemoteUserAccount
{
    [JsonPropertyName("role")]
    public string[] Roles { get; set; } = new string[0];
}
```

In the Client app, create a custom user factory. Identity Server sends multiple roles as a string array in a single `role` claim. The factory creates an individual `role` claim for each role in the array.

*CustomUserFactory.cs*:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

public class CustomUserFactory
    : AccountClaimsPrincipalFactory<CustomUserAccount>
{
    public CustomUserFactory(NavigationManager navigationManager,
        IAccessTokenProviderAccessor accessor)
        : base(accessor)
    {
    }

    public async override ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = (ClaimsIdentity)initialUser.Identity;

            foreach (var role in account.Roles)
            {
                userIdentity.AddClaim(new Claim("role", role));
            }
        }

        return initialUser;
    }
}
```

In the Client app, register the factory.

`Program.Main` (*Program.cs*):

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

...

builder.Services.AddApiAuthorization<RemoteAuthenticationState, CustomUserAccount>()
    .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount, 
        CustomUserFactory>();
```

-->

* In the Server app, call <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles*> on the Identity builder, which adds role-related services:

  ```csharp
  using Microsoft.AspNetCore.Identity;

  ...

  services.AddDefaultIdentity<ApplicationUser>(options => 
      options.SignIn.RequireConfirmedAccount = true)
      .AddRoles<IdentityRole>()
      .AddEntityFrameworkStores<ApplicationDbContext>();
  ```

* In the Server app:

  * Configure Identity Server to put the `name` and `role` claims into the ID token and access token.
  * Prevent the default mapping for roles in the JWT token handler.

  ```csharp
  using System.IdentityModel.Tokens.Jwt;
  using System.Linq;

  ...

  services.AddIdentityServer()
      .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options => {
          options.IdentityResources["openid"].UserClaims.Add("name");
          options.ApiResources.Single().UserClaims.Add("name");
          options.IdentityResources["openid"].UserClaims.Add("role");
          options.ApiResources.Single().UserClaims.Add("role");
      });

  JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");
  ```

Component authorization approaches are functional at this point. Any of the authorization mechanisms in components can use a role to authorize the user:

* [AuthorizeView component](xref:security/blazor/index#authorizeview-component) (Example: `<AuthorizeView Roles="admin">`)
* [`[Authorize]` attribute directive](xref:security/blazor/index#authorize-attribute) (Example: `@attribute [Authorize(Roles = "admin")]`)
* [Procedural logic](xref:security/blazor/index#procedural-logic) (Example: `if (user.IsInRole("admin")) { ... }`)

<!-- HOLD until the factory pattern issue is resolved.
  Multiple role tests are supported:

  ```csharp
  if (user.IsInRole("admin") && user.IsInRole("developer"))
  {
      ...
  }
  ```
-->

`User.Identity.Name` is populated in the Client app with the user's username, which is usually their sign-in email address.

## Profile Service

In the Server app, create a `ProfileService` implementation. The Profile Service example in this section creates `name` and `role` claims for users similar to the scenario shown in the [Name and role claim with API authorization](#name-and-role-claim-with-api-authorization) section. The value of the `role` claim represents the user's assigned role.

> [!NOTE]
> Currently, only one assigned role per user is supported.

*ProfileService.cs*:

```csharp
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Threading.Tasks;

public class ProfileService : IProfileService
{
    public ProfileService()
    {
    }

    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var nameClaim = context.Subject.FindAll(JwtClaimTypes.Name);
        context.IssuedClaims.AddRange(nameClaim);

        var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
        context.IssuedClaims.AddRange(roleClaims);

        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.CompletedTask;
    }
}
```

In the Server app, register the Profile Service in `Startup.ConfigureServices`:

```csharp
using IdentityServer4.Services;

...

services.AddTransient<IProfileService, ProfileService>();
```

Component authorization approaches are functional at this point. Any of the authorization mechanisms in components can a role to authorize the user:

* [AuthorizeView component](xref:security/blazor/index#authorizeview-component) (Example: `<AuthorizeView Roles="admin">`)
* [`[Authorize]` attribute directive](xref:security/blazor/index#authorize-attribute) (Example: `@attribute [Authorize(Roles = "admin")]`)
* [Procedural logic](xref:security/blazor/index#procedural-logic) (Example: `if (user.IsInRole("admin")) { ... }`)

<!-- HOLD until the factory pattern issue is resolved.
  Multiple role tests are supported:

  ```csharp
  if (user.IsInRole("admin") && user.IsInRole("developer"))
  {
      ...
  }
  ```
-->

`User.Identity.Name` is populated in the Client app with the user's user name, which is usually their sign-in email address.

[!INCLUDE[](~/includes/blazor-security/usermanager-signinmanager.md)]

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]

## Additional resources

* <xref:security/blazor/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:security/blazor/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
