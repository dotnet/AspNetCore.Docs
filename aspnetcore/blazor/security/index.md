---
title: ASP.NET Core Blazor authentication and authorization
author: guardrex
description: Learn about Blazor authentication and authorization scenarios.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/14/2019
uid: blazor/security/index
---
# ASP.NET Core Blazor authentication and authorization

By [Steve Sanderson](https://github.com/SteveSandersonMS)

Blazor and ASP.NET Core provide scenarios for the configuration and management of security in Blazor apps.

Security scenarios differ between Blazor server-side and client-side apps. Because Blazor server-side apps run on the server, authorization checks are able to determine:

* The UI options presented to a user (for example, which menu entries are available to a user).
* Access rules for areas of the app and components.

Blazor client-side apps run on the client. Authorization is *only* used to determine which UI options to show. Since client-side checks can be modified or bypassed by a user, a Blazor client-side app can't enforce authorization access rules.

For more information on ASP.NET Core security, see the articles under [ASP.NET Core Security and Identity](xref:security/index).

## Authentication

### Blazor server-side authentication

The mechanisms for determining a user's identity using cookies, tokens, or other mechanisms is the same in a Blazor server-side app as in any other ASP.NET Core app. The Blazor server-side project template can set up an authentication mechanism when a project is created.

# [Visual Studio](#tab/visual-studio)

Follow the Visual Studio guidance in the <xref:blazor/get-started> article to create a new Blazor server-side project with an authentication mechanism.

After choosing the **Blazor (server-side)** template in the **Create a new ASP.NET Core Web Application** dialog, select **Change** under **Authentication**.

A dialog opens to offer the same set of authentication mechanisms available for other ASP.NET Core projects:

* **No Authentication**
* **Individual User Accounts** &ndash; User accounts can be stored:
  * Within the app using ASP.NET Core's [Identity](xref:security/authentication/identity) system.
  * With [Azure AD B2C](xref:security/authentication/azure-ad-b2c).
* **Work or School Accounts**
* **Windows Authentication**

# [Visual Studio Code](#tab/visual-studio-code)

Follow the Visual Studio Code guidance in the <xref:blazor/get-started> article to create a new Blazor server-side project with an authentication mechanism:

```console
dotnet new blazorserverside -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism                                                                 | `{AUTHENTICATION}` value |
| ---------------------------------------------------------------------------------------- | :----------------------: |
| No Authentication                                                                        | `None`                   |
| Individual<br>Users stored in the app with ASP.NET Core Identity.                        | `Individual`             |
| Individual<br>Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c). | `IndividualB2C`          |
| Work or School Accounts<br>Organizational authentication for a single tenant.            | `SingleOrg`              |
| Work or School Accounts<br>Organizational authentication for multiple tenants.           | `MultiOrg`               |
| Windows Authentication                                                                   | `Windows`                |

The command creates a folder named with the value in the `{APP NAME}` placeholder and uses the same value as the app name. For more information, see the [dotnet new](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

Open the project's folder in Visual Studio Code.

<!--

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Follow the Visual Studio for Mac guidance in the <xref:blazor/get-started> article.

1.

1.

-->

   # [.NET Core CLI](#tab/netcore-cli/)

Follow the .NET Core CLI guidance in the <xref:blazor/get-started> article to create a new Blazor server-side project with an authentication mechanism:

```console
dotnet new blazorserverside -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism                                                                 | `{AUTHENTICATION}` value |
| ---------------------------------------------------------------------------------------- | :----------------------: |
| No Authentication                                                                        | `None`                   |
| Individual<br>Users stored in the app with ASP.NET Core Identity.                        | `Individual`             |
| Individual<br>Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c). | `IndividualB2C`          |
| Work or School Accounts<br>Organizational authentication for a single tenant.            | `SingleOrg`              |
| Work or School Accounts<br>Organizational authentication for multiple tenants.           | `MultiOrg`               |
| Windows Authentication                                                                   | `Windows`                |

The command creates a folder named with the value in the `{APP NAME}` placeholder and uses the same value as the app name. For more information, see the [dotnet new](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

---

### Blazor client-side authentication

In Blazor client-side apps, authentication checks can be bypassed because all client-side code can be modified by users. The same is true for all client-side app technologies, including JavaScript SPA frameworks or native apps for any operating system.

Implement an Authentication State Provider to integrate a Blazor client-side app with external authentication systems independently of server-side code. For more information, see the [Implement a custom Authentication State Provider](#implement-a-custom-authentication-state-provider) section.

## \<AuthorizeView>

This approach is useful when you only need to *display* user data and don't need to use the data in procedural logic.

The `<AuthorizeView>` component exposes a `context` variable of type `AuthenticationState`, which you can use to display information about the signed-in user:

```cshtml
<AuthorizeView>
    <h1>Hello, @context.User.Identity.Name!</h1>
    <p>You can only see this content if you're authenticated.</p>
</AuthorizeView>
```

You can also supply different content for display if the user isn't authenticated:

```cshtml
<AuthorizeView>
    <Authorized>
        <h1>Hello, @context.User.Identity.Name!</h1>
        <p>You can only see this content if you're authenticated.</p>
    </Authorized>
    <NotAuthorized>
        <h1>Authentication Failure!</h1>
        <p>You're not signed in.</p>
    </NotAuthorized>
</AuthorizeView>
```

The content of `<Authorized>` and `<NotAuthorized>` can include arbitrary items, such as other interactive components.

Authorization conditions, such as roles or policies that control UI options or access, are covered in the [Authorization](#authorization) section.

If authorization conditions aren't specified, `<AuthorizeView>` treats:

* Authenticated (signed-in) users as authorized.
* Unauthenticated (signed-out) users as unauthorized.

## Content displayed during asynchronous authentication

Blazor allows for authentication state to be determined *asynchronously*. The primary scenario for this approach is in Blazor client-side apps that make a request to an external endpoint for authentication.

While authentication is in progress, `<AuthorizeView>` displays no content by default. Display content while authentication occurs with the `<Authorizing>` element:

```cshtml
<AuthorizeView>
    <Authorized>
        <h1>Hello, @context.User.Identity.Name!</h1>
        <p>You can only see this content if you're authenticated.</p>
    </Authorized>
    <Authorizing>
        <h1>Authentication in progress</h1>
        <p>You can only see this content while authentication is in progress.</p>
    </Authorizing>
</AuthorizeView>
```

This approach isn't applicable to Blazor server-side apps by default because Blazor server-side apps know the authentication state immediately. `Authorizing` content can be provided in a Blazor server-side app's Authorize View component (`<AuthorizeView>`), but the content is never displayed.

## Cascaded Task\<AuthenticationState>

If authentication state data is required for procedural logic, such as when performing an action triggered by the user, obtain the state data by receiving a cascaded parameter of type `Task<AuthenticationState>`.

```cshtml
@page "/"

<button @onclick="@LogUsername">Log username</button>

@code {
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    private async Task LogUsername()
    {
        var authState = await authenticationStateTask;
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            Console.WriteLine($"{user.Identity.Name} is authenticated.");
        }
        else
        {
            Console.WriteLine("The user is NOT authenticated.");
        }
    }
}
```

If `user.Identity.IsAuthenticated` is `true` and because the user is a <xref:System.Security.Claims.ClaimsPrincipal>, claims can be enumerated and membership in roles evaluated.

## Authentication State Provider service

Blazor server-side includes a built-in Authentication State Provider service (`AuthenticationStateProvider`) that obtains authentication state data from ASP.NET Core's server-side `HttpContext.User`. This is how authentication state integrates with existing ASP.NET Core server-side authentication mechanisms.

`AuthenticationStateProvider` is the underlying service that supports `<AuthorizeView>` and `Task<AuthenticationState>`.

We don't recommend using `AuthenticationStateProvider`. Use the `<AuthorizeView>` or `Task<AuthenticationState>` approaches described earlier where possible. The main drawback to using `AuthenticationStateProvider` directly is that the component isn't notified automatically if the underlying authentication state data changes.

The `AuthenticationStateProvider` service can provide the current user's <xref:System.Security.Claims.ClaimsPrincipal> data, as shown in the following example:

```cshtml
@page "/"
@inject AuthenticationStateProvider AuthenticationStateProvider

<button @onclick="@LogUsername">Write user info to console</button>

@code {
    private async Task LogUsername()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            Console.WriteLine($"{user.Identity.Name} is authenticated.");
        }
        else
        {
            Console.WriteLine("The user is NOT authenticated.");
        }
    }
}
```

If `user.Identity.IsAuthenticated` is `true` and because the user is a <xref:System.Security.Claims.ClaimsPrincipal>, claims can be enumerated and membership in roles evaluated.

For more information on dependency injection (DI) and services, see <xref:blazor/dependency-injection> and <xref:fundamentals/dependency-injection>.

## Implement a custom Authentication State Provider

> [!WARNING]
> **We don't recommend implementing a custom Authentication State Provider.**
>
> The built-in Authentication State Provider (`AuthenticationStateProvider`) implementation integrates with ASP.NET Core's built-in authentication mechanisms. If a custom provider is implemented, security vulnerabilities might be introduced to the app.

The only common scenario where a custom Authentication State Provider (`AuthenticationStateProvider`) is implemented is in a Blazor client-side app. A custom provider can integrate with external authentication systems independently of server-side code. In Blazor client-side apps, authentication only exists to present a convenient UI to well-behaved users&mdash;authentication doesn't enforce security in Blazor client-side apps because client-side rules can be bypassed by a malicious user.

If you're building a Blazor client-side app or if your app's specification absolutely requires a custom provider, implement a provider and override `GetAuthenticationStateAsync`:

```csharp
class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "mrfibuli"),
        }, "Fake authentication type");

        var user = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(user));
    }
}
```

The `CustomAuthStateProvider` service is registered in `Startup.ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
}
```

Using the `CustomAuthStateProvider`, all users are authenticated with the username `mrfibuli`.

### Wrap UI hierarchy with \<CascadingAuthenticationState>

If you want to use `<AuthorizeView>` or a cascaded parameter of type `Task<AuthenticationState>`, ensure `<CascadingAuthenticationState>` is wrapped around the relevant part of the UI hierarchy, for example in *App.razor*:


```cshtml
<CascadingAuthenticationState>
    <Router AppAssembly="typeof(Startup).Assembly">
        ...
    </Router>
</CascadingAuthenticationState>
```

### Customize the response with the Router component

The Router component (`<Router>`) allows the app to specify custom content if:

* Content isn't found.
* The user fails an `[Authorize]` condition applied to the component. The `[Authorize]` attribute is covered in the [[Authorize] attribute](#authorize-attribute) section.
* Asynchronous authentication is in progress.

In the default Blazor server-side project template, the *App.razor* file demonstrates how to set custom content:

```cshtml
<CascadingAuthenticationState>
    <Router AppAssembly="typeof(Startup).Assembly">
        <NotFoundContent>
            <h1>Sorry</h1>
            <p>Sorry, there's nothing at this address.</p>
        </NotFoundContent>
        <NotAuthorizedContent>
            <h1>Sorry</h1>
            <p>You're not authorized to reach this page.</p>
            <p>You may need to log in as a different user.</p>
        </NotAuthorizedContent>
        <AuthorizingContent>
            <h1>Authentication in progress</h1>
            <p>Only visible while authentication is in progress.</p>
        </AuthorizingContent>
    </Router>
</CascadingAuthenticationState>
```

The content of `<NotFoundContent>`, `<NotAuthorizedContent>`, and `<AuthorizingContent>` can include arbitrary items, such as other interactive components.

If `<NotAuthorizedContent>` isn't specified, the router uses the following fallback message:

```html
Not authorized.
```

> [!NOTE]
> **Known issue**: In ASP.NET Core 3.0 Preview 6, `<NotAuthorizedContent>` and `<AuthorizingContent>` on the Router component can't be specified in Blazor server-side apps but do work in Blazor client-side apps. This will be addressed in the Preview 7 release.

### Notification about authentication state changes

If the app determines that the underlying authentication state data has changed (for example, because the user signed out or another user has changed their roles), a custom Authentication State Provider can optionally invoke the method `NotifyAuthenticationStateChanged` on the `AuthenticationStateProvider` base class. This notifies consumers of the authentication state data (for example, `<AuthorizeView>`) to rerender using the new data.

## Authorization

After a user is authenticated, *authorization* rules are applied to control what the user can do.

Access is typically granted or denied based on whether:

* A user is authenticated (signed in).
* A user is in a *role*.
* A user has a *claim*.
* A *policy* is satisfied.

Each of these concepts is the same as in an ASP.NET Core MVC or Razor Pages app. For more information on ASP.NET Core security, see the articles under [ASP.NET Core Security and Identity](xref:security/index).

### Role-based and policy-based authorization with \<AuthorizeView>

The `<AuthorizeView>` component supports *role-based* or *policy-based* authorization.

For role-base authorization, use the `Roles` parameter:

```cshtml
<AuthorizeView Roles="admin, superuser">
    <p>You can only see this if you're an admin or superuser.</p>
</AuthorizeView>
```

For more information, see <xref:security/authorization/roles>.

For policy-based authorization, use the `Policy` parameter:

```cshtml
<AuthorizeView Policy="content-editor">
    <p>You can only see this if you satisfy the "content-editor" policy.</p>
</AuthorizeView>
```

Claims-based authorization is a special case of policy-based authorization. For example, you can define a policy that requires users to have a certain claim. For more information, see <xref:security/authorization/policies>.

These APIs can be used in either Blazor server-side or Blazor client-side apps.

If neither `Roles` nor `Policy` is specified, `<AuthorizeView>` uses the default policy, which by default is to treat:

* Authenticated (signed-in) users as authorized.
* Unauthenticated (signed-out) users as unauthorized.

### \[Authorize] attribute

Just like an app can use `[Authorize]` with an MVC controller or Razor page, `[Authorize]` can also be used with Razor Components:

```cshtml
@page "/"
@attribute [Authorize]

You can only see this if you're signed in.
```

> [!IMPORTANT]
> Only use `[Authorize]` on `@page` components reached via the Blazor Router. Authorization is only performed as an aspect of routing and *not* for child components rendered within a page. To authorize the display of specific parts within a page, use `<AuthorizeView>` instead.

You may need to add `@using Microsoft.AspNetCore.Authorization` either to the component or to the *\_Imports.razor* file in order for the component to compile.

The `[Authorize]` attribute also supports role-based or policy-based authorization. For role-based authorization, use the `Roles` parameter:

```cshtml
@page "/"
@attribute [Authorize(Roles = "admin, superuser")]

<p>You can only see this if you're in the 'admin' or 'superuser' role.</p>
```

For policy-based authorization, use the `Policy` parameter:

```cshtml
@page "/"
@attribute [Authorize(Policy = "content-editor")]

<p>You can only see this if you satisfy the 'content-editor' policy.</p>
```

If neither `Roles` nor `Policy` is specified, `[Authorize]` uses the default policy, which by default is to treat:

* Authenticated (signed-in) users as authorized.
* Unauthenticated (signed-out) users as unauthorized.

### Procedural logic

If the app is required to check authorization rules as part of procedural logic, use a cascaded parameter of type `Task<AuthenticationState>` to obtain the user's <xref:System.Security.Claims.ClaimsPrincipal>. `Task<AuthenticationState>` can be combined with other services, such as `IAuthorizationService`, to evaluate policies.

```cshtml
@inject IAuthorizationService AuthorizationService

<button @onclick="@DoSomething">Do something important</button>

@code {
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    private async Task DoSomething()
    {
        var user = (await authenticationStateTask).User;

        if (user.Identity.IsAuthenticated)
        {
            // Perform an action only available to authenticated (signed-in) users.
        }

        if (user.IsInRole("admin"))
        {
            // Perform an action only available to users in the 'admin' role.
        }

        if ((await AuthorizationService.AuthorizeAsync(user, "content-editor"))
            .Succeeded)
        {
            // Perform an action only available to users satisfying the 
            // 'content-editor' policy.
        }
    }
}
```

## Authorization in Blazor client-side apps

In Blazor client-side apps, authorization checks can be bypassed because all client-side code can be modified by users. The same is true for all client-side app technologies, including JavaScript SPA frameworks or native apps for any operating system.

**Always perform authorization checks on the server within any API endpoints accessed by your client-side app.**

## Troubleshoot errors

**Authorization requires a cascading parameter of type Task\<AuthenticationState>. Consider using CascadingAuthenticationState to supply this.**

**`null` value is received for `authenticationStateTask`**

It's likely that the project wasn't created using a Blazor server-side template with authentication enabled. Wrap a `<CascadingAuthenticationState>` around some part of the UI tree, for example in *App.razor* as follows:

```cshtml
<CascadingAuthenticationState>
    <Router AppAssembly="typeof(Startup).Assembly">
        ...
    </Router>
</CascadingAuthenticationState>
```

The `<CascadingAuthenticationState>` supplies the `Task<AuthenticationState>` cascading parameter, which in turn it receives from the underlying `AuthenticationStateProvider` DI service.

## Additional resources

* <xref:security/authentication/windowsauth>
