---
title: Secure an ASP.NET Core Blazor Web App with Windows Authentication
author: guardrex
description: Learn how to secure a Blazor Web App with Windows Authentication.
monikerRange: '>= aspnetcore-9.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/12/2025
uid: blazor/security/blazor-web-app-windows-authentication
---
# Secure an ASP.NET Core Blazor Web App with Windows Authentication

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

This article describes how to secure a Blazor Web App with [Windows Authentication]() using a sample app in the [`dotnet/blazor-samples` GitHub repository (.NET 9 or later)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps)).

Specification for the Blazor Web App:

* [Server render mode with global interactivity](xref:blazor/components/render-modes)
* Establishes an [authorization policy](xref:security/authorization/policies) for a [Windows security identifier](/windows-server/identity/ad-ds/manage/understand-security-identifiers) to access a secure page.

## Sample app

Access the sample app through the latest version folder from the repository's root with the following link. The project is in the `BlazorWebAppWinAuthServer` folder for .NET 9 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## Configuration

This app requires no configuration to run locally.

When deployed to a host, such as IIS, the app must adopt impersonation to run under the user's account. For more information, see <xref:security/authentication/windowsauth>.

### Sample app code

Inspect the `Program` file in the sample app for the following features.

<xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A> is called using the <xref:Microsoft.AspNetCore.Authentication.Negotiate.NegotiateDefaults.AuthenticationScheme%2A?displayProperty=nameWithType> authentication scheme. <xref:Microsoft.Extensions.DependencyInjection.NegotiateExtensions.AddNegotiate%2A> configures the <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder> to use Negotiate (also known as Windows, Kerberos, or NTLM) authentication. This authentication handler supports Kerberos on Windows and Linux servers:

```csharp
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();
```

<xref:Microsoft.Extensions.DependencyInjection.PolicyServiceCollectionExtensions.AddAuthorization%2A> adds authorization policy services, setting the <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.FallbackPolicy%2A?displayProperty=nameWithType> to the default policy (<xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.DefaultPolicy%2A?displayProperty=nameWithType>), which defaults to require authenticated users to access the app.

```csharp
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});
```

<xref:Microsoft.Extensions.DependencyInjection.CascadingAuthenticationStateServiceCollectionExtensions.AddCascadingAuthenticationState%2A> adds cascading authentication state to the service collection. This is equivalent to having a `CascadingAuthenticationState` component at the root of the app's component hierarchy:

```csharp
builder.Services.AddCascadingAuthenticationState();
```

An [authorization policy](xref:security/authorization/policies) is added for a [Windows security identifier](/windows-server/identity/ad-ds/manage/understand-security-identifiers):

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("LocalAccount", policy =>
        policy.RequireClaim(
            "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid",
            "S-1-5-113"));   
```

The authorization policy is enforced by the `LocalAccountOnly` component (path: `/local-account-only`):

```razor
@page "/local-account-only"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize("LocalAccount")]
```

The `UserClaims` component lists the user's claims, which includes the user's Windows security identifiers (SIDs).

## Additional resources

* <xref:security/authentication/windowsauth>
* [Security identifiers (Windows Server documentation)](/windows-server/identity/ad-ds/manage/understand-security-identifiers)
