### Adopt simplified authentication state serialization for Blazor Web Apps

Blazor Web Apps can optionally adopt [simplified authentication state serialization](xref:aspnetcore-9#simplified-authentication-state-serialization-for-blazor-web-apps).

In the server project:

* Remove the Persisting Authentication State Provider (`PersistingAuthenticationStateProvider.cs`).

* Remove the service registration from the `Program` file. Instead, chain a call to <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddAuthenticationStateSerialization%2A> on <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>:

  ```diff
  - builder.Services.AddScoped<AuthenticationStateProvider, PersistingAuthenticationStateProvider>();

    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents()
  +     .AddAuthenticationStateSerialization();
  ```

In the client project (`.Client`):

* Remove the Persistent Authentication State Provider (`PersistentAuthenticationStateProvider.cs`).

* Remove the service registration from the `Program` file. Instead, call <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddAuthenticationStateDeserialization%2A> on the service collection:

  ```diff
  - builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
  + builder.Services.AddAuthenticationStateDeserialization();
  ```
