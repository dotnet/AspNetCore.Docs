---
title: Secure ASP.NET Core server-side Blazor apps
author: guardrex
description: Learn how to secure server-side Blazor apps as ASP.NET Core applications.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/security/server/index
---
# Secure ASP.NET Core server-side Blazor apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to secure server-side Blazor apps as ASP.NET Core applications.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

Server-side Blazor apps are configured for security in the same manner as ASP.NET Core apps. For more information, see the articles under <xref:security/index>.

The authentication context is only established when the app starts, which is when the app first connects to the WebSocket. The authentication context is maintained for the lifetime of the circuit. Apps periodically revalidate the user's authentication state, currently every 30 minutes by default.

If the app must capture users for custom services or react to updates to the user, see <xref:blazor/security/server/additional-scenarios#circuit-handler-to-capture-users-for-custom-services>.

Blazor differs from a traditional server-rendered web apps that make new HTTP requests with cookies on every page navigation. Authentication is checked during navigation events. However, cookies aren't involved. Cookies are only sent when making an HTTP request to a server, which isn't what happens when the user navigates in a Blazor app. During navigation, the user's authentication state is checked within the Blazor circuit, which you can update at any time on the server using the [`RevalidatingAuthenticationStateProvider` abstraction](#additional-security-abstractions).

> [!IMPORTANT]
> Implementing a custom `NavigationManager` to achieve authentication validation during navigation isn't recommended. If the app must execute custom authentication state logic during navigation, use a [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider).

> [!NOTE]
> The code examples in this article adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core 6.0 or later. When targeting ASP.NET Core 5.0 or earlier, remove the null type designation (`?`) from the examples in this article.

## Project template

Create a new server-side Blazor app by following the guidance in <xref:blazor/tooling>.

# [Visual Studio](#tab/visual-studio)

After choosing the server-side app template and configuring the project, select the app's authentication under **Authentication type**:

:::moniker range=">= aspnetcore-8.0"

* **None** (default): No authentication.
* **Individual Accounts**: User accounts are stored within the app using ASP.NET Core [Identity](xref:security/authentication/identity).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* **None** (default): No authentication.
* **Individual Accounts**: User accounts are stored within the app using ASP.NET Core [Identity](xref:security/authentication/identity).
* **Microsoft identity platform**: For more information, see <xref:blazor/security/index#additional-resources>.
* **Windows**: Use Windows Authentication.

:::moniker-end

# [Visual Studio Code](#tab/visual-studio-code)

When issuing the .NET CLI command to create and configure the server-side Blazor app, indicate the authentication mechanism with the `-au|--auth` option:

```dotnetcli
-au {AUTHENTICATION}
```

> [!NOTE]
> For the full command, see <xref:blazor/tooling>.

Permissible authentication values for the `{AUTHENTICATION}` placeholder are shown in the following table.

:::moniker range=">= aspnetcore-8.0"

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |

:::moniker-end

:::moniker range="< aspnetcore-8.0"

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

:::moniker-end

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [.NET Core CLI](#tab/netcore-cli/)

When issuing the .NET CLI command to create and configure the server-side Blazor app, indicate the authentication mechanism with the `-au|--auth` option:

```dotnetcli
-au {AUTHENTICATION}
```

> [!NOTE]
> For the full command, see <xref:blazor/tooling>.

Permissible authentication values for the `{AUTHENTICATION}` placeholder are shown in the following table.

:::moniker range=">= aspnetcore-8.0"

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |

:::moniker-end

:::moniker range="< aspnetcore-8.0"

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

:::moniker-end

For more information:

* See the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.
* Execute the help command for the template in a command shell:

  ```dotnetcli
  dotnet new {PROJECT TEMPLATE} --help
  ```

  In the preceding command, the `{PROJECT TEMPLATE}` placeholder is the project template.

---

:::moniker range=">= aspnetcore-8.0"

## Blazor Identity UI (Individual Accounts)

Blazor supports generating a full Blazor-based Identity UI when you choose the authentication option for *Individual Accounts*.

The Blazor Web App template scaffolds Identity code for a SQL Server database. The command line version uses SQLite by default and includes a SQLite database for Identity.

The template handles the following:

* Adds Identity Razor components and related logic for routine authentication tasks, such as signing users in and out.
  * The Identity components also support advanced Identity features, such as [account confirmation and password recovery](xref:security/authentication/accconfirm) and [multifactor authentication](xref:security/authentication/mfa) using a third-party app.
  * Interactive server-side rendering (interactive SSR) and client-side rendering (CSR) scenarios are supported.
* Adds the Identity-related packages and dependencies.
* References the Identity packages in `_Imports.razor`.
* Creates a custom user Identity class (`ApplicationUser`).
* Creates and registers an EF Core database context (`ApplicationDbContext`).
* Configures routing for the built-in Identity endpoints.
* Includes Identity validation and business logic.

To inspect the Blazor framework's Identity components, access them in the `Pages` and `Shared` folders of the [`Account` folder in the Blazor Web App project template (reference source)](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account).

When you choose the Interactive WebAssembly or Interactive Auto render modes, the server handles all authentication and authorization requests, and the Identity components remain on the server in the Blazor Web App's main project. The project template includes a [`PersistentAuthenticationStateProvider` class (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp.Client/PersistentAuthenticationStateProvider.cs) in the `.Client` project to synchronize the user's authentication state between the server and the browser. The class is a custom implementation of <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>. The provider uses the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> class to prerender the authentication state and persist it to the page.

In the main project of a Blazor Web App, the authentication state provider is named either [`IdentityRevalidatingAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/IdentityRevalidatingAuthenticationStateProvider.cs) (Server interactivity solutions only) or [`PersistingRevalidatingAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/PersistingRevalidatingAuthenticationStateProvider.cs) (WebAssembly or Auto interactivity solutions).

For a description on how global interactive render modes are applied to non-Identity components while at the same time enforcing static SSR for the Identity components, see <xref:blazor/components/render-modes#area-folder-of-static-ssr-components>.

For more information on persisting prerendered state, see <xref:blazor/components/prerender#persist-prerendered-state>.

<!-- UPDATE 9.0 Remove blog post cross-link -->

For more information on the Blazor Identity UI and guidance on integrating external logins through social websites, see [What's new with identity in .NET 8](https://devblogs.microsoft.com/dotnet/whats-new-with-identity-in-dotnet-8/#the-blazor-identity-ui).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Manage authentication state in Blazor Web Apps

*This section applies to Blazor Web Apps that adopt:*

* *Interactive server-side rendering (interactive SSR) and CSR.*
* *Client-side rendering (CSR).*

A client-side authentication state provider is only used within Blazor and isn't integrated with the ASP.NET Core authentication system. During prerendering, Blazor respects the metadata defined on the page and uses the ASP.NET Core authentication system to determine if the user is authenticated. When a user navigates from one page to another, a client-side authentication provider is used. When the user refreshes the page (full-page reload), the client-side authentication state provider isn't involved in the authentication decision on the server. Since the user's state isn't persisted by the server, any authentication state maintained client-side is lost.

To address this, the best approach is to perform authentication within the ASP.NET Core authentication system. The client-side authentication state provider only takes care of reflecting the user's authentication state. Examples for how to accomplish this with authentication state providers are demonstrated by the Blazor Web App project template:

* [`PersistingRevalidatingAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/PersistingRevalidatingAuthenticationStateProvider.cs): For Blazor Web Apps that adopt interactive server-side rendering (interactive SSR) and client-side rendering (CSR). This is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that revalidates the security stamp for the connected user every 30 minutes an interactive circuit is connected. It also uses the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) to flow the authentication state to the client, which is then fixed for the lifetime of CSR.

* [`PersistingServerAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/PersistingServerAuthenticationStateProvider.cs): For Blazor Web Apps that only adopt CSR. This is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that uses the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) to flow the authentication state to the client, which is then fixed for the lifetime of CSR.

* [`PersistentAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp.Client/PersistentAuthenticationStateProvider.cs): For Blazor Web Apps that adopt CSR. This is a client-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that determines the user's authentication state by looking for data persisted in the page when it was rendered on the server. This authentication state is fixed for the lifetime of CSR. If the user needs to log in or out, a full-page reload is required. This only provides a user name and email for display purposes. It doesn't include tokens that authenticate to the server when making subsequent requests, which is handled separately using a cookie that's included on `HttpClient` requests to the server.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker-end

:::moniker range="< aspnetcore-8.0"

## Scaffold Identity

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

For more information on scaffolding Identity into a server-side Blazor app, see <xref:security/authentication/scaffold-identity#scaffold-identity-into-a-server-side-blazor-app>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Scaffold Identity into a server-side Blazor app:

* [Without existing authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-server-side-blazor-app-without-existing-authorization).
* [With authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-server-side-blazor-app-with-authorization).

:::moniker-end

## Additional claims and tokens from external providers

To store additional claims from external providers, see <xref:security/authentication/social/additional-claims>.

## Azure App Service on Linux with Identity Server

Specify the issuer explicitly when deploying to Azure App Service on Linux with Identity Server. For more information, see <xref:security/authentication/identity/spa#azure-app-service-on-linux>.

## Implement a custom `AuthenticationStateProvider`

If the app requires a custom provider, implement <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and override <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.GetAuthenticationStateAsync%2A>.

In the following example, all users are authenticated with the username `mrfibuli`.

`CustomAuthenticationStateProvider.cs`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "mrfibuli"),
        }, "Custom Authentication");

        var user = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(user));
    }
}
```

:::moniker range=">= aspnetcore-8.0"

The `CustomAuthenticationStateProvider` service is registered in the `Program` file:

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

builder.Services.AddScoped<AuthenticationStateProvider, 
    CustomAuthenticationStateProvider>();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

The `CustomAuthenticationStateProvider` service is registered in the `Program` file ***after*** the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

builder.Services.AddServerSideBlazor();

...

builder.Services.AddScoped<AuthenticationStateProvider, 
    CustomAuthenticationStateProvider>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The `CustomAuthenticationStateProvider` service is registered in `Startup.ConfigureServices` of `Startup.cs` ***after*** the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

services.AddServerSideBlazor();

...

services.AddScoped<AuthenticationStateProvider, 
    CustomAuthenticationStateProvider>();
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Confirm or add an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> to the <xref:Microsoft.AspNetCore.Components.Routing.Router> component.

In the `Routes` component (`Components/Routes.razor`):

```razor
<Router ...>
    <Found ...>
        <AuthorizeRouteView RouteData="@routeData" 
            DefaultLayout="@typeof(Layout.MainLayout)" />
        ...
    </Found>
</Router>
```

Add cascading authentication state services to the service collection in the `Program` file:

```csharp
builder.Services.AddCascadingAuthenticationState();
```

> [!NOTE]
> When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and call to <xref:Microsoft.Extensions.DependencyInjection.CascadingAuthenticationStateServiceCollectionExtensions.AddCascadingAuthenticationState%2A>. For more information, see <xref:blazor/security/index#expose-the-authentication-state-as-a-cascading-parameter> with additional information presented in the article's [Customize unauthorized content with the Router component](xref:blazor/security/index#customize-unauthorized-content-with-the-router-component) section.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Confirm or add an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> to the <xref:Microsoft.AspNetCore.Components.Routing.Router> component:

```razor
<CascadingAuthenticationState>
    <Router ...>
        <Found ...>
            <AuthorizeRouteView RouteData="@routeData" 
                DefaultLayout="@typeof(MainLayout)" />
            ...
        </Found>
    </Router>
</CascadingAuthenticationState>
```

> [!NOTE]
> When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> components shown in the preceding example. For more information, see <xref:blazor/security/index#expose-the-authentication-state-as-a-cascading-parameter> with additional information presented in the article's [Customize unauthorized content with the Router component](xref:blazor/security/index#customize-unauthorized-content-with-the-router-component) section.

:::moniker-end

An <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> demonstrates the authenticated user's name in any component:

```razor
<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity?.Name!</p>
    </Authorized>
    <NotAuthorized>
        <p>You're not authorized.</p>
    </NotAuthorized>
</AuthorizeView>
```

For guidance on the use of <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView>, see <xref:blazor/security/index#authorizeview-component>.

## Notification about authentication state changes

A [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider) can invoke <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> on the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> base class to notify consumers of the authentication state change to rerender.

The following example is based on implementing a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> by following the guidance in the [Implement a custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider) section.

The following `CustomAuthenticationStateProvider` implementation exposes a custom method, `AuthenticateUser`, to sign in a user and notify consumers of the authentication state change.

`CustomAuthenticationStateProvider.cs`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(user));
    }

    public void AuthenticateUser(string userIdentifier)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, userIdentifier),
        }, "Custom Authentication");

        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(user)));
    }
}
```

In a component:

* Inject <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>.
* Add a field to hold the user's identifier.
* Add a button and a method to cast the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> to `CustomAuthenticationStateProvider` and call `AuthenticateUser` with the user's identifier.

:::moniker range=">= aspnetcore-8.0"

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<input @bind="userIdentifier" />
<button @onclick="SignIn">Sign in</button>

<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity?.Name!</p>
    </Authorized>
    <NotAuthorized>
        <p>You're not authorized.</p>
    </NotAuthorized>
</AuthorizeView>

@code {
    public string userIdentifier = string.Empty;

    private void SignIn()
    {
        ((CustomAuthenticationStateProvider)AuthenticationStateProvider)
            .AuthenticateUser(userIdentifier);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<input @bind="userIdentifier" />
<button @onclick="SignIn">Sign in</button>

<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity?.Name!</p>
    </Authorized>
    <NotAuthorized>
        <p>You're not authorized.</p>
    </NotAuthorized>
</AuthorizeView>

@code {
    public string userIdentifier = string.Empty;

    private void SignIn()
    {
        ((CustomAuthenticationStateProvider)AuthenticationStateProvider)
            .AuthenticateUser(userIdentifier);
    }
}
```

:::moniker-end

The preceding approach can be enhanced to trigger notifications of authentication state changes via a custom service. The following `AuthenticationService` maintains the current user's claims principal in a backing field (`currentUser`) with an event (`UserChanged`) that the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> can subscribe to, where the event invokes <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A>. With the additional configuration later in this section, the `AuthenticationService` can be injected into a component with logic that sets the `CurrentUser` to trigger the `UserChanged` event.

```csharp
using System.Security.Claims;

public class AuthenticationService
{
    public event Action<ClaimsPrincipal>? UserChanged;
    private ClaimsPrincipal? currentUser;

    public ClaimsPrincipal CurrentUser
    {
        get { return currentUser ?? new(); }
        set
        {
            currentUser = value;

            if (UserChanged is not null)
            {
                UserChanged(currentUser);
            }
        }
    }
}
```

:::moniker range=">= aspnetcore-6.0"

In the `Program` file, register the `AuthenticationService` in the dependency injection container:

```csharp
builder.Services.AddScoped<AuthenticationService>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`, register the `AuthenticationService` in the dependency injection container:

```csharp
services.AddScoped<AuthenticationService>();
```

:::moniker-end

The following `CustomAuthenticationStateProvider` subscribes to the `AuthenticationService.UserChanged` event. `GetAuthenticationStateAsync` returns the user's authentication state. Initially, the authentication state is based on the value of the `AuthenticationService.CurrentUser`. When there's a change in user, a new authentication state is created with the new user (`new AuthenticationState(newUser)`) for calls to `GetAuthenticationStateAsync`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private AuthenticationState authenticationState;

    public CustomAuthenticationStateProvider(AuthenticationService service)
    {
        authenticationState = new AuthenticationState(service.CurrentUser);

        service.UserChanged += (newUser) =>
        {
            authenticationState = new AuthenticationState(newUser);

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(newUser)));
        };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(authenticationState);
}
```

The following component's `SignIn` method creates a claims principal for the user's identifier to set on `AuthenticationService.CurrentUser`:

:::moniker range=">= aspnetcore-8.0"

```razor
@inject AuthenticationService AuthenticationService

<input @bind="userIdentifier" />
<button @onclick="SignIn">Sign in</button>

<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity?.Name!</p>
    </Authorized>
    <NotAuthorized>
        <p>You're not authorized.</p>
    </NotAuthorized>
</AuthorizeView>

@code {
    public string userIdentifier = string.Empty;

    private void SignIn()
    {
        var currentUser = AuthenticationService.CurrentUser;

        var identity = new ClaimsIdentity(
            new[]
            {
                new Claim(ClaimTypes.Name, userIdentifier),
            },
            "Custom Authentication");

        var newUser = new ClaimsPrincipal(identity);

        AuthenticationService.CurrentUser = newUser;
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@inject AuthenticationService AuthenticationService

<input @bind="userIdentifier" />
<button @onclick="SignIn">Sign in</button>

<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity?.Name!</p>
    </Authorized>
    <NotAuthorized>
        <p>You're not authorized.</p>
    </NotAuthorized>
</AuthorizeView>

@code {
    public string userIdentifier = string.Empty;

    private void SignIn()
    {
        var currentUser = AuthenticationService.CurrentUser;

        var identity = new ClaimsIdentity(
            new[]
            {
                new Claim(ClaimTypes.Name, userIdentifier),
            },
            "Custom Authentication");

        var newUser = new ClaimsPrincipal(identity);

        AuthenticationService.CurrentUser = newUser;
    }
}
```

:::moniker-end

## Inject `AuthenticationStateProvider` for services scoped to a component

Don't attempt to resolve <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> within a custom scope because it results in the creation of a new instance of the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that isn't correctly initialized.

To access the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> within a service scoped to a component, inject the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> with the [`@inject` directive](xref:mvc/views/razor#inject) or the [`[Inject]` attribute](xref:Microsoft.AspNetCore.Components.InjectAttribute) and pass it to the service as a parameter. This approach ensures that the correct, initialized instance of the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> is used for each user app instance.
  
`ExampleService.cs`:

```csharp
public class ExampleService
{
    public async Task<string> ExampleMethod(AuthenticationStateProvider authStateProvider)
    {
        var authState = await authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            return $"{user.Identity.Name} is authenticated.";
        }
        else
        {
            return "The user is NOT authenticated.";
        }
    }
}
```
  
Register the service as scoped. In a server-side Blazor app, scoped services have a lifetime equal to the duration of the client connection [circuit](xref:blazor/hosting-models#blazor-server).

:::moniker range=">= aspnetcore-6.0"

In the `Program` file:

```csharp
builder.Services.AddScoped<ExampleService>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`:

```csharp
services.AddScoped<ExampleService>();
```

:::moniker-end

In the following `InjectAuthStateProvider` component:

* The component inherits <xref:Microsoft.AspNetCore.Components.OwningComponentBase>.
* The <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> is injected and passed to `ExampleService.ExampleMethod`.
* `ExampleService` is resolved with <xref:Microsoft.AspNetCore.Components.OwningComponentBase.ScopedServices?displayProperty=nameWithType> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A>, which returns the correct, initialized instance of `ExampleService` that exists for the lifetime of the user's circuit.

`InjectAuthStateProvider.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/inject-auth-state-provider"
@inherits OwningComponentBase
@inject AuthenticationStateProvider AuthenticationStateProvider

<h1>Inject <code>AuthenticationStateProvider</code> Example</h1>

<p>@message</p>

@code {
    private string? message;
    private ExampleService? ExampleService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ExampleService = ScopedServices.GetRequiredService<ExampleService>();

        message = await ExampleService.ExampleMethod(AuthenticationStateProvider);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/inject-auth-state-provider"
@inject AuthenticationStateProvider AuthenticationStateProvider
@inherits OwningComponentBase

<h1>Inject <code>AuthenticationStateProvider</code> Example</h1>

<p>@message</p>

@code {
    private string? message;
    private ExampleService? ExampleService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ExampleService = ScopedServices.GetRequiredService<ExampleService>();

        message = await ExampleService.ExampleMethod(AuthenticationStateProvider);
    }
}
```

:::moniker-end

For more information, see the guidance on <xref:Microsoft.AspNetCore.Components.OwningComponentBase> in <xref:blazor/fundamentals/dependency-injection#owningcomponentbase>.

## Unauthorized content display while prerendering with a custom `AuthenticationStateProvider`

To avoid showing unauthorized content, for example content in an [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component), while prerendering with a [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider), adopt ***one*** of the following approaches:

* Implement <xref:Microsoft.AspNetCore.Components.Authorization.IHostEnvironmentAuthenticationStateProvider> for the custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> to support prerendering: For an example implementation of <xref:Microsoft.AspNetCore.Components.Authorization.IHostEnvironmentAuthenticationStateProvider>, see the Blazor framework's <xref:Microsoft.AspNetCore.Components.Server.ServerAuthenticationStateProvider> implementation in [`ServerAuthenticationStateProvider.cs` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/Circuits/ServerAuthenticationStateProvider.cs).

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker range=">= aspnetcore-8.0"

* Disable prerendering: Indicate the render mode with the `prerender` parameter set to `false` at the highest-level component in the app's component hierarchy that isn't a root component.

  > [!NOTE]
  > Making a root component interactive, such as the `App` component, isn't supported. Therefore, prerendering can't be disabled directly by the `App` component.

  For apps based on the Blazor Web App project template, prerendering is typically disabled where the `Routes` component is used in the `App` component (`Components/App.razor`) :

  ```razor
  <Routes @rendermode="new InteractiveServerRenderMode(prerender: false)" />
  ```

  Also, disable prerendering for the `HeadOutlet` component:

  ```razor
  <HeadOutlet @rendermode="new InteractiveServerRenderMode(prerender: false)" />
  ```

  You can also selectively disable prerendering with fine control of the render mode applied to the `Routes` component instance. For more information, see <xref:blazor/components/render-modes#fine-control-of-render-modes>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* Disable prerendering: Open the `_Host.cshtml` file and change the `render-mode` attribute of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server>:

  ```cshtml
  <component type="typeof(App)" render-mode="Server" />
  ```

:::moniker-end

* Authenticate the user on the server before the app starts: To adopt this approach, the app must respond to a user's initial request with the Identity-based sign-in page or view and prevent any requests to Blazor endpoints until they're authenticated. For more information, see <xref:security/authorization/secure-data#require-authenticated-users>. After authentication, unauthorized content in prerendered Razor components is only shown when the user is truly unauthorized to view the content.

## User state management

In spite of the word "state" in the name, <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> isn't for storing *general user state*. <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> only indicates the user's authentication state to the app, whether they are signed into the app and who they are signed in as.

Authentication uses the same ASP.NET Core Identity authentication as Razor Pages and MVC apps. The user state stored for ASP.NET Core Identity flows to Blazor without adding additional code to the app. Follow the guidance in the ASP.NET Core Identity articles and tutorials for the Identity features to take effect in the Blazor parts of the app.

For guidance on general state management outside of ASP.NET Core Identity, see <xref:blazor/state-management?pivots=server>.

## Additional security abstractions

Two additional abstractions participate in managing authentication state:

* <xref:Microsoft.AspNetCore.Components.Server.ServerAuthenticationStateProvider> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/Circuits/ServerAuthenticationStateProvider.cs)): An <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> used by the Blazor framework to obtain authentication state from the server.

* <xref:Microsoft.AspNetCore.Components.Server.RevalidatingServerAuthenticationStateProvider> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/Circuits/RevalidatingServerAuthenticationStateProvider.cs)): A base class for <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> services used by the Blazor framework to receive an authentication state from the host environment and revalidate it at regular intervals.

  The default 30 minute revalidation interval can be adjusted in [`RevalidatingIdentityAuthenticationStateProvider` (`Areas/Identity/RevalidatingIdentityAuthenticationStateProvider.cs`)](https://github.com/dotnet/aspnetcore/blob/release/7.0/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorServerWeb-CSharp/Areas/Identity/RevalidatingIdentityAuthenticationStateProvider.cs). The following example shortens the interval to 20 minutes:

  ```csharp
  protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(20);
  ```

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker range=">= aspnetcore-8.0"

## Temporary redirection URL validity duration

*This section applies to Blazor Web Apps.*

Use the <xref:Microsoft.AspNetCore.Components.Endpoints.RazorComponentsServiceOptions.TemporaryRedirectionUrlValidityDuration%2A?displayProperty=nameWithType> option to get or set the lifetime of data protection validity for temporary redirection URLs emitted by Blazor server-side rendering. These are only used transiently, so the lifetime only needs to be long enough for a client to receive the URL and begin navigation to it. However, it should also be long enough to allow for clock skew across servers. The default value is five minutes.

In the following example the value is extended to seven minutes:

```csharp
builder.Services.AddRazorComponents(options => 
    options.TemporaryRedirectionUrlValidityDuration = 
        TimeSpan.FromMinutes(7));
```

:::moniker-end

## Additional resources

* [Quickstart: Add sign-in with Microsoft to an ASP.NET Core web app](/entra/identity-platform/quickstart-v2-aspnet-core-webapp)
* [Quickstart: Protect an ASP.NET Core web API with Microsoft identity platform](/entra/identity-platform/quickstart-v2-aspnet-core-web-api)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.
