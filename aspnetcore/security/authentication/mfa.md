---
title: Multifactor authentication in ASP.NET Core
author: damienbod
description: Learn how to set up multifactor authentication (MFA) in an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 05/15/2026
uid: security/authentication/mfa

# customer intent: As an ASP.NET developer, I want to set up multifactor authentication in my ASP.NET Core app, so I can TBD.......
---
<!-- ms.sfi.ropc: t -->
# Multifactor authentication in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-9.0"

By [Damien Bowden](https://github.com/damienbod)

Multifactor authentication (MFA) is a process in which a user is requested during sign in for more forms of identification. The prompt might request the user to enter a code from a cellphone, use an FIDO2 key, or provide a fingerprint scan. When you require a second form of authentication, security is enhanced. The extra factor isn't easily obtained or duplicated by a cyberattacker.

This article provides an overview of multifactor authentication in ASP.NET Core and the recommended authentication flows with examples that show how to:

* Configure MFA for administration pages by using ASP.NET Core Identity,
* Send an MFA sign-in requirement to the OpenID Connect server.
* Force the ASP.NET Core OpenID Connect client to require MFA.

[View or download the sample code](https://github.com/damienbod/AspNetCoreHybridFlowWithApi) ([how to download](xref:fundamentals/index#how-to-download-a-sample)).

## MFA versus 2FA

MFA requires at least two or more types of proof for an identity. Proof types can be something you know, something you possess, or biometric validation for the user to authenticate.

Two-factor authentication (2FA) is like a subset of MFA. 2FA requires exactly two types of proof, whereas MFA can require two or _more_ factors to prove the identity.

2FA is supported by default when using ASP.NET Core Identity. To enable or disable 2FA for a specific user, set the <xref:Microsoft.AspNetCore.Identity.IdentityUser%601.TwoFactorEnabled%2A?displayProperty=nameWithType> property. The ASP.NET Core Identity Default UI includes pages for configuring 2FA.

### MFA TOTP (Time-based One-time Password Algorithm)

MFA with TOTP is supported by default when using ASP.NET Core Identity. This approach can be used together with any compliant authenticator app, including:

* Microsoft Authenticator
* Google Authenticator

For implementation details, see [Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes).

To disable support for MFA TOTP, configure authentication by using the <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentity%2A> method instead of the <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionUIExtensions.AddDefaultIdentity%2A> method. The `AddDefaultIdentity` method calls the <xref:Microsoft.AspNetCore.Identity.IdentityBuilderExtensions.AddDefaultTokenProviders%2A> method internally, which registers multiple token providers including one for MFA TOTP. To register only specific token providers, call the <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddTokenProvider%2A> method for each required provider. For more information on available token providers, see the ['AddDefaultTokenProviders' reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Identity/Core/src/IdentityBuilderExtensions.cs) in the `dotnet/aspnetcore` GitHub repository.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### MFA passkeys/FIDO2 or passwordless

The **passkeys/FIDO2** approach is currently:

* The most secure way to achieve MFA.
* MFA that protects against phishing attacks (also certificate authentication and Windows for business).

ASP.NET Core supports passkeys by using ASP.NET Core Identity. Passkeys/FIDO2 can be used for MFA or passwordless flows. For more information, see <xref:security/authentication/passkeys/index>.

Microsoft Entra ID provides support for passkeys/FIDO2 and passwordless flows. For more information, see [Authentication methods in Microsoft Entra ID - passkeys (FIDO2)](/entra/identity/authentication/concept-authentication-passkeys-fido2).

Other forms of passwordless MFA either don't or might not protect against phishing.

### MFA SMS

MFA with SMS increases security massively compared with password authentication (single factor). However, using SMS as a second factor is no longer recommended. Too many known attack vectors exist for this type of implementation.

For more information, see the [NIST Digital Identity Guidelines (Special Publication 800-63B)](https://pages.nist.gov/800-63-3/sp800-63b.html).

## Configure MFA for administration pages with ASP.NET Core Identity

You can force MFA on users to enable access to sensitive pages within an ASP.NET Core Identity app. This approach can be useful for apps where different levels of access exist for different identities. For example, users might be able to view the profile data by using a password sign-in process, but an administrator would be required to use MFA to access the administrative pages.

### Extend the sign-in process with an MFA claim

The example code configuration uses ASP.NET Core with Identity and Razor Pages. The `AddIdentity` method is used instead of `AddDefaultIdentity`, so an `IUserClaimsPrincipalFactory` implementation can be used to add claims to the identity after successful sign in.

[!INCLUDE [managed-identities](~/includes/managed-identities-conn-strings.md)]

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        Configuration.GetConnectionString("DefaultConnection")));
		
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
		options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
	
builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, 
    AdditionalUserClaimsPrincipalFactory>();
	
builder.Services.AddAuthorization(options =>
    options.AddPolicy("TwoFactorEnabled", x => x.RequireClaim("amr", "mfa")));
	
builder.Services.AddRazorPages();
```

The `AdditionalUserClaimsPrincipalFactory` class adds the `amr` claim (Authentication Methods References claim) to the user claims only after a successful sign in. The claim value is read from the database. The claim is added here because the user should only access the higher protected view if the identity is signed in with MFA. If the database view is read from the database directly instead of using the claim, it's possible to access the view without MFA directly after activating the MFA.

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityStandaloneMfa
{
    public class AdditionalUserClaimsPrincipalFactory : 
        UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        public AdditionalUserClaimsPrincipalFactory( 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, 
            IOptions<IdentityOptions> optionsAccessor) 
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        public async override Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            var claims = new List<Claim>();

            if (user.TwoFactorEnabled)
            {
                claims.Add(new Claim("amr", "mfa"));
            }
            else
            {
                claims.Add(new Claim("amr", "pwd"));
            }

            identity.AddClaims(claims);
            return principal;
        }
    }
}
```

Because the Identity service setup changed in the `Startup` class, the layouts of the Identity need to be updated:

* Scaffold the Identity pages into the app.
* Define the layout in the _Identity/Account/Manage/\_Layout.cshtml_ file.

   ```cshtml
   @{
      Layout = "/Pages/Shared/_Layout.cshtml";
   }
   ```

* Also, assign the layout for all the manage pages from the Identity pages:

   ```cshtml
   @{
      Layout = "_Layout.cshtml";
   }
   ```

### Validate the MFA requirement in the administration page

The administration Razor Page validates that the user is signed in via MFA. In the `OnGet` method, the identity is used to access the user claims. The `amr` claim is checked for the value `mfa`. If the identity is missing this claim or is `false`, the page redirects to the Enable MFA page. This action is possible because the user is already signed in, but without MFA.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityStandaloneMfa
{
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            var claimTwoFactorEnabled = 
                User.Claims.FirstOrDefault(t => t.Type == "amr");

            if (claimTwoFactorEnabled != null && 
                "mfa".Equals(claimTwoFactorEnabled.Value))
            {
                // You logged in with MFA, do the administrative stuff
            }
            else
            {
                return Redirect(
                    "/Identity/Account/Manage/TwoFactorAuthentication");
            }

            return Page();
        }
    }
}
```

### UI logic to toggle user sign-in information

An authorization policy was added at startup. The policy requires the `amr` claim with the value `mfa`:

```csharp
services.AddAuthorization(options =>
    options.AddPolicy("TwoFactorEnabled",
        x => x.RequireClaim("amr", "mfa")));
```

This policy can then be used in the `_Layout` view to show or hide the **Admin** menu with the warning:

```cshtml
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Identity
@inject SignInManager<IdentityUser> SignInManager
@inject UserManager<IdentityUser> UserManager
@inject IAuthorizationService AuthorizationService
```

If the identity is signed in via MFA, the **Admin** menu displays without the tooltip warning.

When the user is signed in without MFA, the **Admin (Not Enabled)** menu displays along with the tooltip that informs the user (explaining the warning).

```cshtml
@if (SignInManager.IsSignedIn(User))
{
    @if ((AuthorizationService.AuthorizeAsync(User, "TwoFactorEnabled")).Result.Succeeded)
    {
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-page="/Admin">Admin</a>
        </li>
    }
    else
    {
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-page="/Admin" 
               id="tooltip-demo"  
               data-toggle="tooltip" 
               data-placement="bottom" 
               title="MFA is NOT enabled. This is required for the Admin Page. If you have activated MFA, then logout, login again.">
                Admin (Not Enabled)
            </a>
        </li>
    }
}
```

If the user signs in without MFA, the **Admin** option shows the **(Not Enabled)** warning:

:::image type="content" source="~/security/authentication/mfa/_static/identitystandalonemfa_01.png" alt-text="Screenshot showing the user signed in without MFA authentication, and the 'Not Enabled' warning on the Admin option.":::

When the user selects the **Admin** option, they're redirected to a view where they can enable MFA:

:::image type="content" source="~/security/authentication/mfa/_static/identitystandalonemfa_02.png" alt-text="Screenshot showing the 'Manage your account' view where the user can enable MFA authentication as an administrator.":::

## Send MFA sign-in requirement to OpenID Connect server 

The `acr_values` parameter can be used to pass the `mfa` required value from the client to the server in an authentication request.

> [!NOTE]
> The `acr_values` parameter needs to be handled on the OpenID Connect server for this approach to work.

### OpenID Connect ASP.NET Core client

The ASP.NET Core Razor Pages OpenID Connect client app uses the `AddOpenIdConnect` method to sign into the OpenID Connect server. The `acr_values` parameter is set with the `mfa` value and sent with the authentication request. The `OpenIdConnectEvents` is used to add this value.

For recommended `acr_values` parameter values, see the [IETF Authentication Method Reference Values](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-amr-values-08) specification.

```csharp
build.Services.AddAuthentication(options =>
{
	options.DefaultScheme =
		CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme =
		OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
	options.SignInScheme =
		CookieAuthenticationDefaults.AuthenticationScheme;
	options.Authority = "<OpenID Connect server URL>";
	options.RequireHttpsMetadata = true;
	options.ClientId = "<OpenID Connect client ID>";
	options.ClientSecret = "<>";
	options.ResponseType = "code";
	options.UsePkce = true;	
	options.Scope.Add("profile");
	options.Scope.Add("offline_access");
	options.SaveTokens = true;
	options.AdditionalAuthorizationParameters.Add("acr_values", "mfa");
});
```

### Example: OpenID Connect Duende IdentityServer server

The following example demonstrates OpenID Connect Duende IdentityServer server with ASP.NET Core Identity. On the OpenID Connect server, which is implemented by using ASP.NET Core Identity with Razor Pages, a new page named `ErrorEnable2FA.cshtml` is created. 

The page view:

* Displays if the Identity comes from an app that requires MFA, but the user hasn't activated this in Identity.
* Informs the user and adds a link to activate this.

```cshtml
@{
    ViewData["Title"] = "ErrorEnable2FA";
}

<h1>The client application requires you to have MFA enabled. Enable this, try login again.</h1>

<br />

You can enable MFA to login here:

<br />

<a href="~/Identity/Account/Manage/TwoFactorAuthentication">Enable MFA</a>
```

In the `Login` method, the `IIdentityServerInteractionService` interface implementation `_interaction` is used to access the OpenID Connect request parameters. The `acr_values` parameter is accessed by using the `AcrValues` property. Because the client sent this with `mfa` set, this can then be checked.

If MFA is required, and the user in ASP.NET Core Identity is enabled with MFA, the sign-in process continues. When the user has no MFA enabled, the user is redirected to the custom view `ErrorEnable2FA.cshtml`. Then ASP.NET Core Identity signs the user in.

The Fido2Store is used to check if the user activated MFA by using a custom FIDO2 Token Provider.

```csharp
public async Task<IActionResult> OnPost()
{
	// check if we are in the context of an authorization request
	var context = await _interaction.GetAuthorizationContextAsync(Input.ReturnUrl);

	var requires2Fa = context?.AcrValues.Count(t => t.Contains("mfa")) >= 1;

	var user = await _userManager.FindByNameAsync(Input.Username);
	if (user != null && !user.TwoFactorEnabled && requires2Fa)
	{
		return RedirectToPage("/Home/ErrorEnable2FA/Index");
	}

	// code omitted for brevity

	if (ModelState.IsValid)
	{
		var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, Input.RememberLogin, lockoutOnFailure: true);
		if (result.Succeeded)
		{
			// code omitted for brevity
		}
		if (result.RequiresTwoFactor)
		{
			var fido2ItemExistsForUser = await _fido2Store.GetCredentialsByUserNameAsync(user.UserName);
			if (fido2ItemExistsForUser.Count > 0)
			{
				return RedirectToPage("/Account/LoginFido2Mfa", new { area = "Identity", Input.ReturnUrl, Input.RememberLogin });
			}

			return RedirectToPage("/Account/LoginWith2fa", new { area = "Identity", Input.ReturnUrl, RememberMe = Input.RememberLogin });
		}
		
		await _events.RaiseAsync(new UserLoginFailureEvent(Input.Username, "invalid credentials", clientId: context?.Client.ClientId));
		ModelState.AddModelError(string.Empty, LoginOptions.InvalidCredentialsErrorMessage);
	}

	// something went wrong, show form with error
	await BuildModelAsync(Input.ReturnUrl);
	return Page();
}
```

If the user is already signed in, the client app:

* Still validates the `amr` claim.
* Can set up the MFA with a link to the ASP.NET Core Identity view, such as **Enable MFA**:

   :::image type="content" source="~/security/authentication/mfa/_static/acr_values-1.png" alt-text="Screenshot showing the client requires sign in with multifactor authentication and the 'Enable MFA' option.":::

## Force ASP.NET Core OpenID Connect client to require MFA

This example shows how an ASP.NET Core Razor Page app, which uses OpenID Connect to sign in, can require users are authenticated by using MFA.

To validate the MFA requirement, an `IAuthorizationRequirement` requirement is created. The requirement is added to the pages by using a policy that requires MFA.

```csharp
using Microsoft.AspNetCore.Authorization;
 
namespace AspNetCoreRequireMfaOidc;

public class RequireMfa : IAuthorizationRequirement{}

```

An `AuthorizationHandler` is implemented to use the `amr` claim and check for the value `mfa`. The `amr` is returned in the `id_token` of a successful authentication and can have many different values, as defined in the [IETF Authentication Method Reference Values](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-amr-values-08) specification.

The returned value depends on how the identity authenticated and on the OpenID Connect server implementation.

The `AuthorizationHandler` uses the `RequireMfa` requirement and validates the `amr` claim. The OpenID Connect server can be implemented by using Duende Identity Server with ASP.NET Core Identity. When a user signs in by using TOTP, the `amr` claim is returned with an MFA value. If you use a different OpenID Connect server implementation or a different MFA type, the `amr` claim can have a different value. The code must be extended to accept the other possible values.

```csharp
public class RequireMfaHandler : AuthorizationHandler<RequireMfa>
{
	protected override Task HandleRequirementAsync(
		AuthorizationHandlerContext context, 
		RequireMfa requirement)
	{
		if (context == null)
			throw new ArgumentNullException(nameof(context));
		if (requirement == null)
			throw new ArgumentNullException(nameof(requirement));

		var amrClaim =
			context.User.Claims.FirstOrDefault(t => t.Type == "amr");

		if (amrClaim != null && amrClaim.Value == Amr.Mfa)
		{
			context.Succeed(requirement);
		}

		return Task.CompletedTask;
	}
}
```

In the program file, the `AddOpenIdConnect` method is used as the default challenge scheme. The authorization handler, which is used to check the `amr` claim, is added to the Inversion of Control container. A policy is then created which adds the `RequireMfa` requirement.

```csharp
builder.Services.ConfigureApplicationCookie(options =>
        options.Cookie.SecurePolicy =
            CookieSecurePolicy.Always);

builder.Services.AddSingleton<IAuthorizationHandler, RequireMfaHandler>();

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme =
		CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme =
		OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
	options.SignInScheme =
		CookieAuthenticationDefaults.AuthenticationScheme;
	options.Authority = "https://localhost:44352";
	options.RequireHttpsMetadata = true;
	options.ClientId = "AspNetCoreRequireMfaOidc";
	options.ClientSecret = "AspNetCoreRequireMfaOidcSecret";
	options.ResponseType = "code";
	options.UsePkce = true;	
	options.Scope.Add("profile");
	options.Scope.Add("offline_access");
	options.SaveTokens = true;
});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("RequireMfa", policyIsAdminRequirement =>
	{
		policyIsAdminRequirement.Requirements.Add(new RequireMfa());
	});
});

builder.Services.AddRazorPages();
```

The policy is then used in the Razor page as required. The policy can also be added globally for the entire app.

```csharp
[Authorize(Policy= "RequireMfa")]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
```

If the user authenticates without MFA, the `amr` claim probably has a `pwd` (password) value. As a result, the request isn't authorized to access the page. Using the default values, the user is redirected to the **Account** > **AccessDenied** page. This behavior can be changed or you can implement your own custom logic. In this example, a link is added so the valid user can set up MFA for their account.

```cshtml
@page
@model AspNetCoreRequireMfaOidc.AccessDeniedModel
@{
    ViewData["Title"] = "AccessDenied";
    Layout = "~/Pages/Shared/_Layout.cshtml";
}

<h1>AccessDenied</h1>

You require MFA to login here

<a href="https://localhost:44352/Manage/TwoFactorAuthentication">Enable MFA</a>
```

After this change, only users that authenticate with MFA can access the page or website. If different MFA types are used, or if 2FA is permitted, the `amr` claim has different values and needs to be processed correctly. Different OpenID Connect servers also return different values for this claim. These values might not follow the [IETF Authentication Method Reference Values](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-amr-values-08) specification.

When the user signs in without MFA (for example, by using only a password):

* The `amr` claim has the `pwd` password value:

  :::image type="content" source="~/security/authentication/mfa/_static/require_mfa_oidc_02.png" alt-text="Screenshot of source code and the Watch window where the 'amr' claim has the 'pwd' password value.":::

* Access is denied:

  :::image type="content" source="~/security/authentication/mfa/_static/require_mfa_oidc_03.png" alt-text="Screenshot showing access is denied when the user signs in without MFA.":::

Alternatively, when the user signs in by using OTP with Identity, the `amr` claim has the `mfa` value:

:::image type="content" source="~/security/authentication/mfa/_static/require_mfa_oidc_01.png" alt-text="Screenshot of source code and the Watch window where the 'amr' claim has the 'mfa' value.":::

### OIDC and OAuth parameter customization

The OAuth and OIDC authentication handlers <xref:Microsoft.AspNetCore.Authentication.OAuth.OAuthOptions.AdditionalAuthorizationParameters> option allows customization of authorization message parameters that are commonly included as part of the redirect query string:

:::code language="csharp" source="~/security/authentication/mfa/samples9/WebAddOpenIdConnect/Program.cs" id="snippet_1" :::

## Related content

* [Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)
* [Authentication methods in Microsoft Entra ID - passkeys (FIDO2)](/entra/identity/authentication/concept-authentication-passkeys-fido2)
* [FIDO2 .NET library for FIDO2 / WebAuthn attestation and assertion with .NET](https://github.com/passwordless-lib/fido2-net-lib) (GitHub)
* [WebAuthn and Passkeys Awesome](https://github.com/yackermann/awesome-webauthn) (GitHub)

:::moniker-end

[!INCLUDE[](~/security/authentication/mfa/includes/mfa-5-8.md)]
