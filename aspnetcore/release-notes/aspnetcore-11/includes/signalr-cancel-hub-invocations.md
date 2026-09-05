### Cancel hub invocations from the client

The SignalR client can cancel a regular, non-streaming hub method invocation. Previously only streaming invocations could be canceled from the client. Now, when you pass a <xref:System.Threading.CancellationToken> to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionExtensions.InvokeAsync%2A> and cancel it, the client sends a cancellation message, and the hub method's `CancellationToken` parameter is triggered on the server.

```csharp
// Client — canceling the token cancels the server-side invocation.
using var cts = new CancellationTokenSource();
var work = connection.InvokeAsync("LongRunningWork", cts.Token);
// ...
cts.Cancel();
```

```csharp
// Hub — accept a CancellationToken to observe client cancellation.
public class WorkHub : Hub
{
    public async Task LongRunningWork(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromMinutes(5), cancellationToken);
    }
}
```
