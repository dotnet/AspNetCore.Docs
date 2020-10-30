---
title: Configure ASP.NET Core Identity
author: AdrienTorris
description: Understand ASP.NET Core Identity default values and learn how to configure Identity properties to use custom values.
ms.author: riande
ms.custom: mvc
ms.date: 02/11/2019
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/identity-configuration
---
# Configure ASP.NET Core Identity

ASP.NET Core Identity uses default values for settings such as password policy, lockout, and cookie configuration. These settings can be overridden in the `Startup` class.

## Identity options

The [IdentityOptions](/dotnet/api/microsoft.aspnetcore.identity.identityoptions) class represents the options that can be used to configure the Identity system. `IdentityOptions` must be set **after** calling `AddIdentity` or `AddDefaultIdentity`.

### Claims Identity

[IdentityOptions.ClaimsIdentity](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.claimsidentity) specifies the [ClaimsIdentityOptions](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions) with the properties shown in the following table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [RoleClaimType](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions.roleclaimtype) | Gets or sets the claim type used for a role claim. | [ClaimTypes.Role](/dotnet/api/system.security.claims.claimtypes.role) |
| [SecurityStampClaimType](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions.securitystampclaimtype) | Gets or sets the claim type used for the security stamp claim. | `AspNet.Identity.SecurityStamp` |
| [UserIdClaimType](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions.useridclaimtype) | Gets or sets the claim type used for the user identifier claim. | [ClaimTypes.NameIdentifier](/dotnet/api/system.security.claims.claimtypes.nameidentifier) |
| [UserNameClaimType](/dotnet/api/microsoft.aspnetcore.identity.claimsidentityoptions.usernameclaimtype) | Gets or sets the claim type used for the user name claim. | [ClaimTypes.Name](/dotnet/api/system.security.claims.claimtypes.name) |

### Lockout

Lockout is set in the [PasswordSignInAsync](/dotnet/api/microsoft.aspnetcore.identity.signinmanager-1.passwordsigninasync#Microsoft_AspNetCore_Identity_SignInManager_1_PasswordSignInAsync_System_String_System_String_System_Boolean_System_Boolean_) method:

[!code-csharp[](identity-configuration/sample/Areas/Identity/Pages/Account/Login.cshtml.cs?name=snippet&highlight=9)]

The preceding code is based on the `Login` Identity template. 

Lockout options are set in `StartUp.ConfigureServices`:

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_lock)]

The preceding code sets the [IdentityOptions](/dotnet/api/microsoft.aspnetcore.identity.identityoptions) [LockoutOptions](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions) with default values.

A successful authentication resets the failed access attempts count and resets the clock.

[IdentityOptions.Lockout](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.lockout) specifies the [LockoutOptions](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [AllowedForNewUsers](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions.allowedfornewusers) | Determines if a new user can be locked out. | `true` |
| [DefaultLockoutTimeSpan](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions.defaultlockouttimespan) | The amount of time a user is locked out when a lockout occurs. | 5 minutes |
| [MaxFailedAccessAttempts](/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions.maxfailedaccessattempts) | The number of failed access attempts until a user is locked out, if lockout is enabled. | 5 |

### Password

By default, Identity requires that passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least six characters long.

Passwords are configured with:

* <xref:Microsoft.AspNetCore.Identity.PasswordOptions> in `Startup.ConfigureServices`.
* [`[StringLength]` attributes](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute) of `Password` properties if Identity is [scaffolded into the app](xref:security/authentication/scaffold-identity). `InputModel` `Password` properties are found in the following files:
  * `Areas/Identity/Pages/Account/Register.cshtml.cs`
  * `Areas/Identity/Pages/Account/ResetPassword.cshtml.cs`

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_pw)]

[IdentityOptions.Password](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.password) specifies the [PasswordOptions](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [RequireDigit](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requiredigit) | Requires a number between 0-9 in the password. | `true` |
| [RequiredLength](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requiredlength) | The minimum length of the password. | 6 |
| [RequireLowercase](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requirelowercase) | Requires a lowercase character in the password. | `true` |
| [RequireNonAlphanumeric](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requirenonalphanumeric) | Requires a non-alphanumeric character in the password. | `true` |
| [RequiredUniqueChars](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requireduniquechars) | Only applies to ASP.NET Core 2.0 or later.<br><br> Requires the number of distinct characters in the password. | 1 |
| [RequireUppercase](/dotnet/api/microsoft.aspnetcore.identity.passwordoptions.requireuppercase) | Requires an uppercase character in the password. | `true` |

### Sign-in

The following code sets `SignIn` settings (to default values):

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_si)]

[IdentityOptions.SignIn](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.signin) specifies the [SignInOptions](/dotnet/api/microsoft.aspnetcore.identity.signinoptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [RequireConfirmedEmail](/dotnet/api/microsoft.aspnetcore.identity.signinoptions.requireconfirmedemail) | Requires a confirmed email to sign in. | `false` |
| [RequireConfirmedPhoneNumber](/dotnet/api/microsoft.aspnetcore.identity.signinoptions.requireconfirmedphonenumber) | Requires a confirmed phone number to sign in. | `false` |

### Tokens

[IdentityOptions.Tokens](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.tokens) specifies the [TokenOptions](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions) with the properties shown in the table.

| Property | Description |
| -------- | ----------- |
| [AuthenticatorTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.authenticatortokenprovider) | Gets or sets the `AuthenticatorTokenProvider` used to validate two-factor sign-ins with an authenticator. |
| [ChangeEmailTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.changeemailtokenprovider) | Gets or sets the `ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails. |
| [ChangePhoneNumberTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.changephonenumbertokenprovider) | Gets or sets the `ChangePhoneNumberTokenProvider` used to generate tokens used when changing phone numbers. |
| [EmailConfirmationTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.emailconfirmationtokenprovider) | Gets or sets the token provider used to generate tokens used in account confirmation emails. |
| [PasswordResetTokenProvider](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.passwordresettokenprovider) | Gets or sets the [IUserTwoFactorTokenProvider\<TUser>](/dotnet/api/microsoft.aspnetcore.identity.iusertwofactortokenprovider-1) used to generate tokens used in password reset emails. |
| [ProviderMap](/dotnet/api/microsoft.aspnetcore.identity.tokenoptions.providermap) | Used to construct a [User Token Provider](/dotnet/api/microsoft.aspnetcore.identity.tokenproviderdescriptor) with the key used as the provider's name. |

### User

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_user)]

[IdentityOptions.User](/dotnet/api/microsoft.aspnetcore.identity.identityoptions.user) specifies the [UserOptions](/dotnet/api/microsoft.aspnetcore.identity.useroptions) with the properties shown in the table.

| Property | Description | Default |
| -------- | ----------- | :-----: |
| [AllowedUserNameCharacters](/dotnet/api/microsoft.aspnetcore.identity.useroptions.allowedusernamecharacters) | Allowed characters in the username. | abcdefghijklmnopqrstuvwxyz<br>ABCDEFGHIJKLMNOPQRSTUVWXYZ<br>0123456789<br>-.\_@+ |
| [RequireUniqueEmail](/dotnet/api/microsoft.aspnetcore.identity.useroptions.requireuniqueemail) | Requires each user to have a unique email. | `false` |

### Cookie settings

Configure the app's cookie in `Startup.ConfigureServices`. [ConfigureApplicationCookie](/dotnet/api/microsoft.extensions.dependencyinjection.identityservicecollectionextensions.configureapplicationcookie#Microsoft_Extensions_DependencyInjection_IdentityServiceCollectionExtensions_ConfigureApplicationCookie_Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Action_Microsoft_AspNetCore_Authentication_Cookies_CookieAuthenticationOptions__) must be called **after** calling `AddIdentity` or `AddDefaultIdentity`.

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_cookie)]

For more information, see [CookieAuthenticationOptions](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions).

## Password Hasher options

<xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions> gets and sets options for password hashing.

| Option | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.CompatibilityMode> | The compatibility mode used when hashing new passwords. Defaults to <xref:Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV3>. The first byte of a hashed password, called a *format marker*, specifies the version of the hashing algorithm used to hash the password. When verifying a password against a hash, the <xref:Microsoft.AspNetCore.Identity.PasswordHasher`1.VerifyHashedPassword*> method selects the correct algorithm based on the first byte. A client is able to authenticate regardless of which version of the algorithm was used to hash the password. Setting the compatibility mode affects the hashing of *new passwords*. |
| <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.IterationCount> | The number of iterations used when hashing passwords using PBKDF2. This value is only used when the <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.CompatibilityMode> is set to <xref:Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV3>. The value must be a positive integer and defaults to `10000`. |

In the following example, the <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.IterationCount> is set to `12000` in `Startup.ConfigureServices`:

```csharp
// using Microsoft.AspNetCore.Identity;

services.Configure<PasswordHasherOptions>(option =>
{
    option.IterationCount = 12000;
});
```

## Globally require all users to be authenticated

[!INCLUDE[](~/includes/requireAuth.md)]