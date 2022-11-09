The `RedirectToLogin` component (`Shared/RedirectToLogin.razor`):

* Manages redirecting unauthorized users to the login page.
* Preserves the current URL that the user is attempting to access so that they can be returned to that page if authentication is successful.

```razor
@inject NavigationManager Navigation
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@code {
    protected override void OnInitialized()
    {
        Navigation.NavigateTo(
            $"authentication/login?returnUrl={Uri.EscapeDataString(Navigation.Uri)}");
    }
}
```

In ASP.NET Core 7.0, the support for authentication in Blazor WebAssembly apps changed to rely on the history state instead of query strings in the URL. As a result, passing the return URL through the query string will fail to redirect back to the original page after a successful login. Use the `NavigateToLogin` extension method instead. For more information, see [Breaking change: Authentication in WebAssembly apps](/dotnet/core/compatibility/aspnet-core/7.0/wasm-app-authentication).

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
