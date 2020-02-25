---
title: Multi-factor authentication
author: damienbod
description: Multi-factor authentication
monikerRange: '>= aspnetcore-3.1'
ms.author: todo
ms.custom: mvc
ms.date: 02/25/2020
no-loc: [Identity]
uid: security/authentication/mfa
---
# Multi-factor authentication

By [Damien Bowden](https://github.com/damienbod)

Multi-factor authentication (MFA) is a process where a user is prompted during a sign-in event for additional forms of identification. This prompt could be to enter a code on their cellphone, use a FIDO2 key or to provide a fingerprint scan. When you require a second form of authentication, security is increased as this additional factor isn't something that's easy for an attacker to obtain or duplicate.

This article covers the following:

* What MFA is and what MFA flows are recommended
* Configure MFA for Admin Pages in an ASP.NET Core Identity application
* Send MFA signin requirement to OpenID Connect server 
* Force ASP.NET Core OpenID Connect client to require MFA

## MFA TOTP (Time-based One-time Password Algorithm)

Multi-factor authentication using TOTP is a supported implementation using ASP.NET Core Identity. This can be used together with the following Apps:

- Microsoft Authenticator App
- Google Authenticator App

See the following link for implementation details:

[Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)

## MFA FIDO2 or Passwordless

FIDO2 is the most secure way of doing Multi-factor authentication and is the only MFA flow which protects against phishing attacks. At present ASP.NET Core does not support FIDO2 support. FIDO2 can be used for MFA or passwordless flows.

Azure Active Directory provides support for FIDO2 and passwordless flows.

[Passwordless authentication options for Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-authentication-passwordless)

You can implement ASP.NET Core with FIDO2 by using the following OSS FIDO2 implementation:

[FIDO2 .NET library for FIDO2 / WebAuthn Attestation and Assertion using .NET](https://github.com/abergs/fido2-net-lib)

## MFA SMS

Although MFA with SMS increases security massively compared with just a password authentication, it is no longer recommended to use SMS as a second factor as too many known attack vectors exist for this type of implementation.

## Configure MFA for administration pages in an ASP.NET Core Identity application

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

And when the user clicks the admin link, then the user is redirected to the MFA enable view.

![Admin activate MFA authentication](mfa/_static/identitystandalonemfa_02.png)

## Send MFA signin requirement to OpenID Connect server 

## Force ASP.NET Core OpenID Connect client to require MFA

## Additional resources

* [Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)

* [Passwordless authentication options for Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-authentication-passwordless)

* [FIDO2 .NET library for FIDO2 / WebAuthn Attestation and Assertion using .NET](https://github.com/abergs/fido2-net-lib)

* [WebAuthn Awesome](https://github.com/herrjemand/awesome-webauthn)



