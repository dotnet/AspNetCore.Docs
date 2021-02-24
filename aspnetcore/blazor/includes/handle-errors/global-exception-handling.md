---
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
Blazor is a single-page application (SPA) client-side framework. The browser serves as the app's host and thus acts as the processing pipeline for individual Razor components based on URI requests for navigation and static assets. Unlike ASP.NET Core apps that run on the server with a middleware processing pipeline, there is no middleware pipeline processing requests for Razor components that can be leveraged for global error handling. However, an app can use an error processing component as a cascading value to the components of an app to process errors in a centralized way.

The following `Error` component passes itself as a [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) to child components. The component processes a string of error information by merely logging the string. However, any degree of error processing desired can occur in the `ProcessError` method. An advantage of using a component over using an [injected service](xref:blazor/fundamentals/dependency-injection) throughout the app is that the component can render content and apply CSS styles when an error occurs.

`Shared/Error.razor`:

```razor
@using Microsoft.Extensions.Logging
@inject ILogger<Error> Logger

<CascadingValue Value=this>
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public void ProcessError(Exception ex)
    {
        Logger.LogError("Error:ProcessError - Type: {Type} Message: {Message}", 
            ex.GetType(), ex.Message);
    }
}
```

In the app's `App` component, wrap the `Router` component with the `Error` component. This permits the `Error` component to cascade down to any component of the app where the `Error` component is received as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute).

`App.razor`:

```razor
<Error>
    <Router ...>
        ...
    </Router>
</Error>
```

To process errors in any app component:

* Designate the `Error` component as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute) in the [`@code`](xref:mvc/views/razor#code) block:

  ```razor
  [CascadingParameter]
  public Error Error { get; set; }
  ```

* Call the `ProcessError` method in any `catch` block with an appropriate exception type:

  ```csharp
  try
  {
      ...
  }
  catch (Exception ex)
  {
      Error.ProcessError(ex);
  }
  ```

The browser's developer tools console shows a trapped error:

> fail: BlazorSample.Shared.Error[0]
> Error:ProcessError - Type: System.NullReferenceException Message: Object reference not set to an instance of an object.

If the `ProcessError` method directly participates in rendering, such as showing a custom error message bar or changing the CSS styles of the rendered elements, call [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes) at the end of the `ProcessErrors` method to rerender the UI.
