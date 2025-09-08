Complete migration coverage for Blazor apps is scheduled for September and October of 2025.

### Adopt passkey user authentication in an existing Blazor Web App

For guidance, see <xref:security/authentication/passkeys/blazor?pivots=existing-app>.

### Update the `IdentityRedirectManager` in apps based on the Blazor Web App template with Individual Accounts

The `IdentityRedirectManager` previously threw an <xref:System.InvalidOperationException> in the `RedirectTo` method to ensure the method wasn't called from an interactive render mode and all the redirection methods were marked with the [`[DoesNotReturn]` attribute](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute). For more information, see <xref:aspnetcore-10#navigationmanagernavigateto-no-longer-throws-a-navigationexception>.

In `Components/Account/IdentityRedirectManager.cs`:

* Remove the <xref:System.InvalidOperationException> from the `RedirectTo` method:

  ```diff
  - throw new InvalidOperationException(
  -     $"{nameof(IdentityRedirectManager)} can only be used during static rendering.");
  ```

* Remove five instances of the the `[DoesNotReturn]` attribute from the file:

  ```diff
  - [DoesNotReturn]
  ```

Alternatively, to revert to the previous behavior of throwing a <xref:Microsoft.AspNetCore.Components.NavigationException>, set the following <xref:System.AppContext> switch in the `Program` file:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Components.Endpoints.NavigationManager.DisableThrowNavigationException", 
    isEnabled: false);
```
