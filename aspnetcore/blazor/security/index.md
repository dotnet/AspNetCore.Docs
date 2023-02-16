---
title: ASP.NET Core Blazor authentication and authorization
author: guardrex
description: Learn about Blazor authentication and authorization scenarios.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/16/2023
uid: blazor/security/index
---
# ASP.NET Core Blazor authentication and authorization

This article describes ASP.NET Core's support for the configuration and management of security in Blazor apps.

Security scenarios differ between Blazor Server and Blazor WebAssembly apps. Because Blazor Server apps run on the server, authorization checks are able to determine:

* The UI options presented to a user (for example, which menu entries are available to a user).
* Access rules for areas of the app and components.

Blazor WebAssembly apps run on the client. Authorization is *only* used to determine which UI options to show. Since client-side checks can be modified or bypassed by a user, a Blazor WebAssembly app can't enforce authorization access rules.

[Razor Pages authorization conventions](xref:security/authorization/razor-pages-authorization) don't apply to routable Razor components. If a non-routable Razor component is [embedded in a page of a Razor Pages app](xref:blazor/components/prerendering-and-integration), the page's authorization conventions indirectly affect the Razor component along with the rest of the page's content.

ASP.NET Core Identity is designed to work in the context of HTTP request and response communication, which generally isn't the Blazor app client-server communication model. ASP.NET Core apps that use ASP.NET Core Identity for user management should use Razor Pages instead of Razor components for Identity-related UI, such as user registration, login, logout, and other user management tasks. Building Razor components that directly handle Identity tasks is possible for several scenarios but isn't recommended or supported by Microsoft.

ASP.NET Core abstractions, such as <xref:Microsoft.AspNetCore.Identity.SignInManager%601> and <xref:Microsoft.AspNetCore.Identity.UserManager%601>, aren't supported in Razor components. For more information on using ASP.NET Core Identity with Blazor, see [Scaffold ASP.NET Core Identity into a Blazor Server app](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project).

## Authentication

Blazor uses the existing ASP.NET Core authentication mechanisms to establish the user's identity. The exact mechanism depends on how the Blazor app is hosted, Blazor Server or Blazor WebAssembly.

### Blazor Server authentication

Blazor Server operates over a SignalR connection with the client. [Authentication in SignalR-based apps](xref:signalr/authn-and-authz) is handled when the connection is established. Authentication can be based on a cookie or some other bearer token, but authentication is managed via the SignalR hub and entirely within the [circuit](xref:blazor/hosting-models#blazor-server).

The built-in <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> service for Blazor Server apps obtains authentication state data from ASP.NET Core's `HttpContext.User`. This is how authentication state integrates with existing ASP.NET Core authentication mechanisms.

#### Avoid `IHttpContextAccessor`/`HttpContext` in Razor components

[!INCLUDE[](~/blazor/security/includes/httpcontext.md)]

#### Shared state

[!INCLUDE[](~/blazor/security/includes/shared-state.md)]

### Blazor WebAssembly authentication

In Blazor WebAssembly, authentication checks can be bypassed because all client-side code can be modified by users. The same is true for all client-side app technologies, including JavaScript SPA frameworks and native apps for any operating system.

Add the following:

* A package reference for the [`Microsoft.AspNetCore.Components.Authorization`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization) NuGet package.

  [!INCLUDE[](~/includes/package-reference.md)]

* The <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> namespace to the app's `_Imports.razor` file.

To handle authentication, use of the built-in or custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> service is covered in the following sections.

For more information, see <xref:blazor/security/webassembly/index>.

## `AuthenticationStateProvider` service

<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> is the underlying service used by the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> component to obtain the authentication state for a user.

You don't typically use <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> directly. Use the [`AuthorizeView` component](#authorizeview-component) or [`Task<AuthenticationState>`](#expose-the-authentication-state-as-a-cascading-parameter) approaches described later in this article. The main drawback to using <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> directly is that the component isn't notified automatically if the underlying authentication state data changes.

> [!NOTE]
> To implement a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>, see <xref:blazor/security/server/index#implement-a-custom-authenticationstateprovider>.

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> service can provide the current user's <xref:System.Security.Claims.ClaimsPrincipal> data, as shown in the following example.

`Pages/ClaimsPrincipalData.razor`:

:::moniker range=">= aspnetcore-6.0"

```razor
@page "/claims-principle-data"
@using System.Security.Claims
@inject AuthenticationStateProvider AuthenticationStateProvider

<h1>ClaimsPrincipal Data</h1>

<button @onclick="GetClaimsPrincipalData">Get ClaimsPrincipal Data</button>

<p>@authMessage</p>

@if (claims.Count() > 0)
{
    <ul>
        @foreach (var claim in claims)
        {
            <li>@claim.Type: @claim.Value</li>
        }
    </ul>
}

<p>@surname</p>

@code {
    private string? authMessage;
    private string? surname;
    private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

    private async Task GetClaimsPrincipalData()
    {
        var authState = await AuthenticationStateProvider
            .GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            authMessage = $"{user.Identity.Name} is authenticated.";
            claims = user.Claims;
            surname = user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value;
        }
        else
        {
            authMessage = "The user is NOT authenticated.";
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
@page "/claims-principle-data"
@using System.Security.Claims
@using Microsoft.AspNetCore.Components.Authorization
@inject AuthenticationStateProvider AuthenticationStateProvider

<h1>ClaimsPrincipal Data</h1>

<button @onclick="GetClaimsPrincipalData">Get ClaimsPrincipal Data</button>

<p>@authMessage</p>

@if (claims.Count() > 0)
{
    <ul>
        @foreach (var claim in claims)
        {
            <li>@claim.Type: @claim.Value</li>
        }
    </ul>
}

<p>@surname</p>

@code {
    private string authMessage;
    private string surname;
    private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

    private async Task GetClaimsPrincipalData()
    {
        var authState = await AuthenticationStateProvider
            .GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            authMessage = $"{user.Identity.Name} is authenticated.";
            claims = user.Claims;
            surname = user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value;
        }
        else
        {
            authMessage = "The user is NOT authenticated.";
        }
    }
}
```

:::moniker-end

If `user.Identity.IsAuthenticated` is `true` and because the user is a <xref:System.Security.Claims.ClaimsPrincipal>, claims can be enumerated and membership in roles evaluated.

For more information on dependency injection (DI) and services, see <xref:blazor/fundamentals/dependency-injection> and <xref:fundamentals/dependency-injection>. For information on how to implement a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> in Blazor Server apps, see <xref:blazor/security/server/index#implement-a-custom-authenticationstateprovider>.

## Expose the authentication state as a cascading parameter

If authentication state data is required for procedural logic, such as when performing an action triggered by the user, obtain the authentication state data by defining a [cascading parameter](xref:blazor/components/cascading-values-and-parameters) of type `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>`, as the following example demonstrates.

`Pages/CascadeAuthState.razor`:

:::moniker range=">= aspnetcore-6.0"

```razor
@page "/cascade-auth-state"

<h1>Cascade Auth State</h1>

<p>@authMessage</p>

@code {
    private string authMessage = "The user is NOT authenticated.";

    [CascadingParameter]
    private Task<AuthenticationState>? authenticationState { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (authenticationState is not null)
        {
            var authState = await authenticationState;
            var user = authState?.User;

            if (user?.Identity is not null && user.Identity.IsAuthenticated)
            {
                authMessage = $"{user.Identity.Name} is authenticated.";
            }
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
@page "/cascade-auth-state"

<h1>Cascade Auth State</h1>

<p>@authMessage</p>

@code {
    private string authMessage = "The user is NOT authenticated.";

    [CascadingParameter]
    private Task<AuthenticationState> authenticationState { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (authenticationState is not null)
        {
            var authState = await authenticationState;
            var user = authState?.User;

            if (user?.Identity is not null && user.Identity.IsAuthenticated)
            {
                authMessage = $"{user.Identity.Name} is authenticated.";
            }
        }
    }
}
```

:::moniker-end

If `user.Identity.IsAuthenticated` is `true`, claims can be enumerated and membership in roles evaluated.

Set up the `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` [cascading parameter](xref:blazor/components/cascading-values-and-parameters) using the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> components in the `App` component.

> [!NOTE]
> When you create a Blazor app from one of the Blazor project templates with authentication enabled, the `App` component includes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> components shown in the following example. A Blazor WebAssembly app includes the required service registrations as well. Additional information is presented in the [Customize unauthorized content with the Router component](#customize-unauthorized-content-with-the-router-component) section.

`App.razor`:

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

:::moniker range="= aspnetcore-5.0"

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

:::moniker-end

In a Blazor WebAssembly App, add services for options and authorization to `Program.cs`:

```csharp
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
```

In a Blazor Server app, services for options and authorization are already present, so no further steps are required.

## Authorization

After a user is authenticated, *authorization* rules are applied to control what the user can do.

Access is typically granted or denied based on whether:

* A user is authenticated (signed in).
* A user is in a *role*.
* A user has a *claim*.
* A *policy* is satisfied.

Each of these concepts is the same as in an ASP.NET Core MVC or Razor Pages app. For more information on ASP.NET Core security, see the articles under [ASP.NET Core Security and Identity](xref:security/index).

## `AuthorizeView` component

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component selectively displays UI content depending on whether the user is authorized. This approach is useful when you only need to *display* data for the user and don't need to use the user's identity in procedural logic.

The component exposes a `context` variable of type <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> (`@context` in Razor syntax), which you can use to access information about the signed-in user:

```razor
<AuthorizeView>
    <p>Hello, @context.User.Identity.Name!</p>
</AuthorizeView>
```

You can also supply different content for display if the user isn't authorized:

```razor
<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity.Name!</p>
        <p><button @onclick="SecureMethod">Authorized Only Button</button></p>
    </Authorized>
    <NotAuthorized>
        <p>You're not authorized.</p>
    </NotAuthorized>
</AuthorizeView>

@code {
    private void SecureMethod() { ... }
}
```

A default event handler for an authorized element, such as the `SecureMethod` method for the `<button>` element in the preceding example, can only be invoked by an authorized user.

> [!WARNING]
> Client-side markup and methods associated with an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> are only protected from view and execution in the ***rendered UI*** in Blazor WebAssembly apps. In order to protect authorized content and secure methods for Blazor WebAssembly apps, the content is usually supplied by a secure, authorized web API call to a server API and never stored in the app. For more information, see <xref:blazor/call-web-api> and <xref:blazor/security/webassembly/additional-scenarios>.

The content of `<Authorized>` and `<NotAuthorized>` tags can include arbitrary items, such as other interactive components.

Authorization conditions, such as roles or policies that control UI options or access, are covered in the [Authorization](#authorization) section.

If authorization conditions aren't specified, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> uses a default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component can be used in the `NavMenu` component (`Shared/NavMenu.razor`) to display a [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), but note that this approach only removes the list item from the rendered output. It doesn't prevent the user from navigating to the component. Implement authorization separately in the destination component.

### Role-based and policy-based authorization

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component supports *role-based* or *policy-based* authorization.

For role-based authorization, use the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Roles> parameter. In the following example, the user must have a role claim for either the `Admin` or `Superuser` roles:

```razor
<AuthorizeView Roles="Admin, Superuser">
    <p>You have an 'Admin' or 'Superuser' role claim.</p>
</AuthorizeView>
```

To require a user have both `Admin` and `Superuser` role claims, nest <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components:

```razor
<AuthorizeView Roles="Admin">
    <AuthorizeView Roles="Superuser">
        <p>You have both 'Admin' or 'Superuser' role claims.</p>
    </AuthorizeView>
</AuthorizeView>
```

For more information, including configuration guidance, see <xref:security/authorization/roles>.

For policy-based authorization, use the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy> parameter with a single policy:

```razor
<AuthorizeView Policy="Over21">
    <p>You satisfy the 'Over21' policy.</p>
</AuthorizeView>
```

To handle the case where the user should satisfy one of several policies, create a policy that confirms that the user satisfies other policies.

To handle the case where the user must satisfy several policies simultaneously, take *either* of the following approaches:

* Create a policy for <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> that confirms that the user satisfies several other policies.
* Nest the policies in multiple <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components:

  ```razor
  <AuthorizeView Policy="Over21">
      <AuthorizeView Policy="LivesInCalifornia">
          <p>You satisfy the 'Over21' and 'LivesInCalifornia' policies.</p>
      </AuthorizeView>
  </AuthorizeView>
  ```

Claims-based authorization is a special case of policy-based authorization. For example, you can define a policy that requires users to have a certain claim. For more information, see <xref:security/authorization/policies>.

If neither <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Roles> nor <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy> is specified, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> uses the default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

Because .NET string comparisons are case-sensitive by default, matching role and policy names is also case-sensitive. For example, `Admin` (uppercase `A`) is not treated as the same role as `admin` (lowercase `a`).

Pascal case is typically used for role and policy names (for example, `BillingAdministrator`), but the use of Pascal case isn't a strict requirement. Different casing schemes, such as camel case, kebab case, and snake case, are permitted. Using spaces in role and policy names is unusual but permitted by the framework. For example, `billing administrator` is an unusual role or policy name format in .NET apps, but it's a valid role or policy name.

### Content displayed during asynchronous authentication

Blazor allows for authentication state to be determined *asynchronously*. The primary scenario for this approach is in Blazor WebAssembly apps that make a request to an external endpoint for authentication.

While authentication is in progress, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> displays no content by default. To display content while authentication occurs, use the `<Authorizing>` tag:

```razor
<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity.Name!</p>
    </Authorized>
    <Authorizing>
        <p>You can only see this content while authentication is in progress.</p>
    </Authorizing>
</AuthorizeView>
```

This approach isn't normally applicable to Blazor Server apps. Blazor Server apps know the authentication state as soon as the state is established. <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.Authorizing> content can be provided in a Blazor Server app's <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component, but the content is never displayed.

## `[Authorize]` attribute

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) is available in Razor components:

```razor
@page "/"
@attribute [Authorize]

You can only see this if you're signed in.
```

> [!IMPORTANT]
> Only use [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) on `@page` components reached via the Blazor Router. Authorization is only performed as an aspect of routing and *not* for child components rendered within a page. To authorize the display of specific parts within a page, use <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> instead.

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) also supports role-based or policy-based authorization. For role-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> parameter:

```razor
@page "/"
@attribute [Authorize(Roles = "Admin, Superuser")]

<p>You can only see this if you're in the 'Admin' or 'Superuser' role.</p>
```

For policy-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> parameter:

```razor
@page "/"
@attribute [Authorize(Policy = "Over21")]

<p>You can only see this if you satisfy the 'Over21' policy.</p>
```

If neither <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> nor <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> is specified, [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) uses the default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

When the user isn't authorized and if the app doesn't [customize unauthorized content with the Router component](#customize-unauthorized-content-with-the-router-component), the framework automatically displays the following fallback message:

```html
Not authorized.
```

:::moniker range=">= aspnetcore-5.0"

## Resource authorization

To authorize users for resources, pass the request's route data to the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView.Resource> parameter of <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView>.

In the <xref:Microsoft.AspNetCore.Components.Routing.Router.Found?displayProperty=nameWithType> content for a requested route in the `App` component (`App.razor`):

```razor
<AuthorizeRouteView Resource="@routeData" RouteData="@routeData" 
    DefaultLayout="@typeof(MainLayout)" />
```

For more information on how authorization state data is passed and used in procedural logic, see the [Expose the authentication state as a cascading parameter](#expose-the-authentication-state-as-a-cascading-parameter) section.

When the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> receives the route data for the resource, authorization policies have access to <xref:Microsoft.AspNetCore.Components.RouteData.PageType?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.Components.RouteData.RouteValues?displayProperty=nameWithType> that permit custom logic to make authorization decisions.

In the following example, an `EditUser` policy is created in <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions> for the app's authorization service configuration (<xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorizationCore%2A>) with the following logic:

* Determine if a route value exists with a key of `id`. If the key exists, the route value is stored in `value`.
* In a variable named `id`, store `value` as a string or set an empty string value (`string.Empty`).
* If `id` isn't an empty string, assert that the policy is satisfied (return `true`) if the string's value starts with `EMP`. Otherwise, assert that the policy fails (return `false`).

In either `Program.cs` or `Startup.cs` (depending on the hosting model and framework version):

* Add namespaces for <xref:Microsoft.AspNetCore.Components?displayProperty=fullName> and <xref:System.Linq?displayProperty=fullName>:

  ```csharp
  using Microsoft.AspNetCore.Components;
  using System.Linq;
  ```

* Add the policy:

  ```csharp
  options.AddPolicy("EditUser", policy =>
      policy.RequireAssertion(context =>
      {
          if (context.Resource is RouteData rd)
          {
              var routeValue = rd.RouteValues.TryGetValue("id", out var value);
              var id = Convert.ToString(value, 
                  System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty;

              if (!string.IsNullOrEmpty(id))
              {
                  return id.StartsWith("EMP", StringComparison.InvariantCulture);
              }
          }

          return false;
      })
  );
  ```

The preceding example is an oversimplified authorization policy, merely used to demonstrate the concept with a working example. For more information on creating and configuring authorization policies, see <xref:security/authorization/policies>.

In the following `EditUser` component, the resource at `/users/{id}/edit` has a route parameter for the user's identifier (`{id}`). The component uses the preceding `EditUser` authorization policy to determine if the route value for `id` starts with `EMP`. If `id` starts with `EMP`, the policy succeeds and access to the component is authorized. If `id` starts with a value other than `EMP` or if `id` is an empty string, the policy fails, and the component doesn't load.

`Pages/EditUser.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

```razor
@page "/users/{id}/edit"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "EditUser")]

<h1>Edit User</h1>

<p>The "EditUser" policy is satisfied! <code>Id</code> starts with 'EMP'.</p>

@code {
    [Parameter]
    public string? Id { get; set; }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

```razor
@page "/users/{id}/edit"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "EditUser")]

<h1>Edit User</h1>

<p>The "EditUser" policy is satisfied! <code>Id</code> starts with 'EMP'.</p>

@code {
    [Parameter]
    public string Id { get; set; }
}
```

:::moniker-end

## Customize unauthorized content with the Router component

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component, in conjunction with the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> component, allows the app to specify custom content if:

* The user fails an [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) condition applied to the component. The markup of the [`<NotAuthorized>`](xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView.NotAuthorized?displayProperty=nameWithType) element is displayed. The [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute is covered in the [`[Authorize]` attribute](#authorize-attribute) section.
* Asynchronous authorization is in progress, which usually means that the process of authenticating the user is in progress. The markup of the [`<Authorizing>`](xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView.Authorizing?displayProperty=nameWithType) element is displayed.
* Content isn't found. The markup of the [`<NotFound>`](xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound?displayProperty=nameWithType) element is displayed.

In the `App` component (`App.razor`):

```razor
<CascadingAuthenticationState>
    <Router ...>
        <Found ...>
            <AuthorizeRouteView ...>
                <NotAuthorized>
                    ...
                </NotAuthorized>
                <Authorizing>
                    ...
                </Authorizing>
            </AuthorizeRouteView>
        </Found>
        <NotFound>
            <LayoutView ...>
                ...
            </LayoutView>
        </NotFound>
    </Router>
</CascadingAuthenticationState>
```

The content of `<NotFound>`, `<NotAuthorized>`, and `<Authorizing>` tags can include arbitrary items, such as other interactive components.

If the `<NotAuthorized>` tag isn't specified, the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> uses the following fallback message:

```html
Not authorized.
```

An app created from the Blazor WebAssembly project template with authentication enabled includes a [`RedirectToLogin` component (`Shared/RedirectToLogin.razor` reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/Shared/RedirectToLogin.razor), which is positioned in the `<NotAuthorized>` content of the Blazor Router in the template's [`App` component (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/App.razor). When a user isn't authenticated (`context.User.Identity?.IsAuthenticated != true`), the `RedirectToLogin` component redirects the browser to the `authentication/login` endpoint for authentication. The user is returned to the requested URL after authenticating with the identity provider.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Procedural logic

If the app is required to check authorization rules as part of procedural logic, use a cascaded parameter of type `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` to obtain the user's <xref:System.Security.Claims.ClaimsPrincipal>. `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` can be combined with other services, such as `IAuthorizationService`, to evaluate policies.

In the following example:

* The `user.Identity.IsAuthenticated` executes code for authenticated (signed-in) users.
* The `user.IsInRole("admin")` executes code for users in the 'Admin' role.
* The `(await AuthorizationService.AuthorizeAsync(user, "content-editor")).Succeeded` executes code for users satisfying the 'content-editor' policy.

A Blazor Server app include the appropriate namespaces by default when created from the Blazor Server project template. In a Blazor WebAssembly app, confirm the presence of the <xref:Microsoft.AspNetCore.Authorization> and <xref:Microsoft.AspNetCore.Components.Authorization> namespaces either in the component or in the app's `_Imports.razor` file:

```razor
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
```

`Pages/ProceduralLogic.razor`:

:::moniker range=">= aspnetcore-6.0"

```razor
@page "/procedural-logic"
@inject IAuthorizationService AuthorizationService

<h1>Procedural Logic Example</h1>

<button @onclick="@DoSomething">Do something important</button>

@code {
    [CascadingParameter]
    private Task<AuthenticationState>? authenticationState { get; set; }

    private async Task DoSomething()
    {
        if (authenticationState is not null)
        {
            var authState = await authenticationState;
            var user = authState?.User;

            if (user is not null)
            {
                if (user.Identity is not null && user.Identity.IsAuthenticated)
                {
                    // ...
                }

                if (user.IsInRole("Admin"))
                {
                    // ...
                }

                if ((await AuthorizationService.AuthorizeAsync(user, "content-editor"))
                    .Succeeded)
                {
                    // ...
                }
            }
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
@page "/procedural-logic"
@inject IAuthorizationService AuthorizationService

<h1>Procedural Logic Example</h1>

<button @onclick="@DoSomething">Do something important</button>

@code {
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    private async Task DoSomething()
    {
        var user = (await authenticationStateTask).User;

        if (user.Identity.IsAuthenticated)
        {
            // ...
        }

        if (user.IsInRole("Admin"))
        {
            // ...
        }

        if ((await AuthorizationService.AuthorizeAsync(user, "content-editor"))
            .Succeeded)
        {
            // ...
        }
    }
}
```

:::moniker-end

## Troubleshoot errors

Common errors:

* **Authorization requires a cascading parameter of type `Task<AuthenticationState>`. Consider using `CascadingAuthenticationState` to supply this.**

* **`null` value is received for `authenticationStateTask`**

It's likely that the project wasn't created using a Blazor Server template with authentication enabled. Wrap a `<CascadingAuthenticationState>` around some part of the UI tree, for example in the `App` component (`App.razor`) as follows:

```razor
<CascadingAuthenticationState>
    <Router ...>
        ...
    </Router>
</CascadingAuthenticationState>
```

The <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> supplies the `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` cascading parameter, which in turn it receives from the underlying <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> dependency injection service.

## Additional resources

:::moniker range=">= aspnetcore-6.0"

* Microsoft identity platform documentation
  * [Overview](/azure/active-directory/develop/)
  * [OAuth 2.0 and OpenID Connect protocols on the Microsoft identity platform](/azure/active-directory/develop/active-directory-v2-protocols)
  * [Microsoft identity platform and OAuth 2.0 authorization code flow](/azure/active-directory/develop/v2-oauth2-auth-code-flow)
  * [Microsoft identity platform ID tokens](/azure/active-directory/develop/id-tokens)
  * [Microsoft identity platform access tokens](/azure/active-directory/develop/access-tokens)
* <xref:security/index>
* <xref:security/authentication/windowsauth>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Awesome Blazor: Authentication](https://github.com/AdrienTorris/awesome-blazor#authentication) community sample links
* <xref:blazor/hybrid/security/index>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* Microsoft identity platform documentation
  * [Overview](/azure/active-directory/develop/)
  * [OAuth 2.0 and OpenID Connect protocols on the Microsoft identity platform](/azure/active-directory/develop/active-directory-v2-protocols)
  * [Microsoft identity platform and OAuth 2.0 authorization code flow](/azure/active-directory/develop/v2-oauth2-auth-code-flow)
  * [Microsoft identity platform ID tokens](/azure/active-directory/develop/id-tokens)
  * [Microsoft identity platform access tokens](/azure/active-directory/develop/access-tokens)
* <xref:security/index>
* <xref:security/authentication/windowsauth>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Awesome Blazor: Authentication](https://github.com/AdrienTorris/awesome-blazor#authentication) community sample links

:::moniker-end
