---
title: Multi-factor authentication
author: damienbod
description: Multi-factor authentication
monikerRange: '>= aspnetcore-3.1'
ms.author: rick-anderson
ms.custom: mvc
ms.date: 02/25/2020
no-loc: [Identity]
uid: security/authentication/mfa
---
# Multi-factor authentication

By [Damien Bowden](https://github.com/damienbod)

Multi-factor authentication (MFA) is a process where a user is requested during a sign-in event for additional forms of identification. This prompt could be to enter a code on their cellphone, use a FIDO2 key or to provide a fingerprint scan. When you require a second form of authentication, security is increased as this additional factor isn't something that's easy for an attacker to obtain or duplicate.

This article covers the following:

* What is MFA and what MFA flows are recommended
* Configure MFA for administration pages using ASP.NET Core Identity
* Send MFA signin requirement to OpenID Connect server 
* Force ASP.NET Core OpenID Connect client to require MFA

## MFA, 2FA

MFA requires at least two or more types of proof for an identity like something you know, possess, or inherit for the user to authenticate.

Two-factor authentication (2FA) is like a subset of MFA, but the difference being that MFA can require 2 or more factors to prove the identity.

### MFA TOTP (Time-based One-time Password Algorithm)

MFA using TOTP is a supported implementation using ASP.NET Core Identity. This can be used together with the following apps:

- Microsoft Authenticator App
- Google Authenticator App

See the following link for implementation details:

[Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)

### MFA FIDO2 or Passwordless

FIDO2 is the most secure way of achieving MFA and is the only MFA flow which protects against phishing attacks. At present, ASP.NET Core doesn't support FIDO2 directly. FIDO2 can be used for MFA or passwordless flows.

Azure Active Directory provides support for FIDO2 and passwordless flows.

[Passwordless authentication options for Azure Active Directory](https://docs.microsoft.com/azure/active-directory/authentication/concept-authentication-passwordless)

You can implement ASP.NET Core with FIDO2 by using the following OSS FIDO2 implementation:

[FIDO2 .NET library for FIDO2 / WebAuthn Attestation and Assertion using .NET](https://github.com/abergs/fido2-net-lib)

### MFA SMS

Although MFA with SMS increases security massively compared with password authentication (Single factor), it is no longer recommended to use SMS as a second factor as too many known attack vectors exist for this type of implementation.

## Configure MFA for administration pages using ASP.NET Core Identity

MFA could be forced on users to access sensitive pages within an ASP.NET Core Identity application. This could be useful for applications where different levels of access exist for the different identities. For example, users might be able to view the profile data using a password login, but an administrator would be required to use MFA to access the admin pages.

### Extending the Login with a MFA claim

The demo code is setup using ASP.NET Core with Identity and Razor Pages. The AddIdentity method is used instead of AddDefaultIdentity one, so an IUserClaimsPrincipalFactory implementation can be used to add claims to the identity after a successful login.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.AddDbContext<ApplicationDbContext>(options =>
		options.UseSqlite(
			Configuration.GetConnectionString("DefaultConnection")));
	
	services.AddIdentity<IdentityUser, IdentityRole>(
		options => options.SignIn.RequireConfirmedAccount = false)
	 .AddEntityFrameworkStores<ApplicationDbContext>()
	 .AddDefaultTokenProviders();

	services.AddSingleton<IEmailSender, EmailSender>();
	services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, 
		AdditionalUserClaimsPrincipalFactory>();

	services.AddAuthorization(options =>
	{
		options.AddPolicy("TwoFactorEnabled",
			x => x.RequireClaim("TwoFactorEnabled", "true" )
		) ;
	});

	services.AddRazorPages();
}
```

The AdditionalUserClaimsPrincipalFactory adds the **TwoFactorEnabled** claim to the user claims after a successful login. This is only added after a login. The value is read from the database. This is added here because the user should only access the higher protected view, if the identity has logged in with MFA. If the database view was read from the database directly instead of using the claim, it would be possible to access the view without MFA directly after activating the MFA.

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityStandaloneMfa
{
    public class AdditionalUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
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
                claims.Add(new Claim("TwoFactorEnabled", "true"));
            }
            else
            {
                claims.Add(new Claim("TwoFactorEnabled", "false")); ;
            }

            identity.AddClaims(claims);
            return principal;
        }
    }
}
```

Because we changed the Identity service setup in the Startup class, the layouts of the Identity need to be updated. Scaffold the Identity pages into the application. Define the layout in the Identity/Account/Manage/_Layout.cshtml file.

```razor
@{
    Layout = "/Pages/Shared/_Layout.cshtml";
}
```

Also add the _layout for all the manage pages from the Identity Pages.

```razor
@{
    Layout = "_Layout.cshtml";
}
```

### Validation the MFA requirement in the Admin Page

The admin Razor Page validates that the user has logged in using MFA. In the OnGet method, the identity is used to access the user claims. The **TwoFactorEnabled** claim is checked for the value true. If the identity is missing this claim, or it is false, the page will redirect to the Enable MFA page. This is possible because the user has logged in already, but without MFA.

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
            var claimTwoFactorEnabled = User.Claims.FirstOrDefault(t => t.Type == "TwoFactorEnabled");

            if (claimTwoFactorEnabled != null && "true".Equals(claimTwoFactorEnabled.Value))
            {
                // You logged in with MFA, do the admin stuff
            }
            else
            {
                return Redirect("/Identity/Account/Manage/TwoFactorAuthentication");
            }

            return Page();
        }
    }
}
```

### UI logic to show hide information about the user login

An Authorization policy was added in the startup which requires the TwoFactorEnabled claim with the value true.

```csharp
services.AddAuthorization(options =>
{
	options.AddPolicy("TwoFactorEnabled",
		x => x.RequireClaim("TwoFactorEnabled", "true" )
	) ;
});
```

This policy can then be used in the _Layout view to show or hide the Admin menu with the warning.

```razor
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Identity
@inject SignInManager<IdentityUser> SignInManager
@inject UserManager<IdentityUser> UserManager
@inject IAuthorizationService AuthorizationService
```

If the identity has logged using MFA, then the Admin menu will be displayed without the warning. If the user has logged without the MFA, the font awesome icon will be displayed, and the tooltip which informs the user, explaining the warning.

```razor
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
				<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>
				Admin
			</a>

		</li>
	}
}
```

If the user logins without MFA , then the warning is displayed.

![Admin MFA authentication](mfa/_static/identitystandalonemfa_01.png)

When the user clicks the admin link, the user is redirected to the MFA enable view.

![Admin activate MFA authentication](mfa/_static/identitystandalonemfa_02.png)

## Send MFA signin requirement to OpenID Connect server 

The `acr_values` parameter can used to pass the mfa required value from the client to the server in an authentication request. 

> [!NOTE]
> The **acr_values** parameter needs to be handled on the Open ID Connect server for this to work.

### OpenID Connect ASP.NET Core client

The ASP.NET Core Razor Pages Open ID Connnect client app uses the `AddOpenIdConnect` method to login to the Open ID Connect server. The `acr_values` parameter is set with the `mfa` value and sent with the authentication request. The `OpenIdConnectEvents` is used to add this.

See [Authentication Method Reference Values](https://tools.ietf.org/html/draft-ietf-oauth-amr-values-08) for recommended acr_values values.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.AddAuthentication(options =>
	{
		options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
	})
	.AddCookie()
	.AddOpenIdConnect(options =>
	{
		options.SignInScheme = "Cookies";
		options.Authority = "<OpenID Connect server URL>";
		options.RequireHttpsMetadata = true;
		options.ClientId = "<OpenID Connect client ID>";
		options.ClientSecret = "<>";
		options.ResponseType = "code id_token"; // Code with PKCE can also be used here
		options.Scope.Add("profile");
		options.Scope.Add("offline_access");
		options.SaveTokens = true;
		options.Events = new OpenIdConnectEvents
		{
			OnRedirectToIdentityProvider = context =>
			{
				context.ProtocolMessage.SetParameter("acr_values", "mfa");

				return Task.FromResult(0);
			}
		};
	});

```

### Example OpenID Connect IdentityServer 4 server with ASP.NET Core Identity

On the OpenID Connect server, which is implemented using ASP.NET Core Identity with MVC views, a new view *ErrorEnable2FA.cshtml* is created and added.

This view will be displayed if the Identity comes from an application which requires MFA but the user has not activated this in Identity. The view informs the user, and adds a link to activate this.

```razor
@{
    ViewData["Title"] = "ErrorEnable2FA";
}

<h1>The client application requires you to have MFA enabled. Enable this, try login again.</h1>

<br />

You can enable MFA to login here:

<br />

<a asp-controller="Manage" asp-action="TwoFactorAuthentication">Enable MFA</a>
```

In the `Login` method, the `IIdentityServerInteractionService` interface implementation _interaction is used to access the Open ID Connnect request parameters. The `acr_values` is accessed using the AcrValues. As the client sent this with **mfa** set, this can then be checked.

If MFA is required, and the user in ASP.NET Core Identity has MFA enabled, then the login continues. If the user has no MFA enabled, the user is redirected to the custom view ErrorEnable2FA.cshtml. Then ASP.NET Core Identity signs the user in.

```csharp
//
// POST: /Account/Login
[HttpPost]
[AllowAnonymous]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Login(LoginInputModel model)
{
	var returnUrl = model.ReturnUrl;
	var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
	var requires2Fa = context?.AcrValues.Count(t => t.Contains("mfa")) >= 1;

	var user = await _userManager.FindByNameAsync(model.Email);
	if(user != null && !user.TwoFactorEnabled && requires2Fa)
	{
		return RedirectToAction(nameof(ErrorEnable2FA));
	}
```

The ExternalLoginCallback works like the local Identity login. The AcrValues property is checked for the "mfa" value and if it is sent, the MFA is forced before the login completes, ie redirected to the ErrorEnable2FA view.

```csharp
//
// GET: /Account/ExternalLoginCallback
[HttpGet]
[AllowAnonymous]
public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
{
	var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
	var requires2Fa = context?.AcrValues.Count(t => t.Contains("mfa")) >= 1;

	if (remoteError != null)
	{
		ModelState.AddModelError(string.Empty, _sharedLocalizer["EXTERNAL_PROVIDER_ERROR", remoteError]);
		return View(nameof(Login));
	}
	var info = await _signInManager.GetExternalLoginInfoAsync();

	if (info == null)
	{
		return RedirectToAction(nameof(Login));
	}

	var email = info.Principal.FindFirstValue(ClaimTypes.Email);

	if (!string.IsNullOrEmpty(email))
	{
		var user = await _userManager.FindByNameAsync(email);
		if (user != null && !user.TwoFactorEnabled && requires2Fa)
		{
			return RedirectToAction(nameof(ErrorEnable2FA));
		}
	}

	// Sign in the user with this external login provider if the user already has a login.
	var result = await _signInManager
		.ExternalLoginSignInAsync(
			info.LoginProvider, 
			info.ProviderKey, 
			isPersistent: 
			false);
```

If the user is already logged in, the client application still validates the "amr" claim, and can setup the MFA then with a link to the ASP.NET Core Identity view.

![acr_values-1](mfa/_static/acr_values-1.png)

## Force ASP.NET Core OpenID Connect client to require MFA

In this example it is shown how an ASP.NET Core Razor Page application which uses OpenID Connect to sign in, can require that users have authenticated using Multi-factor authentication. 

To validate the MFA requirement, an IAuthorizationRequirement requirement is created. This will be added to the pages using a policy which require MFA.

```csharp
using Microsoft.AspNetCore.Authorization;
 
namespace AspNetCoreRequireMfaOidc
{
    public class RequireMfa : IAuthorizationRequirement{}
}
```

An AuthorizationHandler is implemented which will use the **amr** claim and check for the value **mfa**. The amr is returned in the id_token of a successful authentication and can have many different values as defined in the following specification:

[Authentication Method Reference Values](https://tools.ietf.org/html/draft-ietf-oauth-amr-values-08) 

The returned value depends on how the identity authenticated and on the Open ID Connect server implementation.

The AuthorizationHandler uses the RequireMfa requirement and validates the **amr** claim. The OpenID Connect server can be implemented using IdentityServer4 with ASP.NET Core Identity. When a user logs in using TOTP, the amr claim is returned with a mfa value. If using a different OpenID Connect server implementation, or a different MFA type, then the amr claim will, or can have a different value, and the code would need to be extended to accept this as well.

```csharp
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreRequireMfaOidc
{
    public class RequireMfaHandler : AuthorizationHandler<RequireMfa>
    {

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            RequireMfa requirement
        ){
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (requirement == null)
                throw new ArgumentNullException(nameof(requirement));

            var amrClaim = context.User.Claims.FirstOrDefault(t => t.Type == "amr");

            if (amrClaim != null && amrClaim.Value == Amr.Mfa)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
```

In the ConfigureServices method in the Startup class, the AddOpenIdConnect method is used as the default challenge scheme. The authorization handler which is used to check the amr claim is added as to the IoC. A policy is created then which adds the RequireMfa requirement. 

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.ConfigureApplicationCookie(options =>
	{
		options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
	});

	services.AddSingleton<IAuthorizationHandler, RequireMfaHandler>();

	services.AddAuthentication(options =>
	{
		options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
	})
	.AddCookie()
	.AddOpenIdConnect(options =>
	{
		options.SignInScheme = "Cookies";
		options.Authority = "https://localhost:44352";
		options.RequireHttpsMetadata = true;
		options.ClientId = "AspNetCoreRequireMfaOidc";
		options.ClientSecret = "AspNetCoreRequireMfaOidcSecret";
		options.ResponseType = "code id_token";
		options.Scope.Add("profile");
		options.Scope.Add("offline_access");
		options.SaveTokens = true;
	});

	services.AddAuthorization(options =>
	{
		options.AddPolicy("RequireMfa", policyIsAdminRequirement =>
		{
			policyIsAdminRequirement.Requirements.Add(new RequireMfa());
		});
	});

	services.AddRazorPages();
}
```

This policy is then used in the Razor pages as required. This could be added globally for the whole application as well.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspNetCoreRequireMfaOidc.Pages
{
    [Authorize(Policy= "RequireMfa")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
```

If the user authenticates without MFA, then the amr claim will probably have a <strong>pwd</strong> value, and the request will not be authorized to access the page. Using the default values, the user will be redirected to the account/AccessDenied page. This can be changed, or you can implement your own custom logic here. In this example, a link is added, so that the valid user can setup MFA for his or her account.

```razor
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

Now only users that do MFA authenticatation can access the page, or website. If different MFA types are used, or 2FA is ok, then the amr claim will have different values, and need to be processed correctly. Different Open ID Connect servers will also return different values for this claim, and might not follow the Authentication Method Reference Values specification. 

If we login without MFA, ie just using a password, the amr has the pwd value:

![require_mfa_oidc_02.png](mfa/_static/require_mfa_oidc_02.png)

And access is denied:

![require_mfa_oidc_03.png](mfa/_static/require_mfa_oidc_03.png)

Or if we login using OTP with Identity:

![require_mfa_oidc_01.png](mfa/_static/require_mfa_oidc_01.png)

## Additional resources

* [Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)

* [Passwordless authentication options for Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-authentication-passwordless)

* [FIDO2 .NET library for FIDO2 / WebAuthn Attestation and Assertion using .NET](https://github.com/abergs/fido2-net-lib)

* [WebAuthn Awesome](https://github.com/herrjemand/awesome-webauthn)



