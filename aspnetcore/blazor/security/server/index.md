---
title: Secure ASP.NET Core Blazor Server apps
author: guardrex
description: Learn how to secure Blazor Server apps as ASP.NET Core applications.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/16/2023
uid: blazor/security/server/index
---
# Secure ASP.NET Core Blazor Server apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to secure Blazor Server apps as ASP.NET Core applications.

Blazor Server apps are configured for security in the same manner as ASP.NET Core apps. For more information, see the articles under <xref:security/index>. Topics under this overview apply specifically to Blazor Server.

In Blazor Server apps, the authentication context is only established when the app starts, which is when the app first connects to the WebSocket. The authentication context is maintained for the lifetime of the circuit. Blazor Server apps periodically revalidate the user's authentication state, currently every 30 minutes by default.

If the app must capture users for custom services or react to updates to the user, see <xref:blazor/security/server/additional-scenarios#circuit-handler-to-capture-users-for-custom-services>.

Blazor Server differs from a traditional server-rendered web apps that make new HTTP requests with cookies on every page navigation. Authentication is checked during navigation events. However, cookies aren't involved. Cookies are only sent when making an HTTP request to a server, which isn't what happens when the user navigates in a Blazor Server app. During navigation, the user's authentication state is checked within the Blazor circuit, which you can update at any time on the server using the [`RevalidatingAuthenticationStateProvider` abstraction](#additional-security-abstractions).

> [!NOTE]
> Implementing a custom `NavigationManager` to achieve authentication validation during navigation isn't recommended for Blazor Server apps. If the app must execute custom authentication state logic during navigation, use a [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider).

## Blazor Server project template

The [Blazor Server project template](xref:blazor/project-structure) can be configured for authentication when the project is created.

# [Visual Studio](#tab/visual-studio)

Follow the Visual Studio guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism.

After choosing the **Blazor Server App** template and configuring the project, select the app's authentication under **Authentication type**:

* **Individual Accounts**: User accounts are stored within the app using ASP.NET Core [Identity](xref:security/authentication/identity).
* **Microsoft identity platform**: For more information, see <xref:blazor/security/index#additional-resources>.
* **Windows**: Use Windows Authentication.

# [Visual Studio Code](#tab/visual-studio-code)

Follow the Visual Studio Code guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism:

```dotnetcli
dotnet new blazorserver -o {PROJECT NAME} -au {AUTHENTICATION}
```

Permissible authentication values for the `{AUTHENTICATION}` placeholder are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{PROJECT NAME}` placeholder to:

* Create a folder for the project.
* Name the project.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Follow the Visual Studio for Mac guidance in <xref:blazor/tooling> to create a Blazor Server app.

1. Select **Individual Authentication (in-app)** from the **Authentication** dropdown list.

1. The app is created for individual users stored in the app with ASP.NET Core Identity.

# [.NET Core CLI](#tab/netcore-cli/)

Create a new Blazor Server project with an authentication mechanism using the following command in a command shell:

```dotnetcli
dotnet new blazorserver -o {PROJECT NAME} -au {AUTHENTICATION}
```

Permissible authentication values for the `{AUTHENTICATION}` placeholder are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{PROJECT NAME}` placeholder to:

* Create a folder for the project.
* Name the project.

For more information:

* See the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.
* Execute the help command for the Blazor Server template (`blazorserver`) in a command shell:

  ```dotnetcli
  dotnet new blazorserver --help
  ```

---

## Scaffold Identity

:::moniker range=">= aspnetcore-6.0"

For more information on scaffolding Identity into a Blazor Server project, see <xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Scaffold Identity into a Blazor Server project:

* [Without existing authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project-without-existing-authorization).
* [With authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project-with-authorization).

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

The `CustomAuthenticationStateProvider` service is registered in `Program.cs` ***after*** the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>:

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

Confirm or add an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> to the `App` component.

In `App.razor`:

```razor
<CascadingAuthenticationState>
    <Router ...>
        <Found ...>
            <AuthorizeRouteView RouteData="@routeData" 
                DefaultLayout="@typeof(MainLayout)" />
            ...
        </Found>
        <NotFound>
            ...
        </NotFound>
    </Router>
</CascadingAuthenticationState>
```

> [!NOTE]
> When you create a Blazor app from one of the Blazor project templates with authentication enabled, the `App` component includes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> components shown in the preceding example. For more information, see <xref:blazor/security/index#expose-the-authentication-state-as-a-cascading-parameter> with additional information presented in the article's [Customize unauthorized content with the Router component](xref:blazor/security/index#customize-unauthorized-content-with-the-router-component) section.

An <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> demonstrates the authenticated user's name in any component:

```razor
<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity.Name!</p>
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

    public void AuthenticateUser(string emailAddress)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, emailAddress),
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

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<input @bind="userIdentifier" />
<button @onclick="SignIn">Sign in</button>

<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity.Name!</p>
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

In `Program.cs`, register the `AuthenticationService` in the dependency injection container:

```csharp
builder.Services.AddScoped<AuthenticationService>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`, register the `AuthenticationService` in the dependency injection container:

```csharp
services.AddSingleton<AuthenticationService>();
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

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<input @bind="userIdentifier" />
<button @onclick="SignIn">Sign in</button>

<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity.Name!</p>
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
  
Register the service as scoped. In a Blazor Server app, scoped services have a lifetime equal to the duration of the client connection [circuit](xref:blazor/hosting-models#blazor-server).

:::moniker range=">= aspnetcore-6.0"

In `Program.cs`:

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

`Pages/InjectAuthStateProvider.razor`:

:::moniker range=">= aspnetcore-6.0"

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

:::moniker range="< aspnetcore-6.0"

```razor
@page "/inject-auth-state-provider"
@inject AuthenticationStateProvider AuthenticationStateProvider
@inherits OwningComponentBase

<h1>Inject <code>AuthenticationStateProvider</code> Example</h1>

<p>@message</p>

@code {
    private string message;
    private ExampleService ExampleService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ExampleService = ScopedServices.GetRequiredService<ExampleService>();

        message = await ExampleService.ExampleMethod(AuthenticationStateProvider);
    }
}
```

:::moniker-end

For more information, see the guidance on <xref:Microsoft.AspNetCore.Components.OwningComponentBase> in <xref:blazor/fundamentals/dependency-injection#owningcomponentbase>.

## Unauthorized content display during prerendering

To avoid showing unauthorized content during prerendering, implement <xref:Microsoft.AspNetCore.Components.Authorization.IHostEnvironmentAuthenticationStateProvider> to support prerendering, disable prerendering, maintain the current behavior, or authenticate the user on the server before the app starts.

## User state management

In spite of the word "state" in the name, <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> isn't for storing *general user state*. <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> only indicates the user's authentication state to the app, whether they are signed into the app and who they are signed in as.

In Blazor Server apps, authentication uses the same ASP.NET Core Identity authentication as Razor Pages and MVC apps. The user state stored for ASP.NET Core Identity flows to Blazor without adding additional code to the app. Follow the guidance in the ASP.NET Core Identity articles and tutorials for the Identity features to take effect in the Blazor parts of the app.

For guidance on general state management outside of ASP.NET Core Identity, see <xref:blazor/state-management?pivots=server>.

## Additional security abstractions

Two additional abstractions participate in managing authentication state:

* <xref:Microsoft.AspNetCore.Components.Server.ServerAuthenticationStateProvider> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/Circuits/ServerAuthenticationStateProvider.cs)): An <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> used by the Blazor framework to obtain authentication state from the server.

* <xref:Microsoft.AspNetCore.Components.Server.RevalidatingServerAuthenticationStateProvider> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/Circuits/RevalidatingServerAuthenticationStateProvider.cs)): A base class for <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> services used by the Blazor framework to receive an authentication state from the host environment and revalidate it at regular intervals.

  For a Blazor Server app created from the Blazor Server project template with authentication enabled, the default 30 minute revalidation interval can be adjusted in [`RevalidatingIdentityAuthenticationStateProvider` (`Areas/Identity/RevalidatingIdentityAuthenticationStateProvider.cs`)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorServerWeb-CSharp/Areas/Identity/RevalidatingIdentityAuthenticationStateProvider.cs). The following example shortens the interval to 20 minutes:

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
