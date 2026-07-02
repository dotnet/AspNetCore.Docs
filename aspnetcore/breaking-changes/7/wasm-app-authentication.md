---
title: "Breaking change: Authentication in WebAssembly apps"
description: Learn about the breaking change in ASP.NET Core 7.0 where authentication in WebAssembly apps relies on the history state instead of the URL query string.
ms.date: 10/20/2022
ms.custom: https://github.com/aspnet/Announcements/issues/497
---
# Authentication in WebAssembly apps

We updated the support for authentication in Blazor WebAssembly apps to rely on the history state instead of query strings in the URL. As a result, existing applications that pass the return URL through the query string will fail to redirect back to the original page after a successful login.

Existing applications should use the new <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.NavigationManagerExtensions.NavigateToLogin%2A> extension method as it's able to flow the data to the login page correctly.

## Version introduced

.NET 7

## Previous behavior

The return URL was specified in the query string as `?returnUrl=<<return-url>>`.

## New behavior

Starting in .NET 7, the return URL and other parameters passed to the `authentication/login` page are passed via the `history.state` entry of the page.

## Type of breaking change

This change can affect [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility).

## Reason for change

We decided to switch to using `history.state` instead of the query string as it simplifies the implementation and removes the surface attack area associated with passing data through the query string.

## Recommended action

Most apps have a *RedirectToLogin.razor* file that you can update as follows:

```razor
@inject NavigationManager Navigation
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using Microsoft.Extensions.Options

@inject IOptionsSnapshot<RemoteAuthenticationOptions<ApiAuthorizationProviderOptions>> Options
@code {

    protected override void OnInitialized()
    {
        Navigation.NavigateToLogin(Options.Get(Microsoft.Extensions.Options.Options.DefaultName).AuthenticationPaths.LogInPath);
    }
}
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.SignOutSessionStateManager?displayProperty=fullName> (obsoleted in favor of new <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.NavigationManagerExtensions.NavigateToLogout%2A?displayProperty=nameWithType> method)

## See also

- [RedirectToLogin component - Blazor WebAssembly](/aspnet/core/blazor/security/webassembly/standalone-with-authentication-library?tabs=visual-studio#redirecttologin-component)
