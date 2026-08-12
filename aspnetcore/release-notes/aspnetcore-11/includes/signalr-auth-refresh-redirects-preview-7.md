### SignalR .NET client supports authentication refresh after redirects

The SignalR .NET client extends [SignalR authentication refresh](#signalr-authentication-refresh) so it works when negotiate redirects to another server, contributed by [@MoChilia](https://github.com/MoChilia). This client change enables support for redirecting servers such as Azure SignalR Service, which hasn't enabled the feature yet.

The client preserves the app-token provider across the redirect, adopts a refreshed transport token from the response, and retains `tokenLifetimeSeconds` so automatic refresh remains scheduled after the original token expires.

Thank you [@MoChilia](https://github.com/MoChilia) for this contribution!
