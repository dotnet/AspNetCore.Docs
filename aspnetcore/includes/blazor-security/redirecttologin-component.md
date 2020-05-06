The `RedirectToLogin` component (*Shared/RedirectToLogin.razor*):

* Manages redirecting unauthorized users to the login page.
* Preserves the current URL that the user is attempting to access so that they can be returned to that page if authentication is successful.

```razor
@inject NavigationManager Navigation
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@code {
    protected override void OnInitialized()
    {
        Navigation.NavigateTo($"authentication/login?returnUrl=" +
            Uri.EscapeDataString(Navigation.Uri));
    }
}
```
