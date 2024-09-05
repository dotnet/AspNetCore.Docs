### Improvements to SignalR distributed tracing

.NET 9 preview 6 added [initial support for SignalR distributed tracing](https://github.com/dotnet/core/blob/main/release-notes/9.0/preview/preview6/aspnetcore.md#improved-distributed-tracing-for-signalr). RC1 improves SignalR tracing with new capabilities:

* .NET SignalR client has an `ActivitySource` named "Microsoft.AspNetCore.SignalR.Client". Hub invocations now create a client span. Note that other SignalR clients, such as the JavaScript client, don't support tracing. This feature will be added to more clients in future releases.
* Hub invocations on the client and server support [context propagation](https://opentelemetry.io/docs/concepts/context-propagation/). Propagating the trace context enables true distributed tracing. It's now possible to see invocations flow from the client to the server and back.

Here's how these new activities look in the [.NET Aspire dashboard](https://learn.microsoft.com/dotnet/aspire/fundamentals/dashboard/overview?tabs=bash#standalone-mode):

![SignalR distributed tracing in Aspire dashboard](~/release-notes/aspnetcore-9/_static/signalr-distributed-tracing-aspire-dashboard.png) 
