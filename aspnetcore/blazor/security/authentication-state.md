---
title: ASP.NET Core Blazor authentication state
author: guardrex
description: Learn how to create a custom authentication state provider and receive notifications of user authentication state changes.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 09/23/2024
uid: blazor/security/authentication-state
zone_pivot_groups: blazor-app-models
---
# ASP.NET Core Blazor authentication state

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to create a custom [authentication state provider](xref:blazor/security/index#authenticationstateprovider-service) and receive user authentication state change notifications in code.

The general approaches taken for server-side and client-side Blazor apps are similar but differ in their exact implementations, so this article pivots between server-side Blazor apps and client-side Blazor apps. Use the pivot selector at the top of the article to change the article's pivot to match the type of Blazor project that you're working with:

* Server-side Blazor apps (**:::no-loc text="Server":::** pivot): Blazor Server for .NET 7 or earlier and the server project of a Blazor Web App for .NET 8 or later.
* Client-side Blazor apps (**Blazor WebAssembly** pivot): Blazor WebAssembly for all versions of .NET or the `.Client` project of a Blazor Web App for .NET 8 or later.

## Abstract `AuthenticationStateProvider` class

The Blazor framework includes an abstract <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> class to provide information about the authentication state of the current user with the following members:

* <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.GetAuthenticationStateAsync%2A>: Asynchronously gets the authentication state of the current user.
* <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.AuthenticationStateChanged>: An event that provides notification when the authentication state has changed. For example, this event may be raised if a user signs in or out of the app.
* <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A>: Raises an authentication state changed event.

## Implement a custom `AuthenticationStateProvider`

The app must reference the [`Microsoft.AspNetCore.Components.Authorization` NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization), which provides authentication and authorization support for Blazor apps.

[!INCLUDE[](~/includes/package-reference.md)]

:::zone pivot="server"

:::moniker range=">= aspnetcore-8.0"

Configure the following authentication, authorization, and cascading authentication state services in the `Program` file.

When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app is preconfigured with the following service registrations, which includes exposing the authentication state as a cascading parameter. For more information, see <xref:blazor/security/index#expose-the-authentication-state-as-a-cascading-parameter> with additional information presented in the article's [Customize unauthorized content with the `Router` component](xref:blazor/security/index#customize-unauthorized-content-with-the-router-component) section.

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Configure authentication and authorization services in the `Program` file.

When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the following service registration.

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

builder.Services.AddAuthorization();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Configure authentication and authorization services in `Startup.ConfigureServices` of `Startup.cs`.

When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the following service registration.

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

services.AddAuthorization();
```

:::moniker-end

:::zone-end

:::zone pivot="webassembly"

In Blazor WebAssembly apps (all .NET versions) or the `.Client` project of a Blazor Web App (.NET 8 or later), configure authentication, authorization, and cascading authentication state services in the `Program` file.

When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app is preconfigured with the following service registrations, which includes exposing the authentication state as a cascading parameter. For more information, see <xref:blazor/security/index#expose-the-authentication-state-as-a-cascading-parameter> with additional information presented in the article's [Customize unauthorized content with the `Router` component](xref:blazor/security/index#customize-unauthorized-content-with-the-router-component) section.

:::moniker range=">= aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Configure authentication and authorization services in the `Program` file.

When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the following service registration.

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

builder.Services.AddAuthorizationCore();
```

:::moniker-end

:::zone-end

Subclass <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and override <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.GetAuthenticationStateAsync%2A> to create the user's authentication state. In the following example, all users are authenticated with the username `mrfibuli`. 

`CustomAuthStateProvider.cs`:

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.Name, "mrfibuli"),
        ], "Custom Authentication");

        var user = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(user));
    }
}
```

> [!NOTE]
> The preceding code that creates a new <xref:System.Security.Claims.ClaimsIdentity> uses simplified collection initialization introduced with C# 12 (.NET 8). For more information, see [Collection expressions - C# language reference](/dotnet/csharp/language-reference/operators/collection-expressions).

:::zone pivot="server"

:::moniker range=">= aspnetcore-8.0"

The `CustomAuthStateProvider` service is registered in the `Program` file. Register the service *scoped* with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped%2A>:

```csharp
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In a Blazor Server app, register the service *scoped* with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped%2A> ***after*** the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>:

```csharp
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In a Blazor Server app, register the service *scoped* with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped%2A> ***after*** the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>:

```csharp
services.AddServerSideBlazor();

services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
```

:::moniker-end

:::zone-end

:::zone pivot="webassembly"

The `CustomAuthStateProvider` service is registered in the `Program` file. Register the service *singleton* with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A>:

```csharp
builder.Services.AddSingleton<AuthenticationStateProvider, CustomAuthStateProvider>();
```

:::zone-end

If it isn't present, add an [`@using`](xref:mvc/views/razor#using) statement to the `_Imports.razor` file to make the <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> namespace available across components:

```razor
@using Microsoft.AspNetCore.Components.Authorization;
```

:::moniker range=">= aspnetcore-8.0"

Confirm or change the route view component to an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> in the <xref:Microsoft.AspNetCore.Components.Routing.Router> component definition. The location of the `Router` component differs depending on the type of app. Use search to locate the component if you're unaware of its location in the project.

```razor
<Router ...>
    <Found ...>
        <AuthorizeRouteView RouteData="routeData" 
            DefaultLayout="typeof(Layout.MainLayout)" />
        ...
    </Found>
</Router>
```

> [!NOTE]
> When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> component. For more information, see <xref:blazor/security/index#expose-the-authentication-state-as-a-cascading-parameter> with additional information presented in the article's [Customize unauthorized content with the `Router` component](xref:blazor/security/index#customize-unauthorized-content-with-the-router-component) section.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Where the <xref:Microsoft.AspNetCore.Components.Routing.Router> component is located:

* Confirm or change the route view component to an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView>.
* Confirm or add a <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> component around the <xref:Microsoft.AspNetCore.Components.Routing.Router> component.

The location of the `Router` component differs depending on the type of app. Use search to locate the component if you're unaware of its location in the project.

```razor
<CascadingAuthenticationState>
    <Router ...>
        <Found ...>
            <AuthorizeRouteView RouteData="routeData" 
                DefaultLayout="typeof(MainLayout)" />
            ...
        </Found>
    </Router>
</CascadingAuthenticationState>
```

> [!NOTE]
> When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> components. For more information, see <xref:blazor/security/index#expose-the-authentication-state-as-a-cascading-parameter> with additional information presented in the article's [Customize unauthorized content with the `Router` component](xref:blazor/security/index#customize-unauthorized-content-with-the-router-component) section.

:::moniker-end

The following example <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component demonstrates the authenticated user's name:

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

## Authentication state change notifications

A [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider) can invoke <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> on the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> base class to notify consumers of the authentication state change to rerender.

The following example is based on implementing a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> by following the guidance in the [Implement a custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider) section earlier in this article. If you already followed the guidance in that section, the following `CustomAuthStateProvider` replaces the one shown in the section.

The following `CustomAuthStateProvider` implementation exposes a custom method, `AuthenticateUser`, to sign in a user and notify consumers of the authentication state change.

`CustomAuthStateProvider.cs`:

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(user));
    }

    public void AuthenticateUser(string userIdentifier)
    {
        var identity = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.Name, userIdentifier),
        ], "Custom Authentication");

        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(user)));
    }
}
```

> [!NOTE]
> The preceding code that creates a new <xref:System.Security.Claims.ClaimsIdentity> uses simplified collection initialization introduced with C# 12 (.NET 8). For more information, see [Collection expressions - C# language reference](/dotnet/csharp/language-reference/operators/collection-expressions).

In a component:

* Inject <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>.
* Add a field to hold the user's identifier.
* Add a button and a method to cast the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> to `CustomAuthStateProvider` and call `AuthenticateUser` with the user's identifier.

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
        ((CustomAuthStateProvider)AuthenticationStateProvider)
            .AuthenticateUser(userIdentifier);
    }
}
```

The preceding approach can be enhanced to trigger notifications of authentication state changes via a custom service. The following `CustomAuthenticationService` class maintains the current user's claims principal in a backing field (`currentUser`) with an event (`UserChanged`) that the authentication state provider can subscribe to, where the event invokes <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A>. With the additional configuration later in this section, the `CustomAuthenticationService` can be injected into a component with logic that sets the `CurrentUser` to trigger the `UserChanged` event.

`CustomAuthenticationService.cs`:

```csharp
using System.Security.Claims;

public class CustomAuthenticationService
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

:::zone pivot="server"

:::moniker range=">= aspnetcore-6.0"

In the `Program` file, register the `CustomAuthenticationService` in the dependency injection container:

```csharp
builder.Services.AddScoped<CustomAuthenticationService>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`, register the `CustomAuthenticationService` in the dependency injection container:

```csharp
services.AddScoped<CustomAuthenticationService>();
```

:::moniker-end

:::zone-end

:::zone pivot="webassembly"

In the `Program` file, register the `CustomAuthenticationService` in the dependency injection container:

```csharp
builder.Services.AddSingleton<CustomAuthenticationService>();
```

:::zone-end

The following `CustomAuthStateProvider` subscribes to the `CustomAuthenticationService.UserChanged` event. The `GetAuthenticationStateAsync` method returns the user's authentication state. Initially, the authentication state is based on the value of the `CustomAuthenticationService.CurrentUser`. When the user changes, a new authentication state is created for the new user (`new AuthenticationState(newUser)`) for calls to `GetAuthenticationStateAsync`:

```csharp
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private AuthenticationState authenticationState;

    public CustomAuthStateProvider(CustomAuthenticationService service)
    {
        authenticationState = new AuthenticationState(service.CurrentUser);

        service.UserChanged += (newUser) =>
        {
            authenticationState = new AuthenticationState(newUser);
            NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
        };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(authenticationState);
}
```

The following component's `SignIn` method creates a claims principal for the user's identifier to set on `CustomAuthenticationService.CurrentUser`:

```razor
@using System.Security.Claims
@inject CustomAuthenticationService AuthService

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
        var currentUser = AuthService.CurrentUser;

        var identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, userIdentifier),
            ],
            "Custom Authentication");

        var newUser = new ClaimsPrincipal(identity);

        AuthService.CurrentUser = newUser;
    }
}
```

> [!NOTE]
> The preceding code that creates a new <xref:System.Security.Claims.ClaimsIdentity> uses simplified collection initialization introduced with C# 12 (.NET 8). For more information, see [Collection expressions - C# language reference](/dotnet/csharp/language-reference/operators/collection-expressions).

## Additional resources

:::moniker range=">= aspnetcore-8.0"

* [Server-side unauthorized content display while prerendering with a custom `AuthenticationStateProvider`](xref:blazor/security/server/index#unauthorized-content-display-while-prerendering-with-a-custom-authenticationstateprovider)
* [How to access an `AuthenticationStateProvider` from a `DelegatingHandler` set up using an `IHttpClientFactory`](xref:blazor/security/server/additional-scenarios#access-authenticationstateprovider-in-outgoing-request-middleware)
* <xref:blazor/security/blazor-web-app-oidc>
* <xref:blazor/security/webassembly/standalone-with-identity>

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* [Server-side unauthorized content display while prerendering with a custom `AuthenticationStateProvider`](xref:blazor/security/server/index#unauthorized-content-display-while-prerendering-with-a-custom-authenticationstateprovider)
* [How to access an `AuthenticationStateProvider` from a `DelegatingHandler` set up using an `IHttpClientFactory`](xref:blazor/security/server/additional-scenarios#access-authenticationstateprovider-in-outgoing-request-middleware)
* <xref:blazor/security/blazor-web-app-oidc>
* <xref:blazor/security/webassembly/standalone-with-identity>
[Prerendering with authentication in hosted Blazor WebAssembly apps](xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication)

:::moniker-end
