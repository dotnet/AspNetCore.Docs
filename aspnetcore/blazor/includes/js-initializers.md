---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
JavaScript (JS) initializers execute logic before and after a Blazor app loads. JS initializers are useful in the following scenarios:

* Customizing how a Blazor app loads.
* Initializing libraries before Blazor starts up.
* Configuring Blazor settings.

To define a JS initializer, add a JS module to the project named `{PACKAGE ID OR LIBRARY NAME}.lib.module.js`, where the `{PACKAGE ID OR LIBRARY NAME}` placeholder is the package identifier or library name. When supplying the module from a Razor class library (RCL), use the RCL's name for the `{PACKAGE ID OR LIBRARY NAME}` placeholder. To consume the module from the app's static assets, any name can be used for the `{PACKAGE ID OR LIBRARY NAME}` placeholder, and the file should be placed in the app's web root, which is typically the `wwwroot` folder.

The module can export the following conventional functions:

* `beforeStart`: Called before Blazor starts on the .NET side. For example, `beforeStart` is used to customize the loading process, logging level, and other options specific to the hosting model.
  * In Blazor WebAssembly, `beforeStart` receives the Blazor WebAssembly options and any extensions added during publishing.
  * In Blazor Server, `beforeStart` receives the circuit start options.
  * In `BlazorWebViews`, no options are passed.
* `afterStarted`: Called after Blazor is ready to receive calls from JS. For example, `afterStarted` is used to initialize libraries by making JS interop calls and registering custom elements. The Blazor instance is always passed to `afterStarted` as an argument.

The following demonstrates example JS initializers.

`RazorClassLibrary1.lib.module.js`:

```javascript
export function beforeStart(options) {
    console.log("beforeStart");
}

export function afterStarted(blazor) {
    console.log("afterStarted");
}
```

JS initializers are detected as part of the build process and then imported automatically in Blazor apps. Use of JS initializers often removes the need to manually add script references when using Razor class libraries (RCLs).

> [!NOTE]
> MVC and Razor Pages apps don't automatically load JS initializers. However, developer code can include a script to fetch the app's manifest and trigger the load of the JS initializers.
