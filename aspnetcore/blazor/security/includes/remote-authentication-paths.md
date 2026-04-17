Remote authentication paths are customized using <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationApplicationPathsOptions> on the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationOptions%601.AuthenticationPaths%2A?displayProperty=nameWithType> property in the app's `Program` file. For the framework's default path values, see the [`dotnet/aspnetcore` reference source](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly.Authentication/src/RemoteAuthenticationDefaults.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

If an app [customizes a remote authentication path](xref:blazor/security/webassembly/additional-scenarios#customize-app-routes), take either of the following approaches:

* Match the path in hard-coded strings around the app.

* Inject <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationOptions%601?displayProperty=nameWithType> to obtain the configured value around the app. The following example demonstrates the approach for the [`RedirectToLogin` component](#redirecttologin-component).

  Add the following Razor directives to the top of the component's Razor file:

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
  > If other paths differ from the project template's paths or [framework's default paths](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly.Authentication/src/RemoteAuthenticationDefaults.cs), manage them in the same fashion.
