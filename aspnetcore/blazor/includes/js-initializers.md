---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
JavaScript (JS) initializers execute logic before and after a Blazor app loads. JS initializers are useful in the following scenarios:

* Customizing how a Blazor app loads.
* Initializing libraries before Blazor starts up.
* Configuring Blazor settings.

JS initializers are detected as part of the build process and imported automatically in Blazor apps. Use of JS initializers often removes the need to manually add script references when using Razor class libraries (RCLs).

To define a JS initializer, add a JS module to the project named `{NAME}.lib.module.js`, where the `{NAME}` placeholder is the assembly name, library name, or package identifier. Place the file in the project's web root, which is typically the `wwwroot` folder.

The module exports either or both of the following conventional functions:

* `beforeStart`: Called before Blazor starts. For example, `beforeStart` is used to customize the loading process, logging level, and other options specific to the hosting model.
  * In Blazor WebAssembly, `beforeStart` receives the Blazor WebAssembly options and any extensions added during publishing.
  * In Blazor Server, `beforeStart` receives the circuit start options.
  * In [`BlazorWebViews`](/mobile-blazor-bindings/walkthroughs/hybrid-hello-world#mainrazor-native-ui-page), no options are passed.
* `afterStarted`: Called after Blazor is ready to receive calls from JS. For example, `afterStarted` is used to initialize libraries by making JS interop calls and registering custom elements. The Blazor instance is passed to `afterStarted` as an argument.

The following example demonstrates JS initializers for `beforeStart` and `afterStarted`. For the filename of the following example:

* Use the app's assembly name in the filename if the JS initializers are consumed as a static asset in the project. For example, name the file `BlazorSample.lib.module.js` for a project with an assembly name of `BlazorSample`. Place the file in the app's `wwwroot` folder.
* Use the project's library name or package identifier if the JS initializers are consumed from an RCL. For example, name the file `RazorClassLibrary1.lib.module.js` for an RCL with a package identifier of `RazorClassLibrary1`. Place the file in the library's `wwwroot` folder.

```javascript
export function beforeStart(options) {
    console.log("beforeStart");
}

export function afterStarted(blazor) {
    console.log("afterStarted");
}
```

> [!NOTE]
> MVC and Razor Pages apps don't automatically load JS initializers. However, developer code can include a script to fetch the app's manifest and trigger the load of the JS initializers.
