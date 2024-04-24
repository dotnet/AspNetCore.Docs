:::moniker range="< aspnetcore-6.0 >= aspnetcore-3.1"


This article explains how to get started with WebSockets in ASP.NET Core. [WebSocket](https://wikipedia.org/wiki/WebSocket) ([RFC 6455](https://tools.ietf.org/html/rfc6455)) is a protocol that enables two-way persistent communication channels over TCP connections. It's used in apps that benefit from fast, real-time communication, such as chat, dashboard, and game apps.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/websockets/samples) ([how to download](xref:index#how-to-download-a-sample)). [How to run](#sample-app).

## SignalR

[ASP.NET Core SignalR](xref:signalr/introduction) is a library that simplifies adding real-time web functionality to apps. It uses WebSockets whenever possible.

For most applications, we recommend SignalR over raw WebSockets. SignalR provides transport fallback for environments where WebSockets isn't available. It also provides a basic remote procedure call app model. And in most scenarios, SignalR has no significant performance disadvantage compared to using raw WebSockets.

For some apps, [gRPC on .NET](xref:grpc/index) provides an alternative to WebSockets.

## Prerequisites

* Any OS that supports ASP.NET Core:  
  * Windows 7 / Windows Server 2008 or later
  * Linux
  * macOS  
* If the app runs on Windows with IIS:
  * Windows 8 / Windows Server 2012 or later
  * IIS 8 / IIS 8 Express
  * WebSockets must be enabled. See the [IIS/IIS Express support](#iisiis-express-support) section.  
* If the app runs on [HTTP.sys](xref:fundamentals/servers/httpsys):
  * Windows 8 / Windows Server 2012 or later
* For supported browsers, see [Can I use](https://caniuse.com/?search=websockets).

## Configure the middleware

Add the WebSockets middleware in the `Configure` method of the `Startup` class:

:::code language="csharp" source="~/fundamentals/websockets/samples/2.x/WebSocketsSample/Startup.cs" id="snippet_UseWebSockets":::

> [!NOTE]
> If you would like to accept WebSocket requests in a controller, the call to `app.UseWebSockets` must occur before `app.UseEndpoints`.

The following settings can be configured:

* <xref:Microsoft.AspNetCore.Builder.WebSocketOptions.KeepAliveInterval%2A> - How frequently to send "ping" frames to the client to ensure proxies keep the connection open. The default is two minutes.
* <xref:Microsoft.AspNetCore.Builder.WebSocketOptions.AllowedOrigins%2A> - A list of allowed Origin header values for WebSocket requests. By default, all origins are allowed. See "WebSocket origin restriction" below for details.

:::code language="csharp" source="~/fundamentals/websockets/samples/2.x/WebSocketsSample/Startup.cs" id="snippet_UseWebSocketsOptions":::

## Accept WebSocket requests

Somewhere later in the request life cycle (later in the `Configure` method or in an action method, for example) check if it's a WebSocket request and accept the WebSocket request.

The following example is from later in the `Configure` method:

:::code language="csharp" source="~/fundamentals/websockets/samples/2.x/WebSocketsSample/Startup.cs" id="snippet_AcceptWebSocket" highlight="7":::

A WebSocket request could come in on any URL, but this sample code only accepts requests for `/ws`.

A similar approach can be taken in a controller method:

:::code language="csharp" source="~/fundamentals/websockets/samples/6.x/WebSocketsSample/Controllers/WebSocketController.cs" id="snippet":::

When using a WebSocket, you **must** keep the middleware pipeline running for the duration of the connection. If you attempt to send or receive a WebSocket message after the middleware pipeline ends, you may get an exception like the following:

```
System.Net.WebSockets.WebSocketException (0x80004005): The remote party closed the WebSocket connection without completing the close handshake. ---> System.ObjectDisposedException: Cannot write to the response body, the response has completed.
Object name: 'HttpResponseStream'.
```

If you're using a background service to write data to a WebSocket, make sure you keep the middleware pipeline running. Do this by using a <xref:System.Threading.Tasks.TaskCompletionSource%601>. Pass the `TaskCompletionSource` to your background service and have it call <xref:System.Threading.Tasks.TaskCompletionSource%601.TrySetResult%2A> when you finish with the WebSocket. Then `await` the <xref:System.Threading.Tasks.TaskCompletionSource%601.Task> property during the request, as shown in the following example:

:::code language="csharp" source="~/fundamentals/websockets/samples/2.x/WebSocketsSample/Startup2.cs" id="snippet_AcceptWebSocket":::

The WebSocket closed exception can also happen when returning too soon from an action method. When accepting a socket in an action method, wait for the code that uses the socket to complete before returning from the action method.

Never use `Task.Wait`, `Task.Result`, or similar blocking calls to wait for the socket to complete, as that can cause serious threading issues. Always use `await`.

## Send and receive messages

The `AcceptWebSocketAsync` method upgrades the TCP connection to a WebSocket connection and provides a <xref:System.Net.WebSockets.WebSocket> object. Use the `WebSocket` object to send and receive messages.

The code shown earlier that accepts the WebSocket request passes the `WebSocket` object to an `Echo` method. The code receives a message and immediately sends back the same message. Messages are sent and received in a loop until the client closes the connection:

:::code language="csharp" source="~/fundamentals/websockets/samples/2.x/WebSocketsSample/Startup.cs" id="snippet_Echo":::

When accepting the WebSocket connection before beginning the loop, the middleware pipeline ends. Upon closing the socket, the pipeline unwinds. That is, the request stops moving forward in the pipeline when the WebSocket is accepted. When the loop is finished and the socket is closed, the request proceeds back up the pipeline.

## Handle client disconnects

The server isn't automatically informed when the client disconnects due to loss of connectivity. The server receives a disconnect message only if the client sends it, which can't be done if the internet connection is lost. If you want to take some action when that happens, set a timeout after nothing is received from the client within a certain time window.

If the client isn't always sending messages and you don't want to time out just because the connection goes idle, have the client use a timer to send a ping message every X seconds. On the server, if a message hasn't arrived within 2\*X seconds after the previous one, terminate the connection and report that the client disconnected. Wait for twice the expected time interval to leave extra time for network delays that might hold up the ping message.

> [!NOTE]
> The internal [`ManagedWebSocket`](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Net.WebSockets/src/System/Net/WebSockets/ManagedWebSocket.cs) handles the Ping/Pong frames implicitly to keep the connection alive if the `KeepAliveInterval` option is greater than zero, which defaults to 30 seconds (`TimeSpan.FromSeconds(30)`).

## WebSocket origin restriction

The protections provided by CORS don't apply to WebSockets. Browsers do **not**:

* Perform CORS pre-flight requests.
* Respect the restrictions specified in `Access-Control` headers when making WebSocket requests.

However, browsers do send the `Origin` header when issuing WebSocket requests. Applications should be configured to validate these headers to ensure that only WebSockets coming from the expected origins are allowed.

If you're hosting your server on "https://server.com" and hosting your client on "https://client.com", add "https://client.com" to the <xref:Microsoft.AspNetCore.Builder.WebSocketOptions.AllowedOrigins%2A> list for WebSockets to verify.

:::code language="csharp" source="~/fundamentals/websockets/samples/2.x/WebSocketsSample/Startup.cs" id="snippet_UseWebSocketsOptionsAO" highlight="6-7":::

> [!NOTE]
> The `Origin` header is controlled by the client and, like the `Referer` header, can be faked. Do **not** use these headers as an authentication mechanism.

## IIS/IIS Express support

Windows Server 2012 or later and Windows 8 or later with IIS/IIS Express 8 or later has support for the WebSocket protocol.

> [!NOTE]
> WebSockets are always enabled when using IIS Express.

### Enabling WebSockets on IIS

To enable support for the WebSocket protocol on Windows Server 2012 or later:

> [!NOTE]
> These steps are not required when using IIS Express

1. Use the **Add Roles and Features** wizard from the **Manage** menu or the link in **Server Manager**.
1. Select **Role-based or Feature-based Installation**. Select **Next**.
1. Select the appropriate server (the local server is selected by default). Select **Next**.
1. Expand **Web Server (IIS)** in the **Roles** tree, expand **Web Server**, and then expand **Application Development**.
1. Select **WebSocket Protocol**. Select **Next**.
1. If additional features aren't needed, select **Next**.
1. Select **Install**.
1. When the installation completes, select **Close** to exit the wizard.

To enable support for the WebSocket protocol on Windows 8 or later:

> [!NOTE]
> These steps are not required when using IIS Express

1. Navigate to **Control Panel** > **Programs** > **Programs and Features** > **Turn Windows features on or off** (left side of the screen).
1. Open the following nodes: **Internet Information Services** > **World Wide Web Services** > **Application Development Features**.
1. Select the **WebSocket Protocol** feature. Select **OK**.

### Disable WebSocket when using socket.io on Node.js

If using the WebSocket support in [socket.io](https://socket.io/) on [Node.js](https://nodejs.org/), disable the default IIS WebSocket module using the `webSocket` element in *web.config* or *applicationHost.config*. If this step isn't performed, the IIS WebSocket module attempts to handle the WebSocket communication rather than Node.js and the app.

```xml
<system.webServer>
  <webSocket enabled="false" />
</system.webServer>
```

## Sample app

The [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/websockets/samples) that accompanies this article is an echo app. It has a webpage that makes WebSocket connections, and the server resends any messages it receives back to the client. The sample app isn't configured to run from Visual Studio with IIS Express, so run the app in a command shell with [`dotnet run`](/dotnet/core/tools/dotnet-run) and navigate in a browser to `http://localhost:5000`. The webpage shows the connection status:

:::image source="~/fundamentals/websockets/_static/start.png" alt-text="Initial state of webpage before WebSockets connection":::

Select **Connect** to send a WebSocket request to the URL shown. Enter a test message and select **Send**. When done, select **Close Socket**. The **Communication Log** section reports each open, send, and close action as it happens.

:::image source="~/fundamentals/websockets/_static/end.png" alt-text="Final state of webpage after WebSockets connection and test messages are sent and received":::

:::moniker-end
