:::moniker range="= aspnetcore-9.0"

## What is SignalR?

ASP.NET Core SignalR is an open-source library that simplifies adding real-time web functionality to apps. Real-time web functionality enables server-side code to push content to clients instantly.

Good candidates for SignalR:

* Apps that require high frequency updates from the server. Examples are gaming, social networks, voting, auction, maps, and GPS apps.
* Dashboards and monitoring apps. Examples include company dashboards, instant sales updates, or travel alerts.
* Collaborative apps. Whiteboard apps and team meeting software are examples of collaborative apps.
* Apps that require notifications. Social networks, email, chat, games, travel alerts, and many other apps use notifications.

SignalR provides an API for creating server-to-client [remote procedure calls (RPC)](https://wikipedia.org/wiki/Remote_procedure_call). The RPCs invoke functions on clients from server-side .NET code. There are several [supported platforms](xref:signalr/supported-platforms), each with their respective client SDK. Because of this, the programming language being invoked by the RPC call varies.

Here are some features of SignalR for ASP.NET Core:

* Handles connection management automatically.
* Sends messages to all connected clients simultaneously. For example, a chat room.
* Sends messages to specific clients or groups of clients.
* Scales to handle increasing traffic with options such as the [Azure SignalR Service](xref:signalr/scale) and [Redis backplane](xref:signalr/redis-backplane).
* Supports trimming and native ahead-of-time (AOT) compilation for supported scenarios.
* Supports polymorphic type handling in hub methods.
* Supports distributed tracing with `ActivitySource` for SignalR hub server and .NET client.
* [SignalR Hub Protocol](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/HubProtocol.md)

The source is hosted in a [SignalR repository on GitHub](https://github.com/dotnet/AspNetCore/tree/main/src/SignalR).

## Transports

SignalR supports the following techniques for handling real-time communication (in order of graceful fallback):

* [WebSockets](xref:fundamentals/websockets)
* Server-Sent Events
* Long Polling

SignalR automatically chooses the best transport method that is within the capabilities of the server and client. WebSockets is the preferred transport because it generally provides the best performance.

## Hubs

SignalR uses *hubs* to communicate between clients and servers.

A hub is a high-level pipeline that allows a client and server to call methods on each other. SignalR handles the dispatching across machine boundaries automatically, allowing clients to call methods on the server and vice versa. You can pass strongly-typed parameters to methods, which enables model binding. SignalR supports two built-in hub protocols: a text protocol based on JSON (default) and a binary protocol based on MessagePack. MessagePack generally creates smaller messages compared to JSON. For more information, see <xref:signalr/messagepackhubprotocol>.

Hubs call client-side code by sending messages that contain the name and parameters of the client-side method. Objects sent as method parameters are deserialized using the configured protocol. The client tries to match the name to a method in the client-side code. When the client finds a match, it calls the method and passes to it the deserialized parameter data.

## Additional resources

* [Get started with SignalR for ASP.NET Core](xref:tutorials/signalr)
* [Supported Platforms](xref:signalr/supported-platforms)
* [Hubs](xref:signalr/hubs)
* [Logging and diagnostics in ASP.NET Core SignalR](xref:signalr/diagnostics)
* [Hosting and scaling ASP.NET Core SignalR](xref:signalr/scale)
* [JavaScript client](xref:signalr/javascript-client)
* <xref:blazor/fundamentals/signalr>

:::moniker-end
