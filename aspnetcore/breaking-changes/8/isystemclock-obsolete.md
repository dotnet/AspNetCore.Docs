---
title: "Breaking change: ISystemClock is obsolete"
description: Learn about the breaking change in ASP.NET Core 8.0 where ISystemClock and constructors that use it have been marked obsolete.
ms.date: 05/30/2023
ms.custom: https://github.com/aspnet/Announcements/issues/505
---
# ISystemClock is obsolete

<xref:Microsoft.AspNetCore.Authentication.ISystemClock?displayProperty=fullName> has been used by ASP.NET Core's authentication and identity components since version 1.0 to enable unit testing of time-related functionality, like expiration checking. .NET 8 includes a suitable abstraction, <xref:System.TimeProvider?displayProperty=fullName>, that provides the same functionality and much more. We're taking this opportunity to obsolete <xref:Microsoft.AspNetCore.Authentication.ISystemClock> and replace it with <xref:System.TimeProvider> throughout the ASP.NET Core libraries.

## Version introduced

ASP.NET Core 8.0 Preview 5

## Previous behavior

<xref:Microsoft.AspNetCore.Authentication.ISystemClock> was injected into the constructors of the authentication and identity components by dependency injection (DI) and could be overridden for testing.

The default <xref:Microsoft.AspNetCore.Authentication.SystemClock> implementation truncated to the nearest second for easier formatting.

## New behavior

<xref:Microsoft.AspNetCore.Authentication.ISystemClock>, <xref:Microsoft.AspNetCore.Authentication.SystemClock>, and the authentication handler constructors that have an <xref:Microsoft.AspNetCore.Authentication.ISystemClock> parameter have been marked obsolete. Using these APIs in code will generate a warning at compile time.

<xref:Microsoft.AspNetCore.Authentication.ISystemClock> remains in the dependency injection container but is no longer used. It may be removed from the container in a future version.

<xref:System.TimeProvider> is now a settable property on the `Options` classes for the authentication and identity components. It can be set directly or by registering a provider in the dependency injection container.

<xref:System.TimeProvider> does not truncate to the nearest second. Consumers are expected to correctly format the time as needed.

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was made to unify time abstraction across the stack for easier testing.

## Recommended action

If you have components that derive from <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601?displayProperty=fullName> or <xref:Microsoft.AspNetCore.Identity.SecurityStampValidator%601?displayProperty=fullName>, remove the <xref:Microsoft.AspNetCore.Authentication.ISystemClock> constructor parameter and call the new base constructor accordingly.

```diff
- public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
-     : base(options, logger, encoder, clock)
+ public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
+     : base(options, logger, encoder)
```

Similarly, derived implementations that reference the `Clock` property on these types should reference the new `TimeProvider` property instead.

```diff
- var currentUtc = Clock.UtcNow;
+ var currentUtc = TimeProvider.GetUtcNow();
```

You can set `TimeProvider` for testing on the options or via DI.

## Affected APIs

- <xref:Microsoft.AspNetCore.Authentication.ISystemClock?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.SystemClock?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601.Clock?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.Facebook.FacebookHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.Facebook.FacebookOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.Google.GoogleHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.Google.GoogleOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.Negotiate.NegotiateHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.Negotiate.NegotiateOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler%601.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{%600},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.HtmlEncoder,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.PolicySchemeHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.PolicySchemeOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler%601?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.SignInAuthenticationHandler%601.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{%600},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.SignOutAuthenticationHandler%601.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{%600},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.Twitter.TwitterHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.Twitter.TwitterOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Authentication.WsFederation.WsFederationHandler.%23ctor(Microsoft.Extensions.Options.IOptionsMonitor{Microsoft.AspNetCore.Authentication.WsFederation.WsFederationOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Microsoft.AspNetCore.Authentication.ISystemClock)>
- <xref:Microsoft.AspNetCore.Identity.SecurityStampValidator%601.%23ctor(Microsoft.Extensions.Options.IOptions{Microsoft.AspNetCore.Identity.SecurityStampValidatorOptions},Microsoft.AspNetCore.Identity.SignInManager{%600},Microsoft.AspNetCore.Authentication.ISystemClock,Microsoft.Extensions.Logging.ILoggerFactory)>
- <xref:Microsoft.AspNetCore.Identity.SecurityStampValidator%601.Clock?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Identity.TwoFactorSecurityStampValidator%601.%23ctor(Microsoft.Extensions.Options.IOptions{Microsoft.AspNetCore.Identity.SecurityStampValidatorOptions},Microsoft.AspNetCore.Identity.SignInManager{%600},Microsoft.AspNetCore.Authentication.ISystemClock,Microsoft.Extensions.Logging.ILoggerFactory)>
