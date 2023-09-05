---
title: Secure a hosted ASP.NET Core Blazor WebAssembly app with Identity Server
author: guardrex
description: Learn how to secure a hosted ASP.NET Core Blazor WebAssembly app with Identity Server.
monikerRange: '>= aspnetcore-3.1 < aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 03/23/2023
uid: blazor/security/webassembly/hosted-with-identity-server
---
# Secure a hosted ASP.NET Core Blazor WebAssembly app with Identity Server

This article explains how to create a [hosted Blazor WebAssembly solution](xref:blazor/hosting-models#blazor-webassembly) that uses [Duende Identity Server](https://docs.duendesoftware.com) to authenticate users and API calls.

:::moniker range=">= aspnetcore-6.0"

> [!IMPORTANT]
> [Duende Software](https://duendesoftware.com/) might require you to pay a license fee for production use of Duende Identity Server. For more information, see <xref:migration/50-to-60#project-templates-use-duende-identity-server>.

:::moniker-end

> [!NOTE]
> To configure a standalone or hosted Blazor WebAssembly app to use an existing, external Identity Server instance, follow the guidance in <xref:blazor/security/webassembly/standalone-with-authentication-library>.

For additional security scenario coverage after reading this article, see <xref:blazor/security/webassembly/additional-scenarios>.

## Walkthrough

The subsections of the walkthrough explain how to:

* Create the Blazor app
* Run the app

### Create a Blazor app

# [Visual Studio](#tab/visual-studio)

To create a new Blazor WebAssembly project with an authentication mechanism:

1. Create a new project.

1. Choose the **Blazor WebAssembly App** template. Select **Next**.

1. Provide a **Project name** without using dashes. Confirm that the **Location** is correct. Select **Next**.

   Avoid using dashes (`-`) in the project name that break the formation of the OIDC app identifier. Logic in the Blazor WebAssembly project template uses the project name for an OIDC app identifier in the solution's configuration, and dashes aren't permitted in an OIDC app identifier. Pascal case (`BlazorSample`) or underscores (`Blazor_Sample`) are acceptable alternatives.

1. In the **Additional information** dialog, select **Individual Accounts** as the **Authentication type** to store users within the app using ASP.NET Core's [Identity](xref:security/authentication/identity) system.

1. Select the **ASP.NET Core Hosted** checkbox.

1. Select the **Create** button to create the app.

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

To create a new Blazor WebAssembly project with an authentication mechanism in an empty folder, specify the `Individual` authentication mechanism with the `-au|--auth` option to store users within the app using ASP.NET Core's [Identity](xref:security/authentication/identity) system:

```dotnetcli
dotnet new blazorwasm -au Individual -ho -o {PROJECT NAME}
```

| Placeholder      | Example        |
| ---------------- | -------------- |
| `{PROJECT NAME}` | `BlazorSample` |

The output location specified with the optional `-o|--output` option creates a project folder if it doesn't exist and becomes part of the project's name.

Avoid using dashes (`-`) in the project name that break the formation of the OIDC app identifier. Logic in the Blazor WebAssembly project template uses the project name for an OIDC app identifier in the solution's configuration, and dashes aren't permitted in an OIDC app identifier. Pascal case (`BlazorSample`) or underscores (`Blazor_Sample`) are acceptable alternatives.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

---

### Run the app

[!INCLUDE[](~/blazor/security/includes/run-the-app.md)]

## Parts of the solution

This section describes the parts of a solution generated from the Blazor WebAssembly project template and describes how the solution's **:::no-loc text="Client":::** and **:::no-loc text="Server":::** projects are configured for reference. There's no specific guidance to follow in this section for a basic working application if you created the app using the guidance in the [Walkthrough](#walkthrough) section. The guidance in this section is helpful for updating an app to authenticate and authorize users. However, an alternative approach to updating an app is to create a new app from the guidance in the [Walkthrough](#walkthrough) section and moving the app's components, classes, and resources to the new app.

### **:::no-loc text="Server":::** app services

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

The following services are registered.

:::moniker range=">= aspnetcore-6.0"

* In the `Program` file:

  * Entity Framework Core and ASP.NET Core Identity:

    ```csharp
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite( ... ));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
            options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    ```

  * Identity Server with an additional <xref:Microsoft.Extensions.DependencyInjection.IdentityServerBuilderConfigurationExtensions.AddApiAuthorization%2A> helper method that sets up default ASP.NET Core conventions on top of Identity Server:

    ```csharp
    builder.Services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
    ```

  * Authentication with an additional <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A> helper method that configures the app to validate JWT tokens produced by Identity Server:

    ```csharp
    builder.Services.AddAuthentication()
        .AddIdentityServerJwt();
    ```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* In `Startup.ConfigureServices` of `Startup.cs`:

  * Entity Framework Core and ASP.NET Core Identity:

    ```csharp
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(
            Configuration.GetConnectionString("DefaultConnection")));

    services.AddDefaultIdentity<ApplicationUser>(options => 
            options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    ```

  * Identity Server with an additional <xref:Microsoft.Extensions.DependencyInjection.IdentityServerBuilderConfigurationExtensions.AddApiAuthorization%2A> helper method that sets up default ASP.NET Core conventions on top of Identity Server:

    ```csharp
    services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
    ```

  * Authentication with an additional <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A> helper method that configures the app to validate JWT tokens produced by Identity Server:

    ```csharp
    services.AddAuthentication()
        .AddIdentityServerJwt();
    ```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

[!INCLUDE[](~/blazor/includes/default-scheme.md)]

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

* In the `Program` file:

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* In `Startup.Configure` of `Startup.cs`:

:::moniker-end

  * The Identity Server Middleware exposes the OpenID Connect (OIDC) endpoints:

    ```csharp
    app.UseIdentityServer();
    ```

:::moniker range="< aspnetcore-7.0"

  * The Authentication Middleware is responsible for validating request credentials and setting the user on the request context:

    ```csharp
    app.UseAuthentication();
    ```

:::moniker-end

  * Authorization Middleware enables authorization capabilities:

    ```csharp
    app.UseAuthorization();
    ```

### API authorization

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

The <xref:Microsoft.Extensions.DependencyInjection.IdentityServerBuilderConfigurationExtensions.AddApiAuthorization%2A> helper method configures [Identity Server](https://docs.duendesoftware.com) for ASP.NET Core scenarios. Identity Server is a powerful and extensible framework for handling app security concerns. Identity Server exposes unnecessary complexity for the most common scenarios. Consequently, a set of conventions and configuration options is provided that we consider a good starting point. Once your authentication needs change, the full power of Identity Server is available to customize authentication to suit an app's requirements.

### Add an authentication handler for an API that coexists with Identity Server

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

The <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A> helper method configures a policy scheme for the app as the default authentication handler. The policy is configured to allow Identity to handle all requests routed to any subpath in the Identity URL space under `/Identity`. The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler> handles all other requests. Additionally, this method:

* Registers an API resource with Identity Server with a default scope of `{PROJECT NAME}API`, where the `{PROJECT NAME}` placeholder is the project's name at app creation.
* Configures the JWT Bearer Token Middleware to validate tokens issued by Identity Server for the app.

### Weather forecast controller

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

In the `WeatherForecastController` (`Controllers/WeatherForecastController.cs`), the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) is applied to the class. The attribute indicates that the user must be authorized based on the default policy to access the resource. The default authorization policy is configured to use the default authentication scheme, which is set up by <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilderExtensions.AddIdentityServerJwt%2A>. The helper method configures <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler> as the default handler for requests to the app.

### Application database context

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

In the `ApplicationDbContext` (`Data/ApplicationDbContext.cs`), <xref:Microsoft.EntityFrameworkCore.DbContext> extends <xref:Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ApiAuthorizationDbContext%601> to include the schema for Identity Server. <xref:Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ApiAuthorizationDbContext%601> is derived from <xref:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext>.

To gain full control of the database schema, inherit from one of the available Identity <xref:Microsoft.EntityFrameworkCore.DbContext> classes and configure the context to include the Identity schema by calling `builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value)` in the <xref:Microsoft.EntityFrameworkCore.DbContext.OnModelCreating%2A> method.

### OIDC configuration controller

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

In the `OidcConfigurationController` (`Controllers/OidcConfigurationController.cs`), the client endpoint is provisioned to serve OIDC parameters.

### App settings

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

In the app settings file (`appsettings.json`) at the project root, the `IdentityServer` section describes the list of configured clients. In the following example, there's a single client. The client name corresponds to the **:::no-loc text="Client":::** app's assembly name and is mapped by convention to the OAuth `ClientId` parameter. The profile indicates the app type being configured. The profile is used internally to drive conventions that simplify the configuration process for the server.

```json
"IdentityServer": {
  "Clients": {
    "{ASSEMBLY NAME}": {
      "Profile": "IdentityServerSPA"
    }
  }
}
```

The placeholder `{ASSEMBLY NAME}` is the **:::no-loc text="Client":::** app's assembly name (for example, `BlazorSample.Client`).

### Authentication package

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

When an app is created to use Individual User Accounts (`Individual`), the app automatically receives a package reference for the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

### `HttpClient` configuration

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

In the `Program` file, a named <xref:System.Net.Http.HttpClient> is configured to supply <xref:System.Net.Http.HttpClient> instances that include access tokens when making requests to the server API. By default at solution creation, the named <xref:System.Net.Http.HttpClient> is `{PROJECT NAME}.ServerAPI`, where the `{PROJECT NAME}` placeholder is the project's name.

```csharp
builder.Services.AddHttpClient("{PROJECT NAME}.ServerAPI", 
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("{PROJECT NAME}.ServerAPI"));
```

The placeholder `{PROJECT NAME}` is the project name at solution creation. For example, providing a project name of `BlazorSample` produces a named <xref:System.Net.Http.HttpClient> of `BlazorSample.ServerAPI`.

> [!NOTE]
> If you're configuring a Blazor WebAssembly app to use an existing Identity Server instance that isn't part of a hosted Blazor solution, change the <xref:System.Net.Http.HttpClient> base address registration from <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType> (`builder.HostEnvironment.BaseAddress`) to the server app's API authorization endpoint URL.

### API authorization support

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

The support for authenticating users is plugged into the service container by the extension method provided inside the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. This method sets up the services required by the app to interact with the existing authorization system.

```csharp
builder.Services.AddApiAuthorization();
```

By default, configuration for the app is loaded by convention from `_configuration/{client-id}`. By convention, the client ID is set to the app's assembly name. This URL can be changed to point to a separate endpoint by calling the overload with options.

### `Imports` file

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/imports-file-hosted.md)]

### `Index` page

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/index-page-authentication.md)]

### `App` component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

### `RedirectToLogin` component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

### `LoginDisplay` component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/logindisplay-component.md)]

### `Authentication` component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

### `FetchData` component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/fetchdata-component.md)]

## Azure App Service on Linux

Specify the issuer explicitly when deploying to Azure App Service on Linux. For more information, see <xref:security/authentication/identity/spa#azure-app-service-on-linux>.

## Name and role claim with API authorization

### Custom user factory

In the **:::no-loc text="Client":::** app, create a custom user factory. Identity Server sends multiple roles as a JSON array in a single `role` claim. A single role is sent as a string value in the claim. The factory creates an individual `role` claim for each of the user's roles.

`CustomUserFactory.cs`:

:::moniker range=">= aspnetcore-6.0"

```csharp
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

public class CustomUserFactory
    : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    public CustomUserFactory(IAccessTokenProviderAccessor accessor)
        : base(accessor)
    {
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        RemoteUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var user = await base.CreateUserAsync(account, options);

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            var identity = (ClaimsIdentity)user.Identity;
            var roleClaims = identity.FindAll(identity.RoleClaimType).ToArray();

            if (roleClaims.Any())
            {
                foreach (var existingClaim in roleClaims)
                {
                    identity.RemoveClaim(existingClaim);
                }

                var rolesElem = 
                    account.AdditionalProperties[identity.RoleClaimType];

                if (options.RoleClaim is not null && rolesElem is JsonElement roles)
                {
                    if (roles.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var role in roles.EnumerateArray())
                        {
                            var roleValue = role.GetString();

                            if (!string.IsNullOrEmpty(roleValue))
                            {
                                identity.AddClaim(
                                  new Claim(options.RoleClaim, roleValue));
                            }
        
                        }
                    }
                    else
                    {
                        var roleValue = roles.GetString();

                        if (!string.IsNullOrEmpty(roleValue))
                        {
                            identity.AddClaim(
                              new Claim(options.RoleClaim, roleValue));
                        }
                    }
                }
            }
        }

        return user;
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

public class CustomUserFactory
    : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    public CustomUserFactory(IAccessTokenProviderAccessor accessor)
        : base(accessor)
    {
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        RemoteUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var user = await base.CreateUserAsync(account, options);

        if (user.Identity.IsAuthenticated)
        {
            var identity = (ClaimsIdentity)user.Identity;
            var roleClaims = identity.FindAll(identity.RoleClaimType).ToArray();

            if (roleClaims.Any())
            {
                foreach (var existingClaim in roleClaims)
                {
                    identity.RemoveClaim(existingClaim);
                }

                var rolesElem = account.AdditionalProperties[identity.RoleClaimType];

                if (rolesElem is JsonElement roles)
                {
                    if (roles.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var role in roles.EnumerateArray())
                        {
                            identity.AddClaim(new Claim(options.RoleClaim, role.GetString()));
                        }
                    }
                    else
                    {
                        identity.AddClaim(new Claim(options.RoleClaim, roles.GetString()));
                    }
                }
            }
        }

        return user;
    }
}
```

:::moniker-end

In the **:::no-loc text="Client":::** app, register the factory in the `Program` file:

```csharp
builder.Services.AddApiAuthorization()
    .AddAccountClaimsPrincipalFactory<CustomUserFactory>();
```

In the **:::no-loc text="Server":::** app, call <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> on the Identity builder, which adds role-related services.

:::moniker range=">= aspnetcore-6.0"

In the `Program` file:

```csharp
using Microsoft.AspNetCore.Identity;

...

builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.cs`:

```csharp
using Microsoft.AspNetCore.Identity;

...

services.AddDefaultIdentity<ApplicationUser>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

:::moniker-end

### Configure Identity Server

Use **one** of the following approaches:

* [API authorization options](#api-authorization-options)
* [Profile Service](#profile-service)

#### API authorization options

In the **:::no-loc text="Server":::** app:

* Configure Identity Server to put the `name` and `role` claims into the ID token and access token.
* Prevent the default mapping for roles in the JWT token handler.

:::moniker range=">= aspnetcore-6.0"

In the `Program` file:

```csharp
using System.IdentityModel.Tokens.Jwt;

...

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options => {
        options.IdentityResources["openid"].UserClaims.Add("name");
        options.ApiResources.Single().UserClaims.Add("name");
        options.IdentityResources["openid"].UserClaims.Add("role");
        options.ApiResources.Single().UserClaims.Add("role");
    });

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.cs`:

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

:::moniker-end

#### Profile Service

In the **:::no-loc text="Server":::** app, create a `ProfileService` implementation.

`ProfileService.cs`:

:::moniker range=">= aspnetcore-6.0"

```csharp
using IdentityModel;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

public class ProfileService : IProfileService
{
    public ProfileService()
    {
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var nameClaim = context.Subject.FindAll(JwtClaimTypes.Name);
        context.IssuedClaims.AddRange(nameClaim);

        var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
        context.IssuedClaims.AddRange(roleClaims);

        await Task.CompletedTask;
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        await Task.CompletedTask;
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using IdentityModel;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using System.Threading.Tasks;

public class ProfileService : IProfileService
{
    public ProfileService()
    {
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var nameClaim = context.Subject.FindAll(JwtClaimTypes.Name);
        context.IssuedClaims.AddRange(nameClaim);

        var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
        context.IssuedClaims.AddRange(roleClaims);

        await Task.CompletedTask;
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        await Task.CompletedTask;
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

In the **:::no-loc text="Server":::** app, register the Profile Service in the `Program` file:

```csharp
using Duende.IdentityServer.Services;

...

builder.Services.AddTransient<IProfileService, ProfileService>();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In the **:::no-loc text="Server":::** app, register the Profile Service in `Startup.ConfigureServices` of `Startup.cs`:

```csharp
using IdentityServer4.Services;

...

services.AddTransient<IProfileService, ProfileService>();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");
```

:::moniker-end

### Use authorization mechanisms

In the **:::no-loc text="Client":::** app, component authorization approaches are functional at this point. Any of the authorization mechanisms in components can use a role to authorize the user:

* [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component) (Example: `<AuthorizeView Roles="Admin">`)
* [`[Authorize]` attribute directive](xref:blazor/security/index#authorize-attribute) (<xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>) (Example: `@attribute [Authorize(Roles = "Admin")]`)
* [Procedural logic](xref:blazor/security/index#procedural-logic) (Example: `if (user.IsInRole("Admin")) { ... }`)

  Multiple role tests are supported:

  ```csharp
  if (user.IsInRole("Admin") && user.IsInRole("Developer"))
  {
      ...
  }
  ```

`User.Identity.Name` is populated in the **:::no-loc text="Client":::** app with the user's user name, which is usually their sign-in email address.

[!INCLUDE[](~/blazor/security/includes/usermanager-signinmanager.md)]

## Host in Azure App Service with a custom domain and certificate

The following guidance explains:

* How to deploy a hosted Blazor WebAssembly app with Identity Server to [Azure App Service](https://azure.microsoft.com/services/app-service/) with a custom domain.
* How to create and use a TLS certificate for HTTPS protocol communication with browsers. Although the guidance focuses on using the certificate with a custom domain, the guidance is equally applicable to using a default Azure Apps domain, for example `contoso.azurewebsites.net`.

For this hosting scenario, do **not** use the same certificate for [Identity Server's token signing key](https://docs.duendesoftware.com/identityserver/v5/fundamentals/keys/) and the site's HTTPS secure communication with browsers:

* Using different certificates for these two requirements is a good security practice because it isolates private keys for each purpose.
* TLS certificates for communication with browsers is managed independently without affecting Identity Server's token signing.
* When [Azure Key Vault](https://azure.microsoft.com/services/key-vault/) supplies a certificate to an App Service app for custom domain binding, Identity Server can't obtain the same certificate from Azure Key Vault for token signing. Although configuring Identity Server to use the same TLS certificate from a physical path is possible, placing security certificates into source control is a **poor practice and should be avoided in most scenarios**.

In the following guidance, a self-signed certificate is created in Azure Key Vault solely for Identity Server token signing. The Identity Server configuration uses the key vault certificate via the app's `CurrentUser` > `My` certificate store. Other certificates used for HTTPS traffic with custom domains are created and configured separately from the Identity Server signing certificate.

To configure an app, Azure App Service, and Azure Key Vault to host with a custom domain and HTTPS:

1. Create an [App Service plan](/azure/app-service/overview-hosting-plans) with an plan level of `Basic B1` or higher. App Service requires a `Basic B1` or higher service tier to use custom domains.
1. Create a PFX certificate for the site's secure browser communication (HTTPS protocol) with a common name of the site's fully qualified domain name (FQDN) that your organization controls (for example, `www.contoso.com`). Create the certificate with:
   * Key uses
     * Digital signature validation (`digitalSignature`)
     * Key encipherment (`keyEncipherment`)
   * Enhanced/extended key uses
     * Client Authentication (1.3.6.1.5.5.7.3.2)
     * Server Authentication (1.3.6.1.5.5.7.3.1)

   To create the certificate, use one of the following approaches or any other suitable tool or online service:

   * [Azure Key Vault](/azure/key-vault/certificates/quick-create-portal#add-a-certificate-to-key-vault)
   * [MakeCert on Windows](/windows/desktop/seccrypto/makecert)
   * [OpenSSL](https://www.openssl.org)

   Make note of the password, which is used later to import the certificate into Azure Key Vault.

   For more information on Azure Key Vault certificates, see [Azure Key Vault: Certificates](/azure/key-vault/certificates/).
1. Create a new Azure Key Vault or use an existing key vault in your Azure subscription.
1. In the key vault's **Certificates** area, import the PFX site certificate. Record the certificate's thumbprint, which is used in the app's configuration later.
1. In Azure Key Vault, generate a new self-signed certificate for Identity Server token signing. Give the certificate a **Certificate Name** and **Subject**. The **Subject** is specified as `CN={COMMON NAME}`, where the `{COMMON NAME}` placeholder is the certificate's common name. The common name can be any alphanumeric string. For example, `CN=IdentityServerSigning` is a valid certificate **Subject**. In **Issuance Policy** > **Advanced Policy Configuration**, use the default settings. Record the certificate's thumbprint, which is used in the app's configuration later.
1. Navigate to Azure App Service in the Azure portal and create a new App Service with the following configuration:
   * **Publish** set to `Code`.
   * **Runtime stack** set to the app's runtime.
   * For **Sku and size**, confirm that the App Service tier is `Basic B1` or higher.  App Service requires a `Basic B1` or higher service tier to use custom domains.
1. After Azure creates the App Service, open the app's **Configuration** and add a new application setting specifying the certificate thumbprints recorded earlier. The app setting key is `WEBSITE_LOAD_CERTIFICATES`. Separate the certificate thumbprints in the app setting value with a comma, as the following example shows:
   * Key: `WEBSITE_LOAD_CERTIFICATES`
   * Value: `57443A552A46DB...D55E28D412B943565,29F43A772CB6AF...1D04F0C67F85FB0B1`

   In the Azure portal, saving app settings is a two-step process: Save the `WEBSITE_LOAD_CERTIFICATES` key-value setting, then select the **Save** button at the top of the blade.
1. Select the app's **TLS/SSL settings**. Select **Private Key Certificates (.pfx)**. Use the **Import Key Vault Certificate** process. **Use the process _twice_ to import both the site's certificate for HTTPS communication and the site's self-signed Identity Server token signing certificate.**
1. Navigate to the **Custom domains** blade. At your domain registrar's website, use the **IP address** and **Custom Domain Verification ID** to configure the domain. A typical domain configuration includes:
   * An **A Record** with a **Host** of `@` and a value of the IP address from the Azure portal.
   * A **TXT Record** with a **Host** of `asuid` and the value of the verification ID generated by Azure and provided by the Azure portal.

   Make sure that you save the changes at your domain registrar's website correctly. Some registrar websites require a two-step process to save domain records: One or more records are saved individually followed by updating the domain's registration with a separate button.
1. Return to the **Custom domains** blade in the Azure portal. Select **Add custom domain**. Select the **A Record** option. Provide the domain and select **Validate**. If the domain records are correct and propagated across the Internet, the portal allows you to select the **Add custom domain** button.

   It can take a few days for domain registration changes to propagate across Internet domain name servers (DNS) after they're processed by your domain registrar. If domain records aren't updated within three business days, confirm the records are correctly set with the domain registrar and contact their customer support.
1. In the **Custom domains** blade, the **SSL STATE** for the domain is marked `Not Secure`. Select the **Add binding** link. Select the site HTTPS certificate from the key vault for the custom domain binding.
1. In Visual Studio, open the *Server* project's app settings file (`appsettings.json` or `appsettings.Production.json`). In the Identity Server configuration, add the following `Key` section. Specify the self-signed certificate **Subject** for the `Name` key. In the following example, the certificate's common name assigned in the key vault is `IdentityServerSigning`, which yields a **Subject** of `CN=IdentityServerSigning`:

   ```json
   "IdentityServer": {

     ...

     "Key": {
       "Type": "Store",
       "StoreName": "My",
       "StoreLocation": "CurrentUser",
       "Name": "CN=IdentityServerSigning"
     }
   },
   ```

1. In Visual Studio, create an Azure App Service [publish profile](xref:host-and-deploy/visual-studio-publish-profiles#publish-profiles) for the *Server* project. From the menu bar, select: **Build** > **Publish** > **New** > **Azure** > **Azure App Service** (Windows or Linux). When Visual Studio is connected to an Azure subscription, you can set the **View** of Azure resources by **Resource type**. Navigate within the **Web App** list to find the App Service for the app and select it. Select **Finish**.
1. When Visual Studio returns to the **Publish** window, the key vault and SQL Server database service dependencies are automatically detected.

   No configuration changes to the default settings are required for the key vault service.

   For testing purposes, an app's local [SQLite](https://www.sqlite.org/index.html) database, which is configured by default by the Blazor template, can be deployed with the app without additional configuration. Configuring a different database for Identity Server in production is beyond the scope of this article. For more information, see the database resources in the following documentation sets:

   * [App Service](/azure/app-service/)
   * [Duende Identity Server](https://docs.duendesoftware.com)

1. Select the **Edit** link under the deployment profile name at the top of the window. Change the destination URL to the site's custom domain URL (for example, `https://www.contoso.com`). Save the settings.
1. Publish the app. Visual Studio opens a browser window and requests the site at its custom domain.

The Azure documentation contains additional detail on using Azure services and custom domains with TLS binding in App Service, including information on using CNAME records instead of A records. For more information, see the following resources:

* [App Service documentation](/azure/app-service/)
* [Tutorial: Map an existing custom DNS name to Azure App Service](/azure/app-service/app-service-web-tutorial-custom-domain)
* [Secure a custom DNS name with a TLS/SSL binding in Azure App Service](/azure/app-service/configure-ssl-bindings)
* [Azure Key Vault](/azure/key-vault/)

We recommend using a new in-private or incognito browser window for each app test run after a change to the app, app configuration, or Azure services in the Azure portal. Lingering cookies from a previous test run can result in failed authentication or authorization when testing the site even when the site's configuration is correct. For more information on how to configure Visual Studio to open a new in-private or incognito browser window for each test run, see the [Cookies and site data](#cookies-and-site-data) section.

When App Service configuration is changed in the Azure portal, the updates generally take effect quickly but aren't instant. Sometimes, you must wait a short period for an App Service to restart in order for a configuration change to take effect.

If troubleshooting an Identity Server key-signing certificate loading problem, execute the following command in an Azure portal [Kudu](https://github.com/projectkudu/kudu/wiki/Accessing-the-kudu-service) PowerShell command shell. The command provides a list of certificates that the app can access from the `CurrentUser` > `My` certificate store. The output includes certificate subjects and thumbprints useful when debugging an app:

```powershell
Get-ChildItem -path Cert:\CurrentUser\My -Recurse | Format-List DnsNameList, Subject, Thumbprint, EnhancedKeyUsageList
```

## Troubleshoot

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* [Deployment to Azure App Service](xref:security/authentication/identity/spa#deploy-to-production)
* [Import a certificate from Key Vault (Azure documentation)](/azure/app-service/configure-ssl-certificate#import-a-certificate-from-key-vault)
* <xref:blazor/security/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.
* [Duende Identity Server](https://docs.duendesoftware.com)
