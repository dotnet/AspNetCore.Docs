---
title: Configure ASP.NET Core Identity
author: AdrienTorris
description: Understand ASP.NET Core Identity default values and learn how to configure Identity properties to use custom values.
ms.author: scaddie
ms.date: 03/06/2018
uid: security/authentication/identity-configuration
---

# Configure ASP.NET Core Identity

ASP.NET Core Identity uses default configuration for settings such as password policy, lockout time, and cookie settings. These settings can be overridden in the app's `Startup` class.

## Identity options

The [IdentityOptions](/dotnet/api/microsoft.aspnetcore.identity.identityoptions) class represents the options that can be used to configure the Identity system.

### Claims Identity

[IdentityOptions.ClaimsIdentity](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.claimsidentity) specifies the [ClaimsIdentityOptions](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [RoleClaimType](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions.roleclaimtype) | Gets or sets the claim type used for a role claim. | [ClaimTypes.Role](/dotnet/api/system.security.claims.claimtypes.role) |
| [SecurityStampClaimType](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions.securitystampclaimtype) | Gets or sets the claim type used for the security stamp claim. | `AspNet.Identity.SecurityStamp` |
| [UserIdClaimType](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions.useridclaimtype) | Gets or sets the claim type used for the user identifier claim. | [ClaimTypes.NameIdentifier](/dotnet/api/system.security.claims.claimtypes.nameidentifier) |
| [UserNameClaimType](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions.usernameclaimtype) | Gets or sets the claim type used for the user name claim. | [ClaimTypes.Name](/dotnet/api/system.security.claims.claimtypes.name) |

### Lockout

Locks out the user for a period of time after a given number of failed access attempts (default: 5 minute lockout after 5 failed access attempts). A successful authentication resets the failed access attempts count and resets the clock.

The following example shows the default values:

[!code-csharp[](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,39-42,50-52)]

Confirm that [PasswordSignInAsync](/dotnet/api/microsoft.aspnetcore.identity.signinmanager-1.passwordsigninasync) sets `lockoutOnFailure` to `true`:

```csharp
var result = await _signInManager.PasswordSignInAsync(
                 Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
```

[IdentityOptions.Lockout](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.lockout) specifies the [LockoutOptions](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [AllowedForNewUsers](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions.allowedfornewusers) | Determines if a new user can be locked out. | `true` |
| [DefaultLockoutTimeSpan](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions.defaultlockouttimespan) | The amount of time a user is locked out when a lockout occurs. | 5 minutes |
| [MaxFailedAccessAttempts](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions.maxfailedaccessattempts) | The number of failed access attempts until a user is locked out, if lockout is enabled. | 5 |

### Password

By default, Identity requires that passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least six characters long. [PasswordOptions](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions) can be changed in `Startup.ConfigureServices`.

# [ASP.NET Core 2.x](#tab/aspnetcore2x/)

ASP.NET Core 2.0 added the [RequiredUniqueChars](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requireduniquechars) property. Otherwise, the options are the same as ASP.NET Core 1.x.

[!code-csharp[](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-37,50-52)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x/)

[!code-csharp[](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Startup.cs?range=58-65,84)]

---

[IdentityOptions.Password](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.password) specifies the [PasswordOptions](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [RequireDigit](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requiredigit) | Requires a number between 0-9 in the password. | `true` |
| [RequiredLength](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requiredlength) | The minimum length of the password. | 6 |
| [RequiredUniqueChars](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requireduniquechars) | Only applies to ASP.NET Core 2.0 or later.<br><br> Requires the number of distinct characters in the password. | 1 |
| [RequireLowercase](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requirelowercase) | Requires a lowercase character in the password. | `true` |
| [RequireNonAlphanumeric](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requirenonalphanumeric) | Requires a non-alphanumeric character in the password. | `true` |
| [RequireUppercase](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requireuppercase) | Requires an uppercase character in the password. | `true` |

### Sign-in

[!code-csharp[](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,44-46,50-52)]

[IdentityOptions.SignIn](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.signin) specifies the [SignInOptions](/dotnet/api/microsoft.aspnetcore.identity.signinoptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [RequireConfirmedEmail](/dotnet/api/microsoft.aspnetcore.identity.signinoptions.requireconfirmedemail) | Requires a confirmed email to sign in. | `false` |
| [RequireConfirmedPhoneNumber](/dotnet/api/microsoft.aspnetcore.identity.signinoptions.requireconfirmedphonenumber) | Requires a confirmed phone number to sign in. | `false` |

### Tokens

[IdentityOptions.Tokens](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.tokens) specifies the [TokenOptions](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions) with the properties shown in the table.


|                                                        Property                                                         |                                                                                      Description                                                                                      |
|-------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|     [AuthenticatorTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.authenticatortokenprovider)     |                                       Gets or sets the `AuthenticatorTokenProvider` used to validate two-factor sign-ins with an authenticator.                                       |
|       [ChangeEmailTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.changeemailtokenprovider)       |                                     Gets or sets the `ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails.                                     |
| [ChangePhoneNumberTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.changephonenumbertokenprovider) |                                      Gets or sets the `ChangePhoneNumberTokenProvider` used to generate tokens used when changing phone numbers.                                      |
| [EmailConfirmationTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.emailconfirmationtokenprovider) |                                             Gets or sets the token provider used to generate tokens used in account confirmation emails.                                              |
|     [PasswordResetTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.passwordresettokenprovider)     | Gets or sets the [IUserTwoFactorTokenProvider<TUser>](/dotnet/api/microsoft.aspnetcore.identity.iusertwofactortokenprovider-1) used to generate tokens used in password reset emails. |
|                    [ProviderMap](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.providermap)                    |                Used to construct a [User Token Provider](/dotnet/api/microsoft.aspnetcore.identity.tokenproviderdescriptor) with the key used as the provider's name.                 |

### User

[!code-csharp[](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,48-52)]

[IdentityOptions.User](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.user) specifies the [UserOptions](/dotnet/api/microsoft.aspnetcore.identity.useroptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [AllowedUserNameCharacters](/dotnet/api/microsoft.aspnetcore.identity.useroptions.allowedusernamecharacters) | Allowed characters in the username. | abcdefghijklmnopqrstuvwxyz<br>ABCDEFGHIJKLMNOPQRSTUVWXYZ<br>0123456789<br>-._@+ |
| [RequireUniqueEmail](/dotnet/api/microsoft.aspnetcore.identity.useroptions.requireuniqueemail) | Requires each user to have a unique email. | `false` |

## Cookie settings

Configure the app's cookie in `Startup.ConfigureServices`:

# [ASP.NET Core 2.x](#tab/aspnetcore2x/)

[!code-csharp[](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?name=snippet_configurecookie)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x/)

[!code-csharp[](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Startup.cs?range=58-59,72-80,84)]

---

[CookieAuthenticationOptions](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions) has the following properties:

|                                                               Property                                                               |                                                                                                                                                           Description                                                                                                                                                            |
|--------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|       [AccessDeniedPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.accessdeniedpath)       |                                                                 Informs the handler that it should change an outgoing <em>403 Forbidden</em> status code into a <em>302 Redirect</em> onto the given path.<br><br>The default value is `/Account/AccessDenied`.                                                                  |
|             [AuthenticationScheme](/dotnet/api/microsoft.aspnetcore.builder.authenticationoptions.authenticationscheme)              |                                                                                                                Only applies to ASP.NET Core 1.x.<br><br> The logical name for a particular authentication scheme.                                                                                                                |
|            [AutomaticAuthenticate](/dotnet/api/microsoft.aspnetcore.builder.authenticationoptions.automaticauthenticate)             |                                                                       Only applies to ASP.NET Core 1.x.<br><br> When true, cookie authentication should run on every request and attempt to validate and reconstruct any serialized principal it created.                                                                        |
|               [AutomaticChallenge](/dotnet/api/microsoft.aspnetcore.builder.authenticationoptions.automaticchallenge)                |                                              Only applies to ASP.NET Core 1.x.<br><br> If true, the authentication middleware handles automatic challenges. If false, the authentication middleware only alters responses when explicitly indicated by the `AuthenticationScheme`.                                               |
|               [ClaimsIssuer](/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.claimsissuer)               |                                                             Gets or sets the issuer that should be used for any claims that are created (inherited from [AuthenticationSchemeOptions](/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions)).                                                             |
|                             [Cookie.Domain](/dotnet/api/microsoft.aspnetcore.http.cookiebuilder.domain)                              |                                                                                                                                             The domain to associate the cookie with.                                                                                                                                             |
|                         [Cookie.Expiration](/dotnet/api/microsoft.aspnetcore.http.cookiebuilder.expiration)                          |                 Gets or sets the lifespan of the HTTP cookie (not the authentication cookie). This property is overridden by [ExpireTimeSpan](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.expiretimespan). It shouldn't be used in the context of CookieAuthentication.                  |
|                           [Cookie.HttpOnly](/dotnet/api/microsoft.aspnetcore.http.cookiebuilder.httponly)                            |                                                                                                               Indicates whether a cookie is accessible by client-side script.<br><br>The default value is `true`.                                                                                                                |
|                               [Cookie.Name](/dotnet/api/microsoft.aspnetcore.http.cookiebuilder.name)                                |                                                                                                                            The name of the cookie.<br><br>The default value is `.AspNetCore.Cookies`.                                                                                                                            |
|                               [Cookie.Path](/dotnet/api/microsoft.aspnetcore.http.cookiebuilder.path)                                |                                                                                                                                                         The cookie path.                                                                                                                                                         |
|                           [Cookie.SameSite](/dotnet/api/microsoft.aspnetcore.http.cookiebuilder.samesite)                            |                                                                                           The `SameSite` attribute of the cookie.<br><br>The default value is [SameSiteMode.Lax](/dotnet/api/microsoft.aspnetcore.http.samesitemode).                                                                                            |
|                       [Cookie.SecurePolicy](/dotnet/api/microsoft.aspnetcore.http.cookiebuilder.securepolicy)                        |                                                   The [CookieSecurePolicy](/dotnet/api/microsoft.aspnetcore.http.cookiesecurepolicy) configuration.<br><br>The default value is [CookieSecurePolicy.SameAsRequest](/dotnet/api/microsoft.aspnetcore.http.cookiesecurepolicy).                                                    |
|                  [CookieDomain](/dotnet/api/microsoft.aspnetcore.builder.cookieauthenticationoptions.cookiedomain)                   |                                                                                                                      Only applies to ASP.NET Core 1.x.<br><br> The domain name where the cookie is served.                                                                                                                       |
|                [CookieHttpOnly](/dotnet/api/microsoft.aspnetcore.builder.cookieauthenticationoptions.cookiehttponly)                 |                                                                                       Only applies to ASP.NET Core 1.x.<br><br> A flag indicating if the cookie should be accessible only to servers.<br><br>The default value is `true`.                                                                                        |
|                    [CookiePath](/dotnet/api/microsoft.aspnetcore.builder.cookieauthenticationoptions.cookiepath)                     |                                                                                                                  Only applies to ASP.NET Core 1.x.<br><br> Used to isolate apps running on the same host name.                                                                                                                   |
|                  [CookieSecure](/dotnet/api/microsoft.aspnetcore.builder.cookieauthenticationoptions.cookiesecure)                   | Only applies to ASP.NET Core 1.x.<br><br> A flag indicating if the cookie created should be limited to HTTPS (`CookieSecurePolicy.Always`), HTTP or HTTPS (`CookieSecurePolicy.None`), or the same protocol as the request (`CookieSecurePolicy.SameAsRequest`).<br><br>The default value is `CookieSecurePolicy.SameAsRequest`. |
|          [CookieManager](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.cookiemanager)          |                                                                                                                         The component used to get cookies from the request or set them on the response.                                                                                                                          |
| [DataProtectionProvider](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.dataprotectionprovider) |                                                                             If set, the provider used by the [CookieAuthenticationHandler](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationhandler) for data protection.                                                                             |
|                      [Description](/dotnet/api/microsoft.aspnetcore.builder.authenticationoptions.description)                       |                                                                                                Only applies to ASP.NET Core 1.x.<br><br> Additional information about the authentication type which is made available to the app.                                                                                                |
|                 [Events](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.events)                 |                                                                                                      The handler calls methods on the provider which give the app control at certain points where processing is occurring.                                                                                                       |
|                 [EventsType](/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.eventstype)                 |                                                            If set, the service type to get the `Events` instance instead of the property (inherited from [AuthenticationSchemeOptions](/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions)).                                                            |
|         [ExpireTimeSpan](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.expiretimespan)         |                                                                                      Controls how much time the authentication ticket stored in the cookie remains valid from the point it's created.<br><br>The default value is 14 days.                                                                                       |
|              [LoginPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.loginpath)              |                                                                                                       When a user is unauthorized, they're redirected to this path to login.<br><br>The default value is `/Account/Login`.                                                                                                       |
|             [LogoutPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.logoutpath)             |                                                                                                            When a user is logged out, they're redirected to this path.<br><br>The default value is `/Account/Logout`.                                                                                                            |
|     [ReturnUrlParameter](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.returnurlparameter)     |                                              Determines the name of the query string parameter which is appended by the middleware when a <em>401 Unauthorized</em> status code is changed to a <em>302 Redirect</em> onto the login path.<br><br>The default value is `ReturnUrl`.                                              |
|           [SessionStore](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.sessionstore)           |                                                                                                                              An optional container in which to store the identity across requests.                                                                                                                               |
|      [SlidingExpiration](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.slidingexpiration)      |                                                                           When true, a new cookie is issued with a new expiration time when the current cookie is more than halfway through the expiration window.<br><br>The default value is `true`.                                                                           |
|       [TicketDataFormat](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.ticketdataformat)       |                                                                                                 The `TicketDataFormat` is used to protect and unprotect the identity and other properties which are stored in the cookie value.                                                                                                  |

