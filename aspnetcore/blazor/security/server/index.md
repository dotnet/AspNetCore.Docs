---
title: Secure ASP.NET Core Blazor Server apps
author: guardrex
description: Learn how to secure Blazor Server apps as ASP.NET Core applications.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/security/server/index
---
# Secure ASP.NET Core Blazor Server apps

This article explains how to secure Blazor Server apps as ASP.NET Core applications.

:::moniker range=">= aspnetcore-6.0"

Blazor Server apps are configured for security in the same manner as ASP.NET Core apps. For more information, see the articles under <xref:security/index>. Topics under this overview apply specifically to Blazor Server.

## Blazor Server uses ASP.NET Core Identity

Blazor Server uses ASP.NET Core Identity and doesn't offer a separate authentication process within Blazor for authentication and authorization.

Fundamental challenges exist to implementing security independent of ASP.NET Core Identity for Blazor Server:

* ASP.NET Core Identity provides the UI layer using Razor Pages, which are designed to work in the context of a request-response model, contrary to Blazor, which works in a stateful model over a WebSocket connection.
* <xref:Microsoft.AspNetCore.Identity.SignInManager%601>, <xref:Microsoft.AspNetCore.Identity.UserManager%601>, and other Identity abstractions expect an available HTTP request and response to function properly.
* HTTP cookies and other implementations for authentication can't function over a WebSocket connection, which is a fundamental challenge to performing authentication in Blazor.
* Creating a new Identity implementation with a new authentication process is difficult to justify when we consider the reusability of ASP.NET Core Identity with all of the design and validation that it has received.

Use of a separate UI stack for part of an app and performing authentication outside of the Blazor portions of an app might be undesirable for some developers or for some app designs. However, the majority of SPA frameworks implement an authentication process where users are redirected to an external provider and returned to the app. In this regard, Blazor Server is similar to other SPA frameworks.

## Blazor Server project template

The [Blazor Server project template](xref:blazor/project-structure) can be configured for authentication when the project is created.

# [Visual Studio](#tab/visual-studio)

Follow the Visual Studio guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism.

After choosing the **Blazor Server App** template in the **Create a new ASP.NET Core Web Application** dialog, select **Change** under **Authentication**.

A dialog opens to offer the same set of authentication mechanisms available for other ASP.NET Core projects:

* **No Authentication**
* **Individual User Accounts**: User accounts can be stored:
  * Within the app using ASP.NET Core's [Identity](xref:security/authentication/identity) system.
  * With [Azure AD B2C](xref:security/authentication/azure-ad-b2c).
* **Work or School Accounts**
* **Windows Authentication**

# [Visual Studio Code](#tab/visual-studio-code)

Follow the Visual Studio Code guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism:

```dotnetcli
dotnet new blazorserver -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{APP NAME}` placeholder to:

* Create a folder for the project.
* Name the project.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Follow the Visual Studio for Mac guidance in <xref:blazor/tooling>.

1. On the **Configure your new Blazor Server App** step, select **Individual Authentication (in-app)** from the **Authentication** drop down.

1. The app is created for individual users stored in the app with ASP.NET Core Identity.

# [.NET Core CLI](#tab/netcore-cli/)

Create a new Blazor Server project with an authentication mechanism using the following command in a command shell:

```dotnetcli
dotnet new blazorserver -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{APP NAME}` placeholder to:

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

For more information on scaffolding Identity into a Blazor Server project, see <xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project>.

## Additional claims and tokens from external providers

To store additional claims from external providers, see <xref:security/authentication/social/additional-claims>.

## Azure App Service on Linux with Identity Server

Specify the issuer explicitly when deploying to Azure App Service on Linux with Identity Server. For more information, see <xref:security/authentication/identity/spa#azure-app-service-on-linux>.

## Notification about authentication state changes

If the app determines that the underlying authentication state data has changed (for example, because the user signed out or another user has changed their roles), a [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider) can optionally invoke the method <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> on the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> base class. This notifies consumers of the authentication state data (for example, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView>) to rerender using the new data.

## Implement a custom `AuthenticationStateProvider`

If the app requires a custom provider, implement <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and override `GetAuthenticationStateAsync`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthStateProvider : AuthenticationStateProvider
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

The `CustomAuthStateProvider` service is registered in `Program.cs` ***after*** the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

builder.Services.AddServerSideBlazor();

...

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
```

Using the `CustomAuthStateProvider` in the preceding example, all users are authenticated with the username `mrfibuli`.

## Additional resources

* [Quickstart: Add sign-in with Microsoft to an ASP.NET Core web app](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp)
* [Quickstart: Protect an ASP.NET Core web API with Microsoft identity platform](/azure/active-directory/develop/quickstart-v2-aspnet-core-web-api)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Blazor Server apps are configured for security in the same manner as ASP.NET Core apps. For more information, see the articles under <xref:security/index>. Topics under this overview apply specifically to Blazor Server.

## Blazor Server uses ASP.NET Core Identity

Blazor Server uses ASP.NET Core Identity and doesn't offer a separate authentication process within Blazor for authentication and authorization.

Fundamental challenges exist to implementing security independent of ASP.NET Core Identity for Blazor Server:

* ASP.NET Core Identity provides the UI layer using Razor Pages, which are designed to work in the context of a request-response model, contrary to Blazor, which works in a stateful model over a WebSocket connection.
* <xref:Microsoft.AspNetCore.Identity.SignInManager%601>, <xref:Microsoft.AspNetCore.Identity.UserManager%601>, and other Identity abstractions expect an available HTTP request and response to function properly.
* HTTP cookies and other implementations for authentication can't function over a WebSocket connection, which is a fundamental challenge to performing authentication in Blazor.
* Creating a new Identity implementation with a new authentication process is difficult to justify when we consider the reusability of ASP.NET Core Identity with all of the design and validation that it has received.

Use of a separate UI stack for part of an app and performing authentication outside of the Blazor portions of an app might be undesirable for some developers or for some app designs. However, the majority of SPA frameworks implement an authentication process where users are redirected to an external provider and returned to the app. In this regard, Blazor Server is similar to other SPA frameworks.

## Blazor Server project template

The [Blazor Server project template](xref:blazor/project-structure) can be configured for authentication when the project is created.

# [Visual Studio](#tab/visual-studio)

Follow the Visual Studio guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism.

After choosing the **Blazor Server App** template in the **Create a new ASP.NET Core Web Application** dialog, select **Change** under **Authentication**.

A dialog opens to offer the same set of authentication mechanisms available for other ASP.NET Core projects:

* **No Authentication**
* **Individual User Accounts**: User accounts can be stored:
  * Within the app using ASP.NET Core's [Identity](xref:security/authentication/identity) system.
  * With [Azure AD B2C](xref:security/authentication/azure-ad-b2c).
* **Work or School Accounts**
* **Windows Authentication**

# [Visual Studio Code](#tab/visual-studio-code)

Follow the Visual Studio Code guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism:

```dotnetcli
dotnet new blazorserver -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{APP NAME}` placeholder to:

* Create a folder for the project.
* Name the project.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Follow the Visual Studio for Mac guidance in <xref:blazor/tooling>.

1. On the **Configure your new Blazor Server App** step, select **Individual Authentication (in-app)** from the **Authentication** drop down.

1. The app is created for individual users stored in the app with ASP.NET Core Identity.

# [.NET Core CLI](#tab/netcore-cli/)

Create a new Blazor Server project with an authentication mechanism using the following command in a command shell:

```dotnetcli
dotnet new blazorserver -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{APP NAME}` placeholder to:

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

Scaffold Identity into a Blazor Server project:

* [Without existing authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project-without-existing-authorization).
* [With authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project-with-authorization).

## Additional claims and tokens from external providers

To store additional claims from external providers, see <xref:security/authentication/social/additional-claims>.

## Azure App Service on Linux with Identity Server

Specify the issuer explicitly when deploying to Azure App Service on Linux with Identity Server. For more information, see <xref:security/authentication/identity/spa#azure-app-service-on-linux>.

## Notification about authentication state changes

If the app determines that the underlying authentication state data has changed (for example, because the user signed out or another user has changed their roles), a [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider) can optionally invoke the method <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> on the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> base class. This notifies consumers of the authentication state data (for example, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView>) to rerender using the new data.

## Implement a custom `AuthenticationStateProvider`

If the app requires a custom provider, implement <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and override `GetAuthenticationStateAsync`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthStateProvider : AuthenticationStateProvider
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

The `CustomAuthStateProvider` service is registered in `Startup.ConfigureServices` ***after*** the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

services.AddServerSideBlazor();

...

services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
```

Using the `CustomAuthStateProvider` in the preceding example, all users are authenticated with the username `mrfibuli`.

## Additional resources

* [Quickstart: Add sign-in with Microsoft to an ASP.NET Core web app](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp)
* [Quickstart: Protect an ASP.NET Core web API with Microsoft identity platform](/azure/active-directory/develop/quickstart-v2-aspnet-core-web-api)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Blazor Server apps are configured for security in the same manner as ASP.NET Core apps. For more information, see the articles under <xref:security/index>. Topics under this overview apply specifically to Blazor Server.

## Blazor Server uses ASP.NET Core Identity

Blazor Server uses ASP.NET Core Identity and doesn't offer a separate authentication process within Blazor for authentication and authorization.

Fundamental challenges exist to implementing security independent of ASP.NET Core Identity for Blazor Server:

* ASP.NET Core Identity provides the UI layer using Razor Pages, which are designed to work in the context of a request-response model, contrary to Blazor, which works in a stateful model over a WebSocket connection.
* <xref:Microsoft.AspNetCore.Identity.SignInManager%601>, <xref:Microsoft.AspNetCore.Identity.UserManager%601>, and other Identity abstractions expect an available HTTP request and response to function properly.
* HTTP cookies and other implementations for authentication can't function over a WebSocket connection, which is a fundamental challenge to performing authentication in Blazor.
* Creating a new Identity implementation with a new authentication process is difficult to justify when we consider the reusability of ASP.NET Core Identity with all of the design and validation that it has received.

Use of a separate UI stack for part of an app and performing authentication outside of the Blazor portions of an app might be undesirable for some developers or for some app designs. However, the majority of SPA frameworks implement an authentication process where users are redirected to an external provider and returned to the app. In this regard, Blazor Server is similar to other SPA frameworks.

## Blazor Server project template

The [Blazor Server project template](xref:blazor/project-structure) can be configured for authentication when the project is created.

# [Visual Studio](#tab/visual-studio)

Follow the Visual Studio guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism.

After choosing the **Blazor Server App** template in the **Create a new ASP.NET Core Web Application** dialog, select **Change** under **Authentication**.

A dialog opens to offer the same set of authentication mechanisms available for other ASP.NET Core projects:

* **No Authentication**
* **Individual User Accounts**: User accounts can be stored:
  * Within the app using ASP.NET Core's [Identity](xref:security/authentication/identity) system.
  * With [Azure AD B2C](xref:security/authentication/azure-ad-b2c).
* **Work or School Accounts**
* **Windows Authentication**

# [Visual Studio Code](#tab/visual-studio-code)

Follow the Visual Studio Code guidance in <xref:blazor/tooling> to create a new Blazor Server project with an authentication mechanism:

```dotnetcli
dotnet new blazorserver -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{APP NAME}` placeholder to:

* Create a folder for the project.
* Name the project.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Follow the Visual Studio for Mac guidance in <xref:blazor/tooling>.

1. On the **Configure your new Blazor Server App** step, select **Individual Authentication (in-app)** from the **Authentication** drop down.

1. The app is created for individual users stored in the app with ASP.NET Core Identity.

# [.NET Core CLI](#tab/netcore-cli/)

Create a new Blazor Server project with an authentication mechanism using the following command in a command shell:

```dotnetcli
dotnet new blazorserver -o {APP NAME} -au {AUTHENTICATION}
```

Permissible authentication values (`{AUTHENTICATION}`) are shown in the following table.

| Authentication mechanism | Description |
| ------------------------ | ----------- |
| `None` (default)         | No authentication |
| `Individual`             | Users stored in the app with ASP.NET Core Identity |
| `IndividualB2C`          | Users stored in [Azure AD B2C](xref:security/authentication/azure-ad-b2c) |
| `SingleOrg`              | Organizational authentication for a single tenant |
| `MultiOrg`               | Organizational authentication for multiple tenants |
| `Windows`                | Windows Authentication |

Using the `-o|--output` option, the command uses the value provided for the `{APP NAME}` placeholder to:

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

Scaffold Identity into a Blazor Server project:

* [Without existing authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project-without-existing-authorization).
* [With authorization](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-server-project-with-authorization).

## Additional claims and tokens from external providers

To store additional claims from external providers, see <xref:security/authentication/social/additional-claims>.

## Azure App Service on Linux with Identity Server

Specify the issuer explicitly when deploying to Azure App Service on Linux with Identity Server. For more information, see <xref:security/authentication/identity/spa#azure-app-service-on-linux>.

## Notification about authentication state changes

If the app determines that the underlying authentication state data has changed (for example, because the user signed out or another user has changed their roles), a [custom `AuthenticationStateProvider`](#implement-a-custom-authenticationstateprovider) can optionally invoke the method <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> on the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> base class. This notifies consumers of the authentication state data (for example, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView>) to rerender using the new data.

## Implement a custom `AuthenticationStateProvider`

If the app requires a custom provider, implement <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and override `GetAuthenticationStateAsync`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthStateProvider : AuthenticationStateProvider
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

The `CustomAuthStateProvider` service is registered in `Startup.ConfigureServices` ***after*** the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;

...

services.AddServerSideBlazor();

...

services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
```

Using the `CustomAuthStateProvider` in the preceding example, all users are authenticated with the username `mrfibuli`.

## Additional resources

* [Quickstart: Add sign-in with Microsoft to an ASP.NET Core web app](/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp)
* [Quickstart: Protect an ASP.NET Core web API with Microsoft identity platform](/azure/active-directory/develop/quickstart-v2-aspnet-core-web-api)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.

:::moniker-end
