---
title: Secure ASP.NET Core server-side Blazor apps
author: guardrex
description: Learn how to secure server-side Blazor apps as ASP.NET Core applications.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/16/2023
uid: blazor/security/server/index
---
# Secure ASP.NET Core server-side Blazor apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to secure server-side Blazor apps as ASP.NET Core applications.

[!INCLUDE[](~/blazor/includes/location-client-and-server-net31-or-later.md)]

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

<!-- UPDATE 8.0 Check this at RC2 -->

* **Individual Accounts**: User accounts are stored within the app using ASP.NET Core [Identity](xref:security/authentication/identity).
* **Microsoft identity platform**: For more information, see <xref:blazor/security/index#additional-resources>.
* **Windows**: Use Windows Authentication.

# [Visual Studio Code](#tab/visual-studio-code)

When issuing the .NET CLI command to create and configure the server-side Blazor app, indicate the authentication mechanism with the `-au|--auth` option:

```dotnetcli
-au {AUTHENTICATION}
```

> [!NOTE]
> For the full command, see <xref:blazor/tooling>.

Permissible authentication values for the `{AUTHENTICATION}` placeholder are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [.NET Core CLI](#tab/netcore-cli/)

When issuing the .NET CLI command to create and configure the server-side Blazor app, indicate the authentication mechanism with the `-au|--auth` option:

```dotnetcli
-au {AUTHENTICATION}
```

> [!NOTE]
> For the full command, see <xref:blazor/tooling>.

Permissible authentication values for the `{AUTHENTICATION}` placeholder are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

For more information:

* See the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.
* Execute the help command for the template in a command shell:

  ```dotnetcli
  dotnet new {PROJECT TEMPLATE} --help
  ```

  In the preceding command, the `{PROJECT TEMPLATE}` placeholder is the project template.

---

## Scaffold Identity

:::moniker range=">= aspnetcore-6.0"

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

:::moniker range=">= aspnetcore-6.0"

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

Confirm or add an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> for the Blazor router:

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
@attribute [RenderModeServer]
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

The following `CustomAuthenticationStateProvider` subscribes to the `AuthenticationService.UserChanged` event. `GetAuthenticationStateAsync` returns the authentication state of the service's current user (`AuthenticationService.CurrentUser`).

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
@attribute [RenderModeServer]
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
@attribute [RenderModeServer]
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

<!-- UPDATE 8.0 This content will be discussed with the PU after .NET 8 releases. This is tracked by https://github.com/dotnet/AspNetCore.Docs/issues/28001. -->

## Unauthorized content display while prerendering with a custom `AuthenticationStateProvider`

To avoid showing unauthorized content while prerendering with a [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider), adopt ***one*** of the following approaches:

* Implement <xref:Microsoft.AspNetCore.Components.Authorization.IHostEnvironmentAuthenticationStateProvider> for the custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> to support prerendering: For an example implementation of <xref:Microsoft.AspNetCore.Components.Authorization.IHostEnvironmentAuthenticationStateProvider>, see the Blazor framework's <xref:Microsoft.AspNetCore.Components.Server.ServerAuthenticationStateProvider> implementation in [`ServerAuthenticationStateProvider.cs` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/Circuits/ServerAuthenticationStateProvider.cs).

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker range=">= aspnetcore-8.0"

* Disable prerendering: Pass `false` to a server render mode attribute placed in the `Routes` component (`Routes.razor`):

  ```
  @attribute [RenderModeServer(false)]
  ```

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

## Additional resources

* [Quickstart: Add sign-in with Microsoft to an ASP.NET Core web app](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp)
* [Quickstart: Protect an ASP.NET Core web API with Microsoft identity platform](/azure/active-directory/develop/quickstart-v2-aspnet-core-web-api)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.
