---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
*This section only applies to Blazor Server apps. In Blazor WebAssembly, the framework doesn't impose a limit on the size of JavaScript (JS) interop inputs and outputs.*

In Blazor Server, JS interop calls are limited in size by the maximum incoming SignalR message size permitted for hub methods, which is enforced by <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize?displayProperty=nameWithType> (default: 32 KB). JS to .NET SignalR messages larger than <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> throw an error. The framework doesn't impose a limit on the size of a SignalR message from the hub to a client.

When SignalR logging isn't set to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel), a message size error only appears in the browser's developer tools console:

> Error: Connection disconnected with error 'Error: Server returned an error on close: Connection closed with an error.'.

When [SignalR server-side logging](xref:signalr/diagnostics#server-side-logging) is set to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel), server-side logging surfaces an <xref:System.IO.InvalidDataException> for a message size error.

`appsettings.Development.json`:

```json
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information",
      "Microsoft.AspNetCore.SignalR": "Debug"
    }
  }
}
```

Error:

> System.IO.InvalidDataException: The maximum message size of 32768B was exceeded. The message size can be configured in AddHubOptions.

Increase the limit by setting <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> in `Program.cs`. The following example sets the maximum receive message size to 64 KB (64 * 1024):

```csharp
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options => options.MaximumReceiveMessageSize = 64 * 1024);
```

Increasing the SignalR incoming message size limit comes at the cost of requiring more server resources, and it exposes the server to increased risks from a malicious user. Additionally, reading a large amount of content in to memory as strings or byte arrays can also result in allocations that work poorly with the garbage collector, resulting in additional performance penalties.

Consider the following guidance when developing code that transfers a large amount of data between JS and Blazor in Blazor Server apps:

* Leverage the native streaming interop support to transfer data larger than the SignalR incoming message size limit:
  * <xref:blazor/js-interop/call-javascript-from-dotnet#stream-from-net-to-javascript>
  * <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net>
* General tips:
  * Don't allocate large objects in JS and C# code.
  * Free consumed memory when the process is completed or cancelled.
  * Enforce the following additional requirements for security purposes:
    * Declare the maximum file or data size that can be passed.
    * Declare the minimum upload rate from the client to the server.
  * After the data is received by the server, the data can be:
    * Temporarily stored in a memory buffer until all of the segments are collected.
    * Consumed immediately. For example, the data can be stored immediately in a database or written to disk as each segment is received.
