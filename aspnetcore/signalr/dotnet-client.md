---
title: ASP.NET Core SignalR .NET client
ai-usage: ai-assisted
description: Work with the ASP.NET Core SignalR .NET client, including package installation, connecting to a hub, calling hub and client methods, and error handling.
monikerRange: '>= aspnetcore-2.1'
ms.date: 10/27/2026

# customer intent: As an ASP.NET developer, I want to configure the ASP.NET Core SignalR .NET client, so I can connect to a SignalR hub and use hub and client methods.
---
# ASP.NET Core SignalR .NET client

The ASP.NET Core SignalR .NET client library lets you communicate with SignalR hubs from .NET apps. This article describes how to use the APIs to connect to a SignalR hub, and call the .NET hub and client methods. The code sample in this article is a Windows Presentation Foundation (WPF) app that uses the ASP.NET Core SignalR .NET client.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/dotnet-client/samples) ([how to download](xref:fundamentals/index#how-to-download-a-sample))

## Install the SignalR .NET client package

The [Microsoft.AspNetCore.SignalR.Client](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package is required for .NET clients to connect to SignalR hubs. You can install the client library from the Visual Studio **Package Manager Console** or by using the .NET CLI.

# [Visual Studio](#tab/visual-studio)

Run the following command in the **Package Manager Console** window:

```powershell
Install-Package Microsoft.AspNetCore.SignalR.Client
```

# [.NET CLI](#tab/net-cli)

Run the following command in a command shell:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client
```

---

## Connect to a hub

To establish a connection, create a `HubConnectionBuilder` and call `Build`. The hub URL, protocol, transport type, log level, headers, and other options can be configured while building a connection. Configure any required options by inserting any of the `HubConnectionBuilder` methods into `Build`. Start the connection with `StartAsync`.

[!code-csharp[Build hub connection](dotnet-client/samples/SignalRChatClient/MainWindow.xaml.cs?name=snippet_MainWindowClass&highlight=15-17,39)]


## Handle lost connection

:::moniker range=">= aspnetcore-3.0"

To reconnect with clients, you can set up automatic reconnection or configure the reconnection manually.

### Automatically reconnect

The <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection> can be configured to automatically reconnect by using the `WithAutomaticReconnect` method on the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. It doesn't automatically reconnect by default.

```csharp
HubConnection connection= new HubConnectionBuilder()
    .WithUrl(new Uri("http://127.0.0.1:5000/chathub"))
    .WithAutomaticReconnect()
    .Build();
```

Without any parameters, `WithAutomaticReconnect()` configures the client to wait 0, 2, 10, and 30 seconds respectively before trying each reconnect attempt. It stops after four failed attempts.

Before starting any reconnect attempts, the `HubConnection` transitions to the `HubConnectionState.Reconnecting` state and fires the `Reconnecting` event. This approach provides an opportunity to warn users that the connection is lost and to disable UI elements. Non-interactive apps can start queuing or dropping messages.

```csharp
connection.Reconnecting += error =>
{
    Debug.Assert(connection.State == HubConnectionState.Reconnecting);

    // Notify users the connection was lost and the client is reconnecting.
    // Start queuing or dropping messages.

    return Task.CompletedTask;
};
```

If the client successfully reconnects within its first four attempts, the `HubConnection` transitions back to the `Connected` state and fires the `Reconnected` event. This approach provides an opportunity to inform users the connection is now reestablished and to dequeue any queued messages.

Because the connection looks entirely new to the server, a new `ConnectionId` is provided to the `Reconnected` event handlers.

> [!WARNING]
> The `Reconnected` event handler's `connectionId` parameter is `null` if the `HubConnection` is configured to [skip negotiation](configuration.md#configure-client-options).

```csharp
connection.Reconnected += connectionId =>
{
    Debug.Assert(connection.State == HubConnectionState.Connected);

    // Notify users the connection was reestablished.
    // Start dequeuing messages queued while reconnecting if any.

    return Task.CompletedTask;
};
```

`WithAutomaticReconnect()` doesn't configure the `HubConnection` to retry initial start failures, so start failures need to be handled manually:

```csharp
public static async Task<bool> ConnectWithRetryAsync(HubConnection connection, CancellationToken token)
{
    // Keep trying to until we can start or the token is canceled.
    while (true)
    {
        try
        {
            await connection.StartAsync(token);
            Debug.Assert(connection.State == HubConnectionState.Connected);
            return true;
        }
        catch when (token.IsCancellationRequested)
        {
            return false;
        }
        catch
        {
            // Failed to connect, trying again in 5000 ms.
            Debug.Assert(connection.State == HubConnectionState.Disconnected);
            await Task.Delay(5000);
        }
    }
}
```

If the client doesn't successfully reconnect within its first four attempts, the `HubConnection` transitions to the `Disconnected` state and fires the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.Closed> event. This approach provides an opportunity to attempt to restart the connection manually or inform users the connection is now permanently lost.

```csharp
connection.Closed += error =>
{
    Debug.Assert(connection.State == HubConnectionState.Disconnected);

    // Notify users the connection has been closed or manually try to restart the connection.

    return Task.CompletedTask;
};
```

To configure a custom number of reconnect attempts before disconnecting or change the reconnect timing, `WithAutomaticReconnect` accepts an array of numbers representing the delay in milliseconds to wait before starting each reconnect attempt.

```csharp
HubConnection connection = new HubConnectionBuilder()
    .WithUrl(new Uri("http://127.0.0.1:5000/chathub"))
    .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.Zero, TimeSpan.FromSeconds(10) })
    .Build();

    // .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30) }) yields the default behavior.
```

The preceding example configures the `HubConnection` to start attempting reconnects immediately after the connection is lost. This approach is also true for the default configuration.

- If the first reconnect attempt fails, the second reconnect attempt also starts immediately instead of waiting 2 seconds as defined in the default configuration.

- If the second reconnect attempt fails, the third reconnect attempt starts in 10 seconds, which is the same behavior defined in the default configuration.

- The custom behavior then diverges again from the default behavior by stopping after the third reconnect attempt failure. In the default configuration, one more reconnect attempt is made after another 30 seconds.

For more control over the timing and number of automatic reconnect attempts, `WithAutomaticReconnect` accepts an object implementing the `IRetryPolicy` interface, which has a single method named `NextRetryDelay`. `NextRetryDelay` takes a single argument with the type `RetryContext`. The `RetryContext` has three properties: `PreviousRetryCount` (type `long`), `ElapsedTime` (type `TimeSpan`), and `RetryReason` (type `Exception`).

- Before the first reconnect attempt, `PreviousRetryCount` and `ElapsedTime` are both zero (0), and `RetryReason` is the Exception that caused the lost connection.

- After each failed retry attempt, `PreviousRetryCount` increments by one, `ElapsedTime` updates to reflect the amount of time spent reconnecting so far, and `RetryReason` is the Exception that caused the last reconnect attempt to fail.

`NextRetryDelay` must return either a `TimeSpan` value that represents the time to wait before the next reconnect attempt or `null` if the `HubConnection` should stop reconnecting.

```csharp
public class RandomRetryPolicy : IRetryPolicy
{
    private readonly Random _random = new Random();

    public TimeSpan? NextRetryDelay(RetryContext retryContext)
    {
        // If we've been reconnecting for less than 60 seconds so far,
        // wait between 0 and 10 seconds before the next reconnect attempt.
        if (retryContext.ElapsedTime < TimeSpan.FromSeconds(60))
        {
            return TimeSpan.FromSeconds(_random.NextDouble() * 10);
        }
        else
        {
            // If we've been reconnecting for more than 60 seconds so far, stop reconnecting.
            return null;
        }
    }
}
```

```csharp
HubConnection connection = new HubConnectionBuilder()
    .WithUrl(new Uri("http://127.0.0.1:5000/chathub"))
    .WithAutomaticReconnect(new RandomRetryPolicy())
    .Build();
```

Alternatively, you can write code to reconnect your client manually, as demonstrated in the next section.

:::moniker-end

### Manually reconnect

:::moniker range="< aspnetcore-3.0"

> [!WARNING]
> In versions earlier than 3.0, the .NET client for SignalR doesn't automatically reconnect. You must write code to reconnect your client manually.

:::moniker-end

Use the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.Closed> event to respond to a lost connection. For example, you might want to automate reconnection.

The `Closed` event requires a delegate that returns a `Task`, which allows async code to run without using `async void`. To satisfy the delegate signature in a `Closed` event handler that runs synchronously, return `Task.CompletedTask`:

```csharp
connection.Closed += (error) => {
    // Do your close logic.
    return Task.CompletedTask;
};
```

The main reason for the async support is so you can restart the connection. Starting a connection is an async action.

In a `Closed` handler that restarts the connection, consider waiting for some random delay to prevent overloading the server, as shown in the following example:

[!code-csharp[Use Closed event handler to automate reconnection](dotnet-client/samples/SignalRChatClient/MainWindow.xaml.cs?name=snippet_ClosedRestart)]

## Call hub methods from client

`InvokeAsync` calls methods on the hub. Pass the hub method name and any arguments defined in the hub method to `InvokeAsync`. SignalR is asynchronous, so use `async` and `await` when making the calls.

[!code-csharp[InvokeAsync method](dotnet-client/samples/SignalRChatClient/MainWindow.xaml.cs?name=snippet_InvokeAsync)]

The `InvokeAsync` method returns a `Task` that completes when the server method returns. The return value, if any, is provided as the result of the `Task`. Any exceptions thrown by the method on the server produce a faulted `Task`. Use `await` syntax to wait for the server method to complete and `try...catch` syntax to handle errors.

The `SendAsync` method returns a `Task` that completes when the message is sent to the server. No return value is provided because this `Task` doesn't wait until the server method completes. Any exceptions thrown on the client while sending the message produce a faulted `Task`. Use `await` and `try...catch` syntax to handle message send errors.

> [!NOTE]
> Calling hub methods from a client is supported only when using the Azure SignalR Service in *Default* mode. For more information, see [Frequently Asked Questions](/azure/azure-signalr/signalr-resource-faq).

:::moniker range=">= aspnetcore-11.0"

### Cancel a hub method invocation

Pass a <xref:System.Threading.CancellationToken> to `InvokeAsync` to cancel a long-running hub method. Canceling the token sends a cancellation message to the server, which triggers the `CancellationToken` parameter of the running hub method:

```csharp
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

try
{
    var report = await hubConnection.InvokeAsync<Report>(
        "GenerateReport", reportId, cts.Token);
}
catch (OperationCanceledException)
{
    // The invocation was canceled.
}
```

The hub method must declare a `CancellationToken` parameter to observe the cancellation. The server supplies that parameter; don't pass an argument for it from the client:

```csharp
public class ReportHub : Hub
{
    public async Task<Report> GenerateReport(
        int reportId, CancellationToken cancellationToken)
    {
        // Pass cancellationToken to the work being performed.
    }
}
```

Note the following about cancellation:

* Cancellation is cooperative. The server requests cancellation, but the hub method decides whether and how quickly to stop. The server sends a completion message for the invocation either way.
* If the hub method allows an <xref:System.OperationCanceledException> to propagate, the invocation completes with an error rather than as a canceled invocation.
* The `CancellationToken` supplied to the hub method is also canceled when the connection closes, so it isn't only triggered by an explicit client cancellation.
* The caller's `Task` is canceled on the client as soon as the cancellation message is sent. It doesn't wait for the hub method to stop.
* Cancellation applies to `InvokeAsync`, which tracks an invocation ID. `SendAsync` doesn't wait for the hub method, so there's nothing for it to cancel.

Before ASP.NET Core 11.0, a `CancellationToken` passed to a non-streaming `InvokeAsync` only canceled the wait on the client. The hub method ran to completion on the server. Only streaming invocations could be canceled. This is also the behavior against a server running an earlier version of ASP.NET Core.

Canceling a non-streaming invocation is supported by the .NET client only. The JavaScript, Java, and Swift clients can cancel streaming invocations, but their `invoke` equivalents don't accept a cancellation argument. See [ASP.NET Core SignalR clients](client-features.md).

:::moniker-end

## Call client methods from hub

Define the methods that the hub calls by using `connection.On`. Typically, handlers are registered after building the connection and before starting it:

[!code-csharp[Define client methods](dotnet-client/samples/SignalRChatClient/MainWindow.xaml.cs?name=snippet_ConnectionOn)]

The preceding code in `connection.On` runs when server-side code calls it by using the `SendAsync` method:

[!code-csharp[Call client method](dotnet-client/samples/SignalRChat/Hubs/ChatHub.cs?name=snippet_SendMessage)]

Registering handlers before calling `StartAsync` is recommended to avoid missing incoming messages that the server may send immediately upon connecting. However, handlers can also be registered dynamically after the connection has already started.

To unregister a handler:

* Call <xref:System.IDisposable.Dispose*> on the `IDisposable` returned by `connection.On`:

  ```csharp
  IDisposable handler = connection.On<string, string>("ReceiveMessage", (user, message) =>
  {
      // ...
  });

  // Later, stop listening for messages:
  handler.Dispose();
  ```

* In ASP.NET Core 2.2 and later, call <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.Remove*> with the method name to remove all handlers registered for that method:

  ```csharp
  connection.Remove("ReceiveMessage");
  ```

> [!NOTE]
> While the hub side of the connection supports strongly typed messaging, the client must register by using the generic method <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.On*?displayProperty=nameWithType> with the method name. For an example, see [Host ASP.NET Core SignalR in background services](background-services.md#call-a-signalr-hub-from-a-background-service).

## Error handling and logging

Handle errors with a `try...catch` statement. Inspect the `Exception` object to determine the proper action to take after an error occurs:

[!code-csharp[Logging](dotnet-client/samples/SignalRChatClient/MainWindow.xaml.cs?name=snippet_ErrorHandling)]

:::moniker range=">= aspnetcore-11.0"

## Refresh authentication without reconnecting

When the server enables authentication refresh, the .NET client can replace the credentials on an open connection instead of letting the connection close when its access token expires. Automatic refresh is enabled by default, and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection> exposes a `RefreshAuthenticationAsync` method that requests an immediate refresh. To change the refresh timing or turn automatic refresh off, call `WithAuthenticationRefresh` when building the connection. For the client options, the refresh events, and the server options that enable the feature, see [SignalR authentication and authorization](authn-and-authz.md#authentication-refresh).

:::moniker-end

## Related content

* [Hubs](hubs.md)
* [JavaScript client](javascript-client.md)
* [Publish to Azure](publish-to-azure-web-app.md)
* [Azure Functions development and configuration with Azure SignalR Service](/azure/azure-signalr/signalr-concept-serverless-development-config)
