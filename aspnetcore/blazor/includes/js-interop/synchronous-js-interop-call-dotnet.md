*This section only applies to Blazor WebAssembly apps.*

JS interop calls are asynchronous by default, regardless of whether the called code is synchronous or asynchronous. Calls are asynchronous by default to ensure that components are compatible across both Blazor hosting models, Blazor Server and Blazor WebAssembly. On Blazor Server, all JS interop calls must be asynchronous because they're sent over a network connection.

If you know for certain that your app only ever runs on Blazor WebAssembly, you can choose to make synchronous JS interop calls. This has slightly less overhead than making asynchronous calls and can result in fewer render cycles because there's no intermediate state while awaiting results.

To make a synchronous call from JavaScript to .NET in Blazor WebAssembly apps, use `DotNet.invokeMethod` instead of `DotNet.invokeMethodAsync`.

Synchronous calls work if:

* The app is running on Blazor WebAssembly, not Blazor Server.
* The called function returns a value synchronously. The function isn't an `async` method and doesn't return a .NET <xref:System.Threading.Tasks.Task> or JavaScript [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise).
