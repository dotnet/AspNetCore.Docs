---
title: "Breaking change: OpenID Connect `max_age` validates `auth_time`"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where OpenID Connect validates the signed auth_time claim when an authorization request includes max_age."
ms.date: 11/10/2026
---
# OpenID Connect `max_age` validates `auth_time`

To enforce the authentication freshness requested by an app, the ASP.NET Core OpenID Connect handler now validates the signed `auth_time` claim in ID tokens whenever the authorization request includes `max_age`. Providers that omit the claim or return an invalid authentication time now cause authentication to fail.

## Version introduced

.NET 11 RC 2

## Previous behavior

Previously, the OpenID Connect handler sent `max_age` to the identity provider but didn't validate the returned ID token's `auth_time` against that value. An app could accept authentication even if the provider omitted `auth_time` or reported an authentication time outside the requested limit.

## New behavior

Starting in ASP.NET Core 11, the handler validates `auth_time` after normal token and protocol validation whenever the effective authorization request includes `max_age`. The handler records the exact effective `max_age` in protected authorization transaction state after `OnRedirectToIdentityProvider` runs and uses that value to validate the response.

The effective value can come from any of the following sources:

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MaxAge>
* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectChallengeProperties.MaxAge> for an individual challenge.
* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.AdditionalAuthorizationParameters>
* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnRedirectToIdentityProvider>

The signed ID token must contain `auth_time` as an integral, nonnegative OpenID Connect NumericDate: a JSON number that represents seconds since the Unix epoch and fits within the `DateTimeOffset` range. Authentication fails if the claim is missing, malformed, a string, fractional, negative, or outside that range.

The handler also rejects authentication times that are too old or too far in the future:

* The elapsed time since `auth_time` must not exceed `max_age` plus `TokenValidationParameters.ClockSkew`.
* `auth_time` must not exceed the current time plus `TokenValidationParameters.ClockSkew`.

Values exactly at either boundary are accepted.

This validation applies to every ID token in the authorization code, implicit, and hybrid flows, including both ID tokens in a hybrid flow. It applies to both the default `TokenHandler` and the legacy `SecurityTokenValidator` paths. If the authorization request doesn't include `max_age`, this change adds no new `auth_time` check.

For pushed authorization requests (PAR), set `max_age` in `OnRedirectToIdentityProvider`. While this validation is active, changes to `max_age` in `OnPushAuthorization` are rejected unless the handler skips the push.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change). No API signatures change.

## Reason for change

To enforce the app's requested authentication freshness, the handler must validate the provider's signed assertion instead of only forwarding `max_age`. The [OpenID Connect authentication request specification](https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest) requires an `auth_time` claim when `max_age` is requested. For the implementation and background, see [dotnet/aspnetcore#69321](https://github.com/dotnet/aspnetcore/pull/69321) and [dotnet/aspnetcore#67462](https://github.com/dotnet/aspnetcore/issues/67462).

This check trusts only the identity provider's signed assertion. It doesn't prove that a person performed a new physical authentication ceremony or protect against a compromised provider. It doesn't validate UserInfo claims, cover refresh-token redemption, or change the app's local authentication cookie lifetime.

## Recommended action

To preserve authentication freshness checks, ensure that your identity provider honors `max_age` and returns a valid signed `auth_time` claim in every applicable ID token. Test requests that use each of your app's `max_age` sources and, for PAR, move any `max_age` customization from `OnPushAuthorization` to `OnRedirectToIdentityProvider`.

As a temporary compatibility measure while you update the provider, you can disable the new validation with a process-wide AppContext switch. Set the switch before authentication starts, for example at the beginning of `Program.cs`:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Authentication.OpenIdConnect.DisableMaxAgeValidation",
    true);
```

Alternatively, set the equivalent property in the app's runtime configuration:

```json
{
  "runtimeOptions": {
    "configProperties": {
      "Microsoft.AspNetCore.Authentication.OpenIdConnect.DisableMaxAgeValidation": true
    }
  }
}
```

The switch defaults to `false`. To restore validation after the provider is fixed, remove the switch or set it to `false`. The switch disables the handler's `max_age` validation for the entire process, not just one authentication scheme or challenge.

## Affected APIs

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MaxAge?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectChallengeProperties.MaxAge?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.AdditionalAuthorizationParameters?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnRedirectToIdentityProvider?displayProperty=fullName>
