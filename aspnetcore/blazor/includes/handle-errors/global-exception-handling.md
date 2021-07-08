---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
## Global exception handling

Blazor is a single-page application (SPA) client-side framework. The browser serves as the app's host and thus acts as the processing pipeline for individual Razor components based on URI requests for navigation and static assets. Unlike ASP.NET Core apps that run on the server with a middleware processing pipeline, there is no middleware pipeline that processes requests for Razor components that can be leveraged for global error handling. However, an app can use an error processing component as a cascading value to process errors in a centralized way.

The following `Error` component passes itself as a [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) to child components. The following example merely logs the error, but methods of the component can process errors in any way required by the app, including through the use of multiple error processing methods. An advantage of using a component over using an [injected service](xref:blazor/fundamentals/dependency-injection) or a custom logger implementation is that a cascaded component can render content and apply CSS styles when an error occurs.

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

In the `App` component, wrap the `Router` component with the `Error` component. This permits the `Error` component to cascade down to any component of the app where the `Error` component is received as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute).

`App.razor`:

```razor
<Error>
    <Router ...>
        ...
    </Router>
</Error>
```

To process errors in a component:

* Designate the `Error` component as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute) in the [`@code`](xref:mvc/views/razor#code) block:

  ```razor
  [CascadingParameter]
  public Error Error { get; set; }
  ```

* Call an error processing method in any `catch` block with an appropriate exception type. The example `Error` component only offers a single `ProcessError` method, but the error processing component can provide any number of error processing methods to address alternative error processing requirements throughout the app.

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

Using the preceding example `Error` component and `ProcessError` method, the browser's developer tools console indicates the trapped, logged error:

> fail: BlazorSample.Shared.Error[0]
> Error:ProcessError - Type: System.NullReferenceException Message: Object reference not set to an instance of an object.

If the `ProcessError` method directly participates in rendering, such as showing a custom error message bar or changing the CSS styles of the rendered elements, call [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) at the end of the `ProcessErrors` method to rerender the UI.
