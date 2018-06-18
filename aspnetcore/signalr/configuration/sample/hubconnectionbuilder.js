// Creates a basic connection
const connection = new signalR.HubConnectionBuilder()
    .withUrl("url")
    .build();

// Sets the transport type.
// Transport types are lsited in `HttpConnectionDispatcherOptions`
const connection = new signalR.HubConnectionBuilder()
    .withUrl("url", HttpTransportType.WebSockets)
    .build();

// Sets the protocol such as Messagepack
const connection = new signalR.HubConnectionBuilder()
    .withUrl("url")
    .withHubProtocol(IHubProtocol)
    .build();


const connection = new signalR.HubConnectionBuilder()
    .withUrl("url", IHttpConnectionOptions)
    .build();


hubConnection.serverTimeoutInMilliseconds = 5 * 1000; // 5 seconds
hubConnection.keepAliveIntervalInMilliseconds = 10 * 1000; // 10 seconds