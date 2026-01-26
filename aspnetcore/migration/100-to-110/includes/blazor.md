### Blazor release notes

For new feature coverage, see <xref:aspnetcore-11>.

### Adopt Inline JS event handler removed from the `NavMenu` component

*This section only applies to Blazor Web Apps.*

The inline JS event handler for the navigation bar toggler isn't present in the `NavMenu` component of the Blazor Web App project template in .NET 11 or later. Apps generated from the project template use a [collocated JS module](xref:blazor/js-interop/javascript-location#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) approach to show or hide the navigation links on the rendered page. The approach improves [Content Security Policy (CSP) compliance](xref:blazor/security/content-security-policy) because it doesn't require the CSP to include an unsafe hash for the inline JS.

Use the following instructions to adopt the new JS module approach for the navigation links toggler in an existing app.

Add a [collocated JS module](xref:blazor/js-interop/javascript-location#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) next to the app's `NavMenu` component.

`NavMenu.razor.js`:

```javascript
// Handle navigation menu toggle
const navScrollable = document.getElementById("nav-scrollable");
const navToggler = document.querySelector(".navbar-toggler");

if (navScrollable && navToggler) {
    navScrollable.addEventListener("click", function() {
        navToggler.click();
    });
}
```

At the top of the app's `NavMenu` component (`NavMenu.razor`), add a `<script>` tag for the collocated JS module:

* If the app adopts client-side rendering (has a `.Client` project) with global interactivity (the render mode is set globally for the app by the app's `App` component), use the following tag, which indicates the path to the module in the `Layout` folder:

```razor
<script type="module" src="@Assets["Layout/NavMenu.razor.js"]"></script>
```

* Otherwise, use the following tag, which indicates the path to the module in the `Components/Layout` folder:

```razor
<script type="module" src="@Assets["Components/Layout/NavMenu.razor.js"]"></script>
```

Also in the app's `NavMenu` component, change the line that has the inline JS to toggle the navigation links:

```diff
- <div class="nav-scrollable" onclick="document.querySelector('.navbar-toggler').click()">
+ <div id="nav-scrollable" class="nav-scrollable">
```

If the app has a [Content Security Policy (CSP)](xref:blazor/security/content-security-policy#server-side-blazor-apps) with an unsafe hash for the inline JS removed by the preceding step, remove the unsafe hash:

```diff
- 'unsafe-hashes' 'sha256-qnHnQs7NjQNHHNYv/I9cW+I62HzDJjbnyS/OFzqlix0='
```
