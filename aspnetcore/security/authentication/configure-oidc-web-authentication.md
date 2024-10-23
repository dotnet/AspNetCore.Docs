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

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Damien Bowden](https://github.com/damienbod)

TODO

This article covers the following areas:

* TODO

## What is an OpenID Connect confidential interactive client

![TOTO](~/security/authentication/configure-oidc-web-authentication/_static/TODO.png)

## Create an Open ID Connect Code Flow client using Razor Pages

The following section shows how to implement an OpenID connect client in an empty ASP.NET Core Razor page project. The same logic can be applied to any ASP.NET Core web project with only the UI integration being different.

### Add OpenID Connect support

Add the **Microsoft.AspNetCore.Authentication.OpenIdConnect** nuget packages to the ASP.NET Core project.

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
	"Authority": "https://localhost:44318",
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

## Using third party provider clients

## Backend for frontend (BFF) security architecture

## Advanced features, standards, extending the OIDC client

## Standards

[OpenID Connect 1.0](https://openid.net/specs/openid-connect-core-1_0-final.html)

[Proof Key for Code Exchange by OAuth Public Clients](https://datatracker.ietf.org/doc/html/rfc7636)

[The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749)

[OAuth 2.0 Pushed Authorization Requests (PAR) RFC 9126](https://datatracker.ietf.org/doc/html/rfc9126)