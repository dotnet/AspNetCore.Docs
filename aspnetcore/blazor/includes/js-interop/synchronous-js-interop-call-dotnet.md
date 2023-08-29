*This section only applies to client-side components.*

JS interop calls are asynchronous by default, regardless of whether the called code is synchronous or asynchronous. Calls are asynchronous by default to ensure that components are compatible across server-side and client-side render modes. On the server, all JS interop calls must be asynchronous because they're sent over a network connection.

If you know for certain that your component only runs on WebAssembly, you can choose to make synchronous JS interop calls. This has slightly less overhead than making asynchronous calls and can result in fewer render cycles because there's no intermediate state while awaiting results.

To make a synchronous call from JavaScript to .NET in a client-side component, use `DotNet.invokeMethod` instead of `DotNet.invokeMethodAsync`.

Synchronous calls work if:

* The component is only rendered for execution on WebAssembly.
* The called function returns a value synchronously. The function isn't an `async` method and doesn't return a .NET <xref:System.Threading.Tasks.Task> or JavaScript [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise).
