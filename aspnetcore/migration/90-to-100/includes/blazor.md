Complete migration coverage for Blazor apps is scheduled for September and October of 2025.

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
