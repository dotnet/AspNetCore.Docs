Collocation of JavaScript (JS) files for Razor components is a convenient way to organize scripts in an app.

Razor components of Blazor apps collocate JS files using the `.razor.js` extension and are publicly addressable using the path to the file in the project:

`{PATH}/{COMPONENT}.{EXTENSION}.js`

* The `{PATH}` placeholder is the path to the component.
* The `{COMPONENT}` placeholder is the component.
* The `{EXTENSION}` placeholder matches the extension of the component (`razor`).

When the app is published, the framework automatically moves the script to the web root. Scripts are moved to `bin\Release\{TARGET FRAMEWORK MONIKER}\publish\wwwroot\Pages\{COMPONENT}.razor.js`, where the `{TARGET FRAMEWORK MONIKER}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) and the `{COMPONENT}` placeholder is the component name. No change is required to the script's relative URL, as Blazor takes care of placing the JS file in published static assets for you.

> [!NOTE]
> This section and the following examples are primarily focused on explaining JS file collocation. The first example demonstrates a collocated JS file with an ordinary JS function. The second example demonstrates the use of a module to load functions, which is the recommended approach for most professional production apps.
>
> Calling JS from .NET is fully covered in <xref:blazor/js-interop/call-javascript-from-dotnet>, where there are further explanations of the Blazor JS API with additional examples. Component disposal, which is present in the second example, is covered in <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

The following `JsCollocation1` component loads a script via a [`HeadContent` component](xref:blazor/components/control-head-content) and calls the function with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType>.

`JsCollocation1` component (`Pages/JsCollocation1.razor`):

```razor
@page "/js-collocation-1"
@inject IJSRuntime JS

<PageTitle>JS Collocation 1</PageTitle>

<h1>JS Collocation Example 1</h1>

<HeadContent>
    <script type="text/javascript" 
        src="./Pages/JsCollocation1.razor.js"></script>
</HeadContent>

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

The collocated JS file for the `JsCollocation1` component is placed next to the `JsCollocation1` component with the file name `JsCollocation1.razor.js`. In the `JsCollocation1` component, the script is referenced at the path of the collocated file. In the following example, the `showPrompt1` function accepts input from a prompt.

`Pages/JsCollocation1.razor.js`:

```javascript
function showPrompt1(message) {
  return prompt(message, 'Type anything here');
}
```

The next example uses a JS module, which is recommended over the preceding approach, which pollutes the client with global methods. The same general principles apply to loading JS from a collocated JS file.

The following `JsCollocation2` component's `OnAfterRenderAsync` method loads a JS module into `module`, which is a private nullable <xref:Microsoft.JSInterop.IJSObjectReference> of the component class. `module` is used to call the `showPrompt2` function.

`JsCollocation2` component (`Pages/JsCollocation2.razor`):

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
            module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./Pages/JsCollocation2.razor.js");
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

`Pages/JsCollocation2.razor.js`:

```javascript
export function showPrompt2(message) {
  return prompt(message, 'Type anything here');
}
```

For scripts provided by a Razor class library (RCL):

`_content/{PACKAGE ID}/{PATH}/{PAGE, VIEW, OR COMPONENT}.{EXTENSION}.js`

* The `{PACKAGE ID}` placeholder is the RCL's package identifier (or library name for a class library referenced by the app).
* The `{PATH}` placeholder is the path to the page, view, or component. If a Razor component is located at the root of the RCL, the path segment isn't included.
* The `{PAGE, VIEW, OR COMPONENT}` placeholder is the page, view, or component.
* The `{EXTENSION}` placeholder matches the extension of page, view, or component, either `razor` or `cshtml`.

In the following Blazor app example:

* The RCL's package identifier is `AppJS`.
* A module's scripts are loaded for the `Home` component (`Home.razor`).
* The `Home` component is in the `Pages` folder of the RCL.

```csharp
module = await JS.InvokeAsync<IJSObjectReference>("import", 
    "./_content/AppJS/Pages/Home.razor.js");
```
