Collocation of JavaScript (JS) files for Razor components is a convenient way to organize scripts in an app.

Razor components of Blazor apps collocate JS files using the `.razor.js` extension and are publicly addressable using the path to the file in the project. Example: `Index.razor.js` for the `Index` component.

Components from a collocated scripts file in the app:

`{PATH}/{COMPONENT}.{EXTENSION}.js`

* The `{PATH}` placeholder is the path to the component.
* The `{COMPONENT}` placeholder is the component.
* The `{EXTENSION}` placeholder matches the extension of the component (`razor`).

A JS file for the `Index` component is placed next to the `Index` component (`Index.razor`). In the `Index` component, the script is referenced at its path.

`Index.razor.js`:

```javascript
export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}
```

In the `OnAfterRenderAsync` method of the `Index` component (`Index.razor`) with `module` is a private nullable <xref:Microsoft.JSInterop.IJSObjectReference> of the component class (`private IJSObjectReference? module;`).

`Index` component (`Index.razor`):

  ```razor
@page "/"
@implements IAsyncDisposable
@inject IJSRuntime JS

<PageTitle>Home</PageTitle>

<h1>Home</h1>

<button @onclick="ExecuteShowPrompt">showPrompt</button>

@if (!string.IsNullOrEmpty(result))
{
    <p>
        @result
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
                "./Pages/Home.razor.js");
        }
    }

    public async void ExecuteShowPrompt()
    {
        if (module is not null)
        {
            result = await module.InvokeAsync<string>(
                "showPrompt", "Hello World");
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

For more information component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

When the app is published, the framework automatically moves the script to the web root. In the preceding example, the script is moved to `bin\Release\{TARGET FRAMEWORK MONIKER}\publish\wwwroot\Components\Pages\Index.razor.js`, where the `{TARGET FRAMEWORK MONIKER}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks). No change is required to the script's relative URL in the `Index` component.

For scripts provided by a Razor class library (RCL):

`_content/{PACKAGE ID}/{PATH}/{PAGE, VIEW, OR COMPONENT}.{EXTENSION}.js`

* The `{PACKAGE ID}` placeholder is the RCL's package identifier (or library name for a class library referenced by the app).
* The `{PATH}` placeholder is the path to the page, view, or component. If a Razor component is located at the root of the RCL, the path segment isn't included.
* The `{PAGE, VIEW, OR COMPONENT}` placeholder is the page, view, or component.
* The `{EXTENSION}` placeholder matches the extension of page, view, or component, either `razor` or `cshtml`.

In the following Blazor app example:

* The RCL's package identifier is `AppJS`.
* A module's scripts are loaded for the `Index` component (`Index.razor`).
* The `Index` component is in the `Pages` folder of the `Components` folder of the RCL.

```csharp
module = await JS.InvokeAsync<IJSObjectReference>("import", 
    "./_content/AppJS/Components/Pages/Index.razor.js");
```
