### SignalR authentication refresh

SignalR connections can refresh authentication without dropping the connection when the access token expires. The server exposes a `/refresh` endpoint alongside `/negotiate` and reports the token lifetime in the negotiate response. The .NET client re-authenticates before the token expires, so a hub connection that previously closed when its bearer token aged out can stay open. This feature is implemented for the .NET client; the JavaScript/TypeScript client and Azure SignalR Service support are in progress.

<!-- TODO: Update `EnableAuthenticationRefresh`, `OnAuthenticationRefresh`, `OnAuthenticationRefreshedAsync`, and `WithAuthenticationRefresh` to <xref:> once API docs are published. -->

Enable the feature per hub on the server:

```csharp
app.MapHub<ChatHub>("/chat", options =>
{
    options.EnableAuthenticationRefresh = true;

    // Optional: decide whether a given connection may refresh.
    options.OnAuthenticationRefresh = context => ValueTask.FromResult(true);
});
```

A hub can react to a refreshed identity by overriding `OnAuthenticationRefreshedAsync`:

```csharp
public class ChatHub : Hub
{
    public override Task OnAuthenticationRefreshedAsync()
    {
        // The connection's User has been updated with the refreshed token.
        return Task.CompletedTask;
    }
}
```

Automatic refresh is on by default in the .NET client and is configurable with `WithAuthenticationRefresh`:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chat")
    .WithAuthenticationRefresh(options =>
    {
        // EnableAutoRefresh is true by default.
        options.RefreshBeforeExpiration = TimeSpan.FromMinutes(1);
        options.OnAuthenticationRefreshed = context => Task.CompletedTask;
        options.OnAuthenticationRefreshFailed = context => Task.CompletedTask;
    })
    .Build();
```
