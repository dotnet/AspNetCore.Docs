---
title: Configure ASP.NET Core Identity
ai-usage: ai-assisted
description: Understand ASP.NET Core Identity default values and learn how to configure Identity properties to use custom values.
monikerRange: '>= aspnetcore-3.1'
ms.date: 09/18/2026
uid: security/authentication/identity-configuration
---
# Configure ASP.NET Core Identity

:::moniker range=">= aspnetcore-6.0"


ASP.NET Core Identity uses default values for settings such as password policy, lockout, and cookie configuration. These settings can be overridden at application startup.

## Identity options

The <xref:Microsoft.AspNetCore.Identity.IdentityOptions> class represents the options that can be used to configure the Identity system. <xref:Microsoft.AspNetCore.Identity.IdentityOptions> must be set **after** calling <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentity*> or <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionUIExtensions.AddDefaultIdentity*>.

### Claims Identity

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.ClaimsIdentity?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions> with the properties shown in the following table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.RoleClaimType*> | Gets or sets the claim type used for a role claim. | <xref:System.Security.Claims.ClaimTypes.Role?displayProperty=nameWithType> |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.SecurityStampClaimType*> | Gets or sets the claim type used for the security stamp claim. | `AspNet.Identity.SecurityStamp` |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserIdClaimType*> | Gets or sets the claim type used for the user identifier claim. | <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserNameClaimType*> | Gets or sets the claim type used for the user name claim. | <xref:System.Security.Claims.ClaimTypes.Name?displayProperty=nameWithType> |

### Lockout

Lockout is set in the [PasswordSignInAsync](xref:Microsoft.AspNetCore.Identity.SignInManager`1.PasswordSignInAsync(System.String,System.String,System.Boolean,System.Boolean)) method:

[!code-csharp[](identity-configuration/samples/6/RPauth/Areas/Identity/Pages/Account/Login.cshtml.cs?name=snippet&highlight=13)]

The preceding code is based on the [`Login` Identity template](https://github.com/dotnet/aspnetcore/blob/1dcf7acfacf0fe154adcc23270cb0da11ff44ace/src/Identity/UI/src/Areas/Identity/Pages/V5/Account/Login.cshtml.cs#L131-L132).

Lockout options are set in `Program.cs`:

[!code-csharp[](identity-configuration/samples/6/RPauth/Program.cs?name=snippet_lock&highlight=17-23)]

The preceding code sets the <xref:Microsoft.AspNetCore.Identity.IdentityOptions> <xref:Microsoft.AspNetCore.Identity.LockoutOptions> with default values.

A successful authentication resets the failed access attempts count and resets the clock.

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Lockout*?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.LockoutOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.AllowedForNewUsers*> | Determines if a new user can be locked out. | `true` |
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.DefaultLockoutTimeSpan*> | The amount of time a user is locked out when a lockout occurs. | 5 minutes |
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.MaxFailedAccessAttempts*> | The number of failed access attempts until a user is locked out, if lockout is enabled. | 5 |

### Password

By default, Identity requires that passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least six characters long.

Passwords are configured with:

* <xref:Microsoft.AspNetCore.Identity.PasswordOptions> in `Program.cs`.
* [`[StringLength]` attributes](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute) of `Password` properties if Identity is [scaffolded into the app](xref:security/authentication/scaffold-identity). `InputModel` `Password` properties are found in the following files:
  * `Areas/Identity/Pages/Account/Register.cshtml.cs`
  * `Areas/Identity/Pages/Account/ResetPassword.cshtml.cs`

[!code-csharp[](identity-configuration/samples/6/RPauth/Program.cs?name=snippet_pw&highlight=17-26)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Password*?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.PasswordOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireDigit*> | Requires a number between 0-9 in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequiredLength*> | The minimum length of the password. | 6 |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireLowercase*> | Requires a lowercase character in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireNonAlphanumeric*> | Requires a non-alphanumeric character in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequiredUniqueChars*> | Only applies to ASP.NET Core 2.0 or later.<br><br> Requires the number of distinct characters in the password. | 1 |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireUppercase*> | Requires an uppercase character in the password. | `true` |

### Sign-in

The following code sets `SignIn` settings (to default values):

[!code-csharp[](identity-configuration/samples/6/RPauth/Program.cs?name=snippet_si)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.SignIn?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.SignInOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedEmail*> | Requires a confirmed email to sign in. | `false` |
| <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedPhoneNumber*> | Requires a confirmed phone number to sign in. | `false` |

### Tokens

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Tokens*?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.TokenOptions> with the properties shown in the table.

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.AuthenticatorTokenProvider*> | Gets or sets the `AuthenticatorTokenProvider` used to validate two-factor sign-ins with an authenticator. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ChangeEmailTokenProvider*> | Gets or sets the `ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ChangePhoneNumberTokenProvider*> | Gets or sets the `ChangePhoneNumberTokenProvider` used to generate tokens used when changing phone numbers. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.EmailConfirmationTokenProvider*> | Gets or sets the token provider used to generate tokens used in account confirmation emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.PasswordResetTokenProvider*> | Gets or sets the <xref:Microsoft.AspNetCore.Identity.IUserTwoFactorTokenProvider`1> used to generate tokens used in password reset emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ProviderMap*> | Used to construct a [User Token Provider](xref:Microsoft.AspNetCore.Identity.TokenProviderDescriptor) with the key used as the provider's name. |

### User

[!code-csharp[](identity-configuration/samples/6/RPauth/Program.cs?name=snippet_user)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.User*?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.UserOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.UserOptions.AllowedUserNameCharacters*> | Allowed characters in the username. | abcdefghijklmnopqrstuvwxyz<br>ABCDEFGHIJKLMNOPQRSTUVWXYZ<br>0123456789<br>-.\_@+ |
| <xref:Microsoft.AspNetCore.Identity.UserOptions.RequireUniqueEmail*> | Requires each user to have a unique email. | `false` |

<a name="cs6"></a>

### Cookie settings

Configure the app's cookie in `Program.cs`. [ConfigureApplicationCookie](xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.ConfigureApplicationCookie(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions})) must be called **after** calling `AddIdentityCore`, `AddIdentity`, or `AddDefaultIdentity`.

[!code-csharp[](identity-configuration/samples/6/RPauth/Program.cs?name=snippet_cookie)]

For more information, see <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions>.

## Password Hasher options

<xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions> gets and sets options for password hashing.

| Option | Description |
|--|--|
| <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.CompatibilityMode> | The compatibility mode used when hashing new passwords. Defaults to <xref:Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV3>. The first byte of a hashed password, called a *format marker*, specifies the version of the hashing algorithm used to hash the password. When verifying a password against a hash, the <xref:Microsoft.AspNetCore.Identity.PasswordHasher`1.VerifyHashedPassword*> method selects the correct algorithm based on the first byte. A client is able to authenticate regardless of which version of the algorithm was used to hash the password. Setting the compatibility mode affects the hashing of *new passwords*. |
| <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.IterationCount> | The number of iterations used when hashing passwords using PBKDF2. This value is only used when the <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.CompatibilityMode> is set to <xref:Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV3>. The value must be a positive integer and defaults to `100000`. |

In the following example, the <xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions.IterationCount> is set to `12000` in `Program.cs`:

```csharp
// using Microsoft.AspNetCore.Identity;

builder.Services.Configure<PasswordHasherOptions>(option =>
{
    option.IterationCount = 12000;
});
```

## Globally require all users to be authenticated

For guidance, see [Require global user authentication](xref:security/authorization/policies#require-global-user-authentication).

<a name="iss6"></a>

## ISecurityStampValidator and SignOut everywhere

Apps need to react to events involving security sensitive actions by regenerating the users <xref:System.Security.Claims.ClaimsPrincipal>. For example, the `ClaimsPrincipal` should be regenerated when joining a role, changing the password, or other security sensitive events. Identity uses the <xref:Microsoft.AspNetCore.Identity.ISecurityStampValidator> interface to regenerate the `ClaimsPrincipal`.  The default implementation of Identity registers a [SecurityStampValidator](/dotnet/api/microsoft.aspnetcore.identity.securitystampvalidator) with the main [application cookie](#cs6) and the two-factor cookie. The validator hooks into the <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnValidatePrincipal> event of each cookie to call into Identity to verify that the user's security stamp claim is unchanged from what's stored in the cookie. The validator calls in at regular intervals. The call interval is a tradeoff between hitting the datastore too frequently and not often enough. Checking with a long interval results in stale claims. Call `userManager.UpdateSecurityStampAsync(user)`to force existing cookies to be invalided the next time they are checked. Most of the Identity UI account and manage pages call `userManager.UpdateSecurityStampAsync(user)` after changing the password or adding a login. Apps can call `userManager.UpdateSecurityStampAsync(user)` to implement a sign out everywhere action.

Changing the validation interval is shown in the following highlighted code:

:::code language="csharp" source="~/security/authentication/identity-configuration/Program.cs" highlight="17-19":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

ASP.NET Core Identity uses default values for settings such as password policy, lockout, and cookie configuration. These settings can be overridden in the `Startup` class.

## Identity options

The <xref:Microsoft.AspNetCore.Identity.IdentityOptions> class represents the options that can be used to configure the Identity system. `IdentityOptions` must be set **after** calling `AddIdentity` or `AddDefaultIdentity`.

### Claims Identity

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.ClaimsIdentity?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions> with the properties shown in the following table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.RoleClaimType*> | Gets or sets the claim type used for a role claim. | <xref:System.Security.Claims.ClaimTypes.Role?displayProperty=nameWithType> |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.SecurityStampClaimType*> | Gets or sets the claim type used for the security stamp claim. | `AspNet.Identity.SecurityStamp` |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserIdClaimType*> | Gets or sets the claim type used for the user identifier claim. | <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> |
| <xref:Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserNameClaimType*> | Gets or sets the claim type used for the user name claim. | <xref:System.Security.Claims.ClaimTypes.Name?displayProperty=nameWithType> |

### Lockout

Lockout is set in the [PasswordSignInAsync](xref:Microsoft.AspNetCore.Identity.SignInManager`1.PasswordSignInAsync(System.String,System.String,System.Boolean,System.Boolean)) method:

[!code-csharp[](identity-configuration/samples/Areas/Identity/Pages/Account/Login.cshtml.cs?name=snippet&highlight=9)]

The preceding code is based on the `Login` Identity template. 

Lockout options are set in `StartUp.ConfigureServices`:

[!code-csharp[](identity-configuration/samples/Startup.cs?name=snippet_lock)]

The preceding code sets the <xref:Microsoft.AspNetCore.Identity.IdentityOptions> <xref:Microsoft.AspNetCore.Identity.LockoutOptions> with default values.

A successful authentication resets the failed access attempts count and resets the clock.

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Lockout*?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.LockoutOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.AllowedForNewUsers*> | Determines if a new user can be locked out. | `true` |
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.DefaultLockoutTimeSpan*> | The amount of time a user is locked out when a lockout occurs. | 5 minutes |
| <xref:Microsoft.AspNetCore.Identity.LockoutOptions.MaxFailedAccessAttempts*> | The number of failed access attempts until a user is locked out, if lockout is enabled. | 5 |

### Password

By default, Identity requires that passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least six characters long.

Passwords are configured with:

* <xref:Microsoft.AspNetCore.Identity.PasswordOptions> in `Startup.ConfigureServices`.
* [`[StringLength]` attributes](xref:System.ComponentModel.DataAnnotations.StringLengthAttribute) of `Password` properties if Identity is [scaffolded into the app](xref:security/authentication/scaffold-identity). `InputModel` `Password` properties are found in the following files:
  * `Areas/Identity/Pages/Account/Register.cshtml.cs`
  * `Areas/Identity/Pages/Account/ResetPassword.cshtml.cs`

[!code-csharp[](identity-configuration/samples/Startup.cs?name=snippet_pw)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Password*?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.PasswordOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireDigit*> | Requires a number between 0-9 in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequiredLength*> | The minimum length of the password. | 6 |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireLowercase*> | Requires a lowercase character in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireNonAlphanumeric*> | Requires a non-alphanumeric character in the password. | `true` |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequiredUniqueChars*> | Only applies to ASP.NET Core 2.0 or later.<br><br> Requires the number of distinct characters in the password. | 1 |
| <xref:Microsoft.AspNetCore.Identity.PasswordOptions.RequireUppercase*> | Requires an uppercase character in the password. | `true` |

### Sign-in

The following code sets `SignIn` settings (to default values):

[!code-csharp[](identity-configuration/samples/Startup.cs?name=snippet_si)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.SignIn?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.SignInOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedEmail*> | Requires a confirmed email to sign in. | `false` |
| <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedPhoneNumber*> | Requires a confirmed phone number to sign in. | `false` |

### Tokens

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.Tokens*?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.TokenOptions> with the properties shown in the table.

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.AuthenticatorTokenProvider*> | Gets or sets the `AuthenticatorTokenProvider` used to validate two-factor sign-ins with an authenticator. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ChangeEmailTokenProvider*> | Gets or sets the `ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ChangePhoneNumberTokenProvider*> | Gets or sets the `ChangePhoneNumberTokenProvider` used to generate tokens used when changing phone numbers. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.EmailConfirmationTokenProvider*> | Gets or sets the token provider used to generate tokens used in account confirmation emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.PasswordResetTokenProvider*> | Gets or sets the <xref:Microsoft.AspNetCore.Identity.IUserTwoFactorTokenProvider`1> used to generate tokens used in password reset emails. |
| <xref:Microsoft.AspNetCore.Identity.TokenOptions.ProviderMap*> | Used to construct a [User Token Provider](xref:Microsoft.AspNetCore.Identity.TokenProviderDescriptor) with the key used as the provider's name. |

### User

[!code-csharp[](identity-configuration/samples/Startup.cs?name=snippet_user)]

<xref:Microsoft.AspNetCore.Identity.IdentityOptions.User*?displayProperty=nameWithType> specifies the <xref:Microsoft.AspNetCore.Identity.UserOptions> with the properties shown in the table.

| Property | Description | Default |
|--|--|:-:|
| <xref:Microsoft.AspNetCore.Identity.UserOptions.AllowedUserNameCharacters*> | Allowed characters in the username. | abcdefghijklmnopqrstuvwxyz<br>ABCDEFGHIJKLMNOPQRSTUVWXYZ<br>0123456789<br>-.\_@+ |
| <xref:Microsoft.AspNetCore.Identity.UserOptions.RequireUniqueEmail*> | Requires each user to have a unique email. | `false` |

### Cookie settings

Configure the app's cookie in `Startup.ConfigureServices`. [ConfigureApplicationCookie](xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.ConfigureApplicationCookie(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions})) must be called **after** calling `AddIdentityCore`, `AddIdentity`, or `AddDefaultIdentity`.

[!code-csharp[](identity-configuration/samples/Startup.cs?name=snippet_cookie)]

For more information, see <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions>.

## Password Hasher options

<xref:Microsoft.AspNetCore.Identity.PasswordHasherOptions> gets and sets options for password hashing.

| Option | Description |
|--|--|
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

For guidance, see [Require global user authentication](xref:security/authorization/policies#require-global-user-authentication).

:::moniker-end
