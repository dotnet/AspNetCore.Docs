### Simplified authentication state serialization for Blazor Web Apps

New APIs make it easier to add authentication to an existing Blazor web app. When you create a new Blazor web app project with authentication using **Individual Accounts** and you enable WebAssembly-based interactivity, the project includes a custom `AuthenticationStateProvider` in both the server and client projects. These providers flow the user's authentication state to the browser. Authenticating on the server rather than the client allows the app to access authentication state during prerendering and before the WebAssembly runtime is initialized. The custom `AuthenticationStateProvider` implementations use the `PersistentComponentState` service to serialize the authentication state into HTML comments and then read it back from WebAssembly to create a new `AuthenticationState` instance. This works well if you've started from the Blazor web app project template and selected the **Individual Accounts** option, but it's a lot of code to implement yourself or copy if you're trying to add authentication to an existing project.

There are now APIs that can be called in the server and client projects to add this functionality:

* In the server project, use [`AddAuthenticationStateSerialization`](https://source.dot.net/#Microsoft.AspNetCore.Components.WebAssembly.Server/WebAssemblyRazorComponentsBuilderExtensions.cs,5557151694ca7c07) in `Program.cs` to add the necessary services to serialize the authentication state on the server.

  ```csharp
  builder.Services.AddRazorComponents()
      .AddInteractiveWebAssemblyComponents()
      .AddAuthenticationStateSerialization();
  ```

* In the client project, use [`AddAuthenticationStateDeserialization`](https://apisof.net/catalog/4a296157ae3e0f6f0c352bfb4a0c5d5a?) in `Program.cs` to add the necessary services to deserialize the authentication state in the browser.

  ```csharp
  builder.Services.AddAuthorizationCore();
  builder.Services.AddCascadingAuthenticationState();
  builder.Services.AddAuthenticationStateDeserialization();
  ```

By default, these APIs will only serialize the server-side name and role claims for access in the browser. To include all claims, use [AuthenticationStateSerializationOptions](https://source.dot.net/#Microsoft.AspNetCore.Components.WebAssembly.Server/AuthenticationStateSerializationOptions.cs,f2703f443f0954f5) on the server:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization(options => options.SerializeAllClaims = true);
```

The Blazor Web App project template has been updated to use these APIs.
