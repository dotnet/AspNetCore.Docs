The `App` component (`App.razor`) is similar to the `App` component found in Blazor Server apps:

:::moniker range=">= aspnetcore-8.0"

* The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> component makes sure that the current user is authorized to access a given page or otherwise renders the `RedirectToLogin` component.
* The `RedirectToLogin` component manages redirecting unauthorized users to the login page.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* The <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> component manages exposing the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> to the rest of the app.
* The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> component makes sure that the current user is authorized to access a given page or otherwise renders the `RedirectToLogin` component.
* The `RedirectToLogin` component manages redirecting unauthorized users to the login page.

:::moniker-end

Due to changes in the framework across releases of ASP.NET Core, Razor markup for the `App` component (`App.razor`) isn't shown in this section. To inspect the markup of the component for a given release, use ***either*** of the following approaches:

* Create an app provisioned for authentication from the default Blazor WebAssembly project template for the version of ASP.NET Core that you intend to use. Inspect the `App` component (`App.razor`) in the generated app.
* Inspect the `App` component (`App.razor`) in [reference source](https://github.com/dotnet/aspnetcore). Select the version from the branch selector, and search for the component in the `ProjectTemplates` folder of the repository because it has moved over the years.

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]
