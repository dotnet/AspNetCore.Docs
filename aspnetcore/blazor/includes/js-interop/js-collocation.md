Collocation of JavaScript (JS) files for Razor components is a convenient way to organize scripts in an app.

Razor components of Blazor apps collocate JS files using the `.razor.js` extension and are publicly addressable using the path to the file in the project:

`{PATH}/{COMPONENT}.{EXTENSION}.js`

* The `{PATH}` placeholder is the path to the component.
* The `{COMPONENT}` placeholder is the component.
* The `{EXTENSION}` placeholder matches the extension of the component (`razor`).

When the app is published, the framework automatically moves the script to the web root. Scripts are moved to `bin/Release/{TARGET FRAMEWORK MONIKER}/publish/wwwroot/{PATH}/Pages/{COMPONENT}.razor.js`, where the placeholders are:

* `{TARGET FRAMEWORK MONIKER}` is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks).
* `{PATH}` is the path to the component.
* `{COMPONENT}` is the component name.

No change is required to the script's relative URL, as Blazor takes care of placing the JS file in published static assets for you.

This section and the following examples are primarily focused on explaining JS file collocation. The first example demonstrates a collocated JS file with an ordinary JS function. The second example demonstrates the use of a module to load a function, which is the recommended approach for most production apps. Calling JS from .NET is fully covered in <xref:blazor/js-interop/call-javascript-from-dotnet>, where there are further explanations of the Blazor JS API with additional examples. Component disposal, which is present in the second example, is covered in <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

The following `JsCollocation1` component loads a script via a [`HeadContent` component](xref:blazor/components/control-head-content) and calls a JS function with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType>. The `{PATH}` placeholder is the path to the component.

> [!IMPORTANT]
> If you use the following code for a demonstration in a test app, change the `{PATH}` placeholder to the path of the component (example: `Components/Pages` in .NET 8 or later or `Pages` in .NET 7 or earlier). In a Blazor Web App (.NET 8 or later), the component requires an interactive render mode applied either globally to the app or to the component definition.

Add the following script after the Blazor script ([location of the Blazor start script](xref:blazor/project-structure#location-of-the-blazor-script)):

```html
<script src="{PATH}/JsCollocation1.razor.js"></script>
```

`JsCollocation1` component (`{PATH}/JsCollocation1.razor`):

```razor
@page "/js-collocation-1"
@inject IJSRuntime JS

<PageTitle>JS Collocation 1</PageTitle>

<h1>JS Collocation Example 1</h1>

<button @onclick="ShowPrompt">Call showPrompt1</button>

@if (!string.IsNullOrEmpty(result))
{
    <p>
        Hello @result!
    </p>
}

@code {
    private string? result;

    public async void ShowPrompt()
    {
        result = await JS.InvokeAsync<string>(
            "showPrompt1", "What's your name?");
        StateHasChanged();
    }
}
```

The collocated JS file is placed next to the `JsCollocation1` component file with the file name `JsCollocation1.razor.js`. In the `JsCollocation1` component, the script is referenced at the path of the collocated file. In the following example, the `showPrompt1` function accepts the user's name from a [`Window prompt()`](https://developer.mozilla.org/docs/Web/API/Window/prompt) and returns it to the `JsCollocation1` component for display.

`{PATH}/JsCollocation1.razor.js`:

```javascript
function showPrompt1(message) {
  return prompt(message, 'Type your name here');
}
```

The preceding approach isn't recommended for general use in production apps because it pollutes the client with global functions. A better approach for production apps is to use JS modules. The same general principles apply to loading a JS module from a collocated JS file, as the next example demonstrates.

The following `JsCollocation2` component's `OnAfterRenderAsync` method loads a JS module into `module`, which is an <xref:Microsoft.JSInterop.IJSObjectReference> of the component class. `module` is used to call the `showPrompt2` function. The `{PATH}` placeholder is the path to the component.

> [!IMPORTANT]
> If you use the following code for a demonstration in a test app, change the `{PATH}` placeholder to the path of the component. In a Blazor Web App (.NET 8 or later), the component requires an interactive render mode applied either globally to the app or to the component definition.

`JsCollocation2` component (`{PATH}/JsCollocation2.razor`):

```razor
@page "/js-collocation-2"
@implements IAsyncDisposable
@inject IJSRuntime JS

<PageTitle>JS Collocation 2</PageTitle>

<h1>JS Collocation Example 2</h1>

<button @onclick="ShowPrompt">Call showPrompt2</button>

@if (!string.IsNullOrEmpty(result))
{
    <p>
        Hello @result!
    </p>
}

@code {
    private IJSObjectReference? module;
    private string? result;

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            /*
                Change the {PATH} placeholder in the next line to the path of
                the collocated JS file in the app. Examples:

                ./Components/Pages/JsCollocation2.razor.js (.NET 8 or later)
                ./Pages/JsCollocation2.razor.js (.NET 7 or earlier)
            */
            module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./{PATH}/JsCollocation2.razor.js");
        }
    }

    public async void ShowPrompt()
    {
        if (module is not null)
        {
            result = await module.InvokeAsync<string>(
                "showPrompt2", "What's your name?");
            StateHasChanged();
        }
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
```

`{PATH}/JsCollocation2.razor.js`:

```javascript
export function showPrompt2(message) {
  return prompt(message, 'Type your name here');
}
```

For scripts or modules provided by a Razor class library (RCL), the following path is used:

`_content/{PACKAGE ID}/{PATH}/{COMPONENT}.{EXTENSION}.js`

* The `{PACKAGE ID}` placeholder is the RCL's package identifier (or library name for a class library referenced by the app).
* The `{PATH}` placeholder is the path to the component. If a Razor component is located at the root of the RCL, the path segment isn't included.
* The `{COMPONENT}` placeholder is the component name.
* The `{EXTENSION}` placeholder matches the extension of component, either `razor` or `cshtml`.

In the following Blazor app example:

* The RCL's package identifier is `AppJS`.
* A module's scripts are loaded for the `JsCollocation3` component (`JsCollocation3.razor`).
* The `JsCollocation3` component is in the `Components/Pages` folder of the RCL.

```csharp
module = await JS.InvokeAsync<IJSObjectReference>("import", 
    "./_content/AppJS/Components/Pages/JsCollocation3.razor.js");
```
