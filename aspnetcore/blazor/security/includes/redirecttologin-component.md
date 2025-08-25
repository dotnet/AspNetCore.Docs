The `RedirectToLogin` component (`RedirectToLogin.razor`):

* Manages redirecting unauthorized users to the login page.
* The current URL that the user is attempting to access is maintained by so that they can be returned to that page if authentication is successful using:
  * [Navigation history state](xref:blazor/fundamentals/routing#navigation-history-state) in ASP.NET Core in .NET 7 or later.
  * A query string in ASP.NET Core in .NET 6 or earlier.

Inspect the `RedirectToLogin` component in [reference source](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp). The location of the component changed over time, so use GitHub search tools to locate the component.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

The project template uses a well-known login path (`authentication/login`). When the app relies on a login endpoint from the OIDC discovery document (`/.well-known/openid-configuration`), <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationApplicationPathsOptions.LogInPath%2A?displayProperty=nameWithType> contains the login path. Change the login redirect in the `RedirectToLogin` component to use the configured path, as the following code demonstrates.

Add the following directives at the top of the `RedirectToLogin` component:

```razor
@using Microsoft.Extensions.Options
@inject IOptionsSnapshot<RemoteAuthenticationOptions<ApiAuthorizationProviderOptions>> RemoteOptions
```

Modify the component's redirect in the `OnInitialized` method:

```diff
- Navigation.NavigateToLogin("authentication/login");
+ Navigation.NavigateToLogin(RemoteOptions.Get(Options.DefaultName)
+     .AuthenticationPaths.LogInPath);
```
