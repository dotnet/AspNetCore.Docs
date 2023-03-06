The `RedirectToLogin` component (`Shared/RedirectToLogin.razor`):

* Manages redirecting unauthorized users to the login page.
* The current URL that the user is attempting to access is maintained by [navigation history state](xref:blazor/fundamentals/routing#navigation-history-state) so that they can be returned to that page if authentication is successful.

```razor
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject NavigationManager Navigation

@code {
    protected override void OnInitialized()
    {
        Navigation.NavigateToLogin("authentication/login");
    }
}
```
