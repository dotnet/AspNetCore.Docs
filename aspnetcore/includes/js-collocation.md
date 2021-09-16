---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
Collocation of script files in the same folder as pages, views, or Razor components is a convenient way to organize JS code specific to components. Collocated JS files are publicly addressable using the path to the file in the project.

Collocate JavaScript (JS) files using the following filename extension conventions:

* Pages of Razor Pages apps: `.cshtml.js`
* Views of MVC apps: `.cshtml.js`
* Razor components of Blazor apps: `.razor.js`

[JS module](#javascript-isolation-in-javascript-modules) examples:

* `{Pages|Views}/{PAGE, VIEW, OR COMPONENT NAME}.{cshtml|razor}.js` for script files.

  * The `{Pages|Views}` placeholder is either `Pages` for the pages folder of a Razor Pages/Blazor app or `Views` for the views folder of an MVC app.
  * The `{PAGE, VIEW, OR COMPONENT NAME}` placeholder is the name of the page, view, or component.
  * The `{cshtml|razor}` placeholder is either `cshtml` for pages and views or `razor` for a component.

  In the following example, scripts are loaded for the `Index` component (`Pages/Index.razor`) of a Blazor app:

  ```csharp
  var module = await JS.InvokeAsync<IJSObjectReference>("import", 
      "./Pages/Index.razor.js");
  ```
  
  In the following example, scripts are loaded for the `Contact` view (`Views/Contact.cshtml`) of an MVC app:

  ```csharp
  var module = await JS.InvokeAsync<IJSObjectReference>("import", 
      "./Views/Contact.cshtml.js");
  ```

* `_content/{PACKAGE ID}/{Pages|Views}/{PAGE, VIEW, OR COMPONENT NAME}.{cshtml|razor}.js` for scripts provided by a [Razor class library (RCL)](xref:blazor/components/class-libraries).

  * The `{PACKAGE ID}` placeholder is the RCL's package identifier.
  * The `{Pages|Views}` placeholder is either `Pages` for the pages folder of a Razor Pages/Blazor app or `Views` for the views folder of an MVC app.
  * The `{PAGE, VIEW, OR COMPONENT NAME}` placeholder is the name of the page, view, or component.
  * The `{cshtml|razor}` placeholder is either `cshtml` for pages and views or `razor` for a component.

  In the following example, the RCL's package identifier is `AppJS`, and the scripts are loaded for the `Index` component (`Pages/Index.razor`) of a Blazor app:

  ```csharp
  var module = await JS.InvokeAsync<IJSObjectReference>("import", 
      "_content/AppJS/Pages/Index.razor.js");
  ```
  
  In the following example, the RCL's package identifier is `AppJS`, and the scripts are loaded for the `Contact` view (`Views/Contact.cshtml`) of an MVC app:

  ```csharp
  var module = await JS.InvokeAsync<IJSObjectReference>("import", 
      "_content/AppJS/Views/Contact.cshtml.js");
  ```
