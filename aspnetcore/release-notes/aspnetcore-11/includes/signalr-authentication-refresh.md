### SignalR authentication refresh

SignalR connections can refresh authentication without dropping the connection when the access token expires. The server exposes a `/refresh` endpoint alongside `/negotiate` and reports the token lifetime in the negotiate response. A client re-authenticates before the token expires, so a hub connection that previously closed when its bearer token aged out can stay open.

<!-- TODO: Update `EnableAuthenticationRefresh`, `CloseOnAuthenticationExpiration`, `OnAuthenticationRefresh`, `OnAuthenticationRefreshedAsync`, `WithAuthenticationRefresh`, `AuthenticationRefreshed`, `AuthenticationRefreshFailed`, and `RefreshAuthenticationAsync` to <xref:> once API docs are published. -->

Enable the feature per hub on the server. The server can inspect or reject a refreshed identity by returning a value from `OnAuthenticationRefresh`:

```csharp
using System.Security.Claims;

app.MapHub<ChatHub>("/chat", options =>
{
    options.EnableAuthenticationRefresh = true;
    options.CloseOnAuthenticationExpiration = true;

    // Optional: inspect the refreshed identity and decide whether to accept it.
    options.OnAuthenticationRefresh = context =>
    {
        var previousSubject = context.PreviousUser.FindFirstValue("sub")
            ?? context.PreviousUser.FindFirstValue(ClaimTypes.NameIdentifier);
        var newSubject = context.NewUser.FindFirstValue("sub")
            ?? context.NewUser.FindFirstValue(ClaimTypes.NameIdentifier);

        return Task.FromResult(
            previousSubject is not null &&
            string.Equals(previousSubject, newSubject, StringComparison.Ordinal));
    };
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

Automatic refresh is on by default in the .NET client and is configurable with `WithAuthenticationRefresh`. Refresh notifications are events on `HubConnection`, and `RefreshAuthenticationAsync` requests an immediate refresh after the app obtains new claims:

```csharp
await using var connection = new HubConnectionBuilder()
    .WithUrl("https://example.com/chat")
    .WithAuthenticationRefresh(options =>
    {
        // EnableAutoRefresh is true by default.
        options.RefreshBeforeExpiration = TimeSpan.FromMinutes(1);
    })
    .Build();

connection.AuthenticationRefreshed += context => Task.CompletedTask;
connection.AuthenticationRefreshFailed += context => Task.CompletedTask;

await connection.StartAsync();

// Refresh immediately after acquiring a token with updated claims.
await connection.RefreshAuthenticationAsync();
```
