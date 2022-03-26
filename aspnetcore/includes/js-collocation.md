---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
Collocation of JavaScript (JS) files for pages, views, and Razor components is a convenient way to organize scripts in an app.

Collocate JS files using the following filename extension conventions:

* Pages of Razor Pages apps and views of MVC apps: `.cshtml.js`. Examples:
  * `Pages/Index.cshtml.js` for the `Index` page of a Razor Pages app at `Pages/Index.cshtml`.
  * `Views/Home/Index.cshtml.js` for the `Index` view of an MVC app at `Views/Home/Index.cshtml`.
* Razor components of Blazor apps: `.razor.js`. Example: `Pages/Index.razor.js` for the `Index` component at `Pages/Index.razor`.

Collocated JS files are publicly addressable using the ***path to the file in the project***:

* Pages, views, and components from a collocated scripts file in the app:

  `{PATH}/{PAGE, VIEW, OR COMPONENT}.{EXTENSION}.js`
  
  * The `{PATH}` placeholder is the path to the page, view, or component.
  * The `{PAGE, VIEW, OR COMPONENT}` placeholder is the page, view, or component.
  * The `{EXTENSION}` placeholder matches the extension of the page, view, or component, either `razor` or `cshtml`.

  Razor Pages example:

  A JS file for the `Index` page is placed in the `Pages` folder (`Pages/Index.cshtml.js`) next to the `Index` page (`Pages/Index.cshtml`). In the `Index` page, the script is referenced at the path in the `Pages` folder:

  ```razor
  @section Scripts {
    <script src="~/Pages/Index.cshtml.js"></script>
  }
  ```

  When the app is published, the framework automatically moves the script to the web root. In the preceding example, the script is moved to `bin\Release\{TARGET FRAMEWORK MONIKER}\publish\wwwroot\Pages\Index.cshtml.js`, where the `{TARGET FRAMEWORK MONIKER}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks). No change is required to the script's relative URL in the `Index` page.

  Blazor example:

  A JS file for the `Index` component is placed in the `Pages` folder (`Pages/Index.razor.js`) next to the `Index` component (`Pages/Index.razor`). In the `Index` component, the script is referenced at the path in the `Pages` folder. The following example is based on an example shown in the <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules> article.

  `Pages/Index.razor.js`:

  ```javascript
  export function showPrompt(message) {
    return prompt(message, 'Type anything here');
  }
  ```

  In the `OnAfterRenderAsync` method of the `Index` component (`Pages/Index.razor`):

  ```razor
  module = await JS.InvokeAsync<IJSObjectReference>(
      "import", "./Pages/Index.razor.js");
  ```

  When the app is published, the framework automatically moves the script to the web root. In the preceding example, the script is moved to `bin\Release\{TARGET FRAMEWORK MONIKER}\publish\wwwroot\Pages\Index.razor.js`, where the `{TARGET FRAMEWORK MONIKER}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks). No change is required to the script's relative URL in the `Index` component.

* For scripts provided by a Razor class library (RCL):

  `_content/{PACKAGE ID}/{PATH}/{PAGE, VIEW, OR COMPONENT}.{EXTENSION}.js`

  * The `{PACKAGE ID}` placeholder is the RCL's package identifier (or library name for a class library referenced by the app).
  * The `{PATH}` placeholder is the path to the page, view, or component. If a Razor component is located at the root of the RCL, the path segment isn't included.
  * The `{PAGE, VIEW, OR COMPONENT}` placeholder is the page, view, or component.
  * The `{EXTENSION}` placeholder matches the extension of page, view, or component, either `razor` or `cshtml`.

  In the following Blazor app example:
  
  * The RCL's package identifier is `AppJS`.
  * A module's scripts are loaded for the `Index` component (`Index.razor`).
  * The `Index` component is in the `Pages` folder of the RCL.

  ```csharp
  var module = await JS.InvokeAsync<IJSObjectReference>("import", 
      "./_content/AppJS/Pages/Index.razor.js");
  ```
