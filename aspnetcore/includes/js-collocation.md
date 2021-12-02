---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
Collocation of JavaScript (JS) files for pages, views, and Razor components is a convenient way to organize scripts in an app.

Collocate JS files using the following filename extension conventions:

* Pages of Razor Pages apps and views of MVC apps: `.cshtml.js`. Examples:
  * `Pages/Contact.cshtml.js` for the `Contact` page of a Razor Pages app at `Pages/Contact.cshtml`.
  * `Views/Home/Contact.cshtml.js` for the `Contact` view of an MVC app at `Views/Home/Contact.cshtml`.
* Razor components of Blazor apps: `.razor.js`. Example: `Pages/Index.razor.js` for the `Index` component at `Pages/Index.razor`.

Collocated JS files are publicly addressable using the path to the file in the project:

* Pages, views, and components from a collocated scripts file in the app:

  `{PATH}/{PAGE, VIEW, OR COMPONENT}.{EXTENSION}`
  
  * The `{PATH}` placeholder is the path to the page, view, or component.
  * The `{PAGE, VIEW, OR COMPONENT}` placeholder is the page, view, or component.
  * The `{EXTENSION}` placeholder matches the extension of the page, view, or component, either `razor` or `cshtml`, followed by `.js`.
  
  In the following example from a Razor Pages app, the script is collocated in the `Pages` folder with the `Contact` page (`Pages/Contact.cshtml`):

  ```razor
  @section Scripts {
    <script src="~/Pages/Contact.cshtml.js"></script>
  }
  ```

* For scripts provided by a Razor class library (RCL):

  `_content/{PACKAGE ID}/{PATH}/{PAGE, VIEW, OR COMPONENT}.{EXTENSION}`

  * The `{PACKAGE ID}` placeholder is the RCL's package identifier (or library name for a class library referenced by the app).
  * The `{PATH}` placeholder is the path to the page, view, or component. If a Razor component is located at the root of the RCL, the path segment isn't included.
  * The `{PAGE, VIEW, OR COMPONENT}` placeholder is the page, view, or component.
  * The `{EXTENSION}` placeholder matches the extension of page, view, or component, either `razor` or `cshtml`, followed by `.js`.

  In the following Blazor app example:
  
  * The RCL's package identifier is `AppJS`.
  * A module's scripts are loaded for the `Index` component (`Index.razor`).
  * The `Index` component is in the `Pages` folder of the RCL.

  ```csharp
  var module = await JS.InvokeAsync<IJSObjectReference>("import", 
      "./_content/AppJS/Pages/Index.razor.js");
  ```
