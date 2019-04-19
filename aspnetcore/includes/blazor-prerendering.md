While a Blazor server-side app is prerendering, certain actions, such as calling into JavaScript, aren't possible because a connection with the browser hasn't been established. Components may need to render differently when prerendered.

To delay JavaScript interop calls until after the connection with the browser is established, you can use the `OnAfterRenderAsync` component lifecycle event. This event is only called after the app is fully rendered and the client connection is established.

To conditionally render different content based on whether the app is currently being prerendered or not, use the `IsConnected` property on the `IComponentContext` service. `IComponentContext` only returns `true` if there's an active connection to the client.
