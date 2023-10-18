---
title: Use hubs in ASP.NET Core SignalR
author: bradygaster
description: Learn how to use hubs in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 02/14/2023
uid: signalr/hubs
---

# Use hubs in SignalR for ASP.NET Core

:::moniker range=">= aspnetcore-7.0"

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](https://twitter.com/1kevgriff)

The SignalR Hubs API enables connected clients to call methods on the server. The server defines methods that are called from the client and the client defines methods that are called from the server. SignalR takes care of everything required to make real-time client-to-server and server-to-client communication possible.

## Configure SignalR hubs

To register the services required by SignalR hubs, call <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A> in `Program.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Program.cs" id="snippet_AddSignalR" highlight="4":::

To configure SignalR endpoints, call <xref:Microsoft.AspNetCore.Builder.HubEndpointRouteBuilderExtensions.MapHub%2A>, also in `Program.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Program.cs" id="snippet_MapHub" highlight="2":::

[!INCLUDE[](~/includes/signalr-in-shared-framework.md)]

## Create and use hubs

Create a hub by declaring a class that inherits from <xref:Microsoft.AspNetCore.SignalR.Hub>. Add `public` methods to the class to make them callable from clients:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Hubs/ChatHub.cs" id="snippet_Class":::

> [!NOTE]
> Hubs are [transient](/dotnet/core/extensions/dependency-injection#transient):
>
> * Don't store state in a property of the hub class. Each hub method call is executed on a new hub instance.
> * Don't instantiate a hub directly via dependency injection. To send messages to a client from elsewhere in your application use an [`IHubContext`](xref:signalr/hubcontext).
> * Use `await` when calling asynchronous methods that depend on the hub staying alive. For example, a method such as `Clients.All.SendAsync(...)` can fail if it's called without `await` and the hub method completes before `SendAsync` finishes.

## The Context object

The <xref:Microsoft.AspNetCore.SignalR.Hub> class includes a <xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A> property that contains the following properties with information about the connection:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionId%2A> | Gets the unique ID for the connection, assigned by SignalR. There's one connection ID for each connection. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.UserIdentifier%2A> | Gets the [user identifier](xref:signalr/groups). By default, SignalR uses the <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> from the <xref:System.Security.Claims.ClaimsPrincipal> associated with the connection as the user identifier. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.User%2A> | Gets the <xref:System.Security.Claims.ClaimsPrincipal> associated with the current user. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Items%2A> | Gets a key/value collection that can be used to share data within the scope of this connection. Data can be stored in this collection and it will persist for the connection across different hub method invocations. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Features%2A> | Gets the collection of features available on the connection. For now, this collection isn't needed in most scenarios, so it isn't documented in detail yet. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionAborted%2A> | Gets a <xref:System.Threading.CancellationToken> that notifies when the connection is aborted. |

<xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A?displayProperty=nameWithType> also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.GetHttpContextExtensions.GetHttpContext%2A> | Returns the <xref:Microsoft.AspNetCore.Http.HttpContext> for the connection, or `null` if the connection isn't associated with an HTTP request. For HTTP connections, use this method to get information such as HTTP headers and query strings. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Abort%2A> | Aborts the connection. |

## The Clients object

The <xref:Microsoft.AspNetCore.SignalR.Hub> class includes a <xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A> property that contains the following properties for communication between server and client:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.All%2A> | Calls a method on all connected clients |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Caller%2A> | Calls a method on the client that invoked the hub method |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Others%2A> | Calls a method on all connected clients except the client that invoked the method |

<xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A?displayProperty=nameWithType> also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.AllExcept%2A> | Calls a method on all connected clients except for the specified connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Client%2A> | Calls a method on a specific connected client |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Clients%2A> | Calls a method on specific connected clients |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Group%2A> | Calls a method on all connections in the specified group |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.GroupExcept%2A> | Calls a method on all connections in the specified group, except the specified connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Groups%2A> | Calls a method on multiple groups of connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.OthersInGroup%2A> | Calls a method on a group of connections, excluding the client that invoked the hub method |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.User%2A> | Calls a method on all connections associated with a specific user |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Users%2A> | Calls a method on all connections associated with the specified users |

Each property or method in the preceding tables returns an object with a `SendAsync` method. The `SendAsync` method receives the name of the client method to call and any parameters.

The object returned by the `Client` and `Caller` methods also contain an `InvokeAsync` method, which can be used to wait for a [result from the client](xref:signalr/hubs#client-results).

## Send messages to clients

To make calls to specific clients, use the properties of the `Clients` object. In the following example, there are three hub methods:

* `SendMessage` sends a message to all connected clients, using `Clients.All`.
* `SendMessageToCaller` sends a message back to the caller, using `Clients.Caller`.
* `SendMessageToGroup` sends a message to all clients in the `SignalR Users` group.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_Clients":::

## Strongly typed hubs

A drawback of using `SendAsync` is that it relies on a string to specify the client method to be called. This leaves code open to runtime errors if the method name is misspelled or missing from the client.

An alternative to using `SendAsync` is to strongly type the <xref:Microsoft.AspNetCore.SignalR.Hub> class with <xref:Microsoft.AspNetCore.SignalR.Hub%601>. In the following example, the `ChatHub` client method has been extracted out into an interface called `IChatClient`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/IChatClient.cs" id="snippet_Interface":::

This interface can be used to refactor the preceding `ChatHub` example to be strongly typed:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/StronglyTypedChatHub.cs" id="snippet_Class":::

Using `Hub<IChatClient>` enables compile-time checking of the client methods. This prevents issues caused by using strings, since `Hub<T>` can only provide access to the methods defined in the interface. Using a strongly typed `Hub<T>` disables the ability to use `SendAsync`.

> [!NOTE]
> The `Async` suffix isn't stripped from method names. Unless a client method is defined with `.on('MyMethodAsync')`, don't use `MyMethodAsync` as the name.

## Client results

In addition to making calls to clients, the server can request a result from a client. This requires the server to use `ISingleClientProxy.InvokeAsync` and the client to return a result from its `.On` handler.

There are two ways to use the API on the server, the first is to call `Client(...)` or `Caller` on the `Clients` property in a Hub method:

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

The second way is to call `Client(...)` on an instance of [`IHubContext<T>`](xref:signalr/hubcontext):

```csharp
async Task SomeMethod(IHubContext<MyHub> context)
{
    string result = await context.Clients.Client(connectionID).InvokeAsync<string>(
        "GetMessage");
}
```

Strongly-typed hubs can also return values from interface methods:

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

Clients return results in their `.On(...)` handlers, as shown below:

#### .NET client

```csharp
hubConnection.On("GetMessage", async () =>
{
    Console.WriteLine("Enter message:");
    var message = await Console.In.ReadLineAsync();
    return message;
});
```

#### Typescript client

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

Hub constructors can accept services from DI as parameters, which can be stored in properties on the class for use in a hub method.

When injecting multiple services for different hub methods or as an alternative way of writing code, hub methods can also accept services from DI.
By default, hub method parameters are inspected and resolved from DI if possible.

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

If implicit resolution of parameters from services isn't desired, disable it with [DisableImplicitFromServicesParameters](xref:signalr/configuration#configure-server-options).
To explicitly specify which parameters are resolved from DI in hub methods, use the [`DisableImplicitFromServicesParameters`](/dotnet/api/microsoft.aspnetcore.signalr.huboptions.disableimplicitfromservicesparameters) option and use the `[FromServices]` attribute or a custom attribute that implements `IFromServiceMetadata` on the hub method parameters that should be resolved from DI.

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
> This feature makes use of <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService>, which is optionally implemented by DI implementations. If the app's DI container doesn't support this feature, injecting services into hub methods isn't supported.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

### Keyed services support in Dependency Injection

*Keyed services* refers to a mechanism for registering and retrieving Dependency Injection (DI) services using keys. A service is associated with a key by calling <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddKeyedSingleton%2A> (or `AddKeyedScoped` or `AddKeyedTransient`) to register it. Access a registered service by specifying the key with the [`[FromKeyedServices]`](xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute) attribute. The following code shows how to use keyed services:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/KeyedSvsHub/Program.cs" highlight="5-6,34,39":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Handle events for a connection

The SignalR Hubs API provides the <xref:Microsoft.AspNetCore.SignalR.Hub.OnConnectedAsync%2A> and <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A> virtual methods to manage and track connections. Override the `OnConnectedAsync` virtual method to perform actions when a client connects to the hub, such as adding it to a group:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_OnConnectedAsync":::

Override the `OnDisconnectedAsync` virtual method to perform actions when a client disconnects. If the client disconnects intentionally, such as by calling `connection.stop()`, the `exception` parameter is set to `null`. However, if the client disconnects due to an error, such as a network failure, the `exception` parameter contains an exception that describes the failure:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_OnDisconnectedAsync":::

<xref:Microsoft.AspNetCore.SignalR.IGroupManager.RemoveFromGroupAsync%2A> does not need to be called in <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A>, it's automatically handled for you.
## Handle errors

Exceptions thrown in hub methods are sent to the client that invoked the method. On the JavaScript client, the `invoke` method returns a [JavaScript `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Using_promises). Clients can attach a `catch` handler to the returned promise or use `try`/`catch` with `async`/`await` to handle exceptions:

:::code language="JavaScript" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/wwwroot/chat.js" id="snippet_TryCatch":::

Connections aren't closed when a hub throws an exception. By default, SignalR returns a generic error message to the client, as shown in the following example:

```text
Microsoft.AspNetCore.SignalR.HubException: An unexpected error occurred invoking 'SendMessage' on the server.
```

Unexpected exceptions often contain sensitive information, such as the name of a database server in an exception triggered when the database connection fails. SignalR doesn't expose these detailed error messages by default as a security measure. For more information on why exception details are suppressed, see [Security considerations in ASP.NET Core SignalR](xref:signalr/security#exceptions).

If an exceptional condition must be propagated to the client, use the <xref:Microsoft.AspNetCore.SignalR.HubException> class. If a `HubException` is thrown in a hub method, SignalR **sends the entire exception message to the client**, unmodified:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_ThrowException":::

> [!NOTE]
> SignalR only sends the `Message` property of the exception to the client. The stack trace and other properties on the exception aren't available to the client.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/signalr/hubs/samples/) [(how to download)](xref:index#how-to-download-a-sample)
* <xref:signalr/introduction>
* <xref:signalr/javascript-client>
* <xref:signalr/publish-to-azure-web-app>

:::moniker-end

:::moniker range="= aspnetcore-6.0"

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](https://twitter.com/1kevgriff)

The SignalR Hubs API enables connected clients to call methods on the server. The server defines methods that are called from the client and the client defines methods that are called from the server. SignalR takes care of everything required to make real-time client-to-server and server-to-client communication possible.

## Configure SignalR hubs

To register the services required by SignalR hubs, call <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A> in `Program.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Program.cs" id="snippet_AddSignalR" highlight="4":::

To configure SignalR endpoints, call <xref:Microsoft.AspNetCore.Builder.HubEndpointRouteBuilderExtensions.MapHub%2A>, also in `Program.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Program.cs" id="snippet_MapHub" highlight="2":::

[!INCLUDE[](~/includes/signalr-in-shared-framework.md)]

## Create and use hubs

Create a hub by declaring a class that inherits from <xref:Microsoft.AspNetCore.SignalR.Hub>. Add `public` methods to the class to make them callable from clients:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Hubs/ChatHub.cs" id="snippet_Class":::

> [!NOTE]
> Hubs are [transient](/dotnet/core/extensions/dependency-injection#transient):
>
> * Don't store state in a property of the hub class. Each hub method call is executed on a new hub instance.
> * Don't instantiate a hub directly via dependency injection. To send messages to a client from elsewhere in your application use an [`IHubContext`](xref:signalr/hubcontext).
> * Use `await` when calling asynchronous methods that depend on the hub staying alive. For example, a method such as `Clients.All.SendAsync(...)` can fail if it's called without `await` and the hub method completes before `SendAsync` finishes.

## The Context object

The <xref:Microsoft.AspNetCore.SignalR.Hub> class includes a <xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A> property that contains the following properties with information about the connection:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionId%2A> | Gets the unique ID for the connection, assigned by SignalR. There's one connection ID for each connection. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.UserIdentifier%2A> | Gets the [user identifier](xref:signalr/groups). By default, SignalR uses the <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> from the <xref:System.Security.Claims.ClaimsPrincipal> associated with the connection as the user identifier. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.User%2A> | Gets the <xref:System.Security.Claims.ClaimsPrincipal> associated with the current user. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Items%2A> | Gets a key/value collection that can be used to share data within the scope of this connection. Data can be stored in this collection and it will persist for the connection across different hub method invocations. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Features%2A> | Gets the collection of features available on the connection. For now, this collection isn't needed in most scenarios, so it isn't documented in detail yet. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionAborted%2A> | Gets a <xref:System.Threading.CancellationToken> that notifies when the connection is aborted. |

<xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A?displayProperty=nameWithType> also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.GetHttpContextExtensions.GetHttpContext%2A> | Returns the <xref:Microsoft.AspNetCore.Http.HttpContext> for the connection, or `null` if the connection isn't associated with an HTTP request. For HTTP connections, use this method to get information such as HTTP headers and query strings. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Abort%2A> | Aborts the connection. |

## The Clients object

The <xref:Microsoft.AspNetCore.SignalR.Hub> class includes a <xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A> property that contains the following properties for communication between server and client:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.All%2A> | Calls a method on all connected clients |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Caller%2A> | Calls a method on the client that invoked the hub method |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Others%2A> | Calls a method on all connected clients except the client that invoked the method |

<xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A?displayProperty=nameWithType> also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.AllExcept%2A> | Calls a method on all connected clients except for the specified connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Client%2A> | Calls a method on a specific connected client |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Clients%2A> | Calls a method on specific connected clients |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Group%2A> | Calls a method on all connections in the specified group |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.GroupExcept%2A> | Calls a method on all connections in the specified group, except the specified connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Groups%2A> | Calls a method on multiple groups of connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.OthersInGroup%2A> | Calls a method on a group of connections, excluding the client that invoked the hub method |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.User%2A> | Calls a method on all connections associated with a specific user |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Users%2A> | Calls a method on all connections associated with the specified users |

Each property or method in the preceding tables returns an object with a `SendAsync` method. The `SendAsync` method receives the name of the client method to call and any parameters.

## Send messages to clients

To make calls to specific clients, use the properties of the `Clients` object. In the following example, there are three hub methods:

* `SendMessage` sends a message to all connected clients, using `Clients.All`.
* `SendMessageToCaller` sends a message back to the caller, using `Clients.Caller`.
* `SendMessageToGroup` sends a message to all clients in the `SignalR Users` group.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_Clients":::

## Strongly typed hubs

A drawback of using `SendAsync` is that it relies on a string to specify the client method to be called. This leaves code open to runtime errors if the method name is misspelled or missing from the client.

An alternative to using `SendAsync` is to strongly type the <xref:Microsoft.AspNetCore.SignalR.Hub> class with <xref:Microsoft.AspNetCore.SignalR.Hub%601>. In the following example, the `ChatHub` client method has been extracted out into an interface called `IChatClient`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/IChatClient.cs" id="snippet_Interface":::

This interface can be used to refactor the preceding `ChatHub` example to be strongly typed:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/StronglyTypedChatHub.cs" id="snippet_Class":::

Using `Hub<IChatClient>` enables compile-time checking of the client methods. This prevents issues caused by using strings, since `Hub<T>` can only provide access to the methods defined in the interface. Using a strongly typed `Hub<T>` disables the ability to use `SendAsync`.

> [!NOTE]
> The `Async` suffix isn't stripped from method names. Unless a client method is defined with `.on('MyMethodAsync')`, don't use `MyMethodAsync` as the name.

## Change the name of a hub method

By default, a server hub method name is the name of the .NET method. To change this default behavior for a specific method, use the [HubMethodName](xref:Microsoft.AspNetCore.SignalR.HubMethodNameAttribute) attribute. The client should use this name instead of the .NET method name when invoking the method:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_HubMethodName" highlight="1":::

## Handle events for a connection

The SignalR Hubs API provides the <xref:Microsoft.AspNetCore.SignalR.Hub.OnConnectedAsync%2A> and <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A> virtual methods to manage and track connections. Override the `OnConnectedAsync` virtual method to perform actions when a client connects to the hub, such as adding it to a group:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_OnConnectedAsync":::

Override the `OnDisconnectedAsync` virtual method to perform actions when a client disconnects. If the client disconnects intentionally, such as by calling `connection.stop()`, the `exception` parameter is set to `null`. However, if the client disconnects due to an error, such as a network failure, the `exception` parameter contains an exception that describes the failure:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_OnDisconnectedAsync":::

<xref:Microsoft.AspNetCore.SignalR.IGroupManager.RemoveFromGroupAsync%2A> does not need to be called in <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A>, it's automatically handled for you.

## Handle errors

Exceptions thrown in hub methods are sent to the client that invoked the method. On the JavaScript client, the `invoke` method returns a [JavaScript `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Using_promises). Clients can attach a `catch` handler to the returned promise or use `try`/`catch` with `async`/`await` to handle exceptions:

:::code language="JavaScript" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/wwwroot/chat.js" id="snippet_TryCatch":::

Connections aren't closed when a hub throws an exception. By default, SignalR returns a generic error message to the client, as shown in the following example:

```
Microsoft.AspNetCore.SignalR.HubException: An unexpected error occurred invoking 'SendMessage' on the server.
```

Unexpected exceptions often contain sensitive information, such as the name of a database server in an exception triggered when the database connection fails. SignalR doesn't expose these detailed error messages by default as a security measure. For more information on why exception details are suppressed, see [Security considerations in ASP.NET Core SignalR](xref:signalr/security#exceptions).

If an exceptional condition must be propagated to the client, use the <xref:Microsoft.AspNetCore.SignalR.HubException> class. If a `HubException` is thrown in a hub method, SignalR **sends the entire exception message to the client**, unmodified:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/signalr/hubs/samples/6.x/SignalRHubsSample/Snippets/Hubs/ChatHub.cs" id="snippet_ThrowException":::

> [!NOTE]
> SignalR only sends the `Message` property of the exception to the client. The stack trace and other properties on the exception aren't available to the client.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/signalr/hubs/samples/) [(how to download)](xref:index#how-to-download-a-sample)
* <xref:signalr/introduction>
* <xref:signalr/javascript-client>
* <xref:signalr/publish-to-azure-web-app>
* [SignalR Hub Protocol](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/HubProtocol.md)

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](https://twitter.com/1kevgriff)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/hubs/samples/) [(how to download)](xref:index#how-to-download-a-sample)

## What is a SignalR hub

The SignalR Hubs API enables you to call methods on connected clients from the server. In the server code, you define methods that are called by client. In the client code, you define methods that are called from the server. SignalR takes care of everything behind the scenes that makes real-time client-to-server and server-to-client communications possible.

## Configure SignalR hubs

The SignalR middleware requires some services, which are configured by calling <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A>:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Startup.cs" range="38":::

When adding SignalR functionality to an ASP.NET Core app, setup SignalR routes by calling <xref:Microsoft.AspNetCore.Builder.HubEndpointRouteBuilderExtensions.MapHub%2A> in the `Startup.Configure` method's <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> callback:

```csharp
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chathub");
});
```

[!INCLUDE[](~/includes/signalr-in-shared-framework.md)]

## Create and use hubs

Create a hub by declaring a class that inherits from <xref:Microsoft.AspNetCore.SignalR.Hub>, and add public methods to it. Clients can call methods that are defined as `public`:

```csharp
public class ChatHub : Hub
{
    public Task SendMessage(string user, string message)
    {
        return Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
```

You can specify a return type and parameters, including complex types and arrays, as you would in any C# method. SignalR handles the serialization and deserialization of complex objects and arrays in your parameters and return values.

> [!NOTE]
> Hubs are transient:
>
> * Don't store state in a property on the hub class. Every hub method call is executed on a new hub instance.
> * Don't instantiate a hub directly via dependency injection. To send messages to a client from elsewhere in your application use an [`IHubContext`](xref:signalr/hubcontext).
> * Use `await` when calling asynchronous methods that depend on the hub staying alive. For example, a method such as `Clients.All.SendAsync(...)` can fail if it's called without `await` and the hub method completes before `SendAsync` finishes.

## The Context object

The <xref:Microsoft.AspNetCore.SignalR.Hub> class has a <xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A> property that contains the following properties with information about the connection:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionId%2A> | Gets the unique ID for the connection, assigned by SignalR. There's one connection ID for each connection. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.UserIdentifier%2A> | Gets the [user identifier](xref:signalr/groups). By default, SignalR uses the <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> from the <xref:System.Security.Claims.ClaimsPrincipal> associated with the connection as the user identifier. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.User%2A> | Gets the <xref:System.Security.Claims.ClaimsPrincipal> associated with the current user. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Items%2A> | Gets a key/value collection that can be used to share data within the scope of this connection. Data can be stored in this collection and it will persist for the connection across different hub method invocations. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Features%2A> | Gets the collection of features available on the connection. For now, this collection isn't needed in most scenarios, so it isn't documented in detail yet. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionAborted%2A> | Gets a <xref:System.Threading.CancellationToken> that notifies when the connection is aborted. |

<xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A?displayProperty=nameWithType> also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.GetHttpContextExtensions.GetHttpContext%2A> | Returns the <xref:Microsoft.AspNetCore.Http.HttpContext> for the connection, or `null` if the connection isn't associated with an HTTP request. For HTTP connections, you can use this method to get information such as HTTP headers and query strings. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Abort%2A> | Aborts the connection. |

## The Clients object

The <xref:Microsoft.AspNetCore.SignalR.Hub> class has a <xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A> property that contains the following properties for communication between server and client:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.All%2A> | Calls a method on all connected clients |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Caller%2A> | Calls a method on the client that invoked the hub method |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Others%2A> | Calls a method on all connected clients except the client that invoked the method |

<xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A?displayProperty=nameWithType> also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.AllExcept%2A> | Calls a method on all connected clients except for the specified connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Client%2A> | Calls a method on a specific connected client |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Clients%2A> | Calls a method on specific connected clients |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Group%2A> | Calls a method on all connections in the specified group |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.GroupExcept%2A> | Calls a method on all connections in the specified group, except the specified connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Groups%2A> | Calls a method on multiple groups of connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.OthersInGroup%2A> | Calls a method on a group of connections, excluding the client that invoked the hub method |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.User%2A> | Calls a method on all connections associated with a specific user |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Users%2A> | Calls a method on all connections associated with the specified users |

Each property or method in the preceding tables returns an object with a `SendAsync` method. The `SendAsync` method allows you to supply the name and parameters of the client method to call.

## Send messages to clients

To make calls to specific clients, use the properties of the `Clients` object. In the following example, there are three Hub methods:

* `SendMessage` sends a message to all connected clients, using `Clients.All`.
* `SendMessageToCaller` sends a message back to the caller, using `Clients.Caller`.
* `SendMessageToGroup` sends a message to all clients in the `SignalR Users` group.

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="HubMethods":::

## Strongly typed hubs

A drawback of using `SendAsync` is that it relies on a magic string to specify the client method to be called. This leaves code open to runtime errors if the method name is misspelled or missing from the client.

An alternative to using `SendAsync` is to strongly type the <xref:Microsoft.AspNetCore.SignalR.Hub> with <xref:Microsoft.AspNetCore.SignalR.Hub%601>. In the following example, the `ChatHub` client methods have been extracted out into an interface called `IChatClient`.

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/IChatClient.cs" id="snippet_IChatClient":::

This interface can be used to refactor the preceding `ChatHub` example:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/StronglyTypedChatHub.cs" range="8-18,36":::

Using `Hub<IChatClient>` enables compile-time checking of the client methods. This prevents issues caused by using magic strings, since `Hub<T>` can only provide access to the methods defined in the interface.

Using a strongly typed `Hub<T>` disables the ability to use `SendAsync`. Any methods defined on the interface can still be defined as asynchronous. In fact, each of these methods should return a `Task`. Since it's an interface, don't use the `async` keyword. For example:

```csharp
public interface IClient
{
    Task ClientMethod();
}
```

> [!NOTE]
> The `Async` suffix isn't stripped from the method name. Unless your client method is defined with `.on('MyMethodAsync')`, you shouldn't use `MyMethodAsync` as a name.

## Change the name of a hub method

By default, a server hub method name is the name of the .NET method. However, you can use the [HubMethodName](xref:Microsoft.AspNetCore.SignalR.HubMethodNameAttribute) attribute to change this default and manually specify a name for the method. The client should use this name, instead of the .NET method name, when invoking the method:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="HubMethodName" highlight="1":::

## Handle events for a connection

The SignalR Hubs API provides the <xref:Microsoft.AspNetCore.SignalR.Hub.OnConnectedAsync%2A> and <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A> virtual methods to manage and track connections. Override the `OnConnectedAsync` virtual method to perform actions when a client connects to the Hub, such as adding it to a group:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="OnConnectedAsync":::

Override the `OnDisconnectedAsync` virtual method to perform actions when a client disconnects. If the client disconnects intentionally (by calling `connection.stop()`, for example), the `exception` parameter will be `null`. However, if the client is disconnected due to an error (such as a network failure), the `exception` parameter will contain an exception describing the failure:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="OnDisconnectedAsync":::

<xref:Microsoft.AspNetCore.SignalR.IGroupManager.RemoveFromGroupAsync%2A> does not need to be called in <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A>, it's automatically handled for you.

[!INCLUDE[](~/includes/connectionid-signalr.md)]

## Handle errors

Exceptions thrown in your hub methods are sent to the client that invoked the method. On the JavaScript client, the `invoke` method returns a [JavaScript `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Using_promises). When the client receives an error with a handler attached to the promise using `catch`, it's invoked and passed as a JavaScript `Error` object:

:::code language="JavaScript" source="hubs/samples/2.x/SignalRChat/wwwroot/js/chat.js" range="23":::

If your Hub throws an exception, connections aren't closed. By default, SignalR returns a generic error message to the client. For example:

```text
Microsoft.AspNetCore.SignalR.HubException: An unexpected error occurred invoking 'MethodName' on the server.
```

Unexpected exceptions often contain sensitive information, such as the name of a database server in an exception triggered when the database connection fails. SignalR doesn't expose these detailed error messages by default as a security measure. For more information on why exception details are suppressed, see [Security considerations in ASP.NET Core SignalR](xref:signalr/security#exceptions).

If you have an exceptional condition you *do* want to propagate to the client, you can use the <xref:Microsoft.AspNetCore.SignalR.HubException> class. If you throw a `HubException` from your hub method, SignalR **will** send the entire message to the client, unmodified:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="ThrowHubException" highlight="3":::

> [!NOTE]
> SignalR only sends the `Message` property of the exception to the client. The stack trace and other properties on the exception aren't available to the client.

## Additional resources

* <xref:signalr/introduction>
* <xref:signalr/javascript-client>
* <xref:signalr/publish-to-azure-web-app>

:::moniker-end

:::moniker range="< aspnetcore-3.0"

By [Rachel Appel](https://twitter.com/rachelappel) and [Kevin Griffin](https://twitter.com/1kevgriff)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/hubs/samples/) [(how to download)](xref:index#how-to-download-a-sample)

## What is a SignalR hub

The SignalR Hubs API enables you to call methods on connected clients from the server. In the server code, you define methods that are called by client. In the client code, you define methods that are called from the server. SignalR takes care of everything behind the scenes that makes real-time client-to-server and server-to-client communications possible.

## Configure SignalR hubs

The SignalR middleware requires some services, which are configured by calling <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A>:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Startup.cs" range="38":::

When adding SignalR functionality to an ASP.NET Core app, setup SignalR routes by calling <xref:Microsoft.AspNetCore.Builder.SignalRAppBuilderExtensions.UseSignalR%2A> in the `Startup.Configure` method:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Startup.cs" range="57-60":::

## Create and use hubs

Create a hub by declaring a class that inherits from <xref:Microsoft.AspNetCore.SignalR.Hub>, and add public methods to it. Clients can call methods that are defined as `public`:

```csharp
public class ChatHub : Hub
{
    public Task SendMessage(string user, string message)
    {
        return Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
```

You can specify a return type and parameters, including complex types and arrays, as you would in any C# method. SignalR handles the serialization and deserialization of complex objects and arrays in your parameters and return values.

> [!NOTE]
> Hubs are transient:
>
> * Don't store state in a property on the hub class. Every hub method call is executed on a new hub instance.
> * Don't instantiate a hub directly via dependency injection. To send messages to a client from elsewhere in your application use an [`IHubContext`](xref:signalr/hubcontext).
> * Use `await` when calling asynchronous methods that depend on the hub staying alive. For example, a method such as `Clients.All.SendAsync(...)` can fail if it's called without `await` and the hub method completes before `SendAsync` finishes.

## The Context object

The <xref:Microsoft.AspNetCore.SignalR.Hub> class has a <xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A> property that contains the following properties with information about the connection:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionId%2A> | Gets the unique ID for the connection, assigned by SignalR. There's one connection ID for each connection. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.UserIdentifier%2A> | Gets the [user identifier](xref:signalr/groups). By default, SignalR uses the <xref:System.Security.Claims.ClaimTypes.NameIdentifier?displayProperty=nameWithType> from the <xref:System.Security.Claims.ClaimsPrincipal> associated with the connection as the user identifier. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.User%2A> | Gets the <xref:System.Security.Claims.ClaimsPrincipal> associated with the current user. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Items%2A> | Gets a key/value collection that can be used to share data within the scope of this connection. Data can be stored in this collection and it will persist for the connection across different hub method invocations. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Features%2A> | Gets the collection of features available on the connection. For now, this collection isn't needed in most scenarios, so it isn't documented in detail yet. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.ConnectionAborted%2A> | Gets a <xref:System.Threading.CancellationToken> that notifies when the connection is aborted. |

<xref:Microsoft.AspNetCore.SignalR.Hub.Context%2A?displayProperty=nameWithType> also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.GetHttpContextExtensions.GetHttpContext%2A> | Returns the <xref:Microsoft.AspNetCore.Http.HttpContext> for the connection, or `null` if the connection isn't associated with an HTTP request. For HTTP connections, you can use this method to get information such as HTTP headers and query strings. |
| <xref:Microsoft.AspNetCore.SignalR.HubCallerContext.Abort%2A> | Aborts the connection. |

## The Clients object

The <xref:Microsoft.AspNetCore.SignalR.Hub> class has a <xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A> property that contains the following properties for communication between server and client:

| Property | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.All%2A> | Calls a method on all connected clients |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Caller%2A> | Calls a method on the client that invoked the hub method |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.Others%2A> | Calls a method on all connected clients except the client that invoked the method |

<xref:Microsoft.AspNetCore.SignalR.Hub.Clients%2A?displayProperty=nameWithType> also contains the following methods:

| Method | Description |
|--|--|
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.AllExcept%2A> | Calls a method on all connected clients except for the specified connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Client%2A> | Calls a method on a specific connected client |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Clients%2A> | Calls a method on specific connected clients |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Group%2A> | Calls a method on all connections in the specified group |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.GroupExcept%2A> | Calls a method on all connections in the specified group, except the specified connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Groups%2A> | Calls a method on multiple groups of connections |
| <xref:Microsoft.AspNetCore.SignalR.IHubCallerClients%601.OthersInGroup%2A> | Calls a method on a group of connections, excluding the client that invoked the hub method |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.User%2A> | Calls a method on all connections associated with a specific user |
| <xref:Microsoft.AspNetCore.SignalR.IHubClients%601.Users%2A> | Calls a method on all connections associated with the specified users |

Each property or method in the preceding tables returns an object with a `SendAsync` method. The `SendAsync` method allows you to supply the name and parameters of the client method to call.

## Send messages to clients

To make calls to specific clients, use the properties of the `Clients` object. In the following example, there are three Hub methods:

* `SendMessage` sends a message to all connected clients, using `Clients.All`.
* `SendMessageToCaller` sends a message back to the caller, using `Clients.Caller`.
* `SendMessageToGroup` sends a message to all clients in the `SignalR Users` group.

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="HubMethods":::

## Strongly typed hubs

A drawback of using `SendAsync` is that it relies on a magic string to specify the client method to be called. This leaves code open to runtime errors if the method name is misspelled or missing from the client.

An alternative to using `SendAsync` is to strongly type the <xref:Microsoft.AspNetCore.SignalR.Hub> with <xref:Microsoft.AspNetCore.SignalR.Hub%601>. In the following example, the `ChatHub` client methods have been extracted out into an interface called `IChatClient`.

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/IChatClient.cs" id="snippet_IChatClient":::

This interface can be used to refactor the preceding `ChatHub` example:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/StronglyTypedChatHub.cs" range="8-18,36":::

Using `Hub<IChatClient>` enables compile-time checking of the client methods. This prevents issues caused by using magic strings, since `Hub<T>` can only provide access to the methods defined in the interface.

Using a strongly typed `Hub<T>` disables the ability to use `SendAsync`. Any methods defined on the interface can still be defined as asynchronous. In fact, each of these methods should return a `Task`. Since it's an interface, don't use the `async` keyword. For example:

```csharp
public interface IClient
{
    Task ClientMethod();
}
```

> [!NOTE]
> The `Async` suffix isn't stripped from the method name. Unless your client method is defined with `.on('MyMethodAsync')`, you shouldn't use `MyMethodAsync` as a name.

## Change the name of a hub method

By default, a server hub method name is the name of the .NET method. However, you can use the [HubMethodName](xref:Microsoft.AspNetCore.SignalR.HubMethodNameAttribute) attribute to change this default and manually specify a name for the method. The client should use this name, instead of the .NET method name, when invoking the method:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="HubMethodName" highlight="1":::

## Handle events for a connection

The SignalR Hubs API provides the <xref:Microsoft.AspNetCore.SignalR.Hub.OnConnectedAsync%2A> and <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A> virtual methods to manage and track connections. Override the `OnConnectedAsync` virtual method to perform actions when a client connects to the Hub, such as adding it to a group:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="OnConnectedAsync":::

Override the `OnDisconnectedAsync` virtual method to perform actions when a client disconnects. If the client disconnects intentionally (by calling `connection.stop()`, for example), the `exception` parameter will be `null`. However, if the client is disconnected due to an error (such as a network failure), the `exception` parameter will contain an exception describing the failure:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="OnDisconnectedAsync":::

<xref:Microsoft.AspNetCore.SignalR.IGroupManager.RemoveFromGroupAsync%2A> does not need to be called in <xref:Microsoft.AspNetCore.SignalR.Hub.OnDisconnectedAsync%2A>, it's automatically handled for you.

[!INCLUDE[](~/includes/connectionid-signalr.md)]

## Handle errors

Exceptions thrown in your hub methods are sent to the client that invoked the method. On the JavaScript client, the `invoke` method returns a [JavaScript `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Using_promises). When the client receives an error with a handler attached to the promise using `catch`, it's invoked and passed as a JavaScript `Error` object:

:::code language="JavaScript" source="hubs/samples/2.x/SignalRChat/wwwroot/js/chat.js" range="23":::

If your Hub throws an exception, connections aren't closed. By default, SignalR returns a generic error message to the client. For example:

```
Microsoft.AspNetCore.SignalR.HubException: An unexpected error occurred invoking 'MethodName' on the server.
```

Unexpected exceptions often contain sensitive information, such as the name of a database server in an exception triggered when the database connection fails. SignalR doesn't expose these detailed error messages by default as a security measure. For more information on why exception details are suppressed, see [Security considerations in ASP.NET Core SignalR](xref:signalr/security#exceptions).

If you have an exceptional condition you *do* want to propagate to the client, you can use the <xref:Microsoft.AspNetCore.SignalR.HubException> class. If you throw a `HubException` from your hub method, SignalR **will** send the entire message to the client, unmodified:

:::code language="csharp" source="hubs/samples/2.x/SignalRChat/Hubs/ChatHub.cs" id="ThrowHubException" highlight="3":::

> [!NOTE]
> SignalR only sends the `Message` property of the exception to the client. The stack trace and other properties on the exception aren't available to the client.

## Additional resources

* <xref:signalr/introduction>
* <xref:signalr/javascript-client>
* <xref:signalr/publish-to-azure-web-app>

:::moniker-end
