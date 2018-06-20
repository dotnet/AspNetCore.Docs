// Creates a connection and restricts transports to WebSockets and Server Sent Events.
var connection = new HubConnectionBuilder()
    .WithUrl("url", HttpTransportType.WebSockets | HttpTransportType.ServerSentEvents)
    .Build();

// Creates a connection with a JSON Web Token.
var connection = new HubConnectionBuilder()
    .WithUrl("url", options => {
        options.AccessTokenProvider = async () => {
            // Get access token and return it.
        };
    })
    .Build();

// Creates a connection, and sets headers, cookies, and client certificates.
var connection = new HubConnectionBuilder()
    .WithUrl("url", options => {
        options.Headers["Foo"] = "Bar";
        options.Cookies.Add(new Cookie(...));
        options.ClientCertificates.Add(...);
    })
    .Build();