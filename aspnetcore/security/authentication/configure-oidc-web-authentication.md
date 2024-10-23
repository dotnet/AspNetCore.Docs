---
title: Configure OpenID Connect Web (UI) authentication in ASP.NET Core
author: damienbod
description: Learn how to set up OpenID Connect authentication in an ASP.NET Core app.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/02/2024
uid: security/authentication/configure-oidc-web-authentication
---
# Configure OpenID Connect Web (UI) authentication in ASP.NET Core

By [Damien Bowden](https://github.com/damienbod)

[View or download sample code](~/security/authentication/configure-oidc-web-authentication/sample/oidc-net8)

This article covers the following areas:

* What is an OpenID Connect confidential interactive client
* Create an OpenID Connect client in ASP.NET Core
* Examples of OpenID Connect client with code snippets
* Using third party OpenID Connect provider clients
* Backend for frontend (BFF) security architecture
* Advanced features, standards, extending the an OpenID Connect client

## What is an OpenID Connect confidential interactive client

[OpenID Connect](https://openid.net/developers/how-connect-works/) can be used to implement authentication in ASP.NET Core applications. The recommended way is to use an OpenID Connect confidential client using the code flow. The [Proof Key for Code Exchange by OAuth Public Clients (PKCE)](https://datatracker.ietf.org/doc/html/rfc7636) is required for this implement.

Public clients are no longer recommended for web applications.

The default flow works as shown in the following diagram:

![OIDC code flow confidential client using PKCE](~/security/authentication/configure-oidc-web-authentication/_static/oidc-confidential-pkce-flow-drawio.png)

OpenID Connect comes in many variations and all server implementations have slightly different parameters and requirements. Some servers don’t’ support the user info endpoint, some still don’t support PKCE and others require special parameters in the token request. Client assertions can be used instead of client secrets. New standards also exist which add extra security on top of the OpenID Connect Core, for example FAPI, CIBA or DPoP for downstream APIs.

> [!NOTE]
> From .NET 9, [OAuth 2.0 Pushed Authorization Requests (PAR) RFC 9126](https://datatracker.ietf.org/doc/html/rfc9126) is used per default if the OpenID Connect server supports this. This is a three step flow and not a two step flow as shown above. (User Info request is an optional step.)

## Create an Open ID Connect Code Flow client using Razor Pages

The following section shows how to implement an OpenID connect client in an empty ASP.NET Core Razor page project. The same logic can be applied to any ASP.NET Core web project with only the UI integration being different.

### Add OpenID Connect support

Add the [Microsoft.AspNetCore.Authentication.OpenIdConnect](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.OpenIdConnect) Nuget packages to the ASP.NET Core project.

### Setup the OpenID Connect client

Configure the Startup authentication in the project using the builder.Services. The configuration is dependent on the OpenID Connect server. Each OpenID Connect server requires small differences in the setup.

```csharp
builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
	configuration.GetSection("OpenIDConnectSettings").Bind(options);
	
	options.Authority = configuration["OpenIDConnectSettings:Authority"];
	options.ClientId = configuration["OpenIDConnectSettings:ClientId"];
	options.ClientSecret = configuration["OpenIDConnectSettings:ClientSecret"];

	options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.ResponseType = OpenIdConnectResponseType.Code;

	options.SaveTokens = true;
	options.GetClaimsFromUserInfoEndpoint = true;
	options.TokenValidationParameters = new TokenValidationParameters
	{
		NameClaimType = "name"
	};
});
```

See [Secure an ASP.NET Core Blazor Web App with OpenID Connect (OIDC)](xref:core/blazor/security/blazor-web-app-with-oidc) for details on the different OpenID Connect options.
^
> [!NOTE]
> The following namespaces are required:

```csharp
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
```

### Setup the configuration properties

Add the OpenID Connect client settings to the application configuration properties. The settings must match the client configuration in the OpenID Connect server. No secrets are persisted in the application settings, the secrets are stored in a Key Vault in production environments or in user secrets in a development environment.

```json
"OpenIDConnectSettings": {
    // OpenID Connect URL
	"Authority": "https://localhost:44318",
	// client ID from the OpenID Connect server
	"ClientId": "oidc-pkce-confidential",
	//"ClientSecret": "--stored-in-user-secrets-or-key-vault--"
},
```

### Update the ASP.NET Core pipeline method in the program class.

The UseRouting must be implemented before the UseAuthorization method.

```csharp
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
```

### Force authorization

Add the Authorize attribute to the protected razor pages, for example the Index.cshtml.cs file

```csharp
[Authorize]
```

A better way would be to force the whole application to be authorized and opt out for unsecure pages

```csharp
builder.services.AddRazorPages().AddMvcOptions(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});
```

### Add a new Logout.cshtml and SignedOut.cshtml Razor page in the project

Implement a default sign out page and change the Logout razor page code with this:

```csharp
[Authorize]
public class LogoutModel : PageModel
{
    public IActionResult OnGetAsync()
    {
        return SignOut(new AuthenticationProperties
        {
            RedirectUri = "/SignedOut"
        },
        CookieAuthenticationDefaults.AuthenticationScheme,
        OpenIdConnectDefaults.AuthenticationScheme);
    }
}
```

The `SignedOut.cshtml` requires the AllowAnonymous attribute.

```csharp
[AllowAnonymous]
public class SignedOutModel : PageModel
{
    public void OnGet()
    {
    }
}
```

### Add a login, logout button for the user.

```
@if (Context.User.Identity!.IsAuthenticated)
{
	<li class="nav-item">
		<a class="nav-link text-dark" asp-area="" asp-page="/Logout">Logout</a>
	</li>

	<span class="nav-link text-dark">Hi @Context.User.Identity.Name</span>
}
else
{
	<li class="nav-item">
		<a class="nav-link text-dark" asp-area="" asp-page="/Index">Login</a>
	</li>
}
```

## Examples with code snippets

### Example Keycloak

```csharp
```

https://github.com/damienbod/keycloak-backchannel/tree/main/RazorPagePar

### Example Duende

```csharp
```

### Implementing Microsoft identity providers

## Using third party OpenID Connect provider clients

## Backend for frontend (BFF) security architecture

[draft OAuth 2.0 for Browser-Based Applications](https://datatracker.ietf.org/doc/draft-ietf-oauth-browser-based-apps/)

## Advanced features, standards, extending the OIDC client

:::moniker range="> aspnetcore-8.0"

:::moniker-end

### Logging

```csharp
//using ...

using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

//... code 

var app = builder.Build();

IdentityModelEventSource.ShowPII = true;

//... code 

app.Run();
```

### Customizations

## Map claims from OpenID Connect

Refer to the following document:

[Mapping, customizing, and transforming claims in ASP.NET Core](xref:security/authentication/claims)

## Standards

[OpenID Connect 1.0](https://openid.net/specs/openid-connect-core-1_0-final.html)

[Proof Key for Code Exchange by OAuth Public Clients](https://datatracker.ietf.org/doc/html/rfc7636)

[The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749)

[OAuth 2.0 Pushed Authorization Requests (PAR) RFC 9126](https://datatracker.ietf.org/doc/html/rfc9126)