---
title: Use hubs in ASP.NET Core SignalR
author: wadepickett
description: Learn how to work with hubs in ASP.NET Core SignalR, create and use hubs, send messages to clients, and handle results from connected clients on the server.
monikerRange: '>= aspnetcore-2.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 05/20/2026
uid: signalr/hubs

# customer intent: As an ASP.NET developer, I want to use hubs in ASP.NET Core SignalR, so I can enable real-time communication between connected clients and the server, and indirect client-to-client communication.
---
# Use hubs in ASP.NET Core SignalR

:::moniker range=">= aspnetcore-8.0"

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](https://twitter.com/1kevgriff)

The SignalR Hubs API enables connected clients to call methods on the server, facilitating real-time communication. The server defines methods that are called by the client, and the client defines methods that are called by the server. SignalR also enables indirect client-to-client communication, where the SignalR Hub provides the mediation. This approach allows sending messages between individual clients, groups, or to all connected clients. SignalR takes care of everything required to make real-time client-to-server and server-to-client communication possible.

This article describes how to configure hubs, send messages to clients, and allow servers to handle results from clients.

## Configure SignalR hubs

Register the services required by SignalR hubs by calling the <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A> method in the _Program.cs_ file:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Program.cs" id="snippet_AddSignalR" highlight="4":::

Configure SignalR endpoints by calling the <xref:Microsoft.AspNetCore.Builder.HubEndpointRouteBuilderExtensions.MapHub%2A> method in the _Program.cs_ file:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Program.cs" id="snippet_MapHub" highlight="2":::

[!INCLUDE[](~/includes/signalr-in-shared-framework.md)]

## Create and use hubs

Create a hub by declaring a class that inherits from <xref:Microsoft.AspNetCore.SignalR.Hub>. Add `public` methods to the class to make them callable from clients:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Hubs/ChatHub.cs" id="snippet_Class":::

> [!NOTE]
> Hubs are [transient](/dotnet/core/extensions/dependency-injection/service-lifetimes#transient):
>
> * Don't store state in a property of the hub class. Each hub method call is executed on a new hub instance.
> * Don't instantiate a hub directly via dependency injection. To send messages to a client from elsewhere in your application, use an [IHubContext](xref:signalr/hubcontext).
> * Use `await` when calling asynchronous methods that depend on the hub staying alive. For example, if you call a method such as  `Clients.All.SendAsync(...)` without using `await`, the call can fail and the hub method completes before `SendAsync` finishes.

## Use 'Context' object properties and methods

The <xref:Microsoft.AspNetCore.SignalR.Hub> class includes a <xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A> property that contains the following properties with information about the connection:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionId%2A> | Gets the unique ID for the connection, assigned by SignalR. There's one connection ID for each connection. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.UserIdentifier%2A> | Gets the [user identifier](xref:signalr/groups). By default, SignalR uses the <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> property from the <xref:System.Security.Claims.ClaimsPrincipal> associated with the connection as the user identifier. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.User%2A> | Gets the <xref:System.Security.Claims.ClaimsPrincipal> associated with the current user. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Items%2A> | Gets a key/value collection that can be used to share data within the scope of this connection. Data can be stored in this collection and it persists for the connection across different hub method invocations. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Features%2A> | Gets the collection of features available on the connection. This collection isn't currently needed in most scenarios, so detailed documentation isn't yet available. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionAborted%2A> | Gets a <xref:System.Threading.CancellationToken> that notifies when the connection is aborted. |

The <xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A?displayProperty=nameWithType> property also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.GetHttpContextExtensions.GetHttpContext%2A> | Returns the <xref:Microsoft.AspNetCore.Http.HttpContext> for the connection, or `null` if the connection isn't associated with an HTTP request. For HTTP connections, use this method to get information such as HTTP headers and query strings. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Abort%2A> | Aborts the connection. |

## Use 'Clients' object properties and methods

The <xref:Microsoft.AspNetCore.SignalR.Hub> class includes a <xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A> property that contains the following properties for communication between server and client:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.All%2A> | Calls a method on all connected clients. |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Caller%2A> | Calls a method on the client that invoked the hub method. |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Others%2A> | Calls a method on all connected clients except the client that invoked the method. |

The <xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A?displayProperty=nameWithType> property also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.AllExcept%2A> | Calls a method on all connected clients except for the specified connections. |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Client%2A> | Calls a method on a specific connected client. |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Clients%2A> | Calls a method on specific connected clients. |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Group%2A> | Calls a method on all connections in the specified group. |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.GroupExcept%2A> | Calls a method on all connections in the specified group, except the specified connections. |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Groups%2A> | Calls a method on multiple groups of connections. |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.OthersInGroup%2A> | Calls a method on a group of connections, excluding the client that invoked the hub method. |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.User%2A> | Calls a method on all connections associated with a specific user. |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Users%2A> | Calls a method on all connections associated with the specified users. |

Each property or method returns an object with a `SendAsync` method. The `SendAsync` method receives the name of the client method to call and any parameters.

The object returned by the `Client` and `Caller` methods also contain an `InvokeAsync` method, which can be used to wait for a [result from the client](xref:signalr/hubs#request-client-results).

## Send messages to clients

To make calls to specific clients, use the properties of the `Clients` object. In the following example, there are three hub methods:

* The `SendMessage` method sends a message to all connected clients by using the `Clients.All` property.
* The `SendMessageToCaller` method sends a message back to the caller by using the `Clients.Caller` property.
* The `SendMessageToGroup` method sends a message to all clients in the `SignalR Users` group.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_Clients":::

## Use strongly typed hubs

A drawback of using the `SendAsync` method is that it relies on a string to specify the client method to call. This design leaves code open to runtime errors if the method name is misspelled or missing from the client.

An alternative to using the `SendAsync` method is to strongly type the <xref:Microsoft.AspNetCore.SignalR.Hub> class with <xref:Microsoft.AspNetCore.SignalR.Hub%601>. In the following example, the `ChatHub` client method is extracted into an interface named `IChatClient`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/IChatClient.cs" id="snippet_Interface":::

The interface can be used to refactor the preceding `ChatHub` example to make it strongly typed:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/StronglyTypedChatHub.cs" id="snippet_Class":::

Using `Hub<IChatClient>` enables compile-time checking of the client methods. This approach prevents issues caused by using strings because `Hub<T>` can only provide access to the methods defined in the interface. Using a strongly typed `Hub<T>` disables the ability to use the `SendAsync` method.

> [!NOTE]
> The `Async` suffix isn't stripped from method names. Unless a client method is defined with `.on('MyMethodAsync')`, don't use `MyMethodAsync` as the name.

## Request client results

In addition to making calls to clients, the server can request a result from a client. In this scenario, the server uses the `ISingleClientProxy.InvokeAsync` method and the client returns a result from its `.On` handler.

There are two ways to use the API on the server.

You can call `Client(...)` or `Caller` on the `Clients` property in a `Hub` method:

```csharp
public class ChatHub : Hub
{
    public async Task<string> WaitForMessage(string connectionId)
    {
        var message = await Clients.Client(connectionId).InvokeAsync<string>(
            "GetMessage");
        return message;
    }
}
```

Or, you can call `Client(...)` on an instance of [IHubContext\<T>](xref:signalr/hubcontext):

```csharp
async Task SomeMethod(IHubContext<MyHub> context)
{
    string result = await context.Clients.Client(connectionID).InvokeAsync<string>(
        "GetMessage");
}
```

Strongly typed hubs can also return values from interface methods:

```csharp
public interface IClient
{
    Task<string> GetMessage();
}

public class ChatHub : Hub<IClient>
{
    public async Task<string> WaitForMessage(string connectionId)
    {
        string message = await Clients.Client(connectionId).GetMessage();
        return message;
    }
}
```

Clients return results in their `.On(...)` handlers, as shown in the following sections.

#### .NET client

```csharp
hubConnection.On("GetMessage", async () =>
{
    Console.WriteLine("Enter message:");
    var message = await Console.In.ReadLineAsync();
    return message;
});
```

#### TypeScript client

```typescript
hubConnection.on("GetMessage", async () => {
    let promise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("message");
        }, 100);
    });
    return promise;
});
```

#### Java client

```java
hubConnection.onWithResult("GetMessage", () -> {
    return Single.just("message");
});
```

## Change the name of a hub method

By default, a server hub method name is the name of the .NET method. To change this default behavior for a specific method, use the [HubMethodName](xref:Microsoft.AspNetCore.SignalR.HubMethodNameAttribute) attribute. The client should use this name instead of the .NET method name when invoking the method:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_HubMethodName" highlight="1":::

## Inject services into a hub

Hub constructors can accept services from dependency injection as parameters, which can be stored in properties on the class for use in a hub method.

When you inject multiple services for different hub methods or as an alternative way of writing code, hub methods can also accept services from dependency injection. By default, hub method parameters are inspected and resolved from dependency injection if possible.

```csharp
services.AddSingleton<IDatabaseService, DatabaseServiceImpl>();

// ...

public class ChatHub : Hub
{
    public Task SendMessage(string user, string message, IDatabaseService dbService)
    {
        var userName = dbService.GetUserName(user);
        return Clients.All.SendAsync("ReceiveMessage", userName, message);
    }
}
```

If implicit resolution of parameters from services isn't desired, you can disable the behavior with the [DisableImplicitFromServicesParameters](xref:signalr/configuration#configure-server-options) server option.

To explicitly specify which parameters are resolved from dependency injection in hub methods, use the [DisableImplicitFromServicesParameters](/dotnet/api/microsoft.aspnetcore.signalr.huboptions.disableimplicitfromservicesparameters) property. Specify the `[FromServices]` attribute or a custom attribute that implements `IFromServiceMetadata` on the hub method parameters that should be resolved from dependency injection.

```csharp
services.AddSingleton<IDatabaseService, DatabaseServiceImpl>();
services.AddSignalR(options =>
{
    options.DisableImplicitFromServicesParameters = true;
});

// ...

public class ChatHub : Hub
{
    public Task SendMessage(string user, string message,
        [FromServices] IDatabaseService dbService)
    {
        var userName = dbService.GetUserName(user);
        return Clients.All.SendAsync("ReceiveMessage", userName, message);
    }
}
```

> [!NOTE]
> This feature makes use of <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService>, which is optionally implemented in dependency injection configurations. If the application dependency injection container doesn't support this feature, injecting services into hub methods isn't supported.

### Keyed services support in dependency injection

The keyed services mechanism allows you to register and retrieve dependency injection services by using keys. A service is associated with a key by calling the  <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddKeyedSingleton%2A> method to register it. As an alternative, you can call the `AddKeyedScoped` or `AddKeyedTransient` method.

You access a registered service by specifying the key with the [[FromKeyedServices](xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute)] attribute. The following code shows how to use keyed services:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/KeyedSvsHub/Program.cs" highlight="5-6,34,39":::

## Limit per-connection streaming invocations

`<xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumParallelInvocationsPerClient> controls the number of non-streaming hub method invocations a client can run in parallel before they are queued. It does **not** apply to streaming hub invocations. Streaming invocations are intentionally excluded because they are expected to be long-running and concurrent, so a client can start any number of concurrent streams regardless of that setting.

To enforce a per-connection limit on streaming invocations, wrap the stream inside the hub method itself using a private helper that increments a counter before yielding items and decrements it in a `finally` block:

```csharp
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

public class StreamingHub : Hub
{
    // Track the number of active streams per connection.
    private static readonly ConcurrentDictionary<string, int> _activeStreams = new();
    private const int MaxConcurrentStreams = 2;

    public IAsyncEnumerable<int> Counter(
        int count,
        int delay,
        CancellationToken cancellationToken)
    {
        return WithLimit(GetCounter(count, delay, cancellationToken));
    }

    private async IAsyncEnumerable<int> GetCounter(
        int count,
        int delay,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        for (var i = 0; i < count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return i;
            await Task.Delay(delay, cancellationToken);
        }
    }

    private async IAsyncEnumerable<int> WithLimit(
        IAsyncEnumerable<int> stream,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var connectionId = Context.ConnectionId;

        var current = _activeStreams.AddOrUpdate(
            connectionId,
            addValue: 1,
            updateValueFactory: (_, count) => count + 1);

        if (current > MaxConcurrentStreams)
        {
            _activeStreams.AddOrUpdate(
                connectionId,
                addValue: 0,
                updateValueFactory: (_, count) => Math.Max(0, count - 1));

            throw new HubException(
                $"The connection is limited to {MaxConcurrentStreams} concurrent streaming invocations.");
        }

        try
        {
            await foreach (var item in stream.WithCancellation(cancellationToken))
            {
                yield return item;
            }
        }
        finally
        {
            _activeStreams.AddOrUpdate(
                connectionId,
                addValue: 0,
                updateValueFactory: (_, count) => Math.Max(0, count - 1));
        }
    }
}
```

The key point is that `WithLimit` wraps the original `IAsyncEnumerable<T>` and holds the counter elevated for the *full lifetime of the stream*, not just until the first item is yielded.
The `finally` block runs only when the client finishes consuming the stream, cancels it, or the connection drops.

> [!NOTE]
> The `_activeStreams` dictionary is `static` so it is shared across all hub instances for
a given connection. If you prefer DI-managed state, register a singleton service that owns
> the dictionary and inject it into the hub constructor.

## Handle events for a connection

The SignalR Hubs API provides the <xref:Microsoft.AspNetCore.SignalR.Hub.OnConnectedAsync%2A> and <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A> virtual methods to manage and track connections. Override the `OnConnectedAsync` virtual method to perform actions when a client connects to the hub, such as adding it to a group:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_OnConnectedAsync":::

Override the `OnDisconnectedAsync` virtual method to perform actions when a client disconnects. If the client disconnects intentionally, such as by calling `connection.stop()`, the `exception` parameter is set to `null`. However, if the client disconnects due to an error, such as a network failure, the `exception` parameter contains an exception that describes the failure:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_OnDisconnectedAsync":::

The <xref:Microsoft.AspNetCore.SignalR.IGroupManager.RemoveFromGroupAsync%2A> method doesn't need to be called within the <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A> method because it's handled automatically.

## Handle errors

Exceptions thrown in hub methods are sent to the client that invoked the method. On the JavaScript client, the `invoke` method returns a [JavaScript 'Promise' object](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Using_promises). Clients can attach a `catch` handler to the returned promise or use `try`/`catch` with `async`/`await` to handle exceptions:

:::code language="JavaScript" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/wwwroot/chat.js" id="snippet_TryCatch":::

Connections aren't closed when a hub throws an exception. By default, SignalR returns a generic error message to the client, as shown in the following example:

```output
Microsoft.AspNetCore.SignalR.HubException: An unexpected error occurred invoking 'SendMessage' on the server.
```

Unexpected exceptions often contain sensitive information, such as the name of a database server in an exception triggered when the database connection fails. As a security measure, SignalR doesn't expose these detailed error messages by default. For more information on why exception details are suppressed, see [Security considerations in ASP.NET Core SignalR](xref:signalr/security#exceptions).

If an exceptional condition must be propagated to the client, use the <xref:Microsoft.AspNetCore.SignalR.HubException> class. If a `HubException` is thrown in a hub method, SignalR **sends the entire exception message to the client** in an unmodified form:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_ThrowException":::

> [!NOTE]
> SignalR only sends the `Message` property of the exception to the client. The stack trace and other properties on the exception aren't available to the client.

## Related content

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/signalr/hubs/samples/) [(how to download)](xref:fundamentals/index#how-to-download-a-sample)
* <xref:signalr/introduction>
* <xref:signalr/javascript-client>
* <xref:signalr/publish-to-azure-web-app>

:::moniker-end

[!INCLUDE[](~/signalr/hubs/includes/hubs-7.md)]

[!INCLUDE[](~/signalr/hubs/includes/hubs-6.md)]

[!INCLUDE[](~/signalr/hubs/includes/hubs-3-5.md)]

[!INCLUDE[](~/signalr/hubs/includes/hubs-2.1.md)]
