### Blazor release notes

For new feature coverage, see <xref:aspnetcore-10>.

### Set the Blazor WebAssembly environment with the `WasmApplicationEnvironmentName` MSBuild property

*This section only applies to standalone Blazor WebAssembly apps.*

The `Properties/launchSettings.json` file is no longer used to control the environment in standalone Blazor WebAssembly apps.

Set the environment with the `<WasmApplicationEnvironmentName>` property in the app's project file (`.csproj`).

The following example sets the app's environment to `Staging`:

```xml
<WasmApplicationEnvironmentName>Staging</WasmApplicationEnvironmentName>
```

The default environments are:

* `Development` for build.
* `Production` for publish.

### Boot configuration file inlined

Blazor's boot configuration, which prior to the release of .NET 10 existed in a file named `blazor.boot.json`, has been inlined into the `dotnet.js` script. This only affects developers who are interacting directly with the `blazor.boot.json` file, such as when developers are:

* Checking file integrity for published assets with the troubleshoot integrity PowerShell script per the guidance in <xref:blazor/host-and-deploy/webassembly/bundle-caching-and-integrity-check-failures?view=aspnetcore-9.0#troubleshoot-integrity-powershell-script>.
* Changing the file name extension of DLL files when not using the default Webcil file format per the guidance in <xref:blazor/host-and-deploy/webassembly/index?view=aspnetcore-9.0#customize-how-boot-resources-are-loaded>.

Currently, there's no documented replacement strategy for the preceding approaches. If you require either of the preceding strategies, open a new documentation issue describing your scenario using the **Open a documentation issue** link at the bottom of either article.

###  Declarative model for persisting state from components and services

In prior Blazor releases, persisting component state during prerendering using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service involved a significant amount of code. Starting with .NET 10, you can declaratively specify state to persist from components and services using the `[PersistentState]` attribute. For more information, see <xref:aspnetcore-10#declarative-model-for-persisting-state-from-components-and-services>.

### Custom Blazor cache and `BlazorCacheBootResources` MSBuild property removed

Now that all Blazor client-side files are fingerprinted and cached by the browser, Blazor's custom caching mechanism and the `BlazorCacheBootResources` MSBuild property are no longer available. If the client-side project's project file contains the MSBuild property, remove the property, as it no longer has any effect:

```diff
- <BlazorCacheBootResources>...</BlazorCacheBootResources>
```

For more information, see <xref:blazor/host-and-deploy/webassembly/bundle-caching-and-integrity-check-failures?view=aspnetcore-10.0>.

### Adopt passkey user authentication in an existing Blazor Web App

For guidance, see <xref:security/authentication/passkeys/blazor?pivots=existing-app>.

### When navigation errors are disabled in a Blazor Web App with Individual Accounts

*This section applies to Blazor Web Apps that set the `<BlazorDisableThrowNavigationException>` MSBuild property to `true` in order to avoid throwing an navigation exception during static server-side rendering (static SSR).*

The `IdentityRedirectManager` threw an <xref:System.InvalidOperationException> in the `RedirectTo` method to ensure the method wasn't called from an interactive render mode and all the redirection methods were marked with the [`[DoesNotReturn]` attribute](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute). The .NET 10 or later Blazor Web App project template sets the `<BlazorDisableThrowNavigationException>` MSBuild property to `true` in the app's project file in order to avoid throwing the exception during static SSR. If an app based on the project template from a prior release of .NET is updated to .NET 10 or later and includes the `<BlazorDisableThrowNavigationException>` MSBuild property set to `true`, make the following changes. For more information, see <xref:aspnetcore-10#opt-in-to-avoiding-a-navigationexception-during-static-server-side-rendering-with-navigationmanagernavigateto>.

In `Components/Account/IdentityRedirectManager.cs`:

* Remove the <xref:System.InvalidOperationException> from the `RedirectTo` method:

  ```diff
  - throw new InvalidOperationException(
  -     $"{nameof(IdentityRedirectManager)} can only be used during static rendering.");
  ```

* Remove five instances of the `[DoesNotReturn]` attribute from the file:

  ```diff
  - [DoesNotReturn]
  ```
