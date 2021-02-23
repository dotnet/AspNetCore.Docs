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

    public void ProcessError(string errorInformation)
    {
        Logger.LogError("Error information: {ErrorInformation}", errorInformation);
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

To process errors in a component, designate the `Error` component as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute) and call its `ProcessError` method in any `catch` block. The following example adds a button to trigger a mock error for processing. Any `try-catch` block in any of the app's components can similarly process any trapped error where the `Error` component cascading parameter is present.

`Pages/Example.razor`:

```razor
@page "/example"

<h1>Example</h1>

<button class="btn btn-primary" @onclick="ProcessExampleError">
    Process an example error
</button>

@code {
    [CascadingParameter]
    public Error Error { get; set; }

    private void ProcessExampleError()
    {
        try
        {
            throw new NullReferenceException();
        }
        catch (NullReferenceException ex)
        {
            Error.ProcessError($"{nameof(Example)} component error = {ex.Message}");
        }
    }
}
```

The browser's developer tools console shows the logged error when the **Process an example error** button is selected:

> fail: BlazorSample.Shared.Error[0]
> Error:ProcessError - Example component error = Object reference not set to an instance of an object.

To show the Blazor error UI, add a JavaScript function that triggers display of the error UI and use JS interop to call the function.

`wwwroot/index.html`:

```html
    ...

    <script>
        window.displayErrorUI = () => 
            document.getElementById("blazor-error-ui").style.display = "block";
    </script>
</head>
```

In the `ProcessError` method of the `Error` component, trigger the JavaScript function with JS interop.

`Shared/Error.razor`:

```razor
...
@using Microsoft.JSInterop
@inject IJSRuntime JSRuntime

...

@code {
    ...

    public void ProcessError(string errorInformation)
    {
        ...

        JSRuntime.InvokeVoidAsync("displayErrorUI");
    }
}
```

The preceding example doesn't attempt to change the text of the `blazor-error-ui` element, so the default text of "`An unhandled error has occurred.`" is displayed unless additional code is added to set the content of the element.

The app can apply CSS styles directly to the rendered child content of the `Error` component. In the following example, a style string is set for a `<div>` element wrapping the child content. When `ProcessError` executes, the style string applies a red background color to the content. When a style is applied through the cascaded `Error` component, a call to [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes) is required to rerender the UI.

`Shared/Error.razor`:

```razor
...

<CascadingValue Value=this>
    <div style="@cssStyle">
        @ChildContent
    </div>
</CascadingValue>

@code {
    private string cssStyle;

    ...

    public void ProcessError(string errorInformation)
    {
        ...

        cssStyle = "background-color: red";
        StateHasChanged();
    }
}
```
