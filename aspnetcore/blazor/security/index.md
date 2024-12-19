---
title: ASP.NET Core Blazor authentication and authorization
author: guardrex
description: Learn about Blazor authentication and authorization scenarios.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2024
uid: blazor/security/index
---
# ASP.NET Core Blazor authentication and authorization

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes ASP.NET Core's support for the configuration and management of security in Blazor apps.

Blazor uses the existing ASP.NET Core authentication mechanisms to establish the user's identity. The exact mechanism depends on how the Blazor app is hosted, server-side or client-side.

Security scenarios differ between authorization code running server-side and client-side in Blazor apps. For authorization code that runs on the server, authorization checks are able to enforce access rules for areas of the app and components. Because client-side code execution can be tampered with, authorization code executing on the client can't be trusted to absolutely enforce access rules or control the display of client-side content.

:::moniker range=">= aspnetcore-8.0"

If authorization rule enforcement must be guaranteed, don't implement authorization checks in client-side code. Build a Blazor Web App that only relies on server-side rendering (SSR) for authorization checks and rule enforcement.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

If authorization rule enforcement and the security of data and code must be guaranteed, don't develop a client-side app. Build a Blazor Server app.

:::moniker-end

[Razor Pages authorization conventions](xref:security/authorization/razor-pages-authorization) don't apply to routable Razor components. If a non-routable Razor component is [embedded in a page of a Razor Pages app](xref:blazor/components/integration), the page's authorization conventions indirectly affect the Razor component along with the rest of the page's content.

:::moniker range="< aspnetcore-8.0"

ASP.NET Core Identity is designed to work in the context of HTTP request and response communication, which generally isn't the Blazor app client-server communication model. ASP.NET Core apps that use ASP.NET Core Identity for user management should use Razor Pages instead of Razor components for Identity-related UI, such as user registration, login, logout, and other user management tasks. Building Razor components that directly handle Identity tasks is possible for several scenarios but isn't recommended or supported by Microsoft.

ASP.NET Core abstractions, such as <xref:Microsoft.AspNetCore.Identity.SignInManager%601> and <xref:Microsoft.AspNetCore.Identity.UserManager%601>, aren't supported in Razor components. For more information on using ASP.NET Core Identity with Blazor, see [Scaffold ASP.NET Core Identity into a server-side Blazor app](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-server-side-blazor-app).

:::moniker-end

> [!NOTE]
> The code examples in this article adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core in .NET 6 or later. When targeting ASP.NET Core 5.0 or earlier, remove the null type designation (`?`) from examples in this article.

## Securely maintain sensitive data and credentials

Don't store app secrets, connection strings, credentials, passwords, personal identification numbers (PINs), private .NET/C# code, or private keys/tokens in client-side code, which is ***always insecure***. Client-side Blazor code should access secure services and databases through a secure web API that you control.

In test/staging and production environments, server-side Blazor code and web APIs should use secure authentication flows that avoid maintaining credentials within project code or configuration files. Outside of local development testing, we recommend avoiding the use of environment variables to store sensitive data, as environment variables aren't the most secure approach. For local development testing, the [Secret Manager tool](xref:security/app-secrets) is recommended for securing sensitive data. For more information, see the following resources:

* [Secure authentication flows (ASP.NET Core documentation)](xref:security/index#secure-authentication-flows)
* [Managed identities for Microsoft Azure services (this article)](#managed-identities-for-microsoft-azure-services)

For client-side and server-side local development and testing, use the [Secret Manager tool](xref:security/app-secrets) to secure sensitive credentials.

## Managed identities for Microsoft Azure services

For Microsoft Azure services, we recommend using *managed identities*. Managed identities securely authenticate to Azure services without storing credentials in app code. For more information, see the following resources:

* [What are managed identities for Azure resources? (Microsoft Entra documentation)](/entra/identity/managed-identities-azure-resources/overview)
* Azure services documentation
  * [Managed identities in Microsoft Entra for Azure SQL](/azure/azure-sql/database/authentication-azure-ad-user-assigned-managed-identity)
  * [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)

:::moniker range=">= aspnetcore-8.0"

## Antiforgery support

The Blazor template:

* Adds antiforgery services automatically when <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A> is called in the `Program` file.
* Adds Antiforgery Middleware by calling <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> in its request processing pipeline in the `Program` file and requires endpoint [antiforgery protection](xref:security/anti-request-forgery) to mitigate the threats of Cross-Site Request Forgery (CSRF/XSRF). <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> is called after <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>. A call to <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> must be placed after calls, if present, to <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>.

The <xref:Microsoft.AspNetCore.Components.Forms.AntiforgeryToken> component renders an antiforgery token as a hidden field, and this component is automatically added to form (<xref:Microsoft.AspNetCore.Components.Forms.EditForm>) instances. For more information, see <xref:blazor/forms/index#antiforgery-support>.

The <xref:Microsoft.AspNetCore.Components.Forms.AntiforgeryStateProvider> service provides access to an antiforgery token associated with the current session. Inject the service and call its <xref:Microsoft.AspNetCore.Components.Forms.AntiforgeryStateProvider.GetAntiforgeryToken> method to obtain the current <xref:Microsoft.AspNetCore.Components.Forms.AntiforgeryRequestToken>. For more information, see <xref:blazor/call-web-api#antiforgery-support>.

Blazor stores request tokens in component state, which guarantees that antiforgery tokens are available to interactive components, even when they don't have access to the request.

> [!NOTE]
> [Antiforgery mitigation](xref:security/anti-request-forgery) is only required when submitting form data to the server encoded as `application/x-www-form-urlencoded`, `multipart/form-data`, or `text/plain` since these are the [only valid form enctypes](https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#attr-fs-enctype).

For more information, see the following resources:

* <xref:security/anti-request-forgery>: This article is the primary ASP.NET Core article on the subject, which applies to server-side Blazor Server, the server project of Blazor Web Apps, and Blazor integration with MVC/Razor Pages.
* <xref:blazor/forms/index#antiforgery-support>: The *Antiforgery support* section of the article pertains to Blazor forms antiforgery support.

:::moniker-end

## Server-side Blazor authentication

Server-side Blazor apps are configured for security in the same manner as ASP.NET Core apps. For more information, see the articles under <xref:security/index>.

The authentication context is only established when the app starts, which is when the app first [connects to the WebSocket over a SignalR connection](xref:signalr/authn-and-authz) with the client. Authentication can be based on a cookie or some other bearer token, but authentication is managed via the SignalR hub and entirely within the [circuit](xref:blazor/hosting-models#blazor-server). The authentication context is maintained for the lifetime of the circuit. Apps periodically revalidate the user's authentication state every 30 minutes.

If the app must capture users for custom services or react to updates to the user, see <xref:blazor/security/additional-scenarios#circuit-handler-to-capture-users-for-custom-services>.

Blazor differs from a traditional server-rendered web apps that make new HTTP requests with cookies on every page navigation. Authentication is checked during navigation events. However, cookies aren't involved. Cookies are only sent when making an HTTP request to a server, which isn't what happens when the user navigates in a Blazor app. During navigation, the user's authentication state is checked within the Blazor circuit, which you can update at any time on the server using the [`RevalidatingAuthenticationStateProvider` abstraction](#additional-security-abstractions).

> [!IMPORTANT]
> Implementing a custom `NavigationManager` to achieve authentication validation during navigation isn't recommended. If the app must execute custom authentication state logic during navigation, use a [custom `AuthenticationStateProvider`](xref:blazor/security/authentication-state#implement-a-custom-authenticationstateprovider).

> [!NOTE]
> The code examples in this article adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core in .NET 6 or later. When targeting ASP.NET Core 5.0 or earlier, remove the null type designation (`?`) from the examples in this article.

The built-in or custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> service obtains authentication state data from ASP.NET Core's <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType>. This is how authentication state integrates with existing ASP.NET Core authentication mechanisms.

For more information on server-side authentication, see <xref:blazor/security/index>.

### `IHttpContextAccessor`/`HttpContext`

[!INCLUDE[](~/blazor/security/includes/httpcontext.md)]

### Shared state

[!INCLUDE[](~/blazor/security/includes/shared-state.md)]

### Server-side security of sensitive data and credentials

In test/staging and production environments, server-side Blazor code and web APIs should use secure authentication flows that avoid maintaining credentials within project code or configuration files. Outside of local development testing, we recommend avoiding the use of environment variables to store sensitive data, as environment variables aren't the most secure approach. For local development testing, the [Secret Manager tool](xref:security/app-secrets) is recommended for securing sensitive data. For more information, see the following resources:

* [Secure authentication flows (ASP.NET Core documentation)](xref:security/index#secure-authentication-flows)
* [Managed identities for Microsoft Azure services (Blazor documentation)](xref:blazor/security/index#managed-identities-for-microsoft-azure-services)

For client-side and server-side local development and testing, use the [Secret Manager tool](xref:security/app-secrets) to secure sensitive credentials.

### Project template

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

# [.NET CLI](#tab/net-cli/)

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

### Blazor Identity UI (Individual Accounts)

Blazor supports generating a full Blazor-based Identity UI when you choose the authentication option for *Individual Accounts*.

The Blazor Web App template scaffolds Identity code for a SQL Server database. The command line version uses SQLite and includes a SQLite database for Identity.

The template:

* Supports interactive server-side rendering (interactive SSR) and client-side rendering (CSR) scenarios with authenticated users. 
* Adds Identity Razor components and related logic for routine authentication tasks, such as signing users in and out. The Identity components also support advanced Identity features, such as [account confirmation and password recovery](xref:security/authentication/accconfirm) and [multifactor authentication](xref:security/authentication/mfa) using a third-party app. Note that the Identity components themselves don't support interactivity.
* Adds the Identity-related packages and dependencies.
* References the Identity packages in `_Imports.razor`.
* Creates a custom user Identity class (`ApplicationUser`).
* Creates and registers an EF Core database context (`ApplicationDbContext`).
* Configures routing for the built-in Identity endpoints.
* Includes Identity validation and business logic.

To inspect the Blazor framework's Identity components, access them in the `Pages` and `Shared` folders of the [`Account` folder in the Blazor Web App project template (reference source)](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account).

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

When you choose the Interactive WebAssembly or Interactive Auto render modes, the server handles all authentication and authorization requests, and the Identity components render statically on the server in the Blazor Web App's main project.

The framework provides a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> in both the server and client (`.Client`) projects to flow the user's authentication state to the browser. The server project calls `AddAuthenticationStateSerialization`, while the client project calls `AddAuthenticationStateDeserialization`. Authenticating on the server rather than the client allows the app to access authentication state during prerendering and before the .NET WebAssembly runtime is initialized. The custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> implementations use the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) (<xref:Microsoft.AspNetCore.Components.PersistentComponentState>) to serialize the authentication state into HTML comments and then read it back from WebAssembly to create a new <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> instance. For more information, see the [Manage authentication state in Blazor Web Apps](#manage-authentication-state-in-blazor-web-apps) section.

Only for Interactive Server solutions, [`IdentityRevalidatingAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/IdentityRevalidatingAuthenticationStateProvider.cs) is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that revalidates the security stamp for the connected user every 30 minutes an interactive circuit is connected.

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

When you choose the Interactive WebAssembly or Interactive Auto render modes, the server handles all authentication and authorization requests, and the Identity components render statically on the server in the Blazor Web App's main project. The project template includes a [`PersistentAuthenticationStateProvider` class (reference source)](https://github.com/dotnet/aspnetcore/blob/release/8.0/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp.Client/PersistentAuthenticationStateProvider.cs) in the `.Client` project to synchronize the user's authentication state between the server and the browser. The class is a custom implementation of <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>. The provider uses the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) (<xref:Microsoft.AspNetCore.Components.PersistentComponentState>) to prerender the authentication state and persist it to the page.

In the main project of a Blazor Web App, the authentication state provider is named either [`IdentityRevalidatingAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/IdentityRevalidatingAuthenticationStateProvider.cs) (Server interactivity solutions only) or [`PersistingRevalidatingAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/release/8.0/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/PersistingRevalidatingAuthenticationStateProvider.cs) (WebAssembly or Auto interactivity solutions).

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Blazor Identity depends on <xref:Microsoft.EntityFrameworkCore.DbContext> instances not [created by a factory](xref:blazor/blazor-ef-core#new-dbcontext-instances), which is intentional because <xref:Microsoft.EntityFrameworkCore.DbContext> is sufficient for the project template's Identity components to render statically without supporting interactivity.

For a description on how global interactive render modes are applied to non-Identity components while at the same time enforcing static SSR for the Identity components, see <xref:blazor/components/render-modes#area-folder-of-static-ssr-components>.

For more information on persisting prerendered state, see <xref:blazor/components/prerender#persist-prerendered-state>.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### Manage authentication state in Blazor Web Apps

*This section applies to Blazor Web Apps that adopt:*

* Individual Accounts
* *Client-side rendering (CSR, WebAssembly-based interactivity).*

A client-side authentication state provider is only used within Blazor and isn't integrated with the ASP.NET Core authentication system. During prerendering, Blazor respects the metadata defined on the page and uses the ASP.NET Core authentication system to determine if the user is authenticated. When a user navigates from one page to another, a client-side authentication provider is used. When the user refreshes the page (full-page reload), the client-side authentication state provider isn't involved in the authentication decision on the server. Since the user's state isn't persisted by the server, any authentication state maintained client-side is lost.

To address this, the best approach is to perform authentication within the ASP.NET Core authentication system. The client-side authentication state provider only takes care of reflecting the user's authentication state. Examples for how to accomplish this with authentication state providers are demonstrated by the Blazor Web App project template and described below.

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

In the server project's `Program` file, call `AddAuthenticationStateSerialization`, which serializes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> returned by the server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> using the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) (<xref:Microsoft.AspNetCore.Components.PersistentComponentState>):

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();
```

The API only serializes the server-side name and role claims for access in the browser. To include all claims, set `SerializeAllClaims` to `true` in the server-side call to `AddAuthenticationStateSerialization`:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization(
        options => options.SerializeAllClaims = true);
```

In the client (`.Client`) project's `Program` file, call `AddAuthenticationStateDeserialization`, which adds an <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> where the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> is deserialized from the server using `AuthenticationStateData` and the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) (<xref:Microsoft.AspNetCore.Components.PersistentComponentState>). There should be a corresponding call to `AddAuthenticationStateSerialization` in the server project.

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

* [`PersistingRevalidatingAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/release/8.0/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/PersistingRevalidatingAuthenticationStateProvider.cs): For Blazor Web Apps that adopt interactive server-side rendering (interactive SSR) and client-side rendering (CSR). This is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that revalidates the security stamp for the connected user every 30 minutes an interactive circuit is connected. It also uses the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) to flow the authentication state to the client, which is then fixed for the lifetime of CSR.

* [`PersistingServerAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/release/8.0/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/PersistingServerAuthenticationStateProvider.cs): For Blazor Web Apps that only adopt CSR. This is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that uses the [Persistent Component State service](xref:blazor/components/prerender#persist-prerendered-state) to flow the authentication state to the client, which is then fixed for the lifetime of CSR.

* [`PersistentAuthenticationStateProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/release/8.0/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp.Client/PersistentAuthenticationStateProvider.cs): For Blazor Web Apps that adopt CSR. This is a client-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that determines the user's authentication state by looking for data persisted in the page when it was rendered on the server. This authentication state is fixed for the lifetime of CSR. If the user needs to log in or out, a full-page reload is required. This only provides a user name and email for display purposes. It doesn't include tokens that authenticate to the server when making subsequent requests, which is handled separately using a cookie that's included on `HttpClient` requests to the server.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker-end

:::moniker range="< aspnetcore-8.0"

### Scaffold Identity

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

For more information on scaffolding Identity into a server-side Blazor app, see <xref:security/authentication/scaffold-identity#scaffold-identity-into-a-server-side-blazor-app>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Scaffold Identity into a server-side Blazor app:

* [Without existing authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-server-side-blazor-app-without-existing-authorization).
* [With authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-server-side-blazor-app-with-authorization).

:::moniker-end

### Additional claims and tokens from external providers

To store additional claims from external providers, see <xref:security/authentication/social/additional-claims>.

### Azure App Service on Linux with Identity Server

Specify the issuer explicitly when deploying to Azure App Service on Linux with Identity Server. For more information, see <xref:security/authentication/identity/spa#azure-app-service-on-linux>.

### Inject `AuthenticationStateProvider` for services scoped to a component

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

### Unauthorized content display while prerendering with a custom `AuthenticationStateProvider`

To avoid showing unauthorized content, for example content in an [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component), while prerendering with a [custom `AuthenticationStateProvider`](xref:blazor/security/authentication-state#implement-a-custom-authenticationstateprovider), adopt ***one*** of the following approaches:

* Implement <xref:Microsoft.AspNetCore.Components.Authorization.IHostEnvironmentAuthenticationStateProvider> for the custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> to support prerendering: For an example implementation of <xref:Microsoft.AspNetCore.Components.Authorization.IHostEnvironmentAuthenticationStateProvider>, see the Blazor framework's <xref:Microsoft.AspNetCore.Components.Server.ServerAuthenticationStateProvider> implementation in [`ServerAuthenticationStateProvider.cs` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Endpoints/src/DependencyInjection/ServerAuthenticationStateProvider.cs).

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

  You can also selectively control the render mode applied to the `Routes` component instance. For example, see <xref:blazor/components/render-modes#static-ssr-pages-in-a-globally-interactive-app>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* Disable prerendering: Open the `_Host.cshtml` file and change the `render-mode` attribute of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server>:

  ```cshtml
  <component type="typeof(App)" render-mode="Server" />
  ```

:::moniker-end

* Authenticate the user on the server before the app starts: To adopt this approach, the app must respond to a user's initial request with the Identity-based sign-in page or view and prevent any requests to Blazor endpoints until they're authenticated. For more information, see <xref:security/authorization/secure-data#require-authenticated-users>. After authentication, unauthorized content in prerendered Razor components is only shown when the user is truly unauthorized to view the content.

### User state management

In spite of the word "state" in the name, <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> isn't for storing *general user state*. <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> only indicates the user's authentication state to the app, whether they are signed into the app and who they are signed in as.

Authentication uses the same ASP.NET Core Identity authentication as Razor Pages and MVC apps. The user state stored for ASP.NET Core Identity flows to Blazor without adding additional code to the app. Follow the guidance in the ASP.NET Core Identity articles and tutorials for the Identity features to take effect in the Blazor parts of the app.

For guidance on general state management outside of ASP.NET Core Identity, see <xref:blazor/state-management?pivots=server>.

### Additional security abstractions

Two additional abstractions participate in managing authentication state:

* <xref:Microsoft.AspNetCore.Components.Server.ServerAuthenticationStateProvider> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Endpoints/src/DependencyInjection/ServerAuthenticationStateProvider.cs)): An <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> used by the Blazor framework to obtain authentication state from the server.

* <xref:Microsoft.AspNetCore.Components.Server.RevalidatingServerAuthenticationStateProvider> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/Circuits/RevalidatingServerAuthenticationStateProvider.cs)): A base class for <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> services used by the Blazor framework to receive an authentication state from the host environment and revalidate it at regular intervals.

  The default 30 minute revalidation interval can be adjusted in [`RevalidatingIdentityAuthenticationStateProvider` (`Areas/Identity/RevalidatingIdentityAuthenticationStateProvider.cs`)](https://github.com/dotnet/aspnetcore/blob/release/7.0/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorServerWeb-CSharp/Areas/Identity/RevalidatingIdentityAuthenticationStateProvider.cs). The following example shortens the interval to 20 minutes:

  ```csharp
  protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(20);
  ```

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### Authentication state management at sign out

Server-side Blazor persists user authentication state for the lifetime of the circuit, including across browser tabs. To proactively sign off a user across browser tabs when the user signs out on one tab, you must implement a <xref:Microsoft.AspNetCore.Components.Server.RevalidatingServerAuthenticationStateProvider> ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Server/src/Circuits/RevalidatingServerAuthenticationStateProvider.cs)) with a short <xref:Microsoft.AspNetCore.Components.Server.RevalidatingServerAuthenticationStateProvider.RevalidationInterval>.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker range=">= aspnetcore-8.0"

### Temporary redirection URL validity duration

*This section applies to Blazor Web Apps.*

Use the <xref:Microsoft.AspNetCore.Components.Endpoints.RazorComponentsServiceOptions.TemporaryRedirectionUrlValidityDuration%2A?displayProperty=nameWithType> option to get or set the lifetime of ASP.NET Core Data Protection validity for temporary redirection URLs emitted by Blazor server-side rendering. These are only used transiently, so the lifetime only needs to be long enough for a client to receive the URL and begin navigation to it. However, it should also be long enough to allow for clock skew across servers. The default value is five minutes.

In the following example the value is extended to seven minutes:

```csharp
builder.Services.AddRazorComponents(options => 
    options.TemporaryRedirectionUrlValidityDuration = 
        TimeSpan.FromMinutes(7));
```

:::moniker-end

## Client-side Blazor authentication

In client-side Blazor apps, client-side authentication checks can be bypassed because all client-side code can be modified by users. The same is true for all client-side app technologies, including JavaScript SPA frameworks and native apps for any operating system.

Add the following:

* A package reference for the [`Microsoft.AspNetCore.Components.Authorization`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization) NuGet package.

  [!INCLUDE[](~/includes/package-reference.md)]

* The <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> namespace to the app's `_Imports.razor` file.

To handle authentication, use the built-in or custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> service.

For more information on client-side authentication, see <xref:blazor/security/webassembly/index>.

## `AuthenticationStateProvider` service

:::moniker range=">= aspnetcore-8.0"

<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> is the underlying service used by the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component and cascading authentication services to obtain the authentication state for a user.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> is the underlying service used by the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> component to obtain the authentication state for a user.

:::moniker-end

You don't typically use <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> directly. Use the [`AuthorizeView` component](#authorizeview-component) or [`Task<AuthenticationState>`](#expose-the-authentication-state-as-a-cascading-parameter) approaches described later in this article. The main drawback to using <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> directly is that the component isn't notified automatically if the underlying authentication state data changes.

To implement a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>, see <xref:blazor/security/authentication-state>, which includes guidance on implementing user authentication state change notifications.

## Obtain a user's claims principal data

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> service can provide the current user's <xref:System.Security.Claims.ClaimsPrincipal> data, as shown in the following example.

`ClaimsPrincipalData.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/claims-principal-data"
@using System.Security.Claims
@inject AuthenticationStateProvider AuthenticationStateProvider

<h1>ClaimsPrincipal Data</h1>

<button @onclick="GetClaimsPrincipalData">Get ClaimsPrincipal Data</button>

<p>@authMessage</p>

@if (claims.Any())
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

In the preceding example:

* <xref:System.Security.Claims.ClaimsPrincipal.Claims%2A?displayProperty=nameWithType> returns the user's claims (`claims`) for display in the UI.
* The line that obtains the user's surname (`surname`) calls <xref:System.Security.Claims.ClaimsPrincipal.FindAll%2A?displayProperty=nameWithType> with a predicate to filter the user's claims.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/claims-principal-data"
@using System.Security.Claims
@inject AuthenticationStateProvider AuthenticationStateProvider

<h1>ClaimsPrincipal Data</h1>

<button @onclick="GetClaimsPrincipalData">Get ClaimsPrincipal Data</button>

<p>@authMessage</p>

@if (claims.Any())
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

If `user.Identity.IsAuthenticated` is `true` and because the user is a <xref:System.Security.Claims.ClaimsPrincipal>, claims can be enumerated and membership in roles evaluated.

For more information on dependency injection (DI) and services, see <xref:blazor/fundamentals/dependency-injection> and <xref:fundamentals/dependency-injection>. For information on how to implement a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>, see <xref:blazor/security/authentication-state#implement-a-custom-authenticationstateprovider>.

## Expose the authentication state as a cascading parameter

If authentication state data is required for procedural logic, such as when performing an action triggered by the user, obtain the authentication state data by defining a [cascading parameter](xref:blazor/components/cascading-values-and-parameters) of type `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>`, as the following example demonstrates.

`CascadeAuthState.razor`:

:::moniker range=">= aspnetcore-8.0"

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

:::moniker range="< aspnetcore-8.0"

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

If `user.Identity.IsAuthenticated` is `true`, claims can be enumerated and membership in roles evaluated.

:::moniker range=">= aspnetcore-8.0"

Set up the `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` [cascading parameter](xref:blazor/components/cascading-values-and-parameters) using the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and cascading authentication state services.

When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and the call to <xref:Microsoft.Extensions.DependencyInjection.CascadingAuthenticationStateServiceCollectionExtensions.AddCascadingAuthenticationState%2A> shown in the following example. A client-side Blazor app includes the required service registrations as well. Additional information is presented in the [Customize unauthorized content with the `Router` component](#customize-unauthorized-content-with-the-router-component) section.

```razor
<Router ...>
    <Found ...>
        <AuthorizeRouteView RouteData="routeData" 
            DefaultLayout="typeof(Layout.MainLayout)" />
        ...
    </Found>
</Router>
```

In the `Program` file, register cascading authentication state services:

```csharp
builder.Services.AddCascadingAuthenticationState();
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Set up the `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` [cascading parameter](xref:blazor/components/cascading-values-and-parameters) using the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> components.

When you create a Blazor app from one of the Blazor project templates with authentication enabled, the app includes the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> and <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> components shown in the following example. A client-side Blazor app includes the required service registrations as well. Additional information is presented in the [Customize unauthorized content with the `Router` component](#customize-unauthorized-content-with-the-router-component) section.

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

:::moniker-end

:::moniker range="= aspnetcore-5.0"

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

In a client-side Blazor app, add authorization services to the `Program` file:

```csharp
builder.Services.AddAuthorizationCore();
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

In a client-side Blazor app, add options and authorization services to the `Program` file:

```csharp
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
```

:::moniker-end

In a server-side Blazor app, services for options and authorization are already present, so no further steps are required.

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
    <p>Hello, @context.User.Identity?.Name!</p>
</AuthorizeView>
```

You can also supply different content for display if the user isn't authorized with a combination of the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.Authorized%2A> and <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.NotAuthorized%2A> parameters:

```razor
<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity?.Name!</p>
        <p><button @onclick="HandleClick">Authorized Only Button</button></p>
    </Authorized>
    <NotAuthorized>
        <p>You're not authorized.</p>
    </NotAuthorized>
</AuthorizeView>

@code {
    private void HandleClick() { ... }
}
```

Although the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component controls the visibility of elements based on the user’s authorization status, it doesn't enforce security on the event handler itself. In the preceding example, the `HandleClick` method is only associated with a button visible to authorized users, but nothing prevents invoking this method from other places. To ensure method-level security, implement additional authorization logic within the handler itself or in the relevant API.

:::moniker range=">= aspnetcore-8.0"

Razor components of Blazor Web Apps never display `<NotAuthorized>` content when authorization fails server-side during static server-side rendering (static SSR). The server-side ASP.NET Core pipeline processes authorization on the server. Use server-side techniques to handle unauthorized requests. For more information, see <xref:blazor/components/render-modes#static-server-side-rendering-static-ssr>.

:::moniker-end

> [!WARNING]
> Client-side markup and methods associated with an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> are only protected from view and execution in the ***rendered UI*** in client-side Blazor apps. In order to protect authorized content and secure methods in client-side Blazor, the content is usually supplied by a secure, authorized web API call to a server API and never stored in the app. For more information, see <xref:blazor/call-web-api> and <xref:blazor/security/webassembly/additional-scenarios>.

The content of <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.Authorized%2A> and <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.NotAuthorized%2A> can include arbitrary items, such as other interactive components.

Authorization conditions, such as roles or policies that control UI options or access, are covered in the [Authorization](#authorization) section.

If authorization conditions aren't specified, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> uses a default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component can be used in the `NavMenu` component (`Shared/NavMenu.razor`) to display a [`NavLink` component](xref:blazor/fundamentals/routing#navlink-component) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), but note that this approach only removes the list item from the rendered output. It doesn't prevent the user from navigating to the component. Implement authorization separately in the destination component.

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
    <p>User: @context.User</p>
    <p>You have the 'Admin' role claim.</p>
    <AuthorizeView Roles="Superuser" Context="innerContext">
        <p>User: @innerContext.User</p>
        <p>You have both 'Admin' and 'Superuser' role claims.</p>
    </AuthorizeView>
</AuthorizeView>
```

The preceding code establishes a `Context` for the inner <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component to prevent an <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> context collision. The <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> context is accessed in the outer <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> with the standard approach for accessing the context (`@context.User`). The context is accessed in the inner <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> with the named `innerContext` context (`@innerContext.User`).

For more information, including configuration guidance, see <xref:security/authorization/roles>.

For policy-based authorization, use the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy> parameter with a single policy name:

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

Because .NET string comparisons are case-sensitive, matching role and policy names is also case-sensitive. For example, `Admin` (uppercase `A`) is not treated as the same role as `admin` (lowercase `a`).

Pascal case is typically used for role and policy names (for example, `BillingAdministrator`), but the use of Pascal case isn't a strict requirement. Different casing schemes, such as camel case, kebab case, and snake case, are permitted. Using spaces in role and policy names is unusual but permitted by the framework. For example, `billing administrator` is an unusual role or policy name format in .NET apps, but it's a valid role or policy name.

### Content displayed during asynchronous authentication

Blazor allows for authentication state to be determined *asynchronously*. The primary scenario for this approach is in client-side Blazor apps that make a request to an external endpoint for authentication.

While authentication is in progress, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> displays no content. To display content while authentication occurs, assign content to the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.Authorizing%2A> parameter:

```razor
<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity?.Name!</p>
    </Authorized>
    <Authorizing>
        <p>You can only see this content while authentication is in progress.</p>
    </Authorizing>
</AuthorizeView>
```

This approach isn't normally applicable to server-side Blazor apps. Server-side Blazor apps know the authentication state as soon as the state is established. <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.Authorizing> content can be provided in an app's <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component, but the content is never displayed.

## `[Authorize]` attribute

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) is available in Razor components:

```razor
@page "/"
@attribute [Authorize]

You can only see this if you're signed in.
```

> [!IMPORTANT]
> Only use [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) on `@page` components reached via the Blazor router. Authorization is only performed as an aspect of routing and *not* for child components rendered within a page. To authorize the display of specific parts within a page, use <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> instead.

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

When the user isn't authorized and if the app doesn't [customize unauthorized content with the `Router` component](#customize-unauthorized-content-with-the-router-component), the framework automatically displays the following fallback message:

```html
Not authorized.
```

:::moniker range=">= aspnetcore-5.0"

## Resource authorization

To authorize users for resources, pass the request's route data to the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView.Resource> parameter of <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView>.

In the <xref:Microsoft.AspNetCore.Components.Routing.Router.Found?displayProperty=nameWithType> content for a requested route:

```razor
<AuthorizeRouteView Resource="routeData" RouteData="routeData" 
    DefaultLayout="typeof(MainLayout)" />
```

For more information on how authorization state data is passed and used in procedural logic, see the [Expose the authentication state as a cascading parameter](#expose-the-authentication-state-as-a-cascading-parameter) section.

When the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> receives the route data for the resource, authorization policies have access to <xref:Microsoft.AspNetCore.Components.RouteData.PageType?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.Components.RouteData.RouteValues?displayProperty=nameWithType> that permit custom logic to make authorization decisions.

In the following example, an `EditUser` policy is created in <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions> for the app's authorization service configuration (<xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorizationCore%2A>) with the following logic:

* Determine if a route value exists with a key of `id`. If the key exists, the route value is stored in `value`.
* In a variable named `id`, store `value` as a string or set an empty string value (`string.Empty`).
* If `id` isn't an empty string, assert that the policy is satisfied (return `true`) if the string's value starts with `EMP`. Otherwise, assert that the policy fails (return `false`).

In the `Program` file:

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

`EditUser.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

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

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

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

## Customize unauthorized content with the `Router` component

The <xref:Microsoft.AspNetCore.Components.Routing.Router> component, in conjunction with the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> component, allows the app to specify custom content if:

* The user fails an [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) condition applied to the component. The markup of the [`<NotAuthorized>`](xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView.NotAuthorized?displayProperty=nameWithType) element is displayed. The [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute is covered in the [`[Authorize]` attribute](#authorize-attribute) section.
* Asynchronous authorization is in progress, which usually means that the process of authenticating the user is in progress. The markup of the [`<Authorizing>`](xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView.Authorizing?displayProperty=nameWithType) element is displayed.

:::moniker range=">= aspnetcore-8.0"

> [!IMPORTANT]
> Blazor router features that display `<NotAuthorized>` and `<NotFound>` content aren't operational during static server-side rendering (static SSR) because request processing is entirely handled by ASP.NET Core middleware pipeline request processing and Razor components aren't rendered at all for unauthorized or bad requests. Use server-side techniques to handle unauthorized and bad requests during static SSR. For more information, see <xref:blazor/components/render-modes#static-server-side-rendering-static-ssr>.

```razor
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
</Router>
```

The content of <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.Authorized%2A> and <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.NotAuthorized%2A> can include arbitrary items, such as other interactive components.

> [!NOTE]
> The preceding requires cascading authentication state services registration in the app's `Program` file:
>
> ```csharp
> builder.Services.AddCascadingAuthenticationState();
> ```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

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
    </Router>
</CascadingAuthenticationState>
```

The content of <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound%2A>, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.Authorized%2A>, and <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.NotAuthorized%2A> can include arbitrary items, such as other interactive components.

:::moniker-end

If <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeViewCore.NotAuthorized%2A> content isn't specified, the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> uses the following fallback message:

```html
Not authorized.
```

An app created from the Blazor WebAssembly project template with authentication enabled includes a `RedirectToLogin` component, which is positioned in the `<NotAuthorized>` content of the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. When a user isn't authenticated (`context.User.Identity?.IsAuthenticated != true`), the `RedirectToLogin` component redirects the browser to the `authentication/login` endpoint for authentication. The user is returned to the requested URL after authenticating with the identity provider.

## Procedural logic

If the app is required to check authorization rules as part of procedural logic, use a cascaded parameter of type `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` to obtain the user's <xref:System.Security.Claims.ClaimsPrincipal>. `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` can be combined with other services, such as `IAuthorizationService`, to evaluate policies.

In the following example:

* The `user.Identity.IsAuthenticated` executes code for authenticated (signed-in) users.
* The `user.IsInRole("admin")` executes code for users in the 'Admin' role.
* The `(await AuthorizationService.AuthorizeAsync(user, "content-editor")).Succeeded` executes code for users satisfying the 'content-editor' policy.

A server-side Blazor app includes the appropriate namespaces when created from the project template. In a client-side Blazor app, confirm the presence of the <xref:Microsoft.AspNetCore.Authorization> and <xref:Microsoft.AspNetCore.Components.Authorization> namespaces either in the component or in the app's `_Imports.razor` file:

```razor
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
```

`ProceduralLogic.razor`:

:::moniker range=">= aspnetcore-8.0"

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

:::moniker range="< aspnetcore-8.0"

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

## Troubleshoot errors

Common errors:

* **Authorization requires a cascading parameter of type `Task<AuthenticationState>`. Consider using `CascadingAuthenticationState` to supply this.**

* **`null` value is received for `authenticationStateTask`**

It's likely that the project wasn't created using a server-side Blazor template with authentication enabled.

In .NET 7 or earlier, wrap a `<CascadingAuthenticationState>` around some part of the UI tree, for example around the Blazor router:

```razor
<CascadingAuthenticationState>
    <Router ...>
        ...
    </Router>
</CascadingAuthenticationState>
```

In .NET 8 or later, don't use the <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> component:

```diff
- <CascadingAuthenticationState>
      <Router ...>
          ...
      </Router>
- </CascadingAuthenticationState>
```

Instead, add cascading authentication state services to the service collection in the `Program` file:

```csharp
builder.Services.AddCascadingAuthenticationState();
```

The <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> component (.NET 7 or earlier) or services provided by <xref:Microsoft.Extensions.DependencyInjection.CascadingAuthenticationStateServiceCollectionExtensions.AddCascadingAuthenticationState%2A> (.NET 8 or later) supplies the `Task<`<xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState>`>` cascading parameter, which in turn it receives from the underlying <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> dependency injection service.

## Personally Identifiable Information (PII)

Microsoft uses the [GDPR definition for 'personal data' (GDPR 4.1)](https://gdpr-text.com/read/article-4/) when documentation discusses Personally Identifiable Information (PII).

PII refers any information relating to an identified or identifiable natural person. An identifiable natural person is one who can be identified, directly or indirectly, with any of the following:

* Name
* Identification number
* Location coordinates
* Online identifier
* Other specific factors
  * Physical
  * Physiological
  * Genetic
  * Mental (psychological)
  * Economic
  * Cultural
  * Social identity

## Additional resources

:::moniker range=">= aspnetcore-6.0"

* Server-side and Blazor Web App resources
  * [Quickstart: Add sign-in with Microsoft to an ASP.NET Core web app](/entra/identity-platform/quickstart-v2-aspnet-core-webapp)
  * [Quickstart: Protect an ASP.NET Core web API with Microsoft identity platform](/entra/identity-platform/quickstart-v2-aspnet-core-web-api)
  * <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
    * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
    * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.
* Microsoft identity platform documentation
  * [Overview](/entra/identity-platform/)
  * [OAuth 2.0 and OpenID Connect protocols on the Microsoft identity platform](/entra/identity-platform/v2-protocols)
  * [Microsoft identity platform and OAuth 2.0 authorization code flow](/entra/identity-platform/v2-oauth2-auth-code-flow)
  * [Microsoft identity platform ID tokens](/entra/identity-platform/id-tokens)
  * [Microsoft identity platform access tokens](/entra/identity-platform/access-tokens)
* <xref:security/index>
* <xref:security/authentication/windowsauth>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Awesome Blazor: Authentication](https://github.com/AdrienTorris/awesome-blazor#authentication) community sample links
* <xref:blazor/hybrid/security/index>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* Server-side Blazor resources
  * [Quickstart: Add sign-in with Microsoft to an ASP.NET Core web app](/entra/identity-platform/quickstart-v2-aspnet-core-webapp)
  * [Quickstart: Protect an ASP.NET Core web API with Microsoft identity platform](/entra/identity-platform/quickstart-v2-aspnet-core-web-api)
  * <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
    * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
    * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.
* Microsoft identity platform documentation
  * [Overview](/entra/identity-platform/)
  * [OAuth 2.0 and OpenID Connect protocols on the Microsoft identity platform](/entra/identity-platform/v2-protocols)
  * [Microsoft identity platform and OAuth 2.0 authorization code flow](/entra/identity-platform/v2-oauth2-auth-code-flow)
  * [Microsoft identity platform ID tokens](/entra/identity-platform/id-tokens)
  * [Microsoft identity platform access tokens](/entra/identity-platform/access-tokens)
* <xref:security/index>
* <xref:security/authentication/windowsauth>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Awesome Blazor: Authentication](https://github.com/AdrienTorris/awesome-blazor#authentication) community sample links

:::moniker-end
