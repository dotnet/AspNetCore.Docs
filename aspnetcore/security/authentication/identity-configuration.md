---
title: Configure ASP.NET Core Identity
author: AdrienTorris
description: Understand ASP.NET Core Identity default values and learn how to configure Identity properties to use custom values.
ms.author: riande
monikerRange: '>= aspnetcore-3.1'
ms.custom: mvc
ms.date: 2/15/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/identity-configuration
---
# Configure ASP.NET Core Identity

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core Identity uses default values for settings such as password policy, lockout, and cookie configuration. These settings can be overridden at application startup.

## Identity options

The <xref:Microsoft.AspNetCore.Identity.IdentityOptions> class represents the options that can be used to configure the Identity system. <xref:Microsoft.AspNetCore.Identity.IdentityOptions> must be set **after** calling <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentity%2A> or <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionUIExtensions.AddDefaultIdentity%2A>.

### Claims Identity

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.ClaimsIdentity?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions> with the properties shown in the following table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.RoleClaimType%2A> | Gets or sets the claim type used for a role claim. | <xref:System.Security.Claims.ClaimTypes.Role?displayProperty=nameWithType> |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.SecurityStampClaimType%2A> | Gets or sets the claim type used for the security stamp claim. | `AspNet.Identity.SecurityStamp` |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserIdClaimType%2A> | Gets or sets the claim type used for the user identifier claim. | <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserNameClaimType%2A> | Gets or sets the claim type used for the user name claim. | <xref:System.Security.Claims.ClaimTypes.Name?displayProperty=nameWithType> |

### Lockout

Lockout is set in the [PasswordSignInAsync](xref:Microsoft.AspNetCore.Identity.SignInManager%601.PasswordSignInAsync(System.String,System.String,System.Boolean,System.Boolean)) method:

[!code-csharp[](identity-configuration/sample6/RPauth/Areas/Identity/Pages/Account/Login.cshtml.cs?name=snippet&highlight=13)]

The preceding code is based on the [`Login` Identity template](https://github.com/dotnet/aspnetcore/blob/1dcf7acfacf0fe154adcc23270cb0da11ff44ace/src/Identity/UI/src/Areas/Identity/Pages/V5/Account/Login.cshtml.cs#L131-L132).

Lockout options are set in `Program.cs`:

[!code-csharp[](identity-configuration/sample6/RPauth/Program.cs?name=snippet_lock&highlight=17-23)]

The preceding code sets the <xref:Microsoft.AspNetCore.Identity.IdentityOptions> <xref:Microsoft.AspNetCore.Identity.LockoutOptions> with default values.

A successful authentication resets the failed access attempts count and resets the clock.

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Lockout%2A?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.LockoutOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.AllowedForNewUsers%2A> | Determines if a new user can be locked out. | `true` |
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.DefaultLockoutTimeSpan%2A> | The amount of time a user is locked out when a lockout occurs. | 5 minutes |
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.MaxFailedAccessAttempts%2A> | The number of failed access attempts until a user is locked out, if lockout is enabled. | 5 |

### Password

By default, Identity requires that passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least six characters long.

Passwords are configured with:

* <xref:Microsoft.AspNetCore.Identity.PasswordOptions> in `Program.cs`.
* [`[StringLength]` attributes](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute) of `Password` properties if Identity is [scaffolded into the app](xref:security/authentication/scaffold-identity). `InputModel` `Password` properties are found in the following files:
  * `Areas/Identity/Pages/Account/Register.cshtml.cs`
  * `Areas/Identity/Pages/Account/ResetPassword.cshtml.cs`

[!code-csharp[](identity-configuration/sample6/RPauth/Program.cs?name=snippet_pw&highlight=17-26)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Password%2A?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.PasswordOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireDigit%2A> | Requires a number between 0-9 in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequiredLength%2A> | The minimum length of the password. | 6 |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireLowercase%2A> | Requires a lowercase character in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireNonAlphanumeric%2A> | Requires a non-alphanumeric character in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequiredUniqueChars%2A> | Only applies to ASP.NET Core 2.0 or later.<br><br> Requires the number of distinct characters in the password. | 1 |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireUppercase%2A> | Requires an uppercase character in the password. | `true` |

### Sign-in

The following code sets `SignIn` settings (to default values):

[!code-csharp[](identity-configuration/sample6/RPauth/Program.cs?name=snippet_si)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.SignIn?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.SignInOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedEmail%2A> | Requires a confirmed email to sign in. | `false` |
| <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedPhoneNumber%2A> | Requires a confirmed phone number to sign in. | `false` |

### Tokens

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Tokens%2A?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.TokenOptions> with the properties shown in the table.

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.AuthenticatorTokenProvider%2A> | Gets or sets the `AuthenticatorTokenProvider` used to validate two-factor sign-ins with an authenticator. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ChangeEmailTokenProvider%2A> | Gets or sets the `ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ChangePhoneNumberTokenProvider%2A> | Gets or sets the `ChangePhoneNumberTokenProvider` used to generate tokens used when changing phone numbers. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.EmailConfirmationTokenProvider%2A> | Gets or sets the token provider used to generate tokens used in account confirmation emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.PasswordResetTokenProvider%2A> | Gets or sets the <xref:Microsoft.AspNetCore.Identity.IUserTwoFactorTokenProvider%601> used to generate tokens used in password reset emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ProviderMap%2A> | Used to construct a [User Token Provider](xref:Microsoft.AspNetCore.Identity.TokenProviderDescriptor) with the key used as the provider's name. |

### User

[!code-csharp[](identity-configuration/sample6/RPauth/Program.cs?name=snippet_user)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.User%2A?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.UserOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.UserOptions.AllowedUserNameCharacters%2A> | Allowed characters in the username. | abcdefghijklmnopqrstuvwxyz<br>ABCDEFGHIJKLMNOPQRSTUVWXYZ<br>0123456789<br>-.\_@+ |
| <xref:Microsoft.AspNetCore.Identity.UserOptions.RequireUniqueEmail%2A> | Requires each user to have a unique email. | `false` |

### Cookie settings

Configure the app's cookie in `Program.cs`. [ConfigureApplicationCookie](xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.ConfigureApplicationCookie(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions})) must be called **after** calling `AddIdentity` or `AddDefaultIdentity`.

[!code-csharp[](identity-configuration/sample6/RPauth/Program.cs?name=snippet_cookie)]

For more information, see <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions>.

## Password Hasher options

<xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions> gets and sets options for password hashing.

| Option | Description |
|--|--|
| <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.CompatibilityMode> | The compatibility mode used when hashing new passwords. Defaults to <xref:Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV3>. The first byte of a hashed password, called a *format marker*, specifies the version of the hashing algorithm used to hash the password. When verifying a password against a hash, the <xref:Microsoft.AspNetCore.Identity.PasswordHasher%601.VerifyHashedPassword%2A> method selects the correct algorithm based on the first byte. A client is able to authenticate regardless of which version of the algorithm was used to hash the password. Setting the compatibility mode affects the hashing of *new passwords*. |
| <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.IterationCount> | The number of iterations used when hashing passwords using PBKDF2. This value is only used when the <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.CompatibilityMode> is set to <xref:Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV3>. The value must be a positive integer and defaults to `10000`. |

In the following example, the <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.IterationCount> is set to `12000` in `Program.cs`:

```csharp
// using Microsoft.AspNetCore.Identity;

builder.Services.Configure<PasswordHasherOptions>(option =>
{
    option.IterationCount = 12000;
});
```

## Globally require all users to be authenticated

[!INCLUDE[](~/includes/requireAuth.md)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"

ASP.NET Core Identity uses default values for settings such as password policy, lockout, and cookie configuration. These settings can be overridden in the `Startup` class.

## Identity options

The <xref:Microsoft.AspNetCore.Identity.IdentityOptions> class represents the options that can be used to configure the Identity system. `IdentityOptions` must be set **after** calling `AddIdentity` or `AddDefaultIdentity`.

### Claims Identity

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.ClaimsIdentity?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions> with the properties shown in the following table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.RoleClaimType%2A> | Gets or sets the claim type used for a role claim. | <xref:System.Security.Claims.ClaimTypes.Role?displayProperty=nameWithType> |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.SecurityStampClaimType%2A> | Gets or sets the claim type used for the security stamp claim. | `AspNet.Identity.SecurityStamp` |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserIdClaimType%2A> | Gets or sets the claim type used for the user identifier claim. | <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserNameClaimType%2A> | Gets or sets the claim type used for the user name claim. | <xref:System.Security.Claims.ClaimTypes.Name?displayProperty=nameWithType> |

### Lockout

Lockout is set in the [PasswordSignInAsync](xref:Microsoft.AspNetCore.Identity.SignInManager%601.PasswordSignInAsync(System.String,System.String,System.Boolean,System.Boolean)) method:

[!code-csharp[](identity-configuration/sample/Areas/Identity/Pages/Account/Login.cshtml.cs?name=snippet&highlight=9)]

The preceding code is based on the `Login` Identity template. 

Lockout options are set in `StartUp.ConfigureServices`:

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_lock)]

The preceding code sets the <xref:Microsoft.AspNetCore.Identity.IdentityOptions> <xref:Microsoft.AspNetCore.Identity.LockoutOptions> with default values.

A successful authentication resets the failed access attempts count and resets the clock.

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Lockout%2A?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.LockoutOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.AllowedForNewUsers%2A> | Determines if a new user can be locked out. | `true` |
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.DefaultLockoutTimeSpan%2A> | The amount of time a user is locked out when a lockout occurs. | 5 minutes |
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.MaxFailedAccessAttempts%2A> | The number of failed access attempts until a user is locked out, if lockout is enabled. | 5 |

### Password

By default, Identity requires that passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least six characters long.

Passwords are configured with:

* <xref:Microsoft.AspNetCore.Identity.PasswordOptions> in `Startup.ConfigureServices`.
* [`[StringLength]` attributes](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute) of `Password` properties if Identity is [scaffolded into the app](xref:security/authentication/scaffold-identity). `InputModel` `Password` properties are found in the following files:
  * `Areas/Identity/Pages/Account/Register.cshtml.cs`
  * `Areas/Identity/Pages/Account/ResetPassword.cshtml.cs`

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_pw)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Password%2A?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.PasswordOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireDigit%2A> | Requires a number between 0-9 in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequiredLength%2A> | The minimum length of the password. | 6 |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireLowercase%2A> | Requires a lowercase character in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireNonAlphanumeric%2A> | Requires a non-alphanumeric character in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequiredUniqueChars%2A> | Only applies to ASP.NET Core 2.0 or later.<br><br> Requires the number of distinct characters in the password. | 1 |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireUppercase%2A> | Requires an uppercase character in the password. | `true` |

### Sign-in

The following code sets `SignIn` settings (to default values):

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_si)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.SignIn?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.SignInOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedEmail%2A> | Requires a confirmed email to sign in. | `false` |
| <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedPhoneNumber%2A> | Requires a confirmed phone number to sign in. | `false` |

### Tokens

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Tokens%2A?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.TokenOptions> with the properties shown in the table.

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.AuthenticatorTokenProvider%2A> | Gets or sets the `AuthenticatorTokenProvider` used to validate two-factor sign-ins with an authenticator. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ChangeEmailTokenProvider%2A> | Gets or sets the `ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ChangePhoneNumberTokenProvider%2A> | Gets or sets the `ChangePhoneNumberTokenProvider` used to generate tokens used when changing phone numbers. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.EmailConfirmationTokenProvider%2A> | Gets or sets the token provider used to generate tokens used in account confirmation emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.PasswordResetTokenProvider%2A> | Gets or sets the <xref:Microsoft.AspNetCore.Identity.IUserTwoFactorTokenProvider%601> used to generate tokens used in password reset emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ProviderMap%2A> | Used to construct a [User Token Provider](xref:Microsoft.AspNetCore.Identity.TokenProviderDescriptor) with the key used as the provider's name. |

### User

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_user)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.User%2A?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.UserOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.UserOptions.AllowedUserNameCharacters%2A> | Allowed characters in the username. | abcdefghijklmnopqrstuvwxyz<br>ABCDEFGHIJKLMNOPQRSTUVWXYZ<br>0123456789<br>-.\_@+ |
| <xref:Microsoft.AspNetCore.Identity.UserOptions.RequireUniqueEmail%2A> | Requires each user to have a unique email. | `false` |

### Cookie settings

Configure the app's cookie in `Startup.ConfigureServices`. [ConfigureApplicationCookie](xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.ConfigureApplicationCookie(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions})) must be called **after** calling `AddIdentity` or `AddDefaultIdentity`.

[!code-csharp[](identity-configuration/sample/Startup.cs?name=snippet_cookie)]

For more information, see <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions>.

## Password Hasher options

<xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions> gets and sets options for password hashing.

| Option | Description |
|--|--|
| <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.CompatibilityMode> | The compatibility mode used when hashing new passwords. Defaults to <xref:Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV3>. The first byte of a hashed password, called a *format marker*, specifies the version of the hashing algorithm used to hash the password. When verifying a password against a hash, the <xref:Microsoft.AspNetCore.Identity.PasswordHasher%601.VerifyHashedPassword%2A> method selects the correct algorithm based on the first byte. A client is able to authenticate regardless of which version of the algorithm was used to hash the password. Setting the compatibility mode affects the hashing of *new passwords*. |
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

:::moniker-end
