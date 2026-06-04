---
title: "Breaking change: Passkey sign-in enforces email/phone confirmation and lockout"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where PasskeySignInAsync calls PreSignInCheck so that confirmed-email, confirmed-phone, and lockout requirements are honored."
ms.date: 06/04/2026
---
# Passkey sign-in enforces email/phone confirmation and lockout

`SignInManager<TUser>.PasskeySignInAsync` now calls `PreSignInCheck` before signing the user in. This means a successful passkey assertion alone is no longer enough to sign in if the user's account is locked out or hasn't met the configured `RequireConfirmedEmail`, `RequireConfirmedPhoneNumber`, or `RequireConfirmedAccount` policies. This aligns passkey sign-in behavior with `PasswordSignInAsync` and the other sign-in methods.

## Version introduced

.NET 11

## Previous behavior

Previously, `SignInManager<TUser>.PasskeySignInAsync` didn't call `PreSignInCheck`. A successful passkey assertion signed the user in even when:

- `SignInOptions.RequireConfirmedEmail` was `true` and the user's email wasn't confirmed.
- `SignInOptions.RequireConfirmedPhoneNumber` was `true` and the user's phone number wasn't confirmed.
- `SignInOptions.RequireConfirmedAccount` was `true` and the user's account wasn't confirmed.
- The user was locked out (their `LockoutEnd` was in the future).

This was inconsistent with `PasswordSignInAsync` and other sign-in methods, which already enforced these requirements.

## New behavior

Starting in ASP.NET Core 11, after a successful passkey assertion, `PasskeySignInAsync` calls `PreSignInCheck` before issuing the authentication cookie. If the user fails any of the configured checks, the method returns one of the following without signing the user in:

- <xref:Microsoft.AspNetCore.Identity.SignInResult.LockedOut?displayProperty=nameWithType> if the user is locked out.
- <xref:Microsoft.AspNetCore.Identity.SignInResult.NotAllowed?displayProperty=nameWithType> if the user's email, phone, or account isn't confirmed.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

`PasskeySignInAsync` was missing the `PreSignInCheck` call that the other `SignInManager` sign-in methods make. As a result, an application that required confirmed email or phone for password sign-in unintentionally let users bypass that requirement by enrolling a passkey. The change brings passkey sign-in into line with the rest of the sign-in surface. For more information, see [dotnet/aspnetcore#65024](https://github.com/dotnet/aspnetcore/pull/65024).

## Recommended action

Review your sign-in UI flow to handle `SignInResult.LockedOut` and `SignInResult.NotAllowed` for passkey sign-in the same way you already handle them for password sign-in. The scaffolded Identity UI in the ASP.NET Core templates already handles both results.

If your app currently relies on passkey sign-in to bypass these checks, the safest change is to update the relevant user records (for example, mark the email as confirmed) rather than to remove the checks themselves. Removing the checks on `SignInManager<TUser>.PreSignInCheck` affects every sign-in path, not only passkey sign-in.

## Affected APIs

- <xref:Microsoft.AspNetCore.Identity.SignInManager%601.PasskeySignInAsync%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedEmail?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedPhoneNumber?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedAccount?displayProperty=fullName>
