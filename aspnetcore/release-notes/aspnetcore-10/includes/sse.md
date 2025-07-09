### Support for Server-Sent Events (SSE)

ASP.NET Core now supports returning a [ServerSentEvents](xref:System.Net.ServerSentEvents) result using the [TypedResults.ServerSentEvents](https://source.dot.net/#Microsoft.AspNetCore.Http.Results/TypedResults.cs,051e6796e1492f84) API. This feature is supported in both Minimal APIs and controller-based apps.

Server-Sent Events is a server push technology that allows a server to send a stream of event messages to a client over a single HTTP connection. In .NET the event messages are represented as [`SseItem<T>`](/dotnet/api/system.net.serversentevents.sseitem-1) objects, which may contain an event type, an ID, and a data payload of type `T`.

The [TypedResults](xref:Microsoft.AspNetCore.Http.TypedResults) class has a new static method called [ServerSentEvents](https://source.dot.net/#Microsoft.AspNetCore.Http.Results/TypedResults.cs,ceb980606eb9e295) that can be used to return a `ServerSentEvents` result. The first parameter to this method is an `IAsyncEnumerable<SseItem<T>>` that represents the stream of event messages to be sent to the client.

The following example illustrates how to use the `TypedResults.ServerSentEvents` API to return a stream of heart rate events as JSON objects to the client:

:::code language="csharp" source="~/fundamentals/minimal-apis/10.0-samples/MinimalServerSentEvents/Program.cs" id="snippet_json" :::

For more information, see:

- [Server-Sent Events](https://developer.mozilla.org/docs/Web/API/Server-sent_events) on MDN.
- [Minimal API sample app](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/fundamentals/minimal-apis/10.0-samples/MinimalServerSentEvents/Program.cs) using the `TypedResults.ServerSentEvents` API to return a stream of heart rate events as string, `ServerSentEvents`, and JSON objects to the client.
- [Controller API sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/action-return-types/samples/10/ControllerSSE) using the `TypedResults.ServerSentEvents` API to return a stream of heart rate events as string, `ServerSentEvents`, and JSON objects to the client.
