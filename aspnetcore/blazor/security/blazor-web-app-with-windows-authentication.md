---
title: Secure an ASP.NET Core Blazor Web App with Windows Authentication
author: guardrex
description: Learn how to secure a Blazor Web App with Windows Authentication.
monikerRange: '>= aspnetcore-9.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 03/25/2025
uid: blazor/security/blazor-web-app-windows-authentication
---
# Secure an ASP.NET Core Blazor Web App with Windows Authentication

<!-- UPDATE 10.0 - Enable after release

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

-->

This article describes how to secure a Blazor Web App with [Windows Authentication](/windows-server/security/windows-authentication/windows-authentication-overview) using a sample app. For more information, see <xref:security/authentication/windowsauth>.

The app specification for the Blazor Web App:

* Adopts the [Interactive Server render mode with global interactivity](xref:blazor/components/render-modes).
* Establishes an [authorization policy](xref:security/authorization/policies) for a [Windows security identifier](/windows-server/identity/ad-ds/manage/understand-security-identifiers) to access a secure page.

## Sample app

Access the sample through the latest version folder in the Blazor samples repository with the following link. The sample is in the `BlazorWebAppWinAuthServer` folder for .NET 9 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## Configuration

The sample app doesn't require configuration to run locally.

When deployed to a host, such as IIS, the app must adopt impersonation to run under the user's account. For more information, see <xref:security/authentication/windowsauth#impersonation>.

## Sample app code

Inspect the `Program` file in the sample app for the following API calls.

<xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A> is called using the <xref:Microsoft.AspNetCore.Authentication.Negotiate.NegotiateDefaults.AuthenticationScheme%2A?displayProperty=nameWithType> authentication scheme. <xref:Microsoft.Extensions.DependencyInjection.NegotiateExtensions.AddNegotiate%2A> configures the <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder> to use Negotiate (also known as Windows, Kerberos, or NTLM) authentication, and the authentication handler supports Kerberos on Windows and Linux servers:

```csharp
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();
```

<xref:Microsoft.Extensions.DependencyInjection.PolicyServiceCollectionExtensions.AddAuthorization%2A> adds authorization policy services. <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.FallbackPolicy%2A?displayProperty=nameWithType> sets the fallback authorization policy, which is set to the default policy (<xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.DefaultPolicy%2A?displayProperty=nameWithType>). The default policy requires an authenticated user to access the app:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});
```

<xref:Microsoft.Extensions.DependencyInjection.CascadingAuthenticationStateServiceCollectionExtensions.AddCascadingAuthenticationState%2A> adds cascading authentication state to the service collection. This is equivalent to placing a `CascadingAuthenticationState` component at the root of the app's component hierarchy:

```csharp
builder.Services.AddCascadingAuthenticationState();
```

An [authorization policy](xref:security/authorization/policies) is added for a [Windows security identifier (SID)](/windows-server/identity/ad-ds/manage/understand-security-identifiers). The `S-1-5-113` well-known SID in the following example indicates that the user is a local account, which restricts network sign-in to local accounts instead of "administrator" or equivalent accounts:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("LocalAccount", policy =>
        policy.RequireClaim(
            "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid",
            "S-1-5-113"));   
```

The authorization policy is enforced by the `LocalAccountOnly` component.

`Components/Pages/LocalAccountOnly.razor`:

```razor
@page "/local-account-only"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize("LocalAccount")]

<h1>Local Account Only</h1>

<p>
    You can only reach this page by satisfying the
    <code>LocalAccount</code> authorization policy.
</p>
```

The `UserClaims` component lists the user's claims, which includes the user's Windows security identifiers (SIDs), and SID translations.

`Components/Pages/UserClaims.razor`:

```razor
@page "/user-claims"
@using System.Security.Claims
@using System.Security.Principal
@using Microsoft.AspNetCore.Components.QuickGrid

<PageTitle>User Claims & Roles</PageTitle>

<h1>User Claims & Roles</h1>

<QuickGrid Items="claims" Pagination="pagination">
    <Paginator State="pagination" />
    <PropertyColumn Property="@(p => p.Type)" Sortable="true" />
    <PropertyColumn Property="@(p => p.Value)" Sortable="true" />
    <PropertyColumn Property="@(p => GetClaimAsHumanReadable(p))" Sortable="true" Title="Translation" />
    <PropertyColumn Property="@(p => p.Issuer)" Sortable="true" />
</QuickGrid>

<h1>User Roles</h1>

@if (roles.Any())
{
    <ul>
        @foreach (var role in roles)
        {
            <li>@role</li>
        }
    </ul>
}
else
{
    <p>No roles available.</p>
}

@code {
    private IQueryable<Claim> claims = Enumerable.Empty<Claim>().AsQueryable();
    private IEnumerable<string> roles = Enumerable.Empty<string>();
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    [CascadingParameter]
    private Task<AuthenticationState>? AuthState { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (AuthState == null)
        {
            return;
        }

        var authState = await AuthState;

        claims = authState.User.Claims.AsQueryable();

        roles = authState.User.Claims
            .Where(claim => claim.Type == ClaimTypes.Role)
            .Select(claim => claim.Value);
    }

    private string GetClaimAsHumanReadable(Claim claim)
    {
        if (!OperatingSystem.IsWindows() ||
            claim.Type is not (ClaimTypes.PrimarySid or ClaimTypes.PrimaryGroupSid
                or ClaimTypes.GroupSid))
        {
            // We're either not on Windows or not dealing with a SID Claim that
            // can be translated
            return string.Empty;
        }

        SecurityIdentifier sid = new SecurityIdentifier(claim.Value);

        try
        {
            // Throw an exception if the SID can't be translated
            var account = sid.Translate(typeof(NTAccount));

            return account.ToString();
        }
        catch (IdentityNotMappedException)
        {
            return "Could not be mapped";
        }
    }
}
```

## Additional resources

* <xref:security/authentication/windowsauth>
* [Security identifiers (Windows Server documentation)](/windows-server/identity/ad-ds/manage/understand-security-identifiers)
