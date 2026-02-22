---
title: "Breaking change: AuthenticateAsync for remote auth providers"
description: Learn about the breaking change in ASP.NET Core 7.0 where AuthenticateAsync for remote authentication providers no longer fails if there is no current user.
ms.date: 09/13/2022
ms.custom: https://github.com/aspnet/Announcements/issues/491
---
# AuthenticateAsync for remote auth providers

Remote authentication providers like OpenIdConnect, WsFederation, and OAuth have been updated to avoid unnecessary errors when there's no user information available on the request.

## Version introduced

.NET 7

## Previous behavior

Previously, when <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A> was called on a remote authentication provider and there was no current user, the call failed with a message similar to `OpenIdConnect was not authenticated. Failure message: Not authenticated`.

## New behavior

Starting in .NET 7, <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A> returns <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult.NoResult?displayProperty=nameWithType>, an anonymous identity.

## Type of breaking change

This change can affect [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility).

## Reason for change

The previous behavior:

- Was inconsistent with `Cookie` and `Negotiate` authentication, which return <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult.NoResult?displayProperty=nameWithType>.
- Caused excess failure logs, especially if the remote authentication handler was set as the default handler and invoked per request.

## Recommended action

If you have code that directly invokes <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A>, check it to ensure it properly handles <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult.NoResult?displayProperty=nameWithType> and anonymous or empty <xref:System.Security.Claims.ClaimsIdentity> instances.

## Affected APIs

- <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A?displayProperty=fullName>
