### SignalR TypeScript client supports authentication refresh

The SignalR TypeScript client supports refreshing an access token without reconnecting. It can schedule a refresh based on the token lifetime that the server reports or refresh immediately after the app obtains updated claims.

Configure automatic refresh by using `withAuthenticationRefresh`. Register success and failure handlers on the built connection, and call `refreshAuthentication` to request a manual refresh:

```typescript
const connection = new signalR.HubConnectionBuilder()
  .withUrl("/clock", { accessTokenFactory: getAccessToken })
  .withAuthenticationRefresh({
    enableAutoRefresh: true,
    refreshBeforeExpirationInMilliseconds: 120_000,
  })
  .build();

connection.onAuthenticationRefreshed((context) => {
  console.log(`New token lifetime: ${context.newTokenLifetimeInSeconds}`);
});

connection.onAuthenticationRefreshFailed((context) => {
  console.error(context.error);
});

await connection.start();

// Refresh immediately after acquiring a token with updated claims.
await connection.refreshAuthentication();
```
