The `RedirectToLogin` component (`RedirectToLogin.razor`):

* Manages redirecting unauthorized users to the login page.
* The current URL that the user is attempting to access is maintained by so that they can be returned to that page if authentication is successful using:
  * [Navigation history state](xref:blazor/fundamentals/routing#navigation-history-state) in ASP.NET Core in .NET 7 or later.
  * A query string in ASP.NET Core in .NET 6 or earlier.

Inspect the `RedirectToLogin` component in [reference source](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp). The location of the component changed over time, so use GitHub search tools to locate the component.

Paths can be customized by the WebAssembly app (<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationApplicationPathsOptions.LogInPath%2A?displayProperty=nameWithType>, [framework defaults (`dotnet/aspnetcore` reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly.Authentication/src/RemoteAuthenticationDefaults.cs)). The project template uses the well-known, default login path (`authentication/login`). 

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

If an app [customizes the login path](xref:blazor/security/webassembly/additional-scenarios#customize-app-routes), take either of the following approaches:

* Match the path in the hard-coded string in the `RedirectToLogin` component.
* Inject <xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions> to obtain the configured value. For example, take this approach when you customize the path with <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddApiAuthorization%2A> and don't want to duplicate hard-coded string literals across the app's codebase.

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

  > [!NOTE]
  > If other paths differ from the project template's paths or [framework's default paths](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly.Authentication/src/RemoteAuthenticationDefaults.cs), they should managed in the same fashion.
  
